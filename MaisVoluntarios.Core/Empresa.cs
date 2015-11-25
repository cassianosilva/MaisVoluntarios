using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisVoluntarios.Core
{
    public class Empresa
    {
        public int idEmpresa { get; set; }
        public string nomeEmpresa { get; set; }
        public string cnpjEmpresa { get; set; }
        public string email { get; set; }
        public string dataFundada { get; set; }
        public string descricao { get; set; }
        public Atividade atividade { get; set; }
        public Cidade cidade { get; set; }
        public Acesso acesso { get; set; }
        public Telefone telefone { get; set; }
        public Tipo tipo { get; set; }

    }
}
