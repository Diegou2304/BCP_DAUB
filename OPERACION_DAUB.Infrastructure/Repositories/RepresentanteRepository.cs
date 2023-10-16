using Dapper;
using Microsoft.Extensions.Options;
using OPERACION_DAUB.DOMAIN;
using OPERACION_DAUB.INFRASTRUCTURE.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OPERACION_DAUB.INFRASTRUCTURE.Repositories
{
    public class RepresentanteRepository : IRepresentanteRepository
    {
        private readonly string _connectionString;

        public RepresentanteRepository(IOptions<ConnectionStringConfig> connectionStringConfig )
        {
            _connectionString = "Server=LAPTOP-UF8012AL\\SQLEXPRESS; Database=BD_CONTRATOS_DAUB; Trusted_Connection=True; Encrypt=False";
        }
        public async Task<IEnumerable<Representante>> GetRepresentanteById(int id)
        {
            using var connection = new SqlConnection( _connectionString );

            string query = @"
                   select * from RepresentanteLegal where IdRepresentante = @Id ";

            var param = new
            {
                Id = id
            };

            return await connection.QueryAsync<Representante>(query, param);



        }

        public async Task<bool> RepresentanteExists(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            string query = @"
                   select IdRepresentante from RepresentanteLegal where IdRepresentante = @Id ";

            var param = new
            {
                Id = id
            };

            var result =  await connection.QueryAsync<Representante>(query, param);

            if (result is null) return false;

            return true;

        }

        public async Task InsertarRepresentante(Representante representanteLegal)
        {
            using var connection = new SqlConnection(_connectionString);
            string query = @"insert into representante values (@Id,@Paterno,@Materno,@Nombres)";

            var param = new
            {
                Id = representanteLegal.IdRepresentante,
                Paterno = representanteLegal.Paterno,
                Materno = representanteLegal.Materno,
                Nombres = representanteLegal.Nombres
            };

            await connection.ExecuteAsync(query, param);
        }
    }
}
