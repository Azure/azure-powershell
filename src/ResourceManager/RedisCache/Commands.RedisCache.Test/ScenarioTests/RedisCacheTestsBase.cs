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

namespace Microsoft.Azure.Commands.RedisCache.Test.ScenarioTests
{
    using System;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Microsoft.Azure.Test;
    using Microsoft.Azure.Management.Redis;
    using WindowsAzure.Commands.Test.Utilities.Common;
    using Microsoft.Azure.Management.Insights;
    using Microsoft.Azure.Management.Internal.Resources;

    public abstract class RedisCacheTestsBase : RMTestBase, IDisposable
    {
        private EnvironmentSetupHelper helper;

        protected RedisCacheTestsBase()
        {
            helper = new EnvironmentSetupHelper();
        }

        protected void SetupManagementClients()
        {
            object[] managementClients = new object[3];
            managementClients[0] = GetRedisManagementClient();
            managementClients[1] = GetInsightsManagementClient();
            managementClients[2] = GetResourceManagementClient();
            helper.SetupManagementClients(managementClients);
        }

        protected void RunPowerShellTest(params string[] scripts)
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start(TestUtilities.GetCallingClass(2), TestUtilities.GetCurrentMethodName(2));

                SetupManagementClients();

                helper.SetupEnvironment(AzureModule.AzureResourceManager);
                helper.SetupModules(AzureModule.AzureResourceManager, 
                    "ScenarioTests\\" + this.GetType().Name + ".ps1", 
                    helper.RMProfileModule, 
                    helper.GetRMModulePath(@"AzureRM.RedisCache.psd1"));

                helper.RunPowerShellTest(scripts);
            }
        }

        protected RedisManagementClient GetRedisManagementClient()
        {
            return TestBase.GetServiceClient<RedisManagementClient>(new CSMTestEnvironmentFactory());
        }

        protected InsightsManagementClient GetInsightsManagementClient()
        {
            return TestBase.GetServiceClient<InsightsManagementClient>(new CSMTestEnvironmentFactory());
        }

        protected ResourceManagementClient GetResourceManagementClient()
        {
            return TestBase.GetServiceClient<ResourceManagementClient>(new CSMTestEnvironmentFactory());
        }

        public void Dispose()
        {
        }
    }
}
