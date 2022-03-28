using Microsoft.Azure.Management.Compute.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Compute.Models
{
    public class VirtualMachineWrapper
    {
        public VirtualMachine VirtualMachine { get; set; }
        public Dictionary<string, List<string>> CustomHeaders { get; set; }

    }
}
