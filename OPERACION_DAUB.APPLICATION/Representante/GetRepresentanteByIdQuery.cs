using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPERACION_DAUB.APPLICATION.Representante
{
    public class GetRepresentanteByIdQuery : IRequest<IEnumerable<GetRepresentanteByIdResult>>
    {
        public int id;
    }
}
