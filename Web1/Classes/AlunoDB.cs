using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.Configuration;
using MySql.Data.MySqlClient;

namespace Web1.Classes
{
   /* public class Aluno
    {
        private int id;
        private string nome;
        private int idade;

        public int id
        {
            get { return id; }
            set { id = value; }
        }
        public string nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public string idade
        {
            get { return idade; }
            set { idade = value; }
        }

        public Aluno(int id, string nome, int idade)
        {
            this.id = id;
            this.nome = nome;
            this.idade = idade;
        }

        public Aluno() { }
    }*/

    public class AlunoDB
    {
        private String connectionString;
        MySqlConnection _con;
        MySqlCommand _cmd;
        //DataTable _dt;
        //MySqlDataAdapter _sda;
        //MySqlCommandBuilder scb;

        public AlunoDB()
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

        public void InsertAluno(string nome, string idade)
        {
            _con = new MySqlConnection(connectionString);

            // Create INSERT Command.
            string insertSQL = "INSERT INTO aluno ";
            insertSQL += "(nome, idade)";
            insertSQL += "VALUES (@nome,  @idade)";
            _cmd = new MySqlCommand(insertSQL, _con);

            _cmd.Parameters.AddWithValue("@nome", nome);
            _cmd.Parameters.AddWithValue("@idade", idade);

            try
            {
                _con.Open();
                _cmd.ExecuteNonQuery();
            }
            catch (MySqlException err)
            {
                throw new ApplicationException("Data error.");
            }
            finally
            {
                _con.Close();
            }
        }

        public void DeleteAluno(int id)
        {
            _con = new MySqlConnection(connectionString);

            // Create DELETE Command.
            string deleteSQL = "DELETE FROM aluno ";
            deleteSQL += "WHERE (id = @id)";
            _cmd = new MySqlCommand(deleteSQL, _con);

            _cmd.Parameters.AddWithValue("@id", id);

            try
            {
                _con.Open();
                _cmd.ExecuteNonQuery();
            }
            catch (MySqlException err)
            {
                throw new ApplicationException("Data error.");
            }
            finally
            {
                _con.Close();
            }
        }

        public void UpdateAluno(int id, string nome, string idade)
        {
            _con = new MySqlConnection(connectionString);

            // Create UPDATE Command.
            string updateSQL = "UPDATE aluno ";
            updateSQL += "SET nome = @nome, idade = @idade ";
            updateSQL += "WHERE (id = @id)";
            _cmd = new MySqlCommand(updateSQL, _con);

            _cmd.Parameters.AddWithValue("@id", id);
            _cmd.Parameters.AddWithValue("@nome", nome);
            _cmd.Parameters.AddWithValue("@idade", idade);

            try
            {
                _con.Open();
                _cmd.ExecuteNonQuery();
            }
            catch (MySqlException err)
            {
                throw new ApplicationException("Data error.");
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