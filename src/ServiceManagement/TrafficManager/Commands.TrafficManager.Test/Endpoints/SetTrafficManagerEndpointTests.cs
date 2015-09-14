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
    public class SetTrafficManagerEndpointTests : SMTestBase
    {
        private const string ProfileName = "my-profile";
        private const string ProfileDomainName = "my.profile.trafficmanager.net";
        private const LoadBalancingMethod DefaultLoadBalancingMethod = LoadBalancingMethod.Failover;
        private const string DomainName = "www.example.com";
        private const int Weight = 3;
        private const int MinChildEndpoints = 2;
        private const string Location = "West US";
        private MockCommandRuntime mockCommandRuntime;
        private SetAzureTrafficManagerEndpoint cmdlet;

        [TestInitialize]
        public void TestSetup()
        {
            mockCommandRuntime = new MockCommandRuntime();
        }

        [TestMethod]
        public void SetTrafficManagerEndpointSucceeds()
        {
            // Setup
            ProfileWithDefinition original = GetProfileWithDefinition();

            var existingEndpoint = new TrafficManagerEndpoint
            {
                DomainName = DomainName,
                Type = EndpointType.Any,
                Status = EndpointStatus.Enabled,
                Weight = 10,
                MinChildEndpoints = 2
            };

            original.Endpoints.Add(existingEndpoint);

            // Assert the endpoint exists
            Assert.IsTrue(original.Endpoints.Any(e => e.DomainName == DomainName));

            cmdlet = new SetAzureTrafficManagerEndpoint
            {
                DomainName = DomainName,
                TrafficManagerProfile = original,
                Weight = Weight,
                MinChildEndpoints = MinChildEndpoints,
                Location = Location,
                CommandRuntime = mockCommandRuntime
            };

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            var actual = mockCommandRuntime.OutputPipeline[0] as ProfileWithDefinition;

            // All the properties stay the same except the endpoints
            AssertAllProfilePropertiesDontChangeExceptEndpoints(original, actual);

            // There is an endpoint with the domain name in "actual"
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Endpoints.Any(e => e.DomainName == DomainName));
            TrafficManagerEndpoint updatedEndpoint = actual.Endpoints.First(e => e.DomainName == DomainName);

            // Unchanged properties
            Assert.AreEqual(EndpointType.Any, updatedEndpoint.Type);
            Assert.AreEqual(EndpointStatus.Enabled, updatedEndpoint.Status);

            // Updated properties
            Assert.AreEqual(Weight, updatedEndpoint.Weight);
            Assert.AreEqual(Location, updatedEndpoint.Location);
            Assert.AreEqual(MinChildEndpoints, updatedEndpoint.MinChildEndpoints);
        }

        [TestMethod]
        public void SetTrafficManagerNotOverrideWeight()
        {
            // Setup
            ProfileWithDefinition original = GetProfileWithDefinition();

            var existingEndpoint = new TrafficManagerEndpoint
            {
                DomainName = DomainName,
                Type = EndpointType.Any,
                Status = EndpointStatus.Enabled,
                Weight = Weight
            };

            original.Endpoints.Add(existingEndpoint);

            // Assert the endpoint exists
            Assert.IsTrue(original.Endpoints.Any(e => e.DomainName == DomainName));

            cmdlet = new SetAzureTrafficManagerEndpoint
            {
                DomainName = DomainName,
                TrafficManagerProfile = original,
                Location = Location,
                CommandRuntime = mockCommandRuntime
            };

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            var actual = mockCommandRuntime.OutputPipeline[0] as ProfileWithDefinition;

            // All the properties stay the same except the endpoints
            AssertAllProfilePropertiesDontChangeExceptEndpoints(original, actual);

            // There is an endpoint with the domain name in "actual"
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Endpoints.Any(e => e.DomainName == DomainName));
            TrafficManagerEndpoint updatedEndpoint = actual.Endpoints.First(e => e.DomainName == DomainName);

            // Unchanged properties
            Assert.AreEqual(EndpointType.Any, updatedEndpoint.Type);
            Assert.AreEqual(EndpointStatus.Enabled, updatedEndpoint.Status);

            // Updated properties
            Assert.AreEqual(Weight, updatedEndpoint.Weight);
            Assert.AreEqual(Location, updatedEndpoint.Location);
        }

        [TestMethod]
        public void SetTrafficManagerEndpointNotExisting()
        {
            // Setup
            ProfileWithDefinition original = GetProfileWithDefinition();
            TrafficManagerEndpoint expectedEndpoint = new TrafficManagerEndpoint()
            {
                DomainName = DomainName,
                Type = EndpointType.Any,
                Status = EndpointStatus.Enabled,
                Weight = Weight,
                MinChildEndpoints = MinChildEndpoints,
                Location = Location
            };

            cmdlet = new SetAzureTrafficManagerEndpoint
            {
                DomainName = DomainName,
                TrafficManagerProfile = original,
                Type = EndpointType.Any.ToString(),
                Weight = Weight,
                MinChildEndpoints = MinChildEndpoints,
                Location = Location,
                Status = EndpointStatus.Enabled.ToString(),
                CommandRuntime = mockCommandRuntime
            };

            // Assert the endpoint doesn't exist
            Assert.IsFalse(original.Endpoints.Any(e => e.DomainName == DomainName));

            // Action
            cmdlet.ExecuteCmdlet();

            var actual = mockCommandRuntime.OutputPipeline[0] as ProfileWithDefinition;

            // There is a new endpoint with the domain name in "actual"
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Endpoints.Any(e => e.DomainName == DomainName));
            TrafficManagerEndpoint newEndpoint = actual.Endpoints.First(e => e.DomainName == DomainName);
            Assert.AreEqual(expectedEndpoint, newEndpoint);
        }

        /// <summary>
        /// The Type of the endpoint is a required field for new endpoints. Since it's not provided in the arguments
        /// to the cmdlet, the cmdlet fails.
        /// </summary>
        [TestMethod]
        public void SetTrafficManagerEndpointMissinTypeFails()
        {
            // Setup
            ProfileWithDefinition original = GetProfileWithDefinition();

            cmdlet = new SetAzureTrafficManagerEndpoint
            {
                DomainName = DomainName,
                TrafficManagerProfile = original,
                Weight = Weight,
                Location = Location,
                Status = EndpointStatus.Enabled.ToString(),
                CommandRuntime = mockCommandRuntime
            };

            // Assert the endpoint doesn't exist
            Assert.IsFalse(original.Endpoints.Any(e => e.DomainName == DomainName));

            // Action + Assert
            Testing.AssertThrows<Exception>(
                () => cmdlet.ExecuteCmdlet(),
                Microsoft.WindowsAzure.Commands.Common.Properties.Resources.SetTrafficManagerEndpointNeedsParameters);
        }

        /// <summary>
        /// The Type of the endpoint is a required field for new endpoints. Since it's not provided in the arguments
        /// to the cmdlet, the cmdlet fails.
        /// </summary>
        [TestMethod]
        public void SetTrafficManagerEndpointMissingStatusFails()
        {
            // Setup
            ProfileWithDefinition original = GetProfileWithDefinition();

            cmdlet = new SetAzureTrafficManagerEndpoint
            {
                DomainName = DomainName,
                TrafficManagerProfile = original,
                Weight = Weight,
                Location = Location,
                Type = EndpointType.Any.ToString(),
                CommandRuntime = mockCommandRuntime
            };

            // Assert the endpoint doesn't exist
            Assert.IsFalse(original.Endpoints.Any(e => e.DomainName == DomainName));

            // Action + Assert
            Testing.AssertThrows<Exception>(
                () => cmdlet.ExecuteCmdlet(),
                Microsoft.WindowsAzure.Commands.Common.Properties.Resources.SetTrafficManagerEndpointNeedsParameters);
        }

        /// <summary>
        /// The Type of the endpoint is a required field for new endpoints. Since it's not provided in the arguments
        /// to the cmdlet, the cmdlet fails.
        /// </summary>
        [TestMethod]
        public void SetTrafficManagerEndpointMissingWeightSucceeds()
        {
            // Setup
            ProfileWithDefinition original = GetProfileWithDefinition();

            cmdlet = new SetAzureTrafficManagerEndpoint
            {
                DomainName = DomainName,
                TrafficManagerProfile = original,
                Location = Location,
                Type = EndpointType.Any.ToString(),
                Status = EndpointStatus.Enabled.ToString(),
                CommandRuntime = mockCommandRuntime
            };

            // Assert the endpoint doesn't exist
            Assert.IsFalse(original.Endpoints.Any(e => e.DomainName == DomainName));

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            var actual = mockCommandRuntime.OutputPipeline[0] as ProfileWithDefinition;

            // There is a new endpoint with the domain name in "actual"
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Endpoints.Any(e => e.DomainName == DomainName));
            TrafficManagerEndpoint newEndpoint = actual.Endpoints.First(e => e.DomainName == DomainName);

            Assert.AreEqual(EndpointType.Any, newEndpoint.Type);
            Assert.AreEqual(EndpointStatus.Enabled, newEndpoint.Status);

            // Default weight value in PS is null
            Assert.AreEqual(null, newEndpoint.Weight);
            Assert.AreEqual(Location, newEndpoint.Location);
        }

        [TestMethod]
        public void SetTrafficManagerEndpointMissingLocationSucceeds()
        {
            // Setup
            ProfileWithDefinition original = GetProfileWithDefinition();

            cmdlet = new SetAzureTrafficManagerEndpoint
            {
                DomainName = DomainName,
                TrafficManagerProfile = original,
                Weight = Weight,
                Type = EndpointType.Any.ToString(),
                Status = EndpointStatus.Enabled.ToString(),
                CommandRuntime = mockCommandRuntime
            };

            // Assert the endpoint doesn't exist
            Assert.IsFalse(original.Endpoints.Any(e => e.DomainName == DomainName));

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            var actual = mockCommandRuntime.OutputPipeline[0] as ProfileWithDefinition;

            // There is a new endpoint with the domain name in "actual"
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Endpoints.Any(e => e.DomainName == DomainName));
            TrafficManagerEndpoint newEndpoint = actual.Endpoints.First(e => e.DomainName == DomainName);

            Assert.AreEqual(EndpointType.Any, newEndpoint.Type);
            Assert.AreEqual(EndpointStatus.Enabled, newEndpoint.Status);

            Assert.AreEqual(Weight, newEndpoint.Weight);
            Assert.AreEqual(null, newEndpoint.Location);
        }

        private ProfileWithDefinition GetProfileWithDefinition()
        {
            return new ProfileWithDefinition
            {
                DomainName = ProfileDomainName,
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
