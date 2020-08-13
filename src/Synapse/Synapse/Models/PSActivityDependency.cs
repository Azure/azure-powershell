using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSActivityDependency
    {
        public PSActivityDependency(ActivityDependency dependency)
        {
            this.Activity = dependency?.Activity;
            this.DependencyConditions = dependency?.DependencyConditions;
            var propertiesEnum = dependency?.GetEnumerator();
            if (propertiesEnum != null)
            {
                this.AdditionalProperties = new Dictionary<string, object>();
                while (propertiesEnum.MoveNext())
                {
                    this.AdditionalProperties.Add(propertiesEnum.Current);
                }
            }
        }

        [JsonProperty(PropertyName = "activity")]
        public string Activity { get; set; }

        [JsonProperty(PropertyName = "dependencyConditions")]
        public IList<DependencyCondition> DependencyConditions { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; }

        public ActivityDependency ToSdkObject()
        {
            var dependency = new ActivityDependency(this.Activity, this.DependencyConditions);
            this.AdditionalProperties?.ForEach(item => dependency.Add(item.Key, item.Value));
            return dependency;
        }
    }
}
