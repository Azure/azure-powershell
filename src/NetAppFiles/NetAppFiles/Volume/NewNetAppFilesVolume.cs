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
using Microsoft.Azure.Management.NetApp.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Rest.Azure;

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
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The name of the ANF volume")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the ANF volume",
            ParameterSetName = ParentObjectParameterSet)]
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
            HelpMessage = "Maximum storage quota allowed for a file system in bytes. This is a soft quota used for alerting only. Minimum size is 100 GiB. Upper limit is 100TiB, 500Tib for LargeVolume or 2400Tib for LargeVolume on exceptional basis. Specified in bytes.")]
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
            HelpMessage = "Create volume from a snapshot. Resource identifier used to identify the Snapshot")]
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
            HelpMessage = "Backup ID. Resource identifier used to identify the Backup.")]        
        public string BackupId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The security style of volume. Possible values include: 'ntfs', 'unix'")]
        [PSArgumentCompleter("ntfs", "unix")]
        public string SecurityStyle { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Maximum throughput in MiB/s that can be achieved by this volume, this will be accepted as input only for manual qosType volume")]
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
            HelpMessage = "Specifies the number of days after which data that is not accessed by clients will be tiered (minimum 2, maximum 183).")]
        public int? CoolnessPeriod { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "CoolAccessRetrievalPolicy determines the data retrieval behavior from the cool tier to standard storage based on the read pattern for cool access enabled volumes. The possible values for this field are: \n Default - Data will be pulled from cool tier to standard storage on random reads. This policy is the default.\n OnRead - All client-driven data read is pulled from cool tier to standard storage on both sequential and random reads.\n Never - No client-driven data is pulled from cool tier to standard storage.")]
        [PSArgumentCompleter("Default", "OnRead", "Never")]
        public string CoolAccessRetrievalPolicy { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "UNIX permissions for NFS volume accepted in octal 4 digit format. First digit selects the set user ID(4), set group ID (2) and sticky (1) attributes. Second digit selects permission for the owner of the file: read (4), write (2) and execute (1). Third selects permissions for other users in the same group. the fourth for other users not in the group. 0755 - gives read/write/execute permissions to owner and read/execute to group and other users.")]
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
            HelpMessage = "A list of Availability Zones")]
        public string[] Zone { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Source of key used to encrypt data in volume. Applicable if NetApp account has encryption.keySource = 'Microsoft.KeyVault'. Possible values are: 'Microsoft.NetApp, Microsoft.KeyVault'")]
        [PSArgumentCompleter("Microsoft.NetApp", "Microsoft.KeyVault")]
        public string EncryptionKeySource { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The resource ID of private endpoint for KeyVault. It must reside in the same VNET as the volume. Only applicable if encryptionKeySource = 'Microsoft.KeyVault'")]
        public string KeyVaultPrivateEndpointResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "If enabled (true) the snapshot the volume was created from will be automatically deleted after the volume create operation has finished.  Defaults to false")]
        public SwitchParameter DeleteBaseSnapshot { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Enables access based enumeration share property for SMB Shares. Only applicable for SMB/DualProtocol volume")]
        [PSArgumentCompleter("Disabled", "Enabled")]
        public string SmbAccessBasedEnumeration { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Enables non browsable property for SMB Shares. Only applicable for SMB/DualProtocol volume")]
        [PSArgumentCompleter("Disabled", "Enabled")]
        public string SmbNonBrowsable { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specifies whether volume is a Large Volume or Regular Volume. Defaults to false")]
        public SwitchParameter IsLargeVolume { get; set; }

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

            //if (Backup != null)
            //{
            //    ExecuteCmdlet_2022_11_01(tagPairs);
            //}
            //else
            //{
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
                    EncryptionKeySource = EncryptionKeySource,
                    KeyVaultPrivateEndpointResourceId = KeyVaultPrivateEndpointResourceId,
                    DeleteBaseSnapshot = DeleteBaseSnapshot,
                    SmbAccessBasedEnumeration = SmbAccessBasedEnumeration,
                    SmbNonBrowsable = SmbNonBrowsable,
                    CoolAccessRetrievalPolicy = CoolAccessRetrievalPolicy
                };
                if (IsLargeVolume.IsPresent)
                {
                    volumeBody.IsLargeVolume = IsLargeVolume;
                }
                if (SnapshotDirectoryVisible.IsPresent)
                {
                    volumeBody.SnapshotDirectoryVisible = SnapshotDirectoryVisible;
                }
                if (this.Zone != null)
                {
                    volumeBody.Zones = this.Zone?.ToList();
                }
                if (ShouldProcess(PoolName, string.Format(PowerShell.Cmdlets.NetAppFiles.Properties.Resources.CreateResourceMessage, Name)))
                {
                    var anfVolume = AzureNetAppFilesManagementClient.Volumes.CreateOrUpdate(ResourceGroupName, AccountName, PoolName, Name, volumeBody);
                    WriteObject(anfVolume.ToPsNetAppFilesVolume());
                }
            //}
        }

        private void ExecuteCmdlet_2022_11_01(IDictionary<string, string> tagPairs)
        {
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

            var volumeBody = new Management.NetApp.Models.Volume_2022_11_01()
            {
                ServiceLevel = ServiceLevel,
                UsageThreshold = UsageThreshold,
                CreationToken = CreationToken,
                SubnetId = SubnetId,
                Location = Location,
                ExportPolicy = (ExportPolicy != null) ? ModelExtensions.ConvertExportPolicyFromPs(ExportPolicy) : null,
                DataProtection = (dataProtection != null) ? ModelExtensions.ConvertDataProtection_2022_11_01_FromPs(dataProtection) : null,
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
                EncryptionKeySource = EncryptionKeySource,
                KeyVaultPrivateEndpointResourceId = KeyVaultPrivateEndpointResourceId,
                DeleteBaseSnapshot = DeleteBaseSnapshot,
                SmbAccessBasedEnumeration = SmbAccessBasedEnumeration,
                SmbNonBrowsable = SmbNonBrowsable,
                CoolAccessRetrievalPolicy = CoolAccessRetrievalPolicy
            };
            if (IsLargeVolume.IsPresent)
            {
                volumeBody.IsLargeVolume = IsLargeVolume;
            }
            if (SnapshotDirectoryVisible.IsPresent)
            {
                volumeBody.SnapshotDirectoryVisible = SnapshotDirectoryVisible;
            }
            if (this.Zone != null)
            {
                volumeBody.Zones = this.Zone?.ToList();
            }
            if (ShouldProcess(PoolName, string.Format(PowerShell.Cmdlets.NetAppFiles.Properties.Resources.CreateResourceMessage, Name)))
            {
                try
                {
                    var anfVolume = AzureNetAppFilesManagementClient.Volume_2022_11_01.CreateOrUpdate(ResourceGroupName, AccountName, PoolName, Name, volumeBody);
                    WriteObject(anfVolume.ToPsNetAppFilesVolume());
                }
                catch (ErrorResponseException ex)
                {
                    throw new CloudException(ex.Body.Error.Message, ex);
                }
            }
        }
    }
}
