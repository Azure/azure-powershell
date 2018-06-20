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


namespace Commands.Network.Test
{
    public sealed class NetworkResourcesController
    {
        private readonly EnvironmentSetupHelper _helper;

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

        public void RunPsTest(params string[] scripts)
        {
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
                _helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    _helper.RMProfileModule,
                    _helper.RMResourceModule,
                    _helper.GetRMModulePath("AzureRM.Insights.psd1"),
                    _helper.GetRMModulePath("AzureRM.Network.psd1"),
                    _helper.GetRMModulePath("AzureRM.Compute.psd1"),
                    _helper.GetRMModulePath("AzureRM.OperationalInsights.psd1"),
                    _helper.RMStorageDataPlaneModule,
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
            OperationalInsightsManagementClient = GetOperationalInsightsManagementClient(context);

            _helper.SetupManagementClients(
                resourceManagerResourceManagementClient,
                NetworkManagementClient,
                ComputeManagementClient,
                StorageManagementClient,
                RedisManagementClient,
                OperationalInsightsManagementClient);
        }

        private static NetworkManagementClient GetNetworkManagementClient(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<NetworkManagementClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
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
