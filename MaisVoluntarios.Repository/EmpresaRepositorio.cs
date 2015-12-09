using ConnectionDatabase;
using MaisVoluntarios.Core;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Text;

namespace MaisVoluntarios.Repository
{
    public class EmpresaRepositorio
    {
        RepositorioDB db = new RepositorioDB();
        MySqlCommand cmm = new MySqlCommand();
        StringBuilder sql = new StringBuilder();
        ExtraEmpresaRepositorio extraDAO = new ExtraEmpresaRepositorio();
        NecessidadeRepositorio necessidadeDAO = new NecessidadeRepositorio();
        AcessoRepositorio acessoDAO = new AcessoRepositorio();
        CidadeRepositorio cidadeDAO = new CidadeRepositorio();

        public List<Empresa> getAll()
        {
            List<Empresa> empresas = new List<Empresa>();

            sql.Append("SELECT e.idEmpresa, e.nomeEmpresa, e.cnpjEmpresa, e.dataFundada, e.ddd, e.telefone, " +
                "a.nomeAtividade, ex.descricao " +
                "FROM empresa e " +
                "INNER JOIN necessidade n ON n.idEmpresa = e.idEmpresa " +
                "INNER JOIN atividade a ON a.idAtividade = n.idAtividade " +
                "INNER JOIN extraempresa ex ON ex.idEmpresa = e.idEmpresa " +
                "ORDER BY e.nomeEmpresa");

            cmm.CommandText = sql.ToString();
            MySqlDataReader dr = db.executarConsulta(cmm);

            while (dr.Read())
            {
                empresas.Add(new Empresa
                {
                    idEmpresa = (int)dr["idEmpresa"],
                    nomeEmpresa = (string)dr["nomeEmpresa"],
                    cnpjEmpresa = (string)dr["cnpjEmpresa"],
                    dataFundada = (string)dr["dataFundada"],
                    ddd = (string)dr["ddd"],
                    telefone = (string)dr["telefone"],
                    atividade = new Atividade
                    {
                        nomeAtividade = (string)dr["nomeAtividade"]
                    },
                    extraEmpresa = new ExtraEmpresa
                    {
                        descricao = (string)dr["descricao"]
                    }
                });
            }

            dr.Close();
            dr.Dispose();
            sql.Clear();

            return empresas;
        }

        public List<Empresa> getAllNecessidades()
        {
            List<Empresa> empresas = new List<Empresa>();

            sql.Append("SELECT e.idEmpresa, e.nomeEmpresa, e.ddd, e.telefone, a.nomeAtividade " +
                "FROM empresa e " +
                "INNER JOIN necessidade n ON n.idEmpresa = e.idEmpresa " +
                "INNER JOIN atividade a ON a.idAtividade = n.idAtividade " +
                "WHERE n.statusNecessidade = 0 " +
                "ORDER BY n.idNecessidade DESC");

            cmm.CommandText = sql.ToString();
            MySqlDataReader dr = db.executarConsulta(cmm);

            while (dr.Read())
            {
                empresas.Add(new Empresa
                {
                    idEmpresa = (int)dr["idEmpresa"],
                    nomeEmpresa = (string)dr["nomeEmpresa"],
                    ddd = (string)dr["ddd"],
                    telefone = (string)dr["telefone"],
                    atividade = new Atividade
                    {
                        nomeAtividade = (string)dr["nomeAtividade"]
                    }
                });
            }

            dr.Close();
            dr.Dispose();
            sql.Clear();

            return empresas;
        }

        public List<Empresa> getSete()
        {
            List<Empresa> empresas = new List<Empresa>();

            sql.Append("SELECT e.idEmpresa, e.nomeEmpresa, e.ddd, e.telefone, a.nomeAtividade " +
                "FROM empresa e " +
                "INNER JOIN necessidade n ON n.idEmpresa = e.idEmpresa " +
                "INNER JOIN atividade a ON a.idAtividade = n.idAtividade " +
                "WHERE n.statusNecessidade = 0 " +
                "ORDER BY n.idNecessidade DESC " +
                "LIMIT 7");

            cmm.CommandText = sql.ToString();
            MySqlDataReader dr = db.executarConsulta(cmm);

            while (dr.Read())
            {
                empresas.Add(new Empresa
                {
                    idEmpresa = (int)dr["idEmpresa"],
                    nomeEmpresa = (string)dr["nomeEmpresa"],
                    ddd = (string)dr["ddd"],
                    telefone = (string)dr["telefone"],
                    atividade = new Atividade
                    {
                        nomeAtividade = (string)dr["nomeAtividade"]
                    }
                });
            }

            dr.Close();
            dr.Dispose();
            sql.Clear();

            return empresas;
        }

        public Empresa getOne(int pId)
        {
            sql.Append("SELECT e.idEmpresa, e.nomeEmpresa, e.cnpjEmpresa, e.email, e.dataFundada, e.ddd, e.telefone " +
                "FROM empresa e " +
                "INNER JOIN cidade c ON c.idEmpresa = e.idEmpresa " +
                "INNER JOIN acesso a ON a.idEmpresa = e.idEmpresa " +
                "WHERE e.idEmpresa = @idE");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@idE", pId);
            MySqlDataReader dr = db.executarConsulta(cmm);
            dr.Read();
            Empresa emp = new Empresa
            {
                idEmpresa = (int)dr["idEmpresa"],
                nomeEmpresa = (string)dr["nomeEmpresa"],
                cnpjEmpresa = (string)dr["cnpjEmpresa"],
                email = (string)dr["email"],
                dataFundada = (string)dr["dataFundada"],
                ddd = (string)dr["ddd"],
                telefone = (string)dr["telefone"]
            };

            dr.Close();
            dr.Dispose();
            sql.Clear();

            return emp;
        }

        public Empresa getOneView(int pId)
        {
            sql.Append("SELECT e.idEmpresa, e.nomeEmpresa, e.cnpjEmpresa, e.email, e.ddd, e.telefone, " +
                "c.cep, c.nomeCidade, c.estado, e.dataFundada, ex.descricao, a.Login, a.Senha " +
                "FROM empresa e " +
                "INNER JOIN cidade c ON c.idEmpresa = e.idEmpresa " +
                "INNER JOIN acesso a ON a.idEmpresa = e.idEmpresa " +
                "INNER JOIN extraempresa ex ON ex.idEmpresa = e.idEmpresa " +
                "WHERE e.idEmpresa = @id");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@id", pId);
            MySqlDataReader dr = db.executarConsulta(cmm);
            dr.Read();
            Empresa emp = new Empresa
            {
                idEmpresa = (int)dr["idEmpresa"],
                nomeEmpresa = (string)dr["nomeEmpresa"],
                cnpjEmpresa = (string)dr["cnpjEmpresa"],
                dataFundada = (string)dr["dataFundada"],
                email = (string)dr["email"],
                ddd = (string)dr["ddd"],
                telefone = (string)dr["telefone"],
                cidade = new Cidade
                {
                    nomeCidade = (string)dr["nomeCidade"],
                    estado = (string)dr["estado"],
                    cep = (string)dr["cep"],

                },
                extraEmpresa = new ExtraEmpresa
                {
                    descricao = (string)dr["descricao"]
                },
                acesso = new Acesso
                {
                    login = (string)dr["Login"],
                    senha = (string)dr["Senha"]
                }
            };

            dr.Close();
            dr.Dispose();
            sql.Clear();

            return emp;
        }

        public void Create(Empresa pEmpresa)
        {
            sql.Append("INSERT INTO empresa (nomeEmpresa, cnpjEmpresa, email, dataFundada, ddd, telefone) " +
                "VALUES (@nomeEmpresa, @cnpjEmpresa, @email, @dataFundada, @ddd, @telefone)");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@nomeEmpresa", pEmpresa.nomeEmpresa);
            cmm.Parameters.AddWithValue("@cnpjEmpresa", pEmpresa.cnpjEmpresa);
            cmm.Parameters.AddWithValue("@email", pEmpresa.email);
            cmm.Parameters.AddWithValue("@dataFundada", pEmpresa.dataFundada);
            cmm.Parameters.AddWithValue("@ddd", pEmpresa.ddd);
            cmm.Parameters.AddWithValue("@telefone", pEmpresa.telefone);

            db.executarComando(cmm);
            sql.Clear();

            sql.Append("SELECT idEmpresa, nomeEmpresa, cnpjEmpresa from empresa " +
                "Where cnpjEmpresa = @cnpjE and nomeEmpresa = @nomeE");


            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@nomeE", pEmpresa.nomeEmpresa);
            cmm.Parameters.AddWithValue("@cnpjE", pEmpresa.cnpjEmpresa);

            MySqlDataReader dr = db.executarConsulta(cmm);
            dr.Read();
            pEmpresa.idEmpresa = (int)dr["idEmpresa"];

            sql.Clear();

            pEmpresa.cidade.empresa = pEmpresa;
            pEmpresa.necessidade.empresa = pEmpresa;
            pEmpresa.acesso.empresa = pEmpresa;
            pEmpresa.extraEmpresa.empresa = pEmpresa;

            cidadeDAO.CreateEmpresa(pEmpresa.cidade);
            necessidadeDAO.Create(pEmpresa.necessidade);
            acessoDAO.CreateEmpresa(pEmpresa.acesso);
            extraDAO.Create(pEmpresa.extraEmpresa);
        }

        public void Update(Empresa pEmpresa)
        {
            sql.Append("UPDATE empresa " +
                "SET nomeEmpresa = @nomeEmpresa, cnpjEmpresa = @cnpjEmpresa, email = @email, " +
                "dataFundada = @dataFundada, ddd = @ddd, telefone = @telefone " +
                "WHERE idEmpresa = @idEmp");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@nomeEmpresa", pEmpresa.nomeEmpresa);
            cmm.Parameters.AddWithValue("@cnpjEmpresa", pEmpresa.cnpjEmpresa);
            cmm.Parameters.AddWithValue("@email", pEmpresa.email);
            cmm.Parameters.AddWithValue("@dataFundada", pEmpresa.dataFundada);
            cmm.Parameters.AddWithValue("@ddd", pEmpresa.ddd);
            cmm.Parameters.AddWithValue("@telefone", pEmpresa.telefone);
            cmm.Parameters.AddWithValue("@idEmp", pEmpresa.idEmpresa);

            db.executarComando(cmm);
            sql.Clear();

            pEmpresa.cidade.empresa = pEmpresa;
            pEmpresa.necessidade.empresa = pEmpresa;
            pEmpresa.acesso.empresa = pEmpresa;
            pEmpresa.extraEmpresa.empresa = pEmpresa;

            cidadeDAO.UpdateEmpresa(pEmpresa.cidade);
            necessidadeDAO.Update(pEmpresa.necessidade);
            acessoDAO.UpdateEmpresa(pEmpresa.acesso);
            extraDAO.Update(pEmpresa.extraEmpresa);
        }
    }
}
