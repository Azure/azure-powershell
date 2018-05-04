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
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Management.Automation;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.Commands.Automation.Test
{
    public abstract class AutomationScenarioTestsBase : RMTestBase
    {
        private readonly EnvironmentSetupHelper _helper;

        protected AutomationScenarioTestsBase()
        {
            _helper = new EnvironmentSetupHelper();
        }

        protected void SetupManagementClients(MockContext context)
        {
            var automationManagementClient = GetAutomationManagementClient(context);

            _helper.SetupManagementClients(automationManagementClient);
        }

        protected void RunPowerShellTest(params string[] scripts)
        {
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            using (MockContext context = MockContext.Start(callingClassType, mockName))
            {
                SetupManagementClients(context);

                _helper.SetupEnvironment(AzureModule.AzureResourceManager);

                _helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\" + this.GetType().Name + ".ps1",
                    _helper.RMProfileModule,
                    _helper.GetRMModulePath(@"AzureRM.Automation.psd1"));

                _helper.RunPowerShellTest(scripts);
            }
        }

        protected AutomationManagementClient GetAutomationManagementClient(MockContext context)
        {
            return context.GetServiceClient<AutomationManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}
