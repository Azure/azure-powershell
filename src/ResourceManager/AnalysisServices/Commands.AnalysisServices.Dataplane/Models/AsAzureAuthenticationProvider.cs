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
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.WindowsAzure.Commands.Common.Properties;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
#if NETSTANDARD
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Rest.Azure.Authentication;
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
#if NETSTANDARD
        string GetAadAuthenticatedToken(AsAzureContext asAzureContext, SecureString password, Action<string> promptAction, string clientId, string resourceUri, Uri resourceRedirectUri);
#else
        string GetAadAuthenticatedToken(AsAzureContext asAzureContext, SecureString password, PromptBehavior promptBehavior, string clientId, string resourceUri, Uri resourceRedirectUri);
#endif
    }

    public class AsAzureAuthenticationProvider : IAsAzureAuthenticationProvider
    {
#if NETSTANDARD
        public string GetAadAuthenticatedToken(AsAzureContext asAzureContext, SecureString password, Action<string> promptAction, string clientId, string resourceUri, Uri resourceRedirectUri)
#else
        public string GetAadAuthenticatedToken(AsAzureContext asAzureContext, SecureString password, PromptBehavior promptBehavior, string clientId, string resourceUri, Uri resourceRedirectUri)
#endif
        {
            var authUriBuilder = new UriBuilder((string)asAzureContext.Environment.Endpoints[AsAzureEnvironment.AsRolloutEndpoints.AdAuthorityBaseUrl]);
            authUriBuilder.Path = string.IsNullOrEmpty(asAzureContext.Account.Tenant)
                ? "common"
                : asAzureContext.Account.Tenant;

            var authenticationContext = new AuthenticationContext(
                authUriBuilder.ToString(),
                AsAzureClientSession.TokenCache);

            AuthenticationResult result = null;
            string accountType = string.IsNullOrEmpty(asAzureContext.Account.Type) ? AsAzureAccount.AccountType.User : asAzureContext.Account.Type;

            if (password == null && accountType == AsAzureAccount.AccountType.User)
            {
                if (asAzureContext.Account.Id != null)
                {
#if NETSTANDARD
                    result = authenticationContext.AcquireTokenAsync(
                        resourceUri,
                        clientId,
                        resourceRedirectUri,
                        new PlatformParameters(),
                        new UserIdentifier(asAzureContext.Account.Id, UserIdentifierType.OptionalDisplayableId)).Result;
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
#if NETSTANDARD
                    result = authenticationContext.AcquireTokenAsync(
                        resourceUri,
                        clientId,
                        resourceRedirectUri,
                        new PlatformParameters()).Result;
#else
                    result = authenticationContext.AcquireToken(
                        resourceUri,
                        clientId,
                        resourceRedirectUri,
                        promptBehavior);
#endif
                }

                asAzureContext.Account.Id = result.UserInfo.DisplayableId;
                asAzureContext.Account.Tenant = result.TenantId;
                asAzureContext.Account.UniqueId = result.UserInfo.UniqueId;
            }
            else
            {
                if (accountType == AsAzureAccount.AccountType.User)
                {
#if NETSTANDARD
                    //https://stackoverflow.com/a/39393039/294804
                    //https://github.com/AzureAD/azure-activedirectory-library-for-dotnet/issues/482
                    //https://github.com/Azure-Samples/active-directory-dotnet-deviceprofile/blob/5d5499d09c918ae837810d457822474df97600e9/DirSearcherClient/Program.cs#L206-L210
                    // Note: More robust implementation in UserTokenProvider.Netcore.cs in DoAcquireToken
                    DeviceCodeResult codeResult = authenticationContext.AcquireDeviceCodeAsync(resourceUri, clientId).Result;
                    promptAction(codeResult?.Message);
                    result = authenticationContext.AcquireTokenByDeviceCodeAsync(codeResult).Result;
#else
                    UserCredential userCredential = new UserCredential(asAzureContext.Account.Id, password);
                    result = authenticationContext.AcquireToken(resourceUri, clientId, userCredential);
#endif

                    asAzureContext.Account.Id = result.UserInfo.DisplayableId;
                    asAzureContext.Account.Tenant = result.TenantId;
                    asAzureContext.Account.UniqueId = result.UserInfo.UniqueId;
                }
                else if (accountType == AsAzureAccount.AccountType.ServicePrincipal)
                {
                    if (string.IsNullOrEmpty(asAzureContext.Account.CertificateThumbprint))
                    {
#if NETSTANDARD
                        ClientCredential credential = new ClientCredential(asAzureContext.Account.Id, ConversionUtilities.SecureStringToString(password));
                        result = authenticationContext.AcquireTokenAsync(resourceUri, credential).Result;
#else
                        ClientCredential credential = new ClientCredential(asAzureContext.Account.Id, password);
                        result = authenticationContext.AcquireToken(resourceUri, credential);
#endif
                    }
                    else
                    {
                        DiskDataStore dataStore = new DiskDataStore();
                        var certificate = dataStore.GetCertificate(asAzureContext.Account.CertificateThumbprint);
                        if (certificate == null)
                        {
                            throw new ArgumentException(string.Format(Resources.CertificateNotFoundInStore, asAzureContext.Account.CertificateThumbprint));
                        }
#if NETSTANDARD
                        result = authenticationContext.AcquireTokenAsync(resourceUri, new ClientAssertionCertificate(asAzureContext.Account.Id, certificate)).Result;
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
