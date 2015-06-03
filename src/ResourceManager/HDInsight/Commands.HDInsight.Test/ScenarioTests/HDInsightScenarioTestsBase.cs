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

using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Management.HDInsight;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;

namespace Microsoft.Azure.Commands.HDInsight.Test
{
    public abstract class HDInsightScenarioTestsBase
    {
        private EnvironmentSetupHelper helper;

        protected HDInsightScenarioTestsBase()
        {
            helper = new EnvironmentSetupHelper();
        }

        protected void SetupManagementClients()
        {
            var hdinsightManagementClient = GetHdInsightManagementClient();

            helper.SetupManagementClients(hdinsightManagementClient);
        }

        protected HDInsightManagementClient GetHdInsightManagementClient()
        {
            return TestBase.GetServiceClient<HDInsightManagementClient>(new CSMTestEnvironmentFactory());
        }

        protected void RunPowerShellTest(params string[] scripts)
        {
            SetupManagementClients();

            helper.SetupEnvironment(AzureModule.AzureResourceManager);
            helper.SetupModules(AzureModule.AzureResourceManager, //"ScenarioTests\\Common.ps1",
                "ScenarioTests\\" + this.GetType().Name + ".ps1");

            helper.RunPowerShellTest(scripts);
        }
    }
}
