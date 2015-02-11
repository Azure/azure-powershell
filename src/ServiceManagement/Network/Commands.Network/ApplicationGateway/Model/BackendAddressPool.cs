using System.Linq;

namespace Microsoft.Azure.Commands.Network.ApplicationGateway.Model
{
    using System.Text;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Runtime.Serialization;


    /// <summary>
    /// This class represents the collection of backend servers. See backendAddressPools in the NRP spec
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class BackendAddressPool : NamedConfigurationElement
    {
        internal ApplicationGatewayConfigurationContext ConfigurationContext { get; set; }

        /// <summary>
        /// IP address or DNS names corresponding to the backend servers
        /// </summary>
        [DataMember(Name = "IPAddresses", Order = 2, IsRequired = true)]
        public BackendServerCollection BackendServers { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(CultureInfo.InvariantCulture, "Name: {0}", Name);

            sb.AppendFormat(CultureInfo.InvariantCulture, "BackendServers:");
            foreach (var backendServer in BackendServers)
            {
                sb.AppendFormat("{0}", string.IsNullOrEmpty(backendServer) ? "null" : backendServer);
            }

            return sb.ToString();
        }

        public override void Validate()
        {
            if (!this.BackendServers.Any())
            {
                throw new ApplicationGatewayConfigurationValidationException(string.Format("BackendAddressPool: {0} address pool cannot be empty", this.Name));
            }
        }
    }

    [CollectionDataContract(Name = "IPAddresses", ItemName = "IPAddress", Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class BackendServerCollection : List<string>
    {
    }
}
