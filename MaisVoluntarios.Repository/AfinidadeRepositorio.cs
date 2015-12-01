using ConnectionDatabase;
using MaisVoluntarios.Core;
using MySql.Data.MySqlClient;
using System.Text;

namespace MaisVoluntarios.Repository
{
    public class AfinidadeRepositorio
    {
        RepositorioDB db = new RepositorioDB();
        MySqlCommand cmm = new MySqlCommand();
        StringBuilder sql = new StringBuilder();

        public void Create(Afinidade pAfinidade)
        {
            sql.Append("INSERT INTO afinidade (afinidade, idVoluntario) " +
                "VALUES (@afinidade, @idV)");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@afinidade", pAfinidade.afinidade);
            cmm.Parameters.AddWithValue("@idV", pAfinidade.voluntario.idVoluntario);

            db.executarComando(cmm);
            sql.Clear();
        }

        public void Update(Afinidade pAfinidade)
        {
            sql.Append("UPDATE afinidade " +
                "SET afinidade = @afinidade " +
                "WHERE idVoluntario = @idV");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@afinidade", pAfinidade.afinidade);
            cmm.Parameters.AddWithValue("@idV", pAfinidade.voluntario.idVoluntario);

            db.executarComando(cmm);
            sql.Clear();
        }
    }
}
