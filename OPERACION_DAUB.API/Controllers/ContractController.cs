using MediatR;
using Microsoft.AspNetCore.Mvc;
using OPERACION_DAUB.APPLICATION.Contract.CreateContract;

namespace OPERACION_DAUB.API.Controllers
{
    [ApiController]
    public class ContractController
    {
        private readonly IMediator _mediator;
        public ContractController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpPost("contracts")]
        public async Task<int> CreateContract([FromBody]CreateContractCommand command)
        {

            return await _mediator.Send(command);

        }
    }
}
