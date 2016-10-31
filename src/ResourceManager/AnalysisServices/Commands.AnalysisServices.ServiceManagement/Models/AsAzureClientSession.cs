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

using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Security;

namespace Microsoft.Azure.Commands.AnalysisServices.ServiceManagement
{
    /// <summary>
    /// Represents current AS Azure session.
    /// </summary>
    public class AsAzureClientSession
    {
        public const string RestartEndpointPathFormat = "/webapi/servers/{0}/restart?api-version=2016-10-01";
        public const string AadAuthorityUrlProd = "https://login.windows.net";
        public const string AadAuthorityUrlPpe = "https://login.windows-ppe.net";
        public const string AsAzureClientId = "cf710c6e-dfcc-4fa8-a093-d47294e44c66";
        public static readonly Uri RedirectUri = new Uri("urn:ietf:wg:oauth:2.0:oob");

        /// <summary>
        /// Gets or sets the token cache store.
        /// </summary>
        public static TokenCache TokenCache { get; set; }
        
        /// <summary>
        /// As Azure Profile
        /// </summary>
        private AsAzureProfile _profile;

        static AsAzureClientSession()
        {
            Instance = new AsAzureClientSession();
        }

        private AsAzureClientSession()
        {
            TokenCache = new TokenCache();
            _profile = new AsAzureProfile();
        }

        public static AsAzureClientSession Instance { get; private set; }

        public AsAzureProfile Profile
        {
            get { return _profile; }
            set
            {
                _profile = value;
            }
        }
        
        public AsAzureProfile Login(AsAzureContext asAzureContext, SecureString password)
        {
            PromptBehavior promptBehavior = password == null ? PromptBehavior.Always : PromptBehavior.Auto;

            var resourceUri = new UriBuilder(Uri.UriSchemeHttps, asAzureContext.Environment.Name).ToString();
            GetAadAuthenticatedToken(asAzureContext, password, promptBehavior, AsAzureClientId, resourceUri, RedirectUri);

            _profile.Context.TokenCache = AsAzureClientSession.TokenCache.Serialize();

            if (!_profile.Environments.ContainsKey(asAzureContext.Environment.Name))
            {
                _profile.Environments.Add(asAzureContext.Environment.Name, asAzureContext.Environment);
            }

            return _profile;
        }

        /// <summary>
        /// Function to get an AAD token for a given user, client id and resource
        /// </summary>
        public static string GetAadAuthenticatedToken(AsAzureContext asAzureContext, SecureString password, PromptBehavior promptBehavior, string clientId, string resourceUri, Uri resourceRedirectUri)
        {
            var authUriBuilder = new UriBuilder(asAzureContext.Environment.Endpoints[AsAzureEnvironment.AsRolloutEndpoints.AdAuthorityBaseUrl]);
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

        public static string GetAuthorityUrlForEnvironment(AsAzureEnvironment environment)
        {
            return environment.Name.Contains("asazure-int") ? AadAuthorityUrlPpe : AadAuthorityUrlProd;
        }

        public void SetCurrentContext(AsAzureAccount azureAccount, AsAzureEnvironment asEnvironment)
        {
            _profile.Context = new AsAzureContext(azureAccount, asEnvironment)
            {
                TokenCache = AsAzureClientSession.TokenCache.Serialize()
            };
        }
    }
}
