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

namespace Microsoft.Azure.Commands.GuestConfiguration.Test.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;

    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Management.GuestConfiguration;
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;

    using TestEnvironmentFactory = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory;

    public class TestController : RMTestBase
    {
        private readonly EnvironmentSetupHelper _helper;

        public GuestConfigurationClient GuestConfigurationClient { get; private set; }

        public PolicyClient PolicyClient { get; private set; }

        public static TestController NewInstance => new TestController();

        protected TestController()
        {
            _helper = new EnvironmentSetupHelper();
        }

        public void RunPowerShellTest(ServiceManagemenet.Common.Models.XunitTracingInterceptor logger, params string[] scripts)
        {
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            _helper.TracingInterceptor = logger;
            var providers = new Dictionary<string, string>
            {
                { "Microsoft.Resources", null },
                { "Microsoft.Authorization", null }
            };
            var providersToIgnore = new Dictionary<string, string>();
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, providers, providersToIgnore);
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            using (var context = MockContext.Start(callingClassType, mockName))
            {
                SetupManagementClients(context);

                _helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var guestConfigurationCmdletModulePath = _helper.GetRMModulePath(@"AzureRM.GuestConfiguration.psd1");

                var callingClassName = callingClassType?.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();
                _helper.SetupModules(
                    AzureModule.AzureResourceManager,
                    _helper.RMProfileModule,
                    guestConfigurationCmdletModulePath,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1");

                _helper.RunPowerShellTest(scripts);
            }
        }

        protected void SetupManagementClients(MockContext context)
        {
            GuestConfigurationClient = GetGuestConfigurationClient(context);
            PolicyClient = GetPolicyClient(context);
            var clients = new IAzureClient[] { GuestConfigurationClient, PolicyClient };
            _helper.SetupManagementClients(clients);
        }

        private static GuestConfigurationClient GetGuestConfigurationClient(MockContext context)
        {
            return context.GetServiceClient<GuestConfigurationClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static PolicyClient GetPolicyClient(MockContext context)
        {
            return context.GetServiceClient<PolicyClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}
