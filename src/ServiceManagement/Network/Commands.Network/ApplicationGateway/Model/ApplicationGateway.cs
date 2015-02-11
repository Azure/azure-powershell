namespace Microsoft.Azure.Commands.Network.ApplicationGateway.Model
{
    using System;
    using System.Linq;
    using System.Globalization;
    using System.Text;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// This class represents the Application Gateway returned by Get/List APIs.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class ApplicationGateway
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string VnetName { get; set; }

        [DataMember]
        public SubnetCollection Subnets { get; set; }

        [DataMember]
        public uint InstanceCount { get; set; }

        [DataMember]
        public string GatewaySize { get; set; }

        [DataMember]
        public string State { get; set; }

        [DataMember]
        public VirtualIpCollection VirtualIPs { get; set; }

        [DataMember]
        public string DnsName { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(CultureInfo.InvariantCulture, "Name:{0} ", string.IsNullOrEmpty(Name) ? "null" : Name);
            sb.AppendFormat(CultureInfo.InvariantCulture, "Description:{0} ", string.IsNullOrEmpty(Description) ? "null" : Description);
            sb.AppendFormat(CultureInfo.InvariantCulture, "VnetName:{0} ", string.IsNullOrEmpty(VnetName) ? "null" : VnetName);
            sb.AppendFormat(CultureInfo.InvariantCulture, "Subnets:{0} ", !Subnets.Any() ? "null" : Subnets.ToString());
            sb.AppendFormat(CultureInfo.InvariantCulture, "InstanceCount:{0} ", InstanceCount);
            sb.AppendFormat(CultureInfo.InvariantCulture, "GatewaySize:{0} ", string.IsNullOrEmpty(GatewaySize) ? "null" : GatewaySize);
            sb.AppendFormat(CultureInfo.InvariantCulture, "State:{0} ", string.IsNullOrEmpty(State) ? "null" : State);
            sb.AppendFormat(CultureInfo.InvariantCulture, "VirtualIPs:{0} ", !VirtualIPs.Any() ? "null" : VirtualIPs.ToString());
            sb.AppendFormat(CultureInfo.InvariantCulture, "DnsName:{0} ", string.IsNullOrEmpty(DnsName) ? "null" : DnsName);

            return sb.ToString();
        }

        public static void ShowDetails(ApplicationGateway applicationGateway)
        {
            Console.WriteLine("Name:{0}", applicationGateway.Name);
            Console.WriteLine("Description:{0}", applicationGateway.Description);
            Console.WriteLine("VnetName:{0}", applicationGateway.VnetName);
            Console.WriteLine("Subnets:{0}", applicationGateway.Subnets);
            Console.WriteLine("InstanceCount:{0}", applicationGateway.InstanceCount);
            Console.WriteLine("GatewaySize:{0}", applicationGateway.GatewaySize);
            Console.WriteLine("State:{0}", applicationGateway.State);
            Console.WriteLine("VirtualIPs:{0}", applicationGateway.VirtualIPs);
            Console.WriteLine("DnsName:{0}", applicationGateway.DnsName);
        }
    }

    [CollectionDataContract(Name = "ApplicationGateways", Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class ApplicationGatewayCollection : List<ApplicationGateway>
    {
    }
}
