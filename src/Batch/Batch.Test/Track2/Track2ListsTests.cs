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

using Microsoft.Azure.Batch;
using Microsoft.Azure.Commands.Batch.Track2;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Xunit;
using Operation = Azure.Operation;
using Track2BatchPoolResizeOptions = Azure.Compute.Batch.BatchPoolResizeOptions;
using WaitUntil = Azure.WaitUntil;

namespace Microsoft.Azure.Commands.Batch.Test.Track2
{
    public class Track2ListsTests
    {
        private const string AccountUrl = "https://account.westus.batch.azure.com";

        private static readonly string[] AllPools = { "pool1", "pool2", "pool3", "pool4", "pool5", "pool6" };

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(2, 2, 1, true)]
        [InlineData(3, 3, 2, true)]
        [InlineData(6, 6, 3, true)]
        [InlineData(10, 6, 3, true)]
        [InlineData(0, 6, 3, false)]
        [InlineData(-1, 6, 3, false)]
        public void MaxCountStopsThePagingEarly(int maxCount, int expectedItems, int expectedRequests, bool logged)
        {
            RecordingHandler handler = ThreePagesOfPools();
            Track2TestContext context = NewContext(handler);
            int logs = 0;

            IEnumerable<string> ids = Track2Lists.WithMaxCount(context.Track2Client.GetPools(), p => p.Id, maxCount, () => logs++);

            // The limit is logged when the list is made, as today; nothing is asked before the cmdlet reads the items.
            Assert.Equal(logged ? 1 : 0, logs);
            Assert.Empty(handler.Requests);
            Assert.Equal(AllPools.Take(expectedItems), ids.ToList());
            Assert.Equal(expectedRequests, handler.Requests.Count);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ItemsArriveAsTheirPagesDo()
        {
            RecordingHandler handler = ThreePagesOfPools();
            Track2TestContext context = NewContext(handler);

            using (IEnumerator<string> ids = Track2Lists.WithMaxCount(context.Track2Client.GetPools(), p => p.Id, 0).GetEnumerator())
            {
                Assert.True(ids.MoveNext());
                Assert.Equal("pool1", ids.Current);
                Assert.Single(handler.Requests);

                Assert.True(ids.MoveNext());
                Assert.True(ids.MoveNext());
                Assert.Equal("pool3", ids.Current);
                Assert.Equal(2, handler.Requests.Count);
            }
        }

        public static IEnumerable<object[]> Clauses => new List<object[]>
        {
            new object[] { null, null, null },
            new object[] { "state eq 'active'", "id,state", "stats" },
            new object[] { "startswith(id,'my pool') and state eq 'active'", "id, state,,stats", "stats,metadata" },
            new object[] { string.Empty, string.Empty, string.Empty },
        };

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [MemberData(nameof(Clauses))]
        public void FilterSelectAndExpandReachTheServiceAsWithTrack1(string filter, string select, string expand)
        {
            RecordingHandler handler = new RecordingHandler()
                .On("GET /pools/pool1", HttpStatusCode.OK, "{\"id\":\"pool1\"}")
                .On("GET /pools", HttpStatusCode.OK, "{\"value\":[]}");
            Track2TestContext context = NewContext(handler);

            context.BatchOMClient.PoolOperations.ListPools(new ODATADetailLevel(filter, select, expand)).ToList();
            context.BatchOMClient.PoolOperations.GetPool("pool1", new ODATADetailLevel(selectClause: select, expandClause: expand));
            context.Track2Client.GetPools(filter: filter, select: Track2Lists.ToClauseList(select), expand: Track2Lists.ToClauseList(expand)).ToList();
            context.Track2Client.GetPool("pool1", select: Track2Lists.ToClauseList(select), expand: Track2Lists.ToClauseList(expand));

            Assert.Equal(4, handler.Requests.Count);
            AssertSameQuery(handler.Requests[0].Uri, handler.Requests[2].Uri);
            AssertSameQuery(handler.Requests[1].Uri, handler.Requests[3].Uri);

            // And the service gets the text as typed.
            Assert.Equal(filter, QueryValue(handler.Requests[2].Uri, "$filter"));
            Assert.Equal(select, QueryValue(handler.Requests[2].Uri, "$select"));
            Assert.Equal(expand, QueryValue(handler.Requests[2].Uri, "$expand"));
            Assert.Null(QueryValue(handler.Requests[3].Uri, "$filter"));
            Assert.Equal(select, QueryValue(handler.Requests[3].Uri, "$select"));
            Assert.Equal(expand, QueryValue(handler.Requests[3].Uri, "$expand"));
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("DELETE /pools/pool1")]
        [InlineData("POST /pools/pool1/resize")]
        [InlineData("POST /pools/pool1/nodes/node1/reboot")]
        [InlineData("POST /jobs/job1/terminate")]
        public void LongRunningCallsReturnWhenTheServiceAcceptsThem(string call)
        {
            RecordingHandler handler = new RecordingHandler().On(call, HttpStatusCode.Accepted);
            Track2TestContext context = NewContext(handler);

            CallTrack1(context, call);
            Operation operation = CallTrack2(context, call);

            // One request each, and Track 2 doesn't wait for the end, like Track 1.
            Assert.Equal(2, handler.Requests.Count);
            Assert.Equal(call, handler.Requests[0].Method + " " + handler.Requests[0].Uri.AbsolutePath);
            Assert.Equal(call, handler.Requests[1].Method + " " + handler.Requests[1].Uri.AbsolutePath);
            Assert.False(operation.HasCompleted);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ClauseTextIsKeptAsItIs()
        {
            Assert.Null(Track2Lists.ToClauseList(null));
            Assert.Equal(new[] { string.Empty }, Track2Lists.ToClauseList(string.Empty));
            Assert.Equal(new[] { "id", " state", string.Empty, "stats" }, Track2Lists.ToClauseList("id, state,,stats"));
        }

        private static void CallTrack1(Track2TestContext context, string call)
        {
            switch (call)
            {
                case "DELETE /pools/pool1":
                    context.BatchOMClient.PoolOperations.DeletePool("pool1");
                    break;
                case "POST /pools/pool1/resize":
                    context.BatchOMClient.PoolOperations.ResizePool("pool1", targetDedicatedComputeNodes: 1);
                    break;
                case "POST /pools/pool1/nodes/node1/reboot":
                    context.BatchOMClient.PoolOperations.Reboot("pool1", "node1");
                    break;
                case "POST /jobs/job1/terminate":
                    context.BatchOMClient.JobOperations.TerminateJob("job1");
                    break;
                default:
                    throw new ArgumentException(call);
            }
        }

        private static Operation CallTrack2(Track2TestContext context, string call)
        {
            switch (call)
            {
                case "DELETE /pools/pool1":
                    return context.Track2Client.DeletePool(WaitUntil.Started, "pool1");
                case "POST /pools/pool1/resize":
                    return context.Track2Client.ResizePool(WaitUntil.Started, "pool1", new Track2BatchPoolResizeOptions { TargetDedicatedNodes = 1 });
                case "POST /pools/pool1/nodes/node1/reboot":
                    return context.Track2Client.RebootNode(WaitUntil.Started, "pool1", "node1");
                case "POST /jobs/job1/terminate":
                    return context.Track2Client.TerminateJob(WaitUntil.Started, "job1");
                default:
                    throw new ArgumentException(call);
            }
        }

        // Three pages of two pools each, linked the way the service links them.
        private static RecordingHandler ThreePagesOfPools()
        {
            return new RecordingHandler().OnPages("GET /pools",
                Page(AccountUrl + "/pools?api-version=2025-06-01&$skiptoken=page2", "pool1", "pool2"),
                Page(AccountUrl + "/pools?api-version=2025-06-01&$skiptoken=page3", "pool3", "pool4"),
                Page(null, "pool5", "pool6"));
        }

        private static string Page(string nextLink, params string[] ids)
        {
            string items = string.Join(",", ids.Select(id => "{\"id\":\"" + id + "\"}"));
            string next = nextLink == null ? string.Empty : ",\"odata.nextLink\":\"" + nextLink + "\"";
            return "{\"value\":[" + items + "]" + next + "}";
        }

        private static Track2TestContext NewContext(RecordingHandler handler)
        {
            string key = Convert.ToBase64String(Encoding.UTF8.GetBytes("account-key-not-a-real-key-00000"));
            return new Track2TestContext(null, "account", AccountUrl, handler, key);
        }

        private static void AssertSameQuery(Uri track1, Uri track2)
        {
            Assert.Equal(track1.AbsolutePath, track2.AbsolutePath);
            foreach (string name in new[] { "$filter", "$select", "$expand" })
            {
                Assert.Equal(QueryValue(track1, name), QueryValue(track2, name));
            }
        }

        // The decoded value of a query parameter, or null when the request doesn't have it.
        private static string QueryValue(Uri uri, string name)
        {
            foreach (string part in uri.Query.TrimStart('?').Split('&'))
            {
                int equals = part.IndexOf('=');
                string key = Uri.UnescapeDataString(equals < 0 ? part : part.Substring(0, equals));
                if (key == name)
                {
                    return equals < 0 ? string.Empty : Uri.UnescapeDataString(part.Substring(equals + 1));
                }
            }

            return null;
        }
    }
}
