using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UzmanCrm.CrmService.Domain.Base;

namespace UzmanCrm.CrmService.Domain.Entity
{
    public class ExampleEntity : BaseSchema<Guid>
    {
        public string Name { get; set; }
    }
}
