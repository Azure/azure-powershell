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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Shared.Config;
using Microsoft.Azure.PowerShell.Common.Config;

using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Authentication.Utilities
{
    static public class AzConfigReader
    {

        private static IAzureSession Session
        {
            get
            {
                return AzureSession.Instance;
            }
        }

        private static bool fallbackForced = false;

        public static bool FallbackForced
        {
            get
            {
                return fallbackForced;
            }
            set
            {
                fallbackForced = value;
            }
        }

        static public bool IsWamEnabled(string authority)
        {
            if (!fallbackForced && !string.IsNullOrEmpty(authority) && Session.TryGetComponent<IConfigManager>(nameof(IConfigManager), out var config))
            {
                try
                {
                    if (!authority.EndsWith("/"))
                    {
                        authority = authority + "/";
                    }
                    return config.GetConfigValue<bool>(ConfigKeys.EnableLoginByWam) && 0 == string.Compare(authority, AzureAuthorityHosts.AzurePublicCloud.OriginalString, System.StringComparison.OrdinalIgnoreCase);
                }
                catch
                {

                }
            }
            return false;
        }
    }
}
