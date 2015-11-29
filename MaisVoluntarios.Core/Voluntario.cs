namespace MaisVoluntarios.Core
{
    public class Voluntario
    {
        public int idVoluntario { get; set; }
        public string nomeVoluntario { get; set; }
        public string cpfVoluntario { get; set; }
        public string dataNascimento { get; set; }
        public string sexo { get; set; }
        public string email { get; set; }
        public Atividade atividade { get; set; }
        public Cidade cidade { get; set; }
        public Acesso acesso { get; set; }
        public Telefone telefone { get; set; }
        public Tipo tipo { get; set; }

        public Voluntario()
        {
        }

        public Voluntario(int pId, string pNome, string pCpf, string pData, string pSexo, string pEmail,
            Atividade pAtividade, Cidade pCidade, Acesso pAcesso, Telefone pTelefone, Tipo pTipo)
        {
            idVoluntario = pId;
            nomeVoluntario = pNome;
            cpfVoluntario = pCpf;
            dataNascimento = pData;
            sexo = pSexo;
            email = pEmail;
            atividade = pAtividade;
            cidade = pCidade;
            acesso = pAcesso;
            telefone = pTelefone;
            tipo = pTipo;
        }
    }
}
