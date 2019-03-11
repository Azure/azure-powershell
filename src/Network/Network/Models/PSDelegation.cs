using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSDelegation : PSChildResource
    {
        [Ps1Xml(Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }

        public string ServiceName { get; set; }

        public List<string> Actions { get; set; }
    }
}
