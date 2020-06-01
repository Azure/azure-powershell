namespace Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Extensions;

    /// <summary>
    /// The properties used to create a new server by restoring to a different region from a geo replicated backup.
    /// </summary>
    public partial class ServerPropertiesForGeoRestore :
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForGeoRestore,
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForGeoRestoreInternal,
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreate"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreate __serverPropertiesForCreate = new Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.ServerPropertiesForCreate();

        /// <summary>The mode to create a new server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.CreateMode CreateMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).CreateMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).CreateMode = value; }

        /// <summary>Backing field for <see cref="SourceServerId" /> property.</summary>
        private string _sourceServerId;

        /// <summary>The source server id to restore from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public string SourceServerId { get => this._sourceServerId; set => this._sourceServerId = value; }

        /// <summary>Enable ssl enforcement or not when connect to server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.SslEnforcementEnum? SslEnforcement { get => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).SslEnforcement; set => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).SslEnforcement = value; }

        /// <summary>Storage profile of a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IStorageProfile StorageProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).StorageProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).StorageProfile = value; }

        /// <summary>Backup retention days for the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Inherited)]
        public int? StorageProfileBackupRetentionDay { get => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).StorageProfileBackupRetentionDay; set => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).StorageProfileBackupRetentionDay = value; }

        /// <summary>Enable Geo-redundant or not for server backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.GeoRedundantBackup? StorageProfileGeoRedundantBackup { get => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).StorageProfileGeoRedundantBackup; set => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).StorageProfileGeoRedundantBackup = value; }

        /// <summary>Enable Storage Auto Grow.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.StorageAutogrow? StorageProfileStorageAutogrow { get => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).StorageProfileStorageAutogrow; set => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).StorageProfileStorageAutogrow = value; }

        /// <summary>Max storage allowed for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Inherited)]
        public int? StorageProfileStorageMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).StorageProfileStorageMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).StorageProfileStorageMb = value; }

        /// <summary>Server version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.ServerVersion? Version { get => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).Version; set => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).Version = value; }

        /// <summary>Creates an new <see cref="ServerPropertiesForGeoRestore" /> instance.</summary>
        public ServerPropertiesForGeoRestore()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__serverPropertiesForCreate), __serverPropertiesForCreate);
            await eventListener.AssertObjectIsValid(nameof(__serverPropertiesForCreate), __serverPropertiesForCreate);
        }
    }
    /// The properties used to create a new server by restoring to a different region from a geo replicated backup.
    public partial interface IServerPropertiesForGeoRestore :
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreate
    {
        /// <summary>The source server id to restore from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The source server id to restore from.",
        SerializedName = @"sourceServerId",
        PossibleTypes = new [] { typeof(string) })]
        string SourceServerId { get; set; }

    }
    /// The properties used to create a new server by restoring to a different region from a geo replicated backup.
    internal partial interface IServerPropertiesForGeoRestoreInternal :
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal
    {
        /// <summary>The source server id to restore from.</summary>
        string SourceServerId { get; set; }

    }
}