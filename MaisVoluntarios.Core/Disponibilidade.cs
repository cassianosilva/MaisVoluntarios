namespace MaisVoluntarios.Core
{
    public class Disponibilidade
    {
        public int idDisponibilidade { get; set; }
        public Voluntario voluntario { get; set; }
        public Atividade atividade { get; set; }
        public int statusDisponibilidade { get; set; }
    }
}
