namespace MaisVoluntarios.Core
{
    public class Afinidade
    {
        public int idAfinidade { get; set; }
        public string afinidade { get; set; }
        public Voluntario voluntario { get; set; }
    }
}
