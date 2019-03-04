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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Identity.Client;

namespace Microsoft.Azure.PowerShell.Authenticators
{
    internal static class AuthenticationHelpers
    {
        internal const string PowerShellClientId = "04b07795-8ddb-461a-bbee-02f9e1bf7b46",
            PowerShellRedirectUri = "urn:ietf:wg:oauth:2.0:oob",
            EnableEbdMagicCookie = "site_id=501358&display=popup",
            UserImpersonationScope = "{0}/user_impersonation",
            DefaultScope = "{0}/.default";

        /// <summary>
        /// Get the authority string given a tenant and environment
        /// </summary>
        /// <param name="environment">The Azure environment</param>
        /// <param name="tenant">The tenant Id</param>
        /// <returns>The authrotity string, from the AAD endpoint and tenant ID</returns>
        internal static string GetAuthority(IAzureEnvironment environment, string tenant)
        {
            var tenantString = tenant ?? environment?.AdTenant ?? "Common";
            return $"{environment.ActiveDirectoryAuthority}{tenant}";
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="showDialog"></param>
        /// <returns></returns>
        internal static Prompt GetPromptBehavior(string showDialog)
        {
            switch (showDialog)
            {
                case ShowDialog.Always:
                    return Prompt.ForceLogin;
                case ShowDialog.Never:
                    return Prompt.NoPrompt;
                default:
                    return Prompt.SelectAccount;
            }
        }

    }
}
