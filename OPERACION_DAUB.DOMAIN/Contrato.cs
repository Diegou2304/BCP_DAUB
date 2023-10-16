using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace OPERACION_DAUB.DOMAIN
{
    public class Contrato
    {
        public int IdContrato { get; set; }
        public string Codigo_Contrato { get; set; }
        public int IdRepresentante { get; set; }
        public int IdProveedor { get; set; }
        public int IdInfoCliente { get; set; }
    }

    
}
