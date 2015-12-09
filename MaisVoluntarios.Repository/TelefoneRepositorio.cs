using ConnectionDatabase;
using MaisVoluntarios.Core;
using MySql.Data.MySqlClient;
using System.Text;

namespace MaisVoluntarios.Repository
{
    public class TelefoneRepositorio
    {
        RepositorioDB db = new RepositorioDB();
        MySqlCommand cmm = new MySqlCommand();
        StringBuilder sql = new StringBuilder();

        public void Create(Telefone pTelefone)
        {
            sql.Append("INSERT INTO telefone (dddTelefone, telefone, dddCelular, celular, idVoluntario) " +
                "VALUES (@dddTelefone, @telefone, @$dddCelular, @celular, @idV)");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@dddTelefone", pTelefone.dddTelefone);
            cmm.Parameters.AddWithValue("@telefone", pTelefone.telefone);
            cmm.Parameters.AddWithValue("@dddCelular", pTelefone.dddCelular);
            cmm.Parameters.AddWithValue("@celular", pTelefone.celular);
            cmm.Parameters.AddWithValue("@idV", pTelefone.voluntario.idVoluntario);

            db.executarComando(cmm);
            sql.Clear();
        }

        public void Update(Telefone pTelefone)
        {
            sql.Append("UPDATE telefone " +
                "SET dddTelefone = @dddTelefone, telefone = @telefone, dddCelular = @dddCelular, celular = @celular " +
                "WHERE idVoluntario = @idV");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@dddTelefone", pTelefone.dddTelefone);
            cmm.Parameters.AddWithValue("@telefone", pTelefone.telefone);
            cmm.Parameters.AddWithValue("@dddCelular", pTelefone.dddCelular);
            cmm.Parameters.AddWithValue("@celular", pTelefone.celular);
            cmm.Parameters.AddWithValue("@idV", pTelefone.voluntario.idVoluntario);

            db.executarComando(cmm);
            sql.Clear();
        }
    }
}
