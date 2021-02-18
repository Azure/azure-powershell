using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSActivity
    {
        public PSActivity(Activity activity)
        {
            this.Name = activity?.Name;
            this.Description = activity?.Description;
            this.DependsOn = activity?.DependsOn?.Select(element => new PSActivityDependency(element)).ToList();
            this.UserProperties = activity?.UserProperties?.Select(element => new PSUserProperty(element)).ToList();
            var propertiesEnum = activity?.GetEnumerator();
            if (propertiesEnum != null)
            {
                this.AdditionalProperties = new Dictionary<string, object>();
                while (propertiesEnum.MoveNext())
                {
                    this.AdditionalProperties.Add(propertiesEnum.Current);
                }
            }
        }

        public PSActivity() { }

        public string Name { get; set; }

        public string Description { get; set; }

        public IList<PSActivityDependency> DependsOn { get; set; }

        public IList<PSUserProperty> UserProperties { get; set; }

        public IDictionary<string, object> AdditionalProperties { get; set; }

        public virtual void Validate() { }
    }
}
