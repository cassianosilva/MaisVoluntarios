namespace MaisVoluntarios.Core
{
    public class Necessidade
    {
        public int idNecessidade { get; set; }
        public Atividade atividade { get; set; }
        public Empresa empresa { get; set; }
        public int statusNecessidade { get; set; }

        public Necessidade(int pId, Atividade pAtividade, Empresa pEmpresa, int pStatus)
        {
            idNecessidade = pId;
            atividade = pAtividade;
            empresa = pEmpresa;
            statusNecessidade = pStatus;
        }
    }
}
