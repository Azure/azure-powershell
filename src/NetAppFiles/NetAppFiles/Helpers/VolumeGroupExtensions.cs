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

using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.NetAppFiles.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.NetApp.Models;

namespace Microsoft.Azure.Commands.NetAppFiles.Helpers
{
    public static class VolumeGroupExtensions
    {       
        public static PSNetAppFilesVolumeGroupDetail ConvertToPs(this Management.NetApp.Models.VolumeGroupDetails volumeGroupDetails)
        {
            var psVolumeGroupDetail = new PSNetAppFilesVolumeGroupDetail()
            {
                ResourceGroupName = new ResourceIdentifier(volumeGroupDetails.Id).ResourceGroupName,                
                Id = volumeGroupDetails.Id,
                Name = volumeGroupDetails.Name,
                Type = volumeGroupDetails.Type,
                ProvisioningState = volumeGroupDetails.ProvisioningState,
                Tags = volumeGroupDetails.Tags,
                GroupMetaData = volumeGroupDetails.GroupMetaData.ConvertToPs(),
                Volumes = volumeGroupDetails.Volumes.ConvertToPs()
            };
            return psVolumeGroupDetail;
        }

        public static PSNetAppFilesVolumeGroupListProperties ConvertToPs(this Management.NetApp.Models.VolumeGroup volumeGroupListProperties)
        {
            var psVolumeGroupProperties = new PSNetAppFilesVolumeGroupListProperties()
            {
                Id = volumeGroupListProperties.Id,
                Name = volumeGroupListProperties.Name,
                Location = volumeGroupListProperties.Location,
                ProvisioningState = volumeGroupListProperties.ProvisioningState,
                Tags = volumeGroupListProperties.Tags,
                Type = volumeGroupListProperties?.Type,
                GroupMetaData = volumeGroupListProperties.GroupMetaData.ConvertToPs(),

            };
            return psVolumeGroupProperties;
        }

        public static List<PSNetAppFilesVolumeGroupListProperties> ConvertToPS(this IList<Management.NetApp.Models.VolumeGroup> volumeGroupList)
        {
            return volumeGroupList.Select(e => e.ConvertToPs()).ToList();
        }

        public static List<PSNetAppFilesVolumeGroupDetail> ConvertToPS(this IList<VolumeGroupDetails> volumeGroupDetails)
        {
            return volumeGroupDetails.Select(e => e.ConvertToPs()).ToList();
        }

        public static PSNetAppFilesVolumeGroupMetaData ConvertToPs(this Management.NetApp.Models.VolumeGroupMetaData volumeGroupMetaData)
        {
            var psVolumeGroupMetaData = new PSNetAppFilesVolumeGroupMetaData()
            {                
                ApplicationIdentifier = volumeGroupMetaData.ApplicationIdentifier,
                ApplicationType = volumeGroupMetaData.ApplicationType,
                DeploymentSpecId = volumeGroupMetaData.DeploymentSpecId,
                GlobalPlacementRules = volumeGroupMetaData.GlobalPlacementRules,
                GroupDescription = volumeGroupMetaData.GroupDescription,
                VolumesCount = volumeGroupMetaData.VolumesCount
            };
            return psVolumeGroupMetaData;
        }
        public static PSNetAppFilesVolumeGroupVolumeProperties ConvertToPs(this Management.NetApp.Models.VolumeGroupVolumeProperties volumeGroupVolumeProperties)
        {
            var psNetAppFilesVolumeGroupVolumeProperties = new PSNetAppFilesVolumeGroupVolumeProperties()
            {
                Id = volumeGroupVolumeProperties.Id,
                Name = volumeGroupVolumeProperties.Name,
                Type = volumeGroupVolumeProperties.Type,
                Tags = volumeGroupVolumeProperties.Tags,
                FileSystemId = volumeGroupVolumeProperties.FileSystemId,
                CreationToken = volumeGroupVolumeProperties.CreationToken,
                ServiceLevel = volumeGroupVolumeProperties.ServiceLevel,
                UsageThreshold = volumeGroupVolumeProperties.UsageThreshold,
                ExportPolicy = (volumeGroupVolumeProperties.ExportPolicy != null) ? ModelExtensions.ConvertExportPolicyToPs(volumeGroupVolumeProperties.ExportPolicy) : null,
                ProtocolTypes = volumeGroupVolumeProperties.ProtocolTypes,
                ProvisioningState = volumeGroupVolumeProperties.ProvisioningState,
                SnapshotId = volumeGroupVolumeProperties.SnapshotId,
                BackupId = volumeGroupVolumeProperties.BackupId,
                BaremetalTenantId = volumeGroupVolumeProperties.BaremetalTenantId,
                SubnetId = volumeGroupVolumeProperties.SubnetId,
                NetworkFeatures = volumeGroupVolumeProperties.NetworkFeatures,
                NetworkSiblingSetId = volumeGroupVolumeProperties.NetworkSiblingSetId,
                StorageToNetworkProximity = volumeGroupVolumeProperties.StorageToNetworkProximity,
                MountTargets = volumeGroupVolumeProperties.MountTargets,
                VolumeType = volumeGroupVolumeProperties.VolumeType,                
                DataProtection = (volumeGroupVolumeProperties.DataProtection != null) ? ModelExtensions.ConvertDataProtectionToPs(volumeGroupVolumeProperties.DataProtection) : null,
                IsRestoring = volumeGroupVolumeProperties.IsRestoring,
                SnapshotDirectoryVisible = volumeGroupVolumeProperties.SnapshotDirectoryVisible,
                KerberosEnabled = volumeGroupVolumeProperties.KerberosEnabled,
                SecurityStyle = volumeGroupVolumeProperties.SecurityStyle,
                SmbEncryption = volumeGroupVolumeProperties.SmbEncryption,
                SmbContinuouslyAvailable = volumeGroupVolumeProperties.SmbContinuouslyAvailable,
                ThroughputMibps = volumeGroupVolumeProperties.ThroughputMibps,
                EncryptionKeySource = volumeGroupVolumeProperties.EncryptionKeySource,
                LdapEnabled = volumeGroupVolumeProperties.LdapEnabled,
                CoolAccess = volumeGroupVolumeProperties.CoolAccess,
                CoolnessPeriod = volumeGroupVolumeProperties.CoolnessPeriod,
                UnixPermissions = volumeGroupVolumeProperties.UnixPermissions,
                CloneProgress = volumeGroupVolumeProperties.CloneProgress,               
                AvsDataStore = volumeGroupVolumeProperties.AvsDataStore,
                IsDefaultQuotaEnabled = volumeGroupVolumeProperties.IsDefaultQuotaEnabled,
                DefaultUserQuotaInKiBs = volumeGroupVolumeProperties.DefaultUserQuotaInKiBs,
                DefaultGroupQuotaInKiBs = volumeGroupVolumeProperties.DefaultGroupQuotaInKiBs,
                MaximumNumberOfFiles = volumeGroupVolumeProperties.MaximumNumberOfFiles,
                VolumeGroupName = volumeGroupVolumeProperties.VolumeGroupName,
                CapacityPoolResourceId = volumeGroupVolumeProperties.CapacityPoolResourceId,
                ProximityPlacementGroup = volumeGroupVolumeProperties.ProximityPlacementGroup,
                T2Network = volumeGroupVolumeProperties.T2Network,
                VolumeSpecName = volumeGroupVolumeProperties.VolumeSpecName,
                PlacementRules = volumeGroupVolumeProperties.PlacementRules,
                EnableSubvolumes = volumeGroupVolumeProperties.EnableSubvolumes
            };
            return psNetAppFilesVolumeGroupVolumeProperties;
        }

        public static List<PSNetAppFilesVolumeGroupVolumeProperties> ConvertToPs(this IList<VolumeGroupVolumeProperties> volumeGroupVolumeProperties)
        {
            return volumeGroupVolumeProperties.Select(e => e.ConvertToPs()).ToList();
        }

    }
}
