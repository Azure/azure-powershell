﻿//
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

namespace Microsoft.Azure.Commands.Intune
{
    using Microsoft.Azure.Management.Intune.Models;
    using Microsoft.Azure.Management.Intune;
    using System.Globalization;

    /// <summary>
    /// Types of Links to Intune Policies
    /// </summary>
    public enum LinkType
    {
        App,
        Group
    }

    /// <summary>
    /// Prepares payload for link requests of type:group/app for an Intune policy.
    /// </summary>
    public class AppOrGroupPayloadMaker
    {
        public static string AppUriFormat = "https://{0}/providers/Microsoft.Intune/locations/{1}/apps/{2}";
        public static string GroupUriFormat = "https://{0}/providers/Microsoft.Intune/locations/{1}/groups/{2}";

        public static MAMPolicyAppIdOrGroupIdPayload PrepareMAMPolicyPayload(IIntuneResourceManagementClient client, LinkType type, string asuHostName, string name)
        {
            string uriFormat = type == LinkType.App ? AppUriFormat : GroupUriFormat;            
            string uri = string.Format(CultureInfo.InvariantCulture, uriFormat, client.BaseUri.Host, asuHostName, name);
            var payload = new MAMPolicyAppIdOrGroupIdPayload();

            payload.Properties = new MAMPolicyAppOrGroupIdProperties()
            {
                Url = uri
            };

            return payload;
        }
    }
}
