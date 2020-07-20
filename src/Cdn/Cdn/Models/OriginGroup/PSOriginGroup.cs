using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Cdn.Models.OriginGroup
{
    public class PSOriginGroup : PSResource
    {
        private const string OriginGroupKeyPatternFormat =
   @"\/subscriptions\/(?<{0}>.*)\/resourcegroups\/(?<{1}>.*)\/providers\/Microsoft\.Cdn\/profiles\/(?<{2}>.*)\/endpoints\/(?<{3}>.*)\/origingroups\/(?<{4}>.*)";

        private const string SubscriptionIdGroupKey = "subscriptionId";
        private const string ResourceGroupGroupKey = "resourceGroup";
        private const string ProfileNameGroupKey = "profileName";
        private const string EndpointNameGroupKey = "endpointName";
        private const string OriginGroupNameGroupKey = "originGroupName";

        public string ResourceGroupName
        {
            get
            {
                return Regex.Match(Id,
                string.Format(OriginGroupKeyPatternFormat,
                    SubscriptionIdGroupKey,
                    ResourceGroupGroupKey,
                    ProfileNameGroupKey,
                    EndpointNameGroupKey,
                    OriginGroupNameGroupKey), RegexOptions.IgnoreCase).Groups[ResourceGroupGroupKey].Value;
            }
        }

        public string ProfileName
        {
            get
            {
                return Regex.Match(Id,
                string.Format(OriginGroupKeyPatternFormat,
                    SubscriptionIdGroupKey,
                    ResourceGroupGroupKey,
                    ProfileNameGroupKey,
                    EndpointNameGroupKey,
                    OriginGroupNameGroupKey), RegexOptions.IgnoreCase).Groups[ProfileNameGroupKey].Value;
            }
        }

        public string EndpointName
        {
            get
            {
                return Regex.Match(Id,
                string.Format(OriginGroupKeyPatternFormat,
                    SubscriptionIdGroupKey,
                    ResourceGroupGroupKey,
                    ProfileNameGroupKey,
                    EndpointNameGroupKey,
                    OriginGroupNameGroupKey), RegexOptions.IgnoreCase).Groups[EndpointNameGroupKey].Value;
            }
        }
    }
}
