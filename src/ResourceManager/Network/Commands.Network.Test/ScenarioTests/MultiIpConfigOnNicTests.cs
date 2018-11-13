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
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Commands.Network.Test.ScenarioTests
{
    public class MultiIpConfigOnNicTests : Microsoft.WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public MultiIpConfigOnNicTests(ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestMultiIpConfigCRUD()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-MultiIpConfigCRUD");
        }

        [Fact]
        /// current error is: LoadBalancingRules are not supported for secondary IpConfigurations. 
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestLBWithMultiIpConfigNICCRUD()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LBWithMultiIpConfigNICCRUD");
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestAddNICToLBWithMultiIpConfig()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-AddNICToLBWithMultiIpConfig");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        /// Public IP is not supported on secondary IpConfigurations
        public void TestLBWithMultiIpConfigMultiNIC()
        {

            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LBWithMultiIpConfigMultiNIC");
        }
    }
}
