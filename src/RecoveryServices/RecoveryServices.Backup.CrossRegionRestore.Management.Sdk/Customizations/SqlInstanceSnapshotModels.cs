// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Newtonsoft.Json;

// The legacy CRR Swagger owns the operations; the 2026-10-01 Backup Swagger owns
// these shared workload schemas. Keep the additions outside Generated.
namespace Microsoft.Azure.Management.RecoveryServices.Backup.CrossRegionRestore.Models
{
    [JsonObject("AzureVmWorkloadSQLInstance")]
    public partial class AzureVmWorkloadSQLInstanceProtectedItem : AzureVmWorkloadProtectedItem
    {
        [JsonProperty(PropertyName = "childDatabaseNameList")]
        public IList<string> ChildDatabaseNameList { get; set; }

        [JsonProperty(PropertyName = "instanceProtectionReadiness")]
        public string InstanceProtectionReadiness { get; set; }
    }

    public partial class ProtectedItem
    {
        [JsonProperty(PropertyName = "isArchiveEnabled")]
        public bool? IsArchiveEnabled { get; set; }

        [JsonProperty(PropertyName = "softDeleteRetentionPeriodInDays")]
        public int? SoftDeleteRetentionPeriodInDays { get; set; }
    }

    public partial class AzureVmWorkloadSQLDatabaseProtectedItem
    {
        [JsonProperty(PropertyName = "parentProtectedItem")]
        public string ParentProtectedItem { get; set; }

        [JsonProperty(PropertyName = "protectionLevel")]
        public string ProtectionLevel { get; set; }
    }

    public partial class AzureWorkloadSQLRecoveryPointExtendedInfo
    {
        [JsonProperty(PropertyName = "includedDatabases")]
        public IList<DatabaseInRP> IncludedDatabases { get; set; }

        [JsonProperty(PropertyName = "snapshotRecoveryPointInfo")]
        public SnapshotRecoveryPointInfo SnapshotRecoveryPointInfo { get; set; }
    }

    public partial class AzureWorkloadRestoreRequest
    {
        [JsonProperty(PropertyName = "targetResourceGroupName")]
        public string TargetResourceGroupName { get; set; }

        [JsonProperty(PropertyName = "userAssignedManagedIdentityDetails")]
        public UserAssignedManagedIdentityDetails UserAssignedManagedIdentityDetails { get; set; }

        [JsonProperty(PropertyName = "snapshotRestoreParameters")]
        public SnapshotRestoreParameters SnapshotRestoreParameters { get; set; }
    }

    public partial class TargetRestoreInfo
    {
        [JsonProperty(PropertyName = "targetDirectoryMapping")]
        public IDictionary<string, string> TargetDirectoryMapping { get; set; }
    }

    public partial class DatabaseInRP
    {
        [JsonProperty(PropertyName = "datasourceId")]
        public string DatasourceId { get; set; }

        [JsonProperty(PropertyName = "datasourceName")]
        public string DatasourceName { get; set; }
    }

    public partial class SnapshotRecoveryPointInfo
    {
        [JsonProperty(PropertyName = "snapshotResourceGroup")]
        public string SnapshotResourceGroup { get; set; }

        [JsonProperty(PropertyName = "sourceFilesystemInfo")]
        public IList<FilesystemInfo> SourceFilesystemInfo { get; set; }
    }

    public partial class FilesystemInfo
    {
        [JsonProperty(PropertyName = "volumeGuid")]
        public string VolumeGuid { get; set; }

        [JsonProperty(PropertyName = "fileSystemType")]
        public string FileSystemType { get; set; }

        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }

        [JsonProperty(PropertyName = "accessPaths")]
        public IList<string> AccessPaths { get; set; }

        [JsonProperty(PropertyName = "isOnStorageSpace")]
        public bool? IsOnStorageSpace { get; set; }

        [JsonProperty(PropertyName = "storageSpaceInfo")]
        public StorageSpaceInfo StorageSpaceInfo { get; set; }

        [JsonProperty(PropertyName = "diskInfoList")]
        public IList<DiskInfo> DiskInfoList { get; set; }
    }

    public partial class StorageSpaceInfo
    {
        [JsonProperty(PropertyName = "storagePoolUniqueId")]
        public string StoragePoolUniqueId { get; set; }

        [JsonProperty(PropertyName = "storagePoolFriendlyName")]
        public string StoragePoolFriendlyName { get; set; }

        [JsonProperty(PropertyName = "virtualDiskUniqueId")]
        public string VirtualDiskUniqueId { get; set; }

        [JsonProperty(PropertyName = "virtualDiskFriendlyName")]
        public string VirtualDiskFriendlyName { get; set; }
    }

    public partial class DiskInfo
    {
        [JsonProperty(PropertyName = "diskNumber")]
        public int? DiskNumber { get; set; }

        [JsonProperty(PropertyName = "diskUniqueId")]
        public string DiskUniqueId { get; set; }

        [JsonProperty(PropertyName = "diskGuid")]
        public string DiskGuid { get; set; }

        [JsonProperty(PropertyName = "diskLocation")]
        public string DiskLocation { get; set; }

        [JsonProperty(PropertyName = "sizeInBytes")]
        public long? SizeInBytes { get; set; }

        [JsonProperty(PropertyName = "friendlyName")]
        public string FriendlyName { get; set; }

        [JsonProperty(PropertyName = "lun")]
        public int? Lun { get; set; }

        [JsonProperty(PropertyName = "managedDiskId")]
        public string ManagedDiskId { get; set; }
    }

    public partial class SnapshotRestoreParameters
    {
        [JsonProperty(PropertyName = "skipAttachAndMount")]
        public bool? SkipAttachAndMount { get; set; }

        [JsonProperty(PropertyName = "logPointInTimeForDBRecovery")]
        public string LogPointInTimeForDbRecovery { get; set; }

        [JsonProperty(PropertyName = "disksToDetachOnClash")]
        public IList<string> DisksToDetachOnClash { get; set; }
    }

    public partial class UserAssignedManagedIdentityDetails
    {
        [JsonProperty(PropertyName = "identityArmId")]
        public string IdentityArmId { get; set; }

        [JsonProperty(PropertyName = "identityName")]
        public string IdentityName { get; set; }

        [JsonProperty(PropertyName = "userAssignedIdentityProperties")]
        public UserAssignedIdentityProperties UserAssignedIdentityProperties { get; set; }
    }

    public partial class UserAssignedIdentityProperties
    {
        [JsonProperty(PropertyName = "clientId")]
        public string ClientId { get; set; }

        [JsonProperty(PropertyName = "principalId")]
        public string PrincipalId { get; set; }
    }
}
