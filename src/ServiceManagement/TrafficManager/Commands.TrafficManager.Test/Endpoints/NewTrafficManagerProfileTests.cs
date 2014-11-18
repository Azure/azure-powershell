using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.TrafficManager.Endpoint;
using Microsoft.WindowsAzure.Commands.Utilities.TrafficManager;
using Microsoft.WindowsAzure.Management.TrafficManager.Models;
using Moq;

namespace Microsoft.WindowsAzure.Commands.Test.TrafficManager.Profiles
{
    [TestClass]
    public class NewTrafficManagerProfileTests
    {
        private const string profileName = "my-profile";
        private const string profileDomainName = "my.profile.trafficmanager.net";
        private const LoadBalancingMethod loadBalancingMethod = LoadBalancingMethod.Failover;
        private const string domainName = "www.example.com";
        private const int weight = 3;
        private const string cloudServiceType = "CloudService";
        private const string azureWebsiteType = "AzureWebsite";
        private const string anyType = "Any";
        private const string location = "West US";
        private const EndpointStatus status = EndpointStatus.Enabled;
        private const int monitorPort = 80;
        private const DefinitionMonitorProtocol monitorProtocol = DefinitionMonitorProtocol.Http;
        private const string monitorRelativePath = "/";
        private const int ttl = 30;

        private MockCommandRuntime mockCommandRuntime;

        private AddAzureTrafficManagerEndpoint cmdlet;

        private Mock<TrafficManagerClient> clientMock;

        [TestInitialize]
        public void TestSetup()
        {
            mockCommandRuntime = new MockCommandRuntime();
            cmdlet = new AddAzureTrafficManagerEndpoint();
            cmdlet.CommandRuntime = mockCommandRuntime;
            clientMock = new Mock<TrafficManagerClient>();
        }

        [TestMethod]
        public void ProcessNewProfileTest()
        {
            clientMock.Setup(c => c.CreateTrafficManagerProfile())
        }
    }
}
