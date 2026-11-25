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

using Microsoft.Azure.Commands.Batch.Track2;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using Xunit;
using T2 = Azure.Compute.Batch;

namespace Microsoft.Azure.Commands.Batch.Test.Track2
{
    public class Track2RawJsonTests
    {
        private const string AccountUrl = "https://account.westus.batch.azure.com";

        private static readonly string Key = Convert.ToBase64String(Encoding.UTF8.GetBytes("account-key-not-a-real-key-00000"));

        private static readonly string[] AverageCpu = { "stats", "resourceStats", "avgCPUPercentage" };

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void StatisticsAreReadInFullFromTheAnswer()
        {
            RecordingHandler handler = new RecordingHandler().On("GET /pools/pool1", HttpStatusCode.OK, PoolJson("pool1", "2.123456789"));
            global::Azure.Response<T2.BatchPool> response = NewClient(handler).GetPool("pool1", expand: new[] { "stats" });

            // Azure.Compute.Batch 1.0.0 keeps about 7 digits; Track 1 kept 2.123456789.
            Assert.Equal(2.1234567f, response.Value.PoolStatistics.ResourceStatistics.AvgCpuPercentage);
            JsonElement? json = Track2RawJson.Of(response.GetRawResponse());
            Assert.Equal(2.123456789, Track2RawJson.GetDouble(json, AverageCpu));
            Assert.Equal(0.123456789012, Track2RawJson.GetDouble(json, "stats", "resourceStats", "diskReadGiB"));
            Assert.Equal(100, Track2RawJson.GetDouble(json, "stats", "resourceStats", "diskReadIOps"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EachItemOfAListGetsItsOwnJson()
        {
            RecordingHandler handler = TwoPagesOfPools();

            List<KeyValuePair<T2.BatchPool, JsonElement?>> items = Track2RawJson.WithJson(NewClient(handler).GetPools(expand: new[] { "stats" })).ToList();

            Assert.Equal(new[] { "pool1", "pool2", "pool3" }, items.Select(i => i.Key.Id));
            Assert.Equal(new double?[] { 1.123456789, 2.123456789, 3.123456789 }, items.Select(i => Track2RawJson.GetDouble(i.Value, AverageCpu)));
            Assert.Equal(2, handler.Requests.Count);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MaxCountWithTheJsonStopsThePagingEarly()
        {
            RecordingHandler handler = TwoPagesOfPools();
            int logs = 0;

            List<string> pools = Track2Lists.WithMaxCount(
                NewClient(handler).GetPools(expand: new[] { "stats" }),
                (pool, json) => pool.Id + "=" + Track2RawJson.GetDouble(json, AverageCpu)?.ToString("R", CultureInfo.InvariantCulture),
                2,
                () => logs++).ToList();

            Assert.Equal(1, logs);
            Assert.Equal(new[] { "pool1=1.123456789", "pool2=2.123456789" }, pools);
            Assert.Single(handler.Requests);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValuesThatArentThereAreNull()
        {
            JsonElement json = JsonDocument.Parse("{\"a\":{\"b\":\"2.5\",\"c\":true,\"d\":null},\"e\":[1]}").RootElement;

            Assert.Equal(2.5, Track2RawJson.GetDouble(json, "a", "b"));
            Assert.Null(Track2RawJson.GetDouble(json, "a", "c"));
            Assert.Null(Track2RawJson.GetDouble(json, "a", "d"));
            Assert.Null(Track2RawJson.GetDouble(json, "a", "x"));
            Assert.Null(Track2RawJson.GetDouble(json, "e", "x"));
            Assert.Null(Track2RawJson.GetDouble(null, "a"));
            Assert.Null(Track2RawJson.Of(null));
        }

        private static RecordingHandler TwoPagesOfPools()
        {
            return new RecordingHandler().OnPages("GET /pools",
                "{\"value\":[" + PoolJson("pool1", "1.123456789") + "," + PoolJson("pool2", "2.123456789") + "],"
                + "\"odata.nextLink\":\"" + AccountUrl + "/pools?api-version=2025-06-01&$skiptoken=page2\"}",
                "{\"value\":[" + PoolJson("pool3", "3.123456789") + "]}");
        }

        // A pool with its statistics in the form the service sends them (numbers, including the int64 ones).
        private static string PoolJson(string id, string averageCpu)
        {
            return "{\"id\":\"" + id + "\",\"stats\":{\"url\":\"" + AccountUrl + "/pools/" + id + "\",\"startTime\":\"2026-11-10T00:00:00Z\","
                + "\"lastUpdateTime\":\"2026-11-10T01:00:00Z\",\"resourceStats\":{\"startTime\":\"2026-11-10T00:00:00Z\",\"lastUpdateTime\":\"2026-11-10T01:00:00Z\","
                + "\"avgCPUPercentage\":" + averageCpu + ",\"avgMemoryGiB\":1.5,\"peakMemoryGiB\":2.5,\"avgDiskGiB\":3.5,\"peakDiskGiB\":4.5,"
                + "\"diskReadIOps\":100,\"diskWriteIOps\":200,\"diskReadGiB\":0.123456789012,\"diskWriteGiB\":6,\"networkReadGiB\":7,\"networkWriteGiB\":8}}}";
        }

        private static T2.BatchClient NewClient(RecordingHandler handler)
        {
            return new Track2TestContext(null, "account", AccountUrl, handler, Key).Track2Client;
        }
    }
}
