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

using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using Xunit;

namespace Microsoft.Azure.Commands.Profile.Test
{
    public class TelemetryTests
    {
#if !NETSTANDARD
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void HashOfNullValueThrowsAppropriateException()
        {
            Assert.Throws<ArgumentNullException>(() => MetricHelper.GenerateSha256HashString(null));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void HashOfValidValueSucceeds()
        {
            string inputValue = "Sample value to hash of suitable length and complexity.";
            var hash = MetricHelper.GenerateSha256HashString(inputValue);
            Assert.NotNull(hash);
            Assert.True(hash.Length > 0);
            Assert.NotEqual<string>(inputValue, hash, StringComparer.OrdinalIgnoreCase);
        }
#endif
    }
}
