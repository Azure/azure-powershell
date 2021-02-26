using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Compute.Automation.Models
{
    public class PSVirtualMachineRunCommandList : PSVirtualMachineRunCommand
    {
        public PSVirtualMachineRunCommand ToPSVirtualMachineRunCommand()
        {
            return ComputeAutomationAutoMapperProfile.Mapper.Map<PSVirtualMachineRunCommand>(this);
        }
    }
}

