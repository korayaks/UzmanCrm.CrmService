using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UzmanCrm.CrmService.Application.Service.Model;
using UzmanCrm.CrmService.Application.Service.Utilities;

namespace UzmanCrm.CrmService.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleController : ControllerBase
    {
        private readonly IExampleService exampleService;
        public ExampleController(IExampleService exampleService)
        {
            this.exampleService = exampleService; 
        }

        [HttpGet]
        public Task<ExampleEntityDto> ExampleMethod()
        {
            var res =  exampleService.ExampleMethodAsync();

            return res;
        }

        
    }
}
