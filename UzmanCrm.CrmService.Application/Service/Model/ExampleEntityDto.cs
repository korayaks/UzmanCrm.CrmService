﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UzmanCrm.CrmService.Application.Service.Shared;

namespace UzmanCrm.CrmService.Application.Service.Model
{
    public class ExampleEntityDto: BaseSchemaDto<Guid>
    {
        public string Name { get; set; }
    }
}
