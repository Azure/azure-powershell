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
using System.Runtime.Serialization;
using System.Security;
using Microsoft.Identity.Client;
using Microsoft.WindowsAzure.Commands.Common.Properties;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
// TODO: Remove IfDef
#if NETSTANDARD
using Microsoft.WindowsAzure.Commands.Common;
#endif

namespace Microsoft.Azure.Commands.AnalysisServices.Dataplane.Models
{
    [DataContract]
    public class AsAzureAuthInfo
    {
        [DataMember]
        public string DefaultResourceUriSuffix { get; set; }

        [DataMember]
        public string AuthorityUrl { get; set; }
    }

    public interface IAsAzureAuthenticationProvider
    {
// TODO: Remove IfDef
#if NETSTANDARD
        string GetAadAuthenticatedToken(AsAzureContext asAzureContext, SecureString password, Action<string> promptAction, string clientId, string resourceUri, Uri resourceRedirectUri);
#else
        string GetAadAuthenticatedToken(AsAzureContext asAzureContext, SecureString password, PromptBehavior promptBehavior, string clientId, string resourceUri, Uri resourceRedirectUri);
#endif
    }

    public class AsAzureAuthenticationProvider : IAsAzureAuthenticationProvider
    {
// TODO: Remove IfDef
#if NETSTANDARD
        public string GetAadAuthenticatedToken(AsAzureContext asAzureContext, SecureString password, Action<string> promptAction, string clientId, string resourceUri, Uri resourceRedirectUri)
#else
        public string GetAadAuthenticatedToken(AsAzureContext asAzureContext, SecureString password, PromptBehavior promptBehavior, string clientId, string resourceUri, Uri resourceRedirectUri)
#endif
        {
            var authUriBuilder = new UriBuilder((string)asAzureContext.Environment.Endpoints[AsAzureEnvironment.AsRolloutEndpoints.AdAuthorityBaseUrl])
            {
                Path = string.IsNullOrEmpty(asAzureContext.Account.Tenant)
                    ? "common"
                    : asAzureContext.Account.Tenant
            };

            AuthenticationResult result = null;
            var accountType = string.IsNullOrEmpty(asAzureContext.Account.Type) ? AsAzureAccount.AccountType.User : asAzureContext.Account.Type;

            if (password == null && accountType == AsAzureAccount.AccountType.User)
            {
                if (asAzureContext.Account.Id != null)
                {
// TODO: Remove IfDef
#if NETSTANDARD

#else
                    result = authenticationContext.AcquireToken(
                        resourceUri,
                        clientId,
                        resourceRedirectUri,
                        promptBehavior,
                        new UserIdentifier(asAzureContext.Account.Id, UserIdentifierType.OptionalDisplayableId));
#endif
                }
                else
                {
// TODO: Remove IfDef
#if NETSTANDARD

#else
                    result = authenticationContext.AcquireToken(
                        resourceUri,
                        clientId,
                        resourceRedirectUri,
                        promptBehavior);
#endif
                }

                asAzureContext.Account.Id = result.Account.Username;
                asAzureContext.Account.Tenant = result.TenantId;
                asAzureContext.Account.UniqueId = result.UniqueId;
            }
            else
            {
                if (accountType == AsAzureAccount.AccountType.User)
                {
// TODO: Remove IfDef
#if NETSTANDARD

#else
                    UserCredential userCredential = new UserCredential(asAzureContext.Account.Id, password);
                    result = authenticationContext.AcquireToken(resourceUri, clientId, userCredential);
#endif

                    asAzureContext.Account.Id = result.Account.Username;
                    asAzureContext.Account.Tenant = result.TenantId;
                    asAzureContext.Account.UniqueId = result.UniqueId;
                }
                else if (accountType == AsAzureAccount.AccountType.ServicePrincipal)
                {
                    if (string.IsNullOrEmpty(asAzureContext.Account.CertificateThumbprint))
                    {
// TODO: Remove IfDef
#if NETSTANDARD

#else
                        ClientCredential credential = new ClientCredential(asAzureContext.Account.Id, password);
                        result = authenticationContext.AcquireToken(resourceUri, credential);
#endif
                    }
                    else
                    {
                        var dataStore = new DiskDataStore();
                        var certificate = dataStore.GetCertificate(asAzureContext.Account.CertificateThumbprint);
                        if (certificate == null)
                        {
                            throw new ArgumentException(string.Format(Resources.CertificateNotFoundInStore, asAzureContext.Account.CertificateThumbprint));
                        }
// TODO: Remove IfDef
#if NETSTANDARD

#else
                        result = authenticationContext.AcquireToken(resourceUri, new ClientAssertionCertificate(asAzureContext.Account.Id, certificate));
#endif
                    }
                }
            }

            return result?.AccessToken;
        }
    }
}
