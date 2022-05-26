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

using Microsoft.Azure.Management.OperationalInsights;
using Microsoft.Azure.Test.HttpRecorder;
using System.Collections.Generic;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.OperationalInsights;
using RestTestFramework = Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Commands.TestFx;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.OperationalInsights.Test
{
    public class OperationalInsightsTestRunner
    {
        protected readonly ITestRunner TestRunner;

        protected OperationalInsightsTestRunner(ITestOutputHelper output)
        {
            TestRunner = TestFx.TestManager.CreateInstance(output)
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
                    helper.GetRMModulePath("Az.OperationalInsights.psd1"),
                    helper.GetRMModulePath("Az.Storage.psd1")
                })
                .WithNewRecordMatcherArguments(
                    userAgentsToIgnore: new Dictionary<string, string>
                    {
                        {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"}
                    },
                    resourceProviders: new Dictionary<string, string>
                    {
                        {"Microsoft.Resources", null},
                        {"Microsoft.Features", null},
                        {"Microsoft.Authorization", null}
                    }
                ).WithManagementClients(
                    GetOperationalInsightsDataClient,
                    GetOperationalInsightsManagementClient,
                    GetResourceManagementClient,
                    GetStorageManagementClient
                )
                .Build();
        }

        protected OperationalInsightsDataClient GetOperationalInsightsDataClient(RestTestFramework.MockContext context)
        {
            var credentials = new ApiKeyClientCredentials("DEMO_KEY");
            return new OperationalInsightsDataClient(credentials, HttpMockServer.CreateInstance());
        }

        protected OperationalInsightsManagementClient GetOperationalInsightsManagementClient(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<OperationalInsightsManagementClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        protected ResourceManagementClient GetResourceManagementClient(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        protected StorageManagementClient GetStorageManagementClient(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<StorageManagementClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}
