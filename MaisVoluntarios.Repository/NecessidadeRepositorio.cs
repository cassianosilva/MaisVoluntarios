using ConnectionDatabase;
using MaisVoluntarios.Core;
using MySql.Data.MySqlClient;
using System.Text;

namespace MaisVoluntarios.Repository
{
    public class NecessidadeRepositorio
    {
        RepositorioDB db = new RepositorioDB();
        MySqlCommand cmm = new MySqlCommand();
        StringBuilder sql = new StringBuilder();

        public void Create(Necessidade pNecessidade)
        {
            sql.Append("INSERT INTO necessidade (idAtividade, idEmpresa) " +
                "VALUES (@idAtividade, @idE)");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@idAtividade", pNecessidade.atividade.idAtividade);
            cmm.Parameters.AddWithValue("@idE", pNecessidade.empresa.idEmpresa);

            db.executarComando(cmm);
            sql.Clear();
        }

        public void Update(Necessidade pNecessidade)
        {
            sql.Append("UPDATE necessidade " +
                "SET idAtividade = @idAtividade " +
                "WHERE idEmpresa = @idEmp)");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@idAtividade", pNecessidade.atividade.idAtividade);
            cmm.Parameters.AddWithValue("@idEmp", pNecessidade.empresa.idEmpresa);

            db.executarComando(cmm);
            sql.Clear();
        }
    }
}
