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

namespace Commands.DeviceProvisioningServices.Test
{
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Management.DeviceProvisioningServices;
    using Microsoft.Azure.Management.IotHub;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Test;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using RestTestFramework = Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using TestBase = Microsoft.Azure.Test.TestBase;
    using TestUtilities = Microsoft.Azure.Test.TestUtilities;

    public sealed class IotDpsController
    {
        private CSMTestEnvironmentFactory csmTestFactory;
        private EnvironmentSetupHelper helper;

        public ResourceManagementClient ResourceManagementClient { get; private set; }

        public IotHubClient IotHubClient { get; private set; }

        public IotDpsClient IotDpsClient { get; private set; }

        public static IotDpsController NewInstance
        {
            get
            {
                return new IotDpsController();
            }
        }

        public IotDpsController()
        {
            helper = new EnvironmentSetupHelper();
        }

        public void RunPsTest(params string[] scripts)
        {
            var callingClassType = TestUtilities.GetCallingClass(2);
            var mockName = TestUtilities.GetCurrentMethodName(2);

            RunPsTestWorkflow(
                () => scripts,
                null,
                null,
                callingClassType,
                mockName);
        }


        public void RunPsTestWorkflow(
            Func<string[]> scriptBuilder,
            Action<CSMTestEnvironmentFactory> initialize,
            Action cleanup,
            string callingClassType,
            string mockName)
        {
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");
            using (MockContext context = MockContext.Start(callingClassType, mockName))
            {
                this.csmTestFactory = new CSMTestEnvironmentFactory();
                if (initialize != null)
                {
                    initialize(this.csmTestFactory);
                }
                SetupManagementClients(context);

                helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var callingClassName = callingClassType
                                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                                        .Last();
                helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    helper.RMProfileModule,
                    helper.RMResourceModule,
                    helper.GetRMModulePath(@"AzureRM.DeviceProvisioningServices.psd1"),
                    helper.GetRMModulePath(@"AzureRM.IotHub.psd1"),
                    "AzureRM.Resources.ps1"
                    );

                try
                {
                    if (scriptBuilder != null)
                    {
                        var psScripts = scriptBuilder();

                        if (psScripts != null)
                        {
                            helper.RunPowerShellTest(psScripts);
                        }
                    }
                }
                finally
                {
                    if (cleanup != null)
                    {
                        cleanup();
                    }
                }
            }
        }

        private void SetupManagementClients(MockContext context)
        {
            ResourceManagementClient = GetResourceManagementClient();
            IotHubClient = GetIotHubClient(context);
            IotDpsClient = GetIotDpsClient(context);

            helper.SetupManagementClients(
                ResourceManagementClient,
                IotHubClient,
                IotDpsClient
                );
        }

        private ResourceManagementClient GetResourceManagementClient()
        {
            return TestBase.GetServiceClient<ResourceManagementClient>(this.csmTestFactory);
        }

        private IotHubClient GetIotHubClient(MockContext context)
        {
            return context.GetServiceClient<IotHubClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        private IotDpsClient GetIotDpsClient(MockContext context)
        {
            return context.GetServiceClient<IotDpsClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}

