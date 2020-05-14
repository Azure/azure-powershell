namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Backup description.</summary>
    public partial class BackupItem :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItem,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>Id of the backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? BackupId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).BackupId; }

        /// <summary>Name of the blob which contains data for this backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string BlobName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).BlobName; }

        /// <summary>
        /// Unique correlation identifier. Please use this along with the timestamp while communicating with Azure support.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CorrelationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).CorrelationId; }

        /// <summary>Timestamp of the backup creation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? Created { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).Created; }

        /// <summary>List of databases included in the backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSetting[] Database { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).Database; }

        /// <summary>Timestamp when this backup finished.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? FinishedTimeStamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).FinishedTimeStamp; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>Timestamp of a last restore operation which used this backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? LastRestoreTimeStamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).LastRestoreTimeStamp; }

        /// <summary>Details regarding this backup. Might contain an error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Log { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).Log; }

        /// <summary>Internal Acessors for BackupId</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemInternal.BackupId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).BackupId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).BackupId = value; }

        /// <summary>Internal Acessors for BlobName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemInternal.BlobName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).BlobName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).BlobName = value; }

        /// <summary>Internal Acessors for CorrelationId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemInternal.CorrelationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).CorrelationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).CorrelationId = value; }

        /// <summary>Internal Acessors for Created</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemInternal.Created { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).Created; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).Created = value; }

        /// <summary>Internal Acessors for Database</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSetting[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemInternal.Database { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).Database; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).Database = value; }

        /// <summary>Internal Acessors for FinishedTimeStamp</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemInternal.FinishedTimeStamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).FinishedTimeStamp; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).FinishedTimeStamp = value; }

        /// <summary>Internal Acessors for LastRestoreTimeStamp</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemInternal.LastRestoreTimeStamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).LastRestoreTimeStamp; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).LastRestoreTimeStamp = value; }

        /// <summary>Internal Acessors for Log</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemInternal.Log { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).Log; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).Log = value; }

        /// <summary>Internal Acessors for PropertiesName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemInternal.PropertiesName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).Name = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.BackupItemProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Scheduled</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemInternal.Scheduled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).Scheduled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).Scheduled = value; }

        /// <summary>Internal Acessors for SizeInByte</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemInternal.SizeInByte { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).SizeInByte; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).SizeInByte = value; }

        /// <summary>Internal Acessors for Status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BackupItemStatus? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemInternal.Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).Status = value; }

        /// <summary>Internal Acessors for StorageAccountUrl</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemInternal.StorageAccountUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).StorageAccountUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).StorageAccountUrl = value; }

        /// <summary>Internal Acessors for WebsiteSizeInByte</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemInternal.WebsiteSizeInByte { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).WebsiteSizeInByte; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).WebsiteSizeInByte = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Name of this backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PropertiesName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemProperties _property;

        /// <summary>BackupItem resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.BackupItemProperties()); set => this._property = value; }

        /// <summary>True if this backup has been created due to a schedule being triggered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? Scheduled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).Scheduled; }

        /// <summary>Size of the backup in bytes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? SizeInByte { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).SizeInByte; }

        /// <summary>Backup status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BackupItemStatus? Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).Status; }

        /// <summary>SAS URL for the storage account container which contains this backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string StorageAccountUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).StorageAccountUrl; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Size of the original web app which has been backed up.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? WebsiteSizeInByte { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal)Property).WebsiteSizeInByte; }

        /// <summary>Creates an new <see cref="BackupItem" /> instance.</summary>
        public BackupItem()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyOnlyResource), __proxyOnlyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyOnlyResource), __proxyOnlyResource);
        }
    }
    /// Backup description.
    public partial interface IBackupItem :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
    {
        /// <summary>Id of the backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Id of the backup.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(int) })]
        int? BackupId { get;  }
        /// <summary>Name of the blob which contains data for this backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the blob which contains data for this backup.",
        SerializedName = @"blobName",
        PossibleTypes = new [] { typeof(string) })]
        string BlobName { get;  }
        /// <summary>
        /// Unique correlation identifier. Please use this along with the timestamp while communicating with Azure support.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Unique correlation identifier. Please use this along with the timestamp while communicating with Azure support.",
        SerializedName = @"correlationId",
        PossibleTypes = new [] { typeof(string) })]
        string CorrelationId { get;  }
        /// <summary>Timestamp of the backup creation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Timestamp of the backup creation.",
        SerializedName = @"created",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? Created { get;  }
        /// <summary>List of databases included in the backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of databases included in the backup.",
        SerializedName = @"databases",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSetting) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSetting[] Database { get;  }
        /// <summary>Timestamp when this backup finished.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Timestamp when this backup finished.",
        SerializedName = @"finishedTimeStamp",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? FinishedTimeStamp { get;  }
        /// <summary>Timestamp of a last restore operation which used this backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Timestamp of a last restore operation which used this backup.",
        SerializedName = @"lastRestoreTimeStamp",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastRestoreTimeStamp { get;  }
        /// <summary>Details regarding this backup. Might contain an error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Details regarding this backup. Might contain an error message.",
        SerializedName = @"log",
        PossibleTypes = new [] { typeof(string) })]
        string Log { get;  }
        /// <summary>Name of this backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of this backup.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string PropertiesName { get;  }
        /// <summary>True if this backup has been created due to a schedule being triggered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"True if this backup has been created due to a schedule being triggered.",
        SerializedName = @"scheduled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Scheduled { get;  }
        /// <summary>Size of the backup in bytes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Size of the backup in bytes.",
        SerializedName = @"sizeInBytes",
        PossibleTypes = new [] { typeof(long) })]
        long? SizeInByte { get;  }
        /// <summary>Backup status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Backup status.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BackupItemStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BackupItemStatus? Status { get;  }
        /// <summary>SAS URL for the storage account container which contains this backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"SAS URL for the storage account container which contains this backup.",
        SerializedName = @"storageAccountUrl",
        PossibleTypes = new [] { typeof(string) })]
        string StorageAccountUrl { get;  }
        /// <summary>Size of the original web app which has been backed up.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Size of the original web app which has been backed up.",
        SerializedName = @"websiteSizeInBytes",
        PossibleTypes = new [] { typeof(long) })]
        long? WebsiteSizeInByte { get;  }

    }
    /// Backup description.
    internal partial interface IBackupItemInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
    {
        /// <summary>Id of the backup.</summary>
        int? BackupId { get; set; }
        /// <summary>Name of the blob which contains data for this backup.</summary>
        string BlobName { get; set; }
        /// <summary>
        /// Unique correlation identifier. Please use this along with the timestamp while communicating with Azure support.
        /// </summary>
        string CorrelationId { get; set; }
        /// <summary>Timestamp of the backup creation.</summary>
        global::System.DateTime? Created { get; set; }
        /// <summary>List of databases included in the backup.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSetting[] Database { get; set; }
        /// <summary>Timestamp when this backup finished.</summary>
        global::System.DateTime? FinishedTimeStamp { get; set; }
        /// <summary>Timestamp of a last restore operation which used this backup.</summary>
        global::System.DateTime? LastRestoreTimeStamp { get; set; }
        /// <summary>Details regarding this backup. Might contain an error message.</summary>
        string Log { get; set; }
        /// <summary>Name of this backup.</summary>
        string PropertiesName { get; set; }
        /// <summary>BackupItem resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemProperties Property { get; set; }
        /// <summary>True if this backup has been created due to a schedule being triggered.</summary>
        bool? Scheduled { get; set; }
        /// <summary>Size of the backup in bytes.</summary>
        long? SizeInByte { get; set; }
        /// <summary>Backup status.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BackupItemStatus? Status { get; set; }
        /// <summary>SAS URL for the storage account container which contains this backup.</summary>
        string StorageAccountUrl { get; set; }
        /// <summary>Size of the original web app which has been backed up.</summary>
        long? WebsiteSizeInByte { get; set; }

    }
}