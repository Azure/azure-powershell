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

using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Cdn.Models.Endpoint
{
    public class PSEndpoint : PSTrackedResource
    {
        private const string EndpointKeyPatternFormat =
            @"\/subscriptions\/(?<{0}>.*)\/resourcegroups\/(?<{1}>.*)\/providers\/Microsoft\.Cdn\/profiles\/(?<{2}>.*)\/endpoints\/(?<{3}>.*)";

        private const string SubscriptionIdGroupKey = "subscriptionId";
        private const string ResourceGroupGroupKey = "resourceGroup";
        private const string ProfileNameGroupKey = "profileName";
        private const string EndpointNameGroupKey = "endpointName";

        public string HostName { get; set; }

        public string OriginHostHeader { get; set; }

        public string OriginPath { get; set; }

        public string[] ContentTypesToCompress { get; set; }

        public bool IsCompressionEnabled { get; set; }

        public bool IsHttpAllowed { get; set; }

        public bool IsHttpsAllowed { get; set; }

        public PSQueryStringCachingBehavior QueryStringCachingBehavior { get; set; }

        public ICollection<PSDeepCreatedOrigin> Origins { get; set; }

        public PSEndpointResourceState ResourceState { get; set; }

        public string ResourceGroupName
        {
            get
            {
                var match = Regex.Match(Id,
                string.Format(EndpointKeyPatternFormat,
                    SubscriptionIdGroupKey,
                    ResourceGroupGroupKey,
                    ProfileNameGroupKey,
                    EndpointNameGroupKey), RegexOptions.IgnoreCase);

                return match.Groups[ResourceGroupGroupKey].Value;
            }
        }

        public string ProfileName
        {
            get
            {
                var match = Regex.Match(Id,
                string.Format(EndpointKeyPatternFormat,
                    SubscriptionIdGroupKey,
                    ResourceGroupGroupKey,
                    ProfileNameGroupKey,
                    EndpointNameGroupKey), RegexOptions.IgnoreCase);

                return match.Groups[ProfileNameGroupKey].Value;
            }
        }
    }
}
