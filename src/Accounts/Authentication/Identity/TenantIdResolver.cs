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
//
using Azure.Core;
using Azure.Identity;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.PowerShell.Authenticators.Identity
{
    internal static class TenantIdResolver
    {
        public static readonly string[] AllTenants = new string[] { "*" };

        /// <summary>
        /// Resolves the tenantId based on the supplied configuration values.
        /// </summary>
        /// <param name="explicitTenantId">The tenantId passed to the ctor of the Credential.</param>
        /// <param name="context">The <see cref="TokenRequestContext"/>.</param>
        /// <param name="additionallyAllowedTenantIds">Additional tenants the credential is configured to acquire tokens for.</param>
        /// <returns>The tenantId to be used for authorization.</returns>
        public static string Resolve(string explicitTenantId, TokenRequestContext context, string[] additionallyAllowedTenantIds)
        {
            bool disableMultiTenantAuth = IdentityCompatSwitches.DisableTenantDiscovery;

            if (context.TenantId != explicitTenantId && context.TenantId != null && explicitTenantId != null)
            {
                if (disableMultiTenantAuth || explicitTenantId == Constants.AdfsTenantId)
                {
                    AzureIdentityEventSource.Singleton.TenantIdDiscoveredAndNotUsed(explicitTenantId, context.TenantId);
                }
                else
                {
                    AzureIdentityEventSource.Singleton.TenantIdDiscoveredAndUsed(explicitTenantId, context.TenantId);
                }
            }

            string resolvedTenantId = string.Empty;
            if (disableMultiTenantAuth || explicitTenantId == Constants.AdfsTenantId)
            {
                resolvedTenantId = explicitTenantId;
            }
            else
            {
                resolvedTenantId = context.TenantId ?? explicitTenantId;
            }

            if (explicitTenantId != null && resolvedTenantId != explicitTenantId && additionallyAllowedTenantIds != AllTenants && Array.BinarySearch(additionallyAllowedTenantIds, resolvedTenantId, StringComparer.OrdinalIgnoreCase) < 0)
            {
                throw new AuthenticationFailedException($"The current credential is not configured to acquire tokens for tenant {resolvedTenantId}. To enable acquiring tokens for this tenant add it to the AdditionallyAllowedTenants on the credential options, or add \"*\" to AdditionallyAllowedTenants to allow acquiring tokens for any tenant. See the troubleshooting guide for more information. https://aka.ms/azsdk/net/identity/multitenant/troubleshoot");
            }

            return resolvedTenantId;
        }

        public static string[] ResolveAddionallyAllowedTenantIds(IList<string> additionallyAllowedTenants)
        {
            if (additionallyAllowedTenants == null || additionallyAllowedTenants.Count == 0)
            {
                return Array.Empty<string>();
            }

            if (additionallyAllowedTenants.Contains("*"))
            {
                return AllTenants;
            }

            return additionallyAllowedTenants.OrderBy(s => s).ToArray();
        }
    }
}
