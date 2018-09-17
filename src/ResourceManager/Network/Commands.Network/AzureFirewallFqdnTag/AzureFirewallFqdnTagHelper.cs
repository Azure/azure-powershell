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

namespace Microsoft.Azure.Commands.Network
{
    internal static class AzureFirewallFqdnTagHelper
    {
        private static IEnumerable<string> GetAzureFirewallAllowedFqdnTags()
        {
            return new List<string>
            {
                "WindowsUpdate",
                "WindowsDiagnostics",
                "AppServiceEnvironment",
                "MicrosoftActiveProtectionService",
                "AzureBackup"
            };
        }

        public static List<string> MapUserInputToAllowedFqdnTags(IEnumerable<string> userFqdnTags)
        {
            if (userFqdnTags == null)
            {
                throw new ArgumentNullException("FQDN Tags List to be validated is null.", nameof(userFqdnTags));
            }

            var allowedFqdnTags = GetAzureFirewallAllowedFqdnTags();

            // Accept user input case insensistive
            var userAcceptedFqdnTags = allowedFqdnTags.Aggregate(
                new Dictionary<string, string>(),
                (userAcceptedVersions, allowedFqdnTag) =>
                {
                    userAcceptedVersions.Add(allowedFqdnTag.ToUpper(), allowedFqdnTag);

                    return userAcceptedVersions;
                });

            return userFqdnTags.Select(userFqdnTag =>
            {
                var userKey = userFqdnTag.ToUpper();

                if (!userAcceptedFqdnTags.ContainsKey(userKey))
                {
                    throw new ArgumentException($"FQDN Tag {userFqdnTag} is invalid. Valid values are {string.Join(", ", allowedFqdnTags)}");
                }

                return userAcceptedFqdnTags[userKey];
            }).ToList();
        }
    }
}
