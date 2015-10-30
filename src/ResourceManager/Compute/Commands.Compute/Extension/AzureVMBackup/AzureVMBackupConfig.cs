using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute.Extension.AzureVMBackup
{
    public class AzureVMBackupConfig
    {
        public string ResourceGroupName { get; set; }
        public string VMName { get; set; }
        public string ExtensionName { get; set; }
        public string VirtualMachineExtensionType { get; set; }
    }
}
