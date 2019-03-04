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
using System;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.MixedReality.SpatialAnchorsAccount
{
    internal class ResourceId
    {
        static class RegEx
        {
            internal const string Subscription = "subscription";
            internal const string ResourceGroup = "resourceGroup";
            internal const string SpatialAnchorsAccount = "spatialAnchorAccount";
            internal readonly static Regex Id = new Regex($@"\/subscriptions\/(?<{Subscription}>.*)\/resourcegroups\/(?<{ResourceGroup}>.*)\/providers\/Microsoft\.MixedReality\/SpatialAnchorsAccounts\/(?<{SpatialAnchorsAccount}>.*)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
        }

        internal ResourceId(string resourceId)
        {
            var match = RegEx.Id.Match(resourceId);

            if (match.Success)
            {
                SubsciptionId = new Guid(match.Groups[RegEx.Subscription].Value);
                ResourceGroupName = match.Groups[RegEx.ResourceGroup].Value;
                SpatialAnchorsAccountName = match.Groups[RegEx.SpatialAnchorsAccount].Value;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        internal Guid SubsciptionId { get; private set; }
        internal string ResourceGroupName { get; private set; }
        internal string SpatialAnchorsAccountName { get; private set; }
    }
}
