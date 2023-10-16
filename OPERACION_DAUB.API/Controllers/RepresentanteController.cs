using MediatR;
using Microsoft.AspNetCore.Mvc;
using OPERACION_DAUB.APPLICATION.Representante;

namespace OPERACION_DAUB.API.Controllers
{
    [ApiController]
    public class RepresentanteController
    {
        private readonly IMediator _mediator;
        public RepresentanteController(IMediator mediator)
        {
            _mediator = mediator;
            
        }

        [HttpGet("representantes/{id}")]
        public async Task<IEnumerable<GetRepresentanteByIdResult>> GetRepresentanteById([FromRoute]int id)
        {
            var query = new GetRepresentanteByIdQuery
            {
                id = id
            };
            return await  _mediator.Send(query);
        }
    }
}
