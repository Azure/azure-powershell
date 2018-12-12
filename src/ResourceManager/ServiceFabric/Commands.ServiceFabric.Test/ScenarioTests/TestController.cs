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
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Azure.Management.ServiceFabric;
using Microsoft.Azure.Commands.Common.Compute.Version_2018_04;
using Microsoft.Azure.Commands.Common.KeyVault.Version2016_10_1;
using Microsoft.Azure.Commands.ServiceFabric.Commands;
using Microsoft.Azure.Management.Storage.Version2017_10_01;
using Microsoft.Azure.Management.Internal.Network.Version2017_10_01;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.ServiceManagement.Common.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Test.ScenarioTests
{
    public class TestController
    {
        private readonly EnvironmentSetupHelper _helper;

        public ResourceManagementClient NewResourceManagementClient { get; private set; }

        public ServiceFabricManagementClient ServiceFabricClient { get; private set; }

        public ComputeManagementClient ComputeManagementClient { get; private set; }

        public KeyVaultManagementClient KeyVaultManagementClient { get; private set; }

        public StorageManagementClient StorageManagementClient { get; private set; }

        public NetworkManagementClient NetworkManagementClient { get; private set; }

        public static TestController NewInstance => new TestController();

        public TestController()
        {
            _helper = new EnvironmentSetupHelper();
        }

        public void RunPsTest(XunitTracingInterceptor logger, params string[] scripts)
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
            var d = new Dictionary<string, string>
            {
                {"Microsoft.Resources", null},
                {"Microsoft.Features", null},
                {"Microsoft.Authorization", null},
                {"Microsoft.KeyVault", null}
            };
            var providersToIgnore = new Dictionary<string, string>
            {
                {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"}
            };
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            using (var context = MockContext.Start(callingClassType, mockName))
            {
                SetupManagementClients(context);

                _helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var callingClassName = callingClassType.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();

                _helper.SetupModules(AzureModule.AzureResourceManager,
                    _helper.RMProfileModule,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    "AzureRM.Resources.ps1",
                    _helper.GetRMModulePath("AzureRM.ServiceFabric.psd1"));

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
                    ServiceFabricCmdletBase.TestAppCert = false;
                    cleanup?.Invoke();
                }
            }
        }

        private void SetupManagementClients(MockContext context)
        {
            ServiceFabricClient = GetServiceFabricManagementClient(context);
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                ServiceFabricClient.LongRunningOperationRetryTimeout = 20;
            }

            ComputeManagementClient = GetComputeManagementClient(context);
            KeyVaultManagementClient = GetKeyVaultManagementClient(context);
            StorageManagementClient = GetStorageManagementClient(context);
            NetworkManagementClient = GetNetworkManagementClient(context);
            NewResourceManagementClient = GetNewResourceManagementClient(context);

            _helper.SetupManagementClients(
                ServiceFabricClient,
                ComputeManagementClient,
                KeyVaultManagementClient,
                StorageManagementClient,
                NetworkManagementClient,
                NewResourceManagementClient);
        }

        private static ServiceFabricManagementClient GetServiceFabricManagementClient(MockContext context)
        {
            return context.GetServiceClient<ServiceFabricManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static ComputeManagementClient GetComputeManagementClient(MockContext context)
        {
            return context.GetServiceClient<ComputeManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static KeyVaultManagementClient GetKeyVaultManagementClient(MockContext context)
        {
            return context.GetServiceClient<KeyVaultManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static StorageManagementClient GetStorageManagementClient(MockContext context)
        {
            return context.GetServiceClient<StorageManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static NetworkManagementClient GetNetworkManagementClient(MockContext context)
        {
            return context.GetServiceClient<NetworkManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static ResourceManagementClient GetNewResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}