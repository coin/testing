using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.Configuration;
using MySql.Data.MySqlClient;

namespace Web1.Classes
{
    public class Turma
    {
        private int _id;
        private string _nome;

        public Turma()
        {
        }

        public int idturma
        {
            get { return _id; }
            set { idturma = value; }
        }

        public string nome
        {
            get { return _nome; }
            set { nome = value; }
        }
    }

    public class TurmaDB
    {
        private String connectionString;
        MySqlConnection _con;
        MySqlCommand _cmd;

        public TurmaDB()
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

        public DataSet GetTurmas()
        {
            _cmd = new MySqlCommand("SELECT * FROM turma");
            return FillDataSet(_cmd, "turma");
        }

        public void InsertTurma(string nome, string nota)
        {
            _con = new MySqlConnection(connectionString);

            // Create INSERT Command.
            string insertSQL = "INSERT INTO turma ";
            insertSQL += "(nome, nota) ";
            insertSQL += "VALUES (@nome, @nota)";
            _cmd = new MySqlCommand(insertSQL, _con);

            _cmd.Parameters.AddWithValue("@nome", nome);
            _cmd.Parameters.AddWithValue("@nota", nota);

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

        public void UpdateTurma(int idturma, string nome, string nota)
        {
            _con = new MySqlConnection(connectionString);

            // Create UPDATE Command.
            string updateSQL = "UPDATE turma ";
            updateSQL += "SET nome = @nome, nota = @nota ";
            updateSQL += "WHERE (idturma = @idturma)";
            _cmd = new MySqlCommand(updateSQL, _con);

            _cmd.Parameters.AddWithValue("@idturma", idturma);
            _cmd.Parameters.AddWithValue("@nome", nome);
            _cmd.Parameters.AddWithValue("@nota", nota);

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
        // Delete the Turma by ID.
        // This method assumes that ConflictDetection is set to OverwriteValues.
        public int DeleteTurma(int idturma)
        {

            // Create DELETE Command.
            const string sqlCmd = "DELETE FROM turma WHERE (idturma = @idturma)";

            _con = new MySqlConnection(connectionString);
            _cmd = new MySqlCommand(sqlCmd, _con);

            _cmd.Parameters.AddWithValue("@idturma", idturma);
            //cmd.Parameters.Add("@idturma", SqlDbType.Int).Value = idturma;

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