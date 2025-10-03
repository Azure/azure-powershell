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
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ModelsConversions
{
    public class PSTaskContainerSettingsTests
    {
        #region toMgmtContainerConfiguration Tests

        [Fact]
        public void ToMgmtContainerConfiguration_WithCompleteSettings_ReturnsCorrectMapping()
        {
            // Arrange
            var identityResourceId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity";
            var psIdentityRef = new PSComputeNodeIdentityReference { ResourceId = identityResourceId };
            var psRegistry = new PSContainerRegistry(
                userName: "testuser",
                password: "testpass",
                registryServer: "myregistry.azurecr.io",
                identityReference: psIdentityRef);

            var psBindMounts = new List<PSContainerHostBatchBindMountEntry>
            {
                new PSContainerHostBatchBindMountEntry { Source = "Shared", IsReadOnly = false },
                new PSContainerHostBatchBindMountEntry { Source = "Task", IsReadOnly = true }
            };

            var psContainerSettings = new PSTaskContainerSettings(
                imageName: "ubuntu:20.04",
                containerRunOptions: "--rm --network host",
                registry: psRegistry,
                workingDirectory: Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.TaskWorkingDirectory);

            psContainerSettings.ContainerHostBatchBindMounts = psBindMounts;

            // Act
            var result = psContainerSettings.toMgmtContainerConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("ubuntu:20.04", result.ImageName);
            Assert.Equal("--rm --network host", result.ContainerRunOptions);
            Assert.Equal(ContainerWorkingDirectory.TaskWorkingDirectory, result.WorkingDirectory);

            // Verify registry mapping
            Assert.NotNull(result.Registry);
            Assert.Equal("testuser", result.Registry.UserName);
            Assert.Equal("testpass", result.Registry.Password);
            Assert.Equal("myregistry.azurecr.io", result.Registry.RegistryServer);
            Assert.NotNull(result.Registry.IdentityReference);
            Assert.Equal(identityResourceId, result.Registry.IdentityReference.ResourceId);

            // Verify bind mounts mapping
            Assert.NotNull(result.ContainerHostBatchBindMounts);
            Assert.Equal(2, result.ContainerHostBatchBindMounts.Count);
            Assert.Equal("Shared", result.ContainerHostBatchBindMounts[0].Source);
            Assert.Equal(false, result.ContainerHostBatchBindMounts[0].IsReadOnly);
            Assert.Equal("Task", result.ContainerHostBatchBindMounts[1].Source);
            Assert.Equal(true, result.ContainerHostBatchBindMounts[1].IsReadOnly);
        }

        [Fact]
        public void ToMgmtContainerConfiguration_WithMinimalSettings_ReturnsCorrectMapping()
        {
            // Arrange
            var psContainerSettings = new PSTaskContainerSettings(
                imageName: "nginx:latest");

            // Act
            var result = psContainerSettings.toMgmtContainerConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("nginx:latest", result.ImageName);
            Assert.Null(result.ContainerRunOptions);
            Assert.Null(result.Registry);
            Assert.Null(result.WorkingDirectory);
            Assert.Null(result.ContainerHostBatchBindMounts);
        }

        [Fact]
        public void ToMgmtContainerConfiguration_WithContainerImageDefaultWorkingDirectory_ReturnsCorrectMapping()
        {
            // Arrange
            var psContainerSettings = new PSTaskContainerSettings(
                imageName: "alpine:latest",
                workingDirectory: Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.ContainerImageDefault);

            // Act
            var result = psContainerSettings.toMgmtContainerConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("alpine:latest", result.ImageName);
            Assert.Equal(ContainerWorkingDirectory.ContainerImageDefault, result.WorkingDirectory);
        }

        [Fact]
        public void ToMgmtContainerConfiguration_WithNullWorkingDirectory_ReturnsNullWorkingDirectory()
        {
            // Arrange
            var psContainerSettings = new PSTaskContainerSettings(
                imageName: "python:3.9",
                workingDirectory: null);

            // Act
            var result = psContainerSettings.toMgmtContainerConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("python:3.9", result.ImageName);
            Assert.Null(result.WorkingDirectory);
        }

        [Fact]
        public void ToMgmtContainerConfiguration_WithNullRegistry_ReturnsNullRegistry()
        {
            // Arrange
            var psContainerSettings = new PSTaskContainerSettings(
                imageName: "node:16",
                registry: null);

            // Act
            var result = psContainerSettings.toMgmtContainerConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("node:16", result.ImageName);
            Assert.Null(result.Registry);
        }

        [Fact]
        public void ToMgmtContainerConfiguration_WithNullBindMounts_ReturnsNullBindMounts()
        {
            // Arrange
            var psContainerSettings = new PSTaskContainerSettings(
                imageName: "redis:6.2");
            psContainerSettings.ContainerHostBatchBindMounts = null;

            // Act
            var result = psContainerSettings.toMgmtContainerConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("redis:6.2", result.ImageName);
            Assert.Null(result.ContainerHostBatchBindMounts);
        }

        [Theory]
        [InlineData("ubuntu:20.04", "--privileged")]
        [InlineData("nginx:alpine", "--rm --network bridge")]
        [InlineData("mcr.microsoft.com/dotnet/runtime:6.0", "-e ASPNETCORE_ENVIRONMENT=Production")]
        [InlineData("python:3.9-slim", "--volume /data:/app/data")]
        public void ToMgmtContainerConfiguration_VariousImageNamesAndOptions_ReturnsCorrectMapping(string imageName, string containerRunOptions)
        {
            // Arrange
            var psContainerSettings = new PSTaskContainerSettings(
                imageName: imageName,
                containerRunOptions: containerRunOptions);

            // Act
            var result = psContainerSettings.toMgmtContainerConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(imageName, result.ImageName);
            Assert.Equal(containerRunOptions, result.ContainerRunOptions);
        }

        [Fact]
        public void ToMgmtContainerConfiguration_AlwaysCreatesNewInstance()
        {
            // Arrange
            var psContainerSettings = new PSTaskContainerSettings(
                imageName: "ubuntu:20.04");

            // Act
            var result1 = psContainerSettings.toMgmtContainerConfiguration();
            var result2 = psContainerSettings.toMgmtContainerConfiguration();

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void ToMgmtContainerConfiguration_VerifyTaskContainerSettingsType()
        {
            // Arrange
            var psContainerSettings = new PSTaskContainerSettings(
                imageName: "postgres:13");

            // Act
            var result = psContainerSettings.toMgmtContainerConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<TaskContainerSettings>(result);
        }

        [Fact]
        public void ToMgmtContainerConfiguration_WithEmptyBindMountsList_ReturnsEmptyBindMountsList()
        {
            // Arrange
            var psContainerSettings = new PSTaskContainerSettings(
                imageName: "mongo:5.0");
            psContainerSettings.ContainerHostBatchBindMounts = new List<PSContainerHostBatchBindMountEntry>();

            // Act
            var result = psContainerSettings.toMgmtContainerConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.ContainerHostBatchBindMounts);
            Assert.Empty(result.ContainerHostBatchBindMounts);
        }

        #endregion

        #region fromMgmtContainerConfiguration Tests

        [Fact]
        public void FromMgmtContainerConfiguration_WithCompleteSettings_ReturnsCorrectMapping()
        {
            // Arrange
            var identityResourceId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity";
            var mgmtIdentityRef = new ComputeNodeIdentityReference(identityResourceId);
            var mgmtRegistry = new ContainerRegistry(
                userName: "testuser",
                password: "testpass",
                registryServer: "myregistry.azurecr.io",
                identityReference: mgmtIdentityRef);

            var mgmtBindMounts = new List<ContainerHostBatchBindMountEntry>
            {
                new ContainerHostBatchBindMountEntry("Shared", false),
                new ContainerHostBatchBindMountEntry("Applications", true)
            };

            var mgmtContainerSettings = new TaskContainerSettings(
                imageName: "ubuntu:20.04",
                containerRunOptions: "--rm --network host",
                registry: mgmtRegistry,
                workingDirectory: ContainerWorkingDirectory.TaskWorkingDirectory,
                containerHostBatchBindMounts: mgmtBindMounts);

            // Act
            var result = PSTaskContainerSettings.fromMgmtContainerConfiguration(mgmtContainerSettings);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("ubuntu:20.04", result.ImageName);
            Assert.Equal("--rm --network host", result.ContainerRunOptions);
            Assert.Equal(Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.TaskWorkingDirectory, result.WorkingDirectory);

            // Verify registry mapping
            Assert.NotNull(result.Registry);
            Assert.Equal("testuser", result.Registry.UserName);
            Assert.Equal("testpass", result.Registry.Password);
            Assert.Equal("myregistry.azurecr.io", result.Registry.RegistryServer);
            Assert.NotNull(result.Registry.IdentityReference);
            Assert.Equal(identityResourceId, result.Registry.IdentityReference.ResourceId);

            // Verify bind mounts mapping
            Assert.NotNull(result.ContainerHostBatchBindMounts);
            Assert.Equal(2, result.ContainerHostBatchBindMounts.Count);
            Assert.Equal("Shared", result.ContainerHostBatchBindMounts[0].Source);
            Assert.Equal(false, result.ContainerHostBatchBindMounts[0].IsReadOnly);
            Assert.Equal("Applications", result.ContainerHostBatchBindMounts[1].Source);
            Assert.Equal(true, result.ContainerHostBatchBindMounts[1].IsReadOnly);
        }

        [Fact]
        public void FromMgmtContainerConfiguration_WithMinimalSettings_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtContainerSettings = new TaskContainerSettings(
                imageName: "nginx:latest");

            // Act
            var result = PSTaskContainerSettings.fromMgmtContainerConfiguration(mgmtContainerSettings);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("nginx:latest", result.ImageName);
            Assert.Null(result.ContainerRunOptions);
            Assert.Null(result.Registry);
            Assert.Null(result.WorkingDirectory);
            Assert.Null(result.ContainerHostBatchBindMounts);
        }

        [Fact]
        public void FromMgmtContainerConfiguration_WithNullMgmtSettings_ReturnsNull()
        {
            // Act
            var result = PSTaskContainerSettings.fromMgmtContainerConfiguration(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FromMgmtContainerConfiguration_WithContainerImageDefaultWorkingDirectory_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtContainerSettings = new TaskContainerSettings(
                imageName: "alpine:latest",
                workingDirectory: ContainerWorkingDirectory.ContainerImageDefault);

            // Act
            var result = PSTaskContainerSettings.fromMgmtContainerConfiguration(mgmtContainerSettings);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("alpine:latest", result.ImageName);
            Assert.Equal(Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.ContainerImageDefault, result.WorkingDirectory);
        }

        [Fact]
        public void FromMgmtContainerConfiguration_WithNullWorkingDirectory_ReturnsNullWorkingDirectory()
        {
            // Arrange
            var mgmtContainerSettings = new TaskContainerSettings(
                imageName: "python:3.9",
                workingDirectory: null);

            // Act
            var result = PSTaskContainerSettings.fromMgmtContainerConfiguration(mgmtContainerSettings);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("python:3.9", result.ImageName);
            Assert.Null(result.WorkingDirectory);
        }

        [Fact]
        public void FromMgmtContainerConfiguration_WithNullRegistry_ReturnsNullRegistry()
        {
            // Arrange
            var mgmtContainerSettings = new TaskContainerSettings(
                imageName: "node:16",
                registry: null);

            // Act
            var result = PSTaskContainerSettings.fromMgmtContainerConfiguration(mgmtContainerSettings);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("node:16", result.ImageName);
            Assert.Null(result.Registry);
        }

        [Fact]
        public void FromMgmtContainerConfiguration_WithNullBindMounts_ReturnsNullBindMounts()
        {
            // Arrange
            var mgmtContainerSettings = new TaskContainerSettings(
                imageName: "redis:6.2",
                containerHostBatchBindMounts: null);

            // Act
            var result = PSTaskContainerSettings.fromMgmtContainerConfiguration(mgmtContainerSettings);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("redis:6.2", result.ImageName);
            Assert.Null(result.ContainerHostBatchBindMounts);
        }

        [Theory]
        [InlineData("ubuntu:20.04", "--privileged")]
        [InlineData("nginx:alpine", "--rm --network bridge")]
        [InlineData("mcr.microsoft.com/dotnet/runtime:6.0", "-e ASPNETCORE_ENVIRONMENT=Production")]
        [InlineData("python:3.9-slim", "--volume /data:/app/data")]
        public void FromMgmtContainerConfiguration_VariousImageNamesAndOptions_ReturnsCorrectMapping(string imageName, string containerRunOptions)
        {
            // Arrange
            var mgmtContainerSettings = new TaskContainerSettings(
                imageName: imageName,
                containerRunOptions: containerRunOptions);

            // Act
            var result = PSTaskContainerSettings.fromMgmtContainerConfiguration(mgmtContainerSettings);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(imageName, result.ImageName);
            Assert.Equal(containerRunOptions, result.ContainerRunOptions);
        }

        [Fact]
        public void FromMgmtContainerConfiguration_StaticMethod_DoesNotRequireInstance()
        {
            // Arrange
            var mgmtContainerSettings = new TaskContainerSettings(
                imageName: "postgres:13",
                containerRunOptions: "--restart=always");

            // Act - Call static method directly on class
            var result = PSTaskContainerSettings.fromMgmtContainerConfiguration(mgmtContainerSettings);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("postgres:13", result.ImageName);
            Assert.Equal("--restart=always", result.ContainerRunOptions);
        }

        [Fact]
        public void FromMgmtContainerConfiguration_AlwaysCreatesNewInstance()
        {
            // Arrange
            var mgmtContainerSettings = new TaskContainerSettings(
                imageName: "mongo:5.0");

            // Act
            var result1 = PSTaskContainerSettings.fromMgmtContainerConfiguration(mgmtContainerSettings);
            var result2 = PSTaskContainerSettings.fromMgmtContainerConfiguration(mgmtContainerSettings);

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void FromMgmtContainerConfiguration_VerifyPSTaskContainerSettingsType()
        {
            // Arrange
            var mgmtContainerSettings = new TaskContainerSettings(
                imageName: "elasticsearch:7.17");

            // Act
            var result = PSTaskContainerSettings.fromMgmtContainerConfiguration(mgmtContainerSettings);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PSTaskContainerSettings>(result);
        }

        [Fact]
        public void FromMgmtContainerConfiguration_WithEmptyBindMountsList_ReturnsEmptyBindMountsList()
        {
            // Arrange
            var mgmtContainerSettings = new TaskContainerSettings(
                imageName: "rabbitmq:3.9",
                containerHostBatchBindMounts: new List<ContainerHostBatchBindMountEntry>());

            // Act
            var result = PSTaskContainerSettings.fromMgmtContainerConfiguration(mgmtContainerSettings);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.ContainerHostBatchBindMounts);
            Assert.Empty(result.ContainerHostBatchBindMounts);
        }

        [Fact]
        public void FromMgmtContainerConfiguration_WithDefaultConstructor_HandlesCorrectly()
        {
            // Arrange
            var mgmtContainerSettings = new TaskContainerSettings(); // Uses default constructor
            mgmtContainerSettings.ImageName = "busybox:latest";

            // Act
            var result = PSTaskContainerSettings.fromMgmtContainerConfiguration(mgmtContainerSettings);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("busybox:latest", result.ImageName);
            Assert.Null(result.ContainerRunOptions);
            Assert.Null(result.Registry);
            Assert.Null(result.WorkingDirectory);
            Assert.Null(result.ContainerHostBatchBindMounts);
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

            var originalBindMounts = new List<PSContainerHostBatchBindMountEntry>
            {
                new PSContainerHostBatchBindMountEntry { Source = "Shared", IsReadOnly = false },
                new PSContainerHostBatchBindMountEntry { Source = "Startup", IsReadOnly = true }
            };

            var originalPsContainerSettings = new PSTaskContainerSettings(
                imageName: "ubuntu:20.04",
                containerRunOptions: "--rm --network host",
                registry: originalRegistry,
                workingDirectory: Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.TaskWorkingDirectory);

            originalPsContainerSettings.ContainerHostBatchBindMounts = originalBindMounts;

            // Act
            var mgmtSettings = originalPsContainerSettings.toMgmtContainerConfiguration();
            var roundTripPsSettings = PSTaskContainerSettings.fromMgmtContainerConfiguration(mgmtSettings);

            // Assert
            Assert.NotNull(roundTripPsSettings);
            Assert.Equal(originalPsContainerSettings.ImageName, roundTripPsSettings.ImageName);
            Assert.Equal(originalPsContainerSettings.ContainerRunOptions, roundTripPsSettings.ContainerRunOptions);
            Assert.Equal(originalPsContainerSettings.WorkingDirectory, roundTripPsSettings.WorkingDirectory);

            // Verify registry round-trip
            Assert.NotNull(roundTripPsSettings.Registry);
            Assert.Equal(originalPsContainerSettings.Registry.UserName, roundTripPsSettings.Registry.UserName);
            Assert.Equal(originalPsContainerSettings.Registry.Password, roundTripPsSettings.Registry.Password);
            Assert.Equal(originalPsContainerSettings.Registry.RegistryServer, roundTripPsSettings.Registry.RegistryServer);
            Assert.NotNull(roundTripPsSettings.Registry.IdentityReference);
            Assert.Equal(originalPsContainerSettings.Registry.IdentityReference.ResourceId, roundTripPsSettings.Registry.IdentityReference.ResourceId);

            // Verify bind mounts round-trip
            Assert.NotNull(roundTripPsSettings.ContainerHostBatchBindMounts);
            Assert.Equal(originalPsContainerSettings.ContainerHostBatchBindMounts.Count, roundTripPsSettings.ContainerHostBatchBindMounts.Count);
            for (int i = 0; i < originalPsContainerSettings.ContainerHostBatchBindMounts.Count; i++)
            {
                Assert.Equal(originalPsContainerSettings.ContainerHostBatchBindMounts[i].Source, roundTripPsSettings.ContainerHostBatchBindMounts[i].Source);
                Assert.Equal(originalPsContainerSettings.ContainerHostBatchBindMounts[i].IsReadOnly, roundTripPsSettings.ContainerHostBatchBindMounts[i].IsReadOnly);
            }
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesMinimalSettings()
        {
            // Arrange
            var originalPsContainerSettings = new PSTaskContainerSettings(
                imageName: "nginx:latest");

            // Act
            var mgmtSettings = originalPsContainerSettings.toMgmtContainerConfiguration();
            var roundTripPsSettings = PSTaskContainerSettings.fromMgmtContainerConfiguration(mgmtSettings);

            // Assert
            Assert.NotNull(roundTripPsSettings);
            Assert.Equal(originalPsContainerSettings.ImageName, roundTripPsSettings.ImageName);
            Assert.Null(roundTripPsSettings.ContainerRunOptions);
            Assert.Null(roundTripPsSettings.Registry);
            Assert.Null(roundTripPsSettings.WorkingDirectory);
            Assert.Null(roundTripPsSettings.ContainerHostBatchBindMounts);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesNullValues()
        {
            // Arrange
            var originalPsContainerSettings = new PSTaskContainerSettings(
                imageName: "alpine:latest",
                containerRunOptions: null,
                registry: null,
                workingDirectory: null);
            originalPsContainerSettings.ContainerHostBatchBindMounts = null;

            // Act
            var mgmtSettings = originalPsContainerSettings.toMgmtContainerConfiguration();
            var roundTripPsSettings = PSTaskContainerSettings.fromMgmtContainerConfiguration(mgmtSettings);

            // Assert
            Assert.NotNull(roundTripPsSettings);
            Assert.Equal(originalPsContainerSettings.ImageName, roundTripPsSettings.ImageName);
            Assert.Null(roundTripPsSettings.ContainerRunOptions);
            Assert.Null(roundTripPsSettings.Registry);
            Assert.Null(roundTripPsSettings.WorkingDirectory);
            Assert.Null(roundTripPsSettings.ContainerHostBatchBindMounts);
        }

        [Theory]
        [InlineData("ubuntu:20.04", "--privileged")]
        [InlineData("nginx:alpine", "--rm --network bridge")]
        [InlineData("python:3.9", null)]
        public void RoundTripConversion_AllValidValues_PreservesOriginalValue(string imageName, string containerRunOptions)
        {
            // Arrange
            var originalPsContainerSettings = new PSTaskContainerSettings(
                imageName: imageName,
                containerRunOptions: containerRunOptions);

            // Act
            var mgmtSettings = originalPsContainerSettings.toMgmtContainerConfiguration();
            var roundTripPsSettings = PSTaskContainerSettings.fromMgmtContainerConfiguration(mgmtSettings);

            // Assert
            Assert.NotNull(roundTripPsSettings);
            Assert.Equal(originalPsContainerSettings.ImageName, roundTripPsSettings.ImageName);
            Assert.Equal(originalPsContainerSettings.ContainerRunOptions, roundTripPsSettings.ContainerRunOptions);
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

            var originalBindMounts = new List<ContainerHostBatchBindMountEntry>
            {
                new ContainerHostBatchBindMountEntry("VfsMounts", false),
                new ContainerHostBatchBindMountEntry("JobPrep", true)
            };

            var originalMgmtSettings = new TaskContainerSettings(
                imageName: "postgres:13",
                containerRunOptions: "--restart=unless-stopped",
                registry: originalRegistry,
                workingDirectory: ContainerWorkingDirectory.ContainerImageDefault,
                containerHostBatchBindMounts: originalBindMounts);

            // Act
            var psSettings = PSTaskContainerSettings.fromMgmtContainerConfiguration(originalMgmtSettings);
            var roundTripMgmtSettings = psSettings.toMgmtContainerConfiguration();

            // Assert
            Assert.NotNull(roundTripMgmtSettings);
            Assert.Equal(originalMgmtSettings.ImageName, roundTripMgmtSettings.ImageName);
            Assert.Equal(originalMgmtSettings.ContainerRunOptions, roundTripMgmtSettings.ContainerRunOptions);
            Assert.Equal(originalMgmtSettings.WorkingDirectory, roundTripMgmtSettings.WorkingDirectory);

            // Verify registry round-trip
            Assert.NotNull(roundTripMgmtSettings.Registry);
            Assert.Equal(originalMgmtSettings.Registry.UserName, roundTripMgmtSettings.Registry.UserName);
            Assert.Equal(originalMgmtSettings.Registry.Password, roundTripMgmtSettings.Registry.Password);
            Assert.Equal(originalMgmtSettings.Registry.RegistryServer, roundTripMgmtSettings.Registry.RegistryServer);
            Assert.Equal(originalMgmtSettings.Registry.IdentityReference.ResourceId, roundTripMgmtSettings.Registry.IdentityReference.ResourceId);

            // Verify bind mounts round-trip
            Assert.NotNull(roundTripMgmtSettings.ContainerHostBatchBindMounts);
            Assert.Equal(originalMgmtSettings.ContainerHostBatchBindMounts.Count, roundTripMgmtSettings.ContainerHostBatchBindMounts.Count);
            for (int i = 0; i < originalMgmtSettings.ContainerHostBatchBindMounts.Count; i++)
            {
                Assert.Equal(originalMgmtSettings.ContainerHostBatchBindMounts[i].Source, roundTripMgmtSettings.ContainerHostBatchBindMounts[i].Source);
                Assert.Equal(originalMgmtSettings.ContainerHostBatchBindMounts[i].IsReadOnly, roundTripMgmtSettings.ContainerHostBatchBindMounts[i].IsReadOnly);
            }
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void TaskContainerSettingsConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Arrange - Test with realistic container task scenarios
            var identityResourceId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/batch-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/container-identity";
            var psIdentityRef = new PSComputeNodeIdentityReference { ResourceId = identityResourceId };
            var psRegistry = new PSContainerRegistry(
                userName: "batchuser",
                password: "batchpass",
                registryServer: "batchregistry.azurecr.io",
                identityReference: psIdentityRef);

            var psBindMounts = new List<PSContainerHostBatchBindMountEntry>
            {
                new PSContainerHostBatchBindMountEntry { Source = "Shared", IsReadOnly = false },
                new PSContainerHostBatchBindMountEntry { Source = "Applications", IsReadOnly = true },
                new PSContainerHostBatchBindMountEntry { Source = "Task", IsReadOnly = false }
            };

            var psContainerSettings = new PSTaskContainerSettings(
                imageName: "mcr.microsoft.com/dotnet/runtime:6.0",
                containerRunOptions: "--memory=2g --cpus=1.5",
                registry: psRegistry,
                workingDirectory: Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.TaskWorkingDirectory);

            psContainerSettings.ContainerHostBatchBindMounts = psBindMounts;

            // Act
            var mgmtSettings = psContainerSettings.toMgmtContainerConfiguration();
            var backToPs = PSTaskContainerSettings.fromMgmtContainerConfiguration(mgmtSettings);

            // Assert
            Assert.NotNull(mgmtSettings);
            Assert.NotNull(backToPs);

            // Verify semantic equivalence
            Assert.Equal("mcr.microsoft.com/dotnet/runtime:6.0", mgmtSettings.ImageName);
            Assert.Equal("--memory=2g --cpus=1.5", mgmtSettings.ContainerRunOptions);
            Assert.Equal(ContainerWorkingDirectory.TaskWorkingDirectory, mgmtSettings.WorkingDirectory);
            Assert.NotNull(mgmtSettings.Registry);
            Assert.Equal("batchregistry.azurecr.io", mgmtSettings.Registry.RegistryServer);
            Assert.Equal(3, mgmtSettings.ContainerHostBatchBindMounts.Count);

            Assert.Equal("mcr.microsoft.com/dotnet/runtime:6.0", backToPs.ImageName);
            Assert.Equal("--memory=2g --cpus=1.5", backToPs.ContainerRunOptions);
            Assert.Equal(Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.TaskWorkingDirectory, backToPs.WorkingDirectory);
            Assert.NotNull(backToPs.Registry);
            Assert.Equal("batchregistry.azurecr.io", backToPs.Registry.RegistryServer);
            Assert.Equal(3, backToPs.ContainerHostBatchBindMounts.Count);
        }

        [Fact]
        public void TaskContainerSettingsConversions_NullHandling_WorksCorrectly()
        {
            // Test null handling in conversions

            // Act
            var resultFromNull = PSTaskContainerSettings.fromMgmtContainerConfiguration(null);

            // Assert
            Assert.Null(resultFromNull);
        }

        [Fact]
        public void TaskContainerSettingsConversions_BatchContainerContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Batch container tasks
            // TaskContainerSettings is used to configure containerized tasks in Azure Batch

            // Arrange - Test with different container scenarios
            var containerScenarios = new[]
            {
                // Data processing scenario
                new {
                    ImageName = "python:3.9-slim",
                    ContainerRunOptions = "--memory=4g --volume /data:/app/data",
                    WorkingDirectory = Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.TaskWorkingDirectory,
                    Description = "Python data processing with task working directory"
                },
                // Web application scenario
                new {
                    ImageName = "nginx:alpine",
                    ContainerRunOptions = "--publish 80:80",
                    WorkingDirectory = Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.ContainerImageDefault,
                    Description = "Web server using container default working directory"
                },
                // Machine learning scenario
                new {
                    ImageName = "tensorflow/tensorflow:2.8.0-gpu",
                    ContainerRunOptions = "--gpus all --shm-size=1g",
                    WorkingDirectory = Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.TaskWorkingDirectory,
                    Description = "GPU-enabled ML workload with task working directory"
                }
            };

            foreach (var scenario in containerScenarios)
            {
                // Arrange
                var psContainerSettings = new PSTaskContainerSettings(
                    imageName: scenario.ImageName,
                    containerRunOptions: scenario.ContainerRunOptions,
                    workingDirectory: scenario.WorkingDirectory);

                // Act
                var mgmtSettings = psContainerSettings.toMgmtContainerConfiguration();

                // Assert - Should convert correctly for Batch container task configuration
                Assert.NotNull(mgmtSettings);
                Assert.Equal(scenario.ImageName, mgmtSettings.ImageName);
                Assert.Equal(scenario.ContainerRunOptions, mgmtSettings.ContainerRunOptions);
                
                var expectedMgmtWorkingDirectory = scenario.WorkingDirectory == Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.TaskWorkingDirectory
                    ? ContainerWorkingDirectory.TaskWorkingDirectory
                    : ContainerWorkingDirectory.ContainerImageDefault;
                Assert.Equal(expectedMgmtWorkingDirectory, mgmtSettings.WorkingDirectory);

                // Verify round-trip conversion maintains container task semantics
                var backToPs = PSTaskContainerSettings.fromMgmtContainerConfiguration(mgmtSettings);
                Assert.NotNull(backToPs);
                Assert.Equal(scenario.ImageName, backToPs.ImageName);
                Assert.Equal(scenario.ContainerRunOptions, backToPs.ContainerRunOptions);
                Assert.Equal(scenario.WorkingDirectory, backToPs.WorkingDirectory);
            }
        }

        [Fact]
        public void TaskContainerSettingsConversions_InstanceCreation_VerifyBehavior()
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

            var psContainerSettings = new PSTaskContainerSettings(
                imageName: "ubuntu:20.04",
                containerRunOptions: "--rm",
                registry: psRegistry);

            var mgmtIdentityRef = new ComputeNodeIdentityReference(identityResourceId);
            var mgmtRegistry = new ContainerRegistry(
                userName: "testuser",
                password: "testpass",
                registryServer: "test.azurecr.io",
                identityReference: mgmtIdentityRef);

            var mgmtContainerSettings = new TaskContainerSettings(
                imageName: "ubuntu:20.04",
                containerRunOptions: "--rm",
                registry: mgmtRegistry);

            // Act
            var mgmtResult = psContainerSettings.toMgmtContainerConfiguration();
            var psResult = PSTaskContainerSettings.fromMgmtContainerConfiguration(mgmtContainerSettings);

            // Assert - Verify proper instance creation
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.IsType<TaskContainerSettings>(mgmtResult);
            Assert.IsType<PSTaskContainerSettings>(psResult);

            // Verify new instances are created
            Assert.NotSame(mgmtContainerSettings, mgmtResult);
            Assert.NotSame(psContainerSettings, psResult);
        }

        #endregion

        #region Performance and Edge Case Tests

        [Fact]
        public void TaskContainerSettingsConversions_PerformanceTest_ExecutesQuickly()
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

            var psBindMounts = new List<PSContainerHostBatchBindMountEntry>
            {
                new PSContainerHostBatchBindMountEntry { Source = "Shared", IsReadOnly = false }
            };

            var psContainerSettings = new PSTaskContainerSettings(
                imageName: "ubuntu:20.04",
                containerRunOptions: "--rm",
                registry: psRegistry,
                workingDirectory: Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.TaskWorkingDirectory);
            psContainerSettings.ContainerHostBatchBindMounts = psBindMounts;

            var mgmtIdentityRef = new ComputeNodeIdentityReference(identityResourceId);
            var mgmtRegistry = new ContainerRegistry(
                userName: "testuser",
                password: "testpass",
                registryServer: "test.azurecr.io",
                identityReference: mgmtIdentityRef);

            var mgmtBindMounts = new List<ContainerHostBatchBindMountEntry>
            {
                new ContainerHostBatchBindMountEntry("Shared", false)
            };

            var mgmtContainerSettings = new TaskContainerSettings(
                imageName: "ubuntu:20.04",
                containerRunOptions: "--rm",
                registry: mgmtRegistry,
                workingDirectory: ContainerWorkingDirectory.TaskWorkingDirectory,
                containerHostBatchBindMounts: mgmtBindMounts);

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 100; i++)
            {
                var mgmtResult = psContainerSettings.toMgmtContainerConfiguration();
                var psResult = PSTaskContainerSettings.fromMgmtContainerConfiguration(mgmtContainerSettings);

                Assert.NotNull(mgmtResult);
                Assert.NotNull(psResult);
                Assert.Equal("ubuntu:20.04", mgmtResult.ImageName);
                Assert.Equal("ubuntu:20.04", psResult.ImageName);
            }
        }

        [Fact]
        public void TaskContainerSettingsConversions_EdgeCaseValues_HandleCorrectly()
        {
            // Test conversion with various edge case values

            var testContainerSettings = new[]
            {
                // Standard containers
                new { ImageName = "ubuntu:20.04", ContainerRunOptions = "--rm" },
                new { ImageName = "nginx:alpine", ContainerRunOptions = "--publish 80:80" },
                new { ImageName = "python:3.9", ContainerRunOptions = "--volume /data:/app" },
                // Microsoft Container Registry
                new { ImageName = "mcr.microsoft.com/dotnet/runtime:6.0", ContainerRunOptions = "--memory=1g" },
                // Docker Hub with organization
                new { ImageName = "tensorflow/tensorflow:2.8.0", ContainerRunOptions = "--gpus all" },
                // Private registry
                new { ImageName = "myregistry.azurecr.io/myapp:v1.0", ContainerRunOptions = "--network=host" },
                // Edge cases
                new { ImageName = "", ContainerRunOptions = "" },
                new { ImageName = "busybox", ContainerRunOptions = (string)null },
                new { ImageName = "alpine:latest", ContainerRunOptions = "   " }, // Whitespace
                new { ImageName = "very-long-registry-name.azurecr.io/very-long-image-name:very-long-tag-for-testing", ContainerRunOptions = "--memory=4g --cpus=2.5 --volume=/very/long/path/for/testing:/app/data" }
            };

            foreach (var testSetting in testContainerSettings)
            {
                // Arrange
                var psContainerSettings = new PSTaskContainerSettings(
                    imageName: testSetting.ImageName,
                    containerRunOptions: testSetting.ContainerRunOptions);

                // Act
                var mgmtResult = psContainerSettings.toMgmtContainerConfiguration();
                var roundTripResult = PSTaskContainerSettings.fromMgmtContainerConfiguration(mgmtResult);

                // Assert
                Assert.NotNull(mgmtResult);
                Assert.NotNull(roundTripResult);
                Assert.Equal(testSetting.ImageName, mgmtResult.ImageName);
                Assert.Equal(testSetting.ContainerRunOptions, mgmtResult.ContainerRunOptions);
                Assert.Equal(testSetting.ImageName, roundTripResult.ImageName);
                Assert.Equal(testSetting.ContainerRunOptions, roundTripResult.ContainerRunOptions);
            }
        }

        #endregion
    }
}