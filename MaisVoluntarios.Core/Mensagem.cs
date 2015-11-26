using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisVoluntarios.Core
{
    public class Mensagem
    {
        public int idMensagem { get; set; }
        public string mensagem { get; set; }
        public int status { get; set; }
        public int idEmpresa { get; set; }
        public int idVoluntario { get; set; }
        public string nomeEmpresa { get; set; }
        public string nomeVoluntario { get; set; }
    }
}
