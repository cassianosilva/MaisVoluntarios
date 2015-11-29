namespace MaisVoluntarios.Core
{
    public class Atividade
    {
        public int idAtividade { get; set; }
        public string nomeAtividade { get; set; }

        public Atividade(int pId, string pNome)
        {
            idAtividade = pId;
            nomeAtividade = pNome;
        }
    }
}
