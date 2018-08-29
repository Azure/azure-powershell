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
using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Management.Automation;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.Azure.Test.HttpRecorder;
using System.Reflection;
using Microsoft.Rest;
using System.Net.Http;
using Microsoft.Azure.ServiceManagemenet.Common.Models;

namespace Microsoft.Azure.Commands.Automation.Test
{
    public abstract class AutomationScenarioTestsBase : RMTestBase
    {
        private EnvironmentSetupHelper helper;

        protected AutomationScenarioTestsBase()
        {
            helper = new EnvironmentSetupHelper();
        }

        protected void SetupManagementClients()
        {
            var automationManagementClient = GetAutomationManagementClient();

            helper.SetupManagementClients(automationManagementClient);
        }

        protected void RunPowerShellTest(XunitTracingInterceptor logger, params string[] scripts)
        {
            const string RootNamespace = "ScenarioTests";

            using (UndoContext context = UndoContext.Current)
            {
                context.Start(TestUtilities.GetCallingClass(2), TestUtilities.GetCurrentMethodName(2));

                SetupManagementClients();

                helper.SetupEnvironment(AzureModule.AzureResourceManager);


                var psModuleFile = this.GetType().FullName.Contains(RootNamespace) ?
                    this.GetType().FullName.Split(new[] { RootNamespace }, StringSplitOptions.RemoveEmptyEntries).Last().Replace(".", "\\") :
                    $"\\{this.GetType().Name}";

                helper.SetupModules(AzureModule.AzureResourceManager,
                    $"{RootNamespace}{psModuleFile}.ps1",
                    helper.RMProfileModule,
                    helper.GetRMModulePath(@"AzureRM.Automation.psd1"));

                helper.RunPowerShellTest(scripts);
            }
        }

        protected AutomationClient GetAutomationManagementClient()
        {
            AutomationClient client;
            TestEnvironment currentEnvironment = new CSMTestEnvironmentFactory().GetTestEnvironment();
            var credentials = currentEnvironment.AuthorizationContext.TokenCredentials[TokenAudience.Management];

            HttpMockServer server;

            try
            {
                server = HttpMockServer.CreateInstance();
            }
            catch (ApplicationException)
            {
                // mock server has never been initialized, we will need to initialize it.
                HttpMockServer.Initialize("TestEnvironment", "InitialCreation");
                server = HttpMockServer.CreateInstance();
            }

            if (currentEnvironment.UsesCustomUri())
            {
                ConstructorInfo constructor = typeof(AutomationClient).GetConstructor(new Type[] { typeof(Uri), typeof(ServiceClientCredentials), typeof(DelegatingHandler[]) });
                client = constructor.Invoke(new object[] { currentEnvironment.BaseUri, credentials, new DelegatingHandler[] { server } }) as AutomationClient;
            }
            else
            {
                ConstructorInfo constructor = typeof(AutomationClient).GetConstructor(new Type[] { typeof(ServiceClientCredentials) });
                client = constructor.Invoke(new object[] { credentials }) as AutomationClient;
            }

            PropertyInfo subId = typeof(AutomationClient).GetProperty("SubscriptionId", typeof(string));
            if (subId != null)
            {
                subId.SetValue(client, currentEnvironment.SubscriptionId);
            }

            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                PropertyInfo initialTimeout = typeof(AutomationClient).GetProperty("LongRunningOperationInitialTimeout", typeof(int));
                PropertyInfo retryTimeout = typeof(AutomationClient).GetProperty("LongRunningOperationRetryTimeout", typeof(int));
                if (initialTimeout != null && retryTimeout != null)
                {
                    initialTimeout.SetValue(client, 0);
                    retryTimeout.SetValue(client, 0);
                }
            }

            return client;
        }
    }
}
