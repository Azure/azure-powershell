//
// Copyright (c) Microsoft.  All rights reserved.
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

using Microsoft.Azure.Commands.TestFx;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Test.ScenarioTests
{
    public class ApiManagementTestRunner
    {
        protected readonly ITestRunner TestRunner;

        protected ApiManagementTestRunner(ITestOutputHelper output)
        {
            TestRunner = TestManager.CreateInstance(output)
                .WithNewPsScriptFilename($"{GetType().Name}.ps1")
                .WithProjectSubfolderForTests("ScenarioTests")
                .WithCommonPsScripts(new[]
                {
                    @"Common.ps1"
                })
                .WithNewRmModules(helper => new[]
               {
                    helper.RMProfileModule,
                    helper.GetRMModulePath("Az.ApiManagement.psd1")
                })
                .Build();
        }
    }
}
