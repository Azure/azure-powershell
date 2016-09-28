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
using Microsoft.Azure.Management.HDInsight;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System;
using System.Linq;

namespace Microsoft.Azure.Commands.HDInsight.Test
{
    public class HDInsightScenarioTestsBase : RMTestBase
    {
        private EnvironmentSetupHelper helper;
        private CSMTestEnvironmentFactory csmTestFactory;

        public static HDInsightScenarioTestsBase NewInstance
        {
            get
            {
                return new HDInsightScenarioTestsBase();
            }
        }

        protected HDInsightScenarioTestsBase()
        {
            helper = new EnvironmentSetupHelper();
        }

        protected void SetupManagementClients()
        {
            var hdinsightManagementClient = GetHdInsightManagementClient();

            helper.SetupSomeOfManagementClients(hdinsightManagementClient);
        }

        protected HDInsightManagementClient GetHdInsightManagementClient()
        {
            return TestBase.GetServiceClient<HDInsightManagementClient>(this.csmTestFactory);
        }

        /// <summary>
        /// Runs the PowerShell test
        /// </summary>
        /// <param name="scripts">script to be executed</param>
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

        /// <summary>
        /// Runs the PowerShell test under mock undo context based on the test mode setting (Record|Playback)
        /// </summary>
        /// <param name="scriptBuilder">Script builder delegate</param>
        /// <param name="initialize">initialize action</param>
        /// <param name="cleanup">cleanup action</param>
        /// <param name="callingClassType">Calling class type</param>
        /// <param name="mockName">Mock Name</param>
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
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    helper.RMProfileModule,
                    helper.RMResourceModule,
                    helper.GetRMModulePath("AzureRM.HDInsight.psd1"));

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
    }
}
