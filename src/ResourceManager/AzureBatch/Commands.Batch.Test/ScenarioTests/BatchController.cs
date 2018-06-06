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
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using TestEnvironmentFactory = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class BatchController
    {
        internal static string BatchAccount, BatchAccountKey, BatchAccountUrl, BatchResourceGroup;

        private readonly EnvironmentSetupHelper _helper;

        public ResourceManagementClient ResourceManagementClient { get; private set; }

        public BatchManagementClient BatchManagementClient { get; private set; }

        public static BatchController NewInstance => new BatchController();

        public BatchController()
        {
            _helper = new EnvironmentSetupHelper();
        }

        public void RunPsTest(params string[] scripts)
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

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
                SetupManagementClients(context);

                _helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var callingClassName = callingClassType
                                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                                        .Last();
                _helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    "Microsoft.Azure.Commands.Batch.Test.dll",
                    _helper.RMProfileModule,
                    _helper.RMResourceModule,
                    _helper.GetRMModulePath("AzureRM.Batch.psd1"),
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
                            _helper.RunPowerShellTest(psScripts);
                        }
                    }
                }
                finally
                {
                    cleanup?.Invoke();
                }
            }
        }

        private void SetupManagementClients(MockContext context)
        {
            ResourceManagementClient = GetResourceManagementClient(context);
            BatchManagementClient = GetBatchManagementClient(context);

            _helper.SetupManagementClients(ResourceManagementClient, BatchManagementClient);
        }

        private ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
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
