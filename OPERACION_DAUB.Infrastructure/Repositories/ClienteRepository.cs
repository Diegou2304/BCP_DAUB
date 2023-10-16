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
    public class ClienteRepository : IClienteRepository
    {
        private readonly string _connectionString;

        public ClienteRepository(IOptions<ConnectionStringConfig> config)
        {
            _connectionString = "Server=LAPTOP-UF8012AL\\SQLEXPRESS; Database=BD_CONTRATOS_DAUB; Trusted_Connection=True; Encrypt=False";
        }

        public async Task<IEnumerable<InfoCliente>> GetClienteById(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            string query = @"
                   select * from INFO_CLIENTE where IdInfoCliente = @Id ";

            var param = new
            {
                Id = id
            };

            return await connection.QueryAsync<InfoCliente>(query, param);
        }


        public async Task InsertarCliente(InfoCliente cliente)
        {
            using var connection = new SqlConnection(_connectionString);
            string query = @"insert into INFO_CLIENTE values (@Id,@Domicilio,@Direccion1,@Ciudad,@Superficie,
                                                              @NumeroDireccion,@Importe,@Literal,@Cuenta,@NumeroMeses,@FechaInicialArrendamiento,
                                                              @FechaFinalArrendamiento,@FechaTenos,@Mes,@Anio)";

            var param = new
            {
                Id = cliente.IdInfoCliente,
                Domicilio = cliente.Domicilio,
                Direccion1 = cliente.Direccion1,
                Ciudad = cliente.Ciudad,
                Superficie = cliente.Superficie,
                NumeroDireccion = cliente.NumeroDireccion,
                Importe = cliente.Importe,
                Literal = cliente.Literal,
                Cuenta = cliente.Cuenta,
                NumeroMeses = cliente.NumeroMeses,
                FechaInicialArrendamiento = cliente.FechaInicialArrendamiento,
                FechaFinalArrendamiento = cliente.FechaFinalArrendamiento,
                FechaTenos = cliente.FechaTenos,
                Mes = cliente.Mes,
                Anio = cliente.Anio,
            };

            await connection.ExecuteAsync(query, param);
        }


    }
}
