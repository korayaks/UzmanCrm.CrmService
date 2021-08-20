using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UzmanCrm.CrmService.Domain.Abstraction;

namespace UzmanCrm.CrmService.Application.Service.Shared
{
    public class BaseSchemaDto<T>:IEntity
    {
        public T Id { get; set; }

        public Guid CreatedBy { get; set; }

        public Guid ModifiedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }
    }
}
