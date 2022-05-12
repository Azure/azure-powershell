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
using Microsoft.Azure.Management.NetApp.Models;
using Microsoft.Azure.Commands.NetAppFiles.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.NetAppFiles.Helpers
{
    public static class ModelExtensions
    {
        public static List<Management.NetApp.Models.ActiveDirectory> ConvertFromPs(this PSNetAppFilesActiveDirectory[] psActiveDirectories)
        {
            return psActiveDirectories.Select(psActiveDirectory => new Management.NetApp.Models.ActiveDirectory
            {
                // ActiveDirectoryId
                Username = psActiveDirectory.Username,
                Password = psActiveDirectory.Password,
                Domain = psActiveDirectory.Domain,
                Dns = psActiveDirectory.Dns,                
                SmbServerName = psActiveDirectory.SmbServerName,
                OrganizationalUnit = psActiveDirectory.OrganizationalUnit,
                Site = psActiveDirectory.Site,
                BackupOperators = psActiveDirectory.BackupOperators,
                KdcIP = psActiveDirectory.KdcIP,
                AdName = psActiveDirectory.AdName,
                ServerRootCACertificate = psActiveDirectory.ServerRootCACertificate,
                AesEncryption = psActiveDirectory.AesEncryption,
                LdapSigning = psActiveDirectory.LdapSigning,
                SecurityOperators = psActiveDirectory.SecurityOperators,
                LdapOverTLS = psActiveDirectory.LdapOverTLS,
                AllowLocalNfsUsersWithLdap = psActiveDirectory.AllowLocalNfsUsersWithLdap,
                Administrators = psActiveDirectory.Administrators,
                EncryptDCConnections = psActiveDirectory.EncryptDCConnections
            }).ToList();
        }

        public static List<PSNetAppFilesActiveDirectory> ConvertToPs(this IList<Management.NetApp.Models.ActiveDirectory> activeDirectories, string resourceGroupName, string accountName)
        {
            return activeDirectories.Select(e => e.ConvertToPs(resourceGroupName, accountName)).ToList();
        }

        public static PSNetAppFilesActiveDirectory ConvertToPs(this Management.NetApp.Models.ActiveDirectory activeDirectory, string resourceGroupName, string accountName)
        {
            var psActiveDirectory = new PSNetAppFilesActiveDirectory
            {
                ResourceGroupName = resourceGroupName,
                AccountName = accountName,
                ActiveDirectoryId = activeDirectory.ActiveDirectoryId,
                Username = activeDirectory.Username,
                Password = activeDirectory.Password,
                Domain = activeDirectory.Domain,
                Dns = activeDirectory.Dns,
                Status = activeDirectory.Status,
                StatusDetails = activeDirectory.StatusDetails,
                SmbServerName = activeDirectory.SmbServerName,
                OrganizationalUnit = activeDirectory.OrganizationalUnit,
                Site = activeDirectory.Site,
                BackupOperators = activeDirectory.BackupOperators,
                KdcIP = activeDirectory.KdcIP,
                AdName = activeDirectory.AdName,
                ServerRootCACertificate = activeDirectory.ServerRootCACertificate,
                AesEncryption = activeDirectory.AesEncryption,
                LdapSigning = activeDirectory.LdapSigning,
                SecurityOperators = activeDirectory.SecurityOperators,
                LdapOverTLS = activeDirectory.LdapOverTLS,
                AllowLocalNfsUsersWithLdap = activeDirectory.AllowLocalNfsUsersWithLdap,
                Administrators = activeDirectory.Administrators,
                EncryptDCConnections = activeDirectory.EncryptDCConnections
            };
            return psActiveDirectory;
        }

        public static PSNetAppFilesAccount ToPsNetAppFilesAccount(this NetAppAccount netAppAccount)
        {
            string resourceGroupName = new ResourceIdentifier(netAppAccount.Id).ResourceGroupName;
            return new PSNetAppFilesAccount
            {
                ResourceGroupName = resourceGroupName,
                Location = netAppAccount.Location,
                Id = netAppAccount.Id,
                Name = netAppAccount.Name,
                Type = netAppAccount.Type,
                Tags = netAppAccount.Tags,
                Etag = netAppAccount.Etag,
                ActiveDirectories = (netAppAccount.ActiveDirectories != null) ? netAppAccount.ActiveDirectories.ConvertToPs(resourceGroupName, netAppAccount.Name) : null,
                ProvisioningState = netAppAccount.ProvisioningState,
                SystemData =  netAppAccount.SystemData?.ToPsSystemData()
            };
        }

        public static PSNetAppFilesPool ToPsNetAppFilesPool(this CapacityPool capacityPool)
        {
            return new PSNetAppFilesPool
            {
                ResourceGroupName = new ResourceIdentifier(capacityPool.Id).ResourceGroupName,
                Location = capacityPool.Location,
                Id = capacityPool.Id,
                Name = capacityPool.Name,
                Type = capacityPool.Type,
                Tags = capacityPool.Tags,
                Etag = capacityPool.Etag,
                PoolId = capacityPool.PoolId,
                Size = capacityPool.Size,
                ServiceLevel = capacityPool.ServiceLevel,
                ProvisioningState = capacityPool.ProvisioningState,
                QosType = capacityPool.QosType,
                TotalThroughputMibps = capacityPool.TotalThroughputMibps,
                UtilizedThroughputMibps = capacityPool.UtilizedThroughputMibps,
                CoolAccess = capacityPool.CoolAccess,
                SystemData = capacityPool.SystemData?.ToPsSystemData()
            };
        }

        public static VolumePatchPropertiesExportPolicy ConvertExportPolicyPatchFromPs(PSNetAppFilesVolumeExportPolicy psExportPolicy)
        {
            var exportPolicy = new VolumePatchPropertiesExportPolicy {Rules = new List<ExportPolicyRule>()};

            foreach (var rule in psExportPolicy.Rules)
            {
                var exportPolicyRule = new ExportPolicyRule
                {
                    RuleIndex = rule.RuleIndex,
                    UnixReadOnly = rule.UnixReadOnly,
                    UnixReadWrite = rule.UnixReadWrite,
                    Cifs = rule.Cifs,
                    Nfsv3 = rule.Nfsv3,
                    Nfsv41 = rule.Nfsv41,
                    AllowedClients = rule.AllowedClients,
                    HasRootAccess = rule.HasRootAccess,
                    Kerberos5iReadOnly = rule.Kerberos5iReadOnly,
                    Kerberos5iReadWrite = rule.Kerberos5iReadWrite,
                    Kerberos5pReadOnly = rule.Kerberos5pReadOnly,
                    Kerberos5pReadWrite = rule.Kerberos5pReadWrite,
                    Kerberos5ReadOnly = rule.Kerberos5ReadOnly,
                    Kerberos5ReadWrite = rule.Kerberos5ReadWrite,                                        
                };

                exportPolicy.Rules.Add(exportPolicyRule);
            }

            return exportPolicy;
        }

        public static VolumePropertiesExportPolicy ConvertExportPolicyFromPs(PSNetAppFilesVolumeExportPolicy psExportPolicy)
        {
            var exportPolicy = new VolumePropertiesExportPolicy {Rules = new List<ExportPolicyRule>()};

            foreach (var rule in psExportPolicy.Rules)
            {
                var exportPolicyRule = new ExportPolicyRule
                {
                    RuleIndex = rule.RuleIndex,
                    UnixReadOnly = rule.UnixReadOnly,
                    UnixReadWrite = rule.UnixReadWrite,
                    Cifs = rule.Cifs,
                    Nfsv3 = rule.Nfsv3,
                    Nfsv41 = rule.Nfsv41,
                    AllowedClients = rule.AllowedClients,
                    HasRootAccess = rule.HasRootAccess,
                    Kerberos5iReadOnly = rule.Kerberos5iReadOnly,
                    Kerberos5iReadWrite = rule.Kerberos5iReadWrite,
                    Kerberos5pReadOnly = rule.Kerberos5pReadOnly,
                    Kerberos5pReadWrite = rule.Kerberos5pReadWrite,
                    Kerberos5ReadOnly = rule.Kerberos5ReadOnly,
                    Kerberos5ReadWrite = rule.Kerberos5ReadWrite,                    
                };

                exportPolicy.Rules.Add(exportPolicyRule);
            }

            return exportPolicy;
        }
        
        public static PSNetAppFilesVolumeExportPolicy ConvertExportPolicyToPs(VolumePropertiesExportPolicy ExportPolicy)
        {
            PSNetAppFilesVolumeExportPolicy PsExportPolicy = new PSNetAppFilesVolumeExportPolicy();
            var rules = new List<PSNetAppFilesExportPolicyRule>();

            foreach (var Rule in ExportPolicy.Rules)
            {
                PSNetAppFilesExportPolicyRule PsExportPolicyRule = new PSNetAppFilesExportPolicyRule
                {
                    RuleIndex = Rule.RuleIndex,
                    UnixReadOnly = Rule.UnixReadOnly,
                    UnixReadWrite = Rule.UnixReadWrite,
                    Cifs = Rule.Cifs,
                    Nfsv3 = Rule.Nfsv3,
                    Nfsv41 = Rule.Nfsv41,
                    AllowedClients = Rule.AllowedClients,
                    HasRootAccess = Rule.HasRootAccess,
                    Kerberos5iReadOnly = Rule.Kerberos5iReadOnly,
                    Kerberos5iReadWrite = Rule.Kerberos5iReadWrite,
                    Kerberos5pReadOnly = Rule.Kerberos5pReadOnly,
                    Kerberos5pReadWrite = Rule.Kerberos5pReadWrite,
                    Kerberos5ReadOnly = Rule.Kerberos5ReadOnly,
                    Kerberos5ReadWrite = Rule.Kerberos5ReadWrite
                };
                rules.Add(PsExportPolicyRule);
            }
            PsExportPolicy.Rules = rules.ToArray();
            return PsExportPolicy;
        }

        public static PSNetAppFilesVolumeDataProtection ConvertDataProtectionToPs(VolumePropertiesDataProtection DataProtection)
        {
            var psDataProtection = new PSNetAppFilesVolumeDataProtection();            
            if (DataProtection.Replication != null)
            {
                var replication = new PSNetAppFilesReplicationObject();
                // replication.ReplicationId = DataProtection.Replication.ReplicationId;
                replication.EndpointType = DataProtection.Replication.EndpointType;
                replication.ReplicationSchedule = DataProtection.Replication.ReplicationSchedule;
                replication.RemoteVolumeResourceId = DataProtection.Replication.RemoteVolumeResourceId;
                // replication.RemoteVolumeRegion = DataProtection.Replication.RemoteVolumeRegion;
                psDataProtection.Replication = replication;
            }
            if (DataProtection.Snapshot != null)
            {
                var snapshot = new PSNetAppFilesVolumeSnapshot();
                snapshot.SnapshotPolicyId = DataProtection.Snapshot.SnapshotPolicyId;
                psDataProtection.Snapshot = snapshot;
            }
            if (DataProtection.Backup != null)
            {
                var psBackupProps = new PSNetAppFilesVolumeBackupProperties()
                {
                    BackupEnabled = DataProtection.Backup.BackupEnabled,
                    BackupPolicyId = DataProtection.Backup.BackupPolicyId,
                    PolicyEnforced = DataProtection.Backup.PolicyEnforced,
                    VaultId = DataProtection.Backup.VaultId
                };
                psDataProtection.Backup = psBackupProps;
            }

            return psDataProtection;
        }

        public static VolumePropertiesDataProtection ConvertDataProtectionFromPs(PSNetAppFilesVolumeDataProtection psDataProtection)
        {
            var dataProtection = new VolumePropertiesDataProtection();
            if (psDataProtection.Replication != null)
            {
                var replication = new ReplicationObject();

                // replication.ReplicationId = psDataProtection.Replication.ReplicationId;
                replication.EndpointType = psDataProtection.Replication.EndpointType;
                replication.ReplicationSchedule = psDataProtection.Replication.ReplicationSchedule;
                replication.RemoteVolumeResourceId = psDataProtection.Replication.RemoteVolumeResourceId;
                // replication.RemoteVolumeRegion = psDataProtection.Replication.RemoteVolumeRegion;
                dataProtection.Replication = replication;
            }
            
            if (psDataProtection.Snapshot != null)
            {
                var snapshot = new VolumeSnapshotProperties();
                snapshot.SnapshotPolicyId = psDataProtection.Snapshot.SnapshotPolicyId;
                dataProtection.Snapshot = snapshot;
            }

            if (psDataProtection.Backup != null)
            {
                var backup = new VolumeBackupProperties();
                backup.BackupEnabled = psDataProtection.Backup.BackupEnabled;
                backup.BackupPolicyId = psDataProtection.Backup.BackupPolicyId;
                backup.PolicyEnforced = psDataProtection.Backup.PolicyEnforced;
                dataProtection.Backup = backup;
            }
            return dataProtection;
        }

        public static VolumePatchPropertiesDataProtection ConvertToPatchFromPs(this PSNetAppFilesVolumeDataProtection psDataProtection)
        {
            var dataProtection = new VolumePatchPropertiesDataProtection();
            if (psDataProtection.Snapshot != null)
            {
                var snapshot = new VolumeSnapshotProperties();
                snapshot.SnapshotPolicyId = psDataProtection.Snapshot.SnapshotPolicyId;
                dataProtection.Snapshot = snapshot;
            }
            if (psDataProtection.Backup != null)
            {
                var backup = new VolumeBackupProperties();
                backup.BackupEnabled = psDataProtection.Backup.BackupEnabled;
                backup.BackupPolicyId = psDataProtection.Backup.BackupPolicyId;
                backup.PolicyEnforced = psDataProtection.Backup.PolicyEnforced;
                backup.VaultId = psDataProtection.Backup.VaultId;
                dataProtection.Backup = backup;
            }
            return dataProtection;
        }


        public static PSNetAppFilesVolume ToPsNetAppFilesVolume(this Management.NetApp.Models.Volume volume)
        {
            return new PSNetAppFilesVolume
            {
                ResourceGroupName = new ResourceIdentifier(volume.Id).ResourceGroupName,
                Location = volume.Location,
                Id = volume.Id,
                Name = volume.Name,
                Type = volume.Type,
                Tags = volume.Tags,
                Etag = volume.Etag,
                ProvisioningState = volume.ProvisioningState,
                FileSystemId = volume.FileSystemId,
                ServiceLevel = volume.ServiceLevel,
                UsageThreshold = volume.UsageThreshold,
                ExportPolicy = (volume.ExportPolicy != null) ? ConvertExportPolicyToPs(volume.ExportPolicy) : null,
                ProtocolTypes = volume.ProtocolTypes,
                MountTargets = volume.MountTargets,
                SnapshotId = volume.SnapshotId,
                BaremetalTenantId = volume.BaremetalTenantId,
                SubnetId = volume.SubnetId,
                CreationToken = volume.CreationToken,
                VolumeType = volume.VolumeType,
                DataProtection = (volume.DataProtection != null) ? ConvertDataProtectionToPs(volume.DataProtection) : null,
                IsRestoring = volume.IsRestoring,
                SnapshotDirectoryVisible = volume.SnapshotDirectoryVisible,
                BackupId = volume.BackupId,
                SecurityStyle = volume.SecurityStyle,
                ThroughputMibps = volume.ThroughputMibps,
                KerberosEnabled = volume.KerberosEnabled,
                SmbEncryption = volume.SmbEncryption,
                SmbContinuouslyAvailable = volume.SmbContinuouslyAvailable,
                LdapEnabled = volume.LdapEnabled,
                CoolAccess = volume.CoolAccess,
                CoolnessPeriod = volume.CoolnessPeriod,
                UnixPermission = volume.UnixPermissions,
                AvsDataStore = volume.AvsDataStore,
                CloneProgress = volume.CloneProgress,
                IsDefaultQuotaEnabled = volume.IsDefaultQuotaEnabled,
                DefaultUserQuotaInKiBs = volume.DefaultUserQuotaInKiBs,
                DefaultGroupQuotaInKiBs = volume.DefaultGroupQuotaInKiBs,
                NetworkFeatures = volume.NetworkFeatures,
                NetworkSiblingSetId = volume.NetworkSiblingSetId,
                StorageToNetworkProximity = volume.StorageToNetworkProximity,
                VolumeGroupName = volume.VolumeGroupName,
                CapacityPoolResourceId = volume.CapacityPoolResourceId,
                T2Network = volume.T2Network,
                ProximityPlacementGroup = volume.ProximityPlacementGroup,
                PlacementRules = volume.PlacementRules?.ToPPSKeyValuePairs(),
                SystemData = volume.SystemData?.ToPsSystemData(),
                MaximumNumberOfFiles = volume.MaximumNumberOfFiles,
                EnableSubvolumes = volume.EnableSubvolumes,
            };
        }

        public static IList<PSKeyValuePairs> ToPPSKeyValuePairs(this IList<PlacementKeyValuePairs> placementKeysValuePair)
        {
            return placementKeysValuePair?.Select(e => new PSKeyValuePairs() { Key = e.Key, Value = e.Value } ).ToList();            
        }
        public static IList<PlacementKeyValuePairs> ToPlacementKeyValuePairs(this IList<PSKeyValuePairs> psKeysValuePair)
        {
            return psKeysValuePair?.Select(e => new PlacementKeyValuePairs() { Key = e.Key, Value = e.Value }).ToList();
        }

        public static PSNetAppFilesSnapshot ToPsNetAppFilesSnapshot(this Management.NetApp.Models.Snapshot snapshot)
        {
            return new PSNetAppFilesSnapshot
            {
                ResourceGroupName = new ResourceIdentifier(snapshot.Id).ResourceGroupName,
                Location = snapshot.Location,
                Id = snapshot.Id,
                Name = snapshot.Name,
                Type = snapshot.Type,
                SnapshotId = snapshot.SnapshotId,
                Created = snapshot.Created,
                ProvisioningState = snapshot.ProvisioningState,
            };
        }

        public static PSNetAppFilesReplicationStatus ToPsNetAppFilesReplicationStatus(this Management.NetApp.Models.ReplicationStatus replicationStatus)
        {
            return new PSNetAppFilesReplicationStatus
            {
                Healthy = replicationStatus.Healthy,
                RelationshipStatus = replicationStatus.RelationshipStatus,
                MirrorState = replicationStatus.MirrorState,
                TotalProgress = replicationStatus.TotalProgress,
                ErrorMessage = replicationStatus.ErrorMessage
            };
        }

        public static PSSystemData ToPsSystemData(this SystemData systemData)
        {
            return new PSSystemData
            {
                CreatedAt = systemData.CreatedAt,
                CreatedBy = systemData.CreatedBy,
                CreatedByType = systemData.CreatedByType,
                LastModifiedAt = systemData.LastModifiedAt,
                LastModifiedBy = systemData.LastModifiedBy,
                LastModifiedByType = systemData.LastModifiedByType
            };
        }
    }
}