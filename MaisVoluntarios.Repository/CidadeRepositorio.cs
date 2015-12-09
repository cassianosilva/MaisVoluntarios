using ConnectionDatabase;
using MaisVoluntarios.Core;
using MySql.Data.MySqlClient;
using System.Text;

namespace MaisVoluntarios.Repository
{
    public class CidadeRepositorio
    {
        RepositorioDB db = new RepositorioDB();
        MySqlCommand cmm = new MySqlCommand();
        StringBuilder sql = new StringBuilder();

        public void Create(Cidade pCidade)
        {
            sql.Append("INSERT INTO cidade (nomeCidade, estado, cep, idVoluntario) " +
                "VALUES (@nomeCidade, @estado, @cep, @idV)");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@nomeCidade", pCidade.nomeCidade);
            cmm.Parameters.AddWithValue("@estado", pCidade.estado);
            cmm.Parameters.AddWithValue("@cep", pCidade.cep);
            cmm.Parameters.AddWithValue("@idV", pCidade.voluntario.idVoluntario);

            db.executarComando(cmm);
            sql.Clear();
        }

        public void Update(Cidade pCidade)
        {
            sql.Append("UPDATE cidade " +
                "SET nomeCidade = @nomeCidade, estado = @estado, cep = @cep " +
                "WHERE idVoluntario = @idV");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@nomeCidade", pCidade.nomeCidade);
            cmm.Parameters.AddWithValue("@estado", pCidade.estado);
            cmm.Parameters.AddWithValue("@cep", pCidade.cep);
            cmm.Parameters.AddWithValue("@idV", pCidade.voluntario.idVoluntario);

            db.executarComando(cmm);
            sql.Clear();
        }
        public void UpdateEmpresa(Cidade pCidade)
        {
            sql.Append("UPDATE cidade " +
                "SET nomeCidade = @nomeCidade, estado = @estado, cep = @cep " +
                "WHERE idEmpresa = @idV");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@nomeCidade", pCidade.nomeCidade);
            cmm.Parameters.AddWithValue("@estado", pCidade.estado);
            cmm.Parameters.AddWithValue("@cep", pCidade.cep);
            cmm.Parameters.AddWithValue("@idV", pCidade.empresa.idEmpresa);

            db.executarComando(cmm);
            sql.Clear();
        }
    }
}
