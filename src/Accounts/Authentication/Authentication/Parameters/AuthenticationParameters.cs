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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.Shared.Config;
using Microsoft.Azure.PowerShell.Common.Config;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    public abstract class AuthenticationParameters
    {
        public PowerShellTokenCacheProvider TokenCacheProvider { get; set; }

        public IAzureEnvironment Environment { get; set; }

        public IAzureTokenCache TokenCache { get; set; }

        public string TenantId { get; set; }

        public string ResourceId { get; set; }

        public bool? DisableInstanceDiscovery { get; set; } = null;

        public AuthenticationParameters(
            PowerShellTokenCacheProvider tokenCacheProvider,
            IAzureEnvironment environment,
            IAzureTokenCache tokenCache,
            string tenantId,
            string resourceId,
            bool? sendCertificateChain = null)
        {
            TokenCacheProvider = tokenCacheProvider;
            Environment = environment;
            TokenCache = tokenCache;
            TenantId = tenantId;
            ResourceId = resourceId;
            try
            {
                if (AzureSession.Instance.TryGetComponent<IConfigManager>(nameof(IConfigManager), out var config))
                {
                    DisableInstanceDiscovery = config.GetConfigValue<bool>(ConfigKeys.DisableInstanceDiscovery);
                }
            }
            catch(AzPSArgumentException)
            {
                DisableInstanceDiscovery = null;
            }
        }
    }
}
