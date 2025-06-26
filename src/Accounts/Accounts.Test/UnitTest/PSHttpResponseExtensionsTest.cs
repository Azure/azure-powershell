using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Internal.Common;
using Microsoft.Rest.Azure;
using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Commands.Profile.Test.UnitTest
{
    public class PSHttpResponseExtensionsTest
    {
        [Fact]
        public async Task FollowNextLinkAggregatesPagedResults()
        {
            // Arrange
            var responses = CreateFakePagedResponses(3);

            var mockOps = new Mock<IAzureRestOperations>();
            mockOps.SetupSequence(o => o.BeginHttpGetMessagesAsyncWithFullResponse(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<IDictionary<string, IList<string>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(responses[1])
                .ReturnsAsync(responses[2]);

            var mockClient = new Mock<IAzureRestClient>();
            mockClient.SetupGet(c => c.Operations).Returns(mockOps.Object);

            // Act
            var result = await PSHttpResponseExtensions.FollowNextLinkAsync(
                responses[0], mockClient.Object, "v1");

            // Assert
            var json = JObject.Parse(result.Content);
            var actualItems = json["value"] as JArray;
            Assert.NotNull(actualItems);
            Assert.Equal(responses.Count, actualItems.Count);            

            var expectedIds = responses
                .Select(r => JObject.Parse(r.Body)["value"]?[0]?["id"]?.ToString())
                .ToList();

            // Assert each actual item matches expected
            for (int i = 0; i < expectedIds.Count; i++)
            {
                var actualId = actualItems[i]?["id"]?.ToString();
                Assert.Equal(expectedIds[i], actualId);
            }
        }

        [Fact]
        public async Task FollowNextLinkAHandles429WithRetry()
        {
            // First page (initial), second page (rate limited), third page (success after retry)
            var initialResponse = CreateFakePagedResponses(2)[0];
            var rateLimitedResponse = CreateFakePagedResponses(1, (HttpStatusCode)429)[0];
            var successResponse = CreateFakePagedResponses(1, hasNext: false)[0];


            var mockOps = new Mock<IAzureRestOperations>();
            var callCount = 0;
            mockOps.Setup(o => o.BeginHttpGetMessagesAsyncWithFullResponse(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<IDictionary<string, IList<string>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() =>
                {
                    callCount++;
                    return callCount == 1 ? rateLimitedResponse : successResponse;
                });

            var mockClient = new Mock<IAzureRestClient>();
            mockClient.SetupGet(c => c.Operations).Returns(mockOps.Object);

            var outputMessages = new List<string>();
            Action<string> outputAction = msg => outputMessages.Add(msg);

            // Act
            var result = await PSHttpResponseExtensions.FollowNextLinkAsync(
               initialResponse, mockClient.Object, "v1", "value", "nextLink");

            // Assert
            var json = JObject.Parse(result.Content);
            Assert.Equal(2, ((JArray)json["value"]).Count);
        }

        [Fact]
        public async Task FollowNextLinkThrowsOnNonSuccessStatusCode()
        {
            // Arrange
            var initialResponse = CreateFakePagedResponses(2)[0];
            var errorResponse = CreateFakeResponse("{}", HttpStatusCode.NotFound);

            var mockOps = new Mock<IAzureRestOperations>();
            mockOps.Setup(o => o.BeginHttpGetMessagesAsyncWithFullResponse(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<IDictionary<string, IList<string>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(errorResponse);

            var mockClient = new Mock<IAzureRestClient>();
            mockClient.SetupGet(c => c.Operations).Returns(mockOps.Object);

            // Act & Assert
            await Assert.ThrowsAsync<Commands.Common.Exceptions.AzPSException>(async () =>
            {
                await PSHttpResponseExtensions.FollowNextLinkAsync(
                    initialResponse, mockClient.Object, "v1");
            });
        }

        [Fact]
        public async Task FollowNextLinkThrowsOnInvalidJson()
        {
            // Arrange
            var invalidJson = "{ invalid json ";
            var initialResponse = CreateFakeResponse(invalidJson);

            var mockOps = new Mock<IAzureRestOperations>();
            var mockClient = new Mock<IAzureRestClient>();
            mockClient.SetupGet(c => c.Operations).Returns(mockOps.Object);

            // Act & Assert
            await Assert.ThrowsAsync<Commands.Common.Exceptions.AzPSException>(async () =>
            {
                await PSHttpResponseExtensions.FollowNextLinkAsync(
                    initialResponse, mockClient.Object, "v1");
            });
        }

        [Fact]
        public async Task FollowNextLinkHandlesMissingNextLinkProperty()
        {
            // Arrange
            var initialResponse = CreateFakePagedResponses(1)[0];
            var responses = CreateFakePagedResponses(1, hasNext: false);

            var mockOps = new Mock<IAzureRestOperations>();
            var mockClient = new Mock<IAzureRestClient>();
            mockClient.SetupGet(c => c.Operations).Returns(mockOps.Object);

            // Act
            var result = await PSHttpResponseExtensions.FollowNextLinkAsync(
                initialResponse, mockClient.Object, "v1");

            // Assert
            var json = JObject.Parse(result.Content);
            Assert.Single(((JArray)json["value"]));
        }

        [Fact]
        public async Task FollowNextLinkIgnoresUnknownItemName()
        {
            //Arrange
            var initialResponse = CreateFakePagedResponses(1)[0];
            var mockOps = new Mock<IAzureRestOperations>();
            var mockClient = new Mock<IAzureRestClient>();
            mockClient.SetupGet(c => c.Operations).Returns(mockOps.Object);

            // Act
            var result = await PSHttpResponseExtensions.FollowNextLinkAsync(
                initialResponse, mockClient.Object, "v1", pageableItemName: "unknownProperty");

            // Assert not paginated
            var json = JObject.Parse(result.Content);
            Assert.True(json["value"] is JArray arr && arr.Count == 1);
        }

        [Fact]
        public async Task FollowNextLinkRespectsMaxPageSizeLimit()
        {
            // Arrange
            var responses = CreateFakePagedResponses(4);

            var mockOps = new Mock<IAzureRestOperations>();
            mockOps.SetupSequence(o => o.BeginHttpGetMessagesAsyncWithFullResponse(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<IDictionary<string, IList<string>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(responses[1])
                .ReturnsAsync(responses[2])
                .ReturnsAsync(responses[3]);

            var mockClient = new Mock<IAzureRestClient>();
            mockClient.SetupGet(c => c.Operations).Returns(mockOps.Object);

            // Act
            var result = await PSHttpResponseExtensions.FollowNextLinkAsync(
                responses[0], mockClient.Object, "v1", "value", "nextLink", maxPageSize: 2);

            //Assert
            var json = JObject.Parse(result.Content);
            Assert.Equal(2, ((JArray)json["value"]).Count);
            mockOps.Verify(o => o.BeginHttpGetMessagesAsyncWithFullResponse(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<IDictionary<string, IList<string>>>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task FollowNextLinkIgnoresInvalidNextLink()
        {
            // Arrange
            var responseWithNullNextLink = CreateFakeResponse(new JObject
            {
                ["value"] = new JArray(new JObject { ["id"] = Guid.NewGuid().ToString() }),
                ["nextLink"] = "null"
            }.ToString());
            var responseWithInvalidUrl = CreateFakeResponse(new JObject
            {
                ["value"] = new JArray(new JObject { ["id"] = Guid.NewGuid().ToString() }),
                ["nextLink"] = "not a url"
            }.ToString());

            var mockOps = new Mock<IAzureRestOperations>();
            mockOps.Setup(o => o.BeginHttpGetMessagesAsyncWithFullResponse(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<IDictionary<string, IList<string>>>(), It.IsAny<CancellationToken>()))
                .Throws(new Exception("Should not be called"));

            var mockClient = new Mock<IAzureRestClient>();
            mockClient.SetupGet(c => c.Operations).Returns(mockOps.Object);

            // Act & Assert for "null" string
            var resultNull = await PSHttpResponseExtensions.FollowNextLinkAsync(
                responseWithNullNextLink, mockClient.Object, "v1");

            var jsonNull = JObject.Parse(resultNull.Content);
            Assert.Single((JArray)jsonNull["value"]);

            // Act & Assert for invalid URL
            var resultInvalid = await PSHttpResponseExtensions.FollowNextLinkAsync(
                responseWithInvalidUrl, mockClient.Object, "v1");

            var jsonInvalid = JObject.Parse(resultInvalid.Content);
            Assert.Single((JArray)jsonInvalid["value"]);
        }

        #region Test Data Helpers
        private static List<AzureOperationResponse<string>> CreateFakePagedResponses(
               int pages, HttpStatusCode statusCode = HttpStatusCode.OK, bool retry = false, bool hasNext = true,
               string itemName = "value")
        {
            var responses = new List<AzureOperationResponse<string>>();
            for (int i = 1; i <= pages; i++)
            {
                var page = new JObject
                {
                    [itemName] = new JArray(new JObject { ["id"] = $"page{i}"})
                };

                if (hasNext && i < pages) //don't add nextLink for the last page
                {
                    page["nextLink"] = $"https://example.com/api/resource/page{i + 1}";
                }

                responses.Add(CreateFakeResponse(page.ToString(), statusCode, retry));
            }
            return responses;
        }

        private static AzureOperationResponse<string> CreateFakeResponse(string content,
            HttpStatusCode statusCode = HttpStatusCode.OK, bool retry = false)
        {
            var response = new AzureOperationResponse<string>
            {
                Body = content,
                Response = new System.Net.Http.HttpResponseMessage(statusCode),
                Request = new System.Net.Http.HttpRequestMessage
                {
                    Method = new System.Net.Http.HttpMethod("GET"),
                    RequestUri = new Uri("https://example.com/api/resource")
                }
            };
            response.Response.RequestMessage = response.Request;

            if (retry)
            {
                response.Response.Headers.RetryAfter = new System.Net.Http.Headers.RetryConditionHeaderValue(TimeSpan.FromSeconds(0));
            }

            return response;
        }
        #endregion
    }
}