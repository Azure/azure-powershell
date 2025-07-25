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
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Microsoft.Azure.Commands.TestFx
{
    public class TestEnvironment
    {
        private const string DummyTenantId = "395544B0-BF41-429D-921F-E1CA2252FCF4";

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
        /// Is the Test Environment running in mock mode
        /// </summary>
        public bool IsRunningMocked { get; private set; }

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

            IsRunningMocked = HttpMockServer.Mode == HttpRecorderMode.Playback;

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
            UpdateTokenInfo(TokenAudience.Management);
            UpdateTokenInfo(TokenAudience.Graph);
        }

        private void UpdateTokenInfo(TokenAudience audience)
        {
            string token = string.Empty;
            switch (audience)
            {
                case TokenAudience.Management:
                    token = ConnectionStringKeys.RawTokenKey;
                    break;
                case TokenAudience.Graph:
                    token = ConnectionStringKeys.RawGraphTokenKey;
                    break;
            }

            TokenInfo[audience] = new TokenCredentials(token);
        }

        internal void SetEnvironmentVariables()
        {
            if (IsRunningMocked)
            {
                // Get Subscription Id from MockServer. Otherwise, assign zero guid
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
            else
            {
                // Restore/Add Subscription Id in MockServer from supplied connection string
                if (HttpMockServer.Variables.ContainsCaseInsensitiveKey(ConnectionStringKeys.SubscriptionIdKey))
                {
                    HttpMockServer.Variables.UpdateDictionary(ConnectionStringKeys.SubscriptionIdKey, SubscriptionId);
                }
                else
                {
                    HttpMockServer.Variables.Add(ConnectionStringKeys.SubscriptionIdKey, SubscriptionId);
                }
            }
        }
    }
}
