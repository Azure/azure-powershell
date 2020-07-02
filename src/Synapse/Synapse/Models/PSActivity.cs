using Azure.Analytics.Synapse.Artifacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSActivity
    {
        public PSActivity(Activity activity)
        {
            if (activity != null)
            {
                this.Name = activity.Name;
                this.Description = activity.Description;
                this.DependsOn = activity.DependsOn.Select(element => new PSActivityDependency(element)).ToList();
                this.UserProperties = activity.UserProperties.Select(element => new PSUserProperty(element)).ToList();
                this.Keys = activity.Keys;
                this.Values = activity.Values;
            }
        }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public IList<PSActivityDependency> DependsOn { get; set; }

        public IList<PSUserProperty> UserProperties { get; set; }

        public ICollection<string> Keys { get; set; }

        public ICollection<object> Values { get; set; }

        public static Activity ToSdkObject(PSActivity pSActivity)
        {
            Activity activity = new Activity(pSActivity.Name)
            {
                Description = pSActivity.Description,
            };

            IList<PSActivityDependency> pSDependsOn = pSActivity.DependsOn;
            if (pSDependsOn != null)
            {
                IList<ActivityDependency> dependsOn = new List<ActivityDependency>();
                foreach (PSActivityDependency pSDependOn in pSDependsOn)
                {
                    dependsOn.Add(PSActivityDependency.ToSdkObject(pSDependOn));
                }
                activity.DependsOn = dependsOn;
            }

            IList<PSUserProperty> pSUserProperties = pSActivity.UserProperties;
            if (pSUserProperties != null)
            {
                IList<UserProperty> userProperties = new List<UserProperty>();
                foreach (PSUserProperty pSUserProperty in pSUserProperties)
                {
                    userProperties.Add(PSUserProperty.ToSdkObject(pSUserProperty));
                }
                activity.UserProperties = userProperties;
            }

            return activity;
        }
    }
}
