namespace MaisVoluntarios.Core
{
    public class Tipo
    {
        public int idAtividade { get; set; }
        public string nomeAtividade { get; set; }

        public Tipo(int pId, string pNome)
        {
            idAtividade = pId;
            nomeAtividade = pNome;
        }
    }
}
