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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Cdn.Test.ScenarioTests.ScenarioTest
{
    public class EndpointTests : CdnTestRunner
    {
        public EndpointTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEndpointCrudAndAction()
        {
            TestRunner.RunTestScript("Test-EndpointCrudAndAction");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEndpointCreateWithRulesEngine()
        {
            TestRunner.RunTestScript("Test-EndpointCreateWithRulesEngine");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEndpointCrudAndActionWithPiping()
        {
            TestRunner.RunTestScript("Test-EndpointCrudAndActionWithPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEndpointCrudAndActionWithAllProperties()
        {
            TestRunner.RunTestScript("Test-EndpointCrudAndActionWithAllProperties");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEndpointCreateWithDsa()
        {
            TestRunner.RunTestScript("Test-EndpointCreateWithDSA");
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEndpointCrudAndActionWithAllPropertiesWithPiping()
        {
            TestRunner.RunTestScript("Test-EndpointCrudAndActionWithAllPropertiesWithPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEndpointPipeline()
        {
            TestRunner.RunTestScript("Test-EndpointPipeline");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEndpointGeoFilters()
        {
            TestRunner.RunTestScript("Test-EndpointGeoFilters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEndpointResourceUsage()
        {
            TestRunner.RunTestScript("Test-EndpointResourceUsage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EndpointValidateProbeUrl()
        {
            TestRunner.RunTestScript("Test-EndpointValidateProbeUrl");
        }
    }
}
