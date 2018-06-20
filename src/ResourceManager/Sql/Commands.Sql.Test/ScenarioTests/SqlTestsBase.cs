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
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Xunit.Abstractions;
using RestTestFramework = Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.Commands.ScenarioTest.SqlTests
{
    using Graph.RBAC;
    using Common.Authentication.Abstractions;
    using System.IO;

    public class SqlTestsBase : RMTestBase
    {
        protected EnvironmentSetupHelper Helper;

        private const string TenantIdKey = "TenantId";
        private const string DomainKey = "Domain";

        public string UserDomain { get; private set; }

        protected SqlTestsBase(ITestOutputHelper output)
        {
            Helper = new EnvironmentSetupHelper();

            XunitTracingInterceptor tracer = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(tracer);
            Helper.TracingInterceptor = tracer;
        }

        protected virtual void SetupManagementClients(RestTestFramework.MockContext context)
        {
            var sqlClient = GetSqlClient(context);
            var newResourcesClient = GetResourcesClient(context);
            Helper.SetupSomeOfManagementClients(sqlClient, newResourcesClient);
        }

        protected void RunPowerShellTest(params string[] scripts)
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("Microsoft.Resources", null);
            d.Add("Microsoft.Features", null);
            d.Add("Microsoft.Authorization", null);
            d.Add("Microsoft.Network", null);
            var providersToIgnore = new Dictionary<string, string>();
            providersToIgnore.Add("Microsoft.Azure.Graph.RBAC.Version1_6.GraphRbacManagementClient", "1.42-previewInternal");
            providersToIgnore.Add("Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01");
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            // Enable undo functionality as well as mock recording
            using (RestTestFramework.MockContext context = RestTestFramework.MockContext.Start(callingClassType, mockName))
            {
                SetupManagementClients(context);

                Helper.SetupEnvironment(AzureModule.AzureResourceManager);

                Helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + this.GetType().Name + ".ps1",
                    Helper.RMProfileModule,
                    Helper.RMStorageDataPlaneModule,
                    Helper.GetRMModulePath(@"AzureRM.Sql.psd1"),
                    Helper.RMNetworkModule,
                    "AzureRM.Storage.ps1",
                    "AzureRM.Resources.ps1");
                Helper.RunPowerShellTest(scripts);
            }
        }

        protected Management.Sql.SqlManagementClient GetSqlClient(RestTestFramework.MockContext context)
        {
            Management.Sql.SqlManagementClient client =
                context.GetServiceClient<Management.Sql.SqlManagementClient>(
                    RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                client.LongRunningOperationRetryTimeout = 0;
            }
            return client;
        }

        protected Management.Internal.Resources.ResourceManagementClient GetResourcesClient(RestTestFramework.MockContext context)
        {
            Management.Internal.Resources.ResourceManagementClient client =
                context.GetServiceClient<Management.Internal.Resources.ResourceManagementClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                client.LongRunningOperationRetryTimeout = 0;
            }
            return client;
        }

        protected NetworkManagementClient GetNetworkClient(RestTestFramework.MockContext context)
        {
            NetworkManagementClient client =
                context.GetServiceClient<NetworkManagementClient>(
                    RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                client.LongRunningOperationRetryTimeout = 0;
            }
            return client;
        }

        protected GraphRbacManagementClient GetGraphClient(RestTestFramework.MockContext context)
        {
            var environment = RestTestFramework.TestEnvironmentFactory.GetTestEnvironment();
            string tenantId = null;

            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                tenantId = environment.Tenant;
                UserDomain = environment.UserName.Split(new[] { "@" }, StringSplitOptions.RemoveEmptyEntries).Last();

                HttpMockServer.Variables[TenantIdKey] = tenantId;
                HttpMockServer.Variables[DomainKey] = UserDomain;
            }
            else if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                if (HttpMockServer.Variables.ContainsKey(TenantIdKey))
                {
                    tenantId = HttpMockServer.Variables[TenantIdKey];
                    AzureRmProfileProvider.Instance.Profile.DefaultContext.Tenant.Id = tenantId;
                }
                if (HttpMockServer.Variables.ContainsKey(DomainKey))
                {
                    UserDomain = HttpMockServer.Variables[DomainKey];
                    AzureRmProfileProvider.Instance.Profile.DefaultContext.Tenant.Directory = UserDomain;
                }
            }

            var client = context.GetGraphServiceClient<GraphRbacManagementClient>(environment);
            client.TenantID = tenantId;
            return client;
        }

        protected StorageManagementClient GetStorageV2Client(RestTestFramework.MockContext context)
        {
#if NETSTANDARD
            var client = context.GetServiceClient<StorageManagementClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
#else
            var client = TestBase.GetServiceClient<StorageManagementClient>(new CSMTestEnvironmentFactory());
#endif

            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
#if !NETSTANDARD
                client.LongRunningOperationInitialTimeout = 0;
#endif
                client.LongRunningOperationRetryTimeout = 0;
            }
            return client;
        }
    }
}
