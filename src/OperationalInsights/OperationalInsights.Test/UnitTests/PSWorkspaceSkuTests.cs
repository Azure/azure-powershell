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

using System.Management.Automation;
using Microsoft.Azure.Commands.OperationalInsights.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.OperationalInsights.Test.UnitTests
{
    public class PSWorkspaceSkuTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanSetCapacityWithCapacityReservationSku()
        {
            var sku = new PSWorkspaceSku("CapacityReservation", 1000);

            Assert.Equal("CapacityReservation", sku.Name);
            Assert.Equal(1000, sku.Capacity);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ThrowsWhenCapacitySetForNonCapacityReservationSku()
        {
            Assert.Throws<PSArgumentException>(() => new PSWorkspaceSku("pergb2018", 1000));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateNonCapacityReservationSkuWithoutCapacity()
        {
            var sku = new PSWorkspaceSku("pergb2018");

            Assert.Equal("pergb2018", sku.Name);
            Assert.Null(sku.Capacity);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ThrowsWhenCapacityBelowMinimum()
        {
            Assert.Throws<PSArgumentException>(() => new PSWorkspaceSku("CapacityReservation", 100));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ThrowsWhenCapacityNotMultipleOf100()
        {
            Assert.Throws<PSArgumentException>(() => new PSWorkspaceSku("CapacityReservation", 1050));
        }
    }
}
