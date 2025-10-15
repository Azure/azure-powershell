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
    public class PSVirtualMachineConfigurationTests
    {
        #region toMgmtVirtualMachineConfiguration Tests

        [Fact]
        public void ToMgmtVirtualMachineConfiguration_WithMinimalConfiguration_ReturnsCorrectMapping()
        {
            // Arrange - Minimal required configuration for Batch pool VMs
            var imageRef = new PSImageReference("Canonical", "0001-com-ubuntu-server-focal", "20_04-lts-gen2");
            var nodeAgentSkuId = "batch.node.ubuntu 20.04";
            var psVmConfig = new PSVirtualMachineConfiguration(imageRef, nodeAgentSkuId);

            // Act
            var result = psVmConfig.toMgmtVirtualMachineConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.ImageReference);
            Assert.Equal(nodeAgentSkuId, result.NodeAgentSkuId);
            Assert.Null(result.WindowsConfiguration);
            Assert.Null(result.DataDisks);
            Assert.Null(result.LicenseType);
            Assert.Null(result.ContainerConfiguration);
            Assert.Null(result.DiskEncryptionConfiguration);
            Assert.Null(result.NodePlacementConfiguration);
            Assert.Null(result.Extensions);
            Assert.Null(result.OSDisk);
            Assert.Null(result.SecurityProfile);
            Assert.Null(result.ServiceArtifactReference);
        }

        [Fact]
        public void ToMgmtVirtualMachineConfiguration_WithFullConfiguration_ReturnsCorrectMapping()
        {
            // Arrange - Full configuration with all optional properties
            var imageRef = new PSImageReference("MicrosoftWindowsServer", "WindowsServer", "2019-datacenter");
            var nodeAgentSkuId = "batch.node.windows amd64";
            var psVmConfig = new PSVirtualMachineConfiguration(imageRef, nodeAgentSkuId)
            {
                WindowsConfiguration = new PSWindowsConfiguration(enableAutomaticUpdates: true),
                DataDisks = new List<PSDataDisk>
                {
                    new PSDataDisk(0, 100, Microsoft.Azure.Batch.Common.CachingType.ReadWrite, Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS)
                },
                LicenseType = "Windows_Server",
                ContainerConfiguration = new PSContainerConfiguration(),
                DiskEncryptionConfiguration = new PSDiskEncryptionConfiguration(new List<Microsoft.Azure.Batch.Common.DiskEncryptionTarget> { Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk }),
                NodePlacementConfiguration = new PSNodePlacementConfiguration(Microsoft.Azure.Batch.Common.NodePlacementPolicyType.Regional),
                Extensions = new List<PSVMExtension>
                {
                    new PSVMExtension("TestExtension", "Microsoft.Azure.Extensions", "CustomScript")
                },
                OSDisk = new PSOSDisk(),
                SecurityProfile = new PSSecurityProfile(),
                ServiceArtifactReference = new PSServiceArtifactReference("/subscriptions/test/resourceGroups/test/providers/Microsoft.Compute/galleries/test/serviceArtifacts/test/vmArtifactsProfiles/test")
            };

            // Act
            var result = psVmConfig.toMgmtVirtualMachineConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.ImageReference);
            Assert.Equal(nodeAgentSkuId, result.NodeAgentSkuId);
            Assert.NotNull(result.WindowsConfiguration);
            Assert.NotNull(result.DataDisks);
            Assert.Single(result.DataDisks);
            Assert.Equal("Windows_Server", result.LicenseType);
            Assert.NotNull(result.ContainerConfiguration);
            Assert.NotNull(result.DiskEncryptionConfiguration);
            Assert.NotNull(result.NodePlacementConfiguration);
            Assert.NotNull(result.Extensions);
            Assert.Single(result.Extensions);
            Assert.NotNull(result.OSDisk);
            Assert.NotNull(result.SecurityProfile);
            Assert.NotNull(result.ServiceArtifactReference);
        }

        [Fact]
        public void ToMgmtVirtualMachineConfiguration_WithNullOptionalProperties_HandlesCorrectly()
        {
            // Arrange - Configuration with explicitly null optional properties
            var imageRef = new PSImageReference("Canonical", "0001-com-ubuntu-server-focal", "20_04-lts-gen2");
            var nodeAgentSkuId = "batch.node.ubuntu 20.04";
            var psVmConfig = new PSVirtualMachineConfiguration(imageRef, nodeAgentSkuId)
            {
                WindowsConfiguration = null,
                DataDisks = null,
                LicenseType = null,
                ContainerConfiguration = null,
                DiskEncryptionConfiguration = null,
                NodePlacementConfiguration = null,
                Extensions = null,
                OSDisk = null,
                SecurityProfile = null,
                ServiceArtifactReference = null
            };

            // Act
            var result = psVmConfig.toMgmtVirtualMachineConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.ImageReference);
            Assert.Equal(nodeAgentSkuId, result.NodeAgentSkuId);
            Assert.Null(result.WindowsConfiguration);
            Assert.Null(result.DataDisks);
            Assert.Null(result.LicenseType);
            Assert.Null(result.ContainerConfiguration);
            Assert.Null(result.DiskEncryptionConfiguration);
            Assert.Null(result.NodePlacementConfiguration);
            Assert.Null(result.Extensions);
            Assert.Null(result.OSDisk);
            Assert.Null(result.SecurityProfile);
            Assert.Null(result.ServiceArtifactReference);
        }

        [Fact]
        public void ToMgmtVirtualMachineConfiguration_WithEmptyCollections_HandlesCorrectly()
        {
            // Arrange - Configuration with empty collections
            var imageRef = new PSImageReference("Canonical", "0001-com-ubuntu-server-focal", "20_04-lts-gen2");
            var nodeAgentSkuId = "batch.node.ubuntu 20.04";
            var psVmConfig = new PSVirtualMachineConfiguration(imageRef, nodeAgentSkuId)
            {
                DataDisks = new List<PSDataDisk>(),
                Extensions = new List<PSVMExtension>()
            };

            // Act
            var result = psVmConfig.toMgmtVirtualMachineConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.DataDisks);
            Assert.Empty(result.DataDisks);
            Assert.NotNull(result.Extensions);
            Assert.Empty(result.Extensions);
        }

        #endregion

        #region fromMgmtPSVirtualMachineConfiguration Tests

        [Fact]
        public void FromMgmtPSVirtualMachineConfiguration_WithNull_ReturnsNull()
        {
            // Act
            var result = PSVirtualMachineConfiguration.fromMgmtPSVirtualMachineConfiguration(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FromMgmtPSVirtualMachineConfiguration_WithMinimalConfiguration_ReturnsCorrectMapping()
        {
            // Arrange - Minimal required configuration
            var imageRef = new ImageReference("Canonical", "0001-com-ubuntu-server-focal", "20_04-lts-gen2");
            var nodeAgentSkuId = "batch.node.ubuntu 20.04";
            var mgmtVmConfig = new VirtualMachineConfiguration(imageRef, nodeAgentSkuId);

            // Act
            var result = PSVirtualMachineConfiguration.fromMgmtPSVirtualMachineConfiguration(mgmtVmConfig);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.ImageReference);
            Assert.Equal(nodeAgentSkuId, result.NodeAgentSkuId);
            Assert.Null(result.WindowsConfiguration);
            Assert.Null(result.DataDisks);
            Assert.Null(result.LicenseType);
            Assert.Null(result.ContainerConfiguration);
            Assert.Null(result.DiskEncryptionConfiguration);
            Assert.Null(result.NodePlacementConfiguration);
            Assert.Null(result.Extensions);
            Assert.Null(result.OSDisk);
            Assert.Null(result.SecurityProfile);
            Assert.Null(result.ServiceArtifactReference);
        }

        [Fact]
        public void FromMgmtPSVirtualMachineConfiguration_WithFullConfiguration_ReturnsCorrectMapping()
        {
            // Arrange - Full configuration with all optional properties
            var imageRef = new ImageReference("MicrosoftWindowsServer", "WindowsServer", "2019-datacenter");
            var nodeAgentSkuId = "batch.node.windows amd64";
            var mgmtVmConfig = new VirtualMachineConfiguration(
                imageReference: imageRef,
                nodeAgentSkuId: nodeAgentSkuId,
                windowsConfiguration: new WindowsConfiguration(enableAutomaticUpdates: true),
                dataDisks: new List<DataDisk>
                {
                    new DataDisk(0, 100)
                },
                licenseType: "Windows_Server",
                containerConfiguration: new ContainerConfiguration(),
                diskEncryptionConfiguration: new DiskEncryptionConfiguration(),
                nodePlacementConfiguration: new NodePlacementConfiguration(NodePlacementPolicyType.Regional),
                extensions: new List<VMExtension>
                {
                    new VMExtension("TestExtension", "Microsoft.Azure.Extensions", "CustomScript")
                },
                osDisk: new OSDisk(),
                securityProfile: new SecurityProfile(),
                serviceArtifactReference: new ServiceArtifactReference("/subscriptions/test/resourceGroups/test/providers/Microsoft.Compute/galleries/test/serviceArtifacts/test/vmArtifactsProfiles/test")
            );

            // Act
            var result = PSVirtualMachineConfiguration.fromMgmtPSVirtualMachineConfiguration(mgmtVmConfig);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.ImageReference);
            Assert.Equal(nodeAgentSkuId, result.NodeAgentSkuId);
            Assert.NotNull(result.WindowsConfiguration);
            Assert.NotNull(result.DataDisks);
            Assert.Single(result.DataDisks);
            Assert.Equal("Windows_Server", result.LicenseType);
            Assert.NotNull(result.ContainerConfiguration);
            Assert.NotNull(result.DiskEncryptionConfiguration);
            Assert.NotNull(result.NodePlacementConfiguration);
            Assert.NotNull(result.Extensions);
            Assert.Single(result.Extensions);
            Assert.NotNull(result.OSDisk);
            Assert.NotNull(result.SecurityProfile);
            Assert.NotNull(result.ServiceArtifactReference);
        }

        [Fact]
        public void FromMgmtPSVirtualMachineConfiguration_WithNullOptionalProperties_HandlesCorrectly()
        {
            // Arrange - Configuration with null optional properties
            var imageRef = new ImageReference("Canonical", "0001-com-ubuntu-server-focal", "20_04-lts-gen2");
            var nodeAgentSkuId = "batch.node.ubuntu 20.04";
            var mgmtVmConfig = new VirtualMachineConfiguration(
                imageReference: imageRef,
                nodeAgentSkuId: nodeAgentSkuId,
                windowsConfiguration: null,
                dataDisks: null,
                licenseType: null,
                containerConfiguration: null,
                diskEncryptionConfiguration: null,
                nodePlacementConfiguration: null,
                extensions: null,
                osDisk: null,
                securityProfile: null,
                serviceArtifactReference: null
            );

            // Act
            var result = PSVirtualMachineConfiguration.fromMgmtPSVirtualMachineConfiguration(mgmtVmConfig);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.ImageReference);
            Assert.Equal(nodeAgentSkuId, result.NodeAgentSkuId);
            Assert.Null(result.WindowsConfiguration);
            Assert.Null(result.DataDisks);
            Assert.Null(result.LicenseType);
            Assert.Null(result.ContainerConfiguration);
            Assert.Null(result.DiskEncryptionConfiguration);
            Assert.Null(result.NodePlacementConfiguration);
            Assert.Null(result.Extensions);
            Assert.Null(result.OSDisk);
            Assert.Null(result.SecurityProfile);
            Assert.Null(result.ServiceArtifactReference);
        }

        [Fact]
        public void FromMgmtPSVirtualMachineConfiguration_WithEmptyCollections_HandlesCorrectly()
        {
            // Arrange - Configuration with empty collections
            var imageRef = new ImageReference("Canonical", "0001-com-ubuntu-server-focal", "20_04-lts-gen2");
            var nodeAgentSkuId = "batch.node.ubuntu 20.04";
            var mgmtVmConfig = new VirtualMachineConfiguration(
                imageReference: imageRef,
                nodeAgentSkuId: nodeAgentSkuId,
                dataDisks: new List<DataDisk>(),
                extensions: new List<VMExtension>()
            );

            // Act
            var result = PSVirtualMachineConfiguration.fromMgmtPSVirtualMachineConfiguration(mgmtVmConfig);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.DataDisks);
            Assert.Empty(result.DataDisks);
            Assert.NotNull(result.Extensions);
            Assert.Empty(result.Extensions);
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesMinimalConfiguration()
        {
            // Arrange - Minimal configuration for round-trip test
            var imageRef = new PSImageReference("Canonical", "0001-com-ubuntu-server-focal", "20_04-lts-gen2");
            var nodeAgentSkuId = "batch.node.ubuntu 20.04";
            var originalPsVmConfig = new PSVirtualMachineConfiguration(imageRef, nodeAgentSkuId);

            // Act - Convert PS -> Management -> PS
            var mgmtVmConfig = originalPsVmConfig.toMgmtVirtualMachineConfiguration();
            var roundTripPsVmConfig = PSVirtualMachineConfiguration.fromMgmtPSVirtualMachineConfiguration(mgmtVmConfig);

            // Assert - Should get back equivalent values
            Assert.NotNull(roundTripPsVmConfig);
            Assert.Equal(originalPsVmConfig.NodeAgentSkuId, roundTripPsVmConfig.NodeAgentSkuId);
            Assert.NotNull(roundTripPsVmConfig.ImageReference);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesFullConfiguration()
        {
            // Arrange - Full configuration for round-trip test
            var imageRef = new PSImageReference("MicrosoftWindowsServer", "WindowsServer", "2019-datacenter");
            var nodeAgentSkuId = "batch.node.windows amd64";
            var originalPsVmConfig = new PSVirtualMachineConfiguration(imageRef, nodeAgentSkuId)
            {
                WindowsConfiguration = new PSWindowsConfiguration(enableAutomaticUpdates: true),
                DataDisks = new List<PSDataDisk>
                {
                    new PSDataDisk(0, 100, Microsoft.Azure.Batch.Common.CachingType.ReadWrite, Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS)
                },
                LicenseType = "Windows_Server",
                ContainerConfiguration = new PSContainerConfiguration(),
                DiskEncryptionConfiguration = new PSDiskEncryptionConfiguration(new List<Microsoft.Azure.Batch.Common.DiskEncryptionTarget> { Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk }),
                NodePlacementConfiguration = new PSNodePlacementConfiguration(Microsoft.Azure.Batch.Common.NodePlacementPolicyType.Regional),
                Extensions = new List<PSVMExtension>
                {
                    new PSVMExtension("TestExtension", "Microsoft.Azure.Extensions", "CustomScript")
                },
                OSDisk = new PSOSDisk(),
                SecurityProfile = new PSSecurityProfile(),
                ServiceArtifactReference = new PSServiceArtifactReference("/subscriptions/test/resourceGroups/test/providers/Microsoft.Compute/galleries/test/serviceArtifacts/test/vmArtifactsProfiles/test")
            };

            // Act - Convert PS -> Management -> PS
            var mgmtVmConfig = originalPsVmConfig.toMgmtVirtualMachineConfiguration();
            var roundTripPsVmConfig = PSVirtualMachineConfiguration.fromMgmtPSVirtualMachineConfiguration(mgmtVmConfig);

            // Assert - Should preserve all properties
            Assert.NotNull(roundTripPsVmConfig);
            Assert.Equal(originalPsVmConfig.NodeAgentSkuId, roundTripPsVmConfig.NodeAgentSkuId);
            Assert.NotNull(roundTripPsVmConfig.ImageReference);
            Assert.NotNull(roundTripPsVmConfig.WindowsConfiguration);
            Assert.NotNull(roundTripPsVmConfig.DataDisks);
            Assert.Single(roundTripPsVmConfig.DataDisks);
            Assert.Equal(originalPsVmConfig.LicenseType, roundTripPsVmConfig.LicenseType);
            Assert.NotNull(roundTripPsVmConfig.ContainerConfiguration);
            Assert.NotNull(roundTripPsVmConfig.DiskEncryptionConfiguration);
            Assert.NotNull(roundTripPsVmConfig.NodePlacementConfiguration);
            Assert.NotNull(roundTripPsVmConfig.Extensions);
            Assert.Single(roundTripPsVmConfig.Extensions);
            Assert.NotNull(roundTripPsVmConfig.OSDisk);
            Assert.NotNull(roundTripPsVmConfig.SecurityProfile);
            Assert.NotNull(roundTripPsVmConfig.ServiceArtifactReference);
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesValues()
        {
            // This test verifies that converting Management -> PS -> Management preserves the original value

            // Arrange - Management configuration
            var imageRef = new ImageReference("Canonical", "0001-com-ubuntu-server-focal", "20_04-lts-gen2");
            var nodeAgentSkuId = "batch.node.ubuntu 20.04";
            var originalMgmtConfig = new VirtualMachineConfiguration(imageRef, nodeAgentSkuId)
            {
                LicenseType = "Windows_Client"
            };

            // Act - Convert Management -> PS -> Management
            var psConfig = PSVirtualMachineConfiguration.fromMgmtPSVirtualMachineConfiguration(originalMgmtConfig);
            var roundTripMgmtConfig = psConfig.toMgmtVirtualMachineConfiguration();

            // Assert - Should get back the original values
            Assert.NotNull(roundTripMgmtConfig);
            Assert.Equal(originalMgmtConfig.NodeAgentSkuId, roundTripMgmtConfig.NodeAgentSkuId);
            Assert.Equal(originalMgmtConfig.LicenseType, roundTripMgmtConfig.LicenseType);
            Assert.NotNull(roundTripMgmtConfig.ImageReference);
        }

        #endregion

        #region Batch Pool Context Tests

        [Fact]
        public void VirtualMachineConfigurationConversions_BatchPoolContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Batch pool VM configuration
            // VirtualMachineConfiguration is used to configure compute nodes in Azure Batch pools

            // Arrange - Test Linux configuration for CPU-intensive workloads
            var linuxScenario = new PSVirtualMachineConfiguration(
                new PSImageReference("Canonical", "0001-com-ubuntu-server-focal", "20_04-lts-gen2"),
                "batch.node.ubuntu 20.04"
            )
            {
                ContainerConfiguration = new PSContainerConfiguration(),
                DataDisks = new List<PSDataDisk>
                {
                    new PSDataDisk(0, 500, Microsoft.Azure.Batch.Common.CachingType.ReadWrite, Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs)
                }
            };

            // Act & Assert - Linux should convert correctly for Batch compute nodes
            var mgmtLinuxConfig = linuxScenario.toMgmtVirtualMachineConfiguration();
            Assert.NotNull(mgmtLinuxConfig);
            Assert.Equal("batch.node.ubuntu 20.04", mgmtLinuxConfig.NodeAgentSkuId);
            Assert.NotNull(mgmtLinuxConfig.ContainerConfiguration);
            Assert.Single(mgmtLinuxConfig.DataDisks);

            // Arrange - Test Windows configuration for GPU workloads
            var windowsScenario = new PSVirtualMachineConfiguration(
                new PSImageReference("MicrosoftWindowsServer", "WindowsServer", "2019-datacenter"),
                "batch.node.windows amd64"
            )
            {
                WindowsConfiguration = new PSWindowsConfiguration(enableAutomaticUpdates: false),
                LicenseType = "Windows_Server",
                Extensions = new List<PSVMExtension>
                {
                    new PSVMExtension("NvidiaGpuDriverWindows", "Microsoft.HpcCompute", "NvidiaGpuDriverWindows")
                }
            };

            // Act & Assert - Windows should convert correctly for GPU-enabled Batch nodes
            var mgmtWindowsConfig = windowsScenario.toMgmtVirtualMachineConfiguration();
            Assert.NotNull(mgmtWindowsConfig);
            Assert.Equal("batch.node.windows amd64", mgmtWindowsConfig.NodeAgentSkuId);
            Assert.NotNull(mgmtWindowsConfig.WindowsConfiguration);
            Assert.Equal("Windows_Server", mgmtWindowsConfig.LicenseType);
            Assert.Single(mgmtWindowsConfig.Extensions);

            // Verify round-trip conversion maintains Batch pool semantics
            var backToLinuxPs = PSVirtualMachineConfiguration.fromMgmtPSVirtualMachineConfiguration(mgmtLinuxConfig);
            var backToWindowsPs = PSVirtualMachineConfiguration.fromMgmtPSVirtualMachineConfiguration(mgmtWindowsConfig);

            Assert.Equal("batch.node.ubuntu 20.04", backToLinuxPs.NodeAgentSkuId);
            Assert.Equal("batch.node.windows amd64", backToWindowsPs.NodeAgentSkuId);
        }

        [Fact]
        public void VirtualMachineConfigurationConversions_SecurityProfile_VerifyEncryptionSupport()
        {
            // This test validates security profile configuration for encrypted Batch nodes

            // Arrange - Configuration with security and encryption settings
            var secureVmConfig = new PSVirtualMachineConfiguration(
                new PSImageReference("MicrosoftWindowsServer", "WindowsServer", "2019-datacenter"),
                "batch.node.windows amd64"
            )
            {
                SecurityProfile = new PSSecurityProfile
                {
                    SecurityType = Microsoft.Azure.Batch.Common.SecurityTypes.TrustedLaunch
                },
                DiskEncryptionConfiguration = new PSDiskEncryptionConfiguration(
                    new List<Microsoft.Azure.Batch.Common.DiskEncryptionTarget>
                    {
                        Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk,
                        Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk
                    }
                )
            };

            // Act
            var mgmtConfig = secureVmConfig.toMgmtVirtualMachineConfiguration();
            var backToPs = PSVirtualMachineConfiguration.fromMgmtPSVirtualMachineConfiguration(mgmtConfig);

            // Assert - Security configuration should be preserved
            Assert.NotNull(mgmtConfig.SecurityProfile);
            Assert.NotNull(mgmtConfig.DiskEncryptionConfiguration);
            Assert.NotNull(backToPs.SecurityProfile);
            Assert.NotNull(backToPs.DiskEncryptionConfiguration);
        }

        #endregion

        #region Type Safety and Instance Creation Tests

        [Fact]
        public void VirtualMachineConfigurationConversions_TypeSafety_VerifyCorrectTypes()
        {
            // Test that conversions return the correct types

            // Arrange
            var imageRef = new PSImageReference("Canonical", "0001-com-ubuntu-server-focal", "20_04-lts-gen2");
            var psVmConfig = new PSVirtualMachineConfiguration(imageRef, "batch.node.ubuntu 20.04");
            var mgmtVmConfig = new VirtualMachineConfiguration(
                new ImageReference("Canonical", "0001-com-ubuntu-server-focal", "20_04-lts-gen2"),
                "batch.node.ubuntu 20.04"
            );

            // Act
            var mgmtResult = psVmConfig.toMgmtVirtualMachineConfiguration();
            var psResult = PSVirtualMachineConfiguration.fromMgmtPSVirtualMachineConfiguration(mgmtVmConfig);

            // Assert - Verify correct types are returned
            Assert.IsType<VirtualMachineConfiguration>(mgmtResult);
            Assert.IsType<PSVirtualMachineConfiguration>(psResult);
        }

        [Fact]
        public void VirtualMachineConfigurationConversions_InstanceCreation_VerifyBehavior()
        {
            // This test verifies that the conversion methods create appropriate instances

            // Arrange
            var imageRef = new PSImageReference("Canonical", "0001-com-ubuntu-server-focal", "20_04-lts-gen2");
            var psVmConfig = new PSVirtualMachineConfiguration(imageRef, "batch.node.ubuntu 20.04");
            var mgmtVmConfig = new VirtualMachineConfiguration(
                new ImageReference("Canonical", "0001-com-ubuntu-server-focal", "20_04-lts-gen2"),
                "batch.node.ubuntu 20.04"
            );

            // Act
            var mgmtResult = psVmConfig.toMgmtVirtualMachineConfiguration();
            var psResult = PSVirtualMachineConfiguration.fromMgmtPSVirtualMachineConfiguration(mgmtVmConfig);

            // Assert - Verify proper instance creation
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.IsType<VirtualMachineConfiguration>(mgmtResult);
            Assert.IsType<PSVirtualMachineConfiguration>(psResult);

            // Verify new instances are created
            Assert.NotSame(mgmtVmConfig, mgmtResult);
            Assert.NotSame(psVmConfig, psResult);
        }

        #endregion

        #region Performance and Edge Case Tests

        [Fact]
        public void VirtualMachineConfigurationConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient

            // Arrange
            var imageRef = new PSImageReference("Canonical", "0001-com-ubuntu-server-focal", "20_04-lts-gen2");
            var psVmConfig = new PSVirtualMachineConfiguration(imageRef, "batch.node.ubuntu 20.04");
            var mgmtVmConfig = new VirtualMachineConfiguration(
                new ImageReference("Canonical", "0001-com-ubuntu-server-focal", "20_04-lts-gen2"),
                "batch.node.ubuntu 20.04"
            );

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 100; i++)
            {
                var mgmtResult = psVmConfig.toMgmtVirtualMachineConfiguration();
                var psResult = PSVirtualMachineConfiguration.fromMgmtPSVirtualMachineConfiguration(mgmtVmConfig);

                Assert.NotNull(mgmtResult);
                Assert.NotNull(psResult);
                Assert.Equal("batch.node.ubuntu 20.04", mgmtResult.NodeAgentSkuId);
                Assert.Equal("batch.node.ubuntu 20.04", psResult.NodeAgentSkuId);
            }
        }

        [Fact]
        public void VirtualMachineConfigurationConversions_CollectionsWithNullElements_HandlesGracefully()
        {
            // Test that collections containing null elements are handled correctly

            // Arrange - Configuration with collections containing null elements
            var imageRef = new PSImageReference("Canonical", "0001-com-ubuntu-server-focal", "20_04-lts-gen2");
            var psVmConfig = new PSVirtualMachineConfiguration(imageRef, "batch.node.ubuntu 20.04")
            {
                DataDisks = new List<PSDataDisk>
                {
                    new PSDataDisk(0, 100),
                    null, // Null element
                    new PSDataDisk(1, 200)
                },
                Extensions = new List<PSVMExtension>
                {
                    new PSVMExtension("Extension1", "Publisher1", "Type1"),
                    null, // Null element
                    new PSVMExtension("Extension2", "Publisher2", "Type2")
                }
            };

            // Act
            var mgmtResult = psVmConfig.toMgmtVirtualMachineConfiguration();

            // Assert - Should handle null elements gracefully
            Assert.NotNull(mgmtResult);
            Assert.NotNull(mgmtResult.DataDisks);
            Assert.NotNull(mgmtResult.Extensions);
            // The LINQ Select operations should preserve null elements
            Assert.Equal(3, mgmtResult.DataDisks.Count);
            Assert.Equal(3, mgmtResult.Extensions.Count);
        }

        #endregion
    }
}