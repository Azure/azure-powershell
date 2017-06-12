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

namespace Microsoft.Azure.Commands.TrafficManager.Utilities
{
    using System;
    using System.Text.RegularExpressions;

    public class TrafficManagerProfileResourceId : ResourceId
    {
        public const string TrafficManagerProfileCaptureName = "profileName";

        public static readonly Regex TrafficManagerProfileResourceIdRegex = new Regex(
            string.Format(
                "{0}/Microsoft.Network/trafficManagerProfiles/(?'{1}'[^/]+)$",
                ResourceId.ArmResourceIdPatternPrefix,
                TrafficManagerProfileResourceId.TrafficManagerProfileCaptureName),
            RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase,
            TimeSpan.FromSeconds(ResourceId.RegexMatchTimeoutInSeconds));

        public TrafficManagerProfileResourceId(string resourceId)
        {
            if (!TrafficManagerProfileResourceId.TrafficManagerProfileResourceIdRegex.IsMatch(resourceId))
            {
                throw new ArgumentException(string.Format("Invalid or Unexpected Resource ID format: {0}", resourceId));
            }

            this.SubscriptionId = TrafficManagerProfileResourceId.TrafficManagerProfileResourceIdRegex.Match(resourceId).Groups[ResourceId.SubscriptionIdCaptureName].Value;
            this.ResourceGroup = TrafficManagerProfileResourceId.TrafficManagerProfileResourceIdRegex.Match(resourceId).Groups[ResourceId.ResourceGroupCaptureName].Value;
            this.ProfileName = TrafficManagerProfileResourceId.TrafficManagerProfileResourceIdRegex.Match(resourceId).Groups[TrafficManagerProfileResourceId.TrafficManagerProfileCaptureName].Value;
        }

        public string SubscriptionId { get; private set; }

        public string ResourceGroup { get; private set; }

        public string ProfileName { get; private set; }
    }
}