namespace MaisVoluntarios.Core
{
    public class Acesso
    {
        public int idAcesso { get; set; }
        public string senha { get; set; }
        public string login { get; set; }
        public int log { get; set; }
        public Voluntario voluntario { get; set; }
        public Empresa empresa { get; set; }
    }
}
