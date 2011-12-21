using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.Configuration;
using MySql.Data.MySqlClient;

namespace Web1.Classes
{
    public class Aluno
    {
        public String nome;
        public int idade;
        public char sexo;
    }

    public class DBUtil
    {
        private String connectionString;

        public DBUtil()
        {
            if (WebConfigurationManager.ConnectionStrings["Dev"] == null)
            {
                throw new ApplicationException("Missing ConnectionString variable in web.config.");
            }
            else
            {
                connectionString = WebConfigurationManager.ConnectionStrings["Dev"].ConnectionString;
            }
        }

        public DataSet GetAlunos()
        {
            string query = "SELECT * FROM aluno";
            MySqlCommand cmd = new MySqlCommand(query);
            return FillDataSet(cmd, "Alunos");
        }

        public void AddAluno(Aluno obj_aluno)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            // Create the Command.
            string insertSQL = "INSERT INTO aluno ";
            insertSQL += "(nome, idade, sexo)";
            insertSQL += "VALUES (@nome,  @idade,  @sexo)";
            MySqlCommand cmd = new MySqlCommand(insertSQL, con);
            cmd.Parameters.AddWithValue("@nome", obj_aluno.nome);
            cmd.Parameters.AddWithValue("@idade", obj_aluno.idade);
            cmd.Parameters.AddWithValue("@sexo", obj_aluno.sexo);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }


        private DataSet FillDataSet(MySqlCommand cmd, string tableName)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            cmd.Connection = con;
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                try
                {
                    con.Open();
                    adapter.Fill(ds, tableName);
                }
                finally
                {
                    con.Close();
                }
                return ds;
            }
        }
    }
}