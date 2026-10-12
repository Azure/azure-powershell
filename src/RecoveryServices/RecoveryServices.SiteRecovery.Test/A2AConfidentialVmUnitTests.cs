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
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace RecoveryServices.SiteRecovery.Test
{
    /// <summary>
    /// Pure in-process unit tests covering the A2A Confidential VM (CVM) surface
    /// added for API version 2026-11-01.
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
        [Trait(Category.AcceptanceType, Category.CheckIn)]
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
        [Trait(Category.AcceptanceType, Category.CheckIn)]
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
        [Trait(Category.AcceptanceType, Category.CheckIn)]
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
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnableCmdlet_HasOptionalRecoveryConfidentialDataDiskEncryptionIdentityParameter()
        {
            AssertHasOptionalStringParameter(
                typeof(NewAzureRmRecoveryServicesAsrReplicationProtectedItem),
                "RecoveryConfidentialDataDiskEncryptionIdentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateCmdlet_HasOptionalRecoveryConfidentialDataDiskEncryptionIdentityParameter()
        {
            AssertHasOptionalStringParameter(
                typeof(SetAzureRmRecoveryServicesAsrReplicationProtectedItem),
                "RecoveryConfidentialDataDiskEncryptionIdentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
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
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SdkModel_ConfidentialDiskEncryptionInfo_CarriesReplicaAndTarget()
        {
            var info = new ConfidentialDiskEncryptionInfo(ReplicaDesId, TargetDesId);

            Assert.Equal(ReplicaDesId, info.RecoveryReplicaConfidentialDiskEncryptionSetId);
            Assert.Equal(TargetDesId, info.RecoveryTargetConfidentialDiskEncryptionSetId);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
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
        [Trait(Category.AcceptanceType, Category.CheckIn)]
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
        [Trait(Category.AcceptanceType, Category.CheckIn)]
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
        [Trait(Category.AcceptanceType, Category.CheckIn)]
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
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Helper_ConfidentialDetails_ReturnsNullWhenBothIdsMissing()
        {
            Assert.Null(Utilities.A2AConfidentialDiskEncryptionDetails(null, null));
            Assert.Null(Utilities.A2AConfidentialDiskEncryptionDetails(string.Empty, string.Empty));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Helper_ConfidentialDetails_PopulatesBothIds()
        {
            var info = Utilities.A2AConfidentialDiskEncryptionDetails(ReplicaDesId, TargetDesId);

            Assert.NotNull(info);
            Assert.Equal(ReplicaDesId, info.RecoveryReplicaConfidentialDiskEncryptionSetId);
            Assert.Equal(TargetDesId, info.RecoveryTargetConfidentialDiskEncryptionSetId);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Helper_ConfidentialDetails_PopulatesWhenOnlyTargetSupplied()
        {
            var info = Utilities.A2AConfidentialDiskEncryptionDetails(null, TargetDesId);

            Assert.NotNull(info);
            Assert.Null(info.RecoveryReplicaConfidentialDiskEncryptionSetId);
            Assert.Equal(TargetDesId, info.RecoveryTargetConfidentialDiskEncryptionSetId);
        }

        // --- Utilities.CreateA2AVmManagedDiskInputDetails ---------------------

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
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
        [Trait(Category.AcceptanceType, Category.CheckIn)]
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

        /// <summary>
        /// The confidential data disk encryption identity must be readable from the
        /// protected item PS object. Without this the field is write-only through
        /// PowerShell: callers can set it but cannot confirm the service kept it.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RpiDetails_ExposesRecoveryConfidentialDataDiskEncryptionIdentity()
        {
            var details = new A2AReplicationDetails
            {
                RecoveryConfidentialDataDiskEncryptionIdentity = CddeIdentityId,
            };

            var psObject = new ASRAzureToAzureSpecificRPIDetails(details);

            Assert.Equal(CddeIdentityId, psObject.RecoveryConfidentialDataDiskEncryptionIdentity);
        }

        /// <summary>
        /// A non-confidential protected item carries no identity, so the PS object
        /// must surface null rather than an empty string.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RpiDetails_ConfidentialIdentity_IsNullWhenServiceOmitsIt()
        {
            var psObject = new ASRAzureToAzureSpecificRPIDetails(new A2AReplicationDetails());

            Assert.Null(psObject.RecoveryConfidentialDataDiskEncryptionIdentity);
        }

        /// <summary>
        /// Both per-disk confidential encryption set ids must be readable from the
        /// protected disk PS object, flattened the same way the input PS object
        /// exposes them.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ProtectedDiskDetails_ExposesConfidentialDiskEncryptionSets()
        {
            var disk = new A2AProtectedManagedDiskDetails(
                diskName: "osdisk-1",
                confidentialDiskEncryptionInfo: new ConfidentialDiskEncryptionInfo
                {
                    RecoveryReplicaConfidentialDiskEncryptionSetId = ReplicaDesId,
                    RecoveryTargetConfidentialDiskEncryptionSetId = TargetDesId,
                });

            var psObject = new ASRAzureToAzureProtectedDiskDetails(disk);

            Assert.Equal(ReplicaDesId, psObject.ReplicaConfidentialDiskEncryptionSetId);
            Assert.Equal(TargetDesId, psObject.TargetConfidentialDiskEncryptionSetId);
        }

        /// <summary>
        /// A disk with no confidential encryption info must map to nulls and must not
        /// throw, since the service omits the field for every non-confidential disk.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ProtectedDiskDetails_ConfidentialDes_AreNullForNonConfidentialDisk()
        {
            var disk = new A2AProtectedManagedDiskDetails
            {
                DiskName = "datadisk-plain",
            };

            var psObject = new ASRAzureToAzureProtectedDiskDetails(disk);

            Assert.Null(psObject.ReplicaConfidentialDiskEncryptionSetId);
            Assert.Null(psObject.TargetConfidentialDiskEncryptionSetId);
        }

        /// <summary>
        /// Cluster switch protection has no confidential disk encryption field, so a
        /// disk configuration carrying confidential DES ids must be rejected instead
        /// of being silently dropped from the request.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ClusterReprotect_RejectsConfidentialDiskEncryptionSets()
        {
            var disk = Utilities.CreateA2AVmManagedDiskInputDetails(
                new ASRAzuretoAzureDiskReplicationConfig
                {
                    DiskId = "/subscriptions/sub-1/disks/osdisk-1",
                    RecoveryResourceGroupId = "/subscriptions/sub-1/resourceGroups/target-rg",
                    ReplicaConfidentialDiskEncryptionSetId = ReplicaDesId,
                    TargetConfidentialDiskEncryptionSetId = TargetDesId,
                },
                includeDiskEncryption: true);

            var ex = Assert.Throws<TargetInvocationException>(() => InvokeToClusterDiskInput(disk));

            var inner = Assert.IsType<System.InvalidOperationException>(ex.InnerException);
            Assert.Contains("ReplicaConfidentialDiskEncryptionSetId", inner.Message);
            Assert.Contains("cluster", inner.Message);
        }

        /// <summary>
        /// A non-confidential disk must still convert to the cluster disk input with
        /// every supported field carried over.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ClusterReprotect_ConvertsNonConfidentialDisk()
        {
            const string diskId = "/subscriptions/sub-1/disks/osdisk-1";
            const string targetRg = "/subscriptions/sub-1/resourceGroups/target-rg";
            const string desId = "/subscriptions/sub-1/resourceGroups/cvm-rg/providers/Microsoft.Compute/diskEncryptionSets/sse-des";
            var disk = Utilities.CreateA2AVmManagedDiskInputDetails(
                new ASRAzuretoAzureDiskReplicationConfig
                {
                    DiskId = diskId,
                    RecoveryResourceGroupId = targetRg,
                    LogStorageAccountId = "/subscriptions/sub-1/storageAccounts/cache",
                    RecoveryReplicaDiskAccountType = "Premium_LRS",
                    RecoveryTargetDiskAccountType = "Premium_LRS",
                    RecoveryDiskEncryptionSetId = desId,
                },
                includeDiskEncryption: true);

            var cluster = Assert.IsType<A2AClusterVmManagedDiskInputDetails>(InvokeToClusterDiskInput(disk));

            Assert.Equal(diskId, cluster.DiskId);
            Assert.Equal(targetRg, cluster.RecoveryResourceGroupId);
            Assert.Equal("/subscriptions/sub-1/storageAccounts/cache", cluster.PrimaryStagingAzureStorageAccountId);
            Assert.Equal("Premium_LRS", cluster.RecoveryReplicaDiskAccountType);
            Assert.Equal("Premium_LRS", cluster.RecoveryTargetDiskAccountType);
            Assert.Equal(desId, cluster.RecoveryDiskEncryptionSetId);
        }

        private static object InvokeToClusterDiskInput(A2AVmManagedDiskInputDetails disk)
        {
            var method = typeof(UpdateAzureRmRecoveryServicesAsrClusterProtection).GetMethod(
                "ToClusterDiskInput",
                BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);
            return method.Invoke(null, new object[] { disk });
        }

        /// <summary>
        /// The update contract carries only the target confidential DES, so a replica
        /// confidential DES on update must be rejected instead of silently dropped.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateRpi_RejectsReplicaConfidentialDiskEncryptionSet()
        {
            var disk = new ASRAzuretoAzureDiskReplicationConfig
            {
                DiskId = "/subscriptions/sub-1/disks/osdisk-1",
                IsManagedDisk = true,
                ReplicaConfidentialDiskEncryptionSetId = ReplicaDesId,
                TargetConfidentialDiskEncryptionSetId = TargetDesId,
            };

            var ex = Assert.Throws<TargetInvocationException>(() => InvokeCreateManagedDiskUpdateDetails(disk));

            var inner = Assert.IsType<PSArgumentException>(ex.InnerException);
            Assert.Contains("ReplicaConfidentialDiskEncryptionSetId", inner.Message);
        }

        /// <summary>
        /// A target-only confidential DES must be forwarded on the managed disk update input.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateRpi_ForwardsTargetConfidentialDiskEncryptionSet()
        {
            var disk = new ASRAzuretoAzureDiskReplicationConfig
            {
                DiskId = "/subscriptions/sub-1/disks/osdisk-1",
                IsManagedDisk = true,
                TargetConfidentialDiskEncryptionSetId = TargetDesId,
            };

            var update = Assert.IsType<A2AVmManagedDiskUpdateDetails>(InvokeCreateManagedDiskUpdateDetails(disk));

            Assert.Equal("/subscriptions/sub-1/disks/osdisk-1", update.DiskId);
            Assert.NotNull(update.ConfidentialDiskEncryptionInfo);
            Assert.Equal(TargetDesId, update.ConfidentialDiskEncryptionInfo.RecoveryTargetConfidentialDiskEncryptionSetId);
        }

        private static object InvokeCreateManagedDiskUpdateDetails(ASRAzuretoAzureDiskReplicationConfig disk)
        {
            var method = typeof(SetAzureRmRecoveryServicesAsrReplicationProtectedItem).GetMethod(
                "CreateManagedDiskUpdateDetails",
                BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);
            return method.Invoke(null, new object[] { disk });
        }
    }
}
