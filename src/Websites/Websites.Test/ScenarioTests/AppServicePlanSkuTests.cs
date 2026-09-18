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

using Microsoft.Azure.Commands.WebApps.Utilities;
using Microsoft.Azure.Management.WebSites.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.Azure.Commands.Websites.Test.ScenarioTests
{
    public class AppServicePlanSkuTests
    {
        public static IEnumerable<object[]> IsolatedV4Skus
        {
            get
            {
                yield return new object[] { "IsolatedV4", "Small", "I1V4" };
                yield return new object[] { "IsolatedV4", "Medium", "I2V4" };
                yield return new object[] { "IsolatedV4", "Large", "I3V4" };
                yield return new object[] { "IsolatedV4", "ExtraLarge", "I4V4" };
                yield return new object[] { "IsolatedV4", "ExtraExtraLarge", "I5V4" };
                yield return new object[] { "IsolatedV4", "ExtraExtraExtraLarge", "I6V4" };
                yield return new object[] { "IsolatedMV4", "Small", "I1MV4" };
                yield return new object[] { "IsolatedMV4", "Medium", "I2MV4" };
                yield return new object[] { "IsolatedMV4", "Large", "I3MV4" };
                yield return new object[] { "IsolatedMV4", "ExtraLarge", "I4MV4" };
                yield return new object[] { "IsolatedMV4", "ExtraExtraLarge", "I5MV4" };
            }
        }

        [Theory]
        [MemberData(nameof(IsolatedV4Skus))]
        public void CreateSkuDescriptionUsesIsolatedV4TierAndExpectedName(string tier, string workerSize, string expectedName)
        {
            SkuDescription sku = CmdletHelpers.CreateSkuDescription(tier, workerSize, 2);

            Assert.Equal("IsolatedV4", sku.Tier);
            Assert.Equal(expectedName, sku.Name);
            Assert.Equal(2, sku.Capacity);
        }

        [Theory]
        [MemberData(nameof(IsolatedV4Skus))]
        public void UpdateSkuDescriptionUsesIsolatedV4TierAndExpectedName(string tier, string workerSize, string expectedName)
        {
            var sku = new SkuDescription
            {
                Tier = "Basic",
                Name = "B1",
                Capacity = 2
            };

            CmdletHelpers.UpdateSkuDescription(sku, tier, workerSize, tierIsBound: true, workerSizeIsBound: true);

            Assert.Equal("IsolatedV4", sku.Tier);
            Assert.Equal(expectedName, sku.Name);
            Assert.Equal(expectedName, sku.Size);
            Assert.Equal("I", sku.Family);
            Assert.Equal(2, sku.Capacity);
        }

        [Fact]
        public void UpdateWorkerSizePreservesIsolatedV4MemoryOptimizedVariant()
        {
            var sku = new SkuDescription
            {
                Tier = "IsolatedV4",
                Name = "I1MV4",
                Capacity = 1
            };

            CmdletHelpers.UpdateSkuDescription(sku, tier: null, workerSize: "Medium", tierIsBound: false, workerSizeIsBound: true);

            Assert.Equal("IsolatedV4", sku.Tier);
            Assert.Equal("I2MV4", sku.Name);
            Assert.Equal("I2MV4", sku.Size);
            Assert.Equal("I", sku.Family);
        }

        [Fact]
        public void UpdateWithoutTierOrWorkerSizePreservesExistingSku()
        {
            var sku = new SkuDescription
            {
                Tier = "IsolatedV4",
                Name = "I5MV4",
                Capacity = 1
            };

            CmdletHelpers.UpdateSkuDescription(sku, tier: null, workerSize: null, tierIsBound: false, workerSizeIsBound: false);

            Assert.Equal("IsolatedV4", sku.Tier);
            Assert.Equal("I5MV4", sku.Name);
            Assert.Equal("I5MV4", sku.Size);
            Assert.Equal("I", sku.Family);
        }

        [Theory]
        [InlineData("IsolatedV4", 0)]
        [InlineData("IsolatedV4", 7)]
        [InlineData("IsolatedMV4", 0)]
        [InlineData("IsolatedMV4", 6)]
        public void GetSkuNameRejectsUnsupportedIsolatedV4WorkerSizes(string tier, int workerSize)
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => CmdletHelpers.GetSkuName(tier, workerSize));

            Assert.Equal("workerSize", exception.ParamName);
            Assert.Contains(tier, exception.Message);
        }
    }
}
