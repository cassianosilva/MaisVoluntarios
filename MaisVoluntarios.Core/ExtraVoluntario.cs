namespace MaisVoluntarios.Core
{
    public class ExtraVoluntario
    {
        public int idExtra { get; set; }
        public string volJa { get; set; }
        public string disponibilidade { get; set; }
        public string descricao { get; set; }
        public Voluntario voluntario { get; set; }
        public string escolaridade { get; set; }
    }
}
