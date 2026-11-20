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
using Microsoft.Azure.Batch.Common;
using Microsoft.Azure.Batch.Protocol.Models;
using Microsoft.Azure.Commands.Batch.Track2;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Xunit;
using RequestFailedException = Azure.RequestFailedException;

namespace Microsoft.Azure.Commands.Batch.Test.Track2
{
    public class Track2ErrorsTests
    {
        private const string AccountUrl = "https://account.westus.batch.azure.com";
        private const string ClientRequestId = "0f6c3a52-4c5e-4d5b-9b7e-3f2a1c9d8e01";
        private const string RequestId = "7d1e2f3a-8b9c-4d0e-a1f2-b3c4d5e6f701";

        public static IEnumerable<object[]> ServiceErrors => new List<object[]>
        {
            new object[] { HttpStatusCode.NotFound, "The specified pool does not exist.", ErrorBody("PoolNotFound", "The specified pool does not exist."), null, "PoolNotFound" },
            new object[] { HttpStatusCode.BadRequest, "The value for one of the HTTP query parameters is not in the correct format.", ErrorBody("InvalidQueryParameterValue", "Value for one of the query parameters specified in the request URI is invalid.", "{\"key\":\"QueryParameterName\",\"value\":\"$select\"},{\"key\":\"QueryParameterValue\",\"value\":\"notAProperty\"},{\"key\":\"Reason\",\"value\":\"The specified property does not exist.\"}"), null, "InvalidQueryParameterValue" },
            new object[] { HttpStatusCode.ServiceUnavailable, "Server Busy", ErrorBody("ServerBusy", "The server is currently unable to receive requests. Please retry your request."), "30", "ServerBusy" },
            new object[] { HttpStatusCode.InternalServerError, "Internal Server Error", string.Empty, null, null },
            new object[] { HttpStatusCode.BadGateway, "Bad Gateway", "<html><body>Bad gateway</body></html>", null, null },
        };

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [MemberData(nameof(ServiceErrors))]
        public void Track2ErrorsBecomeTheSameBatchExceptionAsTrack1(HttpStatusCode status, string reasonPhrase, string body, string retryAfter, string errorCode)
        {
            Track2TestContext context = NewContext(status, reasonPhrase, body, retryAfter);

            BatchException track1 = Assert.Throws<BatchException>(() => context.BatchOMClient.PoolOperations.GetPool(
                "pool1", additionalBehaviors: new[] { RetryPolicyProvider.NoRetryProvider() }));
            RequestFailedException track2Error = Assert.Throws<RequestFailedException>(() => context.Track2Client.GetPool("pool1"));
            BatchException track2 = Track2Errors.ToBatchException(track2Error);

            Assert.NotNull(track2);
            Assert.Equal(track1.GetType(), track2.GetType());
            Assert.Equal(track1.Message, track2.Message);
            AssertSameRequestInformation(track1.RequestInformation, track2.RequestInformation);
            Assert.Equal(status, track2.RequestInformation.HttpStatusCode);
            Assert.Equal(reasonPhrase, track2.RequestInformation.HttpStatusMessage);
            Assert.Equal(Guid.Parse(ClientRequestId), track2.RequestInformation.ClientRequestId);
            Assert.Equal(RequestId, track2.RequestInformation.ServiceRequestId);
            // Track 1 looks up "retry-after" in a case-sensitive list and HttpClient names the header "Retry-After", so
            // RetryAfter is empty today, even when the service sends it. It stays the same.
            Assert.Null(track2.RequestInformation.RetryAfter);
            Assert.Equal(errorCode, track2.RequestInformation.BatchError?.Code);

            // Track 1's protocol-layer error sits under it, as with Track 1, and the Track 2 error under that.
            Assert.IsType<BatchErrorException>(track1.InnerException);
            Assert.IsType<BatchErrorException>(track2.InnerException);
            Assert.Same(track2Error, track2.InnerException.InnerException);

            // What the cmdlet shows.
            BatchException shownForTrack1 = Assert.IsType<BatchException>(RunCmdlet(track1));
            BatchException shownForTrack2 = Assert.IsType<BatchException>(RunCmdlet(track2Error));
            Assert.Equal(shownForTrack1.Message, shownForTrack2.Message);
            AssertSameRequestInformation(shownForTrack1.RequestInformation, shownForTrack2.RequestInformation);
            Assert.IsType<BatchErrorException>(shownForTrack2.InnerException);
            Assert.Same(track2Error, shownForTrack2.InnerException.InnerException);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TheCmdletShowsTheRequestDetailsForBothTracks()
        {
            Track2TestContext context = NewContext(HttpStatusCode.BadRequest, "The value for one of the HTTP query parameters is not in the correct format.",
                ErrorBody("InvalidQueryParameterValue", "Value for one of the query parameters specified in the request URI is invalid.",
                    "{\"key\":\"QueryParameterName\",\"value\":\"$select\"},{\"key\":\"Reason\",\"value\":\"The specified property does not exist.\"}"),
                null);
            BatchException track1 = Assert.Throws<BatchException>(() => context.BatchOMClient.PoolOperations.GetPool(
                "pool1", additionalBehaviors: new[] { RetryPolicyProvider.NoRetryProvider() }));
            RequestFailedException track2Error = Assert.Throws<RequestFailedException>(() => context.Track2Client.GetPool("pool1"));

            string expected = string.Join(Environment.NewLine,
                "HttpStatusCode: BadRequest",
                "StatusMessage: The value for one of the HTTP query parameters is not in the correct format.",
                "ClientRequestId: " + ClientRequestId,
                "RequestId: " + RequestId,
                string.Empty,
                "Error code: InvalidQueryParameterValue",
                "Message: Value for one of the query parameters specified in the request URI is invalid.\nRequestId:" + RequestId + "\nTime:2026-11-10T19:00:00.0000000Z",
                "Error details:",
                "QueryParameterName: $select",
                "Reason: The specified property does not exist.",
                string.Empty);
            Assert.Equal(expected, RunCmdlet(track1).Message);
            Assert.Equal(expected, RunCmdlet(track2Error).Message);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ErrorsWithoutAnAnswerFromTheServicePassThrough()
        {
            RequestFailedException noAnswer = new RequestFailedException("No such host is known.");
            InvalidOperationException other = new InvalidOperationException("Not a service error.");

            Assert.Null(Track2Errors.ToBatchException(noAnswer));
            Assert.Same(noAnswer, RunCmdlet(noAnswer));
            Assert.Same(other, RunCmdlet(other));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AnErrorThatCantBeConvertedIsKept()
        {
            // Track 1 reads client-request-id as a GUID.
            Track2TestContext context = NewContext(HttpStatusCode.NotFound, "The specified pool does not exist.",
                ErrorBody("PoolNotFound", "The specified pool does not exist."), null, clientRequestId: "not-a-guid");
            RequestFailedException error = Assert.Throws<RequestFailedException>(() => context.Track2Client.GetPool("pool1"));

            Assert.Null(Track2Errors.ToBatchException(error));
            Assert.Same(error, RunCmdlet(error));
        }

        private static Track2TestContext NewContext(HttpStatusCode status, string reasonPhrase, string body, string retryAfter, string clientRequestId = ClientRequestId)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "client-request-id", clientRequestId },
                { "request-id", RequestId },
            };
            if (retryAfter != null)
            {
                headers.Add("Retry-After", retryAfter);
            }

            RecordingHandler handler = new RecordingHandler().On("GET /pools/pool1", status, body, headers, reasonPhrase);
            string key = Convert.ToBase64String(Encoding.UTF8.GetBytes("account-key-not-a-real-key-00000"));
            return new Track2TestContext(null, "account", AccountUrl, handler, key);
        }

        // The service's error answer: code, message (with the request id and time) and optional details.
        private static string ErrorBody(string code, string message, string values = null)
        {
            string body = "{\"odata.metadata\":\"" + AccountUrl + "/$metadata#Microsoft.Azure.Batch.Protocol.Entities.Container.errors/@Element\","
                + "\"code\":\"" + code + "\","
                + "\"message\":{\"lang\":\"en-US\",\"value\":\"" + message + "\\nRequestId:" + RequestId + "\\nTime:2026-11-10T19:00:00.0000000Z\"}";
            if (values != null)
            {
                body += ",\"values\":[" + values + "]";
            }
            return body + "}";
        }

        private static void AssertSameRequestInformation(RequestInformation expected, RequestInformation actual)
        {
            Assert.NotNull(expected);
            Assert.NotNull(actual);
            Assert.Equal(expected.HttpStatusCode, actual.HttpStatusCode);
            Assert.Equal(expected.HttpStatusMessage, actual.HttpStatusMessage);
            Assert.Equal(expected.ClientRequestId, actual.ClientRequestId);
            Assert.Equal(expected.ServiceRequestId, actual.ServiceRequestId);
            Assert.Equal(expected.RetryAfter, actual.RetryAfter);
            if (expected.BatchError == null)
            {
                Assert.Null(actual.BatchError);
                return;
            }

            Assert.NotNull(actual.BatchError);
            Assert.Equal(expected.BatchError.Code, actual.BatchError.Code);
            Assert.Equal(expected.BatchError.Message?.Language, actual.BatchError.Message?.Language);
            Assert.Equal(expected.BatchError.Message?.Value, actual.BatchError.Message?.Value);
            Assert.Equal(
                expected.BatchError.Values?.Select(v => v.Key + "=" + v.Value),
                actual.BatchError.Values?.Select(v => v.Key + "=" + v.Value));
        }

        private static Exception RunCmdlet(Exception error)
        {
            return Record.Exception(() => new ThrowingCmdlet(error).ExecuteCmdlet());
        }

        private class ThrowingCmdlet : BatchCmdletBase
        {
            private readonly Exception error;

            public ThrowingCmdlet(Exception error)
            {
                this.error = error;
            }

            protected override void ExecuteCmdletImpl()
            {
                throw this.error;
            }
        }
    }
}
