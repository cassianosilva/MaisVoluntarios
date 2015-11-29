namespace MaisVoluntarios.Core
{
    public class Telefone
    {
        public int idTelefone { get; set; }
        public int dddTelefone { get; set; }
        public string telefone { get; set; }
        public int dddCelular { get; set; }
        public string celular { get; set; }

        public Telefone(int pId, int pDddTel, string pTel, int pDddCel, string pCel)
        {
            idTelefone = pId;
            dddTelefone = pDddTel;
            telefone = pTel;
            dddCelular = pDddCel;
            celular = pCel;
        }
    }
}
