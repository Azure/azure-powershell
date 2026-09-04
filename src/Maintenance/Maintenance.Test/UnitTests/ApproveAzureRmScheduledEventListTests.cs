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
            ScheduledEventsListAcknowledgeErrorDetails response = null,
            IList<ScheduledEventsAcknowledgeErrorDetails> details = null,
            string responseContent = null)
        {
            return new ScheduledEventsListAcknowledgeErrorException("Operation returned an invalid status code 'MultiStatus'.")
            {
                Body = response == null
                    ? null
                    : new ScheduledEventsListAcknowledgeError(
                        new ScheduledEventsListAcknowledgeErrorDetails(
                            response.Code,
                            response.Message,
                            details)),
                Response = new HttpResponseMessageWrapper(
                    new HttpResponseMessage((HttpStatusCode)207),
                    responseContent)
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MultiStatusWireResponseMapsToPowerShellResponse()
        {
            object writtenObject = null;
            string responseBody = JsonConvert.SerializeObject(new
            {
                Response = new
                {
                    Code = "MultiStatusResponse",
                    Message = "Review each event result."
                },
                Details = new[]
                {
                    new
                    {
                        Code = "NotFound",
                        Message = "Scheduled event not found"
                    }
                }
            });

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
                    CreateMultiStatusException(responseContent: responseBody)));

            cmdlet.ExecuteCmdlet();

            var response = Assert.IsType<PSScheduledEventsApproveResponse>(writtenObject);
            Assert.Equal("MultiStatusResponse", response.Response.Code);
            Assert.Equal("Review each event result.", response.Response.Message);
            ScheduledEventsAcknowledgeErrorDetails detail = Assert.Single(response.Details);
            Assert.Equal(ScheduledEventIds[0], detail.Target);
            Assert.Equal("NotFound", detail.Code);
            Assert.Equal("Scheduled event not found", detail.Message);
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
            string serializedResponse = JsonConvert.SerializeObject(response);
            Assert.DoesNotContain("\"Details\"", serializedResponse);
            Assert.DoesNotContain("\"Response\"", serializedResponse);
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
        public void MultiStatusWritesResultWithoutErrors()
        {
            object writtenObject = null;
            var responseBody = new ScheduledEventsListAcknowledgeErrorDetails(
                "MultiStatusResponse",
                "The operation returned different statuses for the Scheduled Events.");
            var responseDetails = new[]
                {
                    new ScheduledEventsAcknowledgeErrorDetails(ScheduledEventIds[0], "OK", "Successfully approved scheduled event"),
                    new ScheduledEventsAcknowledgeErrorDetails(ScheduledEventIds[1], "NotFound", "Scheduled event not found")
                };

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
                .Returns(Task.FromException<AzureOperationResponse<ScheduledEventsApproveResponse>>(CreateMultiStatusException(responseBody, responseDetails)));

            cmdlet.ExecuteCmdlet();

            var response = Assert.IsType<PSScheduledEventsApproveResponse>(writtenObject);
            Assert.Equal("MultiStatusResponse", response.Response.Code);
            Assert.Equal(2, response.Details.Count);
            Assert.Equal(ScheduledEventIds[0], response.Details[0].Target);
            Assert.Equal("OK", response.Details[0].Code);
            Assert.Equal("Successfully approved scheduled event", response.Details[0].Message);
            Assert.Equal(ScheduledEventIds[1], response.Details[1].Target);
            Assert.Equal("NotFound", response.Details[1].Code);
            Assert.Equal("Scheduled event not found", response.Details[1].Message);
            string serializedResponse = JsonConvert.SerializeObject(response);
            Assert.DoesNotContain("\"Value\"", serializedResponse);
            Assert.DoesNotContain("\"Results\"", serializedResponse);
            commandRuntimeMock.Verify(runtime => runtime.WriteError(It.IsAny<ErrorRecord>()), Times.Never);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MultiStatusUsesSdkExceptionBodyWhenAvailable()
        {
            object writtenObject = null;
            var expectedDetail = new ScheduledEventsAcknowledgeErrorDetails(
                ScheduledEventIds[1],
                "NotFound",
                "Scheduled event not found.");
            var expectedBodyError = new ScheduledEventsListAcknowledgeErrorDetails(
                "MultiStatusResponse",
                "Partial success.");
            ScheduledEventsListAcknowledgeErrorException exception = CreateMultiStatusException(
                expectedBodyError,
                new[] { expectedDetail });

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

            var response = Assert.IsType<PSScheduledEventsApproveResponse>(writtenObject);
            Assert.Equal(expectedBodyError.Code, response.Response.Code);
            Assert.Equal(expectedBodyError.Message, response.Response.Message);
            ScheduledEventsAcknowledgeErrorDetails detail = Assert.Single(response.Details);
            Assert.Same(expectedDetail, detail);
            commandRuntimeMock.Verify(runtime => runtime.WriteError(It.IsAny<ErrorRecord>()), Times.Never);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MultiStatusWithoutSdkBodyWritesResultWithoutErrors()
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

            var response = Assert.IsType<PSScheduledEventsApproveResponse>(writtenObject);
            Assert.Equal("MultiStatus", response.Response.Code);
            Assert.Equal(expectedException.Message, response.Response.Message);
            Assert.Empty(response.Details);
            commandRuntimeMock.Verify(runtime => runtime.WriteError(It.IsAny<ErrorRecord>()), Times.Never);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MultiStatusPopulatesMissingTargetsByRequestOrder()
        {
            object writtenObject = null;
            var responseBody = new ScheduledEventsListAcknowledgeErrorDetails(
                "MultiStatusResponse",
                "Partial success.");
            var responseDetails = new[]
                { new ScheduledEventsAcknowledgeErrorDetails(null, "NotFound", "Scheduled event not found") };

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
                .Returns(Task.FromException<AzureOperationResponse<ScheduledEventsApproveResponse>>(CreateMultiStatusException(responseBody, responseDetails)));

            cmdlet.ExecuteCmdlet();

            var response = Assert.IsType<PSScheduledEventsApproveResponse>(writtenObject);
            ScheduledEventsAcknowledgeErrorDetails detail = Assert.Single(response.Details);
            Assert.Equal(ScheduledEventIds[0], detail.Target);
            Assert.Equal("NotFound", detail.Code);
            commandRuntimeMock.Verify(runtime => runtime.WriteError(It.IsAny<ErrorRecord>()), Times.Never);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MultiStatusWithAllUntargetedFailuresCorrelatesByRequestOrder()
        {
            object writtenObject = null;
            var responseBody = new ScheduledEventsListAcknowledgeErrorDetails(
                "MultiStatusResponse",
                "All failed.");
            ScheduledEventsAcknowledgeErrorDetails[] responseDetails = ScheduledEventIds
                .Select(_ => new ScheduledEventsAcknowledgeErrorDetails(null, "NotFound", "Scheduled event not found"))
                .ToArray();

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
                .Returns(Task.FromException<AzureOperationResponse<ScheduledEventsApproveResponse>>(CreateMultiStatusException(responseBody, responseDetails)));

            cmdlet.ExecuteCmdlet();

            var response = Assert.IsType<PSScheduledEventsApproveResponse>(writtenObject);
            Assert.Equal(ScheduledEventIds, response.Details.Select(detail => detail.Target));
            Assert.All(response.Details, detail => Assert.Equal("NotFound", detail.Code));
            commandRuntimeMock.Verify(runtime => runtime.WriteError(It.IsAny<ErrorRecord>()), Times.Never);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListInternalServerErrorReturnsCodeAndMessage()
        {
            object writtenObject = null;
            var expectedException = new ScheduledEventsListAcknowledgeErrorException("Acknowledge list failed.")
            {
                Body = new ScheduledEventsListAcknowledgeError(
                    new ScheduledEventsListAcknowledgeErrorDetails("InternalServerError", "An internal server error occurred.")),
                Response = new HttpResponseMessageWrapper(
                    new HttpResponseMessage(HttpStatusCode.InternalServerError),
                    null)
            };
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
            Assert.Equal("InternalServerError", response.Error.Code);
            Assert.Equal("An internal server error occurred.", response.Error.Message);
            commandRuntimeMock.Verify(runtime => runtime.WriteObject(It.IsAny<object>()), Times.Once);
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
