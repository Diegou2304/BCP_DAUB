using Dapper;
using Microsoft.Extensions.Options;
using OPERACION_DAUB.DOMAIN;
using OPERACION_DAUB.INFRASTRUCTURE.Repositories.Contracts;
using System.Data.SqlClient;

namespace OPERACION_DAUB.INFRASTRUCTURE.Repositories
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly string _connectionString;

        public ProveedorRepository(IOptions<ConnectionStringConfig> config)
        {
            _connectionString = "Server=LAPTOP-UF8012AL\\SQLEXPRESS; Database=BD_CONTRATOS_DAUB; Trusted_Connection=True; Encrypt=False";
        }

        public async Task<IEnumerable<Proveedor>> GetProveedorByid(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            string query = @"
                   select * from Proveedores where IdProveedor = @Id ";

            var param = new
            {
                Id = id
            };

            return await connection.QueryAsync<Proveedor>(query, param);
        }

        public async Task InsertarProveedor(Proveedor proveedor)
        {
            using var connection = new SqlConnection(_connectionString);
            string query = @"insert into Proveedores values (@IdProveedor, @PaternoProveedor, @MaternoProveedor, @Nombres_Proveedor, @DocumentoProveedor)";

            var param = new
            {
               IdProveedor = proveedor.IdProveedor,
               PaternoProveedor = proveedor.Paterno_Proveedor,
               MaternoProveedor = proveedor.Materno_Proovedor,
               Nombres_Provedor = proveedor.Nombres_Proovedor,
               DocumentoProveedor = proveedor.DocumentoProveedor,
            };

            await connection.ExecuteAsync(query, param);
        }
    }
}
