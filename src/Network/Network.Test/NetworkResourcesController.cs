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
using Microsoft.Azure.Management.ContainerInstance;
using Microsoft.Azure.Management.ManagedServiceIdentity;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Redis;
using Microsoft.Azure.Management.OperationalInsights;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.Storage.Version2017_10_01;

namespace Commands.Network.Test
{
    public sealed class NetworkResourcesController
    {
        private readonly EnvironmentSetupHelper _helper;

        public NetworkManagementClient NetworkManagementClient { get; private set; }

        public ComputeManagementClient ComputeManagementClient { get; private set; }

        public ContainerInstanceManagementClient ContainerInstanceManagementClient { get; set; }

        public StorageManagementClient StorageManagementClient { get; private set; }

        public RedisManagementClient RedisManagementClient { get; private set; }

        public OperationalInsightsManagementClient OperationalInsightsManagementClient { get; private set; }

        public ManagedServiceIdentityClient ManagedServiceIdentityClient { get; private set; }

        public static NetworkResourcesController NewInstance => new NetworkResourcesController();

        public NetworkResourcesController()
        {
            _helper = new EnvironmentSetupHelper();
        }

        public void RunPsTest(XunitTracingInterceptor logger, params string[] scripts)
        {
            _helper.TracingInterceptor = logger;
            var d = new Dictionary<string, string>
            {
                {"Microsoft.Resources", null},
                {"Microsoft.Compute", null},
                {"Microsoft.Features", null},
                {"Microsoft.Authorization", null},
                {"Microsoft.Storage", null},
                {"Microsoft.ManagedServiceIdentity", null}
            };
            var providersToIgnore = new Dictionary<string, string>
            {
                {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"}
            };
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
            using (var context = MockContext.Start(callingClassType, mockName))
            {
                SetupManagementClients(context);

                _helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var callingClassName = callingClassType.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();
                var scenarioTestsDir = Path.Combine(Directory.GetCurrentDirectory(), "ScenarioTests");
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
                    _helper.GetRMModulePath("AzureRM.Monitor.psd1"),
                    _helper.GetRMModulePath("AzureRM.Network.psd1"),
                    _helper.GetRMModulePath("AzureRM.Compute.psd1"),
                    _helper.GetRMModulePath("AzureRM.ContainerInstance.psd1"),
                    _helper.GetRMModulePath("AzureRM.OperationalInsights.psd1"),
                    _helper.GetRMModulePath("AzureRM.ManagedServiceIdentity.psd1"),
                    "AzureRM.Storage.ps1",
                    _helper.GetRMModulePath("AzureRM.Storage.psd1"),
                    "AzureRM.Resources.ps1");

                try
                {
                    var psScripts = scriptBuilder?.Invoke();
                    if (psScripts != null)
                    {
                        _helper.RunPowerShellTest(psScripts);
                    }
                }
                finally
                {
                    cleanup?.Invoke();
                }
            }
        }

        private static ResourceManagementClient GetResourceManagerResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private void SetupManagementClients(MockContext context)
        {
            var resourceManagerResourceManagementClient = GetResourceManagerResourceManagementClient(context);
            NetworkManagementClient = GetNetworkManagementClient(context);
            ComputeManagementClient = GetComputeManagementClient(context);
            ContainerInstanceManagementClient = GetContainerInstanceManagementClient(context);
            StorageManagementClient = GetStorageManagementClient(context);
            RedisManagementClient = GetRedisManagementClient(context);
            OperationalInsightsManagementClient = GetOperationalInsightsManagementClient(context);
            ManagedServiceIdentityClient = GetManagedServiceIdentityClient(context);

            _helper.SetupManagementClients(
                resourceManagerResourceManagementClient,
                NetworkManagementClient,
                ComputeManagementClient,
                ContainerInstanceManagementClient,
                StorageManagementClient,
                RedisManagementClient,
                OperationalInsightsManagementClient,
                ManagedServiceIdentityClient);
        }

        private static ManagedServiceIdentityClient GetManagedServiceIdentityClient(MockContext context)
        {
            return context.GetServiceClient<ManagedServiceIdentityClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static NetworkManagementClient GetNetworkManagementClient(MockContext context)
        {
            return context.GetServiceClient<NetworkManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static StorageManagementClient GetStorageManagementClient(MockContext context)
        {
            return context.GetServiceClient<StorageManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static RedisManagementClient GetRedisManagementClient(MockContext context)
        {
            return context.GetServiceClient<RedisManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static ComputeManagementClient GetComputeManagementClient(MockContext context)
        {
            return context.GetServiceClient<ComputeManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static OperationalInsightsManagementClient GetOperationalInsightsManagementClient(MockContext context)
        {
            return context.GetServiceClient<OperationalInsightsManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static ContainerInstanceManagementClient GetContainerInstanceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ContainerInstanceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
}
}

