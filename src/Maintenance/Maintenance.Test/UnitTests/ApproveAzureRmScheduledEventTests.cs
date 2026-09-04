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
        [InlineData(HttpStatusCode.NotFound, "InvalidScheduledEventId", "Scheduled event not found")]
        [InlineData(HttpStatusCode.InternalServerError, "InternalServerError", "An internal server error occurred.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SingleNonSuccessResponseReturnsCodeAndMessage(
            HttpStatusCode statusCode,
            string code,
            string message)
        {
            object writtenObject = null;
            var expectedException = new MaintenanceErrorException("Acknowledge failed.")
            {
                Body = new MaintenanceError(new Microsoft.Azure.Management.Maintenance.Models.ErrorDetails(code, message)),
                Response = new HttpResponseMessageWrapper(new HttpResponseMessage(statusCode), null)
            };
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
                .Returns(Task.FromException<AzureOperationResponse<ScheduledEventsApproveResponse>>(expectedException));

            cmdlet.ExecuteCmdlet();

            var response = Assert.IsType<MaintenanceError>(writtenObject);
            Assert.Equal(code, response.Error.Code);
            Assert.Equal(message, response.Error.Message);
            commandRuntimeMock.Verify(runtime => runtime.WriteObject(It.IsAny<object>()), Times.Once);
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
