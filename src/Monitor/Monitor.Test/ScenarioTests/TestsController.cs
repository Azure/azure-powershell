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
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Storage.Version2017_10_01;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using RestTestFramework = Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.Commands.Insights.Test.ScenarioTests
{
    public sealed class TestsController : RMTestBase
    {
        private readonly EnvironmentSetupHelper _helper;

        public ResourceManagementClient ResourceManagementClient { get; private set; }

        public StorageManagementClient StorageManagementClient { get; private set; }

        public IMonitorManagementClient MonitorManagementClient { get; private set; }

        public static TestsController NewInstance => new TestsController();

        public TestsController()
        {
            _helper = new EnvironmentSetupHelper();
        }

        public void RunPsTest(ServiceManagement.Common.Models.XunitTracingInterceptor logger, params string[] scripts)
        {
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            _helper.TracingInterceptor = logger;
            RunPsTestWorkflow(
                () => scripts,
                // no custom cleanup 
                null,
                callingClassType,
                mockName);
        }

        public void RunPsTestWorkflow(
            Func<string[]> scriptBuilder,
            Action cleanup,
            string callingClassType,
            string mockName)
        {
            var providers = new Dictionary<string, string>()
            {
                { "Microsoft.Insights", null }
            };

            var providersToIgnore = new Dictionary<string, string>();
            providersToIgnore.Add("Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01");

            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(ignoreResourcesClient: true, providers: providers, userAgents: providersToIgnore);
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            using (RestTestFramework.MockContext context = RestTestFramework.MockContext.Start(callingClassType, mockName))
            {
                SetupManagementClients(context);

                _helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var callingClassName = callingClassType
                                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                                        .Last();
                _helper.SetupModules(AzureModule.AzureResourceManager,
                    _helper.RMProfileModule,
                    _helper.GetRMModulePath("AzureRM.Monitor.psd1"),
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    "AzureRM.Storage.ps1",
                    "AzureRM.Resources.ps1");

                try
                {
                    if (scriptBuilder != null)
                    {
                        var psScripts = scriptBuilder();

                        if (psScripts != null)
                        {
                            _helper.RunPowerShellTest(psScripts);
                        }
                    }
                }
                finally
                {
                    cleanup?.Invoke();
                }
            }
        }

        private void SetupManagementClients(RestTestFramework.MockContext context)
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                // This allows the use of a particular subscription if the user is associated to several
                // "TEST_CSM_ORGID_AUTHENTICATION=SubscriptionId=<subscription-id>"
                string subId = Environment.GetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION");
                RestTestFramework.TestEnvironment environment = new RestTestFramework.TestEnvironment(connectionString: subId);
                this.MonitorManagementClient = this.GetInsightsManagementClient(context: context, env: environment);
                ResourceManagementClient = this.GetResourceManagementClient(context: context, env: environment);
                StorageManagementClient = this.GetStorageManagementClient(context: context, env: environment);
            }
            else if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                this.MonitorManagementClient = this.GetInsightsManagementClient(context: context, env: null);
                ResourceManagementClient = this.GetResourceManagementClient(context: context, env: null);
                StorageManagementClient = this.GetStorageManagementClient(context: context, env: null);
            }

            _helper.SetupManagementClients(
                ResourceManagementClient,
                this.MonitorManagementClient,
                 StorageManagementClient);
        }

        private ResourceManagementClient GetResourceManagementClient(RestTestFramework.MockContext context, RestTestFramework.TestEnvironment env)
        {
            return env != null
                ? context.GetServiceClient<ResourceManagementClient>(currentEnvironment:env)
                : context.GetServiceClient<ResourceManagementClient>();
        }

        private IMonitorManagementClient GetInsightsManagementClient(RestTestFramework.MockContext context, RestTestFramework.TestEnvironment env)
        {
            return env != null 
                ? context.GetServiceClient<MonitorManagementClient>(currentEnvironment: env) 
                : context.GetServiceClient<MonitorManagementClient>();
        }

        private StorageManagementClient GetStorageManagementClient(RestTestFramework.MockContext context, RestTestFramework.TestEnvironment env)
        {
            return env != null
                ? context.GetServiceClient<StorageManagementClient>(currentEnvironment: env)
                : context.GetServiceClient<StorageManagementClient>();
        }
    }
}
