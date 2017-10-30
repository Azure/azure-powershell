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
using Microsoft.Azure.Commands.PowerBIEmbeddedCapacity.Dataplane.Models;
using Enumerable = System.Linq.Enumerable;

namespace Microsoft.Azure.Commands.PowerBIEmbeddedCapacity.Dataplane
{
    /// <summary>
    /// Represents current AS Azure session.
    /// </summary>
    public class PBIClientSession
    {
        public const string RestartEndpointPathFormat = "/webapi/capacities/{0}/restart?api-version=2016-10-01";
        public const string LogfileEndpointPathFormat = "/webapi/capacities/{0}/logfileHere";
        public const string SynchronizeEndpointPathFormat = "/webapi/capacities/{0}/databases/{1}/sync";
        public const string PBIClientId = "cf710c6e-dfcc-4fa8-a093-d47294e44c66";
        public static readonly Uri RedirectUri = new Uri("urn:ietf:wg:oauth:2.0:oob");
        public static string DefaultRolloutEnvironmentKey = "pbidedicated.windows.net";

        public static Dictionary<string, PBIAuthInfo> PBIRolloutEnvironmentMapping = new Dictionary<string, PBIAuthInfo>()
            {
             { "pbidedicated.windows.net", new PBIAuthInfo()
                {
                 AuthorityUrl = "https://login.windows.net" ,
                 DefaultResourceUriSuffix = "*.pbidedicated.windows.net"
                }
             },
             { "pbidedicated-int.windows.net", new PBIAuthInfo()
                {
                    AuthorityUrl = "https://login.windows-ppe.net" ,
                    DefaultResourceUriSuffix = "*.pbidedicated-int.windows.net"
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
        private PBIProfile _profile;

        private IPBIAuthenticationProvider _asAzureAuthenticationProvider;

        static PBIClientSession()
        {
            Instance = new PBIClientSession();
        }

        private PBIClientSession()
        {
            TokenCache = new TokenCache();
            _profile = new PBIProfile();
            _asAzureAuthenticationProvider = new PBIAuthenticationProvider();
        }

        public void SetPBIAuthenticationProvider(IPBIAuthenticationProvider asAzureAuthenticationProvider)
        {
            _asAzureAuthenticationProvider = asAzureAuthenticationProvider;
        }

        public static PBIClientSession Instance { get; private set; }

        public PBIProfile Profile
        {
            get { return _profile; }
            set
            {
                _profile = value;
            }
        }

        public PBIProfile Login(PBIContext asAzureContext, SecureString password)
        {
            PromptBehavior promptBehavior = password == null ? PromptBehavior.Always : PromptBehavior.Auto;

            var resourceUri = new UriBuilder(Uri.UriSchemeHttps, GetResourceUriSuffix(asAzureContext.Environment.Name)).ToString();
            resourceUri = resourceUri.TrimEnd('/');
            _asAzureAuthenticationProvider.GetAadAuthenticatedToken(asAzureContext, password, promptBehavior, PBIClientId, resourceUri, RedirectUri);

            _profile.Context.TokenCache = PBIClientSession.TokenCache.Serialize();

            if (!_profile.Environments.ContainsKey(asAzureContext.Environment.Name))
            {
                _profile.Environments.Add(asAzureContext.Environment.Name, asAzureContext.Environment);
            }

            return _profile;
        }

        public PBIProfile Login(PBIContext asAzureContext)
        {
            var resourceUri = new UriBuilder(Uri.UriSchemeHttps, GetResourceUriSuffix(asAzureContext.Environment.Name)).ToString();
            resourceUri = resourceUri.TrimEnd('/');
            _asAzureAuthenticationProvider.GetAadAuthenticatedToken(asAzureContext, null, PromptBehavior.RefreshSession, PBIClientId, resourceUri, RedirectUri);

            _profile.Context.TokenCache = PBIClientSession.TokenCache.Serialize();

            if (!_profile.Environments.ContainsKey(asAzureContext.Environment.Name))
            {
                _profile.Environments.Add(asAzureContext.Environment.Name, asAzureContext.Environment);
            }

            return _profile;
        }

        public static string GetAuthorityUrlForEnvironment(PBIEnvironment environment)
        {
            var environmentKey = PBIRolloutEnvironmentMapping.Keys.FirstOrDefault(s => environment.Name.Contains(s));
            PBIAuthInfo authInfo = null;
            if (string.IsNullOrEmpty(environmentKey) || !PBIRolloutEnvironmentMapping.TryGetValue(environmentKey, out authInfo))
            {
                throw new ArgumentException(Properties.Resources.UnknownEnvironment);
            }

            return authInfo.AuthorityUrl;
        }

        public void SetCurrentContext(PBIAccount azureAccount, PBIEnvironment asEnvironment)
        {
            _profile.Context = new PBIContext(azureAccount, asEnvironment)
            {
                TokenCache = PBIClientSession.TokenCache.Serialize()
            };
        }

        public static string GetDefaultEnvironmentName()
        {
            return PBIRolloutEnvironmentMapping[DefaultRolloutEnvironmentKey].DefaultResourceUriSuffix;
        }

        public static string GetResourceUriSuffix(string environmentName)
        {
            if (string.IsNullOrEmpty(environmentName))
            {
                return PBIRolloutEnvironmentMapping[DefaultRolloutEnvironmentKey].DefaultResourceUriSuffix;
            }

            var authoInfo = PBIRolloutEnvironmentMapping.FirstOrDefault(kv => kv.Key.Equals(environmentName)).Value;
            if (authoInfo != null)
            {
                return authoInfo.DefaultResourceUriSuffix;
            }

            return environmentName;
        }
    }
}
