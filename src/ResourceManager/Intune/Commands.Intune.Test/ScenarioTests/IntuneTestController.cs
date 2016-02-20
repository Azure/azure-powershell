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
namespace Microsoft.Azure.Commands.Intune.Test.ScenarioTests
{
    using Microsoft.Azure.Common.Authentication;
    using Microsoft.Azure.Management.Intune;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using TestEnvironmentFactory = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory;
    using TestUtilities = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities;

    /// <summary>
    /// Test controller for executing Intune test cases.
    /// </summary>
    public class IntuneTestController
    {
        private EnvironmentSetupHelper helper;

        public IntuneResourceManagementClient IntuneManagementClient { get; private set; }

        /// <summary>
        /// Creating a new instance of the IntuneTestController.
        /// </summary>
        public static IntuneTestController NewInstance
        {
            get
            {
                return new IntuneTestController();
            }
        }

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public IntuneTestController()
        {
            IntuneTestController.InitializeEnvironment();
            helper = new EnvironmentSetupHelper();
        }

        public void RunPsTest(params string[] scripts)
        {
            var callingClassType = TestUtilities.GetCallingClass(2);
            var mockName = TestUtilities.GetCurrentMethodName(2);

            RunPsTestWorkflow(
                () => scripts,
                // no custom cleanup 
                null,
                callingClassType,
                mockName);
        }


        private void RunPsTestWorkflow(
            Func<string[]> scriptBuilder,
            Action cleanup,
            string callingClassType,
            string mockName)
        {
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");
            using (MockContext context = MockContext.Start(callingClassType, mockName))
            {
                SetupManagementClients(context);
                //helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var callingClassName = callingClassType
                                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                                        .Last();
                helper.SetupModules(AzureModule.AzureResourceManager,
                    // "ScenarioTests\\Common.ps1", 
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    helper.GetRMModulePath(@"AzureRM.Profile.psd1"),
                    helper.GetRMModulePath(@"AzureRM.Resources.psd1"),
                    helper.GetRMModulePath(@"AzureRM.Intune.psd1"));

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
            IntuneManagementClient = GetIntuneManagementClient(context);

            helper.SetupManagementClients(IntuneManagementClient);
        }

        private IntuneResourceManagementClient GetIntuneManagementClient(MockContext context)
        {
            return context.GetServiceClient<IntuneResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        internal static void InitializeEnvironment()
        {
            //Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", "SubscriptionId=None;Environment=Prod;UserId=admin@IntuneAzureCLIMSUA06.onmicrosoft.com;Password=XXXXXX");
            //AZURE_TEST_MODE = None, Record, Playback
            //Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
        }
    }
}
