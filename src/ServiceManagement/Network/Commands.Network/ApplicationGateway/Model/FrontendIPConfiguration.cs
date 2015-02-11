namespace Microsoft.Azure.Commands.Network.ApplicationGateway.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;

    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class FrontendIPConfiguration: NamedConfigurationElement
    {
        internal  ApplicationGatewayConfigurationContext ConfigurationContext { get; set; }

        public static readonly string Type_Private = "Private";

        [DataMember(Order = 2, IsRequired = true)]
        public string Type { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public string StaticIPAddress { get; set; }

        public override void Validate()
        {
            if (!string.Equals(this.Type.ToString(), Type_Private, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new ApplicationGatewayConfigurationValidationException(
                    string.Format("Only 'Private' is allowed as Type of FrontendIPConfiguration {0}", this.Name));
            }
        }
    }
}
