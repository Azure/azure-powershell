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

namespace Microsoft.Azure.Commands.ScenarioTest.WatmV2Tests
{
    using Microsoft.Azure.Common.Authentication;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Test;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;

    public class WatmV2TestsBase
    {
        private EnvironmentSetupHelper helper;

        protected WatmV2TestsBase()
        {
            this.helper = new EnvironmentSetupHelper();
        }

        protected void SetupManagementClients()
        {
            ResourceManagementClient resourcesClient = this.GetResourcesClient();
            this.helper.SetupSomeOfManagementClients(resourcesClient);
        }

        protected void RunPowerShellTest(params string[] scripts)
        {
            // Enable undo functionality as well as mock recording
            using (UndoContext context = UndoContext.Current)
            {
                // Configure recordings
                context.Start(TestUtilities.GetCallingClass(2), TestUtilities.GetCurrentMethodName(2));

                this.SetupManagementClients();

                this.helper.SetupEnvironment(AzureModule.AzureResourceManager);

                this.helper.SetupModules(AzureModule.AzureProfile, "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + this.GetType().Name + ".ps1");

                this.helper.RunPowerShellTest(scripts);
            }
        }

        protected ResourceManagementClient GetResourcesClient()
        {
            return TestBase.GetServiceClient<ResourceManagementClient>(new CSMTestEnvironmentFactory());
        }
    }
}
