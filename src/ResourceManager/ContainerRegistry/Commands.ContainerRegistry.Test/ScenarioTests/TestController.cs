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
using System.IO;
using System.Linq;
using Microsoft.Azure.Management.ContainerRegistry;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using TestEnvironmentFactory = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory;
using TestUtilities = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities;

namespace Microsoft.Azure.Commands.ContainerRegistry.Test.ScenarioTests
{
    public class TestController
    {
        private EnvironmentSetupHelper helper;

        public ContainerRegistryManagementClient ContainerRegistryClient { get; private set; }

        public StorageManagementClient StorageClient { get; private set; }

        public ResourceManagementClient ResourceClient { get; private set; }
        
        public TestController()
        {
            helper = new EnvironmentSetupHelper();
        }

        public static TestController NewInstance
        {
            get
            {
                return new TestController();
            }
        }

        private void SetupManagementClients(MockContext context)
        {
            ContainerRegistryClient = GetContainerRegistryManagementClient(context);
            StorageClient = GetStorageManagementClient(context);
            ResourceClient = GetResourceManagementClient(context);
            helper.SetupManagementClients(ContainerRegistryClient, StorageClient, ResourceClient);
        }

        public void RunPowerShellTest(params string[] scripts)
        {
            var callingClassType = TestUtilities.GetCallingClass(2);
            var mockName = TestUtilities.GetCurrentMethodName(2);

            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");
            using (MockContext context = MockContext.Start(callingClassType, mockName))
            {
                SetupManagementClients(context);

                var callingClassName = callingClassType
                                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                                        .Last();
                helper.SetupEnvironment(AzureModule.AzureResourceManager);
                helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    "ScenarioTests\\Common.ps1",
                    helper.RMProfileModule,
                    helper.RMResourceModule,
                    helper.GetRMModulePath(@"AzureRM.ContainerRegistry.psd1"));

                if (scripts != null)
                {
                    helper.RunPowerShellTest(scripts);
                }
            }
        }

        private ContainerRegistryManagementClient GetContainerRegistryManagementClient(MockContext context)
        {
            return context.GetServiceClient<ContainerRegistryManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private StorageManagementClient GetStorageManagementClient(MockContext context)
        {
            return context.GetServiceClient<StorageManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}
