using Microsoft.Azure.Commands.Common.Strategies.Json;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.Azure.Commands.Common.Strategies.UnitTest.Json
{
    public class TypedObjectTest
    {
        public class X
        {
            public int A { get; set; }

            public string B { get; set; }

            [JsonProperty("xxx")]
            public int? C { get;set; }

            [JsonProperty("ab.cd\\.x")]
            public List<int> D { get; set; }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ObjectTest()
        {
            var converters = new Converters();
            var jToken = converters.Serialize<object>(new X { A = 3, B = "b", C = 4 });
            Assert.Equal(JTokenType.Object, jToken.Type);
            var jObject = jToken as JObject;
            Assert.Equal(3.0, jObject["A"]);
            Assert.Equal("b", jObject["B"]);
            Assert.Equal(4, jObject["xxx"]);
            var value = converters.Deserialize<object>(jToken) as IDictionary<string, object>;
            Assert.Equal(3.0, value["A"]);
            Assert.Equal("b", value["B"]);
            Assert.Equal(4.0, value["xxx"]);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Test()
        {
            var converters = new Converters();
            var jToken = converters.Serialize(
                new X { A = 3, B = "b", D = new List<int> { 4, 5 } });
            Assert.Equal(JTokenType.Object, jToken.Type);
            var jObject = jToken as JObject;
            Assert.Equal(3.0, jObject["A"]);
            Assert.Equal("b", jObject["B"]);
            var ab = jObject["ab"] as JObject;
            var list = ab["cd.x"] as JArray;
            Assert.Equal(2, list.Count);
            Assert.Equal(4.0, list[0].ToObject<double>());
            Assert.Equal(5.0, list[1].ToObject<double>());
            var value = converters.Deserialize<X>(jToken);
            Assert.Equal(3, value.A);
            Assert.Equal("b", value.B);
            Assert.Null(value.C);
            Assert.Equal(2, value.D.Count);
            Assert.Equal(4, value.D[0]);
            Assert.Equal(5, value.D[1]);
        }
    }
}
