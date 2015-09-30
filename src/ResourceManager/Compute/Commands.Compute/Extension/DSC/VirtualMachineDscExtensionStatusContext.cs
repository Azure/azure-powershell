
using System;

namespace Microsoft.Azure.Commands.Compute.Extension.DSC
{
    public class VirtualMachineDscExtensionStatusContext
    {
        public string ResourceGroupName { get; set; }
        public string VmName { get; set; }
        public string Version { get; set; }
        public string Status { get; set; }
        public string StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string[] DscConfigurationLog { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}
