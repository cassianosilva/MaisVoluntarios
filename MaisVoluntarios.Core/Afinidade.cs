namespace MaisVoluntarios.Core
{
    public class Afinidade
    {
        public int idAfinidade { get; set; }
        public string afinidade { get; set; }
        public Voluntario voluntario { get; set; }

        public Afinidade(int pId, string pAfinidade, Voluntario pVoluntario)
        {
            idAfinidade = pId;
            afinidade = pAfinidade;
            voluntario = pVoluntario;
        }
    }
}
