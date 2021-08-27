using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UzmanCrm.CrmService.Application.Application;

namespace UzmanCrm.CrmService.Application.Service.Utilities
{
    public interface IRabbitmqService : IApplicationService
    {
        void Send(string lastMessage);
    }
}
