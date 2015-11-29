namespace MaisVoluntarios.Core
{
    public class ExtraEmpresa
    {
        public int idExtra { get; set; }
        public string descricao { get; set; }
        public Empresa empresa { get; set; }

        public ExtraEmpresa(int pId, string pDesc, Empresa pEmpresa)
        {
            idExtra = pId;
            descricao = pDesc;
            empresa = pEmpresa;
        }
    }
}
