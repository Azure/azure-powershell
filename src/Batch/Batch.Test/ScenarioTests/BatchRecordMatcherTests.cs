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

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class BatchRecordMatcherTests
    {
        private const string Key = "POST L2pvYnM=";

        private static string KeyFor(string body)
        {
            return BatchRecordMatcher.WithBody(Key, "POST", body);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SameBodyWithPropertiesInAnotherOrderMatches()
        {
            Assert.Equal(
                KeyFor("{\"id\":\"job1\",\"poolInfo\":{\"poolId\":\"p\"},\"priority\":0}"),
                KeyFor("{\r\n  \"priority\": 0,\r\n  \"poolInfo\": { \"poolId\": \"p\" },\r\n  \"id\": \"job1\"\r\n}"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NamedItemsInAnotherOrderMatch()
        {
            Assert.Equal(
                KeyFor("{\"environmentSettings\":[{\"name\":\"a\",\"value\":\"1\"},{\"name\":\"b\"}]}"),
                KeyFor("{\"environmentSettings\":[{\"name\":\"b\"},{\"name\":\"a\",\"value\":\"1\"}]}"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void OtherListsKeepTheirOrder()
        {
            Assert.NotEqual(KeyFor("{\"taskIds\":[\"a\",\"b\"]}"), KeyFor("{\"taskIds\":[\"b\",\"a\"]}"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SameTimeInAnotherTimeZoneMatches()
        {
            Assert.Equal(
                KeyFor("{\"expiryTime\":\"2025-11-03T22:35:23.4621363Z\"}"),
                KeyFor("{\"expiryTime\":\"2025-11-03T14:35:23.4621363-08:00\"}"));
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("{\"name\":\"a\"}", "{\"name\":\"a\",\"value\":\"\"}")]
        [InlineData("{\"name\":\"a\",\"value\":null}", "{\"name\":\"a\"}")]
        [InlineData("{\"id\":\"p\"}", "{\"id\":\"p\",\"metadata\":[]}")]
        [InlineData("{\"id\":\"p\",\"targetDedicatedNodes\":0}", "{\"id\":\"p\",\"targetDedicatedNodes\":1}")]
        public void DifferentBodiesDoNotMatch(string recorded, string sent)
        {
            Assert.NotEqual(KeyFor(recorded), KeyFor(sent));
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("GET", "{\"id\":\"job1\"}")]
        [InlineData("DELETE", "{\"id\":\"job1\"}")]
        [InlineData("POST", null)]
        [InlineData("POST", "")]
        [InlineData("POST", "not json")]
        [InlineData("PUT", "AAECAw==")]
        [InlineData("POST", "{not json")]
        public void BodyIsLeftOutWhenNotSentOrNotJson(string method, string body)
        {
            Assert.Equal(Key, BatchRecordMatcher.WithBody(Key, method, body));
        }
    }
}
