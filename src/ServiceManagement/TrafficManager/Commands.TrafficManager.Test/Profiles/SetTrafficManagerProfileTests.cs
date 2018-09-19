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
using System.Net;
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
    public class SetTrafficManagerProfileTests
    {
        private const int MonitorExpectedStatusCode = (int)HttpStatusCode.OK;
        private const string Verb = "GET";

        private const string ProfileName = "my-profile";
        private const string ProfileDomainName = "my.profile.trafficmanager.net";

        // Old profile
        private const LoadBalancingMethod DefaultLoadBalancingMethod = LoadBalancingMethod.Failover;
        private const int MonitorPort = 80;
        private const DefinitionMonitorProtocol MonitorProtocol = DefinitionMonitorProtocol.Http;
        private const string MonitorRelativePath = "/";
        private const int Ttl = 30;

        // New profile
        private const LoadBalancingMethod NewLoadBalancingMethod = LoadBalancingMethod.Performance;
        private const int NewMonitorPort = 8080;
        private const DefinitionMonitorProtocol NewMonitorProtocol = DefinitionMonitorProtocol.Https;
        private const string NewMonitorRelativePath = "/index.html";
        private const int NewTtl = 300;

        private MockCommandRuntime mockCommandRuntime;

        private SetAzureTrafficManagerProfile cmdlet;

        private Mock<ITrafficManagerClient> clientMock;

        [TestInitialize]
        public void TestSetup()
        {
            mockCommandRuntime = new MockCommandRuntime();
            clientMock = new Mock<ITrafficManagerClient>();

            clientMock
                .Setup(c => c.InstantiateTrafficManagerDefinition(
                    It.IsAny<string>(),
                    It.IsAny<int>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<int>(),
                    It.IsAny<IList<TrafficManagerEndpoint>>()))
                .Returns(DefaultDefinition);
        }

        [TestMethod]
        public void ProcessSetProfileTestAllArgs()
        {
            // Setup
            ProfileWithDefinition oldProfileWithDefinition = defaultProfileWithDefinition;

            var newProfileWithDefinition = new ProfileWithDefinition
            {
                DomainName = ProfileDomainName,
                Name = ProfileName,
                Endpoints = new List<TrafficManagerEndpoint>(),
                LoadBalancingMethod = NewLoadBalancingMethod,
                MonitorPort = NewMonitorPort,
                Status = ProfileDefinitionStatus.Enabled,
                MonitorRelativePath = NewMonitorRelativePath,
                MonitorProtocol = NewMonitorProtocol,
                TimeToLiveInSeconds = NewTtl
            };


            var newMonitor = new DefinitionMonitor
                {
                    HttpOptions = new DefinitionMonitorHTTPOptions
                        {
                            ExpectedStatusCode = MonitorExpectedStatusCode,
                            RelativePath = NewMonitorRelativePath,
                            Verb = Verb
                        }
                };

            var updateDefinitionCreateParameters = new DefinitionCreateParameters
                {
                    DnsOptions = new DefinitionDnsOptions
                        {
                            TimeToLiveInSeconds = NewTtl
                        },
                    Policy = new DefinitionPolicyCreateParameters
                        {
                            LoadBalancingMethod = NewLoadBalancingMethod,
                            Endpoints = new DefinitionEndpointCreateParameters[0]
                        },
                    Monitors = new[] { newMonitor }
                };

            clientMock
                .Setup(c => c.AssignDefinitionToProfile(ProfileName, It.IsAny<DefinitionCreateParameters>()))
                .Returns(newProfileWithDefinition);

            clientMock
                .Setup(c => c.InstantiateTrafficManagerDefinition(
                NewLoadBalancingMethod.ToString(),
                NewMonitorPort,
                NewMonitorProtocol.ToString(),
                NewMonitorRelativePath,
                NewTtl,
                oldProfileWithDefinition.Endpoints))
                .Returns(updateDefinitionCreateParameters);

            cmdlet = new SetAzureTrafficManagerProfile
                {
                    Name = ProfileName,
                    LoadBalancingMethod = NewLoadBalancingMethod.ToString(),
                    MonitorPort = NewMonitorPort,
                    MonitorProtocol = NewMonitorProtocol.ToString(),
                    MonitorRelativePath = NewMonitorRelativePath,
                    Ttl = NewTtl,
                    TrafficManagerClient = clientMock.Object,
                    CommandRuntime = mockCommandRuntime,
                    TrafficManagerProfile = oldProfileWithDefinition
                };


            // Action
            cmdlet.ExecuteCmdlet();
            var actual = mockCommandRuntime.OutputPipeline[0] as ProfileWithDefinition;

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(newProfileWithDefinition.Name, actual.Name);
            Assert.AreEqual(newProfileWithDefinition.DomainName, actual.DomainName);
            Assert.AreEqual(newProfileWithDefinition.LoadBalancingMethod, actual.LoadBalancingMethod);
            Assert.AreEqual(newProfileWithDefinition.MonitorPort, actual.MonitorPort);
            Assert.AreEqual(newProfileWithDefinition.MonitorProtocol, actual.MonitorProtocol);
            Assert.AreEqual(newProfileWithDefinition.MonitorRelativePath, actual.MonitorRelativePath);
            Assert.AreEqual(newProfileWithDefinition.TimeToLiveInSeconds, actual.TimeToLiveInSeconds);

            // Most important assert; the cmdlet is passing the right parameters
            clientMock.Verify(c => c.InstantiateTrafficManagerDefinition(
                NewLoadBalancingMethod.ToString(),
                NewMonitorPort,
                NewMonitorProtocol.ToString(),
                NewMonitorRelativePath,
                NewTtl,
                oldProfileWithDefinition.Endpoints), Times.Once());
        }

        [TestMethod]
        public void ProcessSetProfileTestLoadBalancingMethod()
        {
            ProfileWithDefinition oldProfileWithDefinition = defaultProfileWithDefinition;

            cmdlet = new SetAzureTrafficManagerProfile
            {
                Name = ProfileName,
                // We only change the load balancign method
                LoadBalancingMethod = NewLoadBalancingMethod.ToString(),
                TrafficManagerClient = clientMock.Object,
                CommandRuntime = mockCommandRuntime,
                TrafficManagerProfile = oldProfileWithDefinition
            };

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            clientMock.Verify(
                c => c.InstantiateTrafficManagerDefinition(
                    // load balancing method is the new one
                    NewLoadBalancingMethod.ToString(),
                    MonitorPort,
                    MonitorProtocol.ToString(),
                    MonitorRelativePath,
                    Ttl,
                    oldProfileWithDefinition.Endpoints),
                Times.Once());
        }

        [TestMethod]
        public void ProcessSetProfileTestMonitorPort()
        {
            ProfileWithDefinition oldProfileWithDefinition = defaultProfileWithDefinition;

            cmdlet = new SetAzureTrafficManagerProfile
                {
                    Name = ProfileName,
                    // We only change the monitor port
                    MonitorPort = NewMonitorPort,
                    TrafficManagerClient = clientMock.Object,
                    CommandRuntime = mockCommandRuntime,
                    TrafficManagerProfile = oldProfileWithDefinition
                };


            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            clientMock.Verify(
                c => c.InstantiateTrafficManagerDefinition(
                    DefaultLoadBalancingMethod.ToString(),
                    // monitor port is the new one
                    NewMonitorPort,
                    MonitorProtocol.ToString(),
                    MonitorRelativePath,
                    Ttl,
                    oldProfileWithDefinition.Endpoints),
                Times.Once());
        }

        [TestMethod]
        public void ProcessSetProfileTestMonitorProtocol()
        {
            ProfileWithDefinition oldProfileWithDefinition = defaultProfileWithDefinition;

            cmdlet = new SetAzureTrafficManagerProfile
                {
                    Name = ProfileName,
                    // We only change the monitor protocl
                    MonitorProtocol = NewMonitorProtocol.ToString(),
                    TrafficManagerClient = clientMock.Object,
                    CommandRuntime = mockCommandRuntime,
                    TrafficManagerProfile = oldProfileWithDefinition
                };


            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            clientMock.Verify(
                c => c.InstantiateTrafficManagerDefinition(
                    DefaultLoadBalancingMethod.ToString(),
                    MonitorPort,
                    // monitor protocol is the new one
                    NewMonitorProtocol.ToString(),
                    MonitorRelativePath,
                    Ttl,
                    oldProfileWithDefinition.Endpoints),
                Times.Once());
        }

        [TestMethod]
        public void ProcessSetProfileTestMonitorRelativePath()
        {
            ProfileWithDefinition oldProfileWithDefinition = defaultProfileWithDefinition;

            cmdlet = new SetAzureTrafficManagerProfile
                {
                    Name = ProfileName,
                    // We only change the monitor protocl
                    MonitorRelativePath = NewMonitorRelativePath,
                    TrafficManagerClient = clientMock.Object,
                    CommandRuntime = mockCommandRuntime,
                    TrafficManagerProfile = oldProfileWithDefinition
                };


            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            clientMock.Verify(
                c => c.InstantiateTrafficManagerDefinition(
                    DefaultLoadBalancingMethod.ToString(),
                    MonitorPort,
                    MonitorProtocol.ToString(),
                    // monitor relative path is the new one
                    NewMonitorRelativePath,
                    Ttl,
                    oldProfileWithDefinition.Endpoints),
                Times.Once());
        }

        [TestMethod]
        public void ProcessSetProfileTestTtl()
        {
            ProfileWithDefinition oldProfileWithDefinition = defaultProfileWithDefinition;

            cmdlet = new SetAzureTrafficManagerProfile
                {
                    Name = ProfileName,
                    // We only change the ttl
                    Ttl = NewTtl,
                    TrafficManagerClient = clientMock.Object,
                    CommandRuntime = mockCommandRuntime,
                    TrafficManagerProfile = oldProfileWithDefinition
                };

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            clientMock.Verify(
                c => c.InstantiateTrafficManagerDefinition(
                    DefaultLoadBalancingMethod.ToString(),
                    MonitorPort,
                    MonitorProtocol.ToString(),
                    MonitorRelativePath,
                    // ttl is the new one
                    NewTtl,
                    oldProfileWithDefinition.Endpoints),
                Times.Once());
        }

        private static ProfileWithDefinition defaultProfileWithDefinition = new ProfileWithDefinition()
        {
            DomainName = ProfileDomainName,
            Name = ProfileName,
            Endpoints = new List<TrafficManagerEndpoint>(),
            LoadBalancingMethod = DefaultLoadBalancingMethod,
            MonitorPort = MonitorPort,
            Status = ProfileDefinitionStatus.Enabled,
            MonitorRelativePath = MonitorRelativePath,
            MonitorProtocol = MonitorProtocol,
            TimeToLiveInSeconds = Ttl
        };

        private static DefinitionCreateParameters DefaultDefinition
        {
            get
            {
                return new DefinitionCreateParameters
                    {
                        Policy =
                            new DefinitionPolicyCreateParameters
                                {
                                    Endpoints = new List<DefinitionEndpointCreateParameters>()
                                }
                    };
            }
        }
    }
}
