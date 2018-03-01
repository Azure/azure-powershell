﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public class AuthorizationTests
    {
        public AuthorizationTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        //[Trait(Category.AcceptanceType, Category.CheckIn)]
        [Fact(Skip = "TODO: Fix the broken outdated test. The test cleans up all assignments, but some assignments are needed for the service scenario tests")]
        public void TestAuthorizationEndToEnd()
        {
            ResourcesController.NewInstance.RunPsTest("Test-AuthorizationEndToEnd");
        }
    }
}
