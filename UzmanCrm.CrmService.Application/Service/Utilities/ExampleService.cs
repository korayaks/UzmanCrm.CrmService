using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UzmanCrm.CrmService.Application.Service.Model;
using UzmanCrm.CrmService.Domain.Entity;

namespace UzmanCrm.CrmService.Application.Service.Utilities
{
    public class ExampleService : IExampleService
    {
        private readonly IMapper _mapper;
        public ExampleService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ExampleEntityDto> ExampleMethodAsync()
        {
            var data = new ExampleEntity()
            {
                Name = "Entity name",

                Id = new Guid(),
                CreatedBy = new Guid(),
                ModifiedBy = new Guid(),
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                IsActive = true,
                IsDelete = false
            };
            
            var userinfo = _mapper.Map<ExampleEntityDto>(data);
            return userinfo;
        }
       
        public async Task<List<ExampleEntityDto>> ExapmleMethodList()
        {
            var list = new List<ExampleEntity>()
            {
                new ExampleEntity()
                {
                    Name = "koray"
                },
                new ExampleEntity()
                {
                    Name = "burak"
                },new ExampleEntity()
                {
                    Name = "aksoy"
                }
            };
            var userlist = _mapper.Map<List<ExampleEntityDto>>(list);
            return userlist;
        }
    }
}
