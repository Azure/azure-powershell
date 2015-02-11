namespace Microsoft.Azure.Commands.Network.ApplicationGateway.Model
{
    using System.Globalization;
    using System.Text;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Represents the application gateway parameters.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class CreateApplicationGatewayParameters
    {
        /// <summary>
        /// Gateway Name.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Name { get; set; }    

        /// <summary>
        /// Gateway Description.
        /// </summary>
        [DataMember(IsRequired = false)]
        public string Description { get; set; }        

        /// <summary>
        /// The vnet to which the gateway belongs.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string VnetName { get; set; }

        /// <summary>
        /// Subnets in the vnet to which the gateway belongs.
        /// </summary>
        [DataMember(IsRequired = true)]
        public SubnetCollection Subnets { get; set; }

        /// <summary>
        /// The number of instances to create for this gateway
        /// </summary>
        [DataMember(IsRequired = false)]
        public uint InstanceCount { get; set; }

        /// <summary>
        /// The size of each gateway instance.
        /// </summary>
        [DataMember(IsRequired = false)]
        public string GatewaySize { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(CultureInfo.InvariantCulture, "Name:{0};", string.IsNullOrEmpty(Name) ? "null" : Name);
            sb.AppendFormat(CultureInfo.InvariantCulture, "Description:{0};", string.IsNullOrEmpty(Description) ? "null" : Description);
            sb.AppendFormat(CultureInfo.InvariantCulture, "VnetName:{0};", string.IsNullOrEmpty(VnetName) ? "null" : VnetName);
            sb.AppendFormat(CultureInfo.InvariantCulture, "Subnets:");
            if (null != Subnets)
            {
                foreach (var subnet in Subnets)
                {
                    sb.AppendFormat(CultureInfo.InvariantCulture, " {0},", subnet);
                }
            }

            sb.AppendFormat(CultureInfo.InvariantCulture, "InstanceCount:{0};", InstanceCount);
            sb.AppendFormat(CultureInfo.InvariantCulture, "GatewaySize:{0}", string.IsNullOrEmpty(GatewaySize) ? "null" : GatewaySize);

            return sb.ToString();
        }
    }

}
