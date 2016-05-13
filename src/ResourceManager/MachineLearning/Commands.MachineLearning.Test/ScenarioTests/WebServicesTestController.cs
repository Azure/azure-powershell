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
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Gallery;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.Azure.Management.MachineLearning.WebServices;
using Microsoft.Azure.Subscriptions;
using LegacyTest = Microsoft.Azure.Test;

namespace Microsoft.Azure.Commands.MachineLearning.Test.ScenarioTests
{
    internal class WebServicesTestController
    {
        private readonly EnvironmentSetupHelper helper;
        private LegacyTest.CSMTestEnvironmentFactory csmTestFactory;

        protected WebServicesTestController()
        {
            this.helper = new EnvironmentSetupHelper();
        }
        
        public ResourceManagementClient ResourceManagementClient { get; private set; }

        public AzureMLWebServicesManagementClient WebServicesManagementClient { get; private set; }

        public static WebServicesTestController NewInstance
        {
            get
            {
                return new WebServicesTestController();
            }
        }

        public void RunPsTest(params string[] scripts)
        {
            var callingClassType = TestUtilities.GetCallingClass(2);
            var mockName = TestUtilities.GetCurrentMethodName(2);

            this.RunPsTestWorkflow(
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
            var providers = new Dictionary<string, string>
            {
                { "Microsoft.Resources", null },
                { "Microsoft.Features", null },
                { "Microsoft.Authorization", null }
            };
            var providersToIgnore = new Dictionary<string, string>
            {
                {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"}
            };
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, providers, providersToIgnore);

            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");
            using (MockContext context = MockContext.Start(callingClassType, mockName))
            {
                this.csmTestFactory = new LegacyTest.CSMTestEnvironmentFactory();
                if (initialize != null)
                {
                    initialize(this.csmTestFactory);
                }

                this.SetupManagementClients(context);
                helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var callingClassName = callingClassType
                                      .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                                      .Last();

                helper.SetupModules(AzureModule.AzureResourceManager,
                   "ScenarioTests\\Common.ps1",
                   "ScenarioTests\\" + callingClassName + ".ps1",
                   helper.RMProfileModule,
                   helper.RMResourceModule,
                   helper.GetRMModulePath(@"AzureRM.MachineLearning.psd1"));

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

        private void SetupManagementClients(MockContext context)
        {
            this.ResourceManagementClient = LegacyTest.TestBase.GetServiceClient<ResourceManagementClient>(this.csmTestFactory);
            this.WebServicesManagementClient = context.GetServiceClient<AzureMLWebServicesManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
            
            var subscriptionClient = LegacyTest.TestBase.GetServiceClient<SubscriptionClient>(this.csmTestFactory);
            var authManagementClient = LegacyTest.TestBase.GetServiceClient<AuthorizationManagementClient>(this.csmTestFactory);
            var gallleryClient = LegacyTest.TestBase.GetServiceClient<GalleryClient>(this.csmTestFactory);
            helper.SetupManagementClients(this.ResourceManagementClient, subscriptionClient, this.WebServicesManagementClient, authManagementClient, gallleryClient);
        }
    }
}
