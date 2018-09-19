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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Test;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Test.ScenarioTests
{
    using Microsoft.Azure.Commands.Common.Authentication;
    using WindowsAzure.Management.Network;

    public abstract class NetworkTestsBase
    {
        private const string testsFilePath = @"ScenarioTests\NetworkTests.ps1";

        private readonly EnvironmentSetupHelper helper;

        protected NetworkTestsBase()
        {
            helper = new EnvironmentSetupHelper();
        }

        protected void SetupManagementClients()
        {
            NetworkManagementClient networkManagementClient = GetNetworkManagementClient();

            helper.SetupManagementClients(networkManagementClient);
        }

        protected void RunPowerShellTest(params string[] scripts)
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start(TestUtilities.GetCallingClass(2), TestUtilities.GetCurrentMethodName(2));

                SetupManagementClients();

                helper.SetupEnvironment(AzureModule.AzureServiceManagement);
                helper.SetupModules(AzureModule.AzureServiceManagement, testsFilePath);

                helper.RunPowerShellTest(scripts);
            }
        }

        protected NetworkManagementClient GetNetworkManagementClient()
        {
            return TestBase.GetServiceClient<NetworkManagementClient>(new RDFETestEnvironmentFactory());
        }
    }
}
