using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPERACION_DAUB.DOMAIN
{
    public class InfoCliente
    {
        public int IdInfoCliente { get; set; }
        public string Domicilio { get; set; }
        public string Direccion1 { get; set; }
        public string Ciudad { get; set; }
        public int Superficie { get; set; }
        public string NumeroDireccion { get; set; }
        public decimal Importe { get; set; }
        public string Literal { get; set; }
        public string Cuenta { get; set; }
        public int NumeroMeses { get; set; }
        public DateTime FechaInicialArrendamiento { get; set; }
        public DateTime FechaFinalArrendamiento { get; set; }
        public DateTime FechaTenos { get; set; }
        public string Mes { get; set; }
        public string Anio { get; set; }
    }
}
