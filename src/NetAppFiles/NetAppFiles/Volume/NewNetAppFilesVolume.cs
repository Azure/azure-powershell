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

using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.NetAppFiles.Common;
using Microsoft.Azure.Commands.NetAppFiles.Helpers;
using Microsoft.Azure.Commands.NetAppFiles.Models;
using Microsoft.Azure.Management.NetApp;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System;
using Microsoft.Azure.Management.NetApp.Models;

namespace Microsoft.Azure.Commands.NetAppFiles.Volume
{
    [Cmdlet(
        "New",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesVolume",
        SupportsShouldProcess = true,
        DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSNetAppFilesVolume))]
    [Alias("New-AnfVolume")]
    public class NewAzureRmNetAppFilesVolume : AzureNetAppFilesCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The resource group of the ANF account")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The location of the resource")]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.NetApp/netAppAccounts/capacityPools/volumes")]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The name of the ANF account")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccount",
            nameof(ResourceGroupName))]
        public string AccountName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The name of the ANF pool")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts/capacityPools",
            nameof(ResourceGroupName),
            nameof(AccountName))]
        public string PoolName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the ANF volume")]
        [ValidateNotNullOrEmpty]
        [Alias("VolumeName")]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts/capacityPools/volumes",
            nameof(ResourceGroupName),
            nameof(AccountName),
            nameof(PoolName))]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The maximum storage quota allowed for a file system in bytes")]
        [ValidateNotNullOrEmpty]
        public long UsageThreshold { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The Azure Resource URI for a delegated subnet")]
        [ValidateNotNullOrEmpty]
        public string SubnetId { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "A unique file path for the volume")]
        [ValidateNotNullOrEmpty]
        public string CreationToken { get; set; }

        [Parameter(
            ParameterSetName = FieldsParameterSet,
            Mandatory = false,
            HelpMessage = "The type of the ANF volume")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("DataProtection")]
        public string VolumeType { get; set; }

        [Parameter(
            ParameterSetName = FieldsParameterSet,
            Mandatory = true,
            HelpMessage = "The service level of the ANF volume")]
        [Parameter(
            ParameterSetName = ParentObjectParameterSet,
            Mandatory = true,
            HelpMessage = "The service level of the ANF volume")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Standard", "Premium", "Ultra", "StandardZRS")]
        public string ServiceLevel { get; set; }

        [Parameter(
            ParameterSetName = FieldsParameterSet,
            Mandatory = false,
            HelpMessage = "Create volume from a snapshot. UUID v4 or resource identifier used to identify the Snapshot")]
        [ValidateNotNullOrEmpty]        
        public string SnapshotId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable array which represents the export policy")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesVolumeExportPolicy ExportPolicy { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable array which represents the replication object")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesReplicationObject ReplicationObject { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable array which represents the snapshot object")]
        [ValidateNotNullOrEmpty]
        [CmdletParameterBreakingChange("Snapshot", ChangeDescription = "Snapshot invalid and preserved for compatibility. Parameter SnapshotPolicyId should be used instead")]
        public PSNetAppFilesVolumeSnapshot Snapshot { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Snapshot Policy ResourceId used to apply a snapshot policy to the volume")]
        [ValidateNotNullOrEmpty]
        public string SnapshotPolicyId { get; set; }
        
        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable array which represents the backup object")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesVolumeBackupProperties Backup { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable array which represents the protocol types. You need to create Active Directory connections before creating an SMB/CIFS volume")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("NFSv3", "NFSv4.1", "CIFS")]
        public string[] ProtocolType { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "If enabled (true) the volume will contain a read-only .snapshot directory which provides access to each of the volume's snapshots (default to true)")]
        public SwitchParameter SnapshotDirectoryVisible { get; set; }

        [Parameter(
            ParameterSetName = FieldsParameterSet,
            Mandatory = false,
            HelpMessage = "Backup ID. UUID v4 or resource identifier used to identify the Backup.")]        
        public string BackupId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The security style of volume. Possible values include: 'ntfs', 'unix'")]
        [PSArgumentCompleter("ntfs", "unix")]
        public string SecurityStyle { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Maximum throughput in Mibps that can be achieved by this volume, this will be accepted as input only for manual qosType volume")]
        public double? ThroughputMibps { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Describe if a volume is Kerberos Enabled.")]
        public SwitchParameter KerberosEnabled { get; set; }
        
        [Parameter(
            Mandatory = false,
            HelpMessage = "Enables encryption for in-flight smb3 data. Only applicable for SMB/DualProtocol volume.")]
        public SwitchParameter SmbEncryption { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Enables continuously available share property for SMB volume. Only applicable for SMB volume.")]
        public SwitchParameter SmbContinuouslyAvailable { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specifies whether LDAP is enabled or not for a given NFS volume.")]
        public SwitchParameter LdapEnabled { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specifies whether Cool Access(tiering) is enabled for the volume (default false).")]
        public SwitchParameter CoolAccess { get; set; }

        [Parameter(
            Mandatory = false,            
            HelpMessage = "Specifies the number of days after which data that is not accessed by clients will be tiered (minimum 7, maximum 63).")]
        public int? CoolnessPeriod { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "UNIX permissions for NFS volume accepted in octal 4 digit format. First digit selects the set user ID(4), set group ID (2) and sticky (1) attributes. Second digit selects permission for the owner of the file: read (4), write (2) and execute (1). Third selects permissions for other users in the same group. the fourth for other users not in the group. 0755 - gives read/write/execute permissions to owner and read/execute to group and other users.")]
        [CmdletParameterBreakingChange("UnixPermissions", ChangeDescription = "Parameter Alias UnixPermissions will be removed, please use UnixPermission.")]
        [Alias("UnixPermissions")]
        public string UnixPermission { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specifies whether the volume is enabled for Azure VMware Solution (AVS) datastore purpose (Enabled, Disabled)")]
        [PSArgumentCompleter("Enabled", "Disabled")]
        public string AvsDataStore { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specifies if default quota is enabled for the volume")]
        public SwitchParameter IsDefaultQuotaEnabled { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Default user quota for volume in KiBs. If isDefaultQuotaEnabled is set, the minimum value of 4 KiBs applies.")]
        public long? DefaultUserQuotaInKiB { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Default group quota for volume in KiBs. If isDefaultQuotaEnabled is set, the minimum value of 4 KiBs applies.")]
        public long? DefaultGroupQuotaInKiB { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Basic network, or Standard features available to the volume (Basic, Standard).")]
        [PSArgumentCompleter("Basic", "Standard")]
        public string NetworkFeature { get; set; }

        [Parameter(            
            Mandatory = false,
            HelpMessage = "Pool Resource Id used in case of creating a volume through volume group.")]
        [ValidateNotNullOrEmpty]
        public string CapacityPoolResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Proximity placement group associated with the volume.")]
        [ValidateNotNullOrEmpty]
        public string ProximityPlacementGroup { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Volume spec name is the application specific designation or identifier for the particular volume in a volume group for e.g. data, log.")]
        [ValidateNotNullOrEmpty]
        public string VolumeSpecName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Application specific placement rules for the particular volume.")]
        [ValidateNotNullOrEmpty]
        public IList<PSKeyValuePairs> PlacementRule { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Flag indicating whether subvolume operations are enabled on the volume (Enabled, Disabled)")]        
        public SwitchParameter EnableSubvolume { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable which represents resource tags")]
        [ValidateNotNullOrEmpty]
        [Alias("Tags")]
        public Hashtable Tag { get; set; }

        [Parameter(
            ParameterSetName = ParentObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The pool for the new volume object")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesPool PoolObject { get; set; }

        public override void ExecuteCmdlet()
        {
            IDictionary<string, string> tagPairs = null;

            if (Tag != null)
            {
                tagPairs = new Dictionary<string, string>();

                foreach (string key in Tag.Keys)
                {
                    tagPairs.Add(key, Tag[key].ToString());
                }
            }

            if (ParameterSetName == ParentObjectParameterSet)
            {
                ResourceGroupName = PoolObject.ResourceGroupName;
                Location = PoolObject.Location;
                var NameParts = PoolObject.Name.Split('/');
                AccountName = NameParts[0];
                PoolName = NameParts[1];
            }

            PSNetAppFilesVolumeDataProtection dataProtection = null;
            if (ReplicationObject != null || !string.IsNullOrWhiteSpace(SnapshotPolicyId) || Backup != null)
            {
                dataProtection = new PSNetAppFilesVolumeDataProtection
                {
                    Replication = ReplicationObject,
                    Snapshot = new PSNetAppFilesVolumeSnapshot() { SnapshotPolicyId = SnapshotPolicyId },
                    Backup = Backup
                };
            }

            var volumeBody = new Management.NetApp.Models.Volume()
            {
                ServiceLevel = ServiceLevel,
                UsageThreshold = UsageThreshold,
                CreationToken = CreationToken,
                SubnetId = SubnetId,
                Location = Location,
                ExportPolicy = (ExportPolicy != null) ? ModelExtensions.ConvertExportPolicyFromPs(ExportPolicy) : null,
                DataProtection = (dataProtection != null) ? ModelExtensions.ConvertDataProtectionFromPs(dataProtection) : null,
                VolumeType = VolumeType,
                ProtocolTypes = ProtocolType,
                Tags = tagPairs,
                SnapshotId = SnapshotId,                
                SnapshotDirectoryVisible = SnapshotDirectoryVisible,
                SecurityStyle = SecurityStyle,
                BackupId = BackupId,
                ThroughputMibps = ThroughputMibps,
                KerberosEnabled = KerberosEnabled.IsPresent,
                SmbEncryption = SmbEncryption,
                SmbContinuouslyAvailable = SmbContinuouslyAvailable,
                LdapEnabled = LdapEnabled,
                CoolAccess = CoolAccess,
                CoolnessPeriod = CoolnessPeriod,
                UnixPermissions = UnixPermission,
                AvsDataStore = AvsDataStore,
                IsDefaultQuotaEnabled = IsDefaultQuotaEnabled,
                DefaultUserQuotaInKiBs = DefaultUserQuotaInKiB,
                DefaultGroupQuotaInKiBs = DefaultGroupQuotaInKiB,
                NetworkFeatures = NetworkFeature,
                CapacityPoolResourceId = CapacityPoolResourceId,
                ProximityPlacementGroup = ProximityPlacementGroup,
                VolumeSpecName = VolumeSpecName,
                PlacementRules = PlacementRule?.ToPlacementKeyValuePairs(),
                EnableSubvolumes = EnableSubvolume.IsPresent ? EnableSubvolumes.Enabled : EnableSubvolumes.Disabled,
            };

            if (ShouldProcess(PoolName, string.Format(PowerShell.Cmdlets.NetAppFiles.Properties.Resources.CreateResourceMessage, Name)))
            {
                var anfVolume = AzureNetAppFilesManagementClient.Volumes.CreateOrUpdate(volumeBody, ResourceGroupName, AccountName, PoolName, Name);
                WriteObject(anfVolume.ToPsNetAppFilesVolume());
            }
        }
    }
}
