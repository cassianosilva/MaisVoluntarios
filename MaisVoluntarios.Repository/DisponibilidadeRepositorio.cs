using ConnectionDatabase;
using MaisVoluntarios.Core;
using MySql.Data.MySqlClient;
using System.Text;

namespace MaisVoluntarios.Repository
{
    public class DisponibilidadeRepositorio
    {
        RepositorioDB db = new RepositorioDB();
        MySqlCommand cmm = new MySqlCommand();
        StringBuilder sql = new StringBuilder();

        public void Create(Disponibilidade pDisp)
        {
            sql.Append("INSERT INTO disponibilidade (idVoluntario, idAtividade) " +
                "VALUES (@idV, @idAtividade)");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@idV", pDisp.voluntario.idVoluntario);
            cmm.Parameters.AddWithValue("@idAtividade", pDisp.atividade.idAtividade);

            db.executarComando(cmm);
            sql.Clear();
        }

        public void Update(Disponibilidade pDisp)
        {
            sql.Append("UPDATE disponibilidade " +
                "SET idAtividade = @idAtividade " +
                "WHERE idVoluntario = @idV");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@idV", pDisp.voluntario.idVoluntario);
            cmm.Parameters.AddWithValue("@idAtividade", pDisp.atividade.idAtividade);

            db.executarComando(cmm);
            sql.Clear();
        }
    }
}
