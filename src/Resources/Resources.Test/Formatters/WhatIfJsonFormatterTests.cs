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

namespace Microsoft.Azure.Commands.Resources.Test.Formatters
{
    using Newtonsoft.Json.Linq;
    using ResourceManager.Cmdlets.Formatters;
    using System;
    using WindowsAzure.Commands.ScenarioTest;
    using Xunit;

    public class WhatIfJsonFormatterTests
    {
        private static readonly string Colon =
            new ColorStringBuilder().Append(":", Color.Reset).ToString();

        private static readonly string LeftSquareBracket =
            new ColorStringBuilder().Append("[", Color.Reset).ToString();

        private static readonly string RightSquareBracket =
            new ColorStringBuilder().Append("]", Color.Reset).ToString();

        private readonly WhatIfJsonFormatter sut;

        public WhatIfJsonFormatterTests()
        {
            sut = new WhatIfJsonFormatter();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FormatJson_NullValue_ConvertsToLowercaseString()
        {
            sut.FormatJson(JValue.CreateNull());

            Assert.Equal("null", sut.Result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FormatJson_IntegerValue_ConvertsToString()
        {
            sut.FormatJson(12345654321);

            Assert.Equal("12345654321", sut.Result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FormatJson_FloatValue_ConvertsToString()
        {
            sut.FormatJson(2414124.79579);

            Assert.Equal("2414124.79579", sut.Result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FormatJson_TrueValue_ConvertsToLowercaseString()
        {
            sut.FormatJson(true);

            Assert.Equal("true", sut.Result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FormatJson_FalseValue_ConvertsToLowercaseString()
        {
            sut.FormatJson(false);

            Assert.Equal("false", sut.Result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FormatJson_StringValue_WrapsContentWithDoubleQuotes()
        {
            sut.FormatJson("foobar");

            Assert.Equal(@"""foobar""", sut.Result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FormatJson_ArrayValue_AlignsItems()
        {
            // Arrange.
            JArray arrayValue = JArray.Parse(@"[0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]");
            var expected = @"[
  0:  0
  1:  1
  2:  2
  3:  3
  4:  4
  5:  5
  6:  6
  7:  7
  8:  8
  9:  9
  10: 10
]"
                .Replace("[", LeftSquareBracket)
                .Replace("]", RightSquareBracket)
                .Replace(":", Colon);

            // Act.
            sut.FormatJson(arrayValue);

            // Assert.
            Assert.Equal(expected, sut.Result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FormatJson_ObjectValue_AlignsValues()
        {
            // Arrange.
            JObject objectValue = JObject.FromObject(new
            {
                path = new
                {
                    to = new
                    {
                        foo = "foo"
                    }
                },
                longPath = new
                {
                    to = new
                    {
                        bar = "bar"
                    }
                }
            });

            var expected = @"

  path.to.foo:     ""foo""
  longPath.to.bar: ""bar""
"
                .Replace(":", Colon);

            // Act.
            sut.FormatJson(objectValue);

            // Assert.
            Assert.Equal(expected, sut.Result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FormatJson_ComplexValue_HandlesNestedArraysAndObjects()
        {
            // Arrange.
            JObject objectValue = JObject.FromObject(new
            {
                root = new
                {
                    foo = 1234,
                    bar = new object[]
                    {
                        true,
                        null,
                        new
                        {
                            nestedString = "value",
                            nestedArray = new object[]
                            {
                                92747,
                                "test"
                            }
                        },
                        new object[]
                        {
                            false
                        }
                    },
                    foobar = "foobar"
                }
            });

            var expected = @"

  root.foo:    1234
  root.bar: [
    0: true
    1: null
    2:

      nestedString: ""value""
      nestedArray: [
        0: 92747
        1: ""test""
      ]

    3: [
      0: false
    ]
  ]
  root.foobar: ""foobar""
"
                .Replace("[", LeftSquareBracket)
                .Replace("]", RightSquareBracket)
                .Replace(":", Colon);

            // Act.
            sut.FormatJson(objectValue);

            // Assert.
            Assert.Equal(expected, sut.Result);
        }
    }
}
