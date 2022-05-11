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
using Xunit.Abstractions;
using Microsoft.Azure.Commands.TestFx;

namespace Microsoft.Azure.Commands.DeploymentManager.Test.ScenarioTests
{
    public class DeploymentManagerTestRunner
    {
        protected readonly ITestRunner TestRunner;

        protected DeploymentManagerTestRunner(ITestOutputHelper output)
        {
            TestRunner = TestManager.CreateInstance(output)
                .WithNewPsScriptFilename($"{GetType().Name}.ps1")
                .WithProjectSubfolderForTests("ScenarioTests")
                .WithCommonPsScripts(new[]
                {
                    @"DeploymentManagerTestsCommon.ps1",
                    @"../AzureRM.Storage.ps1"
                })
                .WithNewRmModules(helper => new[]
                {
                    helper.RMProfileModule,
                    helper.GetRMModulePath(@"Az.ManagedServiceIdentity.psd1"),
                    helper.GetRMModulePath(@"Az.Storage.psd1"),
                    helper.GetRMModulePath(@"Az.Resources.psd1"),
                    helper.GetRMModulePath(@"Az.DeploymentManager.psd1")
                })
                .WithNewRecordMatcherArguments(
                    userAgentsToIgnore: new Dictionary<string, string>(),
                    resourceProviders: new Dictionary<string, string>
                    {
                        {"Microsoft.Resources", null},
                        {"Microsoft.Features", null},
                        {"Microsoft.Authorization", null}
                    }
                )
                .Build();
        }
    }
}
