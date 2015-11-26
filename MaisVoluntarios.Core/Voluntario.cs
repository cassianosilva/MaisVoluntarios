using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Atividade atividade { get; set; }
        public Cidade cidade { get; set; }
        public Acesso acesso { get; set; }
        public Telefone telefone { get; set; }
        public Tipo tipo { get; set; }
    }
}
