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
using System.Linq;
using System;
using Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20150501;

namespace Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models
{
    internal class ApiKeyRole
    {
        public string[] readProperties;
        public string[] writeProperties;
        public string roleName;
        public string displayName;
    }

    public class PSApiKey
    {
        private static readonly Regex AccessIdRegex = new Regex(@"^/subscriptions/(?<SubscriptionId>[^/]+)/resourceGroups/(?<ResourceGroup>[^/]+)/providers/microsoft.insights/components/(?<ResourceName>[^/]+)/(?<Permission>[^/]+).*$", RegexOptions.IgnoreCase);

        internal static ApiKeyRole ReadTelemetry = new ApiKeyRole()
        {
            roleName = "ReadTelemetry",
            displayName = "Read Telemetry",
            readProperties = new string[] { "api" },
        };

        internal static ApiKeyRole WriteAnnotations = new ApiKeyRole()
        {
            roleName = "WriteAnnotations",
            displayName = "Write Annotations",
            writeProperties = new string[] { "annotations" },
        };

        internal static ApiKeyRole ReadAgentConfiguration = new ApiKeyRole()
        {
            roleName = "AuthenticateSDKControlChannel",
            displayName = "Authenticate SDK control channel",
            readProperties = new string[] { "agentconfig" },
        };

        public string ApiKey { get; }

        public string CreatedDate { get; set; }

        public string Id { get; }

        public string[] Permissions { get; }

        public string Description { get; set; }

        public PSApiKey(ApplicationInsightsComponentApiKey key)
        {
            this.ApiKey = key.ApiKey;
            this.CreatedDate = key.CreatedDate;
            this.Id = key.Id.Split('/')[10];
            this.Description = key.Name;

            List<string> accessPermission = new List<string>();

            ApiKeyRole[] roles = new ApiKeyRole[] {
                ReadTelemetry,
                WriteAnnotations,
                ReadAgentConfiguration
            };

            if (key.LinkedReadProperty != null)
            {
                foreach (var readaccess in key.LinkedReadProperty)
                {
                    var role = ExtraRole(roles, readaccess);
                    if (role != null)
                    {
                        accessPermission.Add(role.roleName);
                    }
                }
            }

            if (key.LinkedWriteProperty != null)
            {
                foreach (var writeAccess in key.LinkedWriteProperty)
                {
                    var role = ExtraRole(roles, writeAccess);
                    if (role != null)
                    {
                        accessPermission.Add(role.roleName);
                    }
                }
            }

            this.Permissions = accessPermission.ToArray();
        }

        private static ApiKeyRole ExtraRole(ApiKeyRole[] roles, string readaccess)
        {
            var matches = AccessIdRegex.Match(readaccess);
            if (matches.Success)
            {
                string permission = matches.Groups["Permission"].Value;

                return roles.FirstOrDefault(r =>
                    (r.readProperties != null && r.readProperties.Any(p => StringComparer.OrdinalIgnoreCase.Equals(p, permission))) ||
                    (r.writeProperties != null && r.writeProperties.Any(p => StringComparer.OrdinalIgnoreCase.Equals(p, permission)))
                    );
            }

            return null;
        }

        internal static Tuple<string[], string[]> BuildApiKeyAccess(string subscriptionId, string resourceGroup, string componentName, string[] permissions)
        {
            ApiKeyRole[] roles = new ApiKeyRole[] {
                ReadTelemetry,
                WriteAnnotations,
                ReadAgentConfiguration
            };

            List<string> readAccess = new List<string>();
            List<string> writeAccess = new List<string>();

            foreach (var permission in permissions)
            {
                var role = roles.FirstOrDefault(r => StringComparer.OrdinalIgnoreCase.Equals(r.roleName, permission));
                if (role != null)
                {
                    if (role.readProperties != null)
                    {
                        foreach (var readProperty in role.readProperties)
                        {
                            readAccess.Add($"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/microsoft.insights/components/{componentName}/{readProperty}");
                        }
                    }

                    if (role.writeProperties != null)
                    {
                        foreach (var writeProperty in role.writeProperties)
                        {
                            writeAccess.Add($"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/microsoft.insights/components/{componentName}/{writeProperty}");
                        }
                    }
                }
            }

            return Tuple.Create(readAccess.ToArray(), writeAccess.ToArray());
        }
    }

    public class PSApiKeyTableView : PSApiKey
    {
        public PSApiKeyTableView(ApplicationInsightsComponentApiKey key) 
            : base(key)
        { }
    }
}
