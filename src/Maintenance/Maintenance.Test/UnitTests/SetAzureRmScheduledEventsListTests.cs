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
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Commands.Maintenance.Test.UnitTests
{
    public class SetAzureRmScheduledEventsListTests : RMTestBase
    {
        private const string ResourceGroupName = "test-resource-group";
        private const string ResourceType = "virtualmachinescalesets";
        private const string ResourceName = "test-vmss";

        private static readonly string[] ScheduledEventsIdList =
        {
            "00000000-0000-0000-0000-000000000001",
            "00000000-0000-0000-0000-000000000002"
        };

        private readonly Mock<ICommandRuntime> commandRuntimeMock;
        private readonly Mock<IMaintenanceManagementClient> maintenanceManagementClientMock;
        private readonly Mock<IScheduledEventsOperations> scheduledEventsOperationsMock;
        private readonly SetAzureRmScheduledEventsList cmdlet;

        public SetAzureRmScheduledEventsListTests()
        {
            commandRuntimeMock = new Mock<ICommandRuntime>(MockBehavior.Strict);
            maintenanceManagementClientMock = new Mock<IMaintenanceManagementClient>(MockBehavior.Strict);
            scheduledEventsOperationsMock = new Mock<IScheduledEventsOperations>(MockBehavior.Strict);

            maintenanceManagementClientMock
                .SetupGet(client => client.ScheduledEvents)
                .Returns(scheduledEventsOperationsMock.Object);

            cmdlet = new SetAzureRmScheduledEventsList
            {
                CommandRuntime = commandRuntimeMock.Object,
                MaintenanceClient = new MaintenanceClient(maintenanceManagementClientMock.Object),
                ResourceGroupName = ResourceGroupName,
                ResourceType = ResourceType,
                ResourceName = ResourceName,
                ScheduledEventsIdList = ScheduledEventsIdList
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AcknowledgeListUsesExactArgumentsAndMapsSuccessfulResponse()
        {
            const string responseValue = "Successfully approved all Scheduled Events in the list";
            object writtenObject = null;

            commandRuntimeMock
                .Setup(runtime => runtime.ShouldProcess(ResourceName, VerbsCommon.Set))
                .Returns(true);
            commandRuntimeMock
                .Setup(runtime => runtime.WriteObject(It.IsAny<object>()))
                .Callback<object>(value => writtenObject = value);
            scheduledEventsOperationsMock
                .Setup(operations => operations.AcknowledgeListWithHttpMessagesAsync(
                    ResourceGroupName,
                    ResourceType,
                    ResourceName,
                    It.Is<IList<string>>(ids => ReferenceEquals(ids, ScheduledEventsIdList)),
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
                It.Is<IList<string>>(ids => ReferenceEquals(ids, ScheduledEventsIdList)),
                null,
                It.IsAny<CancellationToken>()), Times.Once);
            var response = Assert.IsType<PSScheduledEventsApproveResponse>(writtenObject);
            Assert.Equal(responseValue, response.Value);
            commandRuntimeMock.Verify(runtime => runtime.WriteObject(It.IsAny<object>()), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ShouldProcessFalseDoesNotCallClient()
        {
            commandRuntimeMock
                .Setup(runtime => runtime.ShouldProcess(ResourceName, VerbsCommon.Set))
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
        public void ClientExceptionIsPropagated()
        {
            var expectedException = new InvalidOperationException("Acknowledge list failed.");

            commandRuntimeMock
                .Setup(runtime => runtime.ShouldProcess(ResourceName, VerbsCommon.Set))
                .Returns(true);
            scheduledEventsOperationsMock
                .Setup(operations => operations.AcknowledgeListWithHttpMessagesAsync(
                    ResourceGroupName,
                    ResourceType,
                    ResourceName,
                    It.Is<IList<string>>(ids => ReferenceEquals(ids, ScheduledEventsIdList)),
                    null,
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromException<AzureOperationResponse<ScheduledEventsApproveResponse>>(expectedException));

            var actualException = Assert.Throws<InvalidOperationException>(() => cmdlet.ExecuteCmdlet());

            Assert.Same(expectedException, actualException);
            commandRuntimeMock.Verify(runtime => runtime.WriteObject(It.IsAny<object>()), Times.Never);
        }
    }
}
