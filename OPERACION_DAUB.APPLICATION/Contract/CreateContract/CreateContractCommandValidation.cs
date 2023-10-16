using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPERACION_DAUB.APPLICATION.Contract.CreateContract
{
    public class CreateContractCommandValidation : AbstractValidator<CreateContractCommand>
    {
        public CreateContractCommandValidation()
        {
            RuleFor(command => command.RepresentanteLegal)
            .NotNull()
            .WithMessage("El campo representanteLegal es requerido.");

            When(command => command.RepresentanteLegal != null, () =>
            {
                RuleFor(command => command.RepresentanteLegal.IdRepresentante)
                    .GreaterThan(0)
                    .WithMessage("El campo idRepresentante del representante legal debe ser un número mayor que 0.");

                RuleFor(command => command.RepresentanteLegal.Paterno)
                    .NotEmpty()
                    .WithMessage("El campo paterno del representante legal no puede estar vacío.");

                RuleFor(command => command.RepresentanteLegal.Materno)
                    .NotEmpty()
                    .WithMessage("El campo materno del representante legal no puede estar vacío.");

                RuleFor(command => command.RepresentanteLegal.Nombres)
                    .NotEmpty()
                    .WithMessage("El campo nombres del representante legal no puede estar vacío.");
            });

            RuleFor(command => command.Proveedores)
                .NotNull()
                .WithMessage("El campo proveedores es requerido.");

            When(command => command.Proveedores != null, () =>
            {
                RuleFor(command => command.Proveedores.IdProveedor)
                    .GreaterThan(0)
                    .WithMessage("El campo idProveedor del proveedor debe ser un número mayor que 0.");

                RuleFor(command => command.Proveedores.Paterno_Proveedor)
                    .NotEmpty()
                    .WithMessage("El campo paterno_Proveedor del proveedor no puede estar vacío.");

                RuleFor(command => command.Proveedores.Materno_Proovedor)
                    .NotEmpty()
                    .WithMessage("El campo materno_Proovedor del proveedor no puede estar vacío.");

                RuleFor(command => command.Proveedores.Nombres_Proovedor)
                    .NotEmpty()
                    .WithMessage("El campo nombres_Proovedor del proveedor no puede estar vacío.");

                RuleFor(command => command.Proveedores.DocumentoProveedor)
                    .NotEmpty()
                    .WithMessage("El campo documentoProveedor del proveedor no puede estar vacío.");
            });

            RuleFor(command => command.INFO_CLIENTEDto)
                .NotNull()
                .WithMessage("El campo infO_CLIENTEDto es requerido.");

            When(command => command.INFO_CLIENTEDto != null, () =>
            {
                RuleFor(command => command.INFO_CLIENTEDto.IdInfoCliente)
                    .GreaterThan(0)
                    .WithMessage("El campo idInfoCliente debe ser un número mayor que 0.");

                RuleFor(command => command.INFO_CLIENTEDto.Domicilio)
                    .NotEmpty()
                    .WithMessage("El campo domicilio del cliente no puede estar vacío.");

                RuleFor(command => command.INFO_CLIENTEDto.Direccion1)
                    .NotEmpty()
                    .WithMessage("El campo direccion1 del cliente no puede estar vacío.");

                RuleFor(command => command.INFO_CLIENTEDto.Ciudad)
                    .NotEmpty()
                    .WithMessage("El campo ciudad del cliente no puede estar vacío.");

                RuleFor(command => command.INFO_CLIENTEDto.Superficie)
                    .GreaterThan(0)
                    .WithMessage("El campo superficie del cliente debe ser un número mayor que 0.");

                RuleFor(command => command.INFO_CLIENTEDto.NumeroDireccion)
                    .NotEmpty()
                    .WithMessage("El campo numeroDireccion del cliente no puede estar vacío.");

                RuleFor(command => command.INFO_CLIENTEDto.Importe)
                    .GreaterThanOrEqualTo(0)
                    .WithMessage("El campo importe del cliente debe ser un número mayor o igual a 0.");

                RuleFor(command => command.INFO_CLIENTEDto.Cuenta)
                    .NotEmpty()
                    .WithMessage("El campo cuenta del cliente no puede estar vacío.");

                RuleFor(command => command.INFO_CLIENTEDto.NumeroMeses)
                    .GreaterThan(0)
                    .WithMessage("El campo numeroMeses del cliente debe ser un número mayor que 0.");

                RuleFor(command => command.INFO_CLIENTEDto.Mes)
                    .NotEmpty()
                    .WithMessage("El campo mes del cliente no puede estar vacío.");

                RuleFor(command => command.INFO_CLIENTEDto.Anio)
                    .NotEmpty()
                    .WithMessage("El campo anio del cliente no puede estar vacío.");
            });

            RuleFor(command => command.ContratoDto)
                .NotNull()
                .WithMessage("El campo contratoDto es requerido.");

            When(command => command.ContratoDto != null, () =>
            {
                RuleFor(command => command.ContratoDto.IdContrato)
                    .GreaterThan(0)
                    .WithMessage("El campo idContrato del contrato debe ser un número mayor que 0.");

                RuleFor(command => command.ContratoDto.Codigo_Contrato)
                    .NotEmpty()
                    .WithMessage("El campo codigo_Contrato del contrato no puede estar vacío.");

                RuleFor(command => command.ContratoDto.IdRepresentante)
                    .GreaterThan(0)
                    .WithMessage("El campo idRepresentante del contrato debe ser un número mayor que 0.");

                RuleFor(command => command.ContratoDto.IdProveedor)
                    .GreaterThan(0)
                    .WithMessage("El campo idProveedor del contrato debe ser un número mayor que 0.");

                RuleFor(command => command.ContratoDto.IdInfoCliente)
                    .GreaterThan(0)
                    .WithMessage("El campo idInfoCliente del contrato debe ser un número mayor que 0.");
            });
        }
    }
}
