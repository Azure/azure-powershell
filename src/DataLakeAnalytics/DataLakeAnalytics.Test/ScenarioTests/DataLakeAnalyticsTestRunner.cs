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

using Microsoft.Azure.Management.DataLake.Analytics;
using Microsoft.Azure.Management.DataLake.Store;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using NewResourceManagementClient = Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient;
using Microsoft.Azure.Commands.TestFx;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.DataLakeAnalytics.Test.ScenarioTests
{
    public class DataLakeAnalyticsTestRunner
    {
        protected readonly ITestRunner TestRunner;

        protected DataLakeAnalyticsTestRunner(ITestOutputHelper output)
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
                    helper.GetRMModulePath("Az.DataLakeAnalytics.psd1"),
                    helper.GetRMModulePath("Az.DataLakeStore.psd1")
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
                    GetNewResourceManagementClient,
                    GetDataLakeStoreAccountManagementClient,
                    GetDataLakeAnalyticsAccountManagementClient,
                    GetDataLakeAnalyticsJobManagementClient,
                    GetDataLakeAnalyticsCatalogManagementClient
                )
                .Build();
        }

        private static NewResourceManagementClient GetNewResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<NewResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static DataLakeStoreAccountManagementClient GetDataLakeStoreAccountManagementClient(MockContext context)
        {
            return context.GetServiceClient<DataLakeStoreAccountManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static DataLakeAnalyticsAccountManagementClient GetDataLakeAnalyticsAccountManagementClient(MockContext context)
        {
            return context.GetServiceClient<DataLakeAnalyticsAccountManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static DataLakeAnalyticsJobManagementClient GetDataLakeAnalyticsJobManagementClient(MockContext context)
        {
            var currentEnvironment = TestEnvironmentFactory.GetTestEnvironment();
            var toReturn = context.GetServiceClient<DataLakeAnalyticsJobManagementClient>(currentEnvironment, true);
            toReturn.AdlaJobDnsSuffix =
                currentEnvironment.Endpoints.DataLakeAnalyticsJobAndCatalogServiceUri.OriginalString.Replace("https://", "");
            return toReturn;
        }

        private static DataLakeAnalyticsCatalogManagementClient GetDataLakeAnalyticsCatalogManagementClient(MockContext context)
        {
            var currentEnvironment = TestEnvironmentFactory.GetTestEnvironment();
            var toReturn = context.GetServiceClient<DataLakeAnalyticsCatalogManagementClient>(currentEnvironment, true);
            toReturn.AdlaCatalogDnsSuffix =
                currentEnvironment.Endpoints.DataLakeAnalyticsJobAndCatalogServiceUri.OriginalString.Replace("https://", "");
            return toReturn;
        }
    }
}
