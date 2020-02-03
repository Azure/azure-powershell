using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Management.Automation;
using Microsoft.Azure.Commands.Cdn.Properties;

namespace Microsoft.Azure.Commands.Cdn.Helpers
{
    public class WafPolicyResourceId
    {
        private const string WafPolicyResourceType = "webapplicationfirewallpolicies";

        public string SubscriptionId { get; private set; }
        public string ResourceGroupName { get; private set; }
        public string PolicyName { get; private set; }

        public WafPolicyResourceId(string rawResourceId)
        {
            var parsed = new ResourceIdentifier(rawResourceId);
            if (!parsed.ResourceType.ToLower().Equals(WafPolicyResourceType) || parsed.ParentResource != null)
            {
                throw new PSArgumentException(Resources.Error_WafPolicyResourceIdInvalid);
            }
            ResourceGroupName = parsed.ResourceGroupName;
            PolicyName = parsed.ResourceName;
            SubscriptionId = parsed.Subscription;
        }
    }
}
