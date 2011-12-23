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
        private int _id;
        private string _nome;
        private int _idade;

        public Aluno()
        {
        }

        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string nome
        {
            get
            {
                return _nome;
            }
            set
            {
                _nome = value;
            }
        }

        public int idade
        {
            get
            {
                return _idade;
            }
            set
            {
                _idade = value;
            }
        }
    }

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
            Initialize();
        }

        public void Initialize()
        {
            // Initialize data source. Use "Dev" connection string from configuration.

            if (WebConfigurationManager.ConnectionStrings["Dev"] == null ||
            WebConfigurationManager.ConnectionStrings["Dev"].ConnectionString.Trim() == "")
            {
                throw new ApplicationException("A connection string named 'Dev' with a valid connection string " +
                "must exist in the <connectionStrings> configuration section for the application.");
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
                throw new ApplicationException("Data error: {0}", err);
            }
            finally
            {
                _con.Close();
            }
        }
        //
        // Delete the Employee by ID.
        //   This method assumes that ConflictDetection is set to OverwriteValues.
        public int DeleteAluno(int id)
        {

            // Create DELETE Command.
            const string sqlCmd = "DELETE FROM aluno WHERE (id = @id)";

            _con = new MySqlConnection(connectionString);
            _cmd = new MySqlCommand(sqlCmd, _con);

            _cmd.Parameters.AddWithValue("@id", id);
            //cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

            int result = 0;

            try
            {
                _con.Open();

                result = _cmd.ExecuteNonQuery();
            }
            catch (MySqlException err)
            {
                // Handle exception.
                throw new ApplicationException("Data error: {0}", err);
            }
            finally
            {
                _con.Close();
            }

            return result;
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
