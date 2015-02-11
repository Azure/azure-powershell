namespace Microsoft.Azure.Commands.Network.ApplicationGateway.Model
{
    using System.Runtime.Serialization;

    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class HttpLoadBalancingRule : NamedConfigurationElement
    {
        internal  ApplicationGatewayConfigurationContext ConfigurationContext { get; set; }

        [DataMember(Order = 2, IsRequired = true)]
        public string Type;

        [DataMember(Order = 3, IsRequired = true)]
        public string BackendHttpSettings;

        [DataMember(Order = 4, IsRequired = true)]
        public string Listener { get; set; }

        [DataMember(Order = 5, IsRequired = true)]
        public string BackendAddressPool { get; set; }

        public override void Validate()
        {
            if (!this.ConfigurationContext.BackendHttpSettingsList.ContainsKey(this.BackendHttpSettings.ToLower()))
            {
                throw new ApplicationGatewayConfigurationValidationException(string.Format("BackendHttpSettings: {0} reference does not exist", this.BackendHttpSettings));
            }

            if (!this.ConfigurationContext.HttpListeners.ContainsKey(this.Listener.ToLower()))
            {
                throw new ApplicationGatewayConfigurationValidationException(string.Format("HttpListener: {0} reference does not exist", this.Listener));
            }

            if (!this.ConfigurationContext.BackendAddressPools.ContainsKey(this.BackendAddressPool.ToLower()))
            {
                throw new ApplicationGatewayConfigurationValidationException(string.Format("BackendAddressPool: {0} reference does not exist", this.BackendAddressPool));
            }
        }
    }
}
