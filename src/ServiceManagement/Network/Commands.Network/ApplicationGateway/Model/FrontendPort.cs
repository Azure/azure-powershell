using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Microsoft.Azure.Commands.Network.ApplicationGateway.Model
{
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class FrontendPort : NamedConfigurationElement
    {
        internal  ApplicationGatewayConfigurationContext ConfigurationContext { get; set; }

        [DataMember(Order = 2, IsRequired = true)]
        public ushort Port { get; set; }
        
        public override void Validate()
        {
        }
    }
}