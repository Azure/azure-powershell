// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Cdn.AfdModels.Arm;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Cdn.AfdHelpers
{
    public class AfdResourceUtilities
    {
        private const string SubscriptionId = "subscriptionId";
        private const string ResourceGroup = "resourceGroup";
        private const string Profile = "profile";

        public static string AfdProfilePattern = @"\/subscriptions\/(?<{0}>.*)\/resourcegroups\/(?<{1}>.*)\/providers\/Microsoft\.Cdn\/profiles\/(?<{2}>.*)";

        public static string GetResourceGroupFromAfdProfile(PSArmResource afdProfile)
        {
            string formattedSting = string.Format(AfdProfilePattern, SubscriptionId, ResourceGroup, Profile);

            Match match = Regex.Match(afdProfile.Id, formattedSting, RegexOptions.IgnoreCase);

            return match.Groups[ResourceGroup].Value;
        }
    }
}
