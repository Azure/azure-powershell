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

namespace Microsoft.Azure.Commands.TrafficManager.Test.ScenarioTests
{
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Xunit;
    using Xunit.Abstractions;
    public class ProfileTests : TrafficManagerTestRunner
    {
        public ProfileTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileCrud()
        {
            TestRunner.RunTestScript("Test-ProfileCrud");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileCrudWithPiping()
        {
            TestRunner.RunTestScript("Test-ProfileCrudWithPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateDeleteUsingProfile()
        {
            TestRunner.RunTestScript("Test-CreateDeleteUsingProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCrudWithEndpoint()
        {
            TestRunner.RunTestScript("Test-CrudWithEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCrudWithEndpointGeo()
        {
            TestRunner.RunTestScript("Test-CrudWithEndpointGeo");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListProfilesInResourceGroup()
        {
            TestRunner.RunTestScript("Test-ListProfilesInResourceGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListProfilesInSubscription()
        {
            TestRunner.RunTestScript("Test-ListProfilesInSubscription");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListProfilesWhereObject()
        {
            TestRunner.RunTestScript("Test-ListProfilesWhereObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileNewAlreadyExists()
        {
            TestRunner.RunTestScript("Test-ProfileNewAlreadyExists");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileRemoveNonExisting()
        {
            TestRunner.RunTestScript("Test-ProfileRemoveNonExisting");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileEnable()
        {
            TestRunner.RunTestScript("Test-ProfileEnable");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileEnablePipeline()
        {
            TestRunner.RunTestScript("Test-ProfileEnablePipeline");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileEnableNonExisting()
        {
            TestRunner.RunTestScript("Test-ProfileEnableNonExisting");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileDisable()
        {
            TestRunner.RunTestScript("Test-ProfileDisable");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileDisablePipeline()
        {
            TestRunner.RunTestScript("Test-ProfileDisablePipeline");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileDisableNonExisting()
        {
            TestRunner.RunTestScript("Test-ProfileDisableNonExisting");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileMonitorDefault()
        {
            TestRunner.RunTestScript("Test-ProfileMonitorDefaults");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileMonitorCustom()
        {
            TestRunner.RunTestScript("Test-ProfileMonitorCustom");
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileMonitorProtocol()
        {
            TestRunner.RunTestScript("Test-ProfileMonitorProtocol");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileMonitorParameterAliases()
        {
            TestRunner.RunTestScript("Test-ProfileMonitorParameterAliases");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAndRemoveCustomHeadersFromProfile()
        {
            TestRunner.RunTestScript("Test-AddAndRemoveCustomHeadersFromProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAndRemoveExpectedStatusCodeRanges()
        {
            TestRunner.RunTestScript("Test-AddAndRemoveExpectedStatusCodeRanges");
        }
    }
}
