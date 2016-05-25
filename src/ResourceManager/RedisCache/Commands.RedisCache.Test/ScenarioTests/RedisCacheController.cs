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
using Microsoft.Azure.Management.Insights;
using Microsoft.Azure.Management.Redis;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.IO;
using System.Linq;
using LegacyTest = Microsoft.Azure.Test;
using TestEnvironmentFactory = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory;
using TestUtilities = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities;

namespace Microsoft.Azure.Commands.RedisCache.Test.ScenarioTests
{
    public class RedisCacheController
    {
        private EnvironmentSetupHelper helper;
        private LegacyTest.CSMTestEnvironmentFactory csmTestFactory;

        public ResourceManagementClient ResourceManagementClient { get; private set; }

        public InsightsManagementClient InsightsManagementClient { get; private set; }

        public RedisManagementClient RedisManagementClient { get; private set; }

        public RedisCacheController()
        {
            helper = new EnvironmentSetupHelper();
        }

        public static RedisCacheController NewInstance
        {
            get
            {
                return new RedisCacheController();
            }
        }

        private void SetupManagementClients(MockContext context)
        {
            RedisManagementClient = GetRedisManagementClient(context);
            InsightsManagementClient = GetInsightsManagementClient();
            ResourceManagementClient = GetResourceManagementClient();
            helper.SetupManagementClients(ResourceManagementClient,
                InsightsManagementClient,
                RedisManagementClient
                );
        }

        public void RunPowerShellTest(params string[] scripts)
        {
            var callingClassType = TestUtilities.GetCallingClass(2);
            var mockName = TestUtilities.GetCurrentMethodName(2);

            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");
            using (MockContext context = MockContext.Start(callingClassType, mockName))
            {
                this.csmTestFactory = new LegacyTest.CSMTestEnvironmentFactory();
                SetupManagementClients(context);

                var callingClassName = callingClassType
                                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                                        .Last();
                helper.SetupEnvironment(AzureModule.AzureResourceManager);
                helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    helper.RMProfileModule,
                    helper.RMResourceModule,
                    helper.GetRMModulePath(@"AzureRM.RedisCache.psd1"));

                if (scripts != null)
                {
                    helper.RunPowerShellTest(scripts);
                }
            }
        }

        private RedisManagementClient GetRedisManagementClient(MockContext context)
        {
            return context.GetServiceClient<RedisManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private InsightsManagementClient GetInsightsManagementClient()
        {
            return LegacyTest.TestBase.GetServiceClient<InsightsManagementClient>(this.csmTestFactory);
        }

        private ResourceManagementClient GetResourceManagementClient()
        {
            return LegacyTest.TestBase.GetServiceClient<ResourceManagementClient>(this.csmTestFactory);
        }
    }
}
