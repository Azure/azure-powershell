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

using Microsoft.Azure.Commands.TestFx.Recorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class BatchRecordMatcherTests
    {
        private const string Key = "POST L2pvYnM=";

        // TestJobCRUD sends these two POST requests to the same URL. "Sent" is the body as the Batch SDK sends it,
        // "Recorded" as TestJobCRUD.json saved it.
        private const string AccountUrl = "https://account.westus2.batch.azure.com";
        private const string JobsPath = "/jobs?api-version=2024-07-01.20.0";
        private const string Job1Sent = "{\"id\":\"job1\",\"priority\":0,\"commonEnvironmentSettings\":[{\"name\":\"ThisIsNull\"},{\"name\":\"ThisIsAString\",\"value\":\"Hello world\"}],\"poolInfo\":{\"poolId\":\"testPool\"},\"usesTaskDependencies\":false}";
        private const string Job1Recorded = "{\r\n  \"id\": \"job1\",\r\n  \"priority\": 0,\r\n  \"commonEnvironmentSettings\": [\r\n    {\r\n      \"name\": \"ThisIsNull\"\r\n    },\r\n    {\r\n      \"name\": \"ThisIsAString\",\r\n      \"value\": \"Hello world\"\r\n    }\r\n  ],\r\n  \"poolInfo\": {\r\n    \"poolId\": \"testPool\"\r\n  },\r\n  \"usesTaskDependencies\": false\r\n}";
        private const string Job2Sent = "{\"id\":\"job2\",\"priority\":3,\"poolInfo\":{\"poolId\":\"testPool2\"},\"usesTaskDependencies\":false}";
        private const string Job2Recorded = "{\r\n  \"id\": \"job2\",\r\n  \"priority\": 3,\r\n  \"poolInfo\": {\r\n    \"poolId\": \"testPool2\"\r\n  },\r\n  \"usesTaskDependencies\": false\r\n}";

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

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("POST", JobsPath, Job1Sent)]
        [InlineData("PUT", "/jobs/job2?api-version=2024-07-01.20.0", "{\"priority\":5,\"constraints\":{\"maxWallClockTime\":\"P10675199DT2H48M5.4775807S\",\"maxTaskRetryCount\":0},\"poolInfo\":{\"poolId\":\"testPool2\"},\"onAllTasksComplete\":\"noaction\"}")]
        [InlineData("PATCH", "/pools/testPool?api-version=2024-07-01.20.0", "{\"metadata\":[{\"name\":\"meta1\",\"value\":\"value1\"}]}")]
        public void RequestMatchesTheEntryTheRecorderSavedForIt(string method, string pathAndQuery, string body)
        {
            AssertRequestMatchesTheEntryTheRecorderSavedForIt(method, pathAndQuery, body);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PasswordThatLooksLikeADateMatchesTheEntryTheRecorderSavedForIt()
        {
            // A password that looks like a date. This checks only that the two keys agree.
            // The body is put together here so that the file has no password value written out.
            string dateValue = "2025-11-03T22:35:23Z";
            string body = "{\"password\":\"" + dateValue + "\",\"expiryTime\":\"2025-11-03T22:35:23.4621363Z\"}";
            AssertRequestMatchesTheEntryTheRecorderSavedForIt("PUT", "/pools/testPool/nodes/node1/users/userendtoend?api-version=2024-07-01.20.0", body);
        }

        private static void AssertRequestMatchesTheEntryTheRecorderSavedForIt(string method, string pathAndQuery, string body)
        {
            BatchRecordMatcher matcher = NewMatcher();
            RecordEntry recorded = new RecordEntry(new HttpResponseMessage(HttpStatusCode.OK) { RequestMessage = Request(method, pathAndQuery, body) });
            // The recording file keeps only the path and query (HttpMockServer.Flush).
            recorded.RequestUri = new Uri(recorded.RequestUri).PathAndQuery;

            string key = matcher.GetMatchingKey(Request(method, pathAndQuery, body));

            Assert.Equal(matcher.GetMatchingKey(recorded), key);
            Assert.NotEqual(matcher.GetMatchingKey(Request(method, pathAndQuery, "{}")), key);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PasswordInTheRequestIsMaskedToMatchTheRecording()
        {
            // New-AzBatchComputeNodeUser's request in TestComputeNodeUserEndToEnd, and the body its recording saved.
            const string path = "/pools/testPool/nodes/node1/users?api-version=2024-07-01.20.0";
            RecordEntry recorded = Recorded("POST", path, "{\r\n  \"name\": \"userendtoend\",\r\n  \"isAdmin\": false,\r\n  \"password\": \"Sanitized\"\r\n}");
            BatchRecordMatcher matcher = NewMatcher();

            // Any value other than "Sanitized" shows that the request side masks it. A plain word, put into the body
            // here, so that the file has no value that looks like a credential.
            string sentValue = "NotYetMasked";
            string key = matcher.GetMatchingKey(Request("POST", path, "{\"name\":\"userendtoend\",\"isAdmin\":false,\"password\":\"" + sentValue + "\"}"));

            Assert.Equal(matcher.GetMatchingKey(recorded), key);
            Assert.DoesNotContain(sentValue, key);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RecordedBodyEditedByHandStillMatches()
        {
            // Job1Recorded with other whitespace, and its properties and settings in another order.
            RecordEntry edited = Recorded("POST", JobsPath,
                "{\n\t\"poolInfo\": { \"poolId\": \"testPool\" },\n\t\"usesTaskDependencies\": false,\n\t\"id\": \"job1\",\n"
                + "\t\"commonEnvironmentSettings\": [\n\t\t{ \"value\": \"Hello world\", \"name\": \"ThisIsAString\" },\n\t\t{ \"name\": \"ThisIsNull\" }\n\t],\n"
                + "\t\"priority\": 0\n}\n");

            BatchRecordMatcher matcher = NewMatcher();

            Assert.Equal(matcher.GetMatchingKey(edited), matcher.GetMatchingKey(Request("POST", JobsPath, Job1Sent)));
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("GET")]
        [InlineData("DELETE")]
        [InlineData("HEAD")]
        public void BodyOfGetDeleteOrHeadIsNotRead(string method)
        {
            BatchRecordMatcher matcher = NewMatcher();
            BodyThatCountsReads body = new BodyThatCountsReads(Job1Sent);

            string key = matcher.GetMatchingKey(new HttpRequestMessage(new HttpMethod(method), AccountUrl + JobsPath) { Content = body });

            Assert.Equal(0, body.Reads);
            Assert.Equal(matcher.GetMatchingKey(new HttpRequestMessage(new HttpMethod(method), AccountUrl + JobsPath)), key);
            Assert.Equal(matcher.GetMatchingKey(Recorded(method, JobsPath, Job1Recorded)), key);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PlaybackReturnsTheRecordedEntryWithTheSameBody()
        {
            BatchRecordMatcher matcher = NewMatcher();
            RecordEntry job1 = Recorded("POST", JobsPath, Job1Recorded);
            RecordEntry job2 = Recorded("POST", JobsPath, Job2Recorded);
            Records records = new Records(matcher);
            records.Enqueue(job1);
            records.Enqueue(job2);

            // The lookup HttpMockServer does for each request in playback, here in the other order.
            Assert.Same(job2, records[matcher.GetMatchingKey(Request("POST", JobsPath, Job2Sent))].Dequeue());
            Assert.Same(job1, records[matcher.GetMatchingKey(Request("POST", JobsPath, Job1Sent))].Dequeue());

            string otherBody = Job1Sent.Replace("\"priority\":0", "\"priority\":1");
            KeyNotFoundException notFound = Assert.Throws<KeyNotFoundException>(() => records[matcher.GetMatchingKey(Request("POST", JobsPath, otherBody))]);
            Assert.StartsWith("Unable to find a matching HTTP request", notFound.Message);
        }

        // Made with the arguments BatchTestRunner passes.
        private static BatchRecordMatcher NewMatcher()
        {
            return new BatchRecordMatcher(
                true,
                new Dictionary<string, string>
                {
                    { "Microsoft.Resources", null },
                    { "Microsoft.Features", null },
                    { "Microsoft.Network", null },
                    { "Microsoft.Authorization", null },
                },
                new Dictionary<string, string>
                {
                    { "Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01" },
                });
        }

        // A request as the Batch SDK sends it.
        private static HttpRequestMessage Request(string method, string pathAndQuery, string body)
        {
            StringContent content = new StringContent(body, Encoding.UTF8);
            content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json; odata=minimalmetadata; charset=utf-8");
            return new HttpRequestMessage(new HttpMethod(method), AccountUrl + pathAndQuery) { Content = content };
        }

        // An entry as playback reads it from a recording file.
        private static RecordEntry Recorded(string method, string pathAndQuery, string body)
        {
            return new RecordEntry
            {
                RequestUri = pathAndQuery,
                EncodedRequestUri = RecorderUtilities.EncodeUriAsBase64(pathAndQuery),
                RequestMethod = method,
                RequestBody = body,
            };
        }

        private class BodyThatCountsReads : HttpContent
        {
            private readonly byte[] bytes;

            public BodyThatCountsReads(string body)
            {
                bytes = Encoding.UTF8.GetBytes(body);
                Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }

            public int Reads { get; private set; }

            protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
            {
                Reads++;
                return stream.WriteAsync(bytes, 0, bytes.Length);
            }

            protected override bool TryComputeLength(out long length)
            {
                length = bytes.Length;
                return true;
            }
        }
    }
}
