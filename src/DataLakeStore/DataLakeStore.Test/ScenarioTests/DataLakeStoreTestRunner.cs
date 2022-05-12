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

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.Diagnostics;
using TestEnvironmentFactory = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory;
using Microsoft.Azure.Commands.DataLakeStore.Models;
using Microsoft.Azure.Commands.DataLake.Test.ScenarioTests;
using Microsoft.Azure.Commands.TestFx;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.DataLakeStore.Test.ScenarioTests
{
    public class DataLakeStoreTestRunner
    {
        protected readonly ITestRunner TestRunner;

        protected DataLakeStoreTestRunner(ITestOutputHelper output)
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
                    helper.RMNetworkModule,
                    helper.GetRMModulePath("Az.DataLakeStore.psd1")
                })
                .WithRecordMatcher(
                    delegate (bool ignoreResourcesClient, Dictionary<string, string> resourceProviders, Dictionary<string, string> userAgentsToIgnore)
                    {
                        return new UrlDecodingRecordMatcher(ignoreResourcesClient, resourceProviders, userAgentsToIgnore);
                    }
                )
                .WithNewRecordMatcherArguments(
                    userAgentsToIgnore: new Dictionary<string, string>
                    {
                        {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"},
                    },
                    resourceProviders: new Dictionary<string, string>
                    {
                        {"Microsoft.Resources", null},
                        {"Microsoft.Features", null},
                        {"Microsoft.Authorization", null},
                        {"Microsoft.Network", null}
                    }
                ).WithMockContextAction(() =>
                {
                    var sf = new StackTrace().GetFrame(2);
                    var callingClassType = sf.GetMethod().ReflectedType?.ToString();
                    var mockName = sf.GetMethod().Name;

                    var context = AdlMockContext.Start(callingClassType, mockName);
                    SetDataLakeStoreFileSystemManagementClient(context);
                })
                .Build();
        }

        protected static void ReSetDataLakeStoreFileSystemManagementClient() { AdlsClientFactory.IsTest = false; }

        private static void SetDataLakeStoreFileSystemManagementClient(MockContext context)
        {
            var currentEnvironment = TestEnvironmentFactory.GetTestEnvironment();
            AdlsClientFactory.IsTest = true;
            AdlsClientFactory.CustomDelegatingHAndler = ((AdlMockContext)context).GetDelegatingHAndlersForDataPlane(currentEnvironment, new AdlMockDelegatingHandler());
            AdlsClientFactory.MockCredentials = currentEnvironment.TokenInfo[TokenAudience.Management];
        }
    }
}
