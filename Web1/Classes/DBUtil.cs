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
        MySqlConnection _con;
        MySqlCommand _cmd;
        //DataTable _dt;
        //MySqlDataAdapter _sda;
        //MySqlCommandBuilder scb;

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
            _cmd = new MySqlCommand("SELECT * FROM aluno");
            return FillDataSet(_cmd, "Alunos");
        }

        public void AddAluno(Aluno obj_aluno)
        {
            _con = new MySqlConnection(connectionString);

            // Create the Command.
            string insertSQL = "INSERT INTO aluno ";
            insertSQL += "(nome, idade, sexo)";
            insertSQL += "VALUES (@nome,  @idade,  @sexo)";
            _cmd = new MySqlCommand(insertSQL, _con);

            _cmd.Parameters.AddWithValue("@nome", obj_aluno.nome);
            _cmd.Parameters.AddWithValue("@idade", obj_aluno.idade);
            _cmd.Parameters.AddWithValue("@sexo", obj_aluno.sexo);

            try
            {
                _con.Open();
                _cmd.ExecuteNonQuery();
            }
            finally
            {
                _con.Close();
            }
        }

        private DataSet FillDataSet(MySqlCommand cmd, string tableName)
        {
            _con = new MySqlConnection(connectionString);
            _cmd.Connection = _con;
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                try
                {
                    _con.Open();
                    adapter.Fill(ds, tableName);
                }
                finally
                {
                    _con.Close();
                }
                return ds;
            }
        }
    }
}