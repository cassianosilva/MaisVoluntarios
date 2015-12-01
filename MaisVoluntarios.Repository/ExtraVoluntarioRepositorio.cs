using ConnectionDatabase;
using MaisVoluntarios.Core;
using MySql.Data.MySqlClient;
using System.Text;

namespace MaisVoluntarios.Repository
{
    public class ExtraVoluntarioRepositorio
    {
        RepositorioDB db = new RepositorioDB();
        MySqlCommand cmm = new MySqlCommand();
        StringBuilder sql = new StringBuilder();

        public void Create(ExtraVoluntario pExtra)
        {
            sql.Append("INSERT INTO extravoluntario (volJa, disponibilidade, descricao, escolaridade, idVoluntario) " +
                "VALUES (@volJa, @disponibilidade, @descricao, @escolaridade, @idV)");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@volJa", pExtra.volJa);
            cmm.Parameters.AddWithValue("@disponibilidade", pExtra.disponibilidade);
            cmm.Parameters.AddWithValue("@descricao", pExtra.descricao);
            cmm.Parameters.AddWithValue("@escolaridade", pExtra.escolaridade);
            cmm.Parameters.AddWithValue("@idV", pExtra.voluntario.idVoluntario);

            db.executarComando(cmm);
            sql.Clear();
        }

        public void Update(ExtraVoluntario pExtra)
        {
            sql.Append("UPDATE extravoluntario " +
                "SET volJa = @volJa, disponibilidade = @disponibilidade, descricao = @descricao, " +
                "escolaridade = @escolaridade " +
                "WHERE idVoluntario = @idV");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@volJa", pExtra.volJa);
            cmm.Parameters.AddWithValue("@disponibilidade", pExtra.disponibilidade);
            cmm.Parameters.AddWithValue("@descricao", pExtra.descricao);
            cmm.Parameters.AddWithValue("@escolaridade", pExtra.escolaridade);
            cmm.Parameters.AddWithValue("@idV", pExtra.voluntario.idVoluntario);

            db.executarComando(cmm);
            sql.Clear();
        }
    }
}
