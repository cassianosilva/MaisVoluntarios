using ConnectionDatabase;
using MaisVoluntarios.Core;
using MySql.Data.MySqlClient;
using System.Text;

namespace MaisVoluntarios.Repository
{
    public class ExtraEmpresaRepositorio
    {
        RepositorioDB db = new RepositorioDB();
        MySqlCommand cmm = new MySqlCommand();
        StringBuilder sql = new StringBuilder();

        public void Create(ExtraEmpresa pExtra)
        {
            sql.Append("INSERT INTO extraempresa (descricao, idEmpresa) " +
                "VALUES (@descricao, @idE)");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@descricao", pExtra.descricao);
            cmm.Parameters.AddWithValue("@idE", pExtra.empresa.idEmpresa);

            db.executarComando(cmm);
            sql.Clear();
        }

        public void Update(ExtraEmpresa pExtra)
        {
            sql.Append("UPDATE extraempresa " +
                "SET descricao = @descricao " +
                "WHERE idEmpresa = @idEmp");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@descricao", pExtra.descricao);
            cmm.Parameters.AddWithValue("@idEmp", pExtra.empresa.idEmpresa);

            db.executarComando(cmm);
            sql.Clear();
        }
    }
}
