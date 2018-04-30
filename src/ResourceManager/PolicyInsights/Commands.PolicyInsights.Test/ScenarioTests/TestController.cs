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
using Microsoft.Azure.Management.PolicyInsights;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestEnvironmentFactory = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory;
using TestUtilities = Microsoft.Azure.Test.TestUtilities;

namespace Microsoft.Azure.Commands.PolicyInsights.Test.ScenarioTests
{
    public class TestController : RMTestBase
    {
        private CSMTestEnvironmentFactory _csmTestFactory;

        private readonly EnvironmentSetupHelper _helper;

        public PolicyInsightsClient PolicyInsightsClient { get; private set; }

        public static TestController NewInstance => new TestController();

        protected TestController()
        {
            _helper = new EnvironmentSetupHelper();
        }

        public void RunPowerShellTest(ServiceManagemenet.Common.Models.XunitTracingInterceptor logger, params string[] scripts)
        {
            var callingClassType = TestUtilities.GetCallingClass(2);
            var mockName = TestUtilities.GetCurrentMethodName(2);

            _helper.TracingInterceptor = logger;
            RunPsTestWorkflow(
                scriptBuilder: () => scripts,
                initialize: null,
                cleanup: null,
                callingClassType: callingClassType,
                mockName: mockName);
        }

        public void RunPsTestWorkflow(
            Func<string[]> scriptBuilder,
            Action<CSMTestEnvironmentFactory> initialize,
            Action cleanup,
            string callingClassType,
            string mockName)
        {
            var providers = new Dictionary<string, string>
            {
                { "Microsoft.Resources", null },
                { "Microsoft.Features", null },
                { "Microsoft.Authorization", null }
            };
            var providersToIgnore = new Dictionary<string, string>();
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, providers, providersToIgnore);
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            using (var context = MockContext.Start(callingClassType, mockName))
            {
                _csmTestFactory = new CSMTestEnvironmentFactory();

                initialize?.Invoke(_csmTestFactory);

                SetupManagementClients(context);

                _helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var callingClassName = callingClassType
                    .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                    .Last();

                _helper.SetupModules(
                    AzureModule.AzureResourceManager,
                    _helper.RMProfileModule,
                    _helper.GetRMModulePath(@"AzureRM.PolicyInsights.psd1"),
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1");

                try
                {
                    var psScripts = scriptBuilder?.Invoke();
                    if (null != psScripts)
                    {
                        _helper.RunPowerShellTest(psScripts);
                    }
                }
                finally
                {
                    cleanup?.Invoke();
                }
            }
        }

        protected void SetupManagementClients(MockContext context)
        {
            PolicyInsightsClient = GetPolicyInsightsClient(context);
            _helper.SetupManagementClients(PolicyInsightsClient);
        }

        private PolicyInsightsClient GetPolicyInsightsClient(MockContext context)
        {
            return context.GetServiceClient<PolicyInsightsClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}
