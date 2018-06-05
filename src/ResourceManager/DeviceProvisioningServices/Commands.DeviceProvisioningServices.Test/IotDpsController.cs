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

using System.Diagnostics;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Management.DeviceProvisioningServices;
using Microsoft.Azure.Management.IotHub;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.IO;
using System.Linq;

namespace Commands.DeviceProvisioningServices.Test
{
    public sealed class IotDpsController
    {
        private readonly EnvironmentSetupHelper _helper;

        public ResourceManagementClient ResourceManagementClient { get; private set; }

        public IotHubClient IotHubClient { get; private set; }

        public IotDpsClient IotDpsClient { get; private set; }

        public static IotDpsController NewInstance => new IotDpsController();

        public IotDpsController()
        {
            _helper = new EnvironmentSetupHelper();
        }

        public void RunPsTest(params string[] scripts)
        {
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");
            using (MockContext context = MockContext.Start(callingClassType, mockName))
            {
                SetupManagementClients(context);

                _helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var callingClassName = callingClassType?.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();
                _helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    _helper.RMProfileModule,
                    _helper.GetRMModulePath(@"AzureRM.DeviceProvisioningServices.psd1"),
                    _helper.GetRMModulePath(@"AzureRM.IotHub.psd1"),
                    "AzureRM.Resources.ps1"
                    );

                _helper.RunPowerShellTest(scripts);
            }
        }

        private void SetupManagementClients(MockContext context)
        {
            ResourceManagementClient = GetResourceManagementClient(context);
            IotHubClient = GetIotHubClient(context);
            IotDpsClient = GetIotDpsClient(context);

            _helper.SetupManagementClients(
                ResourceManagementClient,
                IotHubClient,
                IotDpsClient
                );
        }

        private static ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static IotHubClient GetIotHubClient(MockContext context)
        {
            return context.GetServiceClient<IotHubClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static IotDpsClient GetIotDpsClient(MockContext context)
        {
            return context.GetServiceClient<IotDpsClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}

