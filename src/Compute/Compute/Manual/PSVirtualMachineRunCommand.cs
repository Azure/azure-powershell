
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.Compute.Models
{

    public class PSVirtualMachineRunCommand : Resource
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
        public VirtualMachineRunCommandInstanceView InstanceView { get; set; }
    }
}