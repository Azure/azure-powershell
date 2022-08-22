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

using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest;
using Microsoft.Rest.Azure.Authentication;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.TestFx
{
    public class TestEnvironment
    {
        private const string DummyTenantId = "395544B0-BF41-429D-921F-E1CA2252FCF4";

        /// <summary>
        /// Base Uri used by the Test Environment
        /// </summary>
        public Uri BaseUri { get; set; }

        /// <summary>
        /// Base Azure Graph Uri used by the Test Environment
        /// </summary>
        public Uri GraphUri { get; set; }

        /// <summary>
        /// UserName used by the Test Environment
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Tenant used by the Test Environment
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        /// Subscription Id used by the Test Environment
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Active TestEndpoint being used by the Test Environment
        /// </summary>
        public TestEndpoints Endpoints { get; set; }

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
            UserName = ConnectionString.GetValue(ConnectionStringKeys.UserIdKey);
            OptimizeRecordedFile = ConnectionString.GetValue<bool>(ConnectionStringKeys.OptimizeRecordedFileKey);

            if (string.IsNullOrEmpty(ConnectionString.GetValue(ConnectionStringKeys.BaseUriKey)))
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
            else if (!string.IsNullOrWhiteSpace(ConnectionString.GetValue(ConnectionStringKeys.GraphUriKey)))
            {
                GraphUri = new Uri(ConnectionString.GetValue(ConnectionStringKeys.GraphUriKey));
            }

            InitTokenDictionary();
            SetupHttpRecorderMode();
            RecorderModeSettings();
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
            if (EnvEndpoints == null)
            {
                EnvEndpoints = new Dictionary<TestEnvironmentName, TestEndpoints>()
                {
                    { TestEnvironmentName.Prod, new TestEndpoints(TestEnvironmentName.Prod) },
                    { TestEnvironmentName.Dogfood, new TestEndpoints(TestEnvironmentName.Dogfood) },
                    { TestEnvironmentName.Next, new TestEndpoints(TestEnvironmentName.Next) },
                    { TestEnvironmentName.Current, new TestEndpoints(TestEnvironmentName.Current) },
                    { TestEnvironmentName.Custom, new TestEndpoints(TestEnvironmentName.Custom) }
                };
            }
        }

        private void InitTokenDictionary()
        {
            TokenInfo = new Dictionary<TokenAudience, TokenCredentials>();

            ConnectionString.KeyValuePairs.TryGetValue(ConnectionStringKeys.RawTokenKey, out string rawToken);
            ConnectionString.KeyValuePairs.TryGetValue(ConnectionStringKeys.RawGraphTokenKey, out string rawGraphToken);

            // We need TokenInfo to be non-empty as there are cases where have taken dependency on non-empty TokenInfo in MockContext
            if (string.IsNullOrEmpty(rawToken))
            {
                rawToken = ConnectionStringKeys.RawTokenKey;
            }

            if (string.IsNullOrEmpty(rawGraphToken))
            {
                rawGraphToken = ConnectionStringKeys.RawGraphTokenKey;
            }

            TokenInfo[TokenAudience.Management] = new TokenCredentials(rawToken);
            TokenInfo[TokenAudience.Graph] = new TokenCredentials(rawGraphToken);
        }

        private void SetupHttpRecorderMode()
        {
            string testMode = Environment.GetEnvironmentVariable(ConnectionStringKeys.AZURE_TEST_MODE_ENVKEY);

            if (string.IsNullOrEmpty(testMode))
            {
                testMode = ConnectionString.GetValue(ConnectionStringKeys.HttpRecorderModeKey);
            }

            // Ideally we should be throwing when incompatible environment (e.g. Environment=Foo) is provided in connection string
            // But currently we do not throw
            if (Enum.TryParse(testMode, out HttpRecorderMode recorderMode))
            {
                HttpMockServer.Mode = recorderMode;
            }
            else
            {
                // Log incompatible recorder mode
                // Currently we set Playback as default recorder mode
                HttpMockServer.Mode = HttpRecorderMode.Playback;
            }
        }

        private void RecorderModeSettings()
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

                // If User has provided Access Token in RawToken/GraphToken Key-Value, we don't need to authenticate
                // We currently only check for RawToken and do not check if GraphToken is provided
                if (string.IsNullOrEmpty(ConnectionString.GetValue(ConnectionStringKeys.RawTokenKey)))
                {
                    Login();
                }

                VerifyAuthTokens();
            }
        }

        private void Login()
        {
            string userPassword = ConnectionString.GetValue(ConnectionStringKeys.PasswordKey);
            string spnClientId = ConnectionString.GetValue(ConnectionStringKeys.ServicePrincipalKey);
            string spnClientSecret = ConnectionString.GetValue(ConnectionStringKeys.ServicePrincipalSecretKey);
            //We use this because when login silently using userTokenProvider, we need to provide a well known ClientId for an app that has delegating permissions.
            //All first party app have that permissions, so we use PowerShell app ClientId
#if net452
            string PowerShellClientId = "1950a258-227b-4e31-a9cf-717495945fc2";
#endif
           /*
            * Currently we prioritize login as below:
            * 1) ServicePrincipal/ServicePrincipal Secret Key
            * 2) UserName / Password combination
            * 3) Interactive Login (where user will be presented with prompt to login)
            */

            ActiveDirectoryServiceSettings aadServiceSettings = new ActiveDirectoryServiceSettings()
            {
                AuthenticationEndpoint = new Uri(Endpoints.AADAuthUri.ToString() + ConnectionString.GetValue(ConnectionStringKeys.TenantIdKey)),
                TokenAudience = Endpoints.AADTokenAudienceUri
            };

            ActiveDirectoryServiceSettings graphAADServiceSettings = new ActiveDirectoryServiceSettings()
            {
                AuthenticationEndpoint = new Uri(Endpoints.AADAuthUri.ToString() + ConnectionString.GetValue(ConnectionStringKeys.TenantIdKey)),
                TokenAudience = Endpoints.GraphTokenAudienceUri
            };

            if ((!string.IsNullOrEmpty(spnClientId)) && (!string.IsNullOrEmpty(spnClientSecret)))
            {
                Task<TokenCredentials> mgmAuthResult = Task.Run(async () => (TokenCredentials)await ApplicationTokenProvider.LoginSilentAsync(TenantId, spnClientId, spnClientSecret, aadServiceSettings).ConfigureAwait(false));
                TokenInfo[TokenAudience.Management] = mgmAuthResult.Result;
                UpdateTokenInfoWithGraphToken(graphAADServiceSettings, spnClientId: spnClientId, spnClientSecret: spnClientSecret);
            }
            else if ((!string.IsNullOrEmpty(UserName)) && (!string.IsNullOrEmpty(userPassword)))
            {
                //#if FullNetFx
#if net452
                Task<TokenCredentials> mgmAuthResult = Task.Run(async () => (TokenCredentials)await UserTokenProvider.LoginSilentAsync(PowerShellClientId, TenantId, UserName, userPassword, aadServiceSettings).ConfigureAwait(false));
                this.TokenInfo[TokenAudience.Management] = mgmAuthResult.Result;
                UpdateTokenInfoWithGraphToken(graphAADServiceSettings, userName: UserName, password: userPassword, psClientId: PowerShellClientId);
#else
                throw new NotSupportedException("Username/Password login is supported only in NET452 and above projects");
#endif
            }
            else
            {
                //#if FullNetFx
#if net452
                InteractiveLogin(TenantId, PowerShellClientId, aadServiceSettings, graphAADServiceSettings);
#else
                throw new NotSupportedException("Interactive Login is supported only in NET452 and above projects");
#endif
            }
        }

        private void UpdateTokenInfoWithGraphToken(ActiveDirectoryServiceSettings graphAADServiceSettings, string spnClientId = "", string spnClientSecret = "", string userName = "", string password = "", string psClientId = "")
        {
            Task<TokenCredentials> graphAuthResult = null;
            try
            {
                if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(password))
                {
                    //#if FullNetFx
#if net452
                    graphAuthResult = Task.Run(async () => (TokenCredentials)await UserTokenProvider.LoginSilentAsync(psClientId, TenantId, userName, password, graphAADServiceSettings).ConfigureAwait(false));
#endif
                }
                else if (!string.IsNullOrWhiteSpace(spnClientId) && !string.IsNullOrWhiteSpace(spnClientSecret))
                {
                    graphAuthResult = Task.Run(async () => (TokenCredentials)await ApplicationTokenProvider.LoginSilentAsync(TenantId, spnClientId, spnClientSecret, graphAADServiceSettings).ConfigureAwait(false));
                }

                TokenInfo[TokenAudience.Graph] = graphAuthResult?.Result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error while acquiring Graph Token: '{ex}'");
                // Not all accounts are registered to have access to Graph endpoints. 
            }
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
                    if (subscriptionList.Count() == 1)
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

        internal void SetRecordedEnvironmentVariables()
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
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
