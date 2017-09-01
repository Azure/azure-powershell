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
using System.IO;
using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Management.ContainerInstance;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;

namespace Microsoft.Azure.Commands.ContainerInstance.Test.ScenarioTests
{
    public class TestController
    {
        private EnvironmentSetupHelper helper;

        public ContainerInstanceManagementClient ContainerInstanceClient { get; private set; }

        public ResourceManagementClient ResourceClient { get; private set; }

        public Management.ResourceManager.ResourceManagementClient OldResourceClient { get; private set; }

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

        public void RunPowerShellTest(params string[] scripts)
        {
            var callingClassType = TestUtilities.GetCallingClass(2);
            var mockName = TestUtilities.GetCurrentMethodName(2);

            Dictionary<string, string> providers = new Dictionary<string, string>()
            {
                { "Microsoft.Resources", null },
                { "Microsoft.Features", null },
                { "Microsoft.Authorization", null },
                { "Microsoft.Compute", null }
            };

            var providersToIgnore = new Dictionary<string, string>()
            {
                { "Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01" }
            };

            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, providers, providersToIgnore);
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
                    helper.GetRMModulePath(@"AzureRM.ContainerInstance.psd1"));

                if (scripts != null)
                {
                    helper.RunPowerShellTest(scripts);
                }
            }
        }

        private void SetupManagementClients(MockContext context)
        {
            this.ResourceClient = this.GetResourceManagementClient(context);
            this.OldResourceClient = this.GetOldResourceManagementClient(context);
            this.ContainerInstanceClient = this.GetContainerInstanceManagementClient(context);
            this.helper.SetupManagementClients(this.ResourceClient, this.OldResourceClient, this.ContainerInstanceClient);
        }

        private ContainerInstanceManagementClient GetContainerInstanceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ContainerInstanceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private Management.ResourceManager.ResourceManagementClient GetOldResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<Management.ResourceManager.ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}
