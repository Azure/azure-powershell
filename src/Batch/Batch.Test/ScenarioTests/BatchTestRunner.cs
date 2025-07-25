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

using Microsoft.Azure.Internal.Common;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using Microsoft.Azure.Commands.TestFx;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class BatchTestRunner
    {
        internal static string BatchAccount;
        internal static string BatchAccountKey;
        internal static string BatchAccountUrl;
        internal static string BatchResourceGroup;
        internal static string Subscription;

        public ResourceManagementClient ResourceManagementClient { get; private set; }

        public BatchManagementClient BatchManagementClient { get; private set; }

        public NetworkManagementClient NetworkManagementClient { get; private set; }

        public AzureRestClient AzureRestClient { get; private set; }

        protected readonly ITestRunner TestRunner;

        protected BatchTestRunner(ITestOutputHelper output)
        {
            TestRunner = TestManager.CreateInstance(output)
                .WithNewPsScriptFilename($"{GetType().Name}.ps1")
                .WithProjectSubfolderForTests("ScenarioTests")
                .WithCommonPsScripts(new[]
                {
                    @"Common.ps1",
                    @"../AzureRM.Resources.ps1",
                })
                .WithNewRmModules(helper => new[]
               {
                    helper.RMProfileModule,
                    helper.GetRMModulePath("Az.Batch.psd1"),
                    helper.GetRMModulePath("Az.Network.psd1")
                })
                .WithNewRecordMatcherArguments(
                    userAgentsToIgnore: new Dictionary<string, string>
                    {
                        {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"},
                    },
                    resourceProviders: new Dictionary<string, string>
                    {
                        {"Microsoft.Resources", null},
                        {"Microsoft.Features", null},
                        {"Microsoft.Network", null},
                        {"Microsoft.Authorization", null}
                    }
                )
                .WithManagementClients(
                    GetResourceManagementClient,
                    GetBatchManagementClient,
                    GetNetworkManagementClient,
                    GetAzureRestClient
                )
                .Build();
        }

        private ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            var client = context.GetServiceClient<ResourceManagementClient>();
            ResourceManagementClient = client;
            return client;
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

            var client = context.GetServiceClient<BatchManagementClient>();
            Subscription = client.SubscriptionId;
            BatchManagementClient = client;
            return client;
        }

        private NetworkManagementClient GetNetworkManagementClient(MockContext context)
        {
            var client = context.GetServiceClient<NetworkManagementClient>();
            NetworkManagementClient = client;
            return client;
        }

        private AzureRestClient GetAzureRestClient(MockContext context)
        {
            var client = context.GetServiceClient<AzureRestClient>();
            AzureRestClient = client;
            return client;
        }
    }
}
