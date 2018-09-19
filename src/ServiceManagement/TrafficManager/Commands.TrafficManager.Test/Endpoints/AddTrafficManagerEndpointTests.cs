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

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.TrafficManager.Endpoint;
using Microsoft.WindowsAzure.Commands.TrafficManager.Models;
using Microsoft.WindowsAzure.Management.TrafficManager.Models;

namespace Microsoft.WindowsAzure.Commands.Test.TrafficManager.Endpoints
{
    [TestClass]
    public class AddTrafficManagerEndpointTests : SMTestBase
    {
        private const string ProfileName = "my-profile";
        private const string ProfileDomainName = "my.profile.trafficmanager.net";
        private const string TopLevelProfileDomainName = "my.toplevelprofile.trafficmanager.net";
        private const LoadBalancingMethod DefaultLoadBalancingMethod = LoadBalancingMethod.Failover;
        private const string DomainName = "www.example.com";
        private const string CloudServiceType = "CloudService";
        private const string AzureWebsiteType = "AzureWebsite";
        private const string AnyType = "Any";
        private const string TrafficManagerType = "TrafficManager";
        private const EndpointStatus Status = EndpointStatus.Enabled;
        private const int Weight = 3;
        private const int MinChildEndpoints = 3;

        private MockCommandRuntime mockCommandRuntime;

        private AddAzureTrafficManagerEndpoint cmdlet;

        [TestInitialize]
        public void TestSetup()
        {
            mockCommandRuntime = new MockCommandRuntime();
        }

        [TestMethod]
        public void AddTrafficManagerEndpointCloudService()
        {
            ProfileWithDefinition original = GetProfileWithDefinition();

            // Setup
            cmdlet = new AddAzureTrafficManagerEndpoint
            {
                DomainName = DomainName,
                Type = CloudServiceType,
                Weight = Weight,
                Status = Status.ToString(),
                TrafficManagerProfile = original,
                CommandRuntime = mockCommandRuntime
            };

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            var actual = mockCommandRuntime.OutputPipeline[0] as ProfileWithDefinition;

            // All the properties stay the same except the endpoints
            AssertAllProfilePropertiesDontChangeExceptEndpoints(original, actual);

            // There is a new endpoint with the new domain name in "actual"
            Assert.IsTrue(actual.Endpoints.Any(e => e.DomainName == DomainName));
        }

        [TestMethod]
        public void AddTrafficManagerEndpointWebsite()
        {
            ProfileWithDefinition original = GetProfileWithDefinition();

            // Setup
            cmdlet = new AddAzureTrafficManagerEndpoint
            {
                DomainName = DomainName,
                Type = AzureWebsiteType,
                Weight = Weight,
                TrafficManagerProfile = original,
                CommandRuntime = mockCommandRuntime,
                Status = "Enabled"
            };

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            var actual = mockCommandRuntime.OutputPipeline[0] as ProfileWithDefinition;

            // All the properties stay the same except the endpoints
            AssertAllProfilePropertiesDontChangeExceptEndpoints(original, actual);

            // There is a new endpoint with the new domain name in "actual" but not in "original"
            Assert.IsTrue(actual.Endpoints.Any(e => e.DomainName == DomainName));
        }

        [TestMethod]
        public void AddTrafficManagerEndpointAny()
        {
            ProfileWithDefinition original = GetProfileWithDefinition();

            cmdlet = new AddAzureTrafficManagerEndpoint
            {
                DomainName = DomainName,
                Type = AnyType,
                Weight = Weight,
                TrafficManagerProfile = original,
                CommandRuntime = mockCommandRuntime,
                Status = "Enabled"
            };

            // Action
            cmdlet.ExecuteCmdlet();

            var actual = mockCommandRuntime.OutputPipeline[0] as ProfileWithDefinition;

            // Assert
            // All the properties stay the same except the endpoints
            AssertAllProfilePropertiesDontChangeExceptEndpoints(original, actual);

            // There is a new endpoint with the new domain name in "actual" but not in "original"
            Assert.IsTrue(actual.Endpoints.Any(e => e.DomainName == DomainName));
        }

        [TestMethod]
        public void AddTrafficManagerEndpointTrafficManager()
        {
            ProfileWithDefinition nestedProfile = GetProfileWithDefinition();
            ProfileWithDefinition topLevelProfile = GetProfileWithDefinition(TopLevelProfileDomainName);

            cmdlet = new AddAzureTrafficManagerEndpoint
            {
                DomainName = DomainName,
                Type = AnyType,
                Weight = Weight,
                TrafficManagerProfile = nestedProfile,
                CommandRuntime = mockCommandRuntime,
                Status = "Enabled"
            };

            var cmdletTopLevelEndpoint = new AddAzureTrafficManagerEndpoint
            {
                DomainName = ProfileDomainName,
                Type = TrafficManagerType,
                Weight = Weight,
                MinChildEndpoints = MinChildEndpoints,
                TrafficManagerProfile = topLevelProfile,
                CommandRuntime = mockCommandRuntime,
                Status = "Enabled"
            };

            // Action
            cmdlet.ExecuteCmdlet();
            cmdletTopLevelEndpoint.ExecuteCmdlet();

            var actualNestedProfile = mockCommandRuntime.OutputPipeline[0] as ProfileWithDefinition;
            var actualTopLevelProfile = mockCommandRuntime.OutputPipeline[1] as ProfileWithDefinition;

            // Assert
            // All the properties stay the same except the endpoints
            AssertAllProfilePropertiesDontChangeExceptEndpoints(nestedProfile, actualNestedProfile);
            AssertAllProfilePropertiesDontChangeExceptEndpoints(topLevelProfile, actualTopLevelProfile);

            // There is a new endpoint with the new domain name in "actual" but not in "nestedProfile"
            Assert.IsTrue(actualNestedProfile.Endpoints.Any(e => e.DomainName == DomainName));
            Assert.IsTrue(actualTopLevelProfile.Endpoints.Any(e => e.DomainName == ProfileDomainName));
        }

        [TestMethod]
        public void AddTrafficManagerEndpointAlreadyExistsFails()
        {
            // Setup
            ProfileWithDefinition original = GetProfileWithDefinition();

            var existingEndpoint = new TrafficManagerEndpoint
            {
                DomainName = DomainName,
                Type = EndpointType.Any,
                Status = EndpointStatus.Enabled
            };

            original.Endpoints.Add(existingEndpoint);

            cmdlet = new AddAzureTrafficManagerEndpoint
            {
                DomainName = DomainName,
                Type = AnyType,
                TrafficManagerProfile = original,
                CommandRuntime = mockCommandRuntime
            };

            // Action + Assert
            Testing.AssertThrows<Exception>(() => cmdlet.ExecuteCmdlet());
        }

        [TestMethod]
        public void AddTrafficManagerEndpointNoWeightNoLocationNoMinChildEndpoints()
        {
            // Setup
            ProfileWithDefinition original = GetProfileWithDefinition();

            cmdlet = new AddAzureTrafficManagerEndpoint
            {
                DomainName = DomainName,
                Type = AnyType,
                TrafficManagerProfile = original,
                CommandRuntime = mockCommandRuntime,
                Status = "Enabled"
            };

            // Action
            cmdlet.ExecuteCmdlet();

            var actual = mockCommandRuntime.OutputPipeline[0] as ProfileWithDefinition;

            // Assert
            // All the properties stay the same except the endpoints
            AssertAllProfilePropertiesDontChangeExceptEndpoints(original, actual);

            // There is a new endpoint with the new domain name in "actual" but not in "original"
            Assert.IsTrue(actual.Endpoints.Any(e => e.DomainName == DomainName));
            TrafficManagerEndpoint endpoint = actual.Endpoints.First(e => e.DomainName == DomainName);

            Assert.AreEqual(null, endpoint.Weight);
            Assert.IsNull(endpoint.Location);
            Assert.AreEqual(null, endpoint.MinChildEndpoints);
        }

        private ProfileWithDefinition GetProfileWithDefinition(string profileDomainName = ProfileDomainName)
        {
            return new ProfileWithDefinition
            {
                DomainName = profileDomainName,
                Name = ProfileName,
                Endpoints = new List<TrafficManagerEndpoint>(),
                LoadBalancingMethod = DefaultLoadBalancingMethod,
                MonitorPort = 80,
                Status = ProfileDefinitionStatus.Enabled,
                MonitorRelativePath = "/",
                TimeToLiveInSeconds = 30
            };
        }

        private void AssertAllProfilePropertiesDontChangeExceptEndpoints(
            ProfileWithDefinition original, 
            ProfileWithDefinition actual)
        {
            Assert.AreEqual(original.DomainName, actual.DomainName);
            Assert.AreEqual(original.Name, actual.Name);
            Assert.AreEqual(original.LoadBalancingMethod, actual.LoadBalancingMethod);
            Assert.AreEqual(original.MonitorPort, actual.MonitorPort);
            Assert.AreEqual(original.Status, actual.Status);
            Assert.AreEqual(original.MonitorRelativePath, actual.MonitorRelativePath);
            Assert.AreEqual(original.TimeToLiveInSeconds, actual.TimeToLiveInSeconds);
        }

    }

}
