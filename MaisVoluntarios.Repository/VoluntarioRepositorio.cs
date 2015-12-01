using ConnectionDatabase;
using MaisVoluntarios.Core;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Text;

namespace MaisVoluntarios.Repository
{
    public class VoluntarioRepositorio
    {
        RepositorioDB db = new RepositorioDB();
        MySqlCommand cmm = new MySqlCommand();
        StringBuilder sql = new StringBuilder();
        TelefoneRepositorio telefoneDAO = new TelefoneRepositorio();
        CidadeRepositorio cidadeDAO = new CidadeRepositorio();
        AreaAtuacaoRepositorio areaDAO = new AreaAtuacaoRepositorio();
        ExtraVoluntarioRepositorio extraDAO = new ExtraVoluntarioRepositorio();
        AfinidadeRepositorio afinidadeDAO = new AfinidadeRepositorio();
        DisponibilidadeRepositorio disponibilidadeDAO = new DisponibilidadeRepositorio();
        AcessoRepositorio acessoDAO = new AcessoRepositorio();

        public List<Voluntario> getAll()
        {
            List<Voluntario> voluntarios = new List<Voluntario>();

            sql.Append("SELECT v.idVoluntario, v.nomeVoluntario, v.cpfVoluntario, v.dataNascimento, v.sexo, v.email, " +
                "t.dddTelefone, t.telefone, t.dddCelular, t.celular, a.afinidade, " +
                "c.nomeCidade, c.estado, e.descricao, e.disponibilidade, att.nomeAtividade, aa.areaT " +
                "FROM voluntario v " +
                "INNER JOIN telefone t ON t.idVoluntario = v.idVoluntario " +
                "INNER JOIN afinidade a ON a.idVoluntario = v.idVoluntario " +
                "INNER JOIN cidade c ON c.idVoluntario = v.idVoluntario " +
                "INNER JOIN extravoluntario e ON e.idVoluntario = v.idVoluntario " +
                "INNER JOIN areadeatuacao aa ON aa.idVoluntario = v.idVoluntario " +
                "INNER JOIN disponibilidade vat ON vat.idVoluntario = v.idVoluntario " +
                "INNER JOIN atividade att ON att.idAtividade = vat.idAtividade " +
                "ORDER BY v.nomeVoluntario");

            cmm.CommandText = sql.ToString();
            MySqlDataReader dr = db.executarConsulta(cmm);

            while (dr.Read())
            {
                voluntarios.Add(new Voluntario
                {
                    idVoluntario = (int)dr["idVoluntario"],
                    nomeVoluntario = (string)dr["nomeVoluntario"],
                    cpfVoluntario = (string)dr["cpfVoluntario"],
                    dataNascimento = (string)dr["dataNascimento"],
                    sexo = (string)dr["sexo"],
                    email = (string)dr["email"],
                    atividade = new Atividade { nomeAtividade = (string)dr["nomeAtividade"] },
                    cidade = new Cidade
                    {
                        nomeCidade = (string)dr["nomeCidade"],
                        estado = (string)dr["estado"]
                    },
                    telefone = new Telefone
                    {
                        dddTelefone = (string)dr["dddTelefone"],
                        telefone = (string)dr["telefone"],
                        dddCelular = (string)dr["dddCelular"],
                        celular = (string)dr["celular"]
                    },
                    areaDeAtuacao = new AreaAtuacao { areaT = (string)dr["areaT"] },
                    extraVoluntario = new ExtraVoluntario
                    {
                        disponibilidade = (string)dr["disponibilidade"],
                        descricao = (string)dr["descricao"]
                    },
                    afinidade = new Afinidade { afinidade = (string)dr["afinidade"] }
                });
            }

            sql.Clear();
            dr.Close();
            dr.Dispose();

            return voluntarios;
        }

        public List<Voluntario> getAllDisponibilidade()
        {
            List<Voluntario> voluntarios = new List<Voluntario>();

            sql.Append("SELECT v.idVoluntario, v.nomeVoluntario, t.dddTelefone, t.telefone, a.nomeAtividade, v.status " +
                "FROM volunntario v " +
                "INNER JOIN disponibilidade d ON d.idVoluntario = v.idVoluntario " +
                "INNER JOIN atividade a ON a.idAtividade = d.idAtividade " +
                "INNER JOIN telefone t ON t.idVoluntario = a.idAtividade " +
                "WHERE d.statusDisponibilidade = 0 " +
                "ORDER BY d.idDisponibilidade DESC");

            cmm.CommandText = sql.ToString();
            MySqlDataReader dr = db.executarConsulta(cmm);

            while (dr.Read())
            {
                voluntarios.Add(new Voluntario
                {
                    idVoluntario = (int)dr["idVoluntario"],
                    nomeVoluntario = (string)dr["nomeVoluntario"],
                    status = (string)dr["status"],
                    telefone = 
                    new Telefone
                    {
                        dddTelefone = (string)dr["dddTelefone"],
                        telefone = (string)dr["telefone"]
                    },
                    atividade =
                    new Atividade
                    {
                        nomeAtividade = (string)dr["nomeAtividade"],   
                    }
                });
            }

            sql.Clear();
            dr.Close();
            dr.Dispose();

            return voluntarios;
        }

        public List<Voluntario> getSete()
        {
            List<Voluntario> voluntarios = new List<Voluntario>();

            sql.Append("SELECT v.idVoluntario, v.nomeVoluntario, t.dddTelefone, t.telefone, a.nomeAtividade, v.status " +
                "FROM voluntario v " +
                "INNER JOIN disponibilidade d ON d.idVoluntario = v.idVoluntario " +
                "INNER JOIN atividade a ON a.idAtividade = d.idAtividade " +
                "INNER JOIN telefone t ON t.idVoluntario = a.idAtividade " +
                "WHERE d.statusDisponibilidade = 0 " +
                "ORDER BY d.idDisponibilidade DESC " +
                "LIMIT 7");

            cmm.CommandText = sql.ToString();
            MySqlDataReader dr = db.executarConsulta(cmm);

            while (dr.Read())
            {
                voluntarios.Add(new Voluntario
                {
                    idVoluntario = (int)dr["idVoluntario"],
                    nomeVoluntario = (string)dr["nomeVoluntario"],
                    status = (string)dr["status"],
                    telefone = new Telefone
                    {
                        dddTelefone = (string)dr["dddTelefone"],
                        telefone = (string)dr["telefone"]
                    },
                    atividade = new Atividade
                    {
                        nomeAtividade = (string)dr["nomeAtvidade"]
                    }
                });
            }

            sql.Clear();
            dr.Close();
            dr.Dispose();

            return voluntarios;
        }

        public Voluntario getOne(int pId)
        {
            sql.Append("SELECT v.idVoluntario, v.nomeVoluntario, v.cpfVoluntario, v.dataNascimento, v.sexo, v.email, " +
                "t.dddTelefone, t.telefone, t.dddCelular, t.celular, a.afinidade, c.nomeCidade, c.estado, " +
                "e.descricao, e.disponibilidade, att.nomeAtividade, aa.areaT, c.cep, e.escolaridade, e.volJa, " +
                "ac.Login, ac.Senha" +
                "FROM voluntario v " +
                "INNER JOIN telefone t ON t.idVoluntario = v.idVoluntario" +
                "INNER JOIN afinidade a ON a.idVoluntario = v.idVoluntario " +
                "INNER JOIN cidade c ON c.idVoluntario = v.idVoluntario " +
                "INNER JOIN extravoluntario e ON e.idVoluntario = v.idVoluntario " +
                "INNER JOIN areadeatuacao aa ON aa.idVoluntario = v.idVoluntario " +
                "INNER JOIN acesso ac ON ac.idVoluntario = v.idVoluntario " +
                "INNER JOIN disponibilidade vat ON vat.idVoluntario = v.idVoluntario " +
                "INNER JOIN atividade att ON att.idAtividade = vat.idAtividade " +
                "WHERE v.idVoluntario = @idVol");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@idVol", pId);
            MySqlDataReader dr = db.executarConsulta(cmm);
            dr.Read();

            Voluntario vol = new Voluntario
            {
                idVoluntario = (int)dr["idVoluntario"],
                nomeVoluntario = (string)dr["nomeVoluntario"],
                cpfVoluntario = (string)dr["cpfVoluntario"],
                dataNascimento = (string)dr["dataNascimento"],
                sexo = (string)dr["sexo"],
                email = (string)dr["email"],
                telefone = new Telefone
                {
                    dddTelefone = (string)dr["dddTelefone"],
                    telefone = (string)dr["telefone"],
                    dddCelular = (string)dr["dddCelular"],
                    celular = (string)dr["celular"]
                },
                afinidade = new Afinidade
                {
                    afinidade = (string)dr["afinidade"]
                },
                extraVoluntario = new ExtraVoluntario
                {
                    descricao = (string)dr["descricao"],
                    disponibilidade = (string)dr["disponibilidade"],
                    escolaridade = (string)dr["escolaridade"],
                    volJa = (string)dr["volJa"]
                },
                atividade = new Atividade
                {
                    nomeAtividade = (string)dr["nomeAtividade"]
                },
                cidade = new Cidade
                {
                    nomeCidade = (string)dr["nomeCidade"],
                    estado = (string)dr["estado"],
                    cep = (string)dr["cep"]
                },
                areaDeAtuacao = new AreaAtuacao
                {
                    areaT = (string)dr["areaT"]
                },
                acesso = new Acesso
                {
                    login = (string)dr["Login"],
                    senha = (string)dr["Senha"]
                }
            };

            sql.Clear();
            dr.Close();
            dr.Dispose();

            return vol;
        }

        public void TrocaStatus(int pId, string pStatus)
        {
            sql.Append("UPDATE voluntario " +
                "SET status = @statusVol " +
                "WHERE idVoluntario = @idVol");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@statusVol", pStatus);
            cmm.Parameters.AddWithValue("@idVol", pId);

            db.executarComando(cmm);
            sql.Clear();
        }

        public void Create(Voluntario pVoluntario)
        {
            sql.Append("INSERT INTO voluntario (nomeVoluntario, cpfVoluntario, dataNascimento, sexo, email) " +
                "VALUES (@nomeVoluntario, @cpfVoluntario, @dataNascimento, @sexo, @email)");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@nomeVoluntario", pVoluntario.nomeVoluntario);
            cmm.Parameters.AddWithValue("@cpfVoluntario", pVoluntario.cpfVoluntario);
            cmm.Parameters.AddWithValue("@dataNascimento", pVoluntario.dataNascimento);
            cmm.Parameters.AddWithValue("@sexo", pVoluntario.sexo);
            cmm.Parameters.AddWithValue("@email", pVoluntario.email);

            pVoluntario.idVoluntario = db.executarComandoScalar(cmm);
            sql.Clear();

            pVoluntario.telefone.voluntario = pVoluntario;
            pVoluntario.cidade.voluntario = pVoluntario;
            pVoluntario.areaDeAtuacao.voluntario = pVoluntario;
            pVoluntario.disponibilidade.voluntario = pVoluntario;
            pVoluntario.disponibilidade.atividade = pVoluntario.atividade;
            pVoluntario.extraVoluntario.voluntario = pVoluntario;
            pVoluntario.afinidade.voluntario = pVoluntario;
            pVoluntario.acesso.voluntario = pVoluntario;

            telefoneDAO.Create(pVoluntario.telefone);
            cidadeDAO.Create(pVoluntario.cidade);
            areaDAO.Create(pVoluntario.areaDeAtuacao);
            extraDAO.Create(pVoluntario.extraVoluntario);
            afinidadeDAO.Create(pVoluntario.afinidade);
            disponibilidadeDAO.Create(pVoluntario.disponibilidade);
        }

        public void Update(Voluntario pVoluntario)
        {
            sql.Append("UPDATE voluntario " +
                "SET nomeVoluntario = @nomeVoluntario, cpfVoluntario = @cpfVoluntario, " +
                "dataNascimento = @dataNascimento, sexo = @sexo, email = @email " +
                "WHERE idVoluntario = @idV");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@nomeVoluntario", pVoluntario.nomeVoluntario);
            cmm.Parameters.AddWithValue("@cpfVoluntario", pVoluntario.cpfVoluntario);
            cmm.Parameters.AddWithValue("@dataNascimento", pVoluntario.dataNascimento);
            cmm.Parameters.AddWithValue("@sexo", pVoluntario.sexo);
            cmm.Parameters.AddWithValue("@email", pVoluntario.email);

            db.executarComando(cmm);
            sql.Clear();

            pVoluntario.telefone.voluntario = pVoluntario;
            pVoluntario.cidade.voluntario = pVoluntario;
            pVoluntario.areaDeAtuacao.voluntario = pVoluntario;
            pVoluntario.disponibilidade.voluntario = pVoluntario;
            pVoluntario.disponibilidade.atividade = pVoluntario.atividade;
            pVoluntario.extraVoluntario.voluntario = pVoluntario;
            pVoluntario.afinidade.voluntario = pVoluntario;
            pVoluntario.acesso.voluntario = pVoluntario;

            telefoneDAO.Update(pVoluntario.telefone);
            cidadeDAO.Update(pVoluntario.cidade);
            areaDAO.Update(pVoluntario.areaDeAtuacao);
            extraDAO.Update(pVoluntario.extraVoluntario);
            afinidadeDAO.Update(pVoluntario.afinidade);
            disponibilidadeDAO.Update(pVoluntario.disponibilidade);
        }
    }
}
