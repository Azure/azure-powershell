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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.TestFx;
using Microsoft.Azure.Synapse;
using Microsoft.Azure.Test.HttpRecorder;
using System.Collections.Generic;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Synapse.Test.ScenarioTests
{
    public class SynapseTestRunner
    {
        internal string ResourceGroupName { get; set; }
        internal const string ResourceGroupLocation = "northeurope";

        protected static string TestResourceGroupName;

        protected static string TestWorkspaceName;

        protected static string TestSparkPoolName;

        protected readonly ITestRunner TestRunner;

        protected SynapseTestRunner(ITestOutputHelper output)
        {
            TestRunner = TestManager.CreateInstance(output)
                .WithNewPsScriptFilename($"{GetType().Name}.ps1")
                .WithProjectSubfolderForTests("ScenarioTests")
                .WithCommonPsScripts(new[]
                {
                    @"Common.ps1",
                    @"../AzureRM.Resources.ps1"
                })
                .WithNewRmModules(helper => new[]
                {
                    helper.RMProfileModule,
                    helper.GetRMModulePath("Az.Synapse.psd1"),
                    helper.GetRMModulePath("Az.Storage.psd1"),
                    helper.RMOperationalInsightsModule,
                    helper.RMEventHubModule,
                    helper.RMMonitorModule
                })
                .WithNewRecordMatcherArguments(
                    userAgentsToIgnore: new Dictionary<string, string>
                    {
                        {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"},
                        {"Microsoft.Azure.Management.ResourceManager.ResourceManagementClient", "2017-05-10"}
                    },
                    resourceProviders: new Dictionary<string, string>
                    {
                        {"Microsoft.Resources", null},
                        {"Microsoft.Features", null},
                        {"Microsoft.Authorization", null},
                        {"Microsoft.EventHub", null},
                        {"Microsoft.Insights", null},
                        {"Microsoft.OperationalInsights", null},
                        {"Microsoft.Storage", null}
                    }
                )
                .WithManagementClients(context =>
                    {
                        var creds = context.GetClientCredentials(AzureEnvironment.ExtendedEndpoint.AzureSynapseAnalyticsEndpointResourceId);
                        return new SynapseClient(creds, HttpMockServer.CreateInstance());
                    }
                )
                .Build();
        }
    }
}
