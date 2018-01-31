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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Management.RecoveryServices;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using InternalRmNS = Microsoft.Azure.Management.Internal.Resources;
using LegacyTest = Microsoft.Azure.Test;
using ResourceManagementNS = Microsoft.Azure.Management.Resources;
using RestTestFramework = Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.Commands.RecoveryServices.Test.ScenarioTests
{
    public class TestController
    {
        LegacyTest.CSMTestEnvironmentFactory csmTestFactory;
        EnvironmentSetupHelper helper;

        public RecoveryServicesClient RsClient { get; private set; }

        public ResourceManagementNS.ResourceManagementClient RmClient { get; private set; }

        public InternalRmNS.ResourceManagementClient InternalRmClient { get; private set; }

        public static TestController NewInstance
        {
            get
            {
                return new TestController();
            }
        }

        public TestController()
        {
            this.helper = new EnvironmentSetupHelper();
        }

        protected void SetupManagementClients(RestTestFramework.MockContext context)
        {
            RsClient = GetRsClient(context);
            RmClient = GetRmClient();
            InternalRmClient = GetInternalRmClient(context);

            helper.SetupManagementClients(
                RsClient,
                RmClient,
                InternalRmClient);
        }

        private InternalRmNS.ResourceManagementClient GetInternalRmClient(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<InternalRmNS.ResourceManagementClient>(
                RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        private ResourceManagementNS.ResourceManagementClient GetRmClient()
        {
            return LegacyTest.TestBase.GetServiceClient<ResourceManagementNS.ResourceManagementClient>(
                this.csmTestFactory);
        }

        public void RunPsTest(params string[] scripts)
        {
            var callingClassType = LegacyTest.TestUtilities.GetCallingClass(2);
            var mockName = LegacyTest.TestUtilities.GetCurrentMethodName(2);

            RunPsTestWorkflow(
                () => scripts,
                // no custom initializer
                null,
                // no custom cleanup 
                null,
                callingClassType,
                mockName);
        }

        public void RunPsTestWorkflow(
            Func<string[]> scriptBuilder,
            Action<LegacyTest.CSMTestEnvironmentFactory> initialize,
            Action cleanup,
            string callingClassType,
            string mockName)
        {
            Dictionary<string, string> providers = new Dictionary<string, string>();
            providers.Add("Microsoft.Resources", null);
            providers.Add("Microsoft.Features", null);
            providers.Add("Microsoft.Authorization", null);
            providers.Add("Microsoft.Compute", null);
            var providersToIgnore = new Dictionary<string, string>();
            providersToIgnore.Add("Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01");
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, providers, providersToIgnore);

            HttpMockServer.RecordsDirectory =
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            using (RestTestFramework.MockContext context =
                RestTestFramework.MockContext.Start(callingClassType, mockName))
            {
                csmTestFactory = new LegacyTest.CSMTestEnvironmentFactory();

                if (initialize != null)
                {
                    initialize.Invoke(csmTestFactory);
                }

                SetupManagementClients(context);

                helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var callingClassName =
                    callingClassType
                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();
                string psFile =
                    "ScenarioTests\\" + callingClassName + ".ps1";
                string rmProfileModule = helper.RMProfileModule;
                string rmModulePath = helper.GetRMModulePath("AzureRM.RecoveryServices.psd1");

                List<string> modules = new List<string>();

                modules.Add(psFile);
                modules.Add(rmProfileModule);
                modules.Add(rmModulePath);
                modules.Add(helper.RMResourceModule);
                modules.Add("AzureRM.Resources.ps1");

                helper.SetupModules(AzureModule.AzureResourceManager, modules.ToArray());

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
                        cleanup.Invoke();
                    }
                }
            }
        }

        private RecoveryServicesClient GetRsClient(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<RecoveryServicesClient>(
                RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}