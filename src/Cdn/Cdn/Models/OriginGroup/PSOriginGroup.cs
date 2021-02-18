// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Management.Cdn.Models;
using System.Collections.Generic;
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

        public int ProbeIntervalInSeconds { get; set; }
        public string ProbePath { get; set; }
        public string ProbeProtocol { get; set; }
        public string ProbeRequestType { get; set; }

        public IList<ResourceReference> Origins { get; set; }

        public PSOriginGroupResourceState ResourceState { get; set; }

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
