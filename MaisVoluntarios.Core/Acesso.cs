namespace MaisVoluntarios.Core
{
    public class Acesso
    {
        public int idAcesso { get; set; }
        public string senha { get; set; }
        public string login { get; set; }

        public Acesso(int pId, string pSenha, string pLogin)
        {
            idAcesso = pId;
            senha = pSenha;
            login = pLogin;
        }
    }
}
