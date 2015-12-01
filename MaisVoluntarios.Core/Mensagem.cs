namespace MaisVoluntarios.Core
{
    public class Mensagem
    {
        public int idMensagem { get; set; }
        public string mensagem { get; set; }
        public int status { get; set; }
        public Empresa empresa { get; set; }
        public Voluntario voluntario { get; set; }

        public Mensagem()
        {
        }

        public Mensagem(int pId, string pMsg, int pStatus, Voluntario pVol, Empresa pEmp)
        {
            idMensagem = pId;
            mensagem = pMsg;
            status = pStatus;
            empresa = pEmp;
            voluntario = pVol;
        }
    }
}
