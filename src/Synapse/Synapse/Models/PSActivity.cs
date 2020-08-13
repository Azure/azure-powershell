using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
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

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "dependsOn")]
        public IList<PSActivityDependency> DependsOn { get; set; }

        [JsonProperty(PropertyName = "userProperties")]
        public IList<PSUserProperty> UserProperties { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; }

        public virtual void Validate() { }

        public virtual Activity ToSdkObject()
        {
            Activity activity = new Activity(this.Name);
            SetProperties(activity);
            return activity;
        }

        protected void SetProperties(Activity activity)
        {
            activity.Description = this.Description;
            this.DependsOn?.ForEach(item => activity.DependsOn.Add(item?.ToSdkObject()));
            this.UserProperties?.ForEach(item => activity.UserProperties.Add(item?.ToSdkObject()));
            if (this.AdditionalProperties != null)
            {
                foreach (var item in this.AdditionalProperties)
                {
                    if (item.Key != "typeProperties")
                    {
                        activity.Add(item.Key, item.Value);
                    }
                }
            }
        }
    }
}
