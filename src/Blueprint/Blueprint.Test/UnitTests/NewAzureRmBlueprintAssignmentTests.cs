using System;
using Microsoft.Azure.Commands.Blueprint.Cmdlets;
using Microsoft.Azure.Commands.Blueprint.Common;
using Microsoft.Azure.Commands.Blueprint.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Moq;
using System.Collections.Generic;
using Microsoft.Azure.Management.Blueprint.Models;
using ParameterSetNames = Microsoft.Azure.Commands.Blueprint.Common.BlueprintConstants.ParameterSetNames;

namespace Microsoft.Azure.Commands.Blueprint.Test.UnitTests
{
    public class NewAzureRmBlueprintAssignmentTests
    {
        private Mock<IBlueprintClient> _mockBlueprintClient;

        private MockCommandRuntime _mockCommandRuntime;

        private NewAzureRmBlueprintAssignment _cmdlet;

        public void SetupTest()
        {
            _mockBlueprintClient = new Mock<IBlueprintClient>();
            _mockCommandRuntime = new MockCommandRuntime();

            _cmdlet = new NewAzureRmBlueprintAssignment
            {
                BlueprintClient = _mockBlueprintClient.Object,
                CommandRuntime = _mockCommandRuntime
            };
        }

        public void CreateBlueprintAssignment()
        {
            // Setup
            var subscriptionId = Guid.NewGuid().ToString();
            var assignmentName = "Assignment1";
            var assignment = new Assignment();

            _mockBlueprintClient.Setup(f => f.CreateOrUpdateBlueprintAssignment(subscriptionId, assignmentName, assignment)).Returns((string a, string b, string c) => new PSBlueprintAssignment());

            // Test
            _cmdlet.SetParameterSet(ParameterSetNames.CreateBlueprintAssignment);
            _cmdlet.ExecuteCmdlet();

            // Assert
            _mockBlueprintClient.Verify(f => f.CreateOrUpdateBlueprintAssignment(subscriptionId, assignmentName, assignment), Times.Once());
        }
    }
}
