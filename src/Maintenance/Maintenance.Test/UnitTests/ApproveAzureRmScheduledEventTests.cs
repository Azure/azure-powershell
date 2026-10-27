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
using System.Management.Automation;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Commands.Maintenance.Test.UnitTests
{
    public class ApproveAzureRmScheduledEventTests : RMTestBase
    {
        private const string ResourceGroupName = "test-resource-group";
        private const string ResourceType = "virtualmachinescalesets";
        private const string ResourceName = "test-vmss";
        private const string ScheduledEventId = "00000000-0000-0000-0000-000000000001";
        private const string ShouldProcessTarget = "resourceGroups/test-resource-group/providers/Microsoft.Compute/virtualmachinescalesets/test-vmss/providers/Microsoft.Maintenance/scheduledEvents/00000000-0000-0000-0000-000000000001";

        private readonly Mock<ICommandRuntime> commandRuntimeMock;
        private readonly Mock<IMaintenanceManagementClient> maintenanceManagementClientMock;
        private readonly Mock<IScheduledEventsOperations> scheduledEventsOperationsMock;
        private readonly ApproveAzureRmScheduledEvent cmdlet;

        public ApproveAzureRmScheduledEventTests()
        {
            commandRuntimeMock = new Mock<ICommandRuntime>(MockBehavior.Strict);
            maintenanceManagementClientMock = new Mock<IMaintenanceManagementClient>(MockBehavior.Strict);
            scheduledEventsOperationsMock = new Mock<IScheduledEventsOperations>(MockBehavior.Strict);

            maintenanceManagementClientMock
                .SetupGet(client => client.ScheduledEvents)
                .Returns(scheduledEventsOperationsMock.Object);

            cmdlet = new ApproveAzureRmScheduledEvent
            {
                CommandRuntime = commandRuntimeMock.Object,
                MaintenanceClient = new MaintenanceClient(maintenanceManagementClientMock.Object),
                ResourceGroupName = ResourceGroupName,
                ResourceType = ResourceType,
                ResourceName = ResourceName,
                ScheduledEventId = ScheduledEventId
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AcknowledgeUsesExactArgumentsAndMapsSuccessfulResponse()
        {
            const string responseValue = "Successfully approved scheduled event";
            object writtenObject = null;
            cmdlet.ResourceGroupName = $" {ResourceGroupName} ";
            cmdlet.ResourceType = $" {ResourceType} ";
            cmdlet.ResourceName = $" {ResourceName} ";
            cmdlet.ScheduledEventId = $" {ScheduledEventId} ";

            commandRuntimeMock
                .Setup(runtime => runtime.ShouldProcess(ShouldProcessTarget, VerbsLifecycle.Approve))
                .Returns(true);
            commandRuntimeMock
                .Setup(runtime => runtime.WriteObject(It.IsAny<object>()))
                .Callback<object>(value => writtenObject = value);
            scheduledEventsOperationsMock
                .Setup(operations => operations.AcknowledgeWithHttpMessagesAsync(
                    ResourceGroupName,
                    ResourceType,
                    ResourceName,
                    ScheduledEventId,
                    null,
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new AzureOperationResponse<ScheduledEventsApproveResponse>
                {
                    Body = new ScheduledEventsApproveResponse(responseValue)
                });

            cmdlet.ExecuteCmdlet();

            scheduledEventsOperationsMock.Verify(operations => operations.AcknowledgeWithHttpMessagesAsync(
                ResourceGroupName,
                ResourceType,
                ResourceName,
                ScheduledEventId,
                null,
                It.IsAny<CancellationToken>()), Times.Once);
            var response = Assert.IsType<ScheduledEventsApproveResponse>(writtenObject);
            Assert.Equal(responseValue, response.Value);
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

            scheduledEventsOperationsMock.Verify(operations => operations.AcknowledgeWithHttpMessagesAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, List<string>>>(),
                It.IsAny<CancellationToken>()), Times.Never);
            commandRuntimeMock.Verify(runtime => runtime.WriteObject(It.IsAny<object>()), Times.Never);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void InvalidScheduledEventIdIsRejectedBeforeCallingClient()
        {
            cmdlet.ScheduledEventId = "not-a-guid";

            PSArgumentException exception = Assert.Throws<PSArgumentException>(() => cmdlet.ExecuteCmdlet());

            Assert.Contains(nameof(cmdlet.ScheduledEventId), exception.Message);
            scheduledEventsOperationsMock.Verify(operations => operations.AcknowledgeWithHttpMessagesAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, List<string>>>(),
                It.IsAny<CancellationToken>()), Times.Never);
        }

        [Theory]
        [InlineData(HttpStatusCode.BadRequest, "InvalidRequest", "The request is invalid.")]
        [InlineData(HttpStatusCode.Forbidden, "AccessDenied", "Access to the resource is forbidden.")]
        [InlineData(HttpStatusCode.NotFound, "InvalidScheduledEventId", "Scheduled event not found")]
        [InlineData(HttpStatusCode.Conflict, "EventConflict", "The request conflicts with the resource state.")]
        [InlineData(HttpStatusCode.InternalServerError, "InternalServerError", "An internal server error occurred.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SingleNonSuccessResponseTerminatesWithServiceErrorAndOriginalContext(
            HttpStatusCode statusCode,
            string code,
            string message)
        {
            var wireBody = new JObject
            {
                ["error"] = new JObject { ["code"] = code, ["message"] = message }
            };
            string responseContent = wireBody.ToString(Formatting.None);
            var expectedBody = JsonConvert.DeserializeObject<MaintenanceError>(responseContent);
            var expectedException = new MaintenanceErrorException("Acknowledge failed.")
            {
                Body = expectedBody,
                Response = new HttpResponseMessageWrapper(new HttpResponseMessage(statusCode), responseContent)
            };

            ErrorRecord error = ExecuteAndAssertTerminatingError(expectedException, code,
                statusCode.ToString() + Environment.NewLine + wireBody.ToString(Formatting.Indented));

            Assert.Same(expectedBody, expectedException.Body);
            Assert.Equal(code, expectedException.Body.Error.Code);
            Assert.Equal(message, expectedException.Body.Error.Message);
            Assert.Equal(responseContent, expectedException.Response.Content);
            Assert.Equal(statusCode, expectedException.Response.StatusCode);
            Assert.Equal(statusCode.ToString() + Environment.NewLine + JsonConvert.SerializeObject(
                expectedBody, Formatting.Indented,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }), error.ErrorDetails.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("not valid JSON")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MissingSdkBodyTerminatesWithStatusAndExceptionMessage(string responseContent)
        {
            var expectedException = new MaintenanceErrorException("Acknowledge failed without an SDK body.")
            {
                Body = null,
                Response = new HttpResponseMessageWrapper(new HttpResponseMessage(HttpStatusCode.BadRequest), responseContent)
            };

            ExecuteAndAssertTerminatingError(expectedException, "BadRequest",
                "BadRequest" + Environment.NewLine + expectedException.Message);

            Assert.Null(expectedException.Body);
            Assert.Equal(responseContent, expectedException.Response.Content);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MissingResponseAndSdkBodyTerminateWithExceptionNameAndMessage()
        {
            var expectedException = new MaintenanceErrorException("Acknowledge failed without a response.")
            {
                Body = null,
                Response = null
            };

            ExecuteAndAssertTerminatingError(expectedException, nameof(MaintenanceErrorException), expectedException.Message);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void BodyWithoutErrorTerminatesWithExceptionMessageInsteadOfJson(bool hasResponse)
        {
            var expectedException = new MaintenanceErrorException("Acknowledge failed without an error envelope.")
            {
                Body = new MaintenanceError(),
                Response = hasResponse
                    ? new HttpResponseMessageWrapper(new HttpResponseMessage(HttpStatusCode.Conflict), "{}")
                    : null
            };

            ExecuteAndAssertTerminatingError(expectedException,
                hasResponse ? "Conflict" : nameof(MaintenanceErrorException),
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
            var expectedException = new MaintenanceErrorException("Acknowledge failed.")
            {
                Body = new MaintenanceError(new Microsoft.Azure.Management.Maintenance.Models.ErrorDetails(code, message)),
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
                hasResponse ? "Forbidden" : nameof(MaintenanceErrorException),
                hasResponse ? "Forbidden" + Environment.NewLine + expectedJson : expectedJson);
        }

        private ErrorRecord ExecuteAndAssertTerminatingError(
            MaintenanceErrorException expectedException, string expectedId, string expectedMessage)
        {
            ErrorRecord capturedError = null;
            MaintenanceError expectedBody = expectedException.Body;
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
                .Setup(operations => operations.AcknowledgeWithHttpMessagesAsync(
                    ResourceGroupName,
                    ResourceType,
                    ResourceName,
                    ScheduledEventId,
                    null,
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromException<AzureOperationResponse<ScheduledEventsApproveResponse>>(expectedException));

            Assert.Throws<PipelineStoppedException>(() => cmdlet.ExecuteCmdlet());

            Assert.NotNull(capturedError);
            var actualException = Assert.IsType<MaintenanceErrorException>(capturedError.Exception);
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
            var expectedException = new InvalidOperationException("Acknowledge failed.");

            commandRuntimeMock
                .Setup(runtime => runtime.ShouldProcess(ShouldProcessTarget, VerbsLifecycle.Approve))
                .Returns(true);
            scheduledEventsOperationsMock
                .Setup(operations => operations.AcknowledgeWithHttpMessagesAsync(
                    ResourceGroupName,
                    ResourceType,
                    ResourceName,
                    ScheduledEventId,
                    null,
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromException<AzureOperationResponse<ScheduledEventsApproveResponse>>(expectedException));

            var actualException = Assert.Throws<InvalidOperationException>(() => cmdlet.ExecuteCmdlet());

            Assert.Same(expectedException, actualException);
            commandRuntimeMock.Verify(runtime => runtime.WriteObject(It.IsAny<object>()), Times.Never);
        }
    }
}
