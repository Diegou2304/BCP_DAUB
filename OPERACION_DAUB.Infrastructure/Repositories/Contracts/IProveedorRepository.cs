using OPERACION_DAUB.DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPERACION_DAUB.INFRASTRUCTURE.Repositories.Contracts
{
    public interface IProveedorRepository
    {

        Task<IEnumerable<Proveedor>> GetProveedorByid(int id);
        Task InsertarProveedor(Proveedor proveedor);
    }
}
