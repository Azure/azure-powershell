using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Compute.Automation.Models
{
    public class PSDiskAccessList : PSDiskAccess
    {
        public PSDiskAccess ToPSDiskAccess ()
        {
            return ComputeAutomationAutoMapperProfile.Mapper.Map<PSDiskAccess>(this);
        }
    }
}
