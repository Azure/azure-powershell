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

using System;
using System.Linq;
using System.Reflection;

using Microsoft.Azure.Commands.Management.IotHub;
using Microsoft.WindowsAzure.Commands.ScenarioTest;

using Xunit;

namespace Microsoft.Azure.Commands.IotHub.Test.UnitTests
{
    public class NewAzureRmIotHubKeyTests
    {
        private static readonly MethodInfo RegenerateKeyMethod = typeof(NewAzureRmIotHubKey).GetMethod(
            "RegenerateKey",
            BindingFlags.NonPublic | BindingFlags.Static);

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RegenerateKeyReturnsThirtyTwoNonDegenerateBytes()
        {
            byte[] key = Convert.FromBase64String(RegenerateKey());

            Assert.Equal(32, key.Length);
            Assert.True(key.Distinct().Count() > 1, "The generated key must not consist of one repeated byte.");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RegenerateKeyReturnsUniqueValues()
        {
            const int keyCount = 16;
            string[] keys = Enumerable.Range(0, keyCount)
                .Select(_ => RegenerateKey())
                .ToArray();

            Assert.Equal(keyCount, keys.Distinct().Count());
        }

        private static string RegenerateKey()
        {
            Assert.NotNull(RegenerateKeyMethod);
            return (string)RegenerateKeyMethod.Invoke(null, null);
        }
    }
}
