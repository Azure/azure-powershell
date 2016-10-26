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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Factories;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Common.Authentication.Properties;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.IO;
using System.Security;

namespace Microsoft.Azure.Commands.AnalysisServices
{
    /// <summary>
    /// Represents current Azure session.
    /// </summary>
    public class AsAzureClientUtility
    {
        public const string PowerShellClientId = "1950a258-227b-4e31-a9cf-717495945fc2";

        public static readonly Uri PowerShellRedirectUri = new Uri("urn:ietf:wg:oauth:2.0:oob");

        /// <summary>
        /// Gets or sets data persistence store.
        /// </summary>
        public static IDataStore DataStore { get; set; }

        /// <summary>
        /// Gets or sets the token cache store.
        /// </summary>
        public static TokenCache TokenCache { get; set; }

        /// <summary>
        /// Gets or sets profile directory.
        /// </summary>
        public static string ProfileDirectory { get; set; }

        /// <summary>
        /// Gets or sets token cache file path.
        /// </summary>
        public static string TokenCacheFile { get; set; }

        /// <summary>
        /// Gets or sets profile file name.
        /// </summary>
        public static string ProfileFile { get; set; }

        /// <summary>
        /// Gets or sets file name for the migration backup.
        /// </summary>
        public static string OldProfileFileBackup { get; set; }

        /// <summary>
        /// Gets or sets old profile file name.
        /// </summary>
        public static string OldProfileFile { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private AsAzureProfile _profile;

        static AsAzureClientUtility()
        {
            Instance = new AsAzureClientUtility();
        }

        private AsAzureClientUtility()
        {
            OldProfileFile = "AsAzureProfile.xml";
            OldProfileFileBackup = "AsAzureProfile.xml.bak";
            ProfileDirectory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                Properties.Resources.AsAzureDirectoryName);
            ProfileFile = "AsAzureProfile.json";
            TokenCacheFile = "TokenCache.dat";

            DataStore = new MemoryDataStore();
            TokenCache = new TokenCache();
            _profile = new AsAzureProfile();

            //if (_profile.Context != null && _profile.Context.TokenCache != null && _profile.Context.TokenCache.Length > 0)
            //{
            //    TokenCache.DefaultShared.Deserialize(_profile.Context.TokenCache);
            //}
        }

        public static AsAzureClientUtility Instance { get; private set; }

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
            //"rolloutUrl": "ring0test.asazure-int.windows.net",
            PromptBehavior promptBehavior = password == null ? PromptBehavior.Always : PromptBehavior.Auto;

            var resourceUri = new UriBuilder("https", asAzureContext.Environment.Name).ToString();
            GetAadAuthenticatedToken(asAzureContext, password, promptBehavior, PowerShellClientId, resourceUri, PowerShellRedirectUri);

            _profile.Context.TokenCache = AsAzureClientUtility.TokenCache.Serialize();

            return _profile;
        }

        /// <summary>
        /// Function to get an AAD token for a given user, client id and resource
        /// </summary>
        public static string GetAadAuthenticatedToken(AsAzureContext asAzureContext, SecureString password, PromptBehavior promptBehavior, string clientId, string resourceUri, Uri resourceRedirectUri)
        {
            var authenticationContext = new AuthenticationContext(
                asAzureContext.Environment.Endpoints[AsAzureEnvironment.AsRolloutEndpoints.AdAuthorityBaseUrl], 
                AsAzureClientUtility.TokenCache);

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

        public void SetCurrentContext(AsAzureAccount azureAccount, AsAzureEnvironment asEnvironment)
        {
            _profile.Context = new AsAzureContext(azureAccount, asEnvironment)
            {
                TokenCache = AsAzureClientUtility.TokenCache.Serialize()
            };
        }
    }
}
