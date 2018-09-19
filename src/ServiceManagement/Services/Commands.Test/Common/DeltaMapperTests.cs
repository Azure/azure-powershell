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
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.Test.Common
{
    
    public class DeltaMapperTests
    {
        class SourceClass
        {
            public int? A { get; set; }
            public bool? B { get; set; }
            public string C { get; set; }
            public double Excluded { get; set; }
        }

        class RefClass
        {
            public int? A { get; set; }
            public string C { get; set; }
        }

        class DestClass
        {
            public int? A { get; set; }
            public bool? B { get; set; }
            public string C { get; set; }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MappingWithNoChangesReturnsFalse()
        {
            var src = new SourceClass
            {
                A = 1,
                B = true,
                C = "hello",
                Excluded = 42.0
            };

            var reference = new RefClass
            {
                A = 1,
                C = "hello"
            };

            var dest = new DestClass();

            bool changes = ObjectDeltaMapper.Map(src, reference, dest, "Excluded");
            Assert.False(changes);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MappingWithChangeCopiesChangedProperties()
        {
            var src = new SourceClass
            {
                A = 1,
                B = true,
                C = "hello",
                Excluded = 42.0
            };

            var reference = new RefClass
            {
                A = 4,
                C = "hello"
            };

            var dest = new DestClass();

            bool changes = ObjectDeltaMapper.Map(src, reference, dest, "Excluded");
            Assert.True(changes);
            Assert.Equal(1, dest.A);
            Assert.Null(dest.C);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NullSourcePropertyIsNotAChange()
        {
            var src = new SourceClass
            {
                A = null,
                C = "hello"
            };

            var reference = new RefClass
            {
                A = 4,
                C = "hello"
            };

            var dest = new DestClass();
            bool changes = ObjectDeltaMapper.Map(src, reference, dest);
            Assert.False(changes);
        }
    }
}
