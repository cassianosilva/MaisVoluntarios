namespace MaisVoluntarios.Core
{
    public class Cidade
    {
        public int idCidade { get; set; }
        public string nomeCidade { get; set; }
        public string estado { get; set; }
        public string cep { get; set; }

        public Cidade(int pId, string pNome, string pEstado, string pCep)
        {
            idCidade = pId;
            nomeCidade = pNome;
            estado = pEstado;
            cep = pCep;
        }
    }
}
