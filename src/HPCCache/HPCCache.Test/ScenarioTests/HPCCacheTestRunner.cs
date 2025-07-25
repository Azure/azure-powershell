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
using System.Collections.Generic;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.HPCCache.Test.ScenarioTests
{
    /// <summary>
    /// Base test controller class.
    /// </summary>
    public class HPCCacheTestRunner
    {
        protected readonly ITestRunner TestRunner;

        protected HPCCacheTestRunner(ITestOutputHelper output)
        {
            TestRunner = TestManager.CreateInstance(output)
                .WithNewPsScriptFilename($"{GetType().Name}.ps1")
                .WithProjectSubfolderForTests("ScenarioTests")
                .WithCommonPsScripts(new[]
                {
                    @"../AzureRM.Resources.ps1"
                })
                .WithNewRmModules(helper => new[]
                {
                    helper.RMProfileModule,
                    helper.GetRMModulePath("Az.HPCCache.psd1")
                })
                .WithNewRecordMatcherArguments(
                    resourceProviders: new Dictionary<string, string>
                    {
                        { "Microsoft.Resources", null },
                        { "Microsoft.Features", null },
                        { "Microsoft.Authorization", null },
                        { "Microsoft.Network", null }
                    },
                    userAgentsToIgnore: new Dictionary<string, string>
                    {
                        { "Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01" },
                        { "Microsoft.Azure.Management.ResourceManager.ResourceManagementClient", "2017-05-10" },
                    }
                )
                .Build();
        }
    }
}
