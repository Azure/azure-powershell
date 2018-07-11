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

using Microsoft.Azure.Commands.Common.Strategies.Compute;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Common.Strategies.UnitTest.Compute
{
    public class ImageVersionTest
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CompareToTest()
        {
            var a = ImageVersion.Parse("1.23.456");
            var b = ImageVersion.Parse("1.23");
            var c = ImageVersion.Parse("01.023");
            var d = ImageVersion.Parse("1.23.457");
            Assert.Equal(1, a.CompareTo(b));
            Assert.Equal(-1, b.CompareTo(a));
            Assert.Equal(0, b.CompareTo(c));
            Assert.Equal(-1, a.CompareTo(d));
            Assert.Equal(1, d.CompareTo(a));
        }
    }
}
