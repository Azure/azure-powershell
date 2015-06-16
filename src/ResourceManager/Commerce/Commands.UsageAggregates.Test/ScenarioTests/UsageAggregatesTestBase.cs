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
using Microsoft.Azure.Commerce.UsageAggregates;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Commands.ScenarioTest;

namespace  Microsoft.Azure.Commands.UsageAggregates.Test.ScenarioTests
{
    public abstract class UsageAggregatesTestBase : IDisposable
    {
        private EnvironmentSetupHelper helper;

        protected UsageAggregatesTestBase()
        {
            helper = new EnvironmentSetupHelper();
        }

        protected void SetupManagementClients()
        {
            var usageManagementClient = GetUsageAggregatesManagementClient();
            helper.SetupManagementClients(usageManagementClient);
        }

        protected void RunPowerShellTest(params string[] scripts)
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start(TestUtilities.GetCallingClass(2), TestUtilities.GetCurrentMethodName(2));

                SetupManagementClients();

                helper.SetupEnvironment(AzureModule.AzureResourceManager);
                helper.SetupModules(AzureModule.AzureResourceManager, "ScenarioTests\\" + this.GetType().Name + ".ps1");

                helper.RunPowerShellTest(scripts);
            }
        }

        protected UsageAggregationManagementClient GetUsageAggregatesManagementClient()
        {
            return TestBase.GetServiceClient<UsageAggregationManagementClient>(new CSMTestEnvironmentFactory());
        }

        public void Dispose()
        {
        }
    }
}
