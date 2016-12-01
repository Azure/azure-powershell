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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Microsoft.Azure.Commands.AnalysisServices.Dataplane.Models
{
    public interface IAsAzureAuthenticationProvider
    {
        string GetAadAuthenticatedToken(AsAzureContext asAzureContext, SecureString password, PromptBehavior promptBehavior, string clientId, string resourceUri, Uri resourceRedirectUri);
    }

    public class AsAzureAuthenticationProvider : IAsAzureAuthenticationProvider
    {
        public string GetAadAuthenticatedToken(AsAzureContext asAzureContext, SecureString password, PromptBehavior promptBehavior, string clientId, string resourceUri, Uri resourceRedirectUri)
        {
            var authUriBuilder = new UriBuilder((string)asAzureContext.Environment.Endpoints[AsAzureEnvironment.AsRolloutEndpoints.AdAuthorityBaseUrl]);
            authUriBuilder.Path = string.IsNullOrEmpty(asAzureContext.Account.Tenant)
                ? "common"
                : asAzureContext.Account.Tenant;

            var authenticationContext = new AuthenticationContext(
                authUriBuilder.ToString(),
                AsAzureClientSession.TokenCache);

            AuthenticationResult result = null;
            if (password == null)
            {
                if (asAzureContext.Account.Id != null)
                {
                    result = authenticationContext.AcquireToken(
                        resourceUri,
                        clientId,
                        resourceRedirectUri,
                        promptBehavior,
                        new UserIdentifier(asAzureContext.Account.Id, UserIdentifierType.OptionalDisplayableId));
                }
                else
                {
                    result = authenticationContext.AcquireToken(
                        resourceUri,
                        clientId,
                        resourceRedirectUri,
                        promptBehavior);
                }
            }
            else
            {
                UserCredential userCredential = new UserCredential(asAzureContext.Account.Id, password);
                result = authenticationContext.AcquireToken(resourceUri, clientId, userCredential);
            }

            asAzureContext.Account.Id = result.UserInfo.DisplayableId;
            asAzureContext.Account.Tenant = result.TenantId;

            return result.AccessToken;
        }
    }
}
