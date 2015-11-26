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
            get { return "Server=localhost;Database=voluntariado;Uid=root;Pwd=root;"; }
        }
        private void conectarDB()
        {
            Conn.ConnectionString = connString;
            if (Conn.State != System.Data.ConnectionState.Open)
            {
                Conn.Open();
            }
        }
        private void desconectar()
        {
            if (Conn.State == System.Data.ConnectionState.Open)
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
