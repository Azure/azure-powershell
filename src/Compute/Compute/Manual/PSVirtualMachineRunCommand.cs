
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.Compute.Models
{

    public class PSVirtualMachineRunCommand
    { 
        public string Name { get; set; }
        public string Location { get; set; }
        public string Id { get; set; }
        public string Type { get; set; }
        public IDictionary<string, string> Tags { get; set; }
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