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
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensions.Msal;
using Microsoft.Rest;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace Microsoft.Azure.Commands.TestFx
{
    public class TestEnvironment
    {
        private const string DummyTenantId = "395544B0-BF41-429D-921F-E1CA2252FCF4";

        private const string MicrosoftLoginUrl = "https://login.microsoftonline.com";

        private const string MicrosoftGraphUrl = "https://graph.microsoft.com";

        /// <summary>
        /// Base Uri used by the Test Environment
        /// </summary>
        public Uri BaseUri { get; private set; }

        /// <summary>
        /// Base Azure Graph Uri used by the Test Environment
        /// </summary>
        public Uri GraphUri { get; private set; }

        /// <summary>
        /// Tenant Id used by the Test Environment
        /// </summary>
        public string TenantId { get; private set; }

        /// <summary>
        /// Subscription Id used by the Test Environment
        /// </summary>
        public string SubscriptionId { get; private set; }

        /// <summary>
        /// Service principal client id used by the Test Environment
        /// </summary>
        public string ServicePrincipalClientId { get; private set; }

        /// <summary>
        /// Service principal secret used by the Test Environment
        /// </summary>
        public string ServicePrincipalSecret { get; private set; }

        /// <summary>
        /// UserName used by the Test Environment
        /// </summary>
        public string UserId { get; private set; }

        /// <summary>
        /// Active TestEndpoint being used by the Test Environment
        /// </summary>
        public TestEndpoints Endpoints { get; private set; }

        /// <summary>
        /// Holds default endpoints for all the supported environments
        /// </summary>
        public IDictionary<TestEnvironmentName, TestEndpoints> EnvEndpoints;

        /// <summary>
        /// Connection string used by Test Environment
        /// </summary>
        public ConnectionString ConnectionString { get; private set; }

        /// <summary>
        /// Credential dictionary to hold credentials for Management and Graph client
        /// </summary>
        public Dictionary<TokenAudience, TokenCredentials> TokenInfo { get; private set; }

        [DefaultValue(false)]
        public bool OptimizeRecordedFile { get; set; }

        public TestEnvironment(string connectionString)
        {
            ConnectionString = new ConnectionString(connectionString);
            InitTestEndPoints();

            SubscriptionId = ConnectionString.GetValue(ConnectionStringKeys.SubscriptionIdKey);
            TenantId = ConnectionString.GetValue(ConnectionStringKeys.TenantIdKey);
            UserId = ConnectionString.GetValue(ConnectionStringKeys.UserIdKey);
            ServicePrincipalClientId = ConnectionString.GetValue(ConnectionStringKeys.ServicePrincipalKey);
            ServicePrincipalSecret = ConnectionString.GetValue(ConnectionStringKeys.ServicePrincipalSecretKey);
            OptimizeRecordedFile = ConnectionString.GetValue<bool>(ConnectionStringKeys.OptimizeRecordedFileKey);

            if (string.IsNullOrWhiteSpace(ServicePrincipalClientId) && string.IsNullOrWhiteSpace(UserId))
            {
                UserId = "fakeuser";
            }

            if (string.IsNullOrWhiteSpace(ConnectionString.GetValue(ConnectionStringKeys.BaseUriKey)))
            {
                BaseUri = Endpoints.ResourceManagementUri;
            }
            else
            {
                BaseUri = new Uri(ConnectionString.GetValue(ConnectionStringKeys.BaseUriKey));
            }

            if (string.IsNullOrWhiteSpace(ConnectionString.GetValue(ConnectionStringKeys.GraphUriKey)))
            {
                GraphUri = Endpoints.GraphUri;
            }
            else
            {
                GraphUri = new Uri(ConnectionString.GetValue(ConnectionStringKeys.GraphUriKey));
            }

            SetupTokenDictionary();
        }

        private void InitTestEndPoints()
        {
            LoadDefaultEnvironmentEndpoints();
            string envNameString = ConnectionString.GetValue(ConnectionStringKeys.EnvironmentKey);
            if (!string.IsNullOrEmpty(envNameString))
            {
                envNameString = nameof(TestEnvironmentName.Prod);
            }

            Enum.TryParse(envNameString, true, out TestEnvironmentName envName);
            Endpoints = new TestEndpoints(EnvEndpoints[envName], ConnectionString);
        }

        private void LoadDefaultEnvironmentEndpoints()
        {
            EnvEndpoints ??= new Dictionary<TestEnvironmentName, TestEndpoints>()
            {
                { TestEnvironmentName.Prod, new TestEndpoints(TestEnvironmentName.Prod) },
                { TestEnvironmentName.Dogfood, new TestEndpoints(TestEnvironmentName.Dogfood) },
                { TestEnvironmentName.Next, new TestEndpoints(TestEnvironmentName.Next) },
                { TestEnvironmentName.Current, new TestEndpoints(TestEnvironmentName.Current) },
                { TestEnvironmentName.Custom, new TestEndpoints(TestEnvironmentName.Custom) }
            };
        }

        private void SetupTokenDictionary()
        {
            TokenInfo = new Dictionary<TokenAudience, TokenCredentials>();
            UpdateTokenInfo(TokenAudience.Management, new[] { "https://management.core.windows.net/.default" });
            UpdateTokenInfo(TokenAudience.Graph, new[] { "https://graph.microsoft.com/.default" });
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                VerifyAuthTokens();
            }
        }

        private void UpdateTokenInfo(TokenAudience audience, IEnumerable<string> scopes, string cloudInstanceUri = null)
        {
            string tokenKey = string.Empty;
            switch (audience)
            {
                case TokenAudience.Management:
                    tokenKey = ConnectionStringKeys.RawTokenKey;
                    break;
                case TokenAudience.Graph:
                    tokenKey = ConnectionStringKeys.RawGraphTokenKey;
                    break;
            }

            if (!ConnectionString.KeyValuePairs.TryGetValue(tokenKey, out var token) || string.IsNullOrWhiteSpace(token))
            {
                token = GetAccessToken(scopes, cloudInstanceUri) ?? tokenKey;
            }

            TokenInfo[audience] = new TokenCredentials(token);
        }

        public string GetAccessToken(IEnumerable<string> scopes, string cloudInstanceUri = null)
        {
            string accessToken = null;
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                if (ConnectionString.KeyValuePairs.ContainsKey(ConnectionStringKeys.UserIdKey))
                {
                    accessToken = GetUserAccessToken(scopes, cloudInstanceUri);
                }
                else if (ConnectionString.KeyValuePairs.ContainsKey(ConnectionStringKeys.ServicePrincipalKey))
                {
                    accessToken = GetServicePrincipalAccessToken(scopes, cloudInstanceUri);
                }
            }

            return accessToken;
        }

        private string GetUserAccessToken(IEnumerable<string> scopes, string cloudInstanceUri = null)
        {
            if (string.IsNullOrWhiteSpace(cloudInstanceUri))
            {
                cloudInstanceUri = MicrosoftLoginUrl;
            }

            var pubApp = PublicClientApplicationBuilder.Create(Constants.PowerShellClientId)
                .WithAuthority(cloudInstanceUri, TenantId)
                .WithDefaultRedirectUri()
                .Build();
            RegisterTokenCache(pubApp.UserTokenCache);

            AuthenticationResult authResult;
            try
            {
                var userAccounts = pubApp.GetAccountsAsync().ConfigureAwait(false).GetAwaiter().GetResult();
                var userAccount = userAccounts.FirstOrDefault();
                authResult = pubApp.AcquireTokenSilent(scopes, userAccount).ExecuteAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            }
            catch (MsalUiRequiredException)
            {
                authResult = pubApp.AcquireTokenInteractive(scopes).ExecuteAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            }
            return authResult.AccessToken;
        }

        private string GetServicePrincipalAccessToken(IEnumerable<string> scopes, string cloudInstanceUri = null)
        {
            if (string.IsNullOrWhiteSpace(cloudInstanceUri))
            {
                cloudInstanceUri = MicrosoftLoginUrl;
            }

            var confApp = ConfidentialClientApplicationBuilder
                .Create(ServicePrincipalClientId)
                .WithClientSecret(ServicePrincipalSecret)
                .WithAuthority(cloudInstanceUri, TenantId)
                .Build();
            RegisterTokenCache(confApp.AppTokenCache);

            var authResult = confApp.AcquireTokenForClient(scopes).ExecuteAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            return authResult.AccessToken;
        }

        private void RegisterTokenCache(ITokenCache tokenCache)
        {
            var msalCacheFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ".IdentityService", "msal.cache.plaintext");
            var options = new StorageCreationPropertiesBuilder(Path.GetFileName(msalCacheFile), Path.GetDirectoryName(msalCacheFile)).WithUnprotectedFile().Build();
            var helper = MsalCacheHelper.CreateAsync(options).ConfigureAwait(false).GetAwaiter().GetResult();
            helper.RegisterCache(tokenCache);
        }

        private void VerifyAuthTokens()
        {
            VerifySubscription();
            VerifyGraphToken();
        }

        private void VerifySubscription()
        {
            string matchedSubscriptionId = string.Empty;
            StringBuilder sb = new StringBuilder();
            string callerId = string.Empty;
            string subs = string.Empty;
            List<SubscriptionInfo> subscriptionList = new List<SubscriptionInfo>();

            if (TokenInfo[TokenAudience.Management] != null)
            {
                subscriptionList = ListSubscriptions(BaseUri.ToString(), TokenInfo[TokenAudience.Management]);
                try { callerId = TokenInfo[TokenAudience.Management].CallerId; } catch { }
            }

            if (!(string.IsNullOrEmpty(SubscriptionId)) && !(SubscriptionId.Equals("None", StringComparison.OrdinalIgnoreCase)))
            {
                if (subscriptionList.Any())
                {
                    var matchedSubs = subscriptionList.Where(sub => sub.SubscriptionId.Equals(SubscriptionId, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                    if (matchedSubs != null)
                    {
                        matchedSubscriptionId = matchedSubs.SubscriptionId;
                    }
                    else
                    {
                        foreach (var subInfo in subscriptionList)
                        {
                            subs += subInfo.SubscriptionId + ",";
                        }
                    }
                }

                if (string.IsNullOrEmpty(matchedSubscriptionId))
                {
                    sb.AppendLine($"SubscriptionList:'{subs}' retrieved for the user/spn id '{callerId}', do not match with the provided subscriptionId '{SubscriptionId}' in connection string");
                    throw new Exception(sb.ToString());
                }
            }
            else
            {
                // The idea is in case if no match was found, we check if subscription Id was provided in connection string, if not
                // we then check if the retrieved subscription list has exactly 1 subscription, if yes we will just use that one.
                if (string.IsNullOrEmpty(SubscriptionId))
                {
                    if (subscriptionList.Count == 1)
                    {
                        ConnectionString.KeyValuePairs[ConnectionStringKeys.SubscriptionIdKey] = subscriptionList.First().SubscriptionId;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(SubscriptionId))
                        {
                            sb.AppendLine("Retrieved subscription list has more than 1 subscription. Connection string has no subscription provided. Provide SubcriptionId info in connection string");
                            throw new Exception(sb.ToString());
                        }
                    }
                }
                else if (SubscriptionId.Equals("None", StringComparison.OrdinalIgnoreCase))
                {
                    sb.AppendLine($"'{ConnectionStringKeys.TestCSMOrgIdConnectionStringKey}': connection string contains subscriptionId as '{SubscriptionId}'");
                    sb.AppendLine("Provide valid SubcriptionId info in connection string");
                    throw new Exception(sb.ToString());
                }
            }
        }

        private List<SubscriptionInfo> ListSubscriptions(string baseUri, TokenCredentials credentials)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri($"{baseUri}/subscriptions?api-version=2014-04-01-preview")
            };

            HttpClient client = new HttpClient();
            credentials.ProcessHttpRequestAsync(request, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
            HttpResponseMessage response = client.SendAsync(request).Result;
            response.EnsureSuccessStatusCode();

            string jsonString = response.Content.ReadAsStringAsync().Result;
            var jsonResult = JObject.Parse(jsonString);
            return ((JArray)jsonResult["value"]).Select(item => new SubscriptionInfo((JObject)item)).ToList();
        }

        private void VerifyGraphToken()
        {
            if (TokenInfo[TokenAudience.Graph] != null)
            {
                try
                {
                    string operationUrl = $@"{GraphUri}{TenantId}/users?$orderby=displayName&$top=25&api-version=1.6";
                    TokenCredentials graphCredential = TokenInfo[TokenAudience.Graph];

                    var request = new HttpRequestMessage
                    {
                        RequestUri = new Uri(operationUrl)
                    };

                    HttpClient client = new HttpClient();
                    graphCredential.ProcessHttpRequestAsync(request, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
                    HttpResponseMessage response = client.SendAsync(request).Result;
                    response.EnsureSuccessStatusCode();

                    string jsonString = response.Content.ReadAsStringAsync().Result;
                    var jsonResult = JObject.Parse(jsonString);
                }
                catch (Exception ex)
                {
                    string graphFailMessage = $@"Unable to make request to graph endpoint '{GraphUri}' using credentials provided within the connectionstring";
                    Debug.WriteLine(graphFailMessage, ex.ToString());
                }
            }
        }

        internal void SetEnvironmentVariables()
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                //Restore/Add Subscription Id in MockServer from supplied connection string
                if (HttpMockServer.Variables.ContainsCaseInsensitiveKey(ConnectionStringKeys.SubscriptionIdKey))
                {
                    HttpMockServer.Variables.UpdateDictionary(ConnectionStringKeys.SubscriptionIdKey, SubscriptionId);
                }
                else
                {
                    HttpMockServer.Variables.Add(ConnectionStringKeys.SubscriptionIdKey, SubscriptionId);
                }
            }
            else if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                //Get Subscription Id from MockServer. Otherwise, assign zero guid
                if (HttpMockServer.Variables.ContainsCaseInsensitiveKey(ConnectionStringKeys.SubscriptionIdKey))
                {
                    SubscriptionId = HttpMockServer.Variables.GetValueUsingCaseInsensitiveKey(ConnectionStringKeys.SubscriptionIdKey);
                }
                else
                {
                    SubscriptionId = Guid.Empty.ToString();
                }

                // Get Tenant Id from MockServer. Otherwise, assign dummy guid
                if (HttpMockServer.Variables.ContainsCaseInsensitiveKey(ConnectionStringKeys.TenantIdKey))
                {
                    TenantId = HttpMockServer.Variables.GetValueUsingCaseInsensitiveKey(ConnectionStringKeys.TenantIdKey);
                }
                else
                {
                    TenantId = DummyTenantId;
                }
            }
        }
    }
}
