using Microsoft.Azure.Commands.Utilities.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Resources;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Commands.Tags.Model;
using Microsoft.Cci.UtilityDataStructures;
using Hashtable = System.Collections.Hashtable;

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

        public List<Hashtable> Tags { get; set; }

        [JsonIgnore]
        public string TagsText
        {
            get
            {
                return Tags ==null? null : TagsConversionHelper.SerializeTags(TagsHelper.GetTagsDictionary(Tags));
            }
        }

        public Dictionary<string,string> Properties { get; private set; }

        [JsonIgnore]
        public string PropertiesText
        {
            get
            {
                var sb = new StringBuilder();
                if (Properties.Count > 0)
                {
                    sb.AppendLine();
                }
                Properties.Where(k => k.Key != "Properties").ForEach(kvp =>
                    sb.AppendLine(string.Format("    {0}: {1}", kvp.Key, kvp.Value).Replace("\r\n", "")));
                if (Properties.ContainsKey("Properties"))
                {
                    sb.AppendFormat("    Properties: {0}", Properties["Properties"]);
                }

                return sb.ToString();
            }
        }

        public PSResourceObject()
        {
            Properties = new Dictionary<string, string>();
        }

    }
}
