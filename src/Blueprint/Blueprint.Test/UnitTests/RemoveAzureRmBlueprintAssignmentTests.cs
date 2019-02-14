using System;
using Microsoft.Azure.Commands.Blueprint.Cmdlets;
using Microsoft.Azure.Commands.Blueprint.Common;
using Microsoft.Azure.Commands.Blueprint.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Moq;
using ParameterSetNames = Microsoft.Azure.Commands.Blueprint.Common.BlueprintConstants.ParameterSetNames;

namespace Microsoft.Azure.Commands.Blueprint.Test.UnitTests
{
    public class RemoveAzureRmBlueprintAssignmentTests : RMTestBase
    {
        private Mock<IBlueprintClient> _mockBlueprintClient;

        private MockCommandRuntime _mockCommandRuntime;

        private RemoveAzureRmBlueprintAssignment _cmdlet;

        public void SetupTest()
        {
            _mockBlueprintClient = new Mock<IBlueprintClient>();
            _mockCommandRuntime = new MockCommandRuntime();

            _cmdlet = new RemoveAzureRmBlueprintAssignment
            {
                BlueprintClient = _mockBlueprintClient.Object,
                CommandRuntime = _mockCommandRuntime
            };
        }

        public void DeleteBlueprintAssignment()
        {
            // Setup
            var subscriptionId = Guid.NewGuid().ToString();
            var assignmentName = "Assignment1";

            _mockBlueprintClient.Setup(f => f.DeleteBlueprintAssignment(subscriptionId, assignmentName))
                .Returns((string a, string b) => new PSBlueprintAssignment());

            // Test
            _cmdlet.SubscriptionId = subscriptionId;
            _cmdlet.Name = assignmentName;
            _cmdlet.SetParameterSet(ParameterSetNames.DeleteBlueprintAssignmentByName);
            _cmdlet.ExecuteCmdlet();

            // Assert
            _mockBlueprintClient.Verify(f => f.DeleteBlueprintAssignment(subscriptionId, assignmentName), Times.Once());
        }
    }
}
