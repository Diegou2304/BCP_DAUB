using Dapper;
using Microsoft.Extensions.Options;
using OPERACION_DAUB.DOMAIN;
using OPERACION_DAUB.INFRASTRUCTURE.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPERACION_DAUB.INFRASTRUCTURE.Repositories
{
    public class ContratoRepository : IContratoRepository
    {
        private readonly string _connectionString;
        public ContratoRepository(IOptions<ConnectionStringConfig> config) 
        {
            _connectionString = "Server=LAPTOP-UF8012AL\\SQLEXPRESS; Database=BD_CONTRATOS_DAUB; Trusted_Connection=True; Encrypt=False";
        }

        public async Task InsertContrato(Contrato contrato)
        {
            using var conn = new SqlConnection(_connectionString);
            string query = @"insert into Contrato values (@IdContrato,@Codigo_Contrato,@IdRepresentante,@IdProveedor,@IdInfoCliente)";

            var param = new
            {
                IdContrato = contrato.IdContrato,
                Codigo_Contrato = contrato.Codigo_Contrato,
                IdRepresentante = contrato.IdRepresentante,
                IdProveedor = contrato.IdProveedor,
                IdInfoCliente = contrato.IdInfoCliente
            };

            await conn.ExecuteAsync(query, param);
        }
    }
}
