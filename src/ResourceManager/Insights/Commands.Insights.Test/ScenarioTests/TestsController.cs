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
using Microsoft.Azure.Insights;
using Microsoft.Azure.Management.Insights;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System;
using System.Linq;

namespace Microsoft.Azure.Commands.Insights.Test.ScenarioTests
{
    public sealed class TestsController : RMTestBase
    {
        private CSMTestEnvironmentFactory csmTestFactory;
        private EnvironmentSetupHelper helper;

        public IInsightsClient InsightsClient { get; private set; }
        public IInsightsManagementClient InsightsManagementClient { get; private set; }

        public string UserDomain { get; private set; }

        public static TestsController NewInstance
        {
            get
            {
                return new TestsController();
            }
        }

        public TestsController()
        {
            helper = new EnvironmentSetupHelper();
        }

        public void RunPsTest(params string[] scripts)
        {
            var callingClassType = TestUtilities.GetCallingClass(2);
            var mockName = TestUtilities.GetCurrentMethodName(2);

            RunPsTestWorkflow(
                () => scripts,
                // no custom initializer
                null,
                // no custom cleanup 
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
            using (UndoContext context = UndoContext.Current)
            {
                context.Start(callingClassType, mockName);

                this.csmTestFactory = new CSMTestEnvironmentFactory();

                if (initialize != null)
                {
                    initialize(this.csmTestFactory);
                }

                SetupManagementClients();

                helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var callingClassName = callingClassType
                                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                                        .Last();
                helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    helper.RMProfileModule,
                    helper.GetRMModulePath("AzureRM.Insights.psd1"));

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

        private void SetupManagementClients()
        {
            this.InsightsClient = this.GetInsightsClient();
            this.InsightsManagementClient = this.GetInsightsManagementClient();

            helper.SetupManagementClients(this.InsightsClient, this.InsightsManagementClient);
        }

        private IInsightsClient GetInsightsClient()
        {
            return TestBase.GetServiceClient<InsightsClient>(this.csmTestFactory);
        }

        private IInsightsManagementClient GetInsightsManagementClient()
        {
            return TestBase.GetServiceClient<InsightsManagementClient>(this.csmTestFactory);
        }
    }
}
