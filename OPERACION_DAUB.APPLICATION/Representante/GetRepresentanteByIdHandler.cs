using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using OPERACION_DAUB.INFRASTRUCTURE;
using OPERACION_DAUB.INFRASTRUCTURE.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPERACION_DAUB.APPLICATION.Representante
{
    public class GetRepresentanteByIdHandler : IRequestHandler<GetRepresentanteByIdQuery, IEnumerable<GetRepresentanteByIdResult>>
    {
        private readonly IRepresentanteRepository _representanteRepository;
        private readonly string _connectionString;
        private readonly IMapper _mapper;
        public GetRepresentanteByIdHandler(IOptions<ConnectionStringConfig> connectionString, 
                                            IRepresentanteRepository representanteRepository,
                                            IMapper mapper)
        {
            _connectionString = connectionString.Value.BDCONTRACTS;
            _representanteRepository = representanteRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetRepresentanteByIdResult>> Handle(GetRepresentanteByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _representanteRepository.GetRepresentanteById(request.id);

            return _mapper.Map<IEnumerable<GetRepresentanteByIdResult>>(result);


        }
    }
}
