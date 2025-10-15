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

using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ModelsConversions
{
    public class PSNfsMountConfigurationTests
    {
        #region toMgmtNfsMountConfiguration Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtNfsMountConfiguration_WithAllProperties_ConvertsCorrectly()
        {
            // Arrange
            var psConfig = new PSNfsMountConfiguration(
                source: "nfs.example.com:/data",
                relativeMountPath: "nfs-data",
                mountOptions: "vers=4.1,rsize=1048576,wsize=1048576,hard,intr,timeo=600");

            // Act
            var mgmtConfig = psConfig.toMgmtNfsMountConfiguration();

            // Assert
            Assert.NotNull(mgmtConfig);
            Assert.Equal("nfs.example.com:/data", mgmtConfig.Source);
            Assert.Equal("nfs-data", mgmtConfig.RelativeMountPath);
            Assert.Equal("vers=4.1,rsize=1048576,wsize=1048576,hard,intr,timeo=600", mgmtConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtNfsMountConfiguration_WithoutMountOptions_ConvertsCorrectly()
        {
            // Arrange
            var psConfig = new PSNfsMountConfiguration(
                source: "nfs.example.com:/shared",
                relativeMountPath: "shared",
                mountOptions: null);

            // Act
            var mgmtConfig = psConfig.toMgmtNfsMountConfiguration();

            // Assert
            Assert.NotNull(mgmtConfig);
            Assert.Equal("nfs.example.com:/shared", mgmtConfig.Source);
            Assert.Equal("shared", mgmtConfig.RelativeMountPath);
            Assert.Null(mgmtConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtNfsMountConfiguration_WithEmptyMountOptions_ConvertsCorrectly()
        {
            // Arrange
            var psConfig = new PSNfsMountConfiguration(
                source: "192.168.1.100:/exports/data",
                relativeMountPath: "network-data",
                mountOptions: "");

            // Act
            var mgmtConfig = psConfig.toMgmtNfsMountConfiguration();

            // Assert
            Assert.NotNull(mgmtConfig);
            Assert.Equal("192.168.1.100:/exports/data", mgmtConfig.Source);
            Assert.Equal("network-data", mgmtConfig.RelativeMountPath);
            Assert.Equal("", mgmtConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtNfsMountConfiguration_WithMinimalConfiguration_ConvertsCorrectly()
        {
            // Arrange - Using constructor without mount options parameter
            var psConfig = new PSNfsMountConfiguration(
                source: "nfs-server:/volume1",
                relativeMountPath: "volume1");

            // Act
            var mgmtConfig = psConfig.toMgmtNfsMountConfiguration();

            // Assert
            Assert.NotNull(mgmtConfig);
            Assert.Equal("nfs-server:/volume1", mgmtConfig.Source);
            Assert.Equal("volume1", mgmtConfig.RelativeMountPath);
            Assert.Null(mgmtConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtNfsMountConfiguration_AlwaysCreatesNewInstance()
        {
            // Arrange
            var psConfig = new PSNfsMountConfiguration(
                source: "nfs.example.com:/data",
                relativeMountPath: "data");

            // Act
            var mgmtConfig1 = psConfig.toMgmtNfsMountConfiguration();
            var mgmtConfig2 = psConfig.toMgmtNfsMountConfiguration();

            // Assert
            Assert.NotNull(mgmtConfig1);
            Assert.NotNull(mgmtConfig2);
            Assert.NotSame(mgmtConfig1, mgmtConfig2);
            Assert.Equal(mgmtConfig1.Source, mgmtConfig2.Source);
            Assert.Equal(mgmtConfig1.RelativeMountPath, mgmtConfig2.RelativeMountPath);
            Assert.Equal(mgmtConfig1.MountOptions, mgmtConfig2.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtNfsMountConfiguration_VerifyReturnType()
        {
            // Arrange
            var psConfig = new PSNfsMountConfiguration(
                source: "nfs.example.com:/test",
                relativeMountPath: "test");

            // Act
            var mgmtConfig = psConfig.toMgmtNfsMountConfiguration();

            // Assert
            Assert.NotNull(mgmtConfig);
            Assert.IsType<NFSMountConfiguration>(mgmtConfig);
            Assert.IsAssignableFrom<NFSMountConfiguration>(mgmtConfig);
        }

        #endregion

        #region fromMgmtNfsMountConfiguration Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtNfsMountConfiguration_WithNull_ReturnsNull()
        {
            // Act
            var result = PSNfsMountConfiguration.fromMgmtNfsMountConfiguration(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtNfsMountConfiguration_WithAllProperties_ConvertsCorrectly()
        {
            // Arrange
            var mgmtConfig = new NFSMountConfiguration(
                source: "nfs.example.com:/data",
                relativeMountPath: "nfs-data",
                mountOptions: "vers=4.1,rsize=1048576,wsize=1048576,hard,intr,timeo=600");

            // Act
            var psConfig = PSNfsMountConfiguration.fromMgmtNfsMountConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig);
            Assert.Equal("nfs.example.com:/data", psConfig.Source);
            Assert.Equal("nfs-data", psConfig.RelativeMountPath);
            Assert.Equal("vers=4.1,rsize=1048576,wsize=1048576,hard,intr,timeo=600", psConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtNfsMountConfiguration_WithoutMountOptions_ConvertsCorrectly()
        {
            // Arrange
            var mgmtConfig = new NFSMountConfiguration(
                source: "nfs.example.com:/shared",
                relativeMountPath: "shared",
                mountOptions: null);

            // Act
            var psConfig = PSNfsMountConfiguration.fromMgmtNfsMountConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig);
            Assert.Equal("nfs.example.com:/shared", psConfig.Source);
            Assert.Equal("shared", psConfig.RelativeMountPath);
            Assert.Null(psConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtNfsMountConfiguration_WithEmptyMountOptions_ConvertsCorrectly()
        {
            // Arrange
            var mgmtConfig = new NFSMountConfiguration(
                source: "192.168.1.100:/exports/data",
                relativeMountPath: "network-data",
                mountOptions: "");

            // Act
            var psConfig = PSNfsMountConfiguration.fromMgmtNfsMountConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig);
            Assert.Equal("192.168.1.100:/exports/data", psConfig.Source);
            Assert.Equal("network-data", psConfig.RelativeMountPath);
            Assert.Equal("", psConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtNfsMountConfiguration_WithMinimalConfiguration_ConvertsCorrectly()
        {
            // Arrange
            var mgmtConfig = new NFSMountConfiguration(
                source: "nfs-server:/volume1",
                relativeMountPath: "volume1");

            // Act
            var psConfig = PSNfsMountConfiguration.fromMgmtNfsMountConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig);
            Assert.Equal("nfs-server:/volume1", psConfig.Source);
            Assert.Equal("volume1", psConfig.RelativeMountPath);
            Assert.Null(psConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtNfsMountConfiguration_StaticMethod_DoesNotRequireInstance()
        {
            // Arrange
            var mgmtConfig = new NFSMountConfiguration(
                source: "nfs.test.com:/data",
                relativeMountPath: "test-data",
                mountOptions: "vers=3");

            // Act - Call static method directly on class
            var psConfig = PSNfsMountConfiguration.fromMgmtNfsMountConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig);
            Assert.Equal("nfs.test.com:/data", psConfig.Source);
            Assert.Equal("test-data", psConfig.RelativeMountPath);
            Assert.Equal("vers=3", psConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtNfsMountConfiguration_AlwaysCreatesNewInstance()
        {
            // Arrange
            var mgmtConfig = new NFSMountConfiguration(
                source: "nfs.example.com:/data",
                relativeMountPath: "data",
                mountOptions: "vers=4");

            // Act
            var psConfig1 = PSNfsMountConfiguration.fromMgmtNfsMountConfiguration(mgmtConfig);
            var psConfig2 = PSNfsMountConfiguration.fromMgmtNfsMountConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig1);
            Assert.NotNull(psConfig2);
            Assert.NotSame(psConfig1, psConfig2);
            Assert.Equal(psConfig1.Source, psConfig2.Source);
            Assert.Equal(psConfig1.RelativeMountPath, psConfig2.RelativeMountPath);
            Assert.Equal(psConfig1.MountOptions, psConfig2.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtNfsMountConfiguration_VerifyReturnType()
        {
            // Arrange
            var mgmtConfig = new NFSMountConfiguration(
                source: "nfs.example.com:/test",
                relativeMountPath: "test");

            // Act
            var psConfig = PSNfsMountConfiguration.fromMgmtNfsMountConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig);
            Assert.IsType<PSNfsMountConfiguration>(psConfig);
            Assert.IsAssignableFrom<PSNfsMountConfiguration>(psConfig);
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesAllProperties()
        {
            // Arrange
            var originalPsConfig = new PSNfsMountConfiguration(
                source: "nfs.example.com:/data",
                relativeMountPath: "nfs-data",
                mountOptions: "vers=4.1,rsize=1048576,wsize=1048576,hard,intr,timeo=600");

            // Act
            var mgmtConfig = originalPsConfig.toMgmtNfsMountConfiguration();
            var roundTripPsConfig = PSNfsMountConfiguration.fromMgmtNfsMountConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(roundTripPsConfig);
            Assert.Equal(originalPsConfig.Source, roundTripPsConfig.Source);
            Assert.Equal(originalPsConfig.RelativeMountPath, roundTripPsConfig.RelativeMountPath);
            Assert.Equal(originalPsConfig.MountOptions, roundTripPsConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesNullMountOptions()
        {
            // Arrange
            var originalPsConfig = new PSNfsMountConfiguration(
                source: "nfs.example.com:/shared",
                relativeMountPath: "shared",
                mountOptions: null);

            // Act
            var mgmtConfig = originalPsConfig.toMgmtNfsMountConfiguration();
            var roundTripPsConfig = PSNfsMountConfiguration.fromMgmtNfsMountConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(roundTripPsConfig);
            Assert.Equal(originalPsConfig.Source, roundTripPsConfig.Source);
            Assert.Equal(originalPsConfig.RelativeMountPath, roundTripPsConfig.RelativeMountPath);
            Assert.Null(roundTripPsConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesEmptyMountOptions()
        {
            // Arrange
            var originalPsConfig = new PSNfsMountConfiguration(
                source: "192.168.1.100:/exports/data",
                relativeMountPath: "network-data",
                mountOptions: "");

            // Act
            var mgmtConfig = originalPsConfig.toMgmtNfsMountConfiguration();
            var roundTripPsConfig = PSNfsMountConfiguration.fromMgmtNfsMountConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(roundTripPsConfig);
            Assert.Equal(originalPsConfig.Source, roundTripPsConfig.Source);
            Assert.Equal(originalPsConfig.RelativeMountPath, roundTripPsConfig.RelativeMountPath);
            Assert.Equal("", roundTripPsConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesAllProperties()
        {
            // Arrange
            var originalMgmtConfig = new NFSMountConfiguration(
                source: "nfs.example.com:/data",
                relativeMountPath: "nfs-data",
                mountOptions: "vers=4.1,rsize=1048576,wsize=1048576,hard,intr,timeo=600");

            // Act
            var psConfig = PSNfsMountConfiguration.fromMgmtNfsMountConfiguration(originalMgmtConfig);
            var roundTripMgmtConfig = psConfig.toMgmtNfsMountConfiguration();

            // Assert
            Assert.NotNull(roundTripMgmtConfig);
            Assert.Equal(originalMgmtConfig.Source, roundTripMgmtConfig.Source);
            Assert.Equal(originalMgmtConfig.RelativeMountPath, roundTripMgmtConfig.RelativeMountPath);
            Assert.Equal(originalMgmtConfig.MountOptions, roundTripMgmtConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesNullMountOptions()
        {
            // Arrange
            var originalMgmtConfig = new NFSMountConfiguration(
                source: "nfs.example.com:/shared",
                relativeMountPath: "shared",
                mountOptions: null);

            // Act
            var psConfig = PSNfsMountConfiguration.fromMgmtNfsMountConfiguration(originalMgmtConfig);
            var roundTripMgmtConfig = psConfig.toMgmtNfsMountConfiguration();

            // Assert
            Assert.NotNull(roundTripMgmtConfig);
            Assert.Equal(originalMgmtConfig.Source, roundTripMgmtConfig.Source);
            Assert.Equal(originalMgmtConfig.RelativeMountPath, roundTripMgmtConfig.RelativeMountPath);
            Assert.Null(roundTripMgmtConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesEmptyMountOptions()
        {
            // Arrange
            var originalMgmtConfig = new NFSMountConfiguration(
                source: "192.168.1.100:/exports/data",
                relativeMountPath: "network-data",
                mountOptions: "");

            // Act
            var psConfig = PSNfsMountConfiguration.fromMgmtNfsMountConfiguration(originalMgmtConfig);
            var roundTripMgmtConfig = psConfig.toMgmtNfsMountConfiguration();

            // Assert
            Assert.NotNull(roundTripMgmtConfig);
            Assert.Equal(originalMgmtConfig.Source, roundTripMgmtConfig.Source);
            Assert.Equal(originalMgmtConfig.RelativeMountPath, roundTripMgmtConfig.RelativeMountPath);
            Assert.Equal("", roundTripMgmtConfig.MountOptions);
        }

        #endregion

        #region Integration Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NfsMountConfigurationConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions for Azure Batch NFS file system mounting

            // Test various NFS mount scenarios
            var nfsScenarios = new[]
            {
                new {
                    Source = "nfs.example.com:/data",
                    RelativeMountPath = "shared-data",
                    MountOptions = "vers=4.1,rsize=1048576,wsize=1048576,hard,intr,timeo=600",
                    Description = "High-performance NFS v4.1 mount with optimized read/write sizes"
                },
                new {
                    Source = "192.168.1.100:/exports/ml-datasets",
                    RelativeMountPath = "datasets",
                    MountOptions = "vers=3,soft,rsize=32768,wsize=32768",
                    Description = "NFS v3 mount for machine learning datasets with soft mount"
                },
                new {
                    Source = "nfs-server.local:/volume1/projects",
                    RelativeMountPath = "projects",
                    MountOptions = (string)null,
                    Description = "Basic NFS mount without specific options"
                },
                new {
                    Source = "nfs.azure.com:/premium-storage",
                    RelativeMountPath = "premium",
                    MountOptions = "vers=4.0,proto=tcp,port=2049,bg,hard,intr",
                    Description = "Azure NFS premium storage with TCP protocol and background mount"
                }
            };

            foreach (var scenario in nfsScenarios)
            {
                // Act - PS to Management conversion
                var psConfig = new PSNfsMountConfiguration(
                    source: scenario.Source,
                    relativeMountPath: scenario.RelativeMountPath,
                    mountOptions: scenario.MountOptions);

                var mgmtConfig = psConfig.toMgmtNfsMountConfiguration();
                var backToPs = PSNfsMountConfiguration.fromMgmtNfsMountConfiguration(mgmtConfig);

                // Assert - Verify semantic equivalence
                Assert.NotNull(mgmtConfig);
                Assert.Equal(scenario.Source, mgmtConfig.Source);
                Assert.Equal(scenario.RelativeMountPath, mgmtConfig.RelativeMountPath);
                Assert.Equal(scenario.MountOptions, mgmtConfig.MountOptions);

                Assert.NotNull(backToPs);
                Assert.Equal(scenario.Source, backToPs.Source);
                Assert.Equal(scenario.RelativeMountPath, backToPs.RelativeMountPath);
                Assert.Equal(scenario.MountOptions, backToPs.MountOptions);

                // Act - Management to PS conversion
                var originalMgmtConfig = new NFSMountConfiguration(
                    source: scenario.Source,
                    relativeMountPath: scenario.RelativeMountPath,
                    mountOptions: scenario.MountOptions);

                var mgmtToPs = PSNfsMountConfiguration.fromMgmtNfsMountConfiguration(originalMgmtConfig);
                var backToMgmt = mgmtToPs.toMgmtNfsMountConfiguration();

                // Assert - Verify semantic equivalence in reverse direction
                Assert.NotNull(mgmtToPs);
                Assert.Equal(scenario.Source, mgmtToPs.Source);
                Assert.Equal(scenario.RelativeMountPath, mgmtToPs.RelativeMountPath);
                Assert.Equal(scenario.MountOptions, mgmtToPs.MountOptions);

                Assert.NotNull(backToMgmt);
                Assert.Equal(scenario.Source, backToMgmt.Source);
                Assert.Equal(scenario.RelativeMountPath, backToMgmt.RelativeMountPath);
                Assert.Equal(scenario.MountOptions, backToMgmt.MountOptions);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NfsMountConfigurationConversions_NullHandling_WorksCorrectly()
        {
            // Test null handling in conversions

            // Act
            var resultFromNull = PSNfsMountConfiguration.fromMgmtNfsMountConfiguration(null);

            // Assert
            Assert.Null(resultFromNull);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NfsMountConfigurationConversions_BatchPoolContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Azure Batch pool mount configuration
            // NfsMountConfiguration is used to mount NFS file systems on Batch compute nodes for distributed storage access

            // Arrange - Test high-performance computing (HPC) workload scenarios
            var hpcScenarios = new PSNfsMountConfiguration[]
            {
                new PSNfsMountConfiguration(
                    source: "hpc-nfs.example.com:/shared/scratch",
                    relativeMountPath: "scratch",
                    mountOptions: "vers=4.1,rsize=1048576,wsize=1048576,hard,intr,timeo=600,retrans=2"
                    ),
                new PSNfsMountConfiguration(
                    source: "nfs.example.com:/datasets/genomics",
                    relativeMountPath: "genomics-data",
                    mountOptions: "vers=3,rsize=65536,wsize=65536,soft,timeo=300"
                    ),
                new PSNfsMountConfiguration(
                    source: "storage.local:/exports/results",
                    relativeMountPath: "results",
                    mountOptions: null
                    ),
                new PSNfsMountConfiguration(
                    source: "192.168.10.50:/mnt/shared-cache",
                    relativeMountPath: "cache",
                    mountOptions: "vers=4.0,proto=tcp,fsc,local_lock=none"
                 )
            };

            foreach (var scenario in hpcScenarios)
            {
                // Arrange
                var psNfsConfig = new PSNfsMountConfiguration(
                    source: scenario.Source,
                    relativeMountPath: scenario.RelativeMountPath,
                    mountOptions: scenario.MountOptions);

                // Act
                var mgmtNfsConfig = psNfsConfig.toMgmtNfsMountConfiguration();

                // Assert - Should convert correctly for Batch pool mount configuration
                Assert.NotNull(mgmtNfsConfig);
                Assert.Equal(scenario.Source, mgmtNfsConfig.Source);
                Assert.Equal(scenario.RelativeMountPath, mgmtNfsConfig.RelativeMountPath);
                Assert.Equal(scenario.MountOptions, mgmtNfsConfig.MountOptions);

                // Verify round-trip conversion maintains Batch pool semantics
                var backToPs = PSNfsMountConfiguration.fromMgmtNfsMountConfiguration(mgmtNfsConfig);
                Assert.NotNull(backToPs);
                Assert.Equal(scenario.Source, backToPs.Source);
                Assert.Equal(scenario.RelativeMountPath, backToPs.RelativeMountPath);
                Assert.Equal(scenario.MountOptions, backToPs.MountOptions);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NfsMountConfigurationConversions_InstanceCreation_VerifyBehavior()
        {
            // This test verifies that the conversion methods create appropriate instances

            // Arrange
            var psConfig = new PSNfsMountConfiguration(
                source: "nfs.example.com:/data",
                relativeMountPath: "data",
                mountOptions: "vers=4");

            var mgmtConfig = new NFSMountConfiguration(
                source: "nfs.test.com:/volume",
                relativeMountPath: "volume",
                mountOptions: "vers=3");

            // Act
            var mgmtResult = psConfig.toMgmtNfsMountConfiguration();
            var psResult = PSNfsMountConfiguration.fromMgmtNfsMountConfiguration(mgmtConfig);

            // Assert - Verify proper instance creation
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.IsType<NFSMountConfiguration>(mgmtResult);
            Assert.IsType<PSNfsMountConfiguration>(psResult);

            // Verify new instances are created
            Assert.NotSame(mgmtConfig, mgmtResult);
            Assert.NotSame(psConfig, psResult);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NfsMountConfigurationConversions_EdgeCaseValues_HandleCorrectly()
        {
            // Test conversion with various edge case values

            var testConfigurations = new[]
            {
                // Standard configurations
                new { Source = "nfs.example.com:/data", RelativeMountPath = "data", MountOptions = "vers=4.1" },
                new { Source = "192.168.1.100:/exports", RelativeMountPath = "exports", MountOptions = "vers=3" },
                // Edge cases
                new { Source = "", RelativeMountPath = "", MountOptions = "" },
                new { Source = "nfs://server/path", RelativeMountPath = "path", MountOptions = (string)null },
                new { Source = "   ", RelativeMountPath = "   ", MountOptions = "   " }, // Whitespace
                new { Source = "very-long-nfs-server-name.example.com:/very/long/path/to/shared/directory", RelativeMountPath = "very-long-relative-mount-path-for-testing", MountOptions = "vers=4.1,rsize=1048576,wsize=1048576,hard,intr,timeo=600,retrans=2,bg,proto=tcp,port=2049,fsc,local_lock=none" }
            };

            foreach (var testConfig in testConfigurations)
            {
                // Arrange
                var psConfig = new PSNfsMountConfiguration(
                    source: testConfig.Source,
                    relativeMountPath: testConfig.RelativeMountPath,
                    mountOptions: testConfig.MountOptions);

                var mgmtConfig = new NFSMountConfiguration(
                    source: testConfig.Source,
                    relativeMountPath: testConfig.RelativeMountPath,
                    mountOptions: testConfig.MountOptions);

                // Act
                var mgmtResult = psConfig.toMgmtNfsMountConfiguration();
                var psFromMgmtResult = PSNfsMountConfiguration.fromMgmtNfsMountConfiguration(mgmtConfig);
                var roundTripResult = PSNfsMountConfiguration.fromMgmtNfsMountConfiguration(mgmtResult);

                // Assert
                Assert.NotNull(mgmtResult);
                Assert.NotNull(psFromMgmtResult);
                Assert.NotNull(roundTripResult);

                Assert.Equal(testConfig.Source, mgmtResult.Source);
                Assert.Equal(testConfig.RelativeMountPath, mgmtResult.RelativeMountPath);
                Assert.Equal(testConfig.MountOptions, mgmtResult.MountOptions);

                Assert.Equal(testConfig.Source, psFromMgmtResult.Source);
                Assert.Equal(testConfig.RelativeMountPath, psFromMgmtResult.RelativeMountPath);
                Assert.Equal(testConfig.MountOptions, psFromMgmtResult.MountOptions);

                Assert.Equal(testConfig.Source, roundTripResult.Source);
                Assert.Equal(testConfig.RelativeMountPath, roundTripResult.RelativeMountPath);
                Assert.Equal(testConfig.MountOptions, roundTripResult.MountOptions);
            }
        }

        #endregion

        #region Performance and Validation Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NfsMountConfigurationConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient with multiple operations

            // Arrange
            var psConfigs = new List<PSNfsMountConfiguration>();
            var mgmtConfigs = new List<NFSMountConfiguration>();

            for (int i = 0; i < 100; i++)
            {
                psConfigs.Add(new PSNfsMountConfiguration(
                    source: $"nfs{i}.example.com:/data{i}",
                    relativeMountPath: $"data{i}",
                    mountOptions: $"vers=4.{i % 2},rsize={1024 * (i + 1)},wsize={1024 * (i + 1)}"));

                mgmtConfigs.Add(new NFSMountConfiguration(
                    source: $"mgmt-nfs{i}.example.com:/volume{i}",
                    relativeMountPath: $"volume{i}",
                    mountOptions: $"vers=3,timeo={300 + i}"));
            }

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 10; i++)
            {
                foreach (var psConfig in psConfigs)
                {
                    var mgmtResult = psConfig.toMgmtNfsMountConfiguration();
                    Assert.NotNull(mgmtResult);
                }

                foreach (var mgmtConfig in mgmtConfigs)
                {
                    var psResult = PSNfsMountConfiguration.fromMgmtNfsMountConfiguration(mgmtConfig);
                    Assert.NotNull(psResult);
                }
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NfsMountConfigurationConversions_RealWorldNfsOptions_HandleCorrectly()
        {
            // Test with realistic NFS mount options that would be used in production

            var realWorldConfigurations = new PSNfsMountConfiguration[]
            {
                // High-performance computing scenario
                new PSNfsMountConfiguration(
                    source: "hpc-nfs.example.com:/gpfs/scratch",
                    relativeMountPath: "scratch",
                    mountOptions: "vers=4.1,rsize=1048576,wsize=1048576,hard,intr,timeo=600,retrans=2,proto=tcp,fsc"
                ),
                // Machine learning data lake scenario
                new PSNfsMountConfiguration(
                    source: "ml-data.azure.com:/datasets",
                    relativeMountPath: "ml-datasets",
                    mountOptions: "vers=4.0,rsize=65536,wsize=65536,hard,intr,timeo=300,bg,proto=tcp,port=2049"
                ),
                // Bioinformatics reference data scenario
                new PSNfsMountConfiguration(
                    source: "bioref.example.com:/reference/genomes",
                    relativeMountPath: "reference-genomes",
                    mountOptions: "vers=3,rsize=32768,wsize=32768,soft,timeo=100,retrans=3,ro"
                ),
                // Financial data processing scenario
                new PSNfsMountConfiguration(
                    source: "findata.secure.com:/secure/market-data",
                    relativeMountPath: "market-data",
                    mountOptions: "vers=4.2,rsize=262144,wsize=262144,hard,intr,timeo=900,sec=krb5p"
                ),
                // Simple shared storage scenario
                new PSNfsMountConfiguration(
                    source: "shared.local:/exports/common",
                    relativeMountPath: "shared",
                    mountOptions: null
                )
            };

            foreach (var config in realWorldConfigurations)
            {
                // Arrange
                var psConfig = new PSNfsMountConfiguration(
                    source: config.Source,
                    relativeMountPath: config.RelativeMountPath,
                    mountOptions: config.MountOptions);

                // Act
                var mgmtConfig = psConfig.toMgmtNfsMountConfiguration();
                var roundTripPs = PSNfsMountConfiguration.fromMgmtNfsMountConfiguration(mgmtConfig);

                // Assert
                Assert.NotNull(mgmtConfig);
                Assert.NotNull(roundTripPs);

                Assert.Equal(config.Source, mgmtConfig.Source);
                Assert.Equal(config.RelativeMountPath, mgmtConfig.RelativeMountPath);
                Assert.Equal(config.MountOptions, mgmtConfig.MountOptions);

                Assert.Equal(config.Source, roundTripPs.Source);
                Assert.Equal(config.RelativeMountPath, roundTripPs.RelativeMountPath);
                Assert.Equal(config.MountOptions, roundTripPs.MountOptions);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NfsMountConfigurationConversions_MountPathValidation_VerifyBehavior()
        {
            // Test with various mount path formats to ensure they're preserved correctly

            var mountPathScenarios = new[]
            {
                // Standard relative paths
                new { Source = "nfs.example.com:/data", RelativeMountPath = "data", Valid = true },
                new { Source = "nfs.example.com:/shared", RelativeMountPath = "shared/subdir", Valid = true },
                new { Source = "nfs.example.com:/exports", RelativeMountPath = "exports", Valid = true },
                // Edge case paths
                new { Source = "nfs.example.com:/", RelativeMountPath = "root", Valid = true },
                new { Source = "nfs.example.com:/path with spaces", RelativeMountPath = "spaces", Valid = true },
                new { Source = "nfs.example.com:/path-with-dashes", RelativeMountPath = "dashes", Valid = true },
                new { Source = "nfs.example.com:/path_with_underscores", RelativeMountPath = "underscores", Valid = true },
                new { Source = "nfs.example.com:/123numeric", RelativeMountPath = "numeric123", Valid = true },
                // Unicode and special characters (should be preserved as-is)
                new { Source = "nfs.example.com:/café", RelativeMountPath = "café", Valid = true },
                new { Source = "nfs.example.com:/data", RelativeMountPath = "", Valid = true }, // Empty relative path
            };

            foreach (var scenario in mountPathScenarios)
            {
                // Arrange
                var psConfig = new PSNfsMountConfiguration(
                    source: scenario.Source,
                    relativeMountPath: scenario.RelativeMountPath,
                    mountOptions: "vers=4");

                // Act
                var mgmtConfig = psConfig.toMgmtNfsMountConfiguration();
                var roundTripPs = PSNfsMountConfiguration.fromMgmtNfsMountConfiguration(mgmtConfig);

                // Assert - All paths should be preserved exactly as provided
                Assert.NotNull(mgmtConfig);
                Assert.NotNull(roundTripPs);

                Assert.Equal(scenario.Source, mgmtConfig.Source);
                Assert.Equal(scenario.RelativeMountPath, mgmtConfig.RelativeMountPath);

                Assert.Equal(scenario.Source, roundTripPs.Source);
                Assert.Equal(scenario.RelativeMountPath, roundTripPs.RelativeMountPath);
            }
        }

        #endregion
    }
}