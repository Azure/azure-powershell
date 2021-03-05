using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Automation.Models
{
    public partial class PSVirtualMachineRunCommand : Resource
    {
        public VirtualMachineRunCommandScriptSource Source { get; set; }

        public IList<RunCommandInputParameter> Parameters { get; set; }

        public IList<RunCommandInputParameter> ProtectedParameters { get; set; }

        public bool? AsyncExecution { get; set; }

        public string RunAsUser { get; set; }

        public string RunAsPassword { get; set; }

        public int? TimeoutInSeconds { get; set; }

        public string OutputBlobUri { get; set; }

        public string ErrorBlobUri { get; set; }

        public string ProvisioningState { get; set; }

        public VirtualMachineRunCommandInstanceView InstanceView { get; set; }

    }
}
