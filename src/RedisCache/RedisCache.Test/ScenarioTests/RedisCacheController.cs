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
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.IO;
using System.Linq;
using TestEnvironmentFactory = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory;
using Microsoft.Azure.Management.Storage.Version2017_10_01;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Azure.ServiceManagement.Common.Models;

namespace Microsoft.Azure.Commands.RedisCache.Test.ScenarioTests
{
    public class RedisCacheController
    {
        private readonly EnvironmentSetupHelper _helper;

        public Management.Internal.Resources.ResourceManagementClient NewResourceManagementClient { get; private set; }

        public InsightsManagementClient InsightsManagementClient { get; private set; }

        public RedisManagementClient RedisManagementClient { get; private set; }

        public StorageManagementClient StorageClient { get; private set; }

        public RedisCacheController()
        {
            _helper = new EnvironmentSetupHelper();
        }

        public static RedisCacheController NewInstance => new RedisCacheController();

        private void SetupManagementClients(MockContext context)
        {
            RedisManagementClient = GetRedisManagementClient(context);
            InsightsManagementClient = GetInsightsManagementClient(context);
            NewResourceManagementClient = GetResourceManagementClient(context);
            StorageClient = GetStorageManagementClient(context);
            _helper.SetupManagementClients(
                RedisManagementClient,
                StorageClient,
                NewResourceManagementClient,
                InsightsManagementClient);
        }

        public void RunPowerShellTest(XunitTracingInterceptor logger, params string[] scripts)
        {
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            _helper.TracingInterceptor = logger;

            var d = new Dictionary<string, string>
            {
                {"Microsoft.Resources", null},
                {"Microsoft.Features", null},
                {"Microsoft.Authorization", null}
            };
            var providersToIgnore = new Dictionary<string, string>();
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);

            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");
            using (var context = MockContext.Start(callingClassType, mockName))
            {
                SetupManagementClients(context);

                var callingClassName = callingClassType?.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();
                _helper.SetupEnvironment(AzureModule.AzureResourceManager);
                _helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    _helper.RMProfileModule,
                    "AzureRM.Storage.ps1",
                    _helper.GetRMModulePath(@"AzureRM.RedisCache.psd1"),
                    "AzureRM.Resources.ps1");

                if (scripts != null)
                {
                    _helper.RunPowerShellTest(scripts);
                }
            }
        }

        private static StorageManagementClient GetStorageManagementClient(MockContext context)
        {
            return context.GetServiceClient<StorageManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static RedisManagementClient GetRedisManagementClient(MockContext context)
        {
            return context.GetServiceClient<RedisManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static InsightsManagementClient GetInsightsManagementClient(MockContext context)
        {
            return context.GetServiceClient<InsightsManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static Management.Internal.Resources.ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<Management.Internal.Resources.ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}
