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
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Subscriptions;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public sealed class ProfileController
    {
        private CSMTestEnvironmentFactory csmTestFactory;
        private EnvironmentSetupHelper helper;
        private const string TenantIdKey = "TenantId";
        private const string DomainKey = "Domain";
        private const string SubscriptionIdKey = "SubscriptionId";


        public SubscriptionClient SubscriptionClient { get; private set; }

        public string UserDomain { get; private set; }

        public static ProfileController NewInstance
        {
            get { return new ProfileController(); }
        }

        public ProfileController()
        {
            helper = new EnvironmentSetupHelper();
        }

        public void RunPsTest(string tenant, params string[] scripts)
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
                mockName, tenant);
        }

        public void RunPsTestWorkflow(
            Func<string[]> scriptBuilder,
            Action<CSMTestEnvironmentFactory> initialize,
            Action cleanup,
            string callingClassType,
            string mockName, string tenant)
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
                var oldFactory = AzureSession.AuthenticationFactory as MockTokenAuthenticationFactory;
                AzureSession.AuthenticationFactory = new MockTokenAuthenticationFactory(oldFactory.Token.UserId, oldFactory.Token.AccessToken, tenant);

                var callingClassName = callingClassType
                    .Split(new[] {"."}, StringSplitOptions.RemoveEmptyEntries)
                    .Last();
                helper.SetupModules(AzureModule.AzureResourceManager, 
                    callingClassName + ".ps1", 
                    helper.RMProfileModule);

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
            SubscriptionClient = GetSubscriptionClient();

            helper.SetupManagementClients(SubscriptionClient);
        }

        private SubscriptionClient GetSubscriptionClient()
        {
            return TestBase.GetServiceClient<SubscriptionClient>(this.csmTestFactory);
        }
    }
}
