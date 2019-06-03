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

using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Cdn.Models.Profile
{
    /// <summary>
    /// Represents the properties of an Azure Cdn Profile.
    /// </summary>
    public class PSProfile : PSTrackedResource
    {
        private const string ProfileKeyPatternFormat =
            @"\/subscriptions\/(?<{0}>.*)\/resourcegroups\/(?<{1}>.*)\/providers\/Microsoft\.Cdn\/profiles\/(?<{2}>.*)";
        private const string SubscriptionIdGroupKey = "subscriptionId";
        private const string ResourceGroupGroupKey = "resourceGroup";
        private const string ProfileNameGroupKey = "profileName";

        /// <summary>
        /// Gets or sets the profile sku.
        /// </summary>
        public PSSku Sku { get; set; }

        /// <summary>
        /// Gets or sets the profile state.
        /// </summary>
        public PSProfileResourceState ResourceState { get; set; }

        /// <summary>
        /// Gets the resource group from resource id.
        /// </summary>
        public string ResourceGroupName
        {
            get
            {
                var match = Regex.Match(Id,
                string.Format(ProfileKeyPatternFormat,
                    SubscriptionIdGroupKey,
                    ResourceGroupGroupKey,
                    ProfileNameGroupKey), RegexOptions.IgnoreCase);
                return match.Groups[ResourceGroupGroupKey].Value;
            }
        }
    }
}
