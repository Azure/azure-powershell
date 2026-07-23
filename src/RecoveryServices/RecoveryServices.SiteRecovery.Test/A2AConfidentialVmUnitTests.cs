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

using System.Linq;
using System.Management.Automation;
using System.Reflection;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;
using Xunit;

namespace RecoveryServices.SiteRecovery.Test
{
    /// <summary>
    /// Pure in-process unit tests covering the A2A Confidential VM (CVM) surface
    /// added for API version 2026-06-01.
    ///
    /// These tests do not require a recorded HTTP cassette or live Azure
    /// credentials and are safe to run on every CI build. They pin the
    /// behavioural contract of the new CVM inputs exposed by:
    ///   * <see cref="ASRAzuretoAzureDiskReplicationConfig"/> (input PS object)
    ///   * <see cref="AzureRmAsrAzureToAzureDiskReplicationConfig"/> (disk-config cmdlet)
    ///   * <see cref="NewAzureRmRecoveryServicesAsrReplicationProtectedItem"/> (enable cmdlet)
    ///   * <see cref="SetAzureRmRecoveryServicesAsrReplicationProtectedItem"/> (update cmdlet)
    ///   * <see cref="UpdateAzureRmRecoveryServicesAsrProtection"/> (reprotect cmdlet)
    ///   * the generated SDK models
    ///     (<see cref="ConfidentialDiskEncryptionInfo"/>,
    ///      <see cref="UpdateConfidentialDiskEncryptionInfo"/>, and the new
    ///      properties on the enable/switch/update inputs)
    ///   * <see cref="Utilities.A2AConfidentialDiskEncryptionDetails(string, string)"/> and
    ///     <see cref="Utilities.CreateA2AVmManagedDiskInputDetails(ASRAzuretoAzureDiskReplicationConfig, bool)"/>.
    /// </summary>
    public class A2AConfidentialVmUnitTests
    {
        private const string ReplicaDesId =
            "/subscriptions/sub-1/resourceGroups/cvm-rg/providers/Microsoft.Compute/diskEncryptionSets/replica-cvm-des";
        private const string TargetDesId =
            "/subscriptions/sub-1/resourceGroups/cvm-rg/providers/Microsoft.Compute/diskEncryptionSets/target-cvm-des";
        private const string CddeIdentityId =
            "/subscriptions/sub-1/resourceGroups/cvm-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/cdde-identity";

        // --- ASRAzuretoAzureDiskReplicationConfig (input PS object) ------------

        [Fact]
        public void ReplicationConfig_ConfidentialDesProperties_RoundTrip()
        {
            var cfg = new ASRAzuretoAzureDiskReplicationConfig
            {
                ReplicaConfidentialDiskEncryptionSetId = ReplicaDesId,
                TargetConfidentialDiskEncryptionSetId = TargetDesId,
            };

            Assert.Equal(ReplicaDesId, cfg.ReplicaConfidentialDiskEncryptionSetId);
            Assert.Equal(TargetDesId, cfg.TargetConfidentialDiskEncryptionSetId);
        }

        [Fact]
        public void ReplicationConfig_ConfidentialDesProperties_DefaultsAreNull()
        {
            // Backward-compat: callers that don't set the CVM properties must
            // see nulls so the enable/reprotect wire-up omits the field for
            // non-confidential disks.
            var cfg = new ASRAzuretoAzureDiskReplicationConfig();

            Assert.Null(cfg.ReplicaConfidentialDiskEncryptionSetId);
            Assert.Null(cfg.TargetConfidentialDiskEncryptionSetId);
        }

        // --- Disk-config cmdlet parameter attributes --------------------------

        [Theory]
        [InlineData(nameof(AzureRmAsrAzureToAzureDiskReplicationConfig.ReplicaConfidentialDiskEncryptionSetId))]
        [InlineData(nameof(AzureRmAsrAzureToAzureDiskReplicationConfig.TargetConfidentialDiskEncryptionSetId))]
        public void DiskConfigCmdlet_ConfidentialParameters_AreOptionalAndInManagedDiskSet(string propertyName)
        {
            PropertyInfo property = typeof(AzureRmAsrAzureToAzureDiskReplicationConfig)
                .GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
            Assert.NotNull(property);

            ParameterAttribute parameter = property
                .GetCustomAttributes<ParameterAttribute>(inherit: false)
                .SingleOrDefault();
            Assert.NotNull(parameter);

            Assert.Equal("AzureToAzureManagedDisk", parameter.ParameterSetName);
            Assert.False(parameter.Mandatory,
                $"{propertyName} must remain optional to preserve backward compatibility.");
        }

        // --- Enable / Update / Reprotect cmdlet CDDE-identity parameter -------

        [Fact]
        public void EnableCmdlet_HasOptionalRecoveryConfidentialDataDiskEncryptionIdentityParameter()
        {
            AssertHasOptionalStringParameter(
                typeof(NewAzureRmRecoveryServicesAsrReplicationProtectedItem),
                "RecoveryConfidentialDataDiskEncryptionIdentity");
        }

        [Fact]
        public void UpdateCmdlet_HasOptionalRecoveryConfidentialDataDiskEncryptionIdentityParameter()
        {
            AssertHasOptionalStringParameter(
                typeof(SetAzureRmRecoveryServicesAsrReplicationProtectedItem),
                "RecoveryConfidentialDataDiskEncryptionIdentity");
        }

        [Fact]
        public void ReprotectCmdlet_HasOptionalRecoveryConfidentialDataDiskEncryptionIdentityParameter()
        {
            AssertHasOptionalStringParameter(
                typeof(UpdateAzureRmRecoveryServicesAsrProtection),
                "RecoveryConfidentialDataDiskEncryptionIdentity");
        }

        private static void AssertHasOptionalStringParameter(System.Type cmdletType, string propertyName)
        {
            PropertyInfo property = cmdletType
                .GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
            Assert.NotNull(property);
            Assert.Equal(typeof(string), property.PropertyType);

            var parameters = property.GetCustomAttributes<ParameterAttribute>(inherit: false).ToArray();
            Assert.NotEmpty(parameters);
            Assert.All(parameters, p => Assert.False(p.Mandatory,
                $"{cmdletType.Name}.{propertyName} must remain optional to preserve backward compatibility."));
        }

        // --- Generated SDK model shape ----------------------------------------

        [Fact]
        public void SdkModel_ConfidentialDiskEncryptionInfo_CarriesReplicaAndTarget()
        {
            var info = new ConfidentialDiskEncryptionInfo(ReplicaDesId, TargetDesId);

            Assert.Equal(ReplicaDesId, info.RecoveryReplicaConfidentialDiskEncryptionSetId);
            Assert.Equal(TargetDesId, info.RecoveryTargetConfidentialDiskEncryptionSetId);
        }

        [Fact]
        public void SdkModel_UpdateConfidentialDiskEncryptionInfo_CarriesTargetOnly()
        {
            var info = new UpdateConfidentialDiskEncryptionInfo(TargetDesId);

            Assert.Equal(TargetDesId, info.RecoveryTargetConfidentialDiskEncryptionSetId);
            // The update model must NOT expose a replica setter — the replica DES
            // is immutable after enable.
            Assert.Null(typeof(UpdateConfidentialDiskEncryptionInfo)
                .GetProperty("RecoveryReplicaConfidentialDiskEncryptionSetId"));
        }

        [Fact]
        public void SdkModel_ManagedDiskInput_ExposesConfidentialDiskEncryptionInfo()
        {
            var input = new A2AVmManagedDiskInputDetails
            {
                ConfidentialDiskEncryptionInfo =
                    new ConfidentialDiskEncryptionInfo(ReplicaDesId, TargetDesId),
            };

            Assert.NotNull(input.ConfidentialDiskEncryptionInfo);
            Assert.Equal(ReplicaDesId,
                input.ConfidentialDiskEncryptionInfo.RecoveryReplicaConfidentialDiskEncryptionSetId);
        }

        [Fact]
        public void SdkModel_ManagedDiskUpdate_ExposesUpdateConfidentialDiskEncryptionInfo()
        {
            var input = new A2AVmManagedDiskUpdateDetails
            {
                ConfidentialDiskEncryptionInfo =
                    new UpdateConfidentialDiskEncryptionInfo(TargetDesId),
            };

            Assert.NotNull(input.ConfidentialDiskEncryptionInfo);
            Assert.Equal(TargetDesId,
                input.ConfidentialDiskEncryptionInfo.RecoveryTargetConfidentialDiskEncryptionSetId);
        }

        [Theory]
        [InlineData(typeof(A2AEnableProtectionInput))]
        [InlineData(typeof(A2ASwitchProtectionInput))]
        [InlineData(typeof(A2AUpdateReplicationProtectedItemInput))]
        public void SdkModel_VmLevelInputs_ExposeRecoveryConfidentialDataDiskEncryptionIdentity(System.Type modelType)
        {
            PropertyInfo property = modelType
                .GetProperty("RecoveryConfidentialDataDiskEncryptionIdentity");
            Assert.NotNull(property);
            Assert.Equal(typeof(string), property.PropertyType);
        }

        // --- Utilities.A2AConfidentialDiskEncryptionDetails -------------------

        [Fact]
        public void Helper_ConfidentialDetails_ReturnsNullWhenBothIdsMissing()
        {
            Assert.Null(Utilities.A2AConfidentialDiskEncryptionDetails(null, null));
            Assert.Null(Utilities.A2AConfidentialDiskEncryptionDetails(string.Empty, string.Empty));
        }

        [Fact]
        public void Helper_ConfidentialDetails_PopulatesBothIds()
        {
            var info = Utilities.A2AConfidentialDiskEncryptionDetails(ReplicaDesId, TargetDesId);

            Assert.NotNull(info);
            Assert.Equal(ReplicaDesId, info.RecoveryReplicaConfidentialDiskEncryptionSetId);
            Assert.Equal(TargetDesId, info.RecoveryTargetConfidentialDiskEncryptionSetId);
        }

        [Fact]
        public void Helper_ConfidentialDetails_PopulatesWhenOnlyTargetSupplied()
        {
            var info = Utilities.A2AConfidentialDiskEncryptionDetails(null, TargetDesId);

            Assert.NotNull(info);
            Assert.Null(info.RecoveryReplicaConfidentialDiskEncryptionSetId);
            Assert.Equal(TargetDesId, info.RecoveryTargetConfidentialDiskEncryptionSetId);
        }

        // --- Utilities.CreateA2AVmManagedDiskInputDetails ---------------------

        [Fact]
        public void Helper_ManagedDiskInput_ForwardsConfidentialDiskEncryptionInfo()
        {
            var disk = new ASRAzuretoAzureDiskReplicationConfig
            {
                DiskId = "/subscriptions/sub-1/disks/osdisk-1",
                RecoveryResourceGroupId = "/subscriptions/sub-1/resourceGroups/target-rg",
                ReplicaConfidentialDiskEncryptionSetId = ReplicaDesId,
                TargetConfidentialDiskEncryptionSetId = TargetDesId,
            };

            var sdk = Utilities.CreateA2AVmManagedDiskInputDetails(disk, includeDiskEncryption: false);

            Assert.NotNull(sdk.ConfidentialDiskEncryptionInfo);
            Assert.Equal(ReplicaDesId,
                sdk.ConfidentialDiskEncryptionInfo.RecoveryReplicaConfidentialDiskEncryptionSetId);
            Assert.Equal(TargetDesId,
                sdk.ConfidentialDiskEncryptionInfo.RecoveryTargetConfidentialDiskEncryptionSetId);
        }

        [Fact]
        public void Helper_ManagedDiskInput_OmitsConfidentialInfoForNonConfidentialDisk()
        {
            // Backward-compat: a non-confidential disk (no CVM DES ids) must not
            // carry a ConfidentialDiskEncryptionInfo, so the wire request omits
            // the field entirely.
            var disk = new ASRAzuretoAzureDiskReplicationConfig
            {
                DiskId = "/subscriptions/sub-1/disks/osdisk-1",
                RecoveryResourceGroupId = "/subscriptions/sub-1/resourceGroups/target-rg",
            };

            var sdk = Utilities.CreateA2AVmManagedDiskInputDetails(disk, includeDiskEncryption: false);

            Assert.Null(sdk.ConfidentialDiskEncryptionInfo);
        }
    }
}
