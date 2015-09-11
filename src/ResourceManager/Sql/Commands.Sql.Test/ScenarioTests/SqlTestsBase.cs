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

using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.Azure.Test;
using Microsoft.Azure.Graph.RBAC;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Commands.Resources.Models.ActiveDirectory;
using System;

namespace Microsoft.Azure.Commands.ScenarioTest.SqlTests
{
    public class SqlTestsBase
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
            helper.SetupSomeOfManagementClients(sqlCSMClient, storageClient, resourcesClient, authorizationClient, graphClient);
        }

        protected void RunPowerShellTest(params string[] scripts)
        {
            HttpMockServer.Matcher = new PermissiveRecordMatcher();
            // Enable undo functionality as well as mock recording
            using (UndoContext context = UndoContext.Current)
            {
                // Configure recordings
                context.Start(TestUtilities.GetCallingClass(2), TestUtilities.GetCurrentMethodName(2));

                SetupManagementClients();

                helper.SetupEnvironment();

                helper.SetupModules(AzureModule.AzureProfile, "ScenarioTests\\Common.ps1",
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
                }
                if (HttpMockServer.Variables.ContainsKey(DomainKey))
                {
                    UserDomain = HttpMockServer.Variables[DomainKey];
                }
            }

            return TestBase.GetGraphServiceClient<GraphRbacManagementClient>(testFactory, tenantId);
        }
    }
}
