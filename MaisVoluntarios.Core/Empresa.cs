namespace MaisVoluntarios.Core
{
    public class Empresa
    {
        public int idEmpresa { get; set; }
        public string nomeEmpresa { get; set; }
        public string cnpjEmpresa { get; set; }
        public string email { get; set; }
        public string dataFundada { get; set; }
        public string descricao { get; set; }
        public Atividade atividade { get; set; }
        public Cidade cidade { get; set; }
        public Acesso acesso { get; set; }
        public Telefone telefone { get; set; }
        public Tipo tipo { get; set; }

        public Empresa()
        {
        }

        public Empresa(int pId, string pNome, string pCnpj, string pEmail, string pData, string pDesc,
            Cidade pCidade, Acesso pAcesso, Telefone pTel, Tipo pTipo)
        {
            idEmpresa = pId;
            nomeEmpresa = pNome;
            cnpjEmpresa = pCnpj;
            dataFundada = pData;
            descricao = pDesc;
            cidade = pCidade;
            acesso = pAcesso;
            telefone = pTel;
            tipo = pTipo;
        }
    }
}
