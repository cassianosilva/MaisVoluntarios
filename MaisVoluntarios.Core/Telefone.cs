namespace MaisVoluntarios.Core
{
    public class Telefone
    {
        public int idTelefone { get; set; }
        public string dddTelefone { get; set; }
        public string telefone { get; set; }
        public string dddCelular { get; set; }
        public string celular { get; set; }
        public Voluntario voluntario { get; set; }
    }
}
