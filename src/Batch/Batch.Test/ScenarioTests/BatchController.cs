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
<<<<<<< HEAD
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Internal.Resources;
=======
using Microsoft.Azure.Internal.Common;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Network;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class BatchController
    {
<<<<<<< HEAD
        internal static string BatchAccount, BatchAccountKey, BatchAccountUrl, BatchResourceGroup;
=======
        internal static string BatchAccount;
        internal static string BatchAccountKey;
        internal static string BatchAccountUrl;
        internal static string BatchResourceGroup;
        internal static string Subscription;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

        private readonly EnvironmentSetupHelper _helper;

        public ResourceManagementClient ResourceManagementClient { get; private set; }

        public BatchManagementClient BatchManagementClient { get; private set; }

<<<<<<< HEAD
=======
        public NetworkManagementClient NetworkManagementClient { get; private set; }

        public AzureRestClient AzureRestClient { get; private set; }

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        public static BatchController NewInstance => new BatchController();

        public BatchController()
        {
            _helper = new EnvironmentSetupHelper();
        }

        public void RunPsTest(XunitTracingInterceptor logger, params string[] scripts)
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            RunPsTestWorkflow(
                logger,
                () => scripts,
                // no custom initializer
                null,
                // no custom cleanup
                null,
                callingClassType,
                mockName);
        }

        public void RunPsTestWorkflow(
            XunitTracingInterceptor logger,
            Func<string[]> scriptBuilder,
            Action initialize,
            Action cleanup,
            string callingClassType,
            string mockName)
        {
            _helper.TracingInterceptor = logger;
            var d = new Dictionary<string, string>
            {
                {"Microsoft.Resources", null},
                {"Microsoft.Features", null},
<<<<<<< HEAD
=======
                {"Microsoft.Network", null},
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                {"Microsoft.Authorization", null}
            };
            var providersToIgnore = new Dictionary<string, string>
            {
                {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"}
            };
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);

            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");
            using (var context = MockContext.Start(callingClassType, mockName))
            {
                SetupManagementClients(context);

                _helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var callingClassName = callingClassType
                                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                                        .Last();
                _helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    _helper.RMProfileModule,
<<<<<<< HEAD
                    _helper.GetRMModulePath("AzureRM.Batch.psd1"),
=======
                    _helper.GetRMModulePath("Az.Batch.psd1"),
                    _helper.GetRMModulePath("Az.Network.psd1"),
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                    "AzureRM.Resources.ps1");

                try
                {
                    initialize?.Invoke();
                    var psScripts = scriptBuilder?.Invoke();
                    if (psScripts != null)
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

        private void SetupManagementClients(MockContext context)
        {
            ResourceManagementClient = GetResourceManagementClient(context);
            BatchManagementClient = GetBatchManagementClient(context);
<<<<<<< HEAD

            _helper.SetupManagementClients(ResourceManagementClient, BatchManagementClient);
=======
            NetworkManagementClient = GetNetworkManagementClient(context);
            AzureRestClient = context.GetServiceClient<AzureRestClient>(TestEnvironmentFactory.GetTestEnvironment());

            _helper.SetupManagementClients(ResourceManagementClient, BatchManagementClient, NetworkManagementClient, AzureRestClient);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }

        private ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

<<<<<<< HEAD
=======
        private NetworkManagementClient GetNetworkManagementClient(MockContext context)
        {
            return context.GetServiceClient<NetworkManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD

            return context.GetServiceClient<BatchManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
=======
            var result = context.GetServiceClient<BatchManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
            Subscription = result.SubscriptionId;

            return result;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }
    }
}
