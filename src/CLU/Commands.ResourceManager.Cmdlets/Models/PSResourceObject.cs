using Microsoft.Azure.Commands.Utilities.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Models
{
    public class PSResourceObject
    {
        public string Name { get; set; }

        public string ResourceId { get; set; }

        public string ResourceName { get; set; }

        public string ResourceType { get; set; }

        public string ResourceGroupName { get; set; }

        public string Location { get; set; }

        public string SubscriptionId { get; set; }

        public Dictionary<string,string> Properties { get; private set; }

        public string PropertiesText
        {
            get
            {
                var sb = new StringBuilder();
                if (Properties.Count > 0)
                {
                    sb.AppendLine();
                }
                Properties.ForEach(kvp =>
                    sb.AppendLine(string.Format("    {0}: {1}", kvp.Key, kvp.Value).Replace("\r\n", "")));

                return sb.ToString();
            }
        }

        public PSResourceObject()
        {
            Properties = new Dictionary<string, string>();
        }

    }
}
