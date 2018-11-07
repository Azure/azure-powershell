//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Network
{
    internal static class AzureFirewallFqdnTagHelper
    {
        public static List<string> MapUserInputToAllowedFqdnTags(IEnumerable<string> userFqdnTags, IAzureFirewallFqdnTagsOperations azureFirewallFqdnTagClient)
        {
            if (userFqdnTags == null)
            {
                throw new ArgumentNullException("FQDN Tags List to be validated is null.", nameof(userFqdnTags));
            }

            var allowedFqdnTags = GetAzureFirewallAllowedFqdnTags(azureFirewallFqdnTagClient);

            // Accept user input case insensistive
            var userAcceptedFqdnTags = allowedFqdnTags.Aggregate(
                new Dictionary<string, string>(),
                (userAcceptedVersions, allowedFqdnTag) =>
                {
                    userAcceptedVersions.Add(allowedFqdnTag.FqdnTagName.ToUpper(), allowedFqdnTag.FqdnTagName);

                    return userAcceptedVersions;
                });

            return userFqdnTags.Select(userFqdnTag =>
            {
                var userKey = userFqdnTag.ToUpper();

                if (!userAcceptedFqdnTags.ContainsKey(userKey))
                {
                    throw new ArgumentException($"FQDN Tag {userFqdnTag} is invalid. Valid values are [{string.Join(", ", allowedFqdnTags.Select(tag => tag.FqdnTagName))}]");
                }

                return userAcceptedFqdnTags[userKey];
            }).ToList();
        }

        internal static IEnumerable<PSAzureFirewallFqdnTag> GetAzureFirewallAllowedFqdnTags(IAzureFirewallFqdnTagsOperations azureFirewallFqdnTagClient)
        {

            IPage<AzureFirewallFqdnTag> azureFirewallFqdnTagPage = azureFirewallFqdnTagClient.ListAll();

            // Get all resources by polling on next page link
            var azureFirewallFqdnTagResponseLIst = ListNextLink<AzureFirewallFqdnTag>.GetAllResourcesByPollingNextLink(azureFirewallFqdnTagPage, azureFirewallFqdnTagClient.ListAllNext);

            var psAzureFirewallFqdnTags = azureFirewallFqdnTagResponseLIst.Select(fqdnTag =>
            {
                var psFqdnTag = ToPsAzureFirewallFqdnTag(fqdnTag);
                psFqdnTag.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(fqdnTag.Id);
                return psFqdnTag;
            }).ToList();

            return psAzureFirewallFqdnTags;
        }

        private static PSAzureFirewallFqdnTag ToPsAzureFirewallFqdnTag(AzureFirewallFqdnTag fqdnTag)
        {
            var psAzFwFqdnTag = NetworkResourceManagerProfile.Mapper.Map<PSAzureFirewallFqdnTag>(fqdnTag);

            psAzFwFqdnTag.Tag = TagsConversionHelper.CreateTagHashtable(fqdnTag.Tags);

            return psAzFwFqdnTag;
        }
    }
}
