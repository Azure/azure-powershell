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
using System.Linq;
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
    public class GetTrafficManagerProfileTests
    {
        private const string ProfileName = "my-profile";
        private const string ProfileDomainName = "my.profile.trafficmanager.net";
        private const LoadBalancingMethod LoadBalancingMethodDefault = LoadBalancingMethod.Failover;

        private MockCommandRuntime mockCommandRuntime;

        private GetAzureTrafficManagerProfile cmdlet;

        private Mock<ITrafficManagerClient> clientMock;

        [TestInitialize]
        public void TestSetup()
        {
            mockCommandRuntime = new MockCommandRuntime();
            clientMock = new Mock<ITrafficManagerClient>();
        }

        [TestMethod]
        public void ProcessGetSingleProfile()
        {
            // Setup
            ProfileWithDefinition expected = GetProfileWithDefinition();

            clientMock
                .Setup(c => c.GetTrafficManagerProfileWithDefinition(ProfileName))
                .Returns(expected);

            cmdlet = new GetAzureTrafficManagerProfile
                {
                    Name = ProfileName,
                    TrafficManagerClient = clientMock.Object,
                    CommandRuntime = mockCommandRuntime,
                };

            // Action
            cmdlet.ExecuteCmdlet();

            // Test
            Assert.AreEqual(1, mockCommandRuntime.OutputPipeline.Count);

            var actual = mockCommandRuntime.OutputPipeline[0] as ProfileWithDefinition;

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Name, actual.Name);

            // TODO: Override .Equals in ProfileDefinition and uncomment this line
            // Assert.AreEquals(expected, actual);

            clientMock.Verify(c => c.GetTrafficManagerProfileWithDefinition(ProfileName), Times.Once());
        }

        [TestMethod]
        public void ProcessGetListProfiles()
        {
            // Setup
            ProfileWithDefinition expected1 = GetProfileWithDefinition();
            ProfileWithDefinition expected2 = GetProfileWithDefinition();
            expected2.Name = "my-profile2";
            expected2.DomainName = "my-profile2.trafficmanager.net";

            IEnumerable<SimpleProfile> expected = new List<SimpleProfile> {expected1, expected2};

            clientMock.Setup(c => c.ListProfiles()).Returns(expected);

            cmdlet = new GetAzureTrafficManagerProfile
                {
                    TrafficManagerClient = clientMock.Object,
                    CommandRuntime = mockCommandRuntime,
                };

            // Action
            cmdlet.ExecuteCmdlet();

            var actual = (IEnumerable<SimpleProfile>)mockCommandRuntime.OutputPipeline[0];

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count(), actual.Count());
            Assert.IsTrue(actual.Any(p => p.Name.Equals(expected1.Name)));
            Assert.IsTrue(actual.Any(p => p.Name.Equals(expected2.Name)));
            Assert.IsTrue(actual.Any(p => p.DomainName.Equals(expected1.DomainName)));
            Assert.IsTrue(actual.Any(p => p.DomainName.Equals(expected2.DomainName)));

            clientMock.Verify(c => c.ListProfiles(), Times.Once());
        }

        private ProfileWithDefinition GetProfileWithDefinition()
        {
            return new ProfileWithDefinition
                {
                    DomainName = ProfileDomainName,
                    Name = ProfileName,
                    Endpoints = new List<TrafficManagerEndpoint>(),
                    LoadBalancingMethod = LoadBalancingMethodDefault,
                    MonitorPort = 80,
                    Status = ProfileDefinitionStatus.Enabled,
                    MonitorRelativePath = "/",
                    TimeToLiveInSeconds = 30
                };
        }
    }
}
