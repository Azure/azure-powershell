using Microsoft.Azure.Commands.Common.Strategies.Json;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.Azure.Commands.Common.Strategies.UnitTest.Json
{
    public class JsonTest
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NullTest()
        {
            var converters = new Converters();
            var jToken = converters.Serialize<object>(null);
            Assert.Null(jToken);
            var value = converters.Deserialize<object>(jToken);
            Assert.Null(value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void StringTest()
        {
            var converters = new Converters();
            var jToken = converters.Serialize("Hello world!");
            Assert.Equal(JTokenType.String, jToken.Type);
            var value = converters.Deserialize<string>(jToken);
            Assert.Equal("Hello world!", value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ObjectStringTest()
        {
            var converters = new Converters();
            var jToken = converters.Serialize("Hello world!" as object);
            Assert.Equal(JTokenType.String, jToken.Type);
            var value = converters.Deserialize<object>(jToken);
            Assert.Equal("Hello world!", value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void BoolTest()
        {
            var converters = new Converters();
            var jToken = converters.Serialize(true);
            Assert.Equal(JTokenType.Boolean, jToken.Type);
            var value = converters.Deserialize<bool>(jToken);
            Assert.Equal(true, value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ObjectBoolTest()
        {
            var converters = new Converters();
            var jToken = converters.Serialize(true as object);
            Assert.Equal(JTokenType.Boolean, jToken.Type);
            var value = converters.Deserialize<object>(jToken);
            Assert.Equal(true, value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DoubleTest()
        {
            var converters = new Converters();
            var jToken = converters.Serialize(123.456);
            Assert.Equal(JTokenType.Float, jToken.Type);
            var value = converters.Deserialize<double>(jToken);
            Assert.Equal(123.456, value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ObjectDoubleTest()
        {
            var converters = new Converters();
            var jToken = converters.Serialize<object>(123.456);
            Assert.Equal(JTokenType.Float, jToken.Type);
            var value = converters.Deserialize<object>(jToken);
            Assert.Equal(123.456, value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ArrayTest()
        {
            var converters = new Converters();
            var jToken = converters.Serialize(new List<string> { "a", "b" });
            Assert.Equal(JTokenType.Array, jToken.Type);
            var value = converters.Deserialize<List<string>>(jToken);
            Assert.Equal(new List<string> { "a", "b" }, value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ObjectArrayTest()
        {
            var converters = new Converters();
            var jToken = converters.Serialize<object>(new List<string> { "a", "b" });
            Assert.Equal(JTokenType.Array, jToken.Type);
            var value = converters.Deserialize<object>(jToken);
            Assert.Equal(new List<object> { "a", "b" }, value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DictionaryTest()
        {
            var converters = new Converters();
            var jToken = converters.Serialize(new Dictionary<string, int>
            {
                { "A", 39 },
                { "B", 57 },
            });
            Assert.Equal(JTokenType.Object, jToken.Type);
            var value = converters.Deserialize<Dictionary<string, int>>(jToken);
            Assert.Equal(39, value["A"]);
            Assert.Equal(57, value["B"]);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ObjectDictionaryTest()
        {
            var converters = new Converters();
            var jToken = converters.Serialize<object>(new Dictionary<string, int>
            {
                { "A", 39 },
                { "B", 57 },
            });
            Assert.Equal(JTokenType.Object, jToken.Type);
            var value = converters.Deserialize<object>(jToken) as IDictionary<string, object>;
            Assert.Equal(39.0, value["A"]);
            Assert.Equal(57.0, value["B"]);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NullableTest()
        {
            var converters = new Converters();
            var jToken = converters.Serialize<int?>(3);
            Assert.Equal(JTokenType.Integer, jToken.Type);
            var value = converters.Deserialize<int?>(jToken);
            Assert.Equal(3, value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NullableNullTest()
        {
            var converters = new Converters();
            var jToken = converters.Serialize<int?>(null);
            Assert.Null(jToken);
            var value = converters.Deserialize<int?>(jToken);
            Assert.Null(value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ObjectNullableTest()
        {
            var converters = new Converters();
            var jToken = converters.Serialize<object>(3 as int?);
            Assert.Equal(JTokenType.Integer, jToken.Type);
            var value = converters.Deserialize<object>(jToken);
            Assert.Equal(3.0, value);
        }
    }
}
