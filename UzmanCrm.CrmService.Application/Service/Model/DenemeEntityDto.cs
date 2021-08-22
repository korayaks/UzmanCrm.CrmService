using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UzmanCrm.CrmService.Application.Service.Shared;
using UzmanCrm.CrmService.Domain.Abstraction;

namespace UzmanCrm.CrmService.Application.Service.Model
{
    public class DenemeEntityDto : BaseSchemaDto<Guid>, IEntity
    {
        public string Name { get; set; }
        public string adres { get; set; }
        public string yas { get; set; }
    }
}
