using ConnectionDatabase;
using MaisVoluntarios.Core;
using MySql.Data.MySqlClient;
using System.Text;

namespace MaisVoluntarios.Repository
{
    public class AreaAtuacaoRepositorio
    {
        RepositorioDB db = new RepositorioDB();
        MySqlCommand cmm = new MySqlCommand();
        StringBuilder sql = new StringBuilder();

        public void Create(AreaAtuacao pArea)
        {
            sql.Append("INSERT INTO areadeatuacao (areaT, idVoluntario) " +
                "VALUES (@areaT, @idV)");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@areaT", pArea.areaT);
            cmm.Parameters.AddWithValue("@idV", pArea.voluntario.idVoluntario);

            db.executarComando(cmm);
            sql.Clear();
        }

        public void Update(AreaAtuacao pArea)
        {
            sql.Append("UPDATE areadeatuacao " +
                "SET areaT = @areaT " +
                "WHERE idVoluntario = @idV");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@areaT", pArea.areaT);
            cmm.Parameters.AddWithValue("@idV", pArea.voluntario.idVoluntario);

            db.executarComando(cmm);
            sql.Clear();
        }
    }
}
