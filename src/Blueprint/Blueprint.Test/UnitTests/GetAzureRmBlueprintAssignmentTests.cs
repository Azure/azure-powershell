using System;
using Microsoft.Azure.Commands.Blueprint.Cmdlets;
using Microsoft.Azure.Commands.Blueprint.Common;
using Microsoft.Azure.Commands.Blueprint.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Moq;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using ParameterSetNames = Microsoft.Azure.Commands.Blueprint.Common.BlueprintConstants.ParameterSetNames;

namespace Microsoft.Azure.Commands.Blueprint.Test.UnitTests
{

    public class GetAzureRmBlueprintAssignmentTests : RMTestBase
    {
        private Mock<IBlueprintClient> _mockBlueprintClient;

        private MockCommandRuntime _mockCommandRuntime;

        private GetAzureRmBlueprintAssignment _cmdlet;

        
        public void SetupTest()
        {
            _mockBlueprintClient = new Mock<IBlueprintClient>();
            _mockCommandRuntime = new MockCommandRuntime();

            _cmdlet = new GetAzureRmBlueprintAssignment
            {
                BlueprintClient = _mockBlueprintClient.Object,
                CommandRuntime = _mockCommandRuntime
            };
        }

      
        public void ListBlueprintAssignmentBySubscription()
        {
            // Setup
            var subscriptionId = Guid.NewGuid().ToString();

            _mockBlueprintClient.Setup(f => f.ListBlueprintAssignments(subscriptionId)).Returns((string a) => new List<PSBlueprintAssignment>());

            // Test
            _cmdlet.SubscriptionId = subscriptionId;
            _cmdlet.SetParameterSet(ParameterSetNames.BlueprintAssignmentsBySubscription);
            _cmdlet.ExecuteCmdlet();

            // Assert
            _mockBlueprintClient.Verify(f => f.ListBlueprintAssignments(subscriptionId), Times.Once());
        }
        
        public void BlueprintAssignmentByName()
        {
            // Setup
            var subscriptionId = Guid.NewGuid().ToString();
            var name = "Assignment1";

            _mockBlueprintClient.Setup(f => f.GetBlueprintAssignment(subscriptionId, name)).Returns((string a, string b) => new PSBlueprintAssignment());

            // Test
            _cmdlet.SubscriptionId = subscriptionId;
            _cmdlet.Name = name;
            _cmdlet.SetParameterSet(ParameterSetNames.BlueprintAssignmentByName);
            _cmdlet.ExecuteCmdlet();

            // Assert
            _mockBlueprintClient.Verify(f => f.GetBlueprintAssignment(subscriptionId, name), Times.Once());
        }
    }
}
