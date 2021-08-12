﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UzmanCrm.CrmService.Application.Service.Model;

namespace UzmanCrm.CrmService.Application.Service.Utilities
{
    public class ExampleService : IExampleService
    {
        public async Task<ExampleEntityDto> ExampleMethodAsync()
        {
            var data = new ExampleEntityDto();
            data.Name = "korayaks";
            return data;
        }
    }
}
