using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Models
{
    public partial class VirtualMachineWrapper
    {
        public VirtualMachine VirtualMachine { get; set; }
        public Dictionary<string, List<string>> CustomHeaders { get; set; }

    }
}
