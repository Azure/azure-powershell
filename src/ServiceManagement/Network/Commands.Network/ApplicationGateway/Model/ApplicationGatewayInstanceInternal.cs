namespace Microsoft.Azure.Commands.Network.ApplicationGateway.Model
{
    using System;    
    using System.Globalization;
    using System.Text;    
    using System.Runtime.Serialization;
    using System.Collections.Generic;

    /// <summary>
    /// This class represents the Application Gateway instance returned by diagnostics APIs.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class ApplicationGatewayInstanceInternal
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string SubscriptionId { get; set; }

        [DataMember]
        public long BytesIn { get; set; }

        [DataMember]
        public long BytesOut { get; set; }

        [DataMember]
        public long Compute { get; set; }

        [DataMember]
        public string Config { get; set; }

        [DataMember]
        public string CurrentInstanceVersion { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(CultureInfo.InvariantCulture, "Name:{0} ", string.IsNullOrEmpty(Name) ? "null" : Name);
            sb.AppendFormat(CultureInfo.InvariantCulture, "SubscriptionId:{0} ", string.IsNullOrEmpty(SubscriptionId) ? "null" : SubscriptionId);
            sb.AppendFormat(CultureInfo.InvariantCulture, "BytesIn:{0} ", BytesIn);
            sb.AppendFormat(CultureInfo.InvariantCulture, "BytesOut:{0} ", BytesOut);
            sb.AppendFormat(CultureInfo.InvariantCulture, "Compute:{0} ", Compute);
            sb.AppendFormat(CultureInfo.InvariantCulture, "CurrentInstanceVersion:{0} ", string.IsNullOrEmpty(CurrentInstanceVersion) ? "null" : CurrentInstanceVersion);
            sb.AppendLine();
            sb.Append("Config:");
            sb.AppendLine();
            sb.AppendFormat(CultureInfo.InvariantCulture, "{0} ", string.IsNullOrEmpty(Config) ? "null" : Config);

            return sb.ToString();
        }

        public static void ShowDetails(ApplicationGatewayInstanceInternal applicationGatewayInstanceInternal)
        {
            Console.WriteLine("Name:{0}", applicationGatewayInstanceInternal.Name);
            Console.WriteLine("SubscriptionId:{0}", applicationGatewayInstanceInternal.SubscriptionId);
            Console.WriteLine("BytesIn:{0}", applicationGatewayInstanceInternal.BytesIn);
            Console.WriteLine("BytesOut:{0}", applicationGatewayInstanceInternal.BytesOut);
            Console.WriteLine("Compute:{0}", applicationGatewayInstanceInternal.Compute);
            Console.WriteLine("CurrentInstanceVersion:{0}", applicationGatewayInstanceInternal.CurrentInstanceVersion);   
            Console.WriteLine("Config:");
            Console.WriteLine("{0}", applicationGatewayInstanceInternal.Config);   
        }
    }

    [CollectionDataContract(Name = "ApplicationGatewayInstancesInternal", Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class ApplicationGatewayInstanceInternalCollection : List<ApplicationGatewayInstanceInternal>
    {
    }
}