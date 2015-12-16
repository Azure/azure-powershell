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

namespace Commands.Network.Test.ScenarioTests
{
    public class PublicIpAddressTests : Microsoft.WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        [Fact(Skip = "TODO, [#108248038]: Enable scenario tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPublicIpAddressCRUD()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-PublicIpAddressCRUD");
        }

        [Fact(Skip = "TODO, [#108248038]: Enable scenario tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPublicIpAddressCRUDNoDomainNameLabel()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-PublicIpAddressCRUD-NoDomainNameLabel");
        }

        [Fact(Skip = "TODO, [#108248038]: Enable scenario tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPublicIpAddressCRUDStaticAllocation()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-PublicIpAddressCRUD-StaticAllocation");
        }

        [Fact(Skip = "TODO, [#108248038]: Enable scenario tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPublicIpAddressCRUDEditDomainNameLavel()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-PublicIpAddressCRUD-EditDomainNameLavel");
        }

        [Fact(Skip = "TODO, [#108248038]: Enable scenario tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPublicIpAddressCRUDReverseFqdn()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-PublicIpAddressCRUD-ReverseFqdn");
        }
    }
}
