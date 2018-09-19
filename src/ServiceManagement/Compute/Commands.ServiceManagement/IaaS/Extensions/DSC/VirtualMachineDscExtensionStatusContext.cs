
using System;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions
{
    public class VirtualMachineDscExtensionStatusContext
    {
        public string ServiceName { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string[] DscConfigurationLog { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}
