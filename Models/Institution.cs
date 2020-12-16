using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instituicoes.Models
{
    public class Institution
    {
        public long? InstitutionID { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
    }
}
