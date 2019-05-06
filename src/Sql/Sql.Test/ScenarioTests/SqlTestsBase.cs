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
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Sql;
using CommonStorage = Microsoft.Azure.Management.Storage.Version2017_10_01;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit.Abstractions;
using Microsoft.Azure.Management.EventHub;
using Microsoft.Azure.Management.OperationalInsights;
using SDKMonitor = Microsoft.Azure.Management.Monitor;
using CommonMonitor = Microsoft.Azure.Management.Monitor.Version2018_09_01;

namespace Microsoft.Azure.Commands.ScenarioTest.SqlTests
{
    public class SqlTestsBase : RMTestBase
    {
        protected EnvironmentSetupHelper Helper;

        protected SqlTestsBase(ITestOutputHelper output)
        {
            Helper = new EnvironmentSetupHelper();

            var tracer = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(tracer);
            Helper.TracingInterceptor = tracer;
        }

        protected virtual void SetupManagementClients(MockContext context)
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

            var d = new Dictionary<string, string>
            {
                {"Microsoft.Resources", null},
                {"Microsoft.Features", null},
                {"Microsoft.Authorization", null},
                {"Microsoft.Network", null}
            };
            var providersToIgnore = new Dictionary<string, string>
            {
                {"Microsoft.Azure.Graph.RBAC.Version1_6.GraphRbacManagementClient", "1.42-previewInternal"},
                {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"}
            };
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            // Enable undo functionality as well as mock recording
            using (var context = MockContext.Start(callingClassType, mockName))
            {
                SetupManagementClients(context);
                Helper.SetupEnvironment(AzureModule.AzureResourceManager);
                Helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + GetType().Name + ".ps1",
                    Helper.RMProfileModule,
                    Helper.GetRMModulePath(@"AzureRM.Sql.psd1"),
                    Helper.RMNetworkModule,
                    "AzureRM.Storage.ps1",
                    "AzureRM.Resources.ps1",
                    Helper.RMOperationalInsightsModule,
                    Helper.RMEventHubModule,
                    Helper.RMMonitorModule);
                Helper.RunPowerShellTest(scripts);
            }
        }

        protected SqlManagementClient GetSqlClient(MockContext context)
        {
            return context.GetServiceClient<SqlManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        protected SDKMonitor.IMonitorManagementClient GetMonitorManagementClient(MockContext context)
        {
            return context.GetServiceClient<SDKMonitor.MonitorManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        protected CommonMonitor.IMonitorManagementClient GetCommonMonitorManagementClient(MockContext context)
        {
            return context.GetServiceClient<CommonMonitor.MonitorManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        protected IEventHubManagementClient GetEventHubManagementClient(MockContext context)
        {
            return context.GetServiceClient<EventHubManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        protected IOperationalInsightsManagementClient GetOperationalInsightsManagementClient(MockContext context)
        {
            return context.GetServiceClient<OperationalInsightsManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        protected ResourceManagementClient GetResourcesClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        protected NetworkManagementClient GetNetworkClient(MockContext context)
        {
            return context.GetServiceClient<NetworkManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        protected static CommonStorage.StorageManagementClient GetStorageManagementClient(MockContext context)
        {
            return context.GetServiceClient<CommonStorage.StorageManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

    }
}
