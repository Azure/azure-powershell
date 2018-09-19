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
using Microsoft.Azure.Commands.AnalysisServices.Dataplane.Models;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;

namespace Microsoft.Azure.Commands.AnalysisServices.Dataplane
{
    /// <summary>
    /// Represents current AS Azure session.
    /// </summary>
    public class AsAzureClientSession
    {
        public const string RestartEndpointPathFormat = "/webapi/servers/{0}/restart?api-version=2016-10-01";
        public const string LogfileEndpointPathFormat = "/webapi/servers/{0}/logfileHere";
        public const string SynchronizeEndpointPathFormat = "/servers/{0}/models/{1}/sync";
        public const string AsAzureClientId = "cf710c6e-dfcc-4fa8-a093-d47294e44c66";
        public static readonly Uri RedirectUri = new Uri("urn:ietf:wg:oauth:2.0:oob");
        public static string DefaultRolloutEnvironmentKey = "asazure.windows.net";

        /// <summary>
        /// Gets or sets the token cache store.
        /// </summary>
        public static TokenCache TokenCache { get; set; }

        /// <summary>
        /// As Azure Profile
        /// </summary>
        private AsAzureProfile _profile;

        private IAsAzureAuthenticationProvider _asAzureAuthenticationProvider;

        static AsAzureClientSession()
        {
            Instance = new AsAzureClientSession();
        }

        private AsAzureClientSession()
        {
            TokenCache = new TokenCache();
            _profile = new AsAzureProfile();
            _asAzureAuthenticationProvider = new AsAzureAuthenticationProvider();
        }

        public void SetAsAzureAuthenticationProvider(IAsAzureAuthenticationProvider asAzureAuthenticationProvider)
        {
            _asAzureAuthenticationProvider = asAzureAuthenticationProvider;
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

#if NETSTANDARD
        public AsAzureProfile Login(AsAzureContext asAzureContext, SecureString password, Action<string> promptAction)
#else
        public AsAzureProfile Login(AsAzureContext asAzureContext, SecureString password)
#endif
        {
            var resourceUri = new UriBuilder(Uri.UriSchemeHttps, GetResourceUriSuffix(asAzureContext.Environment.Name)).ToString();
            resourceUri = resourceUri.TrimEnd('/');
#if NETSTANDARD
            _asAzureAuthenticationProvider.GetAadAuthenticatedToken(asAzureContext, password, promptAction, AsAzureClientId, resourceUri, RedirectUri);
#else
            _asAzureAuthenticationProvider.GetAadAuthenticatedToken(asAzureContext, password, password == null ? PromptBehavior.Always : PromptBehavior.Auto, AsAzureClientId, resourceUri, RedirectUri);
#endif

            _profile.Context.TokenCache = AsAzureClientSession.TokenCache.Serialize();

            if (!_profile.Environments.ContainsKey(asAzureContext.Environment.Name))
            {
                _profile.Environments.Add(asAzureContext.Environment.Name, asAzureContext.Environment);
            }

            return _profile;
        }

        public AsAzureProfile Login(AsAzureContext asAzureContext)
        {
            var resourceUri = new UriBuilder(Uri.UriSchemeHttps, GetResourceUriSuffix(asAzureContext.Environment.Name)).ToString();
            resourceUri = resourceUri.TrimEnd('/');
#if NETSTANDARD
            _asAzureAuthenticationProvider.GetAadAuthenticatedToken(asAzureContext, null, null, AsAzureClientId, resourceUri, RedirectUri);
#else
            _asAzureAuthenticationProvider.GetAadAuthenticatedToken(asAzureContext, null, PromptBehavior.RefreshSession, AsAzureClientId, resourceUri, RedirectUri);
#endif

            _profile.Context.TokenCache = AsAzureClientSession.TokenCache.Serialize();

            if (!_profile.Environments.ContainsKey(asAzureContext.Environment.Name))
            {
                _profile.Environments.Add(asAzureContext.Environment.Name, asAzureContext.Environment);
            }

            return _profile;
        }

        public static string GetAuthorityUrlForEnvironment(AsAzureEnvironment environment)
        {
            var profile = AzureRmProfileProvider.Instance.GetProfile<AzureRmProfile>();
            var availableEnvironments = profile.Environments;

            foreach (var env in availableEnvironments)
            {
                var endpointSuffix = env.GetEndpoint(AzureEnvironment.ExtendedEndpoint.AnalysisServicesEndpointSuffix);

                if (environment.Name.EndsWith(endpointSuffix))
                {
                    return env.ActiveDirectoryAuthority;
                }
            }

            throw new ArgumentException(Properties.Resources.UnknownEnvironment);
        }

        public void SetCurrentContext(AsAzureAccount azureAccount, AsAzureEnvironment asEnvironment)
        {
            _profile.Context = new AsAzureContext(azureAccount, asEnvironment)
            {
                TokenCache = AsAzureClientSession.TokenCache.Serialize()
            };
        }

        public static string GetDefaultEnvironmentName()
        {
            return "*." + AzureEnvironmentConstants.AzureAnalysisServicesEndpointSuffix;
        }

        public static string GetResourceUriSuffix(string environmentName)
        {
            if (string.IsNullOrEmpty(environmentName))
            {
                return GetDefaultEnvironmentName();
            }

            return environmentName;
        }
    }
}
