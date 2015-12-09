using ConnectionDatabase;
using MaisVoluntarios.Core;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Text;

namespace MaisVoluntarios.Repository
{
    public class MensagemRepositorio
    {
        RepositorioDB db = new RepositorioDB();
        MySqlCommand cmm = new MySqlCommand();
        StringBuilder sql = new StringBuilder();

        public List<Mensagem> getAllVoluntario(int pId)
        {
            List<Mensagem> mensagens = new List<Mensagem>();

            sql.Append("SELECT m.idMensagem, m.mensagem, m.status, m.idEmpresa, m.idVoluntario, e.nomeEmpresa " +
                "FROM mensagem m " +
                "INNER JOIN voluntario v ON v.idVoluntario = m.idVoluntario " +
                "INNER JOIN empresa e ON e.idEmpresa = m.idEmpresa " +
                "WHERE v.idVoluntario = @idV " +
                "ORDER BY m.idMensagem DESC");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@idV", pId);
            MySqlDataReader dr = db.executarConsulta(cmm);

            while (dr.Read())
            {
                mensagens.Add(new Mensagem
                {
                    idMensagem = (int)dr["idMensagem"],
                    mensagem = (string)dr["mensagem"],
                    status = (int)dr["status"],
                    empresa = new Empresa
                    {
                        idEmpresa = (int)dr["idEmpresa"],
                        nomeEmpresa = (string)dr["nomeEmpresa"]
                    },
                    voluntario = new Voluntario
                    {
                        idVoluntario = (int)dr["idVoluntario"]
                    }
                });
            }

            dr.Close();
            dr.Dispose();
            sql.Clear();

            return mensagens;
        }
        public List<Mensagem> getAllVoluntarioPreview(int pId)
        {
            List<Mensagem> mensagens = new List<Mensagem>();

            sql.Append("SELECT m.idMensagem, m.mensagem, m.status, m.idEmpresa, m.idVoluntario, e.nomeEmpresa " +
                "FROM mensagem m " +
                "INNER JOIN voluntario v ON v.idVoluntario = m.idVoluntario " +
                "INNER JOIN empresa e ON e.idEmpresa = m.idEmpresa " +
                "WHERE v.idVoluntario = @idV and m.status='0' " +
                "ORDER BY m.idMensagem DESC");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@idV", pId);
            MySqlDataReader dr = db.executarConsulta(cmm);

            while (dr.Read())
            {
                mensagens.Add(new Mensagem
                {
                    idMensagem = (int)dr["idMensagem"],
                    mensagem = (string)dr["mensagem"],
                    status = (int)dr["status"],
                    empresa = new Empresa
                    {
                        idEmpresa = (int)dr["idEmpresa"],
                        nomeEmpresa = (string)dr["nomeEmpresa"]
                    },
                    voluntario = new Voluntario
                    {
                        idVoluntario = (int)dr["idVoluntario"]
                    }
                });
            }

            dr.Close();
            dr.Dispose();
            sql.Clear();

            return mensagens;
        }

        public List<Mensagem> getAllEmpresa(int pId)
        {
            List<Mensagem> mensagens = new List<Mensagem>();

            sql.Append("SELECT m.idMensagem, m.mensagem, m.status, m.idEmpresa, m.idVoluntario, v.nomeVoluntario " +
                "FROM mensagemempresa m " +
                "INNER JOIN voluntario v ON v.idVoluntario = m.idVoluntario " +
                "INNER JOIN empresa e ON e.idEmpresa = m.idEmpresa " +
                "WHERE e.idEmpresa = @idV " +
                "ORDER BY m.idMensagem DESC");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@idV", pId);
            MySqlDataReader dr = db.executarConsulta(cmm);

            while (dr.Read())
            {
                mensagens.Add(new Mensagem
                {
                    idMensagem = (int)dr["idMensagem"],
                    mensagem = (string)dr["mensagem"],
                    status = (int)dr["status"],
                    empresa = new Empresa
                    {
                        idEmpresa = (int)dr["idEmpresa"]
                    },
                    voluntario = new Voluntario
                    {
                        idVoluntario = (int)dr["idVoluntario"],
                        nomeVoluntario = (string)dr["nomeVoluntario"]
                    }
                });
            }

            dr.Close();
            dr.Dispose();
            sql.Clear();

            return mensagens;
        }

        public List<Mensagem> getAllVoluntarioSaida(int pId)
        {
            List<Mensagem> mensagens = new List<Mensagem>();

            sql.Append("SELECT m.idMensagem, m.mensagem, m.status, m.idEmpresa, m.idVoluntario, v.nomeVoluntario, e.nomeEmpresa " +
                "FROM mensagemempresa m " +
                "INNER JOIN voluntario v ON v.idVoluntario = m.idVoluntario " +
                "INNER JOIN empresa e ON e.idEmpresa = m.idEmpresa " +
                "WHERE v.idVoluntario = @idV " +
                "ORDER BY m.idMensagem DESC");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@idV", pId);
            MySqlDataReader dr = db.executarConsulta(cmm);

            while (dr.Read())
            {
                mensagens.Add(new Mensagem
                {
                    idMensagem = (int)dr["idMensagem"],
                    mensagem = (string)dr["mensagem"],
                    status = (int)dr["status"],
                    empresa = new Empresa
                    {
                        idEmpresa = (int)dr["idEmpresa"],
                        nomeEmpresa = (string)dr["nomeEmpresa"]
                    },
                    voluntario = new Voluntario
                    {
                        idVoluntario = (int)dr["idVoluntario"],
                        nomeVoluntario = (string)dr["nomeVoluntario"]
                    }
                });
            }

            dr.Close();
            dr.Dispose();
            sql.Clear();

            return mensagens;
        }

        public List<Mensagem> getAllEmpresaSaida(int pId)
        {
            List<Mensagem> mensagens = new List<Mensagem>();

            sql.Append("SELECT m.idMensagem, m.mensagem, m.status, m.idEmpresa, m.idVoluntario, v.nomeVoluntario " +
                "FROM mensagem m " +
                "INNER JOIN voluntario v ON v.idVoluntario = m.idVoluntario " +
                "INNER JOIN empresa e ON e.idEmpresa = m.idEmpresa " +
                "WHERE e.idEmpresa = @idV " +
                "ORDER BY m.idMensagem DESC");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@idV", pId);
            MySqlDataReader dr = db.executarConsulta(cmm);

            while (dr.Read())
            {
                mensagens.Add(new Mensagem
                {
                    idMensagem = (int)dr["idMensagem"],
                    mensagem = (string)dr["mensagem"],
                    status = (int)dr["status"],
                    empresa = new Empresa
                    {
                        idEmpresa = (int)dr["idEmpresa"]
                    },
                    voluntario = new Voluntario
                    {
                        idVoluntario = (int)dr["idVoluntario"],
                        nomeVoluntario = (string)dr["nomeVoluntario"]
                    }
                });
            }

            dr.Close();
            dr.Dispose();
            sql.Clear();

            return mensagens;
        }

        public List<Mensagem> getSeteVoluntario(int pId)
        {
            List<Mensagem> mensagens = new List<Mensagem>();

            sql.Append("select m.idMensagem, m.mensagem, m.status, m.idEmpresa, m.idVoluntario, e.nomeEmpresa " +
                "FROM mensagem m " +
                "INNER JOIN voluntario v ON v.idVoluntario = m.idVoluntario " +
                "INNER JOIN empresa e ON e.idEmpresa = m.idEmpresa " +
                "WHERE v.idVoluntario = @idV AND m.status = 0 " +
                "ORDER BY m.idMensagem DESC " +
                "LIMIT 7");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@idV", pId);
            MySqlDataReader dr = db.executarConsulta(cmm);

            while (dr.Read())
            {
                mensagens.Add(new Mensagem
                {
                    idMensagem = (int)dr["idMensagem"],
                    mensagem = (string)dr["mensagem"],
                    status = (int)dr["status"],
                    empresa = new Empresa
                    {
                        idEmpresa = (int)dr["idEmpresa"],
                        nomeEmpresa = (string)dr["nomeEmpresa"]
                    },
                    voluntario = new Voluntario
                    {
                        idVoluntario = (int)dr["idVoluntario"]
                    }
                });
            }

            dr.Close();
            dr.Dispose();
            sql.Clear();

            return mensagens;
        }

        public List<Mensagem> getSeteEmpresa(int pId)
        {
            List<Mensagem> mensagens = new List<Mensagem>();

            sql.Append("select m.idMensagem, m.mensagem, m.status, m.idEmpresa, m.idVoluntario, e.nomeVoluntario " +
                "FROM mensagem m " +
                "INNER JOIN voluntario v ON v.idVoluntario = m.idVoluntario " +
                "INNER JOIN empresa e ON e.idEmpresa = m.idEmpresa " +
                "WHERE v.idVoluntario = @idV AND m.status = 0 " +
                "ORDER BY m.idMensagem DESC " +
                "LIMIT 7");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@idV", pId);
            MySqlDataReader dr = db.executarConsulta(cmm);

            while (dr.Read())
            {
                mensagens.Add(new Mensagem
                {
                    idMensagem = (int)dr["idMensagem"],
                    mensagem = (string)dr["mensagem"],
                    status = (int)dr["status"],
                    empresa = new Empresa
                    {
                        idEmpresa = (int)dr["idEmpresa"]
                    },
                    voluntario = new Voluntario
                    {
                        idVoluntario = (int)dr["idVoluntario"],
                        nomeVoluntario = (string)dr["nomeVoluntario"]
                    }
                });
            }

            dr.Close();
            dr.Dispose();
            sql.Clear();

            return mensagens;
        }

        public Mensagem getOne(int pId)
        {
            sql.Append("SELECT m.idMensagem, m.mensagem, m.status, m.idEmpresa, m.idVoluntario, " +
                "e.nomeEmpresa, v.nomeVoluntario " +
                "FROM mensagem m " +
                "INNER JOIN voluntario v ON v.idVoluntario = m.idVoluntario " +
                "INNER JOIN empresa e ON e.idEmpresa = m.idEmpresa " +
                "WHERE m.idMensagem = @idM");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@idM", pId);
            MySqlDataReader dr = db.executarConsulta(cmm);
            dr.Read();
            Mensagem msg = new Mensagem
            {
                idMensagem = (int)dr["idMensagem"],
                mensagem = (string)dr["mensagem"],
                status = (int)dr["status"],
                empresa = new Empresa
                {
                    idEmpresa = (int)dr["idEmpresa"],
                    nomeEmpresa = (string)dr["nomeEmpresa"]
                },
                voluntario = new Voluntario
                {
                    idVoluntario = (int)dr["idVoluntario"],
                    nomeVoluntario = (string)dr["nomeVoluntario"]
                }
            };

            dr.Close();
            dr.Dispose();
            sql.Clear();

            return msg;
        }

        public Mensagem getOneSaida(int pId)
        {
            sql.Append("SELECT m.idMensagem, m.mensagem, m.status, m.idEmpresa, m.idVoluntario, " +
                "e.nomeEmpresa, v.nomeVoluntario " +
                "FROM mensagemempresa m " +
                "INNER JOIN voluntario v ON v.idVoluntario = m.idVoluntario " +
                "INNER JOIN empresa e ON e.idEmpresa = m.idEmpresa " +
                "WHERE m.idMensagem = @idM");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@idM", pId);
            MySqlDataReader dr = db.executarConsulta(cmm);
            dr.Read();
            Mensagem msg = new Mensagem
            {
                idMensagem = (int)dr["idMensagem"],
                mensagem = (string)dr["mensagem"],
                status = (int)dr["status"],
                empresa = new Empresa
                {
                    idEmpresa = (int)dr["idEmpresa"],
                    nomeEmpresa = (string)dr["nomeEmpresa"]
                },
                voluntario = new Voluntario
                {
                    idVoluntario = (int)dr["idVoluntario"],
                    nomeVoluntario = (string)dr["nomeVoluntario"]
                }
            };

            dr.Close();
            dr.Dispose();
            sql.Clear();

            return msg;
        }

        public void TrocaStatusMensagem(int pId)
        {
            sql.Append("UPDATE mensagem " +
                "SET status = 1 " +
                "WHERE idMensagem = @idM");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@idM", pId);

            db.executarComando(cmm);
            sql.Clear();
        }

        public void TrocaStatusMensagemEmp(int pId)
        {
            sql.Append("UPDATE mensagemempresa " +
                "SET status = 1 " +
                "WHERE idMensagem = @idMen");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@idMen", pId);

            db.executarComando(cmm);
            sql.Clear();
        }

        public void CreateMsg(Mensagem pMsg)
        {
            sql.Append("INSERT INTO mensagemempresa (mensagem, idVoluntario, idEmpresa) " +
                "VALUES (@msg, @idVol, @idEmp)");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@msg", pMsg.mensagem);
            cmm.Parameters.AddWithValue("@idVol", pMsg.voluntario.idVoluntario);
            cmm.Parameters.AddWithValue("@idEmp", pMsg.empresa.idEmpresa);

            db.executarComando(cmm);
            sql.Clear();
        }

        public void CreateMsgSaida(Mensagem pMsg)
        {
            sql.Append("INSERT INTO mensagem (mensagem, idVoluntario, idEmpresa) " +
                "VALUES (@msg, @idVol, @idEmp)");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@msg", pMsg.mensagem);
            cmm.Parameters.AddWithValue("@idVol", pMsg.voluntario.idVoluntario);
            cmm.Parameters.AddWithValue("@idEmp", pMsg.empresa.idEmpresa);

            db.executarComando(cmm);
            sql.Clear();
        }

        public void DeleteMensagemEntrada(int pId)
        {
            sql.Append("DELETE FROM mensagem " +
                "WHERE idMensagem = @id");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@id", pId);

            db.executarComando(cmm);
            sql.Clear();
        }

        public void DeleteMensagemSaida(int pId)
        {
            sql.Append("DELETE FROM mensagemempresa " +
                "WHERE idMensagem = @id");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@id", pId);

            db.executarComando(cmm);
            sql.Clear();
        }
    }
}
