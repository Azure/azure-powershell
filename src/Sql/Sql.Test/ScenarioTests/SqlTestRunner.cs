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

using Microsoft.Azure.Commands.TestFx;
using Microsoft.Azure.Commands.TestFx.Recorder;
using System.Collections.Generic;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.ScenarioTest.SqlTests
{
    public class SqlTestRunner
    {
        protected string[] resourceTypesToIgnoreApiVersion = new string[] {
            "Microsoft.Sql/managedInstances",
            "Microsoft.Sql/managedInstances/databases",
            "Microsoft.Sql/managedInstances/managedDatabases",
            "Microsoft.Sql/servers",
            "Microsoft.Sql/servers/databases",
            "Microsoft.Sql/servers/elasticPools"
        };

        protected readonly ITestRunner TestRunner;

        protected SqlTestRunner(ITestOutputHelper output)
        {
            TestRunner = TestManager.CreateInstance(output)
                .WithNewPsScriptFilename($"{GetType().Name}.ps1")
                .WithProjectSubfolderForTests("ScenarioTests")
                .WithCommonPsScripts(new[]
                {
                    @"Common.ps1",
                    @"../AzureRM.Storage.ps1",
                    @"../AzureRM.Resources.ps1"
                })
                .WithNewRmModules(helper => new[]
                {
                    helper.RMProfileModule,
                    helper.GetRMModulePath("Az.Sql.psd1"),
                    helper.RMNetworkModule,
                    helper.RMOperationalInsightsModule,
                    helper.RMEventHubModule,
                    helper.RMMonitorModule,
                    helper.RMKeyVaultModule
                })
                .WithRecordMatcher(
                    (bool ignoreResourcesClient, Dictionary<string, string> providers, Dictionary<string, string> userAgents) =>
                        new PermissiveRecordMatcherWithResourceApiExclusion(ignoreResourcesClient, providers, userAgents, resourceTypesToIgnoreApiVersion)
                )
                .WithNewRecordMatcherArguments(
                    userAgentsToIgnore: new Dictionary<string, string>
                    {
                        {"Microsoft.Azure.Graph.RBAC.Version1_6.GraphRbacManagementClient", "1.42-previewInternal"},
                        {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"}
                    },
                    resourceProviders: new Dictionary<string, string>
                    {
                        {"Microsoft.Resources", null},
                        {"Microsoft.Sql", null},
                        {"Microsoft.Features", null},
                        {"Microsoft.Authorization", null},
                        {"Microsoft.Network", null},
                        {"Microsoft.KeyVault", null},
                        {"Microsoft.EventHub", null},
                        {"Microsoft.Insights", null},
                        {"Microsoft.OperationalInsights", null}
                    }
                )
                .Build();
        }
    }
}
