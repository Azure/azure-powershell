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

namespace Microsoft.Azure.Commands.Resources.Test.Json
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Json;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public class PSJsonSerializerTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Serialize_Null_Success()
        {
            string result = PSJsonSerializer.Serialize(null);

            Assert.Equal("null", result);
        }

        [Theory]
        [MemberData(nameof(PrimitiveData))]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Serialize_PrimitiveValue_Success(object value, string expected)
        {
            string result = PSJsonSerializer.Serialize(value);

            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(PrimitiveData))]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Serialize_PSObject_SerializesUnderlyingPrimitiveValue(object value, string expected)
        {
            var psObject = new PSObject(value);

            string result = PSJsonSerializer.Serialize(psObject);

            Assert.Equal(expected, result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Serialize_Hashtable_Success()
        {
            var hashtable = new Hashtable
            {
                ["foo"] = new PSObject("fooValue"),
                ["Bar"] = true,
                ["nested"] = new Hashtable
                {
                    ["foo"] = new PSObject(Guid.Parse("4d44fe86-f04a-4ba5-9900-abdec8cb11c1")),
                    ["bar"] = new object[]
                    {
                        "test",
                        true,
                        123,
                        new Hashtable
                        {
                            ["deepNested"] = new PSObject("leaf"),
                            ["array"] = new object[]
                            {
                                new PSObject("abc"),
                                new PSObject(new
                                {
                                    stuff = false
                                })
                            }
                        }
                    }
                }
            };

            string result = PSJsonSerializer.Serialize(hashtable);

            JToken parsedResult = result.FromJson<JToken>();

            JToken expected = JToken.FromObject(new
            {
                foo = "fooValue",
                Bar = true,
                nested = new
                {
                    foo = "4d44fe86-f04a-4ba5-9900-abdec8cb11c1",
                    bar = new object[]
                    {
                        "test",
                        true,
                        123,
                        new
                        {
                            deepNested = "leaf",
                            array = new object[]
                            {
                                "abc",
                                new
                                {
                                    stuff = false
                                }
                            }
                        }
                    }
                }
            });
            Assert.True(JToken.DeepEquals(expected, parsedResult));
        }

        public static IEnumerable<object[]> PrimitiveData => new List<object[]>
        {
            new object[] { 42, "42" },
            new object[] { 3.1415926, "3.1415926" },
            new object[] { 3.1415926M, "3.1415926" },
            new object[] { true, "true" },
            new object[] { false, "false" },
            new object[] { "foobar", "\"foobar\"" },
            new object[] { Guid.Parse("4d44fe86-f04a-4ba5-9900-abdec8cb11c1"), "\"4d44fe86-f04a-4ba5-9900-abdec8cb11c1\"" },
            new object[] { new Uri("https://example.com"), "\"https://example.com\"" },
            new object[] { new DateTime(2020, 8, 1, 0, 0, 0, DateTimeKind.Utc), "\"2020-08-01T00:00:00Z\"" },
            new object[] { new DateTimeOffset(new DateTime(2020, 8, 1, 0, 0, 0, DateTimeKind.Utc)), "\"2020-08-01T00:00:00+00:00\"" },
        };
    }
}
