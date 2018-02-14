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

using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.Azure.Commands.ManagementPartner;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.ManagementPartner.Test.ScenarioTests
{
    public class ManagementPartnerTests : RMTestBase
    {
        public ManagementPartnerTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPartner()
        {
            TestController.NewInstance.RunPsTest( "Test-GetPartner");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPartnerNoParnterId()
        {
            TestController.NewInstance.RunPsTest("Test-GetPartnerNoPartnerId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewParnter()
        {
            TestController.NewInstance.RunPsTest("Test-NewPartner");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateParnter()
        {
            TestController.NewInstance.RunPsTest("Test-UpdatePartner");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveParnter()
        {
            TestController.NewInstance.RunPsTest("Test-RemovePartner");
        }
    }
}
