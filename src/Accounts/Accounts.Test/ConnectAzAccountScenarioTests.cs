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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Profile.Test
{
    public class ConnectAzAccountScenarioTests : AccountsTestRunner
    {
        public ConnectAzAccountScenarioTests(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestMaxContextPopulationWithSpecifiedValue()
        {
            TestRunner.RunTestScript("Test-MaxContextPopulationWithSpecifiedValue");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestMaxContextPopulationWithDefaultValue()
        {
            TestRunner.RunTestScript("Test-MaxContextPopulationWithDefaultValue");
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestMaxContextPopulationGetAll()
        {
            TestRunner.RunTestScript("Test-MaxContextPopulationGetAll");
        }

    }
}