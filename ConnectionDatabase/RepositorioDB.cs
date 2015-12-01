using MySql.Data.MySqlClient;
using System.Data;

namespace ConnectionDatabase
{
    public class RepositorioDB
    {
        public MySqlConnection Conn = new MySqlConnection();
        public MySqlCommand cmm;
        public MySqlDataReader dr;

        public string connString
        {
            get { return "Server=localhost;Database=voluntariado;Uid=root;Pwd=1234;"; }
        }
        private void conectarDB()
        {
            Conn.ConnectionString = connString;
            if (Conn.State != ConnectionState.Open)
            {
                Conn.Open();
            }
        }
        private void desconectar()
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
        }
        public void executarComando(MySqlCommand cmm)
        {
            conectarDB();
            cmm.Connection = Conn;
            try
            {
                cmm.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }

            desconectar();
        }

        public int executarComandoScalar(MySqlCommand cmm)
        {
            int lastId;

            conectarDB();
            cmm.Connection = Conn;

            try
            {
                lastId = (int)cmm.ExecuteScalar();
            }
            catch (MySqlException ex)
            {
                dr.Dispose();
                throw ex;
            }

            return lastId;
        }

        public MySqlDataReader executarConsulta(MySqlCommand cmm)
        {

            conectarDB();
            cmm.Connection = Conn;

            try
            {

                dr = cmm.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (MySqlException ex)
            {
                dr.Dispose();
                throw ex;
            }

            return dr;
        }

    }
}
