using MediatR;
using Microsoft.Extensions.Options;
using OPERACION_DAUB.DOMAIN;
using OPERACION_DAUB.INFRASTRUCTURE;
using OPERACION_DAUB.INFRASTRUCTURE.Repositories;
using OPERACION_DAUB.INFRASTRUCTURE.Repositories.Contracts;


namespace OPERACION_DAUB.APPLICATION.Contract.CreateContract
{
    public class CreateContractHandler : IRequestHandler<CreateContractCommand, int>
    {
        private readonly IRepresentanteRepository _representanteRepository;
        private readonly IProveedorRepository _proveedorRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IContratoRepository _contratoRepository;
       
        public CreateContractHandler(IRepresentanteRepository representanteRepository, 
                                   IProveedorRepository proveedorRepository, 
                                   IClienteRepository clienteRepository,
                                   IContratoRepository contratoRepository,
                                   IOptions<ConnectionStringConfig> config)
        {
            _representanteRepository = representanteRepository;
            _proveedorRepository = proveedorRepository;
            _clienteRepository = clienteRepository;
            _contratoRepository = contratoRepository;
        }
        public async Task<int> Handle(CreateContractCommand request, CancellationToken cancellationToken)
        {
            var proveedor = new Proveedor()
            {
                IdProveedor = request.Proveedores.IdProveedor,
                DocumentoProveedor = request.Proveedores.DocumentoProveedor,
                Paterno_Proveedor = request.Proveedores.Paterno_Proveedor,
                Materno_Proovedor = request.Proveedores.Materno_Proovedor,
                Nombres_Proovedor = request.Proveedores.Nombres_Proovedor,


            };
            var proveedorQuery = await _proveedorRepository.GetProveedorByid(proveedor.IdProveedor);
            if (proveedorQuery is null)
            {
                await _proveedorRepository.InsertarProveedor(proveedor);
            }

            var representante = new DOMAIN.Representante() 
            {
                IdRepresentante = request.RepresentanteLegal.IdRepresentante,
                Paterno = request.RepresentanteLegal.Paterno,
                Materno = request.RepresentanteLegal.Materno,
                Nombres = request.RepresentanteLegal.Nombres
            };

            var result = await _representanteRepository.GetRepresentanteById(representante.IdRepresentante);
            if (result is null)
            {
                _representanteRepository.InsertarRepresentante(representante);
            }
            var cliente = new DOMAIN.InfoCliente() 
            {
                  IdInfoCliente = request.INFO_CLIENTEDto.IdInfoCliente, 
                  Domicilio = request.INFO_CLIENTEDto.Domicilio,
                  Direccion1 = request.INFO_CLIENTEDto.Direccion1, 
                  Ciudad = request.INFO_CLIENTEDto.Ciudad,
                  Superficie = request.INFO_CLIENTEDto.Superficie, 
                  NumeroDireccion = request.INFO_CLIENTEDto.NumeroDireccion, 
                  Importe = request.INFO_CLIENTEDto.Importe, 
                  Literal = request.INFO_CLIENTEDto.Literal, 
                  Cuenta =  request.INFO_CLIENTEDto.Cuenta, 
                  NumeroMeses = request.INFO_CLIENTEDto.NumeroMeses, 
                  FechaInicialArrendamiento = request.INFO_CLIENTEDto.FechaInicialArrendamiento, 
                  FechaFinalArrendamiento = request.INFO_CLIENTEDto.FechaFinalArrendamiento,
                  FechaTenos = request.INFO_CLIENTEDto.FechaTenos, 
                  Mes = request.INFO_CLIENTEDto.Mes, 
                  Anio = request.INFO_CLIENTEDto.Anio
            };
            var temp = await _clienteRepository.GetClienteById(cliente.IdInfoCliente);
            if (temp is null)
            {
               await _clienteRepository.InsertarCliente(cliente);
            }


            var contrato = new Contrato
            {
                IdContrato = request.ContratoDto.IdContrato,
                Codigo_Contrato = request.ContratoDto.Codigo_Contrato,
                IdRepresentante = request.RepresentanteLegal.IdRepresentante,
                IdProveedor = request.Proveedores.IdProveedor,
                IdInfoCliente = request.INFO_CLIENTEDto.IdInfoCliente,

            };

            await _contratoRepository.InsertContrato(contrato);

            return contrato.IdContrato;
        }
    }
}
