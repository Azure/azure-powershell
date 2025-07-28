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

using Azure.Identity;
using Microsoft.Azure.Commands.Shared.Config;
using Microsoft.Azure.PowerShell.Common.Config;
using System;

namespace Microsoft.Azure.Commands.Common.Authentication.Utilities
{
    public static class BrokerUtilities
    {
        /// <summary>
        /// Returns true if WAM (Windows Authentication Manager) is enabled for the given authority.
        /// </summary>
        /// <param name="authority">Authority for authentication (AAD)</param>
        /// <param name="configOnly">Ignore other conditions and check config only.</param>
        /// <returns></returns>
        public static bool IsWamEnabled(string authority, bool configOnly = false)
        {
            return AzureSession.Instance.TryGetComponent<IConfigManager>(nameof(IConfigManager), out var config)
                && config.GetConfigValue<bool>(ConfigKeys.EnableLoginByWam)
                && (configOnly || IsPublicCloud(authority));
        }

        /// <summary>
        /// Broker is now enabled by default only for public cloud.
        /// </summary>
        /// <param name="authority"></param>
        /// <returns></returns>
        private static bool IsPublicCloud(string authority)
        {

            return !string.IsNullOrEmpty(authority)
                && $"{authority}/".StartsWith(AzureAuthorityHosts.AzurePublicCloud.OriginalString, StringComparison.OrdinalIgnoreCase);
        }
    }
}
