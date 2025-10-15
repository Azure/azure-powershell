// -----------------------------------------------------------------------------
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
// -----------------------------------------------------------------------------

using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Management.Batch.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ModelsConversions
{
    public class PSContainerConfigurationTests
    {
        #region toMgmtContainerConfiguration Tests

        [Fact]
        public void ToMgmtContainerConfiguration_WithAllProperties_ReturnsCorrectMapping()
        {
            // Arrange
            var identityResourceId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity";
            var psIdentityRef = new PSComputeNodeIdentityReference { ResourceId = identityResourceId };
            var psRegistry = new PSContainerRegistry(
                userName: "testuser",
                password: "testpass",
                registryServer: "myregistry.azurecr.io",
                identityReference: psIdentityRef);

            var psContainerConfig = new PSContainerConfiguration
            {
                Type = "DockerCompatible",
                ContainerImageNames = new List<string> { "ubuntu:20.04", "nginx:alpine" },
                ContainerRegistries = new List<PSContainerRegistry> { psRegistry }
            };

            // Act
            var result = psContainerConfig.toMgmtContainerConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("DockerCompatible", result.Type);
            Assert.NotNull(result.ContainerImageNames);
            Assert.Equal(2, result.ContainerImageNames.Count);
            Assert.Contains("ubuntu:20.04", result.ContainerImageNames);
            Assert.Contains("nginx:alpine", result.ContainerImageNames);
            Assert.NotNull(result.ContainerRegistries);
            Assert.Single(result.ContainerRegistries);
            Assert.Equal("testuser", result.ContainerRegistries.First().UserName);
            Assert.Equal("myregistry.azurecr.io", result.ContainerRegistries.First().RegistryServer);
        }

        [Fact]
        public void ToMgmtContainerConfiguration_WithDockerCompatible_ReturnsCorrectMapping()
        {
            // Arrange
            var psContainerConfig = new PSContainerConfiguration
            {
                Type = "DockerCompatible",
                ContainerImageNames = new List<string> { "mcr.microsoft.com/dotnet/runtime:6.0" },
                ContainerRegistries = new List<PSContainerRegistry>()
            };

            // Act
            var result = psContainerConfig.toMgmtContainerConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("DockerCompatible", result.Type);
            Assert.NotNull(result.ContainerImageNames);
            Assert.Single(result.ContainerImageNames);
            Assert.Equal("mcr.microsoft.com/dotnet/runtime:6.0", result.ContainerImageNames.First());
            Assert.NotNull(result.ContainerRegistries);
            Assert.Empty(result.ContainerRegistries);
        }

        [Fact]
        public void ToMgmtContainerConfiguration_WithCriCompatible_ReturnsCorrectMapping()
        {
            // Arrange
            var psContainerConfig = new PSContainerConfiguration
            {
                Type = "CriCompatible",
                ContainerImageNames = new List<string> { "docker.io/library/alpine:latest" },
                ContainerRegistries = new List<PSContainerRegistry>()
            };

            // Act
            var result = psContainerConfig.toMgmtContainerConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("CriCompatible", result.Type);
            Assert.NotNull(result.ContainerImageNames);
            Assert.Single(result.ContainerImageNames);
            Assert.Equal("docker.io/library/alpine:latest", result.ContainerImageNames.First());
            Assert.NotNull(result.ContainerRegistries);
            Assert.Empty(result.ContainerRegistries);
        }

        [Fact]
        public void ToMgmtContainerConfiguration_WithMultipleRegistries_ReturnsCorrectMapping()
        {
            // Arrange
            var psRegistry1 = new PSContainerRegistry(
                userName: "user1",
                password: "pass1",
                registryServer: "registry1.azurecr.io");

            var psRegistry2 = new PSContainerRegistry(
                userName: "user2",
                password: "pass2",
                registryServer: "registry2.azurecr.io");

            var psContainerConfig = new PSContainerConfiguration
            {
                Type = "DockerCompatible",
                ContainerImageNames = new List<string> { "registry1.azurecr.io/myapp:v1", "registry2.azurecr.io/myapp:v2" },
                ContainerRegistries = new List<PSContainerRegistry> { psRegistry1, psRegistry2 }
            };

            // Act
            var result = psContainerConfig.toMgmtContainerConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("DockerCompatible", result.Type);
            Assert.NotNull(result.ContainerImageNames);
            Assert.Equal(2, result.ContainerImageNames.Count);
            Assert.NotNull(result.ContainerRegistries);
            Assert.Equal(2, result.ContainerRegistries.Count);
            
            var registryServers = result.ContainerRegistries.Select(r => r.RegistryServer).ToList();
            Assert.Contains("registry1.azurecr.io", registryServers);
            Assert.Contains("registry2.azurecr.io", registryServers);
        }

        [Fact]
        public void ToMgmtContainerConfiguration_WithNullContainerImageNames_ReturnsNullImageNames()
        {
            // Arrange
            var psContainerConfig = new PSContainerConfiguration
            {
                Type = "DockerCompatible",
                ContainerImageNames = null,
                ContainerRegistries = new List<PSContainerRegistry>()
            };

            // Act
            var result = psContainerConfig.toMgmtContainerConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("DockerCompatible", result.Type);
            Assert.Null(result.ContainerImageNames);
            Assert.NotNull(result.ContainerRegistries);
            Assert.Empty(result.ContainerRegistries);
        }

        [Fact]
        public void ToMgmtContainerConfiguration_WithNullContainerRegistries_ReturnsEmptyRegistries()
        {
            // Arrange
            var psContainerConfig = new PSContainerConfiguration
            {
                Type = "DockerCompatible",
                ContainerImageNames = new List<string> { "ubuntu:20.04" },
                ContainerRegistries = null
            };

            // Act
            var result = psContainerConfig.toMgmtContainerConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("DockerCompatible", result.Type);
            Assert.NotNull(result.ContainerImageNames);
            Assert.Single(result.ContainerImageNames);
            Assert.Null(result.ContainerRegistries);
        }

        [Theory]
        [InlineData("DockerCompatible")]
        [InlineData("CriCompatible")]
        public void ToMgmtContainerConfiguration_VariousContainerTypes_ReturnsCorrectMapping(string containerType)
        {
            // Arrange
            var psContainerConfig = new PSContainerConfiguration
            {
                Type = containerType,
                ContainerImageNames = new List<string> { "test:image" },
                ContainerRegistries = new List<PSContainerRegistry>()
            };

            // Act
            var result = psContainerConfig.toMgmtContainerConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(containerType, result.Type);
            Assert.NotNull(result.ContainerImageNames);
            Assert.Single(result.ContainerImageNames);
            Assert.Equal("test:image", result.ContainerImageNames.First());
        }

        [Fact]
        public void ToMgmtContainerConfiguration_AlwaysCreatesNewInstance()
        {
            // Arrange
            var psContainerConfig = new PSContainerConfiguration
            {
                Type = "DockerCompatible",
                ContainerImageNames = new List<string> { "ubuntu:20.04" },
                ContainerRegistries = new List<PSContainerRegistry>()
            };

            // Act
            var result1 = psContainerConfig.toMgmtContainerConfiguration();
            var result2 = psContainerConfig.toMgmtContainerConfiguration();

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void ToMgmtContainerConfiguration_VerifyContainerConfigurationType()
        {
            // Arrange
            var psContainerConfig = new PSContainerConfiguration
            {
                Type = "DockerCompatible",
                ContainerImageNames = new List<string> { "ubuntu:20.04" },
                ContainerRegistries = new List<PSContainerRegistry>()
            };

            // Act
            var result = psContainerConfig.toMgmtContainerConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ContainerConfiguration>(result);
        }

        #endregion

        #region fromMgmtContainerConfiguration Tests

        [Fact]
        public void FromMgmtContainerConfiguration_WithAllProperties_ReturnsCorrectMapping()
        {
            // Arrange
            var identityResourceId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity";
            var mgmtIdentityRef = new ComputeNodeIdentityReference(identityResourceId);
            var mgmtRegistry = new ContainerRegistry(
                userName: "testuser",
                password: "testpass",
                registryServer: "myregistry.azurecr.io",
                identityReference: mgmtIdentityRef);

            var mgmtContainerConfig = new ContainerConfiguration(
                type: "DockerCompatible",
                containerImageNames: new List<string> { "ubuntu:20.04", "nginx:alpine" },
                containerRegistries: new List<ContainerRegistry> { mgmtRegistry });

            // Act
            var psContainerConfig = new PSContainerConfiguration();
            var result = PSContainerConfiguration.fromMgmtContainerConfiguration(mgmtContainerConfig);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("DockerCompatible", result.Type);
            Assert.NotNull(result.ContainerImageNames);
            Assert.Equal(2, result.ContainerImageNames.Count);
            Assert.Contains("ubuntu:20.04", result.ContainerImageNames);
            Assert.Contains("nginx:alpine", result.ContainerImageNames);
            Assert.NotNull(result.ContainerRegistries);
            Assert.Single(result.ContainerRegistries);
            Assert.Equal("testuser", result.ContainerRegistries.First().UserName);
            Assert.Equal("myregistry.azurecr.io", result.ContainerRegistries.First().RegistryServer);
        }

        [Fact]
        public void FromMgmtContainerConfiguration_WithDockerCompatible_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtContainerConfig = new ContainerConfiguration(
                type: "DockerCompatible",
                containerImageNames: new List<string> { "mcr.microsoft.com/dotnet/runtime:6.0" },
                containerRegistries: new List<ContainerRegistry>());

            // Act
            var psContainerConfig = new PSContainerConfiguration();
            var result = PSContainerConfiguration.fromMgmtContainerConfiguration(mgmtContainerConfig);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("DockerCompatible", result.Type);
            Assert.NotNull(result.ContainerImageNames);
            Assert.Single(result.ContainerImageNames);
            Assert.Equal("mcr.microsoft.com/dotnet/runtime:6.0", result.ContainerImageNames.First());
            Assert.NotNull(result.ContainerRegistries);
            Assert.Empty(result.ContainerRegistries);
        }

        [Fact]
        public void FromMgmtContainerConfiguration_WithCriCompatible_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtContainerConfig = new ContainerConfiguration(
                type: "CriCompatible",
                containerImageNames: new List<string> { "docker.io/library/alpine:latest" },
                containerRegistries: new List<ContainerRegistry>());

            // Act
            var psContainerConfig = new PSContainerConfiguration();
            var result = PSContainerConfiguration.fromMgmtContainerConfiguration(mgmtContainerConfig);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("CriCompatible", result.Type);
            Assert.NotNull(result.ContainerImageNames);
            Assert.Single(result.ContainerImageNames);
            Assert.Equal("docker.io/library/alpine:latest", result.ContainerImageNames.First());
            Assert.NotNull(result.ContainerRegistries);
            Assert.Empty(result.ContainerRegistries);
        }

        [Fact]
        public void FromMgmtContainerConfiguration_WithNullMgmtConfiguration_ReturnsNull()
        {
            // Act
            var psContainerConfig = new PSContainerConfiguration();
            var result = PSContainerConfiguration.fromMgmtContainerConfiguration(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FromMgmtContainerConfiguration_WithMultipleRegistries_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtRegistry1 = new ContainerRegistry(
                userName: "user1",
                password: "pass1",
                registryServer: "registry1.azurecr.io");

            var mgmtRegistry2 = new ContainerRegistry(
                userName: "user2",
                password: "pass2",
                registryServer: "registry2.azurecr.io");

            var mgmtContainerConfig = new ContainerConfiguration(
                type: "DockerCompatible",
                containerImageNames: new List<string> { "registry1.azurecr.io/myapp:v1", "registry2.azurecr.io/myapp:v2" },
                containerRegistries: new List<ContainerRegistry> { mgmtRegistry1, mgmtRegistry2 });

            // Act
            var psContainerConfig = new PSContainerConfiguration();
            var result = PSContainerConfiguration.fromMgmtContainerConfiguration(mgmtContainerConfig);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("DockerCompatible", result.Type);
            Assert.NotNull(result.ContainerImageNames);
            Assert.Equal(2, result.ContainerImageNames.Count);
            Assert.NotNull(result.ContainerRegistries);
            Assert.Equal(2, result.ContainerRegistries.Count);
            
            var registryServers = result.ContainerRegistries.Select(r => r.RegistryServer).ToList();
            Assert.Contains("registry1.azurecr.io", registryServers);
            Assert.Contains("registry2.azurecr.io", registryServers);
        }

        [Fact]
        public void FromMgmtContainerConfiguration_WithNullContainerImageNames_ReturnsNullImageNames()
        {
            // Arrange
            var mgmtContainerConfig = new ContainerConfiguration(
                type: "DockerCompatible",
                containerImageNames: null,
                containerRegistries: new List<ContainerRegistry>());

            // Act
            var psContainerConfig = new PSContainerConfiguration();
            var result = PSContainerConfiguration.fromMgmtContainerConfiguration(mgmtContainerConfig);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("DockerCompatible", result.Type);
            Assert.Null(result.ContainerImageNames);
            Assert.NotNull(result.ContainerRegistries);
            Assert.Empty(result.ContainerRegistries);
        }

        [Fact]
        public void FromMgmtContainerConfiguration_WithNullContainerRegistries_ReturnsNullRegistries()
        {
            // Arrange
            var mgmtContainerConfig = new ContainerConfiguration(
                type: "DockerCompatible",
                containerImageNames: new List<string> { "ubuntu:20.04" },
                containerRegistries: null);

            // Act
            var psContainerConfig = new PSContainerConfiguration();
            var result = PSContainerConfiguration.fromMgmtContainerConfiguration(mgmtContainerConfig);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("DockerCompatible", result.Type);
            Assert.NotNull(result.ContainerImageNames);
            Assert.Single(result.ContainerImageNames);
            Assert.Null(result.ContainerRegistries);
        }

        [Theory]
        [InlineData("DockerCompatible")]
        [InlineData("CriCompatible")]
        public void FromMgmtContainerConfiguration_VariousContainerTypes_ReturnsCorrectMapping(string containerType)
        {
            // Arrange
            var mgmtContainerConfig = new ContainerConfiguration(
                type: containerType,
                containerImageNames: new List<string> { "test:image" },
                containerRegistries: new List<ContainerRegistry>());

            // Act
            var psContainerConfig = new PSContainerConfiguration();
            var result = PSContainerConfiguration.fromMgmtContainerConfiguration(mgmtContainerConfig);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(containerType, result.Type);
            Assert.NotNull(result.ContainerImageNames);
            Assert.Single(result.ContainerImageNames);
            Assert.Equal("test:image", result.ContainerImageNames.First());
        }

        [Fact]
        public void FromMgmtContainerConfiguration_AlwaysCreatesNewInstance()
        {
            // Arrange
            var mgmtContainerConfig = new ContainerConfiguration(
                type: "DockerCompatible",
                containerImageNames: new List<string> { "ubuntu:20.04" },
                containerRegistries: new List<ContainerRegistry>());

            // Act
            var psContainerConfig = new PSContainerConfiguration();
            var result1 = PSContainerConfiguration.fromMgmtContainerConfiguration(mgmtContainerConfig);
            var result2 = PSContainerConfiguration.fromMgmtContainerConfiguration(mgmtContainerConfig);

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void FromMgmtContainerConfiguration_VerifyPSContainerConfigurationType()
        {
            // Arrange
            var mgmtContainerConfig = new ContainerConfiguration(
                type: "DockerCompatible",
                containerImageNames: new List<string> { "ubuntu:20.04" },
                containerRegistries: new List<ContainerRegistry>());

            // Act
            var psContainerConfig = new PSContainerConfiguration();
            var result = PSContainerConfiguration.fromMgmtContainerConfiguration(mgmtContainerConfig);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PSContainerConfiguration>(result);
        }

        [Fact]
        public void FromMgmtContainerConfiguration_WithDefaultConstructor_HandlesCorrectly()
        {
            // Arrange
            var mgmtContainerConfig = new ContainerConfiguration(); // Uses default constructor
            mgmtContainerConfig.Type = "DockerCompatible";
            mgmtContainerConfig.ContainerImageNames = new List<string> { "ubuntu:latest" };

            // Act
            var psContainerConfig = new PSContainerConfiguration();
            var result = PSContainerConfiguration.fromMgmtContainerConfiguration(mgmtContainerConfig);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("DockerCompatible", result.Type);
            Assert.NotNull(result.ContainerImageNames);
            Assert.Single(result.ContainerImageNames);
            Assert.Equal("ubuntu:latest", result.ContainerImageNames.First());
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesAllProperties()
        {
            // Arrange
            var identityResourceId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity";
            var originalIdentityRef = new PSComputeNodeIdentityReference { ResourceId = identityResourceId };
            var originalRegistry = new PSContainerRegistry(
                userName: "testuser",
                password: "testpass",
                registryServer: "myregistry.azurecr.io",
                identityReference: originalIdentityRef);

            var originalPsContainerConfig = new PSContainerConfiguration
            {
                Type = "DockerCompatible",
                ContainerImageNames = new List<string> { "ubuntu:20.04", "nginx:alpine", "postgres:13" },
                ContainerRegistries = new List<PSContainerRegistry> { originalRegistry }
            };

            // Act
            var mgmtContainerConfig = originalPsContainerConfig.toMgmtContainerConfiguration();
            var psContainerConfig = new PSContainerConfiguration();
            var roundTripPsContainerConfig = PSContainerConfiguration.fromMgmtContainerConfiguration(mgmtContainerConfig);

            // Assert
            Assert.NotNull(roundTripPsContainerConfig);
            Assert.Equal(originalPsContainerConfig.Type, roundTripPsContainerConfig.Type);
            Assert.Equal(originalPsContainerConfig.ContainerImageNames.Count, roundTripPsContainerConfig.ContainerImageNames.Count);
            
            foreach (var imageName in originalPsContainerConfig.ContainerImageNames)
            {
                Assert.Contains(imageName, roundTripPsContainerConfig.ContainerImageNames);
            }
            
            Assert.Equal(originalPsContainerConfig.ContainerRegistries.Count, roundTripPsContainerConfig.ContainerRegistries.Count);
            Assert.Equal(originalPsContainerConfig.ContainerRegistries.First().UserName, 
                         roundTripPsContainerConfig.ContainerRegistries.First().UserName);
            Assert.Equal(originalPsContainerConfig.ContainerRegistries.First().RegistryServer, 
                         roundTripPsContainerConfig.ContainerRegistries.First().RegistryServer);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesMinimalProperties()
        {
            // Arrange
            var originalPsContainerConfig = new PSContainerConfiguration
            {
                Type = "CriCompatible",
                ContainerImageNames = new List<string> { "alpine:latest" },
                ContainerRegistries = new List<PSContainerRegistry>()
            };

            // Act
            var mgmtContainerConfig = originalPsContainerConfig.toMgmtContainerConfiguration();
            var psContainerConfig = new PSContainerConfiguration();
            var roundTripPsContainerConfig = PSContainerConfiguration.fromMgmtContainerConfiguration(mgmtContainerConfig);

            // Assert
            Assert.NotNull(roundTripPsContainerConfig);
            Assert.Equal(originalPsContainerConfig.Type, roundTripPsContainerConfig.Type);
            Assert.Equal(originalPsContainerConfig.ContainerImageNames.Count, roundTripPsContainerConfig.ContainerImageNames.Count);
            Assert.Equal(originalPsContainerConfig.ContainerImageNames.First(), roundTripPsContainerConfig.ContainerImageNames.First());
            Assert.Equal(originalPsContainerConfig.ContainerRegistries.Count, roundTripPsContainerConfig.ContainerRegistries.Count);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesNullValues()
        {
            // Arrange
            var originalPsContainerConfig = new PSContainerConfiguration
            {
                Type = "DockerCompatible",
                ContainerImageNames = null,
                ContainerRegistries = null
            };

            // Act
            var mgmtContainerConfig = originalPsContainerConfig.toMgmtContainerConfiguration();
            var psContainerConfig = new PSContainerConfiguration();
            var roundTripPsContainerConfig = PSContainerConfiguration.fromMgmtContainerConfiguration(mgmtContainerConfig);

            // Assert
            Assert.NotNull(roundTripPsContainerConfig);
            Assert.Equal(originalPsContainerConfig.Type, roundTripPsContainerConfig.Type);
            Assert.Null(roundTripPsContainerConfig.ContainerImageNames);
            Assert.Null(roundTripPsContainerConfig.ContainerRegistries);
        }

        [Theory]
        [InlineData("DockerCompatible")]
        [InlineData("CriCompatible")]
        public void RoundTripConversion_AllValidTypes_PreservesOriginalValue(string containerType)
        {
            // Arrange
            var originalPsContainerConfig = new PSContainerConfiguration
            {
                Type = containerType,
                ContainerImageNames = new List<string> { "test:image" },
                ContainerRegistries = new List<PSContainerRegistry>()
            };

            // Act
            var mgmtContainerConfig = originalPsContainerConfig.toMgmtContainerConfiguration();
            var psContainerConfig = new PSContainerConfiguration();
            var roundTripPsContainerConfig = PSContainerConfiguration.fromMgmtContainerConfiguration(mgmtContainerConfig);

            // Assert
            Assert.NotNull(roundTripPsContainerConfig);
            Assert.Equal(originalPsContainerConfig.Type, roundTripPsContainerConfig.Type);
            Assert.Equal(originalPsContainerConfig.ContainerImageNames.First(), roundTripPsContainerConfig.ContainerImageNames.First());
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesValues()
        {
            // Arrange
            var identityResourceId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity";
            var originalIdentityRef = new ComputeNodeIdentityReference(identityResourceId);
            var originalRegistry = new ContainerRegistry(
                userName: "testuser",
                password: "testpass",
                registryServer: "myregistry.azurecr.io",
                identityReference: originalIdentityRef);

            var originalMgmtContainerConfig = new ContainerConfiguration(
                type: "DockerCompatible",
                containerImageNames: new List<string> { "ubuntu:20.04", "nginx:alpine" },
                containerRegistries: new List<ContainerRegistry> { originalRegistry });

            // Act
            var psContainerConfig = new PSContainerConfiguration();
            var convertedPsContainerConfig = PSContainerConfiguration.fromMgmtContainerConfiguration(originalMgmtContainerConfig);
            var roundTripMgmtContainerConfig = convertedPsContainerConfig.toMgmtContainerConfiguration();

            // Assert
            Assert.NotNull(roundTripMgmtContainerConfig);
            Assert.Equal(originalMgmtContainerConfig.Type, roundTripMgmtContainerConfig.Type);
            Assert.Equal(originalMgmtContainerConfig.ContainerImageNames.Count, roundTripMgmtContainerConfig.ContainerImageNames.Count);
            
            foreach (var imageName in originalMgmtContainerConfig.ContainerImageNames)
            {
                Assert.Contains(imageName, roundTripMgmtContainerConfig.ContainerImageNames);
            }
            
            Assert.Equal(originalMgmtContainerConfig.ContainerRegistries.Count, roundTripMgmtContainerConfig.ContainerRegistries.Count);
            Assert.Equal(originalMgmtContainerConfig.ContainerRegistries.First().UserName, 
                         roundTripMgmtContainerConfig.ContainerRegistries.First().UserName);
            Assert.Equal(originalMgmtContainerConfig.ContainerRegistries.First().RegistryServer, 
                         roundTripMgmtContainerConfig.ContainerRegistries.First().RegistryServer);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void ContainerConfigurationConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Arrange - Test with realistic container configuration scenario
            var identityResourceId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/batch-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/container-identity";
            var psIdentityRef = new PSComputeNodeIdentityReference { ResourceId = identityResourceId };
            var psRegistry = new PSContainerRegistry(
                userName: "batchuser",
                password: "batchpass",
                registryServer: "batchregistry.azurecr.io",
                identityReference: psIdentityRef);

            var psContainerConfig = new PSContainerConfiguration
            {
                Type = "DockerCompatible",
                ContainerImageNames = new List<string> 
                { 
                    "mcr.microsoft.com/dotnet/runtime:6.0",
                    "batchregistry.azurecr.io/myapp:latest",
                    "docker.io/library/ubuntu:20.04"
                },
                ContainerRegistries = new List<PSContainerRegistry> { psRegistry }
            };

            // Act
            var mgmtContainerConfig = psContainerConfig.toMgmtContainerConfiguration();
            var psContainerConfigInstance = new PSContainerConfiguration();
            var backToPs = PSContainerConfiguration.fromMgmtContainerConfiguration(mgmtContainerConfig);

            // Assert
            Assert.NotNull(mgmtContainerConfig);
            Assert.Equal("DockerCompatible", mgmtContainerConfig.Type);
            Assert.Equal(3, mgmtContainerConfig.ContainerImageNames.Count);
            Assert.Single(mgmtContainerConfig.ContainerRegistries);
            Assert.Equal("batchregistry.azurecr.io", mgmtContainerConfig.ContainerRegistries.First().RegistryServer);

            Assert.NotNull(backToPs);
            Assert.Equal("DockerCompatible", backToPs.Type);
            Assert.Equal(3, backToPs.ContainerImageNames.Count);
            Assert.Single(backToPs.ContainerRegistries);
            Assert.Equal("batchregistry.azurecr.io", backToPs.ContainerRegistries.First().RegistryServer);
        }

        [Fact]
        public void ContainerConfigurationConversions_NullHandling_WorksCorrectly()
        {
            // Test null handling in conversions

            // Act
            var psContainerConfig = new PSContainerConfiguration();
            var resultFromNull = PSContainerConfiguration.fromMgmtContainerConfiguration(null);

            // Assert
            Assert.Null(resultFromNull);
        }

        [Fact]
        public void ContainerConfigurationConversions_BatchPoolContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Batch pool configuration
            // ContainerConfiguration is used to configure container support for Batch pool compute nodes

            // Arrange - Test with different container configuration scenarios
            var scenarios = new[]
            {
                // Docker workload with private registry
                new {
                    Type = "DockerCompatible",
                    ImageNames = new List<string> { "myregistry.azurecr.io/myapp:v1.0", "nginx:alpine" },
                    HasRegistry = true,
                    Description = "Docker workload with private Azure Container Registry"
                },
                // Docker workload with public images only
                new {
                    Type = "DockerCompatible",
                    ImageNames = new List<string> { "ubuntu:20.04", "mcr.microsoft.com/dotnet/runtime:6.0" },
                    HasRegistry = false,
                    Description = "Docker workload with public images from Docker Hub and MCR"
                },
                // CRI-compatible workload
                new {
                    Type = "CriCompatible",
                    ImageNames = new List<string> { "docker.io/library/alpine:latest" },
                    HasRegistry = false,
                    Description = "CRI-compatible workload for Kubernetes-style containers"
                },
                // Single container workload
                new {
                    Type = "DockerCompatible",
                    ImageNames = new List<string> { "postgres:13" },
                    HasRegistry = false,
                    Description = "Single container database workload"
                }
            };

            foreach (var scenario in scenarios)
            {
                // Arrange
                var psContainerRegistries = scenario.HasRegistry 
                    ? new List<PSContainerRegistry> 
                    { 
                        new PSContainerRegistry(
                            userName: "testuser", 
                            password: "testpass", 
                            registryServer: "myregistry.azurecr.io") 
                    }
                    : new List<PSContainerRegistry>();

                var psContainerConfig = new PSContainerConfiguration
                {
                    Type = scenario.Type,
                    ContainerImageNames = scenario.ImageNames,
                    ContainerRegistries = psContainerRegistries
                };

                // Act
                var mgmtContainerConfig = psContainerConfig.toMgmtContainerConfiguration();

                // Assert - Should convert correctly for Batch pool configuration
                Assert.NotNull(mgmtContainerConfig);
                Assert.Equal(scenario.Type, mgmtContainerConfig.Type);
                Assert.Equal(scenario.ImageNames.Count, mgmtContainerConfig.ContainerImageNames.Count);
                
                foreach (var imageName in scenario.ImageNames)
                {
                    Assert.Contains(imageName, mgmtContainerConfig.ContainerImageNames);
                }
                
                Assert.Equal(psContainerRegistries.Count, mgmtContainerConfig.ContainerRegistries.Count);

                // Verify round-trip conversion maintains container configuration semantics
                var psContainerConfigInstance = new PSContainerConfiguration();
                var backToPs = PSContainerConfiguration.fromMgmtContainerConfiguration(mgmtContainerConfig);
                Assert.NotNull(backToPs);
                Assert.Equal(scenario.Type, backToPs.Type);
                Assert.Equal(scenario.ImageNames.Count, backToPs.ContainerImageNames.Count);
                
                foreach (var imageName in scenario.ImageNames)
                {
                    Assert.Contains(imageName, backToPs.ContainerImageNames);
                }
                
                Assert.Equal(psContainerRegistries.Count, backToPs.ContainerRegistries.Count);
            }
        }

        [Fact]
        public void ContainerConfigurationConversions_InstanceCreation_VerifyBehavior()
        {
            // This test verifies that the conversion methods create appropriate instances

            // Arrange
            var identityResourceId = "/subscriptions/test/resourceGroups/test/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test";
            var psIdentityRef = new PSComputeNodeIdentityReference { ResourceId = identityResourceId };
            var psRegistry = new PSContainerRegistry(
                userName: "testuser",
                password: "testpass",
                registryServer: "test.azurecr.io",
                identityReference: psIdentityRef);

            var psContainerConfig = new PSContainerConfiguration
            {
                Type = "DockerCompatible",
                ContainerImageNames = new List<string> { "ubuntu:20.04" },
                ContainerRegistries = new List<PSContainerRegistry> { psRegistry }
            };

            var mgmtIdentityRef = new ComputeNodeIdentityReference(identityResourceId);
            var mgmtRegistry = new ContainerRegistry(
                userName: "testuser",
                password: "testpass",
                registryServer: "test.azurecr.io",
                identityReference: mgmtIdentityRef);

            var mgmtContainerConfig = new ContainerConfiguration(
                type: "DockerCompatible",
                containerImageNames: new List<string> { "ubuntu:20.04" },
                containerRegistries: new List<ContainerRegistry> { mgmtRegistry });

            // Act
            var mgmtResult = psContainerConfig.toMgmtContainerConfiguration();
            var psContainerConfigInstance = new PSContainerConfiguration();
            var psResult = PSContainerConfiguration.fromMgmtContainerConfiguration(mgmtContainerConfig);

            // Assert - Verify proper instance creation
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.IsType<ContainerConfiguration>(mgmtResult);
            Assert.IsType<PSContainerConfiguration>(psResult);

            // Verify new instances are created
            Assert.NotSame(mgmtContainerConfig, mgmtResult);
            Assert.NotSame(psContainerConfig, psResult);
        }

        #endregion

        #region Performance and Edge Case Tests

        [Fact]
        public void ContainerConfigurationConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient

            // Arrange
            var identityResourceId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/test/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test";
            var psIdentityRef = new PSComputeNodeIdentityReference { ResourceId = identityResourceId };
            var psRegistry = new PSContainerRegistry(
                userName: "testuser",
                password: "testpass",
                registryServer: "test.azurecr.io",
                identityReference: psIdentityRef);

            var psContainerConfig = new PSContainerConfiguration
            {
                Type = "DockerCompatible",
                ContainerImageNames = new List<string> { "ubuntu:20.04", "nginx:alpine" },
                ContainerRegistries = new List<PSContainerRegistry> { psRegistry }
            };

            var mgmtIdentityRef = new ComputeNodeIdentityReference(identityResourceId);
            var mgmtRegistry = new ContainerRegistry(
                userName: "testuser",
                password: "testpass",
                registryServer: "test.azurecr.io",
                identityReference: mgmtIdentityRef);

            var mgmtContainerConfig = new ContainerConfiguration(
                type: "DockerCompatible",
                containerImageNames: new List<string> { "ubuntu:20.04", "nginx:alpine" },
                containerRegistries: new List<ContainerRegistry> { mgmtRegistry });

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 100; i++)
            {
                var mgmtResult = psContainerConfig.toMgmtContainerConfiguration();
                var psContainerConfigInstance = new PSContainerConfiguration();
                var psResult = PSContainerConfiguration.fromMgmtContainerConfiguration(mgmtContainerConfig);

                Assert.NotNull(mgmtResult);
                Assert.NotNull(psResult);
                Assert.Equal("DockerCompatible", mgmtResult.Type);
                Assert.Equal("DockerCompatible", psResult.Type);
            }
        }

        [Fact]
        public void ContainerConfigurationConversions_DefaultAndNullValues_HandleCorrectly()
        {
            // Test conversion with default and null values

            // Scenario 1: Default PS constructor
            var defaultPsContainerConfig = new PSContainerConfiguration
            {
                Type = "DockerCompatible"
                // Other properties use default values (null)
            };

            var mgmtFromDefault = defaultPsContainerConfig.toMgmtContainerConfiguration();
            Assert.NotNull(mgmtFromDefault);
            Assert.Equal("DockerCompatible", mgmtFromDefault.Type);
            Assert.Null(mgmtFromDefault.ContainerImageNames);
            Assert.Null(mgmtFromDefault.ContainerRegistries);

            // Scenario 2: Default management constructor
            var defaultMgmtContainerConfig = new ContainerConfiguration();
            defaultMgmtContainerConfig.Type = "CriCompatible";

            var psContainerConfigInstance = new PSContainerConfiguration();
            var psFromDefault = PSContainerConfiguration.fromMgmtContainerConfiguration(defaultMgmtContainerConfig);
            Assert.NotNull(psFromDefault);
            Assert.Equal("CriCompatible", psFromDefault.Type);
            Assert.Null(psFromDefault.ContainerImageNames);
            Assert.Null(psFromDefault.ContainerRegistries);

            // Scenario 3: Explicit null values
            var nullValuesPsContainerConfig = new PSContainerConfiguration
            {
                Type = "DockerCompatible",
                ContainerImageNames = null,
                ContainerRegistries = null
            };

            var mgmtNullValuesResult = nullValuesPsContainerConfig.toMgmtContainerConfiguration();
            Assert.NotNull(mgmtNullValuesResult);
            Assert.Equal("DockerCompatible", mgmtNullValuesResult.Type);
            Assert.Null(mgmtNullValuesResult.ContainerImageNames);
            Assert.Null(mgmtNullValuesResult.ContainerRegistries);

            var roundTripNullValues = PSContainerConfiguration.fromMgmtContainerConfiguration(mgmtNullValuesResult);
            Assert.NotNull(roundTripNullValues);
            Assert.Equal("DockerCompatible", roundTripNullValues.Type);
            Assert.Null(roundTripNullValues.ContainerImageNames);
            Assert.Null(roundTripNullValues.ContainerRegistries);
        }

        [Fact]
        public void ContainerConfigurationConversions_ContainerTypeSemantics_VerifyCorrectness()
        {
            // This test validates the semantic meaning of different container types

            var containerTypeScenarios = new[]
            {
                new {
                    Type = "DockerCompatible",
                    Description = "Docker-compatible containers using standard Docker runtime",
                    TypicalImages = new[] { "ubuntu:20.04", "nginx:alpine", "postgres:13" },
                    UseCases = new[] { "Standard containerized applications", "Docker Compose workloads", "Legacy Docker applications" }
                },
                new {
                    Type = "CriCompatible",
                    Description = "CRI-compatible containers for Kubernetes-style orchestration",
                    TypicalImages = new[] { "docker.io/library/alpine:latest", "k8s.gcr.io/pause:3.5" },
                    UseCases = new[] { "Kubernetes workloads", "CRI-O runtime", "containerd runtime" }
                }
            };

            foreach (var scenario in containerTypeScenarios)
            {
                // Act - Convert configuration with specific container type
                var psContainerConfig = new PSContainerConfiguration
                {
                    Type = scenario.Type,
                    ContainerImageNames = scenario.TypicalImages.ToList(),
                    ContainerRegistries = new List<PSContainerRegistry>()
                };

                var mgmtContainerConfig = psContainerConfig.toMgmtContainerConfiguration();
                var psContainerConfigInstance = new PSContainerConfiguration();
                var roundTripContainerConfig = PSContainerConfiguration.fromMgmtContainerConfiguration(mgmtContainerConfig);

                // Assert - Container type semantics should be preserved
                Assert.NotNull(mgmtContainerConfig);
                Assert.NotNull(roundTripContainerConfig);
                Assert.Equal(scenario.Type, mgmtContainerConfig.Type);
                Assert.Equal(scenario.Type, roundTripContainerConfig.Type);

                // Verify image names are preserved
                Assert.Equal(scenario.TypicalImages.Length, mgmtContainerConfig.ContainerImageNames.Count);
                Assert.Equal(scenario.TypicalImages.Length, roundTripContainerConfig.ContainerImageNames.Count);
                
                foreach (var image in scenario.TypicalImages)
                {
                    Assert.Contains(image, mgmtContainerConfig.ContainerImageNames);
                    Assert.Contains(image, roundTripContainerConfig.ContainerImageNames);
                }
            }
        }

        #endregion
    }
}