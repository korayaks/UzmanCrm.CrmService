using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UzmanCrm.CrmService.Application.Service.Model;
using UzmanCrm.CrmService.Domain.Entity;

namespace UzmanCrm.CrmService.Application.Service.ExampleService.Mappings
{
    public class ExampleProfile : Profile
    {
        public ExampleProfile()
        {
            this.CreateMap<ExampleEntity, ExampleEntityDto>().ReverseMap();
        }
    }
}
