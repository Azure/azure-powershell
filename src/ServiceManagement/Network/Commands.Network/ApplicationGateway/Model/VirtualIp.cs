namespace Microsoft.Azure.Commands.Network.ApplicationGateway.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Globalization;
    
    [CollectionDataContract(Name = "VirtualIPs", ItemName = "VirtualIP", Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class VirtualIpCollection : List<string>
    {
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            bool isFirst = true;

            this.ForEach(delegate(String name)
            {
                if (!isFirst)
                {
                    sb.AppendFormat(", ");
                }
                isFirst = false;
                sb.AppendFormat(CultureInfo.InvariantCulture, name);
            });
            return sb.ToString();
        }
    }
}
