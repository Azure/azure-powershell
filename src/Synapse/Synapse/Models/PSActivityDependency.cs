using Azure.Analytics.Synapse.Artifacts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSActivityDependency
    {
        public PSActivityDependency(ActivityDependency dependency)
        {
            this.Activity = dependency.Activity;
            this.DependencyConditions = dependency.DependencyConditions;
            this.Keys = dependency.Keys;
            this.Values = dependency.Values;
        }

        public string Activity { get; set; }

        public IList<DependencyCondition> DependencyConditions { get; set; }

        public ICollection<string> Keys { get; }

        public ICollection<object> Values { get; }

        public static ActivityDependency ToSdkObject(PSActivityDependency pSActivityDependency)
        {
           return new ActivityDependency(pSActivityDependency.Activity, pSActivityDependency.DependencyConditions);
        }
    }
}
