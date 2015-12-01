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
        public string ddd { get; set; }
        public string telefone { get; set; }
        public Atividade atividade { get; set; }
        public Necessidade necessidade { get; set; }
        public ExtraEmpresa extraEmpresa { get; set; }
        public Cidade cidade { get; set; }
        public Acesso acesso { get; set; }

        public Empresa()
        {
        }
    }
}
