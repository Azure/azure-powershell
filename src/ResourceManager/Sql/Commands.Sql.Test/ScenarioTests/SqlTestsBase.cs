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
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Graph.RBAC;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Management.Storage;

namespace Microsoft.Azure.Commands.ScenarioTest.SqlTests
{
    public class SqlTestsBase : RMTestBase
    {
        protected SqlEvnSetupHelper helper;

        private const string TenantIdKey = "TenantId";
        private const string DomainKey = "Domain";

        public string UserDomain { get; private set; }

        protected SqlTestsBase()
        {
            helper = new SqlEvnSetupHelper();
        }

        protected virtual void SetupManagementClients()
        {
            var sqlCSMClient = GetSqlClient(); // to interact with the security endpoints
            var storageClient = GetStorageClient();
            var resourcesClient = GetResourcesClient();
            var authorizationClient = GetAuthorizationManagementClient();
            var graphClient = GetGraphClient();
            HttpClientHelperFactory.Instance = new TestHttpClientHelperFactory(new CSMTestEnvironmentFactory().GetTestEnvironment().Credentials as SubscriptionCloudCredentials);
            helper.SetupSomeOfManagementClients(sqlCSMClient, storageClient, resourcesClient, authorizationClient, graphClient);
        }

        protected void RunPowerShellTest(params string[] scripts)
        {
            //HttpMockServer.Matcher = new PermissiveRecordMatcher();
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("Microsoft.Authorization", "2014-07-01-preview");
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(false, d);
            // Enable undo functionality as well as mock recording
            using (UndoContext context = UndoContext.Current)
            {
                // Configure recordings
                context.Start(TestUtilities.GetCallingClass(2), TestUtilities.GetCurrentMethodName(2));

                SetupManagementClients();

                helper.SetupEnvironment();

                helper.SetupModules(AzureModule.AzureResourceManager, "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + this.GetType().Name + ".ps1");

                helper.RunPowerShellTest(scripts);
            }
        }

        protected SqlManagementClient GetSqlClient()
        {
            SqlManagementClient client = TestBase.GetServiceClient<SqlManagementClient>(new CSMTestEnvironmentFactory());
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                client.LongRunningOperationInitialTimeout = 0;
                client.LongRunningOperationRetryTimeout = 0;
            }
            return client;
        }

        protected StorageManagementClient GetStorageClient()
        {
            StorageManagementClient client = TestBase.GetServiceClient<StorageManagementClient>(new RDFETestEnvironmentFactory());
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                client.LongRunningOperationInitialTimeout = 0;
                client.LongRunningOperationRetryTimeout = 0;
            }
            return client;
        }

        protected ResourceManagementClient GetResourcesClient()
        {
            ResourceManagementClient client = TestBase.GetServiceClient<ResourceManagementClient>(new CSMTestEnvironmentFactory());
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                client.LongRunningOperationInitialTimeout = 0;
                client.LongRunningOperationRetryTimeout = 0;
            }
            return client;
        }

        protected AuthorizationManagementClient GetAuthorizationManagementClient()
        {   
            AuthorizationManagementClient client = TestBase.GetServiceClient<AuthorizationManagementClient>(new CSMTestEnvironmentFactory());
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                client.LongRunningOperationInitialTimeout = 0;
                client.LongRunningOperationRetryTimeout = 0;
            }
            return client;
        }

        protected GraphRbacManagementClient GetGraphClient()
        {
            var testFactory = new CSMTestEnvironmentFactory();
            var environment = testFactory.GetTestEnvironment();
            string tenantId = Guid.Empty.ToString();

            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                tenantId = environment.AuthorizationContext.TenantId;
                UserDomain = environment.AuthorizationContext.UserDomain;

                HttpMockServer.Variables[TenantIdKey] = tenantId;
                HttpMockServer.Variables[DomainKey] = UserDomain;
            }
            else if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                if (HttpMockServer.Variables.ContainsKey(TenantIdKey))
                {
                    tenantId = HttpMockServer.Variables[TenantIdKey];
                    AzureRMCmdlet.DefaultProfile.Context.Tenant.Id = new Guid(tenantId);
                }
                if (HttpMockServer.Variables.ContainsKey(DomainKey))
                {
                    UserDomain = HttpMockServer.Variables[DomainKey];
                    AzureRMCmdlet.DefaultProfile.Context.Tenant.Domain = UserDomain;
                }
            }

            return TestBase.GetGraphServiceClient<GraphRbacManagementClient>(testFactory, tenantId);
        }

        /// <summary>
        /// The test http client helper factory.
        /// </summary>
        private class TestHttpClientHelperFactory : HttpClientHelperFactory
        {
            /// <summary>
            /// The subscription cloud credentials.
            /// </summary>
            private readonly SubscriptionCloudCredentials credential;

            /// <summary>
            /// Initializes a new instance of the <see cref="TestHttpClientHelperFactory"/> class.
            /// </summary>
            /// <param name="credentials"></param>
            public TestHttpClientHelperFactory(SubscriptionCloudCredentials credentials)
            {
                this.credential = credentials;
            }

            /// <summary>
            /// Creates new instances of the <see cref="HttpClientHelper"/> class.
            /// </summary>
            /// <param name="credentials">The credentials.</param>
            /// <param name="headerValues">The headers.</param>
            public override HttpClientHelper CreateHttpClientHelper(SubscriptionCloudCredentials credentials, IEnumerable<ProductInfoHeaderValue> headerValues)
            {
                return new HttpClientHelperImpl(credentials: this.credential, headerValues: headerValues);
            }

            /// <summary>
            /// An implementation of the <see cref="HttpClientHelper"/> abstract class.
            /// </summary>
            private class HttpClientHelperImpl : HttpClientHelper
            {
                /// <summary>
                /// Initializes new instances of the <see cref="HttpClientHelperImpl"/> class.
                /// </summary>
                /// <param name="credentials">The credentials.</param>
                /// <param name="headerValues">The headers.</param>
                public HttpClientHelperImpl(SubscriptionCloudCredentials credentials, IEnumerable<ProductInfoHeaderValue> headerValues)
                    : base(credentials: credentials, headerValues: headerValues)
                {
                }

                /// <summary>
                /// Creates an <see cref="HttpClient"/>
                /// </summary>
                /// <param name="primaryHandlers">The handlers that will be added to the top of the chain.</param>
                public override HttpClient CreateHttpClient(params DelegatingHandler[] primaryHandlers)
                {
                    return base.CreateHttpClient(HttpMockServer.CreateInstance().AsArray().Concat(primaryHandlers).ToArray());
                }
            }
        }
    }
}
