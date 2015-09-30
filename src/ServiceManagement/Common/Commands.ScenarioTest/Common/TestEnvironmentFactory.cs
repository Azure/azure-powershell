//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using Microsoft.Azure.Test.HttpRecorder;
using Newtonsoft.Json.Linq;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Hyak.Common;
using Microsoft.Azure;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest.Common
{
    public abstract class TestEnvironmentFactory
    {
        /// <summary>
        /// The key inside the connection string for the management certificate
        /// </summary>
        public const string ManagementCertificateKey = ConnectionStringFields.ManagementCertificate;

        /// <summary>
        /// The key inside the connection string for the subscription identifier
        /// </summary>
        public const string SubscriptionIdKey = ConnectionStringFields.SubscriptionId;

        /// <summary>
        /// The key inside the connection string for the AAD user ID
        /// </summary>
        public const string AADUserIdKey = ConnectionStringFields.UserId;

        /// <summary>
        /// The key inside the connection string for the AAD password
        /// </summary>
        public const string AADPasswordKey = ConnectionStringFields.Password;

        /// <summary>
        /// The key inside the connection string for the base management URI
        /// </summary>
        public const string BaseUriKey = ConnectionStringFields.BaseUri;

        /// <summary>
        /// The key inside the connection string for the AAD client ID
        /// </summary>
        public const string ClientID = ConnectionStringFields.AADClientId;
        public const string ClientIdDefault = "1950a258-227b-4e31-a9cf-717495945fc2";

        /// <summary>
        /// The key inside the connection string for the AAD authentication endpoint
        /// </summary>
        public const string AADAuthEndpoint = ConnectionStringFields.AADAuthenticationEndpoint;
        public const string AADAuthEndpointDefault = "https://login.windows-ppe.net/";
        /// <summary>
        /// The key inside the connection string for the AAD Tenant
        /// </summary>
        public const string AADTenant = ConnectionStringFields.AADTenant;
        public const string AADTenantDefault = "common";

        public const string StorageAccountKey = "AZURE_STORAGE_ACCOUNT";

        /// <summary>
        /// A raw token to be used for authentication with the given subscription ID
        /// </summary>
        public const string RawToken = ConnectionStringFields.RawToken;

        public virtual TestEnvironment GetTestEnvironment()
        {
            var env = this.GetTestEnvironmentFromContext();
            env.StorageAccount = Environment.GetEnvironmentVariable(StorageAccountKey);
            return env;
        }

        protected abstract TestEnvironment GetTestEnvironmentFromContext();

        /// <summary>
        /// Return test credentials and URI using AAD auth for an OrgID account.  Use this method with caution - it may take a dependency on ADAL.
        /// </summary>
        /// <returns>The test credentials, or null if the appropriate environment variable is not set.</returns>
        protected virtual TestEnvironment GetOrgIdTestEnvironment(string orgIdVariable)
        {
            TestEnvironment orgIdEnvironment = null;
            string orgIdAuth = GetOrgId(orgIdVariable);
            if (!string.IsNullOrEmpty(orgIdAuth))
            {
                string token = null;
                IDictionary<string, string> authSettings = ParseConnectionString(orgIdAuth);
                string subscription = authSettings[SubscriptionIdKey];
                string authEndpoint = authSettings.ContainsKey(AADAuthEndpoint) ? authSettings[AADAuthEndpoint] : AADAuthEndpointDefault;
                string tenant = authSettings.ContainsKey(AADTenant) ? authSettings[AADTenant] : AADTenantDefault;
                string user = null;
                AuthenticationResult result = null;

                if (authSettings.ContainsKey(AADUserIdKey))
                {
                    user = authSettings[AADUserIdKey];
                }

                // Preserve/restore subscription ID
                if (HttpMockServer.Mode == HttpRecorderMode.Record)
                {
                    HttpMockServer.Variables[SubscriptionIdKey] = subscription;
                    if (authSettings.ContainsKey(AADUserIdKey) && authSettings.ContainsKey(AADPasswordKey))
                    {
                        
                        string password = authSettings[AADPasswordKey];
                        TracingAdapter.Information("Using AAD auth with username and password combination");
                        token = TokenCloudCredentialsHelper.GetTokenFromBasicCredentials(user, password, authEndpoint, tenant);
                    }
                    else
                    {
                        TracingAdapter.Information("Using AAD auth with pop-up dialog");
                        string clientId = authSettings.ContainsKey(ClientID) ? authSettings[ClientID] : ClientIdDefault;
                        if (authSettings.ContainsKey(RawToken))
                        {
                            token = authSettings[RawToken];
                        }
                        else
                        {
                            result = TokenCloudCredentialsHelper.GetToken(authEndpoint, tenant, clientId);
                            token = result.CreateAuthorizationHeader().Substring("Bearer ".Length);
                        }
                    }
                }

                if (HttpMockServer.Mode == HttpRecorderMode.Playback)
                {
                    // playback mode but no stored credentials in mocks
                    TracingAdapter.Information("Using dummy token for playback");
                    token = Guid.NewGuid().ToString();
                }

                orgIdEnvironment = new TestEnvironment
                {
                    Credentials = token == null ? null : new TokenCloudCredentials(subscription, token),
                    UserName = user,
                    AuthenticationResult = result
                };

                if (authSettings.ContainsKey(BaseUriKey))
                {
                    orgIdEnvironment.BaseUri = new Uri(authSettings[BaseUriKey]);
                }

                if (!string.IsNullOrEmpty(authEndpoint))
                {
                    orgIdEnvironment.ActiveDirectoryEndpoint = new Uri(authEndpoint);
                }

                orgIdEnvironment.SubscriptionId = subscription;
            }

            return orgIdEnvironment;
        }

        private static string GetOrgId(string orgIdVariable)
        {
            string connectionString = Environment.GetEnvironmentVariable(orgIdVariable);
            if (string.IsNullOrEmpty(connectionString))
            {
                JObject dummyTestConnectionString = JObject.Parse(Properties.Resources.CsmTestDummy);
                connectionString = dummyTestConnectionString.SelectToken(orgIdVariable).Value<string>();
            }
            
            return connectionString;
        }
        /// <summary>
        /// Break up the connection string into key-value pairs
        /// </summary>
        /// <param name="connectionString">The connection string to parse</param>
        /// <returns>A dictionary of keys and values from the connection string</returns>
        public static IDictionary<string, string> ParseConnectionString(string connectionString)
        {
            // hacky connection string parser.  We should replace with more robust connection string parsing
            IDictionary<string, string> settings = new Dictionary<string, string>();
            string[] pairs = connectionString.Split(new char[] { ';' });
            foreach (string pair in pairs)
            {
                string[] keyValue = pair.Split(new char[] { '=' }, 2);
                string key = keyValue[0].Trim();
                string value = keyValue[1].Trim();
                settings[key] = value;
            }

            return settings;
        }
    }
}
