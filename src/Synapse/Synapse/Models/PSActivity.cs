using Azure.Analytics.Synapse.Artifacts.Models;
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
            this.Keys = activity?.Keys;
            this.Values = activity?.Values;
        }

        public PSActivity() { }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public IList<PSActivityDependency> DependsOn { get; set; }

        public IList<PSUserProperty> UserProperties { get; set; }

        public ICollection<string> Keys { get; set; }

        public ICollection<object> Values { get; set; }

        public virtual void Validate() { }

        public virtual Activity ToSdkObject()
        {
            Activity activity = new Activity(this.Name)
            {
                Description = this.Description,
            };
            return activity;
        }
    }
}
