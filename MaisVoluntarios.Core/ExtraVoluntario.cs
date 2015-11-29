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

        public ExtraVoluntario(int pId, string pVolJa, string pDisp, string pDesc, Voluntario pVol, string pEsc)
        {
            idExtra = pId;
            volJa = pVolJa;
            disponibilidade = pDisp;
            descricao = pDesc;
            voluntario = pVol;
            escolaridade = pEsc;
        }
    }
}
