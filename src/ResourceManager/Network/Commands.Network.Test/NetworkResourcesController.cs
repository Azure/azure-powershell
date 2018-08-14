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
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Redis;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.OperationalInsights;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Azure.Management.Internal.Resources;
using RestTestFramework = Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.Azure.Internal.Subscriptions;

namespace Commands.Network.Test
{
    public sealed class NetworkResourcesController
    {
        private readonly EnvironmentSetupHelper _helper;

        public SubscriptionClient SubscriptionClient { get; private set; }

        public NetworkManagementClient NetworkManagementClient { get; private set; }

        public ComputeManagementClient ComputeManagementClient { get; private set; }

        public StorageManagementClient StorageManagementClient { get; private set; }

        public RedisManagementClient RedisManagementClient { get; private set; }

        public OperationalInsightsManagementClient OperationalInsightsManagementClient { get; private set; }

        public static NetworkResourcesController NewInstance => new NetworkResourcesController();

        public NetworkResourcesController()
        {
            _helper = new EnvironmentSetupHelper();
        }

        public void RunPsTest(XunitTracingInterceptor logger, params string[] scripts)
        {
            _helper.TracingInterceptor = logger;
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("Microsoft.Resources", null);
            d.Add("Microsoft.Compute", null);
            d.Add("Microsoft.Features", null);
            d.Add("Microsoft.Authorization", null);
            d.Add("Microsoft.Storage", null);
            var providersToIgnore = new Dictionary<string, string>();
            providersToIgnore.Add("Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01");
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);

            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

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
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");
            using (RestTestFramework.MockContext context = RestTestFramework.MockContext.Start(callingClassType, mockName))
            {
                SetupManagementClients(context);

                _helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var callingClassName = callingClassType
                                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                                        .Last();

                string scenarioTestsDir = Path.Combine(Directory.GetCurrentDirectory(), "ScenarioTests");
                string psScriptPath = null;

                var testDirs = Directory.GetDirectories(scenarioTestsDir).ToList();
                testDirs.Insert(0, scenarioTestsDir);

                foreach (var dir in testDirs)
                {
                    var testPath = Path.Combine(dir, callingClassName + ".ps1");
                    if (File.Exists(testPath))
                    {
                        psScriptPath = testPath;
                        break;
                    }
                }

                if (psScriptPath == null)
                {
                    throw new FileNotFoundException(string.Format("Couldn't find ps1 file for test class '{0}'", callingClassName));
                }

                _helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\Common.ps1",
                    psScriptPath,
                    _helper.RMProfileModule,
                    _helper.GetRMModulePath("AzureRM.Insights.psd1"),
                    _helper.GetRMModulePath("AzureRM.Network.psd1"),
                    _helper.GetRMModulePath("AzureRM.Compute.psd1"),
                    _helper.GetRMModulePath("AzureRM.OperationalInsights.psd1"),
#if !NETSTANDARD
                    _helper.RMStorageDataPlaneModule,
#endif
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

        private static ResourceManagementClient GetResourceManagerResourceManagementClient(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        private void SetupManagementClients(RestTestFramework.MockContext context)
        {
            var resourceManagerResourceManagementClient = GetResourceManagerResourceManagementClient(context);
            NetworkManagementClient = GetNetworkManagementClient(context);
            ComputeManagementClient = GetComputeManagementClient(context);
            StorageManagementClient = GetStorageManagementClient(context);
            RedisManagementClient = GetRedisManagementClient(context);
            SubscriptionClient = GetSubscriptionClient(context);
            OperationalInsightsManagementClient = GetOperationalInsightsManagementClient(context);

            _helper.SetupManagementClients(
                resourceManagerResourceManagementClient,
                NetworkManagementClient,
                ComputeManagementClient,
                StorageManagementClient,
                RedisManagementClient,
                SubscriptionClient,
                OperationalInsightsManagementClient);
        }

        private static NetworkManagementClient GetNetworkManagementClient(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<NetworkManagementClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        private static SubscriptionClient GetSubscriptionClient(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<SubscriptionClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        private static StorageManagementClient GetStorageManagementClient(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<StorageManagementClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        private static RedisManagementClient GetRedisManagementClient(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<RedisManagementClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        private static ComputeManagementClient GetComputeManagementClient(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<ComputeManagementClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        private static OperationalInsightsManagementClient GetOperationalInsightsManagementClient(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<OperationalInsightsManagementClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }
}
}
