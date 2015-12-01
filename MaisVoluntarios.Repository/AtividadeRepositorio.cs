using ConnectionDatabase;
using MaisVoluntarios.Core;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Text;

namespace MaisVoluntarios.Repository
{
    public class AtividadeRepositorio
    {
        RepositorioDB db = new RepositorioDB();
        MySqlCommand cmm = new MySqlCommand();
        StringBuilder sql = new StringBuilder();

        public List<Atividade> getAll()
        {
            List<Atividade> atividades = new List<Atividade>();

            sql.Append("SELECT idAtividade, nomeAtividade " +
                "FROM atividade " +
                "ORDER BY nomeAtividade");

            cmm.CommandText = sql.ToString();
            MySqlDataReader dr = db.executarConsulta(cmm);

            while (dr.Read())
            {
                atividades.Add(new Atividade
                {
                    idAtividade = (int)dr["idAtividade"],
                    nomeAtividade = (string)dr["nomeAtividade"]
                });
            }

            dr.Close();
            dr.Dispose();
            sql.Clear();

            return atividades;
        }

        public Atividade getOne(int pId)
        {
            sql.Append("SELECT * FROM atividade");

            cmm.CommandText = sql.ToString();
            MySqlDataReader dr = db.executarConsulta(cmm);
            dr.Read();
            Atividade atividade = new Atividade
            {
                idAtividade = (int)dr["idAtividade"],
                nomeAtividade = (string)dr["nomeAtividade"]
            };

            dr.Close();
            dr.Dispose();
            sql.Clear();

            return atividade;
        }

        public void Create(Atividade pAtividade)
        {
            sql.Append("INSERT INTO atividade (nomeAtividade) " +
                "VALUES (@nomeAtividade)");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@nomeAtividade", pAtividade.nomeAtividade);
        }

        public void Delete(int pId)
        {
            sql.Append("DELETE FROM atividade " +
                "WHERE idAtividade = @id");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@id", pId);
        }
    }
}
