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

using System.Collections.Generic;
using Microsoft.Azure.Commands.TestFx;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.EventHub.Test.ScenarioTests
{
    public class EventHubTestRunner
    {
        protected readonly ITestRunner TestRunner;

        protected EventHubTestRunner(ITestOutputHelper output)
        {
            TestRunner = TestFx.TestManager.CreateInstance(output)
                .WithNewPsScriptFilename($"{GetType().Name}.ps1")
                .WithProjectSubfolderForTests("ScenarioTests")
                .WithCommonPsScripts(new[]
                {
                    @"../AzureRM.Resources.ps1",
                    @"../AzureRM.Storage.ps1"
                })
                .WithNewRmModules(helper => new[]
               {
                    helper.RMProfileModule,
                    helper.GetRMModulePath("AzureRM.EventHub.psd1"),
                    helper.GetRMModulePath("AzureRM.KeyVault.psd1"),
                    helper.GetRMModulePath("AzureRM.ManagedServiceIdentity.psd1"),
                    helper.GetRMModulePath("AzureRM.Network.psd1"),
                })
                .WithRecordMatcher(
                    (ignoreResourcesClient, resourceProviders, userAgentsToIgnore) =>
                        new PermissiveRecordMatcherWithApiExclusion(ignoreResourcesClient, resourceProviders, userAgentsToIgnore)
                )
                .WithNewRecordMatcherArguments(
                    userAgentsToIgnore: new Dictionary<string, string>
                    {
                        {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"},
                        {"Microsoft.Azure.Management.ResourceManager.ResourceManagementClient", "2017-05-10"},
                        {"Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient", "2016-09-01"},
                    },
                    resourceProviders: new Dictionary<string, string>
                    {
                        {"Microsoft.Resources", null},
                        {"Microsoft.Features", null},
                        {"Microsoft.Authorization", null},
                        {"Microsoft.Storage", null},
                        {"Microsoft.KeyVault", null},
                        {"Microsoft.ManagedServiceIdentity", null}
                    }
                )
                .Build();
        }
    }
}
