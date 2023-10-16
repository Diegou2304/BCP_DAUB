using AutoMapper;
using OPERACION_DAUB.APPLICATION.Contract.CreateContract;
using OPERACION_DAUB.APPLICATION.Representante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPERACION_DAUB.APPLICATION.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
        
            CreateMap<DOMAIN.Representante, GetRepresentanteByIdResult>();
            

        }
    }
}
