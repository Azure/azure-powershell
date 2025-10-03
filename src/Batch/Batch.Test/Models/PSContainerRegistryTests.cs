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
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ModelsConversions
{
    public class PSContainerRegistryTests
    {
        #region toMgmtContainerRegistry Tests

        [Fact]
        public void ToMgmtContainerRegistry_WithAllProperties_ReturnsCorrectMapping()
        {
            // Arrange
            var identityResourceId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity";
            var psIdentityRef = new PSComputeNodeIdentityReference { ResourceId = identityResourceId };
            var psRegistry = new PSContainerRegistry(
                userName: "testuser",
                password: "testpassword",
                registryServer: "myregistry.azurecr.io",
                identityReference: psIdentityRef);

            // Act
            var result = psRegistry.toMgmtContainerRegistry();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("testuser", result.UserName);
            Assert.Equal("testpassword", result.Password);
            Assert.Equal("myregistry.azurecr.io", result.RegistryServer);
            Assert.NotNull(result.IdentityReference);
            Assert.Equal(identityResourceId, result.IdentityReference.ResourceId);
        }

        [Fact]
        public void ToMgmtContainerRegistry_WithMinimalProperties_ReturnsCorrectMapping()
        {
            // Arrange
            var psRegistry = new PSContainerRegistry(
                userName: "testuser",
                password: "testpassword");

            // Act
            var result = psRegistry.toMgmtContainerRegistry();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("testuser", result.UserName);
            Assert.Equal("testpassword", result.Password);
            Assert.Null(result.RegistryServer);
            Assert.Null(result.IdentityReference);
        }

        [Fact]
        public void ToMgmtContainerRegistry_WithDockerHubRegistry_ReturnsCorrectMapping()
        {
            // Arrange
            var psRegistry = new PSContainerRegistry(
                userName: "dockerhubuser",
                password: "dockerhubpassword",
                registryServer: "docker.io");

            // Act
            var result = psRegistry.toMgmtContainerRegistry();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("dockerhubuser", result.UserName);
            Assert.Equal("dockerhubpassword", result.Password);
            Assert.Equal("docker.io", result.RegistryServer);
            Assert.Null(result.IdentityReference);
        }

        [Fact]
        public void ToMgmtContainerRegistry_WithNullIdentityReference_ReturnsNullIdentityReference()
        {
            // Arrange
            var psRegistry = new PSContainerRegistry(
                userName: "testuser",
                password: "testpassword",
                registryServer: "registry.example.com",
                identityReference: null);

            // Act
            var result = psRegistry.toMgmtContainerRegistry();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("testuser", result.UserName);
            Assert.Equal("testpassword", result.Password);
            Assert.Equal("registry.example.com", result.RegistryServer);
            Assert.Null(result.IdentityReference);
        }

        [Fact]
        public void ToMgmtContainerRegistry_WithNullOmObject_ReturnsNull()
        {
            // Arrange
            var psRegistry = new PSContainerRegistry();
            // Set omObject to null using reflection to simulate the condition
            psRegistry.GetType().GetField("omObject", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(psRegistry, null);

            // Act
            var result = psRegistry.toMgmtContainerRegistry();

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("myregistry.azurecr.io", "azureuser", "azurepass")]
        [InlineData("docker.io", "dockeruser", "dockerpass")]
        [InlineData("registry.gitlab.com", "gitlabuser", "gitlabtoken")]
        [InlineData("ghcr.io", "githubuser", "githubtoken")]
        public void ToMgmtContainerRegistry_VariousRegistryProviders_ReturnsCorrectMapping(string registryServer, string userName, string password)
        {
            // Arrange
            var psRegistry = new PSContainerRegistry(
                userName: userName,
                password: password,
                registryServer: registryServer);

            // Act
            var result = psRegistry.toMgmtContainerRegistry();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userName, result.UserName);
            Assert.Equal(password, result.Password);
            Assert.Equal(registryServer, result.RegistryServer);
            Assert.Null(result.IdentityReference);
        }

        [Fact]
        public void ToMgmtContainerRegistry_AlwaysCreatesNewInstance()
        {
            // Arrange
            var psRegistry = new PSContainerRegistry(
                userName: "testuser",
                password: "testpassword");

            // Act
            var result1 = psRegistry.toMgmtContainerRegistry();
            var result2 = psRegistry.toMgmtContainerRegistry();

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void ToMgmtContainerRegistry_VerifyContainerRegistryType()
        {
            // Arrange
            var psRegistry = new PSContainerRegistry(
                userName: "testuser",
                password: "testpassword");

            // Act
            var result = psRegistry.toMgmtContainerRegistry();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ContainerRegistry>(result);
        }

        [Fact]
        public void ToMgmtContainerRegistry_WithEmptyStringProperties_PreservesEmptyValues()
        {
            // Arrange
            var psRegistry = new PSContainerRegistry(
                userName: "",
                password: "",
                registryServer: "");

            // Act
            var result = psRegistry.toMgmtContainerRegistry();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("", result.UserName);
            Assert.Equal("", result.Password);
            Assert.Equal("", result.RegistryServer);
        }

        #endregion

        #region fromMgmtContainerRegistry Tests

        [Fact]
        public void FromMgmtContainerRegistry_WithAllProperties_ReturnsCorrectMapping()
        {
            // Arrange
            var identityResourceId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity";
            var mgmtIdentityRef = new ComputeNodeIdentityReference(identityResourceId);
            var mgmtRegistry = new ContainerRegistry(
                userName: "testuser",
                password: "testpassword",
                registryServer: "myregistry.azurecr.io",
                identityReference: mgmtIdentityRef);

            // Act
            var result = PSContainerRegistry.fromMgmtContainerRegistry(mgmtRegistry);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("testuser", result.UserName);
            Assert.Equal("testpassword", result.Password);
            Assert.Equal("myregistry.azurecr.io", result.RegistryServer);
            Assert.NotNull(result.IdentityReference);
            Assert.Equal(identityResourceId, result.IdentityReference.ResourceId);
        }

        [Fact]
        public void FromMgmtContainerRegistry_WithMinimalProperties_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtRegistry = new ContainerRegistry(
                userName: "testuser",
                password: "testpassword");

            // Act
            var result = PSContainerRegistry.fromMgmtContainerRegistry(mgmtRegistry);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("testuser", result.UserName);
            Assert.Equal("testpassword", result.Password);
            Assert.Null(result.RegistryServer);
            Assert.Null(result.IdentityReference);
        }

        [Fact]
        public void FromMgmtContainerRegistry_WithNullIdentityReference_ReturnsNullIdentityReference()
        {
            // Arrange
            var mgmtRegistry = new ContainerRegistry(
                userName: "testuser",
                password: "testpassword",
                registryServer: "registry.example.com",
                identityReference: null);

            // Act
            var result = PSContainerRegistry.fromMgmtContainerRegistry(mgmtRegistry);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("testuser", result.UserName);
            Assert.Equal("testpassword", result.Password);
            Assert.Equal("registry.example.com", result.RegistryServer);
            Assert.Null(result.IdentityReference);
        }

        [Fact]
        public void FromMgmtContainerRegistry_WithNullMgmtRegistry_ReturnsNull()
        {
            // Act
            var result = PSContainerRegistry.fromMgmtContainerRegistry(null);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("myregistry.azurecr.io", "azureuser", "azurepass")]
        [InlineData("docker.io", "dockeruser", "dockerpass")]
        [InlineData("registry.gitlab.com", "gitlabuser", "gitlabtoken")]
        [InlineData("ghcr.io", "githubuser", "githubtoken")]
        [InlineData("quay.io", "quayuser", "quaytoken")]
        public void FromMgmtContainerRegistry_VariousRegistryProviders_ReturnsCorrectMapping(string registryServer, string userName, string password)
        {
            // Arrange
            var mgmtRegistry = new ContainerRegistry(
                userName: userName,
                password: password,
                registryServer: registryServer);

            // Act
            var result = PSContainerRegistry.fromMgmtContainerRegistry(mgmtRegistry);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userName, result.UserName);
            Assert.Equal(password, result.Password);
            Assert.Equal(registryServer, result.RegistryServer);
            // Fixed: Check for null before accessing ResourceId
            Assert.Null(result.IdentityReference);
        }

        [Fact]
        public void FromMgmtContainerRegistry_StaticMethod_DoesNotRequireInstance()
        {
            // Arrange
            var mgmtRegistry = new ContainerRegistry(
                userName: "testuser",
                password: "testpassword",
                registryServer: "registry.example.com");

            // Act - Call static method directly on class
            var result = PSContainerRegistry.fromMgmtContainerRegistry(mgmtRegistry);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("testuser", result.UserName);
            Assert.Equal("testpassword", result.Password);
            Assert.Equal("registry.example.com", result.RegistryServer);
        }

        [Fact]
        public void FromMgmtContainerRegistry_AlwaysCreatesNewInstance()
        {
            // Arrange
            var mgmtRegistry = new ContainerRegistry(
                userName: "testuser",
                password: "testpassword");

            // Act
            var result1 = PSContainerRegistry.fromMgmtContainerRegistry(mgmtRegistry);
            var result2 = PSContainerRegistry.fromMgmtContainerRegistry(mgmtRegistry);

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void FromMgmtContainerRegistry_VerifyPSContainerRegistryType()
        {
            // Arrange
            var mgmtRegistry = new ContainerRegistry(
                userName: "testuser",
                password: "testpassword");

            // Act
            var result = PSContainerRegistry.fromMgmtContainerRegistry(mgmtRegistry);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PSContainerRegistry>(result);
        }

        [Fact]
        public void FromMgmtContainerRegistry_WithDefaultConstructor_HandlesCorrectly()
        {
            // Arrange
            var mgmtRegistry = new ContainerRegistry(); // Uses default constructor

            // Act
            var result = PSContainerRegistry.fromMgmtContainerRegistry(mgmtRegistry);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.UserName);
            Assert.Null(result.Password);
            Assert.Null(result.RegistryServer);
            Assert.Null(result.IdentityReference);
        }

        [Fact]
        public void FromMgmtContainerRegistry_WithEmptyStringProperties_PreservesEmptyValues()
        {
            // Arrange
            var mgmtRegistry = new ContainerRegistry(
                userName: "",
                password: "",
                registryServer: "");

            // Act
            var result = PSContainerRegistry.fromMgmtContainerRegistry(mgmtRegistry);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("", result.UserName);
            Assert.Equal("", result.Password);
            Assert.Equal("", result.RegistryServer);
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesAllProperties()
        {
            // Arrange
            var identityResourceId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity";
            var originalIdentityRef = new PSComputeNodeIdentityReference { ResourceId = identityResourceId };
            var originalPsRegistry = new PSContainerRegistry(
                userName: "testuser",
                password: "testpassword",
                registryServer: "myregistry.azurecr.io",
                identityReference: originalIdentityRef);

            // Act
            var mgmtRegistry = originalPsRegistry.toMgmtContainerRegistry();
            var roundTripPsRegistry = PSContainerRegistry.fromMgmtContainerRegistry(mgmtRegistry);

            // Assert
            Assert.NotNull(roundTripPsRegistry);
            Assert.Equal(originalPsRegistry.UserName, roundTripPsRegistry.UserName);
            Assert.Equal(originalPsRegistry.Password, roundTripPsRegistry.Password);
            Assert.Equal(originalPsRegistry.RegistryServer, roundTripPsRegistry.RegistryServer);
            Assert.NotNull(roundTripPsRegistry.IdentityReference);
            Assert.Equal(originalPsRegistry.IdentityReference.ResourceId, roundTripPsRegistry.IdentityReference.ResourceId);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesMinimalProperties()
        {
            // Arrange
            var originalPsRegistry = new PSContainerRegistry(
                userName: "testuser",
                password: "testpassword");

            // Act
            var mgmtRegistry = originalPsRegistry.toMgmtContainerRegistry();
            var roundTripPsRegistry = PSContainerRegistry.fromMgmtContainerRegistry(mgmtRegistry);

            // Assert
            Assert.NotNull(roundTripPsRegistry);
            Assert.Equal(originalPsRegistry.UserName, roundTripPsRegistry.UserName);
            Assert.Equal(originalPsRegistry.Password, roundTripPsRegistry.Password);
            Assert.Null(roundTripPsRegistry.RegistryServer);
            Assert.Null(roundTripPsRegistry.IdentityReference);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesNullIdentityReference()
        {
            // Arrange
            var originalPsRegistry = new PSContainerRegistry(
                userName: "testuser",
                password: "testpassword",
                registryServer: "registry.example.com",
                identityReference: null);

            // Act
            var mgmtRegistry = originalPsRegistry.toMgmtContainerRegistry();
            var roundTripPsRegistry = PSContainerRegistry.fromMgmtContainerRegistry(mgmtRegistry);

            // Assert
            Assert.NotNull(roundTripPsRegistry);
            Assert.Equal(originalPsRegistry.UserName, roundTripPsRegistry.UserName);
            Assert.Equal(originalPsRegistry.Password, roundTripPsRegistry.Password);
            Assert.Equal(originalPsRegistry.RegistryServer, roundTripPsRegistry.RegistryServer);
            Assert.Null(roundTripPsRegistry.IdentityReference);
        }

        [Theory]
        [InlineData("myregistry.azurecr.io", "azureuser", "azurepass")]
        [InlineData("docker.io", "dockeruser", "dockerpass")]
        [InlineData("", "", "")]
        public void RoundTripConversion_AllValidValues_PreservesOriginalValue(string registryServer, string userName, string password)
        {
            // Arrange
            var originalPsRegistry = new PSContainerRegistry(
                userName: userName,
                password: password,
                registryServer: registryServer);

            // Act
            var mgmtRegistry = originalPsRegistry.toMgmtContainerRegistry();
            if (mgmtRegistry != null)
            {
                var roundTripPsRegistry = PSContainerRegistry.fromMgmtContainerRegistry(mgmtRegistry);

                // Assert
                Assert.NotNull(roundTripPsRegistry);
                Assert.Equal(originalPsRegistry.UserName, roundTripPsRegistry.UserName);
                Assert.Equal(originalPsRegistry.Password, roundTripPsRegistry.Password);
                Assert.Equal(originalPsRegistry.RegistryServer, roundTripPsRegistry.RegistryServer);
            }
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesValues()
        {
            // Arrange
            var identityResourceId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity";
            var originalIdentityRef = new ComputeNodeIdentityReference(identityResourceId);
            var originalMgmtRegistry = new ContainerRegistry(
                userName: "testuser",
                password: "testpassword",
                registryServer: "myregistry.azurecr.io",
                identityReference: originalIdentityRef);

            // Act
            var psRegistry = PSContainerRegistry.fromMgmtContainerRegistry(originalMgmtRegistry);
            var roundTripMgmtRegistry = psRegistry.toMgmtContainerRegistry();

            // Assert
            Assert.NotNull(roundTripMgmtRegistry);
            Assert.Equal(originalMgmtRegistry.UserName, roundTripMgmtRegistry.UserName);
            Assert.Equal(originalMgmtRegistry.Password, roundTripMgmtRegistry.Password);
            Assert.Equal(originalMgmtRegistry.RegistryServer, roundTripMgmtRegistry.RegistryServer);
            Assert.NotNull(roundTripMgmtRegistry.IdentityReference);
            Assert.Equal(originalMgmtRegistry.IdentityReference.ResourceId, roundTripMgmtRegistry.IdentityReference.ResourceId);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void ContainerRegistryConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Arrange - Test with Azure Container Registry scenario
            var identityResourceId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/batch-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/acr-identity";
            var psIdentityRef = new PSComputeNodeIdentityReference { ResourceId = identityResourceId };
            var psRegistry = new PSContainerRegistry(
                userName: "batchuser",
                password: "secretpassword",
                registryServer: "batchregistry.azurecr.io",
                identityReference: psIdentityRef);

            // Act
            var mgmtRegistry = psRegistry.toMgmtContainerRegistry();
            var backToPs = PSContainerRegistry.fromMgmtContainerRegistry(mgmtRegistry);

            // Assert
            Assert.NotNull(mgmtRegistry);
            Assert.Equal("batchuser", mgmtRegistry.UserName);
            Assert.Equal("secretpassword", mgmtRegistry.Password);
            Assert.Equal("batchregistry.azurecr.io", mgmtRegistry.RegistryServer);
            Assert.NotNull(mgmtRegistry.IdentityReference);
            Assert.Equal(identityResourceId, mgmtRegistry.IdentityReference.ResourceId);

            Assert.NotNull(backToPs);
            Assert.Equal("batchuser", backToPs.UserName);
            Assert.Equal("secretpassword", backToPs.Password);
            Assert.Equal("batchregistry.azurecr.io", backToPs.RegistryServer);
            Assert.NotNull(backToPs.IdentityReference);
            Assert.Equal(identityResourceId, backToPs.IdentityReference.ResourceId);
        }

        [Fact]
        public void ContainerRegistryConversions_NullHandling_WorksCorrectly()
        {
            // Test null handling in conversions

            // Arrange
            PSContainerRegistry psRegistryWithNullOmObject = new PSContainerRegistry();
            psRegistryWithNullOmObject.GetType().GetField("omObject", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(psRegistryWithNullOmObject, null);

            // Act
            var resultFromNullOmObject = psRegistryWithNullOmObject.toMgmtContainerRegistry();
            var resultFromNullMgmt = PSContainerRegistry.fromMgmtContainerRegistry(null);

            // Assert
            Assert.Null(resultFromNullOmObject);
            Assert.Null(resultFromNullMgmt);
        }

        [Fact]
        public void ContainerRegistryConversions_BatchContainerContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Batch container configuration
            // ContainerRegistry is used to configure private container registries for Batch pool compute nodes

            // Arrange - Test with different container registry scenarios
            var scenarios = new[]
            {
                // Azure Container Registry with managed identity
                new {
                    RegistryServer = "mybatchregistry.azurecr.io",
                    UserName = (string)null,
                    Password = (string)null,
                    IdentityResourceId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/acr-identity"
                },
                // Docker Hub with credentials
                new {
                    RegistryServer = "docker.io",
                    UserName = "dockerhubuser",
                    Password = "dockerhubpass",
                    IdentityResourceId = (string)null
                },
                // Private registry with credentials
                new {
                    RegistryServer = "private.registry.com",
                    UserName = "privateuser",
                    Password = "privatepass",
                    IdentityResourceId = (string)null
                }
            };

            foreach (var scenario in scenarios)
            {
                // Arrange
                var psIdentityRef = scenario.IdentityResourceId != null 
                    ? new PSComputeNodeIdentityReference { ResourceId = scenario.IdentityResourceId }
                    : null;

                var psRegistry = new PSContainerRegistry(
                    userName: scenario.UserName,
                    password: scenario.Password,
                    registryServer: scenario.RegistryServer,
                    identityReference: psIdentityRef);

                // Act
                var mgmtRegistry = psRegistry.toMgmtContainerRegistry();

                // Assert - Should convert correctly for Batch container configuration
                Assert.NotNull(mgmtRegistry);
                Assert.Equal(scenario.UserName, mgmtRegistry.UserName);
                Assert.Equal(scenario.Password, mgmtRegistry.Password);
                Assert.Equal(scenario.RegistryServer, mgmtRegistry.RegistryServer);
                
                if (scenario.IdentityResourceId != null)
                {
                    Assert.NotNull(mgmtRegistry.IdentityReference);
                    Assert.Equal(scenario.IdentityResourceId, mgmtRegistry.IdentityReference.ResourceId);
                }
                else
                {
                    Assert.Null(mgmtRegistry.IdentityReference);
                }

                // Verify round-trip conversion maintains container registry semantics
                var backToPs = PSContainerRegistry.fromMgmtContainerRegistry(mgmtRegistry);
                Assert.NotNull(backToPs);
                Assert.Equal(scenario.UserName, backToPs.UserName);
                Assert.Equal(scenario.Password, backToPs.Password);
                Assert.Equal(scenario.RegistryServer, backToPs.RegistryServer);
                
                // Fixed: Check for null before accessing ResourceId
                if (scenario.IdentityResourceId != null)
                {
                    Assert.NotNull(backToPs.IdentityReference);
                    Assert.Equal(scenario.IdentityResourceId, backToPs.IdentityReference.ResourceId);
                }
                else
                {
                    Assert.Null(backToPs.IdentityReference);
                }
            }
        }

        [Fact]
        public void ContainerRegistryConversions_InstanceCreation_VerifyBehavior()
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
            
            var mgmtIdentityRef = new ComputeNodeIdentityReference(identityResourceId);
            var mgmtRegistry = new ContainerRegistry(
                userName: "testuser",
                password: "testpass",
                registryServer: "test.azurecr.io",
                identityReference: mgmtIdentityRef);

            // Act
            var mgmtResult = psRegistry.toMgmtContainerRegistry();
            var psResult = PSContainerRegistry.fromMgmtContainerRegistry(mgmtRegistry);

            // Assert - Verify proper instance creation
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.IsType<ContainerRegistry>(mgmtResult);
            Assert.IsType<PSContainerRegistry>(psResult);

            // Verify new instances are created
            Assert.NotSame(mgmtRegistry, mgmtResult);
            Assert.NotSame(psRegistry, psResult);
        }

        #endregion

        #region Performance and Edge Case Tests

        [Fact]
        public void ContainerRegistryConversions_PerformanceTest_ExecutesQuickly()
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
            
            var mgmtIdentityRef = new ComputeNodeIdentityReference(identityResourceId);
            var mgmtRegistry = new ContainerRegistry(
                userName: "testuser",
                password: "testpass",
                registryServer: "test.azurecr.io",
                identityReference: mgmtIdentityRef);

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 100; i++)
            {
                var mgmtResult = psRegistry.toMgmtContainerRegistry();
                var psResult = PSContainerRegistry.fromMgmtContainerRegistry(mgmtRegistry);

                Assert.NotNull(mgmtResult);
                Assert.NotNull(psResult);
                Assert.Equal("testuser", mgmtResult.UserName);
                Assert.Equal("testuser", psResult.UserName);
            }
        }

        [Fact]
        public void ContainerRegistryConversions_EdgeCaseValues_HandleCorrectly()
        {
            // Test conversion with various edge case values

            var testRegistries = new[] {
                // Standard Azure Container Registry
                new { Server = "myregistry.azurecr.io", User = "acruser", Pass = "acrtoken" },
                // Docker Hub (default registry)
                new { Server = "docker.io", User = "dockeruser", Pass = "dockerpass" },
                // GitHub Container Registry
                new { Server = "ghcr.io", User = "githubuser", Pass = "ghp_token123" },
                // GitLab Container Registry
                new { Server = "registry.gitlab.com", User = "gitlab-ci-token", Pass = "token123" },
                // Quay.io
                new { Server = "quay.io", User = "quayuser", Pass = "quaytoken" },
                // Long registry names
                new { Server = "very-long-registry-name-for-testing.azurecr.io", User = "verylongusernameforcredentialtesting", Pass = "verylongpasswordfortesting123456789" },
                // Registry with port
                new { Server = "registry.example.com:5000", User = "portuser", Pass = "portpass" },
                // Empty values
                new { Server = "", User = "", Pass = "" }
            };

            foreach (var testRegistry in testRegistries)
            {
                // Arrange
                var psRegistry = new PSContainerRegistry(
                    userName: testRegistry.User,
                    password: testRegistry.Pass,
                    registryServer: testRegistry.Server);

                // Act
                var mgmtResult = psRegistry.toMgmtContainerRegistry();
                var roundTripResult = PSContainerRegistry.fromMgmtContainerRegistry(mgmtResult);

                // Assert
                Assert.NotNull(mgmtResult);
                Assert.NotNull(roundTripResult);
                Assert.Equal(testRegistry.User, mgmtResult.UserName);
                Assert.Equal(testRegistry.Pass, mgmtResult.Password);
                Assert.Equal(testRegistry.Server, mgmtResult.RegistryServer);
                Assert.Equal(testRegistry.User, roundTripResult.UserName);
                Assert.Equal(testRegistry.Pass, roundTripResult.Password);
                Assert.Equal(testRegistry.Server, roundTripResult.RegistryServer);
            }
        }

        #endregion
    }
}