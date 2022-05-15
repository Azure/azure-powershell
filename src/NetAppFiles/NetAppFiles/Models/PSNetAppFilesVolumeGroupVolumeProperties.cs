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
namespace Microsoft.Azure.Commands.NetAppFiles.Models
{
    using Microsoft.Azure.Management.NetApp.Models;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Volume group properties
    /// </summary>
    public class PSNetAppFilesVolumeGroupVolumeProperties
    {
        /// <summary>
        /// Gets resource Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets resource name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets resource type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets resource tags
        /// </summary>
        public IDictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Gets fileSystem ID
        /// </summary>
        /// <remarks>
        /// Unique FileSystem Identifier.
        /// </remarks>
        public string FileSystemId { get; set; }

        /// <summary>
        /// Gets or sets creation Token or File Path
        /// </summary>
        /// <remarks>
        /// A unique file path for the volume. Used when creating mount targets
        /// </remarks>
        public string CreationToken { get; set; }

        /// <summary>
        /// Gets or sets serviceLevel
        /// </summary>
        /// <remarks>
        /// Possible values include: 'Standard', 'Premium', 'Ultra',
        /// 'StandardZRS'
        /// </remarks>
        public string ServiceLevel { get; set; }

        /// <summary>
        /// Gets or sets usageThreshold
        /// </summary>
        /// <remarks>
        /// Maximum storage quota allowed for a file system in bytes. This is a
        /// soft quota used for alerting only. Minimum size is 100 GiB. Upper
        /// limit is 100TiB. Specified in bytes.
        /// </remarks>
        public long UsageThreshold { get; set; }

        /// <summary>
        /// Gets or sets exportPolicy
        /// </summary>
        /// <remarks>
        /// Set of export policy rules
        /// </remarks>
        public PSNetAppFilesVolumeExportPolicy ExportPolicy { get; set; }

        /// <summary>
        /// Gets or sets protocolTypes
        /// </summary>
        /// <remarks>
        /// Set of protocol types, default NFSv3, CIFS for SMB protocol
        /// </remarks>
        public IList<string> ProtocolTypes { get; set; }

        /// <summary>
        /// Gets azure lifecycle management
        /// </summary>
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Gets or sets snapshot ID
        /// </summary>
        /// <remarks>
        /// UUID v4 or resource identifier used to identify the Snapshot.
        /// </remarks>
        public string SnapshotId { get; set; }

        /// <summary>
        /// Gets or sets backup ID
        /// </summary>
        /// <remarks>
        /// UUID v4 or resource identifier used to identify the Backup.
        /// </remarks>
        public string BackupId { get; set; }

        /// <summary>
        /// Gets baremetal Tenant ID
        /// </summary>
        /// <remarks>
        /// Unique Baremetal Tenant Identifier.
        /// </remarks>
        public string BaremetalTenantId { get; set; }

        /// <summary>
        /// Gets or sets the Azure Resource URI for a delegated subnet. Must
        /// have the delegation Microsoft.NetApp/volumes
        /// </summary>
        public string SubnetId { get; set; }

        /// <summary>
        /// Gets or sets network features
        /// </summary>
        /// <remarks>
        /// Basic network, or Standard features available to the volume.
        /// Possible values include: 'Basic', 'Standard'
        /// </remarks>
        public string NetworkFeatures { get; set; }

        /// <summary>
        /// Gets network Sibling Set ID
        /// </summary>
        /// <remarks>
        /// Network Sibling Set ID for the the group of volumes sharing
        /// networking resources.
        /// </remarks>
        public string NetworkSiblingSetId { get; set; }

        /// <summary>
        /// Gets storage to Network Proximity
        /// </summary>
        /// <remarks>
        /// Provides storage to network proximity information for the volume.
        /// Possible values include: 'Default', 'T1', 'T2'
        /// </remarks>
        public string StorageToNetworkProximity { get; set; }

        /// <summary>
        /// Gets mountTargets
        /// </summary>
        /// <remarks>
        /// List of mount targets
        /// </remarks>
        public IList<MountTargetProperties> MountTargets { get; set; }

        /// <summary>
        /// Gets or sets what type of volume is this. For destination volumes
        /// in Cross Region Replication, set type to DataProtection
        /// </summary>
        public string VolumeType { get; set; }

        /// <summary>
        /// Gets or sets dataProtection
        /// </summary>
        /// <remarks>
        /// DataProtection type volumes include an object containing details of
        /// the replication
        /// </remarks>
        public PSNetAppFilesVolumeDataProtection DataProtection { get; set; }

        /// <summary>
        /// Gets or sets restoring
        /// </summary>
        public bool? IsRestoring { get; set; }

        /// <summary>
        /// Gets or sets if enabled (true) the volume will contain a read-only
        /// snapshot directory which provides access to each of the volume's
        /// snapshots (default to true).
        /// </summary>
        public bool? SnapshotDirectoryVisible { get; set; }

        /// <summary>
        /// Gets or sets describe if a volume is KerberosEnabled. To be use
        /// with swagger version 2020-05-01 or later
        /// </summary>
        public bool? KerberosEnabled { get; set; }

        /// <summary>
        /// Gets or sets the security style of volume, default unix, defaults
        /// to ntfs for dual protocol or CIFS protocol. Possible values
        /// include: 'ntfs', 'unix'
        /// </summary>
        public string SecurityStyle { get; set; }

        /// <summary>
        /// Gets or sets enables encryption for in-flight smb3 data. Only
        /// applicable for SMB/DualProtocol volume. To be used with swagger
        /// version 2020-08-01 or later
        /// </summary>
        public bool? SmbEncryption { get; set; }

        /// <summary>
        /// Gets or sets enables continuously available share property for smb
        /// volume. Only applicable for SMB volume
        /// </summary>
        public bool? SmbContinuouslyAvailable { get; set; }

        /// <summary>
        /// Gets or sets maximum throughput in Mibps that can be achieved by
        /// this volume and this will be accepted as input only for manual
        /// qosType volume
        /// </summary>
        public double? ThroughputMibps { get; set; }

        /// <summary>
        /// Gets or sets encryption Key Source. Possible values are:
        /// 'Microsoft.NetApp'
        /// </summary>
        public string EncryptionKeySource { get; set; }

        /// <summary>
        /// Gets or sets specifies whether LDAP is enabled or not for a given
        /// NFS volume.
        /// </summary>
        public bool? LdapEnabled { get; set; }

        /// <summary>
        /// Gets or sets specifies whether Cool Access(tiering) is enabled for
        /// the volume.
        /// </summary>
        public bool? CoolAccess { get; set; }

        /// <summary>
        /// Gets or sets specifies the number of days after which data that is
        /// not accessed by clients will be tiered.
        /// </summary>
        public int? CoolnessPeriod { get; set; }

        /// <summary>
        /// Gets or sets UNIX permissions for NFS volume accepted in octal 4
        /// digit format. First digit selects the set user ID(4), set group ID
        /// (2) and sticky (1) attributes. Second digit selects permission for
        /// the owner of the file: read (4), write (2) and execute (1). Third
        /// selects permissions for other users in the same group. the fourth
        /// for other users not in the group. 0755 - gives read/write/execute
        /// permissions to owner and read/execute to group and other users.
        /// </summary>
        public string UnixPermissions { get; set; }

        /// <summary>
        /// Gets when a volume is being restored from another volume's
        /// snapshot, will show the percentage completion of this cloning
        /// process. When this value is empty/null there is no cloning process
        /// currently happening on this volume. This value will update every 5
        /// minutes during cloning.
        /// </summary>
        public int? CloneProgress { get; set; }

        /// <summary>
        /// Gets or sets avsDataStore
        /// </summary>
        /// <remarks>
        /// Specifies whether the volume is enabled for Azure VMware Solution
        /// (AVS) datastore purpose. Possible values include: 'Enabled',
        /// 'Disabled'
        /// </remarks>
        public string AvsDataStore { get; set; }

        /// <summary>
        /// Gets or sets specifies if default quota is enabled for the volume.
        /// </summary>
        public bool? IsDefaultQuotaEnabled { get; set; }

        /// <summary>
        /// Gets or sets default user quota for volume in KiBs. If
        /// isDefaultQuotaEnabled is set, the minimum value of 4 KiBs applies .
        /// </summary>
        public long? DefaultUserQuotaInKiBs { get; set; }

        /// <summary>
        /// Gets or sets default group quota for volume in KiBs. If
        /// isDefaultQuotaEnabled is set, the minimum value of 4 KiBs applies.
        /// </summary>
        public long? DefaultGroupQuotaInKiBs { get; set; }

        /// <summary>
        /// Gets maximum number of files allowed. Needs a service request in
        /// order to be changed. Only allowed to be changed if volume quota is
        /// more than 4TiB.
        /// </summary>
        public long? MaximumNumberOfFiles { get; set; }

        /// <summary>
        /// Gets volume Group Name
        /// </summary>
        public string VolumeGroupName { get; set; }

        /// <summary>
        /// Gets or sets pool Resource Id used in case of creating a volume
        /// through volume group
        /// </summary>
        public string CapacityPoolResourceId { get; set; }

        /// <summary>
        /// Gets or sets proximity placement group associated with the volume
        /// </summary>
        public string ProximityPlacementGroup { get; set; }

        /// <summary>
        /// Gets T2 network information
        /// </summary>
        public string T2Network { get; set; }

        /// <summary>
        /// Gets or sets volume spec name is the application specific
        /// designation or identifier for the particular volume in a volume
        /// group for e.g. data, log
        /// </summary>
        public string VolumeSpecName { get; set; }

        /// <summary>
        /// Gets or sets volume placement rules
        /// </summary>
        /// <remarks>
        /// Application specific placement rules for the particular volume
        /// </remarks>
        public IList<PlacementKeyValuePairs> PlacementRules { get; set; }

        /// <summary>
        /// Gets or sets flag indicating whether subvolume operations are
        /// enabled on the volume. Possible values include: 'Enabled',
        /// 'Disabled'
        /// </summary>
        public string EnableSubvolumes { get; set; }

    }
}
