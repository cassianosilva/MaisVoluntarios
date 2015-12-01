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
        public string status { get; set; }
        public Atividade atividade { get; set; }
        public Afinidade afinidade { get; set; }
        public ExtraVoluntario extraVoluntario { get; set; }
        public AreaAtuacao areaDeAtuacao { get; set; }
        public Cidade cidade { get; set; }
        public Acesso acesso { get; set; }
        public Telefone telefone { get; set; }
        public Disponibilidade disponibilidade { get; set; }

        public Voluntario()
        {
        }
    }
}
