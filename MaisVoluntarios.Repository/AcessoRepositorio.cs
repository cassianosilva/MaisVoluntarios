using ConnectionDatabase;
using MaisVoluntarios.Core;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisVoluntarios.Repository
{
    public class AcessoRepositorio
    {
        RepositorioDB db = new RepositorioDB();
        MySqlCommand cmm = new MySqlCommand();
        StringBuilder sql = new StringBuilder();

        public Acesso getPass(Acesso pAcesso)
        {
            if (pAcesso.log == 1)
            {
                sql.Append("SELECT a.idVoluntario, a.Senha, a.Login, v.nomeVoluntario " +
                    "FROM acesso a " +
                    "INNER JOIN voluntario v " +
                    "ON v.idVoluntario = a.idVoluntario " +
                    "WHERE a.Senha = @pass AND a.Login = @user");

                cmm.CommandText = sql.ToString();
                cmm.Parameters.AddWithValue("@pass", pAcesso.senha);
                cmm.Parameters.AddWithValue("@user", pAcesso.login);
                MySqlDataReader dr = db.executarConsulta(cmm);

                if (dr.HasRows)
                {
                    dr.Read();

                    Acesso acc = new Acesso
                    {
                        login = (string)dr["Login"],
                        senha = (string)dr["Senha"],
                        voluntario = new Voluntario
                        {
                            idVoluntario = (int)dr["idVoluntario"],
                            nomeVoluntario = (string)dr["nomeVoluntario"]
                        }
                    };

                    dr.Close();
                    dr.Dispose();
                    sql.Clear();

                    return acc;
                }
                else
                {
                    dr.Close();
                    dr.Dispose();
                    sql.Clear();

                    return null;
                }
            }
            else
            {
                sql.Append("SELECT a.idEmpresa, a.Senha, a.Login, e.nomeEmpresa " +
                    "FROM acesso a " +
                    "INNER JOIN empresa e " +
                    "ON e.idEmpresa = a.idEmpresa " +
                    "WHERE a.Senha = @pass AND a.Login = @user");

                cmm.CommandText = sql.ToString();
                cmm.Parameters.AddWithValue("@pass", pAcesso.senha);
                cmm.Parameters.AddWithValue("@user", pAcesso.login);
                MySqlDataReader dr = db.executarConsulta(cmm);

                if (dr.HasRows)
                {
                    dr.Read();

                    Acesso acc = new Acesso
                    {
                        login = (string)dr["Login"],
                        senha = (string)dr["Senha"],
                        empresa = new Empresa
                        {
                            idEmpresa = (int)dr["idEmpresa"],
                            nomeEmpresa = (string)dr["nomeEmpresa"]
                        }
                    };

                    dr.Close();
                    dr.Dispose();
                    sql.Clear();

                    return acc;
                }
                else
                {
                    dr.Close();
                    dr.Dispose();
                    sql.Clear();

                    return null;
                }
            }

            
        }

        public void CreateVoluntario(Acesso pAcesso)
        {
            sql.Append("INSERT INTO acesso (Senha, Login, idVoluntario) " +
                "values (@Senha, @Login, @idV)");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@Senha", pAcesso.senha);
            cmm.Parameters.AddWithValue("@Login", pAcesso.login);
            cmm.Parameters.AddWithValue("@idV", pAcesso.voluntario.idVoluntario);

            db.executarComando(cmm);
            sql.Clear();
        }
        public void CreateEmpresa(Acesso pAcesso)
        {
            sql.Append("INSERT INTO acesso (Senha, Login, idEmpresa) " +
                "values (@Senha, @Login, @idV)");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@Senha", pAcesso.senha);
            cmm.Parameters.AddWithValue("@Login", pAcesso.login);
            cmm.Parameters.AddWithValue("@idV", pAcesso.empresa.idEmpresa);

            db.executarComando(cmm);
            sql.Clear();
        }
        public void Update(Acesso pAcesso)
        {
            sql.Append("UPDATE acesso " +
                "SET Senha = @Senha,Login = @Login " +
                "WHERE idVoluntario = @idV");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@Senha", pAcesso.senha);
            cmm.Parameters.AddWithValue("@Login", pAcesso.login);
            cmm.Parameters.AddWithValue("@idV", pAcesso.voluntario.idVoluntario);

            db.executarComando(cmm);
            sql.Clear();
        }
        public void UpdateEmpresa(Acesso pAcesso)
        {
            sql.Append("UPDATE acesso " +
                "SET Senha = @Senha,Login = @Login " +
                "WHERE idVoluntario = @idV");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@Senha", pAcesso.senha);
            cmm.Parameters.AddWithValue("@Login", pAcesso.login);
            cmm.Parameters.AddWithValue("@idV", pAcesso.empresa.idEmpresa);

            db.executarComando(cmm);
            sql.Clear();
        }
    }
}
