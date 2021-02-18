using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
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

        public string Activity { get; set; }

        public IList<DependencyCondition> DependencyConditions { get; set; }

        public IDictionary<string, object> AdditionalProperties { get; set; }
    }
}
