

using MediatR;
using System.Net;

namespace OPERACION_DAUB.APPLICATION.Contract.CreateContract
{
    public class CreateContractCommand  : IRequest<int>
    {
        public RepresentanteLegalDto RepresentanteLegal { get; set; }
        public ProveedoresDto Proveedores { get; set; }
        public INFO_CLIENTEDto INFO_CLIENTEDto { get; set; }
        public ContratoDto ContratoDto { get; set; }
    }

    public class RepresentanteLegalDto
    {
        public int IdRepresentante { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Nombres { get; set; }
    }

    public class ProveedoresDto
    {
        public int IdProveedor { get; set; }
        public string Paterno_Proveedor { get; set; }
        public string Materno_Proovedor { get; set; }
        public string Nombres_Proovedor { get; set; }
        public string DocumentoProveedor { get; set; }
    }

    public class INFO_CLIENTEDto
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

    public class ContratoDto
    {
        public int IdContrato { get; set; }
        public string Codigo_Contrato { get; set; }
        public int IdRepresentante { get; set; }
        public int IdProveedor { get; set; }
        public int IdInfoCliente { get; set; }
    }
}
