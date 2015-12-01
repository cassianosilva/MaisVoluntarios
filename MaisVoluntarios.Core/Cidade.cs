namespace MaisVoluntarios.Core
{
    public class Cidade
    {
        public int idCidade { get; set; }
        public string nomeCidade { get; set; }
        public string estado { get; set; }
        public string cep { get; set; }
        public Voluntario voluntario { get; set; }
        public Empresa empresa { get; set; }
    }
}
