namespace MaisVoluntarios.Core
{
    public class AreaAtuacao
    {
        public int idAreaAtuacao { get; set; }
        public string areaT { get; set; }
        public Voluntario voluntario { get; set; }

        public AreaAtuacao(int pId, string pArea, Voluntario pVoluntario)
        {
            idAreaAtuacao = pId;
            areaT = pArea;
            voluntario = pVoluntario;
        }
    }
}
