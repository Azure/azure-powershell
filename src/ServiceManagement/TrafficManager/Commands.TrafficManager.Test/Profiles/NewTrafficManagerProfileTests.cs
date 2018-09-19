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

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.TrafficManager.Models;
using Microsoft.WindowsAzure.Commands.TrafficManager.Profile;
using Microsoft.WindowsAzure.Commands.TrafficManager.Utilities;
using Microsoft.WindowsAzure.Management.TrafficManager.Models;
using Moq;

namespace Microsoft.WindowsAzure.Commands.Test.TrafficManager.Profiles
{
    [TestClass]
    public class NewTrafficManagerProfileTests
    {
        private const string ProfileName = "my-profile";
        private const string ProfileDomainName = "my.profile.trafficmanager.net";
        private const LoadBalancingMethod DefaultLoadBalancingMethod = LoadBalancingMethod.Failover;
        private const int MonitorPort = 80;
        private const DefinitionMonitorProtocol MonitorProtocol = DefinitionMonitorProtocol.Http;
        private const string MonitorRelativePath = "/";
        private const int Ttl = 30;

        private MockCommandRuntime mockCommandRuntime;

        private NewAzureTrafficManagerProfile cmdlet;

        private Mock<ITrafficManagerClient> clientMock;

        [TestInitialize]
        public void TestSetup()
        {
            mockCommandRuntime = new MockCommandRuntime();
            clientMock = new Mock<ITrafficManagerClient>();
        }

        [TestMethod]
        public void ProcessNewProfileTest()
        {
            // Setup
            clientMock.Setup(c => c.NewAzureTrafficManagerProfile(
                            ProfileName,
                            ProfileDomainName,
                            DefaultLoadBalancingMethod.ToString(),
                            MonitorPort,
                            MonitorProtocol.ToString(),
                            MonitorRelativePath,
                            Ttl))
                      .Returns(new ProfileWithDefinition
                      {
                          DomainName = ProfileDomainName,
                          Name = ProfileName,
                          Endpoints = new List<TrafficManagerEndpoint>(),
                          LoadBalancingMethod = DefaultLoadBalancingMethod,
                          MonitorPort = 80,
                          Status = ProfileDefinitionStatus.Enabled,
                          MonitorRelativePath = MonitorRelativePath,
                          TimeToLiveInSeconds = Ttl
                      });


            cmdlet = new NewAzureTrafficManagerProfile
                {
                    Name = ProfileName,
                    DomainName = ProfileDomainName,
                    LoadBalancingMethod = DefaultLoadBalancingMethod.ToString(),
                    MonitorPort = MonitorPort,
                    MonitorProtocol = MonitorProtocol.ToString(),
                    MonitorRelativePath = MonitorRelativePath,
                    Ttl = Ttl,
                    TrafficManagerClient = clientMock.Object,
                    CommandRuntime = mockCommandRuntime
                };

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            var actual = mockCommandRuntime.OutputPipeline[0] as ProfileWithDefinition;

            Assert.IsNotNull(actual);
            Assert.AreEqual(ProfileName, actual.Name);
            Assert.AreEqual(ProfileDomainName, actual.DomainName);
            Assert.AreEqual(MonitorRelativePath, actual.MonitorRelativePath);
            Assert.AreEqual(Ttl, actual.TimeToLiveInSeconds);
            Assert.AreEqual(DefaultLoadBalancingMethod, actual.LoadBalancingMethod);
            Assert.IsTrue(actual.Endpoints.Count == 0);
        }
    }
}
