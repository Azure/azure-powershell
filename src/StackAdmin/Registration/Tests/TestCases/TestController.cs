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

namespace Microsoft.Azure.Commands.AzureStack.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Management.AzureStack;
    using Microsoft.Azure.Management.Internal.Resources;
    using Microsoft.Azure.ServiceManagemenet.Common.Models;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;

    public class TestController
    {
        private readonly EnvironmentSetupHelper helper;

        public static TestController Instance => new TestController();

        public TestController()
        {
            HttpMockServer.Mode = HttpRecorderMode.Playback;
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(
                ignoreResourcesClient: true,
                providers: new Dictionary<string, string>()
                {
                    {"Microsoft.Resources", null},
                    {"Microsoft.Features", null},
                    {"Microsoft.Authorization", null}
                },
                userAgents: new Dictionary<string, string>());

            this.helper = new EnvironmentSetupHelper();
        }

        public AzureStackManagementClient AzureStackManagementClient { get; private set; }

        public void RunPowerShellTest(XunitTracingInterceptor logger, params string[] scripts)
        {
            var stackFrame = new StackTrace().GetFrame(1);
            var callingClassType = stackFrame.GetMethod().ReflectedType?.ToString();
            var callingClassName = callingClassType?.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();
            var mockName = stackFrame.GetMethod().Name;

            this.helper.TracingInterceptor = logger;

            using (var context = MockContext.Start(callingClassType, mockName))
            {
                var environment = TestEnvironmentFactory.GetTestEnvironment();
                var azsMgmtClient = context.GetServiceClient<AzureStackManagementClient>(environment);
                var resourceMgmtClient = context.GetServiceClient<ResourceManagementClient>(environment);
                this.helper.SetupManagementClients(azsMgmtClient, resourceMgmtClient);
                this.helper.SetupEnvironment(AzureModule.AzureResourceManager);
                this.helper.SetupModules(AzureModule.AzureResourceManager,
                    $@"TestCases\{callingClassName}.ps1",
                    this.helper.RMProfileModule,
                    this.helper.GetRMModulePath("AzureRM.AzureStack.Registration.psd1"));

                if (scripts != null)
                {
                    var psObj = this.helper.RunPowerShellTest(scripts);
                }
            }
        }
    }
}
