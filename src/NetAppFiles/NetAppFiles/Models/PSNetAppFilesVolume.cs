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

using System.Collections.Generic;

namespace Microsoft.Azure.Commands.NetAppFiles.Models
{
    /// <summary>
    /// ARM tracked resource
    /// </summary>
    public class PSNetAppFilesVolume
    {
        /// <summary>
        /// Gets or sets the Resource group name
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets Resource location
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets resource Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets resource name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets resource type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets resource tags
        /// </summary>
        public object Tags { get; set; }

        /// <summary>
        /// Gets or sets resource etag
        /// </summary>
        /// <remarks>
        /// A unique read-only string that changes whenever the resource is updated.
        /// </remarks>
        public string Etag { get; set; }

        /// <summary>
        /// Gets azure lifecycle management
        /// </summary>
        public string ProvisioningState { get; set; }

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
        /// The service level of the file system. Possible values include:
        /// 'Standard', 'Premium', 'Ultra'
        /// </remarks>
        public string ServiceLevel { get; set; }

        /// <summary>
        /// Gets or sets usageThreshold
        /// </summary>
        /// <remarks>
        /// Maximum storage quota allowed for a file system in bytes. This is a
        /// soft quota used for alerting only. Minimum size is 100 GiB. Upper
        /// limit is 100TiB.
        /// </remarks>
        public long? UsageThreshold { get; set; }

        /// <summary>
        /// Gets or sets exportPolicy
        /// </summary>
        /// <remarks>
        /// Set of export policy rules
        /// </remarks>
        public PSNetAppFilesVolumeExportPolicy ExportPolicy { get; set; }

        /// <summary>
        /// Gets or sets the protocol types
        /// </summary>
        /// <remarks>
        /// Protocol types usable by the volume
        /// </remarks>
        public IList<string> ProtocolTypes { get; set; }

        /// <summary>
        /// Gets or sets the mount targets
        /// </summary>
        /// <remarks>
        /// Mount targets associated with the volume
        /// </remarks>
        public object MountTargets { get; set; }

        /// <summary>
        /// Gets or sets snapshot ID
        /// </summary>
        /// <remarks>
        /// UUID v4 used to identify the Snapshot
        /// </remarks>
        public string SnapshotId { get; set; }

        /// <summary>
        /// Gets or sets baremetal Tenant ID
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
        /// Gets or sets the type of the volume
        /// </summary>
        public string VolumeType { get; set; }

        /// <summary>
        /// Gets or sets the DataProtection properties
        /// </summary>
        /// <remarks>
        /// DataProtection type volumes include an object containing details of the replication
        /// </remarks>
        public PSNetAppFilesVolumeDataProtection DataProtection { get; set; }

        /// <summary>
        /// Gets or sets restoring
        /// </summary>
        public bool? IsRestoring { get; set; }

        /// <summary>
        /// If enabled (true) the volume will contain a read-only .snapshot directory which provides access to each of the volume's snapshots (default to true)
        /// </summary>
        public bool? SnapshotDirectoryVisible { get; set; }

        /// <summary>
        /// Gets or sets backup ID
        /// </summary>
        /// <remarks>
        /// UUID v4 or resource identifier used to identify the Backup.
        /// </remarks>
        public string BackupId { get; set; }

        /// <summary>
        /// Gets or sets SecurityStyle
        /// </summary>
        /// <remarks>
        /// The security style of volume. Possible values include: 'ntfs', 'unix'        
        /// </remarks>
        public string SecurityStyle { get; set; }

        /// <summary>
        /// Gets or sets ThroughputMibps
        /// </summary>
        /// <remarks>
        ///  Maximum throughput in Mibps that can be achieved by this volume
        /// </remarks>
        public double? ThroughputMibps { get; set; }


        /// <summary>
        /// Gets or sets KerberosEnabled
        /// </summary>
        /// <remarks>
        ///  describe if a volume is KerberosEnabled.
        /// </remarks>
        public bool? KerberosEnabled { get; set; }

        /// <summary>
        /// Gets or sets SmbEncryption
        /// </summary>
        /// <remarks>
        ///  Enables encryption for in-flight smb3 data. Only applicable for SMB/DualProtocol volume. 
        /// </remarks>
        public bool? SmbEncryption { get; set; }

        /// <summary>
        /// Gets or sets SmbContinuouslyAvailable
        /// </summary>
        /// <remarks>
        ///  Enables continuously available share property for SMB volume. Only applicable for SMB volume
        /// </remarks>
        public bool? SmbContinuouslyAvailable { get; set; }

        /// <summary>
        /// Gets or sets LdapEnabled
        /// </summary>
        /// <remarks>
        ///  Specifies whether LDAP is enabled or not for a given NFS volume.
        /// </remarks>
        public bool? LdapEnabled { get; set; }

        /// <summary>
        /// Gets or sets CoolAccess
        /// </summary>
        /// <value>
        /// Specifies whether Cool Access(tiering) is enabled for the volume.
        /// </value>
        public bool? CoolAccess { get; set; }

        /// <summary>
        /// Gets or sets CoolnessPeriod
        /// </summary>
        /// <value>
        /// Specifies the number of days after which data that is not accessed by clients will be tiered.
        /// </value>
        public int? CoolnessPeriod { get; set; }

        /// <summary>
        /// Gets or sets UnixPermission
        /// </summary>
        /// <value>
        /// UNIX permissions for NFS volume accepted in octal 4 digit format. First digit selects the set user ID(4), set group ID (2) and sticky (1) attributes. 
        /// Second digit selects permission for the owner of the file: read (4), write (2) and execute (1). Third selects permissions for other users in the same group. 
        /// The fourth for other users not in the group. 0755 - gives read/write/execute permissions to owner and read/execute to group and other users.
        /// </value>
        public string UnixPermission { get; set; }

        /// <summary>
        /// Gets or sets CloneProgress
        /// </summary>
        /// <value>
        /// When a volume is being restored from another volume's snapshot, will show the percentage completion of this cloning process. When this value is empty/null there is no cloning process currently happening on this volume.
        /// This value will update every 5 minutes during cloning.
        /// </value>
        public int? CloneProgress { get; set; }

        /// <summary>
        /// Gets or sets AvsDataStore
        /// </summary>
        /// <value>
        /// Specifies whether the volume is enabled for Azure VMware Solution (AVS) datastore purpose (Enabled, Disabled)
        /// </value>
        public string AvsDataStore { get; set; }

        /// <summary>
        /// Gets or sets IsDefaultQuotaEnabled
        /// </summary>
        /// <value>
        /// Specifies if default quota is enabled for the volume
        /// </value>
        public bool? IsDefaultQuotaEnabled { get; set; }

        /// <summary>
        /// Gets or sets DefaultUserQuotaInKiBs
        /// </summary>
        /// <value>
        /// Default user quota for volume in KiBs. If isDefaultQuotaEnabled is set, the minimum value of 4 KiBs applies
        /// </value>
        public long? DefaultUserQuotaInKiBs { get; set; }

        /// <summary>
        /// Gets or sets DefaultGroupQuotaInKiBs
        /// </summary>
        /// <value>
        /// Default group quota for volume in KiBs. If isDefaultQuotaEnabled is set, the minimum value of 4 KiBs applies
        /// </value>
        public long? DefaultGroupQuotaInKiBs { get; set; }

        /// <summary>
        /// Gets or sets NetworkFeatures
        /// </summary>
        /// <value>
        /// Basic network, or Standard features available to the volume (Basic, Standard).
        /// </value>
        public string NetworkFeatures { get; set; }

        /// <summary>
        /// Gets or sets NetworkSiblingSetId
        /// </summary>
        /// <value>
        /// Network Sibling Set ID for the group of volumes sharing networking resources example (9760acf5-4638-11e7-9bdb-020073ca3333).
        /// </value>
        public string NetworkSiblingSetId { get; set; }

        /// <summary>
        /// Gets or sets NetworkFeatures
        /// </summary>
        /// <value>
        /// Provides storage to network proximity information for the volume (Default, T1, T2).
        /// Default: Basic storage to network connectivity
        /// T1: Standard T1 storage to network connectivity.
        /// T2: Standard T2 storage to network connectivity.
        /// </value>
        public string StorageToNetworkProximity { get; set; }

        /// <summary>
        /// Gets or sets VolumeGroupName
        /// </summary>
        /// <value>
        /// Volume Group Name
        /// </value>
        public string VolumeGroupName { get; set; }

        /// <summary>
        /// Gets or sets CapacityPoolResourceId
        /// </summary>
        /// <value>
        /// Pool Resource Id used in case of creating a volume through volume group
        /// </value>
        public string CapacityPoolResourceId { get; set; }

        /// <summary>
        /// Gets or sets ProximityPlacementGroup
        /// </summary>
        /// <value>
        /// Proximity placement group associated with the volume
        /// </value>
        public string ProximityPlacementGroup { get; set; }

        /// <summary>
        /// Gets or sets T2Network
        /// </summary>
        /// <value>
        /// T2 network information
        /// </value>
        public string T2Network { get; set; }

        /// <summary>
        /// Gets or sets PlacementRules
        /// </summary>
        /// <value>
        /// Application specific placement rules for the particular volume.
        /// </value>
        public IList<PSKeyValuePairs> PlacementRules { get; set; }

        /// <summary>
        /// Gets or sets SystemData
        /// </summary>
        public PSSystemData SystemData { get; set; }

        /// <summary>
        /// Gets or sets MaximumNumberOfFiles
        /// </summary>
        /// <value>
        /// Gets maximum number of files allowed. Needs a service request in
        /// order to be changed. Only allowed to be changed if volume quota is
        /// more than 4TiB.
        /// </value>
        public long? MaximumNumberOfFiles {get; set;}

        /// <summary>
        /// Gets or sets EnableSubvolumes
        /// </summary>
        /// <value>
        /// Gets or sets flag indicating whether subvolume operations are
        /// enabled on the volume. Possible values include: 'Enabled',
        /// 'Disabled'
        /// </value>
        public string EnableSubvolumes { get; set; }
    }
}