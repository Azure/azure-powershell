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
using System;

namespace Microsoft.Azure.PowerShell.Authenticators
{
    internal static class AuthenticationHelpers
    {
        internal const string PowerShellClientId = "1950a258-227b-4e31-a9cf-717495945fc2", 
            DefaultScope = "{0}/.default",
            AdfsScope = "{0}/openid";

        /// <summary>
        /// Get the scopes array for a given resource. If resource URI doesn't contain permission, .default should be appended for all app-level permissions.
        /// </summary>
        /// <param name="onPremise">determines which scope to use</param>
        /// <param name="resource">which resource will be requested</param>
        /// <returns></returns>
        internal static string[] GetScope(bool onPremise, string resource)
        {
            
            if(!string.IsNullOrEmpty(resource))
            {
                Uri uri = new Uri(resource);
                if(!string.IsNullOrWhiteSpace(uri.AbsolutePath) && !"/".Equals(uri.AbsolutePath))
                {
                    return new string[] { resource };
                }
            }
            var scopeTemplate = onPremise ? AdfsScope : DefaultScope;
            return new string[] { string.Format(scopeTemplate, resource) };
        }
    }
}
