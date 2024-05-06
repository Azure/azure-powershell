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

namespace Microsoft.Azure.Commands.FrontDoor.Test.ScenarioTests.ScenarioTest
{
    public class FrontDoorTests : FrontDoorTestRunner
    {
        public FrontDoorTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFrontDoorCrud()
        {
            TestRunner.RunTestScript("Test-FrontDoorCrud");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFrontDoorCrudDefaults()
        {
            TestRunner.RunTestScript("Test-FrontDoorCrudDefaults");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFrontDoorCrudWithPiping()
        {
            TestRunner.RunTestScript("Test-FrontDoorCrudWithPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFrontDoorRulesEngineCrud()
        {
            TestRunner.RunTestScript("Test-FrontDoorRulesEngineCrud");
        }

        //[Fact]
        //[Trait(Category.AcceptanceType, Category.CheckIn)]
        //public void TestFrontDoorEndpointCustomDomainHTTPSFrontDoor()
        //{
        //    TestController.NewInstance.RunPowerShellTest(_logger, "Test-FrontDoorEndpointCustomDomainHTTPS-FrontDoor");
        //}

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFrontDoorEndpointCustomDomainHTTPSByocSpecificVersion()
        {
            TestRunner.RunTestScript("Test-FrontDoorEndpointCustomDomainHTTPS-BYOC-SpecificVersion");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFrontDoorEndpointCustomDomainHTTPSByocLatestVersion()
        {
            TestRunner.RunTestScript("Test-FrontDoorEndpointCustomDomainHTTPS-BYOC-LatestVersion");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFrontDoorCrudRedirect()
        { 
            TestRunner.RunTestScript("Test-FrontDoorCrudRedirect");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFrontDoorCrudPrivateLink()
        {
            TestRunner.RunTestScript("Test-FrontDoorCrudPrivateLink");
        }
    }
}
