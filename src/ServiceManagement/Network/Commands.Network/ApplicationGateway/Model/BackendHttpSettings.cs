using System.Runtime.Remoting.Channels;

namespace Microsoft.Azure.Commands.Network.ApplicationGateway.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;

    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class BackendHttpSettings : NamedConfigurationElement
    {
        internal  ApplicationGatewayConfigurationContext ConfigurationContext { get; set; }

        [DataMember(Order = 2, IsRequired = true)]
        public ushort Port { get; set; }

        [DataMember(Order = 3, IsRequired = true)]
        public Protocol Protocol { get; set; }

        [DataMember(Order = 4, IsRequired = true)]
        public string CookieBasedAffinity { get; set; }

        public override void Validate()
        {
            if (!string.Equals(this.Protocol.ToString(), "Http", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new ApplicationGatewayConfigurationValidationException(
                    string.Format("Only Http is allowed as Protocol of BackendHttpSettings {0}", this.Name));
            }

            if (!string.Equals(this.CookieBasedAffinity, "Enabled", StringComparison.InvariantCultureIgnoreCase) &&
                !string.Equals(this.CookieBasedAffinity, "Disabled", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new ApplicationGatewayConfigurationValidationException(
                    string.Format("Invalid value for CookieBasedAffinity in BackendHttpSettings {0}. Allowed values:[Enabled/Disabled]", this.Name));
            }
        }
    }
}
