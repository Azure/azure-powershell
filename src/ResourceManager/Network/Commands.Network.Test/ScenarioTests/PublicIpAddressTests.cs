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
    public class PublicIpAddressTests : Microsoft.WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public PublicIpAddressTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestPublicIpAddressCRUD()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-PublicIpAddressCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestPublicIpAddressCRUDPublicIPPrefix()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-PublicIpAddressCRUD-PublicIPPrefix");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestPublicIpAddressCRUDNoDomainNameLabel()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-PublicIpAddressCRUD-NoDomainNameLabel");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestPublicIpAddressCRUDStaticAllocation()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-PublicIpAddressCRUD-StaticAllocation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestPublicIpAddressCRUDEditDomainNameLavel()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-PublicIpAddressCRUD-EditDomainNameLavel");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestPublicIpAddressCRUDReverseFqdn()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-PublicIpAddressCRUD-ReverseFqdn");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestPublicIpAddressCRUDIpTag()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-PublicIpAddressCRUD-IpTag");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestPublicIpAddressIpVersion()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-PublicIpAddressIpVersion");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestPublicIpAddressVmss()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-PublicIpAddressVmss");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestPublicIpBasicSku()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-PublicIpAddressCRUD-BasicSku");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestPublicIpStandardSku()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-PublicIpAddressCRUD-StandardSku");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestPublicIpAddressZones()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-PublicIpAddressZones");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestPublicIpAddressCRUDIdleTimeout()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-PublicIpAddressCRUD-IdleTimeout");
        }
    }
}
