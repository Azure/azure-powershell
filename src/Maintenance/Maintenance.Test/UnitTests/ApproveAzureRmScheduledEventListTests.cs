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

using Microsoft.Azure.Commands.Maintenance.Models;
using Microsoft.Azure.Management.Maintenance;
using Microsoft.Azure.Management.Maintenance.Models;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Commands.Maintenance.Test.UnitTests
{
    public class ApproveAzureRmScheduledEventListTests : RMTestBase
    {
        private const string ResourceGroupName = "test-resource-group";
        private const string ResourceType = "virtualmachinescalesets";
        private const string ResourceName = "test-vmss";

        private static readonly string[] ScheduledEventIds =
        {
            "00000000-0000-0000-0000-000000000001",
            "00000000-0000-0000-0000-000000000002"
        };
        private const string ShouldProcessTarget = "resourceGroups/test-resource-group/providers/Microsoft.Compute/virtualmachinescalesets/test-vmss/providers/Microsoft.Maintenance/scheduledEvents [00000000-0000-0000-0000-000000000001, 00000000-0000-0000-0000-000000000002]";

        private readonly Mock<ICommandRuntime> commandRuntimeMock;
        private readonly Mock<IMaintenanceManagementClient> maintenanceManagementClientMock;
        private readonly Mock<IScheduledEventsOperations> scheduledEventsOperationsMock;
        private readonly ApproveAzureRmScheduledEventList cmdlet;

        public ApproveAzureRmScheduledEventListTests()
        {
            commandRuntimeMock = new Mock<ICommandRuntime>(MockBehavior.Strict);
            maintenanceManagementClientMock = new Mock<IMaintenanceManagementClient>(MockBehavior.Strict);
            scheduledEventsOperationsMock = new Mock<IScheduledEventsOperations>(MockBehavior.Strict);

            maintenanceManagementClientMock
                .SetupGet(client => client.ScheduledEvents)
                .Returns(scheduledEventsOperationsMock.Object);

            cmdlet = new ApproveAzureRmScheduledEventList
            {
                CommandRuntime = commandRuntimeMock.Object,
                MaintenanceClient = new MaintenanceClient(maintenanceManagementClientMock.Object),
                ResourceGroupName = ResourceGroupName,
                ResourceType = ResourceType,
                ResourceName = ResourceName,
                ScheduledEventIdList = ScheduledEventIds
            };
        }

        private static ScheduledEventsListAcknowledgeErrorException CreateMultiStatusException(
            ScheduledEventsListAcknowledgeError body = null,
            string responseContent = null)
        {
            return new ScheduledEventsListAcknowledgeErrorException("Operation returned an invalid status code 'MultiStatus'.")
            {
                Body = body,
                Response = new HttpResponseMessageWrapper(
                    new HttpResponseMessage((HttpStatusCode)207),
                    responseContent)
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MultiStatusWireResponsePreservesSdkBodyAndJsonEnvelope()
        {
            object writtenObject = null;
            const string responseBody = @"{""error"":{""code"":""MultiStatusResponse"",""message"":""The operation returned different statuses for the Scheduled Events. Review each event's result for details."",""details"":[{""target"":""00000000-0000-0000-0000-000000000002"",""code"":""Conflict"",""message"":""The event cannot be acknowledged.""}]}}";
            // Simulate the SDK deserializing the HTTP 207 payload into the exception body.
            var expectedBody = JsonConvert.DeserializeObject<ScheduledEventsListAcknowledgeError>(responseBody);
            ScheduledEventsListAcknowledgeErrorDetails expectedError = expectedBody.Error;
            IList<ScheduledEventsAcknowledgeErrorDetails> expectedDetails = expectedError.Details;

            commandRuntimeMock
                .Setup(runtime => runtime.ShouldProcess(ShouldProcessTarget, VerbsLifecycle.Approve))
                .Returns(true);
            commandRuntimeMock
                .Setup(runtime => runtime.WriteObject(It.IsAny<object>()))
                .Callback<object>(value => writtenObject = value);
            scheduledEventsOperationsMock
                .Setup(operations => operations.AcknowledgeListWithHttpMessagesAsync(
                    ResourceGroupName,
                    ResourceType,
                    ResourceName,
                    It.Is<IList<string>>(ids => ids.SequenceEqual(ScheduledEventIds)),
                    null,
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromException<AzureOperationResponse<ScheduledEventsApproveResponse>>(
                    CreateMultiStatusException(expectedBody, responseBody)));

            cmdlet.ExecuteCmdlet();

            var response = Assert.IsType<ScheduledEventsListAcknowledgeError>(writtenObject);
            Assert.Same(expectedBody, response);
            Assert.Same(expectedError, response.Error);
            Assert.Same(expectedDetails, response.Error.Details);
            Assert.Equal("MultiStatusResponse", response.Error.Code);
            Assert.Equal("The operation returned different statuses for the Scheduled Events. Review each event's result for details.", response.Error.Message);
            ScheduledEventsAcknowledgeErrorDetails detail = Assert.Single(response.Error.Details);
            Assert.Equal(ScheduledEventIds[1], detail.Target);
            Assert.Equal("Conflict", detail.Code);
            Assert.Equal("The event cannot be acknowledged.", detail.Message);
            Assert.True(JToken.DeepEquals(JToken.Parse(responseBody), JToken.Parse(JsonConvert.SerializeObject(response))));
            commandRuntimeMock.Verify(runtime => runtime.WriteObject(It.IsAny<object>()), Times.Once);
            commandRuntimeMock.Verify(runtime => runtime.WriteError(It.IsAny<ErrorRecord>()), Times.Never);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AcknowledgeListUsesExactArgumentsAndMapsSuccessfulResponse()
        {
            const string responseValue = "Successfully approved all Scheduled Events in the list";
            object writtenObject = null;
            cmdlet.ResourceGroupName = $" {ResourceGroupName} ";
            cmdlet.ResourceType = $" {ResourceType} ";
            cmdlet.ResourceName = $" {ResourceName} ";
            cmdlet.ScheduledEventIdList = ScheduledEventIds.Select(id => $" {id} ").ToArray();

            commandRuntimeMock
                .Setup(runtime => runtime.ShouldProcess(ShouldProcessTarget, VerbsLifecycle.Approve))
                .Returns(true);
            commandRuntimeMock
                .Setup(runtime => runtime.WriteObject(It.IsAny<object>()))
                .Callback<object>(value => writtenObject = value);
            scheduledEventsOperationsMock
                .Setup(operations => operations.AcknowledgeListWithHttpMessagesAsync(
                    ResourceGroupName,
                    ResourceType,
                    ResourceName,
                    It.Is<IList<string>>(ids => ids.SequenceEqual(ScheduledEventIds)),
                    null,
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new AzureOperationResponse<ScheduledEventsApproveResponse>
                {
                    Body = new ScheduledEventsApproveResponse(responseValue)
                });

            cmdlet.ExecuteCmdlet();

            scheduledEventsOperationsMock.Verify(operations => operations.AcknowledgeListWithHttpMessagesAsync(
                ResourceGroupName,
                ResourceType,
                ResourceName,
                It.Is<IList<string>>(ids => ids.SequenceEqual(ScheduledEventIds)),
                null,
                It.IsAny<CancellationToken>()), Times.Once);
            var response = Assert.IsType<ScheduledEventsApproveResponse>(writtenObject);
            Assert.Equal(responseValue, response.Value);
            var serializedResponse = JObject.Parse(JsonConvert.SerializeObject(response));
            JProperty valueProperty = Assert.Single(serializedResponse.Properties());
            Assert.Equal("value", valueProperty.Name);
            Assert.Equal(JTokenType.String, valueProperty.Value.Type);
            Assert.Equal(responseValue, valueProperty.Value.Value<string>());
            commandRuntimeMock.Verify(runtime => runtime.WriteObject(It.IsAny<object>()), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ShouldProcessFalseDoesNotCallClient()
        {
            commandRuntimeMock
                .Setup(runtime => runtime.ShouldProcess(ShouldProcessTarget, VerbsLifecycle.Approve))
                .Returns(false);

            cmdlet.ExecuteCmdlet();

            scheduledEventsOperationsMock.Verify(operations => operations.AcknowledgeListWithHttpMessagesAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<IList<string>>(),
                It.IsAny<Dictionary<string, List<string>>>(),
                It.IsAny<CancellationToken>()), Times.Never);
            commandRuntimeMock.Verify(runtime => runtime.WriteObject(It.IsAny<object>()), Times.Never);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EmptyScheduledEventIdListIsRejectedBeforeCallingClient()
        {
            cmdlet.ScheduledEventIdList = Array.Empty<string>();

            PSArgumentException exception = Assert.Throws<PSArgumentException>(() => cmdlet.ExecuteCmdlet());

            Assert.Contains(nameof(cmdlet.ScheduledEventIdList), exception.Message);
            scheduledEventsOperationsMock.Verify(operations => operations.AcknowledgeListWithHttpMessagesAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<IList<string>>(),
                It.IsAny<Dictionary<string, List<string>>>(),
                It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void InvalidScheduledEventIdInListIsRejectedBeforeCallingClient()
        {
            cmdlet.ScheduledEventIdList = new[] { ScheduledEventIds[0], "not-a-guid" };

            PSArgumentException exception = Assert.Throws<PSArgumentException>(() => cmdlet.ExecuteCmdlet());

            Assert.Equal(nameof(cmdlet.ScheduledEventIdList), exception.ParamName);
            Assert.Contains("index 1", exception.Message);
            scheduledEventsOperationsMock.Verify(operations => operations.AcknowledgeListWithHttpMessagesAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<IList<string>>(),
                It.IsAny<Dictionary<string, List<string>>>(),
                It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void WhitespaceScheduledEventIdInListReportsParameterNameAndIndex()
        {
            cmdlet.ScheduledEventIdList = new[] { " " };

            PSArgumentException exception = Assert.Throws<PSArgumentException>(() => cmdlet.ExecuteCmdlet());

            Assert.Equal(nameof(cmdlet.ScheduledEventIdList), exception.ParamName);
            Assert.Contains("index 0", exception.Message);
            scheduledEventsOperationsMock.Verify(operations => operations.AcknowledgeListWithHttpMessagesAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<IList<string>>(),
                It.IsAny<Dictionary<string, List<string>>>(),
                It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MultiStatusPreservesSdkBodyAndReorderedTargetsWithoutErrors()
        {
            object writtenObject = null;
            var responseDetails = new[]
                {
                    new ScheduledEventsAcknowledgeErrorDetails(ScheduledEventIds[1], "Conflict", "The event cannot be acknowledged."),
                    new ScheduledEventsAcknowledgeErrorDetails(ScheduledEventIds[0], "NotFound", "Scheduled event not found.")
                };
            var expectedDetails = responseDetails.ToArray();
            var expectedError = new ScheduledEventsListAcknowledgeErrorDetails(
                "MultiStatusResponse",
                "The operation returned different statuses for the Scheduled Events. Review each event's result for details.",
                responseDetails);
            var responseBody = new ScheduledEventsListAcknowledgeError(expectedError);

            commandRuntimeMock
                .Setup(runtime => runtime.ShouldProcess(ShouldProcessTarget, VerbsLifecycle.Approve))
                .Returns(true);
            commandRuntimeMock
                .Setup(runtime => runtime.WriteObject(It.IsAny<object>()))
                .Callback<object>(value => writtenObject = value);
            scheduledEventsOperationsMock
                .Setup(operations => operations.AcknowledgeListWithHttpMessagesAsync(
                    ResourceGroupName,
                    ResourceType,
                    ResourceName,
                    It.Is<IList<string>>(ids => ids.SequenceEqual(ScheduledEventIds)),
                    null,
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromException<AzureOperationResponse<ScheduledEventsApproveResponse>>(CreateMultiStatusException(responseBody)));

            cmdlet.ExecuteCmdlet();

            var response = Assert.IsType<ScheduledEventsListAcknowledgeError>(writtenObject);
            Assert.Same(responseBody, response);
            Assert.Same(expectedError, response.Error);
            Assert.Equal("MultiStatusResponse", response.Error.Code);
            Assert.Equal("The operation returned different statuses for the Scheduled Events. Review each event's result for details.", response.Error.Message);
            Assert.Same(responseDetails, response.Error.Details);
            Assert.Equal(2, response.Error.Details.Count);
            Assert.Same(expectedDetails[0], response.Error.Details[0]);
            Assert.Same(expectedDetails[1], response.Error.Details[1]);
            Assert.Equal(ScheduledEventIds[1], response.Error.Details[0].Target);
            Assert.Equal("Conflict", response.Error.Details[0].Code);
            Assert.Equal("The event cannot be acknowledged.", response.Error.Details[0].Message);
            Assert.Equal(ScheduledEventIds[0], response.Error.Details[1].Target);
            Assert.Equal("NotFound", response.Error.Details[1].Code);
            Assert.Equal("Scheduled event not found.", response.Error.Details[1].Message);
            commandRuntimeMock.Verify(runtime => runtime.WriteObject(It.IsAny<object>()), Times.Once);
            commandRuntimeMock.Verify(runtime => runtime.WriteError(It.IsAny<ErrorRecord>()), Times.Never);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MultiStatusWithFewerDetailsPassesSdkBodyThroughUnchanged()
        {
            object writtenObject = null;
            var expectedDetail = new ScheduledEventsAcknowledgeErrorDetails(
                ScheduledEventIds[1],
                "NotFound",
                "Scheduled event not found.");
            var expectedDetails = new[] { expectedDetail };
            var expectedBodyError = new ScheduledEventsListAcknowledgeErrorDetails(
                "MultiStatusResponse",
                "The operation returned different statuses for the Scheduled Events. Review each event's result for details.",
                expectedDetails);
            ScheduledEventsListAcknowledgeErrorException exception = CreateMultiStatusException(
                new ScheduledEventsListAcknowledgeError(expectedBodyError));

            commandRuntimeMock
                .Setup(runtime => runtime.ShouldProcess(ShouldProcessTarget, VerbsLifecycle.Approve))
                .Returns(true);
            commandRuntimeMock
                .Setup(runtime => runtime.WriteObject(It.IsAny<object>()))
                .Callback<object>(value => writtenObject = value);
            scheduledEventsOperationsMock
                .Setup(operations => operations.AcknowledgeListWithHttpMessagesAsync(
                    ResourceGroupName,
                    ResourceType,
                    ResourceName,
                    It.Is<IList<string>>(ids => ids.SequenceEqual(ScheduledEventIds)),
                    null,
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromException<AzureOperationResponse<ScheduledEventsApproveResponse>>(exception));

            cmdlet.ExecuteCmdlet();

            var response = Assert.IsType<ScheduledEventsListAcknowledgeError>(writtenObject);
            Assert.Same(exception.Body, response);
            Assert.Same(expectedBodyError, response.Error);
            Assert.Equal("MultiStatusResponse", response.Error.Code);
            Assert.Equal("The operation returned different statuses for the Scheduled Events. Review each event's result for details.", response.Error.Message);
            Assert.Same(expectedDetails, response.Error.Details);
            ScheduledEventsAcknowledgeErrorDetails detail = Assert.Single(response.Error.Details);
            Assert.Same(expectedDetail, detail);
            Assert.Equal(ScheduledEventIds[1], detail.Target);
            Assert.Equal("NotFound", detail.Code);
            Assert.Equal("Scheduled event not found.", detail.Message);
            commandRuntimeMock.Verify(runtime => runtime.WriteError(It.IsAny<ErrorRecord>()), Times.Never);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MultiStatusWithoutSdkBodyWritesFallbackWithoutErrors()
        {
            object writtenObject = null;
            ScheduledEventsListAcknowledgeErrorException expectedException = CreateMultiStatusException();

            commandRuntimeMock
                .Setup(runtime => runtime.ShouldProcess(ShouldProcessTarget, VerbsLifecycle.Approve))
                .Returns(true);
            commandRuntimeMock
                .Setup(runtime => runtime.WriteObject(It.IsAny<object>()))
                .Callback<object>(value => writtenObject = value);
            scheduledEventsOperationsMock
                .Setup(operations => operations.AcknowledgeListWithHttpMessagesAsync(
                    ResourceGroupName,
                    ResourceType,
                    ResourceName,
                    It.Is<IList<string>>(ids => ids.SequenceEqual(ScheduledEventIds)),
                    null,
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromException<AzureOperationResponse<ScheduledEventsApproveResponse>>(expectedException));

            cmdlet.ExecuteCmdlet();

            var response = Assert.IsType<ScheduledEventsListAcknowledgeError>(writtenObject);
            Assert.NotNull(response.Error);
            Assert.Equal("MultiStatus", response.Error.Code);
            Assert.Equal(expectedException.Message, response.Error.Message);
            Assert.Null(response.Error.Details);
            commandRuntimeMock.Verify(runtime => runtime.WriteObject(It.IsAny<object>()), Times.Once);
            commandRuntimeMock.Verify(runtime => runtime.WriteError(It.IsAny<ErrorRecord>()), Times.Never);
            commandRuntimeMock.Verify(runtime => runtime.ThrowTerminatingError(It.IsAny<ErrorRecord>()), Times.Never);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MultiStatusWithoutResponseAndSdkBodyTerminatesWithExceptionNameAndMessage()
        {
            ScheduledEventsListAcknowledgeErrorException expectedException = CreateMultiStatusException();
            expectedException.Response = null;

            ExecuteAndAssertTerminatingError(expectedException,
                nameof(ScheduledEventsListAcknowledgeErrorException), expectedException.Message);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MultiStatusDoesNotPopulateMissingTargetsWhenCountsDiffer()
        {
            object writtenObject = null;
            var responseDetails = new[]
                { new ScheduledEventsAcknowledgeErrorDetails(null, "NotFound", "Scheduled event not found") };
            var expectedDetail = responseDetails[0];
            var responseBody = new ScheduledEventsListAcknowledgeError(
                new ScheduledEventsListAcknowledgeErrorDetails(
                    "MultiStatusResponse", "The operation returned different statuses for the Scheduled Events. Review each event's result for details.", responseDetails));

            commandRuntimeMock
                .Setup(runtime => runtime.ShouldProcess(ShouldProcessTarget, VerbsLifecycle.Approve))
                .Returns(true);
            commandRuntimeMock
                .Setup(runtime => runtime.WriteObject(It.IsAny<object>()))
                .Callback<object>(value => writtenObject = value);
            scheduledEventsOperationsMock
                .Setup(operations => operations.AcknowledgeListWithHttpMessagesAsync(
                    ResourceGroupName,
                    ResourceType,
                    ResourceName,
                    It.Is<IList<string>>(ids => ids.SequenceEqual(ScheduledEventIds)),
                    null,
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromException<AzureOperationResponse<ScheduledEventsApproveResponse>>(CreateMultiStatusException(responseBody)));

            cmdlet.ExecuteCmdlet();

            var response = Assert.IsType<ScheduledEventsListAcknowledgeError>(writtenObject);
            Assert.Same(responseBody, response);
            Assert.Equal("MultiStatusResponse", response.Error.Code);
            Assert.Equal("The operation returned different statuses for the Scheduled Events. Review each event's result for details.", response.Error.Message);
            Assert.Same(responseDetails, response.Error.Details);
            ScheduledEventsAcknowledgeErrorDetails detail = Assert.Single(response.Error.Details);
            Assert.Same(expectedDetail, detail);
            Assert.Null(detail.Target);
            Assert.Equal("NotFound", detail.Code);
            Assert.Equal("Scheduled event not found", detail.Message);
            commandRuntimeMock.Verify(runtime => runtime.WriteError(It.IsAny<ErrorRecord>()), Times.Never);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MultiStatusDoesNotSynthesizeMissingTargetsEvenWhenCountsMatch()
        {
            object writtenObject = null;
            // Defensive regression: target validation and population belong to the service.
            ScheduledEventsAcknowledgeErrorDetails[] responseDetails = ScheduledEventIds
                .Select(_ => new ScheduledEventsAcknowledgeErrorDetails(null, "NotFound", "Scheduled event not found"))
                .ToArray();
            var expectedDetails = responseDetails.ToArray();
            var responseBody = new ScheduledEventsListAcknowledgeError(
                new ScheduledEventsListAcknowledgeErrorDetails(
                    "MultiStatusResponse", "The operation returned different statuses for the Scheduled Events. Review each event's result for details.", responseDetails));

            commandRuntimeMock
                .Setup(runtime => runtime.ShouldProcess(ShouldProcessTarget, VerbsLifecycle.Approve))
                .Returns(true);
            commandRuntimeMock
                .Setup(runtime => runtime.WriteObject(It.IsAny<object>()))
                .Callback<object>(value => writtenObject = value);
            scheduledEventsOperationsMock
                .Setup(operations => operations.AcknowledgeListWithHttpMessagesAsync(
                    ResourceGroupName,
                    ResourceType,
                    ResourceName,
                    It.Is<IList<string>>(ids => ids.SequenceEqual(ScheduledEventIds)),
                    null,
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromException<AzureOperationResponse<ScheduledEventsApproveResponse>>(CreateMultiStatusException(responseBody)));

            cmdlet.ExecuteCmdlet();

            var response = Assert.IsType<ScheduledEventsListAcknowledgeError>(writtenObject);
            Assert.Same(responseBody, response);
            Assert.Equal("MultiStatusResponse", response.Error.Code);
            Assert.Equal("The operation returned different statuses for the Scheduled Events. Review each event's result for details.", response.Error.Message);
            Assert.Same(responseDetails, response.Error.Details);
            Assert.Equal(ScheduledEventIds.Length, response.Error.Details.Count);
            for (int index = 0; index < expectedDetails.Length; index++)
            {
                Assert.Same(expectedDetails[index], response.Error.Details[index]);
                Assert.Null(response.Error.Details[index].Target);
                Assert.Equal("NotFound", response.Error.Details[index].Code);
                Assert.Equal("Scheduled event not found", response.Error.Details[index].Message);
            }
            commandRuntimeMock.Verify(runtime => runtime.WriteError(It.IsAny<ErrorRecord>()), Times.Never);
        }

        [Theory]
        [InlineData(HttpStatusCode.BadRequest, @"{""error"":{""code"":""BadRequest"",""message"":""The request is invalid.""}}", "BadRequest", "The request is invalid.")]
        [InlineData(HttpStatusCode.Forbidden, @"{""error"":{""code"":""Forbidden"",""message"":""Access to the resource is forbidden.""}}", "Forbidden", "Access to the resource is forbidden.")]
        [InlineData(HttpStatusCode.NotFound, @"{""error"":{""code"":""InvalidScheduledEventId"",""message"":""The resource was not found.""}}", "InvalidScheduledEventId", "The resource was not found.")]
        [InlineData(HttpStatusCode.Conflict, @"{""error"":{""code"":""Conflict"",""message"":""The request conflicts with the resource state.""}}", "Conflict", "The request conflicts with the resource state.")]
        [InlineData(HttpStatusCode.InternalServerError, @"{""error"":{""code"":""InternalServerError"",""message"":""An internal server error occurred.""}}", "InternalServerError", "An internal server error occurred.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListErrorWireResponseTerminatesWithServiceErrorAndOriginalContext(
            HttpStatusCode statusCode,
            string responseBody,
            string expectedCode,
            string expectedMessage)
        {
            var expectedBody = JsonConvert.DeserializeObject<ScheduledEventsListAcknowledgeError>(responseBody);
            var expectedException = new ScheduledEventsListAcknowledgeErrorException("Acknowledge list failed.")
            {
                Body = expectedBody,
                Response = new HttpResponseMessageWrapper(
                    new HttpResponseMessage(statusCode),
                    responseBody)
            };

            ErrorRecord error = ExecuteAndAssertTerminatingError(expectedException, expectedCode,
                statusCode.ToString() + Environment.NewLine + JObject.Parse(responseBody).ToString(Formatting.Indented));

            Assert.Same(expectedBody, expectedException.Body);
            Assert.NotNull(expectedBody.Error);
            Assert.Equal(expectedCode, expectedBody.Error.Code);
            Assert.Equal(expectedMessage, expectedBody.Error.Message);
            Assert.Null(expectedBody.Error.Details);
            Assert.Equal(responseBody, expectedException.Response.Content);
            Assert.Equal(statusCode, expectedException.Response.StatusCode);
            Assert.Equal(statusCode.ToString() + Environment.NewLine + JsonConvert.SerializeObject(
                expectedBody, Formatting.Indented,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }), error.ErrorDetails.Message);
            Assert.DoesNotContain("\"details\"", error.ErrorDetails.Message);
            Assert.DoesNotContain("\"Details\"", error.ErrorDetails.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("not valid JSON")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MissingSdkBodyTerminatesWithStatusAndExceptionMessage(string responseContent)
        {
            var expectedException = new ScheduledEventsListAcknowledgeErrorException("Acknowledge list failed without an SDK body.")
            {
                Body = null,
                Response = new HttpResponseMessageWrapper(new HttpResponseMessage(HttpStatusCode.BadRequest), responseContent)
            };

            ExecuteAndAssertTerminatingError(expectedException, "BadRequest",
                "BadRequest" + Environment.NewLine + expectedException.Message);

            Assert.Null(expectedException.Body);
            Assert.Equal(responseContent, expectedException.Response.Content);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void BodyWithoutErrorTerminatesWithExceptionMessageInsteadOfJson(bool hasResponse)
        {
            var expectedException = new ScheduledEventsListAcknowledgeErrorException("Acknowledge list failed without an error envelope.")
            {
                Body = new ScheduledEventsListAcknowledgeError(),
                Response = hasResponse
                    ? new HttpResponseMessageWrapper(new HttpResponseMessage(HttpStatusCode.Conflict), "{}")
                    : null
            };

            ExecuteAndAssertTerminatingError(expectedException,
                hasResponse ? "Conflict" : nameof(ScheduledEventsListAcknowledgeErrorException),
                hasResponse ? "Conflict" + Environment.NewLine + expectedException.Message : expectedException.Message);

            Assert.Null(expectedException.Body.Error);
        }

        [Theory]
        [InlineData(null, true)]
        [InlineData("", true)]
        [InlineData(" ", true)]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData(" ", false)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MissingServiceCodeUsesStatusOrExceptionNameWhileRetainingJson(string code, bool hasResponse)
        {
            const string message = "Service error without a code.";
            var expectedException = new ScheduledEventsListAcknowledgeErrorException("Acknowledge list failed.")
            {
                Body = new ScheduledEventsListAcknowledgeError(new ScheduledEventsListAcknowledgeErrorDetails(code, message)),
                Response = hasResponse
                    ? new HttpResponseMessageWrapper(new HttpResponseMessage(HttpStatusCode.Forbidden), null)
                    : null
            };
            var expectedError = new JObject { ["message"] = message };
            if (code != null)
            {
                expectedError.AddFirst(new JProperty("code", code));
            }
            string expectedJson = new JObject { ["error"] = expectedError }.ToString(Formatting.Indented);

            ExecuteAndAssertTerminatingError(expectedException,
                hasResponse ? "Forbidden" : nameof(ScheduledEventsListAcknowledgeErrorException),
                hasResponse ? "Forbidden" + Environment.NewLine + expectedJson : expectedJson);
        }

        private ErrorRecord ExecuteAndAssertTerminatingError(
            ScheduledEventsListAcknowledgeErrorException expectedException, string expectedId, string expectedMessage)
        {
            ErrorRecord capturedError = null;
            ScheduledEventsListAcknowledgeError expectedBody = expectedException.Body;
            var expectedResponse = expectedException.Response;
            HttpStatusCode? expectedStatus = expectedResponse?.StatusCode;
            string expectedContent = expectedResponse?.Content;
            commandRuntimeMock
                .Setup(runtime => runtime.ShouldProcess(ShouldProcessTarget, VerbsLifecycle.Approve))
                .Returns(true);
            commandRuntimeMock
                .Setup(runtime => runtime.ThrowTerminatingError(It.IsAny<ErrorRecord>()))
                .Callback<ErrorRecord>(error =>
                {
                    capturedError = error;
                    throw new PipelineStoppedException();
                });
            scheduledEventsOperationsMock
                .Setup(operations => operations.AcknowledgeListWithHttpMessagesAsync(
                    ResourceGroupName,
                    ResourceType,
                    ResourceName,
                    It.Is<IList<string>>(ids => ids.SequenceEqual(ScheduledEventIds)),
                    null,
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromException<AzureOperationResponse<ScheduledEventsApproveResponse>>(expectedException));

            Assert.Throws<PipelineStoppedException>(() => cmdlet.ExecuteCmdlet());

            Assert.NotNull(capturedError);
            var actualException = Assert.IsType<ScheduledEventsListAcknowledgeErrorException>(capturedError.Exception);
            Assert.Same(expectedException, actualException);
            Assert.Same(expectedBody, actualException.Body);
            Assert.Same(expectedResponse, actualException.Response);
            Assert.Equal(expectedStatus, actualException.Response?.StatusCode);
            Assert.Equal(expectedContent, actualException.Response?.Content);
            Assert.Equal(expectedId, capturedError.FullyQualifiedErrorId);
            Assert.Equal(ErrorCategory.InvalidOperation, capturedError.CategoryInfo.Category);
            Assert.Equal(ShouldProcessTarget, capturedError.TargetObject);
            Assert.NotNull(capturedError.ErrorDetails);
            Assert.Equal(expectedMessage, capturedError.ErrorDetails.Message);
            commandRuntimeMock.Verify(runtime => runtime.WriteObject(It.IsAny<object>()), Times.Never);
            commandRuntimeMock.Verify(runtime => runtime.WriteError(It.IsAny<ErrorRecord>()), Times.Never);
            commandRuntimeMock.Verify(runtime => runtime.ThrowTerminatingError(It.IsAny<ErrorRecord>()), Times.Once);
            return capturedError;
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ClientExceptionIsPropagated()
        {
            var expectedException = new InvalidOperationException("Acknowledge list failed.");

            commandRuntimeMock
                .Setup(runtime => runtime.ShouldProcess(ShouldProcessTarget, VerbsLifecycle.Approve))
                .Returns(true);
            scheduledEventsOperationsMock
                .Setup(operations => operations.AcknowledgeListWithHttpMessagesAsync(
                    ResourceGroupName,
                    ResourceType,
                    ResourceName,
                    It.Is<IList<string>>(ids => ids.SequenceEqual(ScheduledEventIds)),
                    null,
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromException<AzureOperationResponse<ScheduledEventsApproveResponse>>(expectedException));

            var actualException = Assert.Throws<InvalidOperationException>(() => cmdlet.ExecuteCmdlet());

            Assert.Same(expectedException, actualException);
            commandRuntimeMock.Verify(runtime => runtime.WriteObject(It.IsAny<object>()), Times.Never);
        }
    }
}
