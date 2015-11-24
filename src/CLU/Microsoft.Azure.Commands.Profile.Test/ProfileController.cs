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
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Commands.ScenarioTest;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public sealed class ProfileController
    {
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

        public void RunPsTest(string tenant, string callingClassType, string mockName, string[] scripts)
        {
            RunPsTestWorkflow(
                () => scripts,
                // no custom cleanup 
                null,
                callingClassType,
                mockName, tenant);
        }

        public void RunPsTestWorkflow(
            Func<string[]> scriptBuilder,
            Action cleanup,
            string callingClassType,
            string mockName, string tenant)
        {
            using (MockContext context = MockContext.Start(callingClassType, mockName))
            {


                SetupManagementClients();

                helper.SetupEnvironment(AzureModule.AzureResourceManager);

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
        }


        private SubscriptionClient GetSubscriptionClient()
        {
            throw new NotImplementedException();
        }
    }
}
