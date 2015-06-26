using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute.Extension.DSC
{
    public class VirtualMachineDscExtensionBaseCmdlet : VirtualMachineExtensionBaseCmdlet
    {
        protected string ExtensionNamespace = "Microsoft.Powershell";
        protected string ExtensionName = "DSC";
        protected string DefaultContainerName = "windows-powershell-dsc";
        protected string DefaultExtensionVersion = "1.*";

        //why do we need this?
        internal static readonly Version CurrentProtocolVersion = new Version(2, 0, 0, 0);
        
        public VirtualMachineDscExtensionBaseCmdlet()
        {}
    }
}
