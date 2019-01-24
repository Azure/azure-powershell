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
    using ServiceManagement.Common.Models;
    using Xunit;
    using Xunit.Abstractions;
    public class ProfileTests
    {
        public XunitTracingInterceptor _logger;

        public ProfileTests(ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileCrud()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ProfileCrud");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileCrudWithPiping()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ProfileCrudWithPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateDeleteUsingProfile()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-CreateDeleteUsingProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCrudWithEndpoint()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-CrudWithEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCrudWithEndpointGeo()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-CrudWithEndpointGeo");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListProfilesInResourceGroup()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ListProfilesInResourceGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListProfilesInSubscription()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ListProfilesInSubscription");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListProfilesWhereObject()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ListProfilesWhereObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileNewAlreadyExists()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ProfileNewAlreadyExists");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileRemoveNonExisting()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ProfileRemoveNonExisting");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileEnable()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ProfileEnable");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileEnablePipeline()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ProfileEnablePipeline");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileEnableNonExisting()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ProfileEnableNonExisting");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileDisable()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ProfileDisable");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileDisablePipeline()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ProfileDisablePipeline");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileDisableNonExisting()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ProfileDisableNonExisting");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileMonitorDefault()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ProfileMonitorDefaults");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileMonitorCustom()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ProfileMonitorCustom");
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileMonitorProtocol()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ProfileMonitorProtocol");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileMonitorParameterAliases()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ProfileMonitorParameterAliases");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAndRemoveCustomHeadersFromProfile()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-AddAndRemoveCustomHeadersFromProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAndRemoveExpectedStatusCodeRanges()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-AddAndRemoveExpectedStatusCodeRanges");
        }
    }
}
