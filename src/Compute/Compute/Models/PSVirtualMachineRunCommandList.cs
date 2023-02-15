using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Management.Compute.Models;

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
