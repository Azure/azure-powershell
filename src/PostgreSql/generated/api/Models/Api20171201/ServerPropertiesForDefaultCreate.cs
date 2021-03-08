namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Extensions;

    /// <summary>The properties used to create a new server.</summary>
    public partial class ServerPropertiesForDefaultCreate :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesForDefaultCreate,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesForDefaultCreateInternal,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesForCreate"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesForCreate __serverPropertiesForCreate = new Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ServerPropertiesForCreate();

        /// <summary>Backing field for <see cref="AdministratorLogin" /> property.</summary>
        private string _administratorLogin;

        /// <summary>
        /// The administrator's login name of a server. Can only be specified when the server is being created (and is required for
        /// creation).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Owned)]
        public string AdministratorLogin { get => this._administratorLogin; set => this._administratorLogin = value; }

        /// <summary>Backing field for <see cref="AdministratorLoginPassword" /> property.</summary>
        private System.Security.SecureString _administratorLoginPassword;

        /// <summary>The password of the administrator login.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Owned)]
        public System.Security.SecureString AdministratorLoginPassword { get => this._administratorLoginPassword; set => this._administratorLoginPassword = value; }

        /// <summary>The mode to create a new server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.CreateMode CreateMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).CreateMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).CreateMode = value ; }

        /// <summary>Status showing whether the server enabled infrastructure encryption.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.InfrastructureEncryption? InfrastructureEncryption { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).InfrastructureEncryption; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).InfrastructureEncryption = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.InfrastructureEncryption)""); }

        /// <summary>Enforce a minimal Tls version for the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.MinimalTlsVersionEnum? MinimalTlsVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).MinimalTlsVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).MinimalTlsVersion = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.MinimalTlsVersionEnum)""); }

        /// <summary>
        /// Whether or not public network access is allowed for this server. Value is optional but if passed in, must be 'Enabled'
        /// or 'Disabled'
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.PublicNetworkAccessEnum? PublicNetworkAccess { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).PublicNetworkAccess; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).PublicNetworkAccess = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.PublicNetworkAccessEnum)""); }

        /// <summary>Enable ssl enforcement or not when connect to server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.SslEnforcementEnum? SslEnforcement { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).SslEnforcement; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).SslEnforcement = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.SslEnforcementEnum)""); }

        /// <summary>Storage profile of a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IStorageProfile StorageProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).StorageProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).StorageProfile = value ?? null /* model class */; }

        /// <summary>Backup retention days for the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inherited)]
        public int? StorageProfileBackupRetentionDay { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).StorageProfileBackupRetentionDay; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).StorageProfileBackupRetentionDay = value ?? default(int); }

        /// <summary>Enable Geo-redundant or not for server backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.GeoRedundantBackup? StorageProfileGeoRedundantBackup { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).StorageProfileGeoRedundantBackup; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).StorageProfileGeoRedundantBackup = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.GeoRedundantBackup)""); }

        /// <summary>Enable Storage Auto Grow.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.StorageAutogrow? StorageProfileStorageAutogrow { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).StorageProfileStorageAutogrow; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).StorageProfileStorageAutogrow = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.StorageAutogrow)""); }

        /// <summary>Max storage allowed for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inherited)]
        public int? StorageProfileStorageMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).StorageProfileStorageMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).StorageProfileStorageMb = value ?? default(int); }

        /// <summary>Server version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.ServerVersion? Version { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).Version; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesForCreateInternal)__serverPropertiesForCreate).Version = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.ServerVersion)""); }

        /// <summary>Creates an new <see cref="ServerPropertiesForDefaultCreate" /> instance.</summary>
        public ServerPropertiesForDefaultCreate()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__serverPropertiesForCreate), __serverPropertiesForCreate);
            await eventListener.AssertObjectIsValid(nameof(__serverPropertiesForCreate), __serverPropertiesForCreate);
        }
    }
    /// The properties used to create a new server.
    public partial interface IServerPropertiesForDefaultCreate :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesForCreate
    {
        /// <summary>
        /// The administrator's login name of a server. Can only be specified when the server is being created (and is required for
        /// creation).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The administrator's login name of a server. Can only be specified when the server is being created (and is required for creation).",
        SerializedName = @"administratorLogin",
        PossibleTypes = new [] { typeof(string) })]
        string AdministratorLogin { get; set; }
        /// <summary>The password of the administrator login.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The password of the administrator login.",
        SerializedName = @"administratorLoginPassword",
        PossibleTypes = new [] { typeof(System.Security.SecureString) })]
        System.Security.SecureString AdministratorLoginPassword { get; set; }

    }
    /// The properties used to create a new server.
    internal partial interface IServerPropertiesForDefaultCreateInternal :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesForCreateInternal
    {
        /// <summary>
        /// The administrator's login name of a server. Can only be specified when the server is being created (and is required for
        /// creation).
        /// </summary>
        string AdministratorLogin { get; set; }
        /// <summary>The password of the administrator login.</summary>
        System.Security.SecureString AdministratorLoginPassword { get; set; }

    }
}