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
using System.Collections.Generic;
using System.Linq;
using System.Security;
using Microsoft.Azure.Commands.AnalysisServices.Dataplane.Models;
using Enumerable = System.Linq.Enumerable;

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

        public static Dictionary<string, AsAzureAuthInfo> AsAzureRolloutEnvironmentMapping = new Dictionary<string, AsAzureAuthInfo>()
            {
             { "asazure.windows.net", new AsAzureAuthInfo()
                {
                 AuthorityUrl = "https://login.windows.net" ,
                 DefaultResourceUriSuffix = "*.asazure.windows.net"
                }
             },
             { "asazure-int.windows.net", new AsAzureAuthInfo()
                {
                    AuthorityUrl = "https://login.windows-ppe.net" ,
                    DefaultResourceUriSuffix = "*.asazure-int.windows.net"
                }
             }
            };

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

        public AsAzureProfile Login(AsAzureContext asAzureContext, SecureString password)
        {
            PromptBehavior promptBehavior = password == null ? PromptBehavior.Always : PromptBehavior.Auto;

            var resourceUri = new UriBuilder(Uri.UriSchemeHttps, GetResourceUriSuffix(asAzureContext.Environment.Name)).ToString();
            resourceUri = resourceUri.TrimEnd('/');
            _asAzureAuthenticationProvider.GetAadAuthenticatedToken(asAzureContext, password, promptBehavior, AsAzureClientId, resourceUri, RedirectUri);

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
            _asAzureAuthenticationProvider.GetAadAuthenticatedToken(asAzureContext, null, PromptBehavior.RefreshSession, AsAzureClientId, resourceUri, RedirectUri);

            _profile.Context.TokenCache = AsAzureClientSession.TokenCache.Serialize();

            if (!_profile.Environments.ContainsKey(asAzureContext.Environment.Name))
            {
                _profile.Environments.Add(asAzureContext.Environment.Name, asAzureContext.Environment);
            }

            return _profile;
        }

        public static string GetAuthorityUrlForEnvironment(AsAzureEnvironment environment)
        {
            var environmentKey = AsAzureRolloutEnvironmentMapping.Keys.FirstOrDefault(s => environment.Name.Contains(s));
            AsAzureAuthInfo authInfo = null;
            if (string.IsNullOrEmpty(environmentKey) || !AsAzureRolloutEnvironmentMapping.TryGetValue(environmentKey, out authInfo))
            {
                throw new ArgumentException(Properties.Resources.UnknownEnvironment);
            }

            return authInfo.AuthorityUrl;
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
            return AsAzureRolloutEnvironmentMapping[DefaultRolloutEnvironmentKey].DefaultResourceUriSuffix;
        }

        public static string GetResourceUriSuffix(string environmentName)
        {
            if (string.IsNullOrEmpty(environmentName))
            {
                return AsAzureRolloutEnvironmentMapping[DefaultRolloutEnvironmentKey].DefaultResourceUriSuffix;
            }

            var authoInfo = AsAzureRolloutEnvironmentMapping.FirstOrDefault(kv => kv.Key.Equals(environmentName)).Value;
            if (authoInfo != null)
            {
                return authoInfo.DefaultResourceUriSuffix;
            }

            return environmentName;
        }
    }
}
