using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Automation.Models
//namespace Microsoft.Azure.Commands.Compute.Models
{
    public partial class PSVirtualMachineRunCommand
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

        public string ProvisioningState { get; }

        public VirtualMachineRunCommandInstanceView InstanceView { get; }

        // Gets or sets the property of 'Id'
        public string Id { get; set; }

        // Gets or sets the property of 'Name'
        public string Name { get; set; }

        public string Type { get; set; }

        public string Location { get; set; }

        public IDictionary<string, string> Tags { get; set; }


    }
}
