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
        public static List<ActiveDirectory> ConvertActiveDirectoriesFromPs(PSNetAppFilesActiveDirectory[] psActiveDirectories)
        {
            return psActiveDirectories.Select(psActiveDirectory => new ActiveDirectory
            {
                // ActiveDirectoryId
                Username = psActiveDirectory.Username,
                Password = psActiveDirectory.Password,
                Domain = psActiveDirectory.Domain,
                Dns = psActiveDirectory.Dns,
                // Status
                SmbServerName = psActiveDirectory.SmbServerName
                // OrganizationalUnit
            }).ToList();
        }

        public static List<PSNetAppFilesActiveDirectory> ConvertActiveDirectoriesToPs(IList<ActiveDirectory> ActiveDirectories)
        {
            List<PSNetAppFilesActiveDirectory> PsActiveDirectories = new List<PSNetAppFilesActiveDirectory>();

            foreach (var ActiveDirectory in ActiveDirectories)
            {
                PSNetAppFilesActiveDirectory PsActiveDirectory = new PSNetAppFilesActiveDirectory
                {
                    ActiveDirectoryId = ActiveDirectory.ActiveDirectoryId,
                    Username = ActiveDirectory.Username,
                    Password = ActiveDirectory.Password,
                    Domain = ActiveDirectory.Domain,
                    Dns = ActiveDirectory.Dns,
                    Status = ActiveDirectory.Status,
                    SmbServerName = ActiveDirectory.SmbServerName,
                    OrganizationalUnit = ActiveDirectory.OrganizationalUnit
                };

                PsActiveDirectories.Add(PsActiveDirectory);
            }

            return PsActiveDirectories;
        }

        public static PSNetAppFilesAccount ToPsNetAppFilesAccount(this NetAppAccount netAppAccount)
        {
            return new PSNetAppFilesAccount
            {
                ResourceGroupName = new ResourceIdentifier(netAppAccount.Id).ResourceGroupName,
                Location = netAppAccount.Location,
                Id = netAppAccount.Id,
                Name = netAppAccount.Name,
                Type = netAppAccount.Type,
                Tags = netAppAccount.Tags,
                ActiveDirectories = (netAppAccount.ActiveDirectories != null) ? ConvertActiveDirectoriesToPs(netAppAccount.ActiveDirectories) : null,
                ProvisioningState = netAppAccount.ProvisioningState
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
                PoolId = capacityPool.PoolId,
                Size = capacityPool.Size,
                ServiceLevel = capacityPool.ServiceLevel,
                ProvisioningState = capacityPool.ProvisioningState
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
                    AllowedClients = rule.AllowedClients
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
                    AllowedClients = rule.AllowedClients
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
                    AllowedClients = Rule.AllowedClients
                };
                rules.Add(PsExportPolicyRule);
            }
            PsExportPolicy.Rules = rules.ToArray();
            return PsExportPolicy;
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
                ProvisioningState = volume.ProvisioningState,
                FileSystemId = volume.FileSystemId,
                ServiceLevel = volume.ServiceLevel,
                UsageThreshold = volume.UsageThreshold,
                ExportPolicy = (volume.ExportPolicy != null) ? ConvertExportPolicyToPs(volume.ExportPolicy) : null,
                ProtocolTypes = volume.ProtocolTypes,
                MountTargets = volume.MountTargets,
                SnapshotId = volume.SnapshotId,
                BaremetalTenantId = volume.BaremetalTenantId,
                SubnetId = volume.SubnetId
            };
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
                Tags = snapshot.Tags,
                FileSystemId = snapshot.FileSystemId,
                SnapshotId = snapshot.SnapshotId,
                Created = snapshot.Created,
                ProvisioningState = snapshot.ProvisioningState,
            };
        }
    }
}