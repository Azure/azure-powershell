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

namespace Microsoft.Azure.Commands.DataShare.Test.ScenarioTests.ScenarioTest
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Management.DataShare;
    using Microsoft.Azure.Management.Internal.Resources;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;

    public class TestController : RMTestBase
    {
        private readonly EnvironmentSetupHelper helper;

        public ResourceManagementClient ResourceManagementClient { get; private set; }

        public DataShareManagementClient DataShareManagementClient { get; private set; }

        public static TestController NewInstance => new TestController();

        protected TestController()
        {
            this.helper = new EnvironmentSetupHelper();
        }

        protected void SetupManagementClients(MockContext context)
        {
            this.ResourceManagementClient = this.GetResourceManagementClient(context);
            this.DataShareManagementClient = TestController.GetDataShareManagementClient(context);

            this.helper.SetupManagementClients(
                this.ResourceManagementClient,
                this.DataShareManagementClient);
        }

        public void RunPowerShellTest(
            ServiceManagement.Common.Models.XunitTracingInterceptor logger,
            params string[] scripts)
        {
            StackFrame sf = new StackTrace().GetFrame(1);
            string callingClassType = sf.GetMethod().ReflectedType?.ToString();
            string mockName = sf.GetMethod().Name;

            this.helper.TracingInterceptor = logger;
            this.RunPsTestWorkflow(
                () => scripts,
                // no custom cleanup
                null,
                callingClassType,
                mockName);
        }

        public void RunPsTestWorkflow(
            Func<string[]> scriptBuilder,
            Action cleanup,
            string callingClassType,
            string mockName)
        {
            var d = new Dictionary<string, string>
            {
                { "Microsoft.Resources", null },
                { "Microsoft.Features", null },
                { "Microsoft.Authorization", null },
                { "Microsoft.Compute", null }
            };
            var providersToIgnore = new Dictionary<string, string>
            {
                { "Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01" }
            };
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);

            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            using (MockContext context = MockContext.Start(callingClassType, mockName))
            {
                this.SetupManagementClients(context);

                this.helper.SetupEnvironment(AzureModule.AzureResourceManager);

                string callingClassName =
                    callingClassType.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();

                this.helper.SetupModules(
                    AzureModule.AzureResourceManager,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    this.helper.RMProfileModule,
                    this.helper.GetRMModulePath("AzureRM.DataShare.psd1"),
                    "AzureRM.Resources.ps1");
                try
                {
                    string[] psScripts = scriptBuilder?.Invoke();
                    if (psScripts != null)
                    {
                        this.helper.RunPowerShellTest(psScripts);
                    }
                }
                finally
                {
                    cleanup?.Invoke();
                }
            }
        }

        protected ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static DataShareManagementClient GetDataShareManagementClient(MockContext context)
        {
            return context.GetServiceClient<DataShareManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}
