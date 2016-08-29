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
using Microsoft.Azure.Gallery;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestBase = Microsoft.Azure.Test.TestBase;
using TestEnvironmentFactory = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory;
using TestUtilities = Microsoft.Azure.Test.TestUtilities;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class BatchController
    {
        internal static string BatchAccount, BatchAccountKey, BatchAccountUrl, BatchResourceGroup;

        private CSMTestEnvironmentFactory csmTestFactory;
        private EnvironmentSetupHelper helper;

        public AuthorizationManagementClient AuthorizationManagementClient { get; private set; }

        public GalleryClient GalleryClient { get; private set; }

        public ResourceManagementClient ResourceManagementClient { get; private set; }

        public BatchManagementClient BatchManagementClient { get; private set; }

        public static BatchController NewInstance
        {
            get
            {
                return new BatchController();
            }
        }

        public BatchController()
        {
            helper = new EnvironmentSetupHelper();
        }

        public void RunPsTest(params string[] scripts)
        {
            var callingClassType = TestUtilities.GetCallingClass(2);
            var mockName = TestUtilities.GetCurrentMethodName(2);

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
            Action initialize,
            Action cleanup,
            string callingClassType,
            string mockName)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("Microsoft.Resources", null);
            d.Add("Microsoft.Features", null);
            d.Add("Microsoft.Authorization", null);
            var providersToIgnore = new Dictionary<string, string>();
            providersToIgnore.Add("Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01");
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);

            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");
            using (MockContext context = MockContext.Start(callingClassType, mockName))
            {
                this.csmTestFactory = SetupCSMTestEnvironmentFactory();
                SetupManagementClients(context);

                helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var callingClassName = callingClassType
                                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                                        .Last();
                helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    "Microsoft.Azure.Commands.Batch.Test.dll",
                    helper.RMProfileModule,
                    helper.RMResourceModule,
                    helper.GetRMModulePath("AzureRM.Batch.psd1"),
                    "AzureRM.Resources.ps1");

                try
                {
                    if (initialize != null)
                    {
                        initialize();
                    }

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

        private CSMTestEnvironmentFactory SetupCSMTestEnvironmentFactory()
        {
            CSMTestEnvironmentFactory factory = new CSMTestEnvironmentFactory();
            // to set test environment to Current add Environment=Current in TEST_CSM_ORGID_AUTHENTICATION env. variable
            // available configurations are: Prod/Dogfood/Next/Current
            return factory;
        }

        private void SetupManagementClients(MockContext context)
        {
            AuthorizationManagementClient = GetAuthorizationManagementClient();
            GalleryClient = GetGalleryClient();
            ResourceManagementClient = GetResourceManagementClient();
            BatchManagementClient = GetBatchManagementClient(context);

            helper.SetupManagementClients(AuthorizationManagementClient,
                                          GalleryClient,
                                          ResourceManagementClient,
                                          BatchManagementClient);
        }

        private AuthorizationManagementClient GetAuthorizationManagementClient()
        {
            return TestBase.GetServiceClient<AuthorizationManagementClient>(this.csmTestFactory);
        }

        private GalleryClient GetGalleryClient()
        {
            return TestBase.GetServiceClient<GalleryClient>(this.csmTestFactory);
        }

        private ResourceManagementClient GetResourceManagementClient()
        {
            return TestBase.GetServiceClient<ResourceManagementClient>(this.csmTestFactory);
        }

        private BatchManagementClient GetBatchManagementClient(MockContext context)
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                BatchAccount = Environment.GetEnvironmentVariable(ScenarioTestHelpers.BatchAccountName);
                BatchAccountKey = Environment.GetEnvironmentVariable(ScenarioTestHelpers.BatchAccountKey);
                BatchAccountUrl = Environment.GetEnvironmentVariable(ScenarioTestHelpers.BatchAccountEndpoint);
                BatchResourceGroup = Environment.GetEnvironmentVariable(ScenarioTestHelpers.BatchAccountResourceGroup);

                HttpMockServer.Variables[ScenarioTestHelpers.BatchAccountName] = BatchAccount;
                HttpMockServer.Variables[ScenarioTestHelpers.BatchAccountEndpoint] = BatchAccountUrl;
                HttpMockServer.Variables[ScenarioTestHelpers.BatchAccountResourceGroup] = BatchResourceGroup;
            }
            else if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                BatchAccount = HttpMockServer.Variables[ScenarioTestHelpers.BatchAccountName];
                BatchAccountKey = "00000000000000000000000000000000000000000000000000000000000000000000000000000000000000==";
                BatchAccountUrl = HttpMockServer.Variables[ScenarioTestHelpers.BatchAccountEndpoint];

                if (HttpMockServer.Variables.ContainsKey(ScenarioTestHelpers.BatchAccountResourceGroup))
                {
                    BatchResourceGroup = HttpMockServer.Variables[ScenarioTestHelpers.BatchAccountResourceGroup];
                }
            }

            return context.GetServiceClient<BatchManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}
