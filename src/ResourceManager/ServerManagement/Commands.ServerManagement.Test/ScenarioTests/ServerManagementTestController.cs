// Copyright Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// 
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Microsoft.Azure.Commands.ServerManagement.Test.ScenarioTests
{
    using System;
    using System.IO;
    using System.Linq;
    using WindowsAzure.Commands.ScenarioTest;
    using Common.Authentication;
    using Management.ServerManagement;
    using Rest.ClientRuntime.Azure.TestFramework;

    /// <summary>
    ///     Test controller for executing Intune test cases.
    /// </summary>
    public class ServerManagementTestController
    {
        private readonly EnvironmentSetupHelper helper;

        public ServerManagementClient ServerManagementClient { get; private set; }

        /// <summary>
        ///     Creating a new instance of the ServerManagementTestController.
        /// </summary>
        public static ServerManagementTestController NewInstance
        {
            get { return new ServerManagementTestController(); }
        }

        /// <summary>
        ///     Parameterless constructor.
        /// </summary>
        public ServerManagementTestController()
        {
            InitializeEnvironment();
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
            using (var context = MockContext.Start(callingClassType, mockName))
            {
                SetupManagementClients(context);

                var callingClassName = callingClassType
                    .Split(new[] {"."}, StringSplitOptions.RemoveEmptyEntries)
                    .Last();
                helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    helper.GetRMModulePath(@"AzureRM.Profile.psd1"),
                    helper.GetRMModulePath(@"AzureRM.Resources.psd1"),
                    helper.GetRMModulePath(@"AzureRM.ServerManagement.psd1"));

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
            ServerManagementClient = GetServerManagementClient(context);

            helper.SetupManagementClients(ServerManagementClient);
        }

        private ServerManagementClient GetServerManagementClient(MockContext context)
        {
            return context.GetServiceClient<ServerManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        internal static void InitializeEnvironment()
        {
#if DEBUG_INTERACTIVE
            Environment.SetEnvironmentVariable("AZURE_TEST_ENVIRONMENT", "production");
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Record");
            Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION",
                "SubscriptionId=3e82a90d-d19e-42f9-bb43-9112945846ef; BaseUri = https://management.azure.com/;AADAuthEndpoint=https://login.windows.net/");
#endif 
        }
    }
}