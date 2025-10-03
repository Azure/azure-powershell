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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ModelsConversions
{
    public class PSStartTaskTests
    {
        #region toMgmtStartTask Tests

        [Fact]
        public void ToMgmtStartTask_WithAllProperties_ReturnsCorrectMapping()
        {
            // Arrange
            var identityResourceId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity";
            var psIdentityRef = new PSComputeNodeIdentityReference { ResourceId = identityResourceId };
            var psRegistry = new PSContainerRegistry(
                userName: "testuser",
                password: "testpass",
                registryServer: "myregistry.azurecr.io",
                identityReference: psIdentityRef);

            var psContainerSettings = new PSTaskContainerSettings(
                imageName: "ubuntu:20.04",
                containerRunOptions: "--rm --network host",
                registry: psRegistry,
                workingDirectory: Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.TaskWorkingDirectory);

            var psAutoUserSpec = new PSAutoUserSpecification(
                scope: Microsoft.Azure.Batch.Common.AutoUserScope.Task,
                elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.Admin);
            var psUserIdentity = new PSUserIdentity(psAutoUserSpec);

            var environmentSettings = new Dictionary<string, string>
            {
                { "PATH", "/usr/local/bin:/usr/bin:/bin" },
                { "HOME", "/home/user" }
            };

            var psStartTask = new PSStartTask("echo 'Starting batch task'")
            {
                ContainerSettings = psContainerSettings,
                EnvironmentSettings = environmentSettings,
                MaxTaskRetryCount = 3,
                UserIdentity = psUserIdentity,
                WaitForSuccess = true
            };

            // Act
            var result = psStartTask.toMgmtStartTask();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("echo 'Starting batch task'", result.CommandLine);
            Assert.Equal(3, result.MaxTaskRetryCount);
            Assert.Equal(true, result.WaitForSuccess);

            // Verify container settings
            Assert.NotNull(result.ContainerSettings);
            Assert.Equal("ubuntu:20.04", result.ContainerSettings.ImageName);
            Assert.Equal("--rm --network host", result.ContainerSettings.ContainerRunOptions);
            Assert.Equal(ContainerWorkingDirectory.TaskWorkingDirectory, result.ContainerSettings.WorkingDirectory);

            // Verify user identity
            Assert.NotNull(result.UserIdentity);
            Assert.NotNull(result.UserIdentity.AutoUser);
            Assert.Equal(AutoUserScope.Task, result.UserIdentity.AutoUser.Scope);
            Assert.Equal(ElevationLevel.Admin, result.UserIdentity.AutoUser.ElevationLevel);

            // Verify environment settings
            Assert.NotNull(result.EnvironmentSettings);
            Assert.Equal(2, result.EnvironmentSettings.Count);
            var envDict = new Dictionary<string, string>();
            foreach (var env in result.EnvironmentSettings)
            {
                envDict[env.Name] = env.Value;
            }
            Assert.Equal("/usr/local/bin:/usr/bin:/bin", envDict["PATH"]);
            Assert.Equal("/home/user", envDict["HOME"]);
        }

        [Fact]
        public void ToMgmtStartTask_WithMinimalProperties_ReturnsCorrectMapping()
        {
            // Arrange
            var psStartTask = new PSStartTask("echo 'hello world'");

            // Act
            var result = psStartTask.toMgmtStartTask();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("echo 'hello world'", result.CommandLine);
            Assert.Null(result.ContainerSettings);
            Assert.Null(result.EnvironmentSettings);
            Assert.Null(result.MaxTaskRetryCount);
            Assert.Null(result.ResourceFiles);
            Assert.Null(result.UserIdentity);
            Assert.Null(result.WaitForSuccess);
        }

        [Fact]
        public void ToMgmtStartTask_WithNamedUser_ReturnsCorrectMapping()
        {
            // Arrange
            var psUserIdentity = new PSUserIdentity("batchuser");
            var psStartTask = new PSStartTask("cmd /c dir")
            {
                UserIdentity = psUserIdentity,
                MaxTaskRetryCount = 1,
                WaitForSuccess = false
            };

            // Act
            var result = psStartTask.toMgmtStartTask();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("cmd /c dir", result.CommandLine);
            Assert.Equal(1, result.MaxTaskRetryCount);
            Assert.Equal(false, result.WaitForSuccess);
            Assert.NotNull(result.UserIdentity);
            Assert.Equal("batchuser", result.UserIdentity.UserName);
            Assert.Null(result.UserIdentity.AutoUser);
        }

        [Fact]
        public void ToMgmtStartTask_WithContainerSettingsOnly_ReturnsCorrectMapping()
        {
            // Arrange
            var psContainerSettings = new PSTaskContainerSettings(
                imageName: "nginx:alpine",
                containerRunOptions: "--publish 80:80");

            var psStartTask = new PSStartTask("nginx -g 'daemon off;'")
            {
                ContainerSettings = psContainerSettings
            };

            // Act
            var result = psStartTask.toMgmtStartTask();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("nginx -g 'daemon off;'", result.CommandLine);
            Assert.NotNull(result.ContainerSettings);
            Assert.Equal("nginx:alpine", result.ContainerSettings.ImageName);
            Assert.Equal("--publish 80:80", result.ContainerSettings.ContainerRunOptions);
        }

        [Fact]
        public void ToMgmtStartTask_WithNullContainerSettings_ReturnsNullContainerSettings()
        {
            // Arrange
            var psStartTask = new PSStartTask("echo 'test'")
            {
                ContainerSettings = null
            };

            // Act
            var result = psStartTask.toMgmtStartTask();

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.ContainerSettings);
        }

        [Fact]
        public void ToMgmtStartTask_WithNullUserIdentity_ReturnsNullUserIdentity()
        {
            // Arrange
            var psStartTask = new PSStartTask("echo 'test'")
            {
                UserIdentity = null
            };

            // Act
            var result = psStartTask.toMgmtStartTask();

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.UserIdentity);
        }

        [Fact]
        public void ToMgmtStartTask_WithEmptyEnvironmentSettings_ReturnsEmptyEnvironmentSettings()
        {
            // Arrange
            var psStartTask = new PSStartTask("echo 'test'")
            {
                EnvironmentSettings = new Dictionary<string, string>()
            };

            // Act
            var result = psStartTask.toMgmtStartTask();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.EnvironmentSettings);
            Assert.Empty(result.EnvironmentSettings);
        }

        [Theory]
        [InlineData("echo 'Hello World'", 0, true)]
        [InlineData("powershell -Command 'Get-Process'", 5, false)]
        [InlineData("/bin/bash -c 'ls -la'", null, null)]
        [InlineData("python setup.py install", 10, true)]
        public void ToMgmtStartTask_VariousCommandLineScenarios_ReturnsCorrectMapping(string commandLine, int? maxRetryCount, bool? waitForSuccess)
        {
            // Arrange
            var psStartTask = new PSStartTask(commandLine)
            {
                MaxTaskRetryCount = maxRetryCount,
                WaitForSuccess = waitForSuccess
            };

            // Act
            var result = psStartTask.toMgmtStartTask();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(commandLine, result.CommandLine);
            Assert.Equal(maxRetryCount, result.MaxTaskRetryCount);
            Assert.Equal(waitForSuccess, result.WaitForSuccess);
        }

        [Fact]
        public void ToMgmtStartTask_AlwaysCreatesNewInstance()
        {
            // Arrange
            var psStartTask = new PSStartTask("echo 'test'");

            // Act
            var result1 = psStartTask.toMgmtStartTask();
            var result2 = psStartTask.toMgmtStartTask();

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void ToMgmtStartTask_VerifyStartTaskType()
        {
            // Arrange
            var psStartTask = new PSStartTask("echo 'test'");

            // Act
            var result = psStartTask.toMgmtStartTask();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<StartTask>(result);
        }

        #endregion

        #region fromMgmtStartTask Tests

        [Fact]
        public void FromMgmtStartTask_WithAllProperties_ReturnsCorrectMapping()
        {
            // Arrange
            var identityResourceId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity";
            var mgmtIdentityRef = new ComputeNodeIdentityReference(identityResourceId);
            var mgmtRegistry = new ContainerRegistry(
                userName: "testuser",
                password: "testpass",
                registryServer: "myregistry.azurecr.io",
                identityReference: mgmtIdentityRef);

            var mgmtContainerSettings = new TaskContainerSettings(
                imageName: "ubuntu:20.04",
                containerRunOptions: "--rm --network host",
                registry: mgmtRegistry,
                workingDirectory: ContainerWorkingDirectory.TaskWorkingDirectory);

            var mgmtAutoUserSpec = new AutoUserSpecification(
                scope: AutoUserScope.Task,
                elevationLevel: ElevationLevel.Admin);
            var mgmtUserIdentity = new UserIdentity(autoUser: mgmtAutoUserSpec);

            var mgmtEnvironmentSettings = new List<EnvironmentSetting>
            {
                new EnvironmentSetting("PATH", "/usr/local/bin:/usr/bin:/bin"),
                new EnvironmentSetting("HOME", "/home/user")
            };

            var mgmtStartTask = new StartTask(
                commandLine: "echo 'Starting batch task'",
                resourceFiles: null,
                environmentSettings: mgmtEnvironmentSettings,
                userIdentity: mgmtUserIdentity,
                maxTaskRetryCount: 3,
                waitForSuccess: true,
                containerSettings: mgmtContainerSettings);

            // Act
            var result = PSStartTask.fromMgmtStartTask(mgmtStartTask);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("echo 'Starting batch task'", result.CommandLine);
            Assert.Equal(3, result.MaxTaskRetryCount);
            Assert.Equal(true, result.WaitForSuccess);

            // Verify container settings
            Assert.NotNull(result.ContainerSettings);
            Assert.Equal("ubuntu:20.04", result.ContainerSettings.ImageName);
            Assert.Equal("--rm --network host", result.ContainerSettings.ContainerRunOptions);
            Assert.Equal(Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.TaskWorkingDirectory, result.ContainerSettings.WorkingDirectory);

            // Verify user identity
            Assert.NotNull(result.UserIdentity);
            Assert.NotNull(result.UserIdentity.AutoUser);
            Assert.Equal(Microsoft.Azure.Batch.Common.AutoUserScope.Task, result.UserIdentity.AutoUser.Scope);
            Assert.Equal(Microsoft.Azure.Batch.Common.ElevationLevel.Admin, result.UserIdentity.AutoUser.ElevationLevel);

            // Verify environment settings
            Assert.NotNull(result.EnvironmentSettings);
            Assert.Equal(2, result.EnvironmentSettings.Count);
            Assert.Equal("/usr/local/bin:/usr/bin:/bin", result.EnvironmentSettings["PATH"]);
            Assert.Equal("/home/user", result.EnvironmentSettings["HOME"]);
        }

        [Fact]
        public void FromMgmtStartTask_WithMinimalProperties_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtStartTask = new StartTask(commandLine: "echo 'hello world'");

            // Act
            var result = PSStartTask.fromMgmtStartTask(mgmtStartTask);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("echo 'hello world'", result.CommandLine);
            Assert.Null(result.ContainerSettings);
            Assert.Null(result.EnvironmentSettings);
            Assert.Null(result.MaxTaskRetryCount);
            Assert.Null(result.ResourceFiles);
            Assert.Null(result.UserIdentity);
            Assert.Null(result.WaitForSuccess);
        }

        [Fact]
        public void FromMgmtStartTask_WithNamedUser_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtUserIdentity = new UserIdentity(userName: "batchuser");
            var mgmtStartTask = new StartTask(
                commandLine: "cmd /c dir",
                userIdentity: mgmtUserIdentity,
                maxTaskRetryCount: 1,
                waitForSuccess: false);

            // Act
            var result = PSStartTask.fromMgmtStartTask(mgmtStartTask);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("cmd /c dir", result.CommandLine);
            Assert.Equal(1, result.MaxTaskRetryCount);
            Assert.Equal(false, result.WaitForSuccess);
            Assert.NotNull(result.UserIdentity);
            Assert.Equal("batchuser", result.UserIdentity.UserName);
            Assert.Null(result.UserIdentity.AutoUser);
        }

        [Fact]
        public void FromMgmtStartTask_WithContainerSettingsOnly_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtContainerSettings = new TaskContainerSettings(
                imageName: "nginx:alpine",
                containerRunOptions: "--publish 80:80");

            var mgmtStartTask = new StartTask(
                commandLine: "nginx -g 'daemon off;'",
                containerSettings: mgmtContainerSettings);

            // Act
            var result = PSStartTask.fromMgmtStartTask(mgmtStartTask);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("nginx -g 'daemon off;'", result.CommandLine);
            Assert.NotNull(result.ContainerSettings);
            Assert.Equal("nginx:alpine", result.ContainerSettings.ImageName);
            Assert.Equal("--publish 80:80", result.ContainerSettings.ContainerRunOptions);
        }

        [Fact]
        public void FromMgmtStartTask_WithNullContainerSettings_ReturnsNullContainerSettings()
        {
            // Arrange
            var mgmtStartTask = new StartTask(
                commandLine: "echo 'test'",
                containerSettings: null);

            // Act
            var result = PSStartTask.fromMgmtStartTask(mgmtStartTask);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.ContainerSettings);
        }

        [Fact]
        public void FromMgmtStartTask_WithNullUserIdentity_ReturnsNullUserIdentity()
        {
            // Arrange
            var mgmtStartTask = new StartTask(
                commandLine: "echo 'test'",
                userIdentity: null);

            // Act
            var result = PSStartTask.fromMgmtStartTask(mgmtStartTask);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.UserIdentity);
        }

        [Fact]
        public void FromMgmtStartTask_WithEmptyEnvironmentSettings_ReturnsNullEnvironmentSettings()
        {
            // Arrange
            var mgmtStartTask = new StartTask(
                commandLine: "echo 'test'",
                environmentSettings: new List<EnvironmentSetting>());

            // Act
            var result = PSStartTask.fromMgmtStartTask(mgmtStartTask);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.EnvironmentSettings);
            Assert.Empty(result.EnvironmentSettings);
        }

        [Theory]
        [InlineData("echo 'Hello World'", 0, true)]
        [InlineData("powershell -Command 'Get-Process'", 5, false)]
        [InlineData("/bin/bash -c 'ls -la'", null, null)]
        [InlineData("python setup.py install", 10, true)]
        public void FromMgmtStartTask_VariousCommandLineScenarios_ReturnsCorrectMapping(string commandLine, int? maxRetryCount, bool? waitForSuccess)
        {
            // Arrange
            var mgmtStartTask = new StartTask(
                commandLine: commandLine,
                maxTaskRetryCount: maxRetryCount,
                waitForSuccess: waitForSuccess);

            // Act
            var result = PSStartTask.fromMgmtStartTask(mgmtStartTask);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(commandLine, result.CommandLine);
            Assert.Equal(maxRetryCount, result.MaxTaskRetryCount);
            Assert.Equal(waitForSuccess, result.WaitForSuccess);
        }

        [Fact]
        public void FromMgmtStartTask_StaticMethod_DoesNotRequireInstance()
        {
            // Arrange
            var mgmtStartTask = new StartTask(commandLine: "echo 'test'");

            // Act - Call static method directly on class
            var result = PSStartTask.fromMgmtStartTask(mgmtStartTask);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("echo 'test'", result.CommandLine);
        }

        [Fact]
        public void FromMgmtStartTask_AlwaysCreatesNewInstance()
        {
            // Arrange
            var mgmtStartTask = new StartTask(commandLine: "echo 'test'");

            // Act
            var result1 = PSStartTask.fromMgmtStartTask(mgmtStartTask);
            var result2 = PSStartTask.fromMgmtStartTask(mgmtStartTask);

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void FromMgmtStartTask_VerifyPSStartTaskType()
        {
            // Arrange
            var mgmtStartTask = new StartTask(commandLine: "echo 'test'");

            // Act
            var result = PSStartTask.fromMgmtStartTask(mgmtStartTask);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PSStartTask>(result);
        }

        [Fact]
        public void FromMgmtStartTask_WithDefaultConstructor_HandlesCorrectly()
        {
            // Arrange
            var mgmtStartTask = new StartTask(); // Uses default constructor
            mgmtStartTask.CommandLine = "echo 'default test'";

            // Act
            var result = PSStartTask.fromMgmtStartTask(mgmtStartTask);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("echo 'default test'", result.CommandLine);
            Assert.Null(result.ContainerSettings);
            Assert.Null(result.EnvironmentSettings);
            Assert.Null(result.MaxTaskRetryCount);
            Assert.Null(result.ResourceFiles);
            Assert.Null(result.UserIdentity);
            Assert.Null(result.WaitForSuccess);
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

            var originalContainerSettings = new PSTaskContainerSettings(
                imageName: "ubuntu:20.04",
                containerRunOptions: "--rm --network host",
                registry: originalRegistry,
                workingDirectory: Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.TaskWorkingDirectory);

            var originalAutoUserSpec = new PSAutoUserSpecification(
                scope: Microsoft.Azure.Batch.Common.AutoUserScope.Task,
                elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.Admin);
            var originalUserIdentity = new PSUserIdentity(originalAutoUserSpec);

            var originalEnvironmentSettings = new Dictionary<string, string>
            {
                { "PATH", "/usr/local/bin:/usr/bin:/bin" },
                { "HOME", "/home/user" },
                { "LANG", "en_US.UTF-8" }
            };

            var originalPsStartTask = new PSStartTask("echo 'Starting batch task'")
            {
                ContainerSettings = originalContainerSettings,
                EnvironmentSettings = originalEnvironmentSettings,
                MaxTaskRetryCount = 3,
                UserIdentity = originalUserIdentity,
                WaitForSuccess = true
            };

            // Act
            var mgmtStartTask = originalPsStartTask.toMgmtStartTask();
            var roundTripPsStartTask = PSStartTask.fromMgmtStartTask(mgmtStartTask);

            // Assert
            Assert.NotNull(roundTripPsStartTask);
            Assert.Equal(originalPsStartTask.CommandLine, roundTripPsStartTask.CommandLine);
            Assert.Equal(originalPsStartTask.MaxTaskRetryCount, roundTripPsStartTask.MaxTaskRetryCount);
            Assert.Equal(originalPsStartTask.WaitForSuccess, roundTripPsStartTask.WaitForSuccess);

            // Verify container settings round-trip
            Assert.NotNull(roundTripPsStartTask.ContainerSettings);
            Assert.Equal(originalPsStartTask.ContainerSettings.ImageName, roundTripPsStartTask.ContainerSettings.ImageName);
            Assert.Equal(originalPsStartTask.ContainerSettings.ContainerRunOptions, roundTripPsStartTask.ContainerSettings.ContainerRunOptions);
            Assert.Equal(originalPsStartTask.ContainerSettings.WorkingDirectory, roundTripPsStartTask.ContainerSettings.WorkingDirectory);

            // Verify user identity round-trip
            Assert.NotNull(roundTripPsStartTask.UserIdentity);
            Assert.NotNull(roundTripPsStartTask.UserIdentity.AutoUser);
            Assert.Equal(originalPsStartTask.UserIdentity.AutoUser.Scope, roundTripPsStartTask.UserIdentity.AutoUser.Scope);
            Assert.Equal(originalPsStartTask.UserIdentity.AutoUser.ElevationLevel, roundTripPsStartTask.UserIdentity.AutoUser.ElevationLevel);

            // Verify environment settings round-trip
            Assert.NotNull(roundTripPsStartTask.EnvironmentSettings);
            Assert.Equal(originalPsStartTask.EnvironmentSettings.Count, roundTripPsStartTask.EnvironmentSettings.Count);
            foreach (DictionaryEntry entry in originalPsStartTask.EnvironmentSettings)
            {
                Assert.Equal(entry.Value, roundTripPsStartTask.EnvironmentSettings[entry.Key]);
            }
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesMinimalProperties()
        {
            // Arrange
            var originalPsStartTask = new PSStartTask("echo 'simple test'");

            // Act
            var mgmtStartTask = originalPsStartTask.toMgmtStartTask();
            var roundTripPsStartTask = PSStartTask.fromMgmtStartTask(mgmtStartTask);

            // Assert
            Assert.NotNull(roundTripPsStartTask);
            Assert.Equal(originalPsStartTask.CommandLine, roundTripPsStartTask.CommandLine);
            Assert.Null(roundTripPsStartTask.ContainerSettings);
            Assert.Null(roundTripPsStartTask.EnvironmentSettings);
            Assert.Null(roundTripPsStartTask.MaxTaskRetryCount);
            Assert.Null(roundTripPsStartTask.ResourceFiles);
            Assert.Null(roundTripPsStartTask.UserIdentity);
            Assert.Null(roundTripPsStartTask.WaitForSuccess);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesNullValues()
        {
            // Arrange
            var originalPsStartTask = new PSStartTask("echo 'null test'")
            {
                ContainerSettings = null,
                EnvironmentSettings = null,
                MaxTaskRetryCount = null,
                ResourceFiles = null,
                UserIdentity = null,
                WaitForSuccess = null
            };

            // Act
            var mgmtStartTask = originalPsStartTask.toMgmtStartTask();
            var roundTripPsStartTask = PSStartTask.fromMgmtStartTask(mgmtStartTask);

            // Assert
            Assert.NotNull(roundTripPsStartTask);
            Assert.Equal(originalPsStartTask.CommandLine, roundTripPsStartTask.CommandLine);
            Assert.Null(roundTripPsStartTask.ContainerSettings);
            Assert.Null(roundTripPsStartTask.EnvironmentSettings);
            Assert.Null(roundTripPsStartTask.MaxTaskRetryCount);
            Assert.Null(roundTripPsStartTask.ResourceFiles);
            Assert.Null(roundTripPsStartTask.UserIdentity);
            Assert.Null(roundTripPsStartTask.WaitForSuccess);
        }

        [Theory]
        [InlineData("echo 'Hello World'", 0, true)]
        [InlineData("powershell -Command 'Get-Process'", 5, false)]
        [InlineData("/bin/bash -c 'ls -la'", null, null)]
        public void RoundTripConversion_AllValidValues_PreservesOriginalValue(string commandLine, int? maxRetryCount, bool? waitForSuccess)
        {
            // Arrange
            var originalPsStartTask = new PSStartTask(commandLine)
            {
                MaxTaskRetryCount = maxRetryCount,
                WaitForSuccess = waitForSuccess
            };

            // Act
            var mgmtStartTask = originalPsStartTask.toMgmtStartTask();
            var roundTripPsStartTask = PSStartTask.fromMgmtStartTask(mgmtStartTask);

            // Assert
            Assert.NotNull(roundTripPsStartTask);
            Assert.Equal(originalPsStartTask.CommandLine, roundTripPsStartTask.CommandLine);
            Assert.Equal(originalPsStartTask.MaxTaskRetryCount, roundTripPsStartTask.MaxTaskRetryCount);
            Assert.Equal(originalPsStartTask.WaitForSuccess, roundTripPsStartTask.WaitForSuccess);
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

            var originalContainerSettings = new TaskContainerSettings(
                imageName: "postgres:13",
                containerRunOptions: "--restart=unless-stopped",
                registry: originalRegistry,
                workingDirectory: ContainerWorkingDirectory.ContainerImageDefault);

            var originalAutoUserSpec = new AutoUserSpecification(
                scope: AutoUserScope.Pool,
                elevationLevel: ElevationLevel.NonAdmin);
            var originalUserIdentity = new UserIdentity(autoUser: originalAutoUserSpec);

            var originalEnvironmentSettings = new List<EnvironmentSetting>
            {
                new EnvironmentSetting("DATABASE_URL", "postgresql://user:pass@localhost:5432/db"),
                new EnvironmentSetting("LOG_LEVEL", "INFO")
            };

            var originalMgmtStartTask = new StartTask(
                commandLine: "pg_ctl start",
                environmentSettings: originalEnvironmentSettings,
                userIdentity: originalUserIdentity,
                maxTaskRetryCount: 2,
                waitForSuccess: false,
                containerSettings: originalContainerSettings);

            // Act
            var psStartTask = PSStartTask.fromMgmtStartTask(originalMgmtStartTask);
            var roundTripMgmtStartTask = psStartTask.toMgmtStartTask();

            // Assert
            Assert.NotNull(roundTripMgmtStartTask);
            Assert.Equal(originalMgmtStartTask.CommandLine, roundTripMgmtStartTask.CommandLine);
            Assert.Equal(originalMgmtStartTask.MaxTaskRetryCount, roundTripMgmtStartTask.MaxTaskRetryCount);
            Assert.Equal(originalMgmtStartTask.WaitForSuccess, roundTripMgmtStartTask.WaitForSuccess);

            // Verify container settings round-trip
            Assert.NotNull(roundTripMgmtStartTask.ContainerSettings);
            Assert.Equal(originalMgmtStartTask.ContainerSettings.ImageName, roundTripMgmtStartTask.ContainerSettings.ImageName);
            Assert.Equal(originalMgmtStartTask.ContainerSettings.ContainerRunOptions, roundTripMgmtStartTask.ContainerSettings.ContainerRunOptions);
            Assert.Equal(originalMgmtStartTask.ContainerSettings.WorkingDirectory, roundTripMgmtStartTask.ContainerSettings.WorkingDirectory);

            // Verify user identity round-trip
            Assert.NotNull(roundTripMgmtStartTask.UserIdentity);
            Assert.NotNull(roundTripMgmtStartTask.UserIdentity.AutoUser);
            Assert.Equal(originalMgmtStartTask.UserIdentity.AutoUser.Scope, roundTripMgmtStartTask.UserIdentity.AutoUser.Scope);
            Assert.Equal(originalMgmtStartTask.UserIdentity.AutoUser.ElevationLevel, roundTripMgmtStartTask.UserIdentity.AutoUser.ElevationLevel);

            // Verify environment settings round-trip
            Assert.NotNull(roundTripMgmtStartTask.EnvironmentSettings);
            Assert.Equal(originalMgmtStartTask.EnvironmentSettings.Count, roundTripMgmtStartTask.EnvironmentSettings.Count);
            var originalEnvDict = originalMgmtStartTask.EnvironmentSettings.ToDictionary(e => e.Name, e => e.Value);
            var roundTripEnvDict = roundTripMgmtStartTask.EnvironmentSettings.ToDictionary(e => e.Name, e => e.Value);
            foreach (var kvp in originalEnvDict)
            {
                Assert.Equal(kvp.Value, roundTripEnvDict[kvp.Key]);
            }
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void StartTaskConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Arrange - Test with realistic start task scenarios
            var identityResourceId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/batch-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/start-task-identity";
            var psIdentityRef = new PSComputeNodeIdentityReference { ResourceId = identityResourceId };
            var psRegistry = new PSContainerRegistry(
                userName: "batchuser",
                password: "batchpass",
                registryServer: "batchregistry.azurecr.io",
                identityReference: psIdentityRef);

            var psContainerSettings = new PSTaskContainerSettings(
                imageName: "mcr.microsoft.com/dotnet/runtime:6.0",
                containerRunOptions: "--memory=1g --cpus=0.5",
                registry: psRegistry,
                workingDirectory: Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.TaskWorkingDirectory);

            var psAutoUserSpec = new PSAutoUserSpecification(
                scope: Microsoft.Azure.Batch.Common.AutoUserScope.Pool,
                elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.Admin);
            var psUserIdentity = new PSUserIdentity(psAutoUserSpec);

            var environmentSettings = new Dictionary<string, string>
            {
                { "ASPNETCORE_ENVIRONMENT", "Production" },
                { "DOTNET_RUNNING_IN_CONTAINER", "true" },
                { "PATH", "/usr/local/sbin:/usr/local/bin:/usr/sbin:/usr/bin:/sbin:/bin" }
            };

            var psStartTask = new PSStartTask("dotnet myapp.dll")
            {
                ContainerSettings = psContainerSettings,
                EnvironmentSettings = environmentSettings,
                MaxTaskRetryCount = 2,
                UserIdentity = psUserIdentity,
                WaitForSuccess = true
            };

            // Act
            var mgmtStartTask = psStartTask.toMgmtStartTask();
            var backToPs = PSStartTask.fromMgmtStartTask(mgmtStartTask);

            // Assert
            Assert.NotNull(mgmtStartTask);
            Assert.NotNull(backToPs);

            // Verify semantic equivalence
            Assert.Equal("dotnet myapp.dll", mgmtStartTask.CommandLine);
            Assert.Equal(2, mgmtStartTask.MaxTaskRetryCount);
            Assert.Equal(true, mgmtStartTask.WaitForSuccess);
            Assert.NotNull(mgmtStartTask.ContainerSettings);
            Assert.Equal("mcr.microsoft.com/dotnet/runtime:6.0", mgmtStartTask.ContainerSettings.ImageName);
            Assert.NotNull(mgmtStartTask.UserIdentity);
            Assert.Equal(AutoUserScope.Pool, mgmtStartTask.UserIdentity.AutoUser.Scope);

            Assert.Equal("dotnet myapp.dll", backToPs.CommandLine);
            Assert.Equal(2, backToPs.MaxTaskRetryCount);
            Assert.Equal(true, backToPs.WaitForSuccess);
            Assert.NotNull(backToPs.ContainerSettings);
            Assert.Equal("mcr.microsoft.com/dotnet/runtime:6.0", backToPs.ContainerSettings.ImageName);
            Assert.NotNull(backToPs.UserIdentity);
            Assert.Equal(Microsoft.Azure.Batch.Common.AutoUserScope.Pool, backToPs.UserIdentity.AutoUser.Scope);
        }

        [Fact]
        public void StartTaskConversions_BatchPoolContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Batch pool configuration
            // StartTask is used to configure initialization tasks that run when compute nodes join a pool

            // Arrange - Test with different start task scenarios
            var scenarios = new[]
            {
                // Node setup scenario
                new {
                    CommandLine = "apt-get update && apt-get install -y python3 python3-pip",
                    MaxRetryCount = 0,
                    WaitForSuccess = true,
                    Description = "Node setup with package installation"
                },
                // Application deployment scenario  
                new {
                    CommandLine = "powershell -Command 'Invoke-WebRequest -Uri https://example.com/setup.ps1 -OutFile setup.ps1; .\\setup.ps1'",
                    MaxRetryCount = 3,
                    WaitForSuccess = true,
                    Description = "Application deployment with retry logic"
                },
                // Container preparation scenario
                new {
                    CommandLine = "docker pull myregistry.azurecr.io/myapp:latest",
                    MaxRetryCount = 2,
                    WaitForSuccess = false,
                    Description = "Container image pre-loading"
                },
                // File system preparation scenario
                new {
                    CommandLine = "/bin/bash -c 'mkdir -p /shared && chmod 777 /shared'",
                    MaxRetryCount = 1,
                    WaitForSuccess = true,
                    Description = "File system setup"
                }
            };

            foreach (var scenario in scenarios)
            {
                // Arrange
                var psStartTask = new PSStartTask(scenario.CommandLine)
                {
                    MaxTaskRetryCount = scenario.MaxRetryCount,
                    WaitForSuccess = scenario.WaitForSuccess
                };

                // Act
                var mgmtStartTask = psStartTask.toMgmtStartTask();

                // Assert - Should convert correctly for Batch pool start task configuration
                Assert.NotNull(mgmtStartTask);
                Assert.Equal(scenario.CommandLine, mgmtStartTask.CommandLine);
                Assert.Equal(scenario.MaxRetryCount, mgmtStartTask.MaxTaskRetryCount);
                Assert.Equal(scenario.WaitForSuccess, mgmtStartTask.WaitForSuccess);

                // Verify round-trip conversion maintains start task semantics
                var backToPs = PSStartTask.fromMgmtStartTask(mgmtStartTask);
                Assert.NotNull(backToPs);
                Assert.Equal(scenario.CommandLine, backToPs.CommandLine);
                Assert.Equal(scenario.MaxRetryCount, backToPs.MaxTaskRetryCount);
                Assert.Equal(scenario.WaitForSuccess, backToPs.WaitForSuccess);
            }
        }

        [Fact]
        public void StartTaskConversions_InstanceCreation_VerifyBehavior()
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

            var psStartTask = new PSStartTask("echo 'test'")
            {
                ContainerSettings = psContainerSettings,
                MaxTaskRetryCount = 1
            };

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

            var mgmtStartTask = new StartTask(
                commandLine: "echo 'test'",
                containerSettings: mgmtContainerSettings,
                maxTaskRetryCount: 1);

            // Act
            var mgmtResult = psStartTask.toMgmtStartTask();
            var psResult = PSStartTask.fromMgmtStartTask(mgmtStartTask);

            // Assert - Verify proper instance creation
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.IsType<StartTask>(mgmtResult);
            Assert.IsType<PSStartTask>(psResult);

            // Verify new instances are created
            Assert.NotSame(mgmtStartTask, mgmtResult);
            Assert.NotSame(psStartTask, psResult);
        }

        #endregion

        #region Performance and Edge Case Tests

        [Fact]
        public void StartTaskConversions_PerformanceTest_ExecutesQuickly()
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

            var psContainerSettings = new PSTaskContainerSettings(
                imageName: "ubuntu:20.04",
                registry: psRegistry);

            var psAutoUserSpec = new PSAutoUserSpecification(
                scope: Microsoft.Azure.Batch.Common.AutoUserScope.Task,
                elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.Admin);
            var psUserIdentity = new PSUserIdentity(psAutoUserSpec);

            var psStartTask = new PSStartTask("echo 'performance test'")
            {
                ContainerSettings = psContainerSettings,
                UserIdentity = psUserIdentity,
                MaxTaskRetryCount = 1
            };

            var mgmtIdentityRef = new ComputeNodeIdentityReference(identityResourceId);
            var mgmtRegistry = new ContainerRegistry(
                userName: "testuser",
                password: "testpass",
                registryServer: "test.azurecr.io",
                identityReference: mgmtIdentityRef);

            var mgmtContainerSettings = new TaskContainerSettings(
                imageName: "ubuntu:20.04",
                registry: mgmtRegistry);

            var mgmtAutoUserSpec = new AutoUserSpecification(
                scope: AutoUserScope.Task,
                elevationLevel: ElevationLevel.Admin);
            var mgmtUserIdentity = new UserIdentity(autoUser: mgmtAutoUserSpec);

            var mgmtStartTask = new StartTask(
                commandLine: "echo 'performance test'",
                containerSettings: mgmtContainerSettings,
                userIdentity: mgmtUserIdentity,
                maxTaskRetryCount: 1);

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 100; i++)
            {
                var mgmtResult = psStartTask.toMgmtStartTask();
                var psResult = PSStartTask.fromMgmtStartTask(mgmtStartTask);

                Assert.NotNull(mgmtResult);
                Assert.NotNull(psResult);
                Assert.Equal("echo 'performance test'", mgmtResult.CommandLine);
                Assert.Equal("echo 'performance test'", psResult.CommandLine);
            }
        }

        [Fact]
        public void StartTaskConversions_EdgeCaseCommandLines_HandleCorrectly()
        {
            // Test conversion with various edge case command lines

            var testCommandLines = new[]
            {
                // Standard commands
                "echo 'Hello World'",
                "powershell -Command 'Get-Process'",
                "/bin/bash -c 'ls -la'",
                
                // Commands with special characters
                "echo 'Hello \"World\" with quotes'",
                "cmd /c echo Special chars: !@#$%^&*()",
                "/bin/sh -c 'echo $HOME && echo $USER'",
                
                // Long commands
                "powershell -Command 'Get-ChildItem -Path C:\\ -Recurse -ErrorAction SilentlyContinue | Where-Object { $_.LastWriteTime -gt (Get-Date).AddDays(-30) } | Sort-Object LastWriteTime -Descending'",
                
                // Multi-line equivalent commands
                "cmd /c \"echo Line 1 && echo Line 2 && echo Line 3\"",
                
                // Container-specific commands
                "docker run --rm hello-world",
                "kubectl apply -f deployment.yaml",
                
                // Package installation commands
                "apt-get update && apt-get install -y curl wget",
                "yum update -y && yum install -y git",
                "pip install -r requirements.txt",
                
                // File operations
                "mkdir -p /shared/data && chmod 755 /shared/data",
                "curl -o setup.sh https://example.com/setup.sh && chmod +x setup.sh && ./setup.sh",
                
                // Empty command
                "",
                
                // Single character
                "a"
            };

            foreach (var commandLine in testCommandLines)
            {
                // Arrange
                var psStartTask = new PSStartTask(commandLine);

                // Act
                var mgmtResult = psStartTask.toMgmtStartTask();
                var roundTripResult = PSStartTask.fromMgmtStartTask(mgmtResult);

                // Assert
                Assert.NotNull(mgmtResult);
                Assert.NotNull(roundTripResult);
                Assert.Equal(commandLine, mgmtResult.CommandLine);
                Assert.Equal(commandLine, roundTripResult.CommandLine);
            }
        }

        [Fact]
        public void StartTaskConversions_DefaultAndNullValues_HandleCorrectly()
        {
            // Test conversion with default and null values

            // Scenario 1: Default constructor
            var defaultPsStartTask = new PSStartTask();
            defaultPsStartTask.CommandLine = "echo 'default test'";

            var mgmtDefaultResult = defaultPsStartTask.toMgmtStartTask();
            Assert.NotNull(mgmtDefaultResult);
            Assert.Equal("echo 'default test'", mgmtDefaultResult.CommandLine);

            // Scenario 2: Default management StartTask
            var defaultMgmtStartTask = new StartTask();
            defaultMgmtStartTask.CommandLine = "echo 'default mgmt test'";

            var psFromDefault = PSStartTask.fromMgmtStartTask(defaultMgmtStartTask);
            Assert.NotNull(psFromDefault);
            Assert.Equal("echo 'default mgmt test'", psFromDefault.CommandLine);

            // Scenario 3: Explicit null values
            var nullValuesPsStartTask = new PSStartTask("echo 'null values test'")
            {
                ContainerSettings = null,
                EnvironmentSettings = null,
                MaxTaskRetryCount = null,
                ResourceFiles = null,
                UserIdentity = null,
                WaitForSuccess = null
            };

            var mgmtNullValuesResult = nullValuesPsStartTask.toMgmtStartTask();
            Assert.NotNull(mgmtNullValuesResult);
            Assert.Equal("echo 'null values test'", mgmtNullValuesResult.CommandLine);
            Assert.Null(mgmtNullValuesResult.ContainerSettings);
            Assert.Null(mgmtNullValuesResult.EnvironmentSettings);
            Assert.Null(mgmtNullValuesResult.MaxTaskRetryCount);
            Assert.Null(mgmtNullValuesResult.ResourceFiles);
            Assert.Null(mgmtNullValuesResult.UserIdentity);
            Assert.Null(mgmtNullValuesResult.WaitForSuccess);

            var roundTripNullValues = PSStartTask.fromMgmtStartTask(mgmtNullValuesResult);
            Assert.NotNull(roundTripNullValues);
            Assert.Equal("echo 'null values test'", roundTripNullValues.CommandLine);
            Assert.Null(roundTripNullValues.ContainerSettings);
            Assert.Null(roundTripNullValues.EnvironmentSettings);
            Assert.Null(roundTripNullValues.MaxTaskRetryCount);
            Assert.Null(roundTripNullValues.ResourceFiles);
            Assert.Null(roundTripNullValues.UserIdentity);
            Assert.Null(roundTripNullValues.WaitForSuccess);
        }

        #endregion
    }
}