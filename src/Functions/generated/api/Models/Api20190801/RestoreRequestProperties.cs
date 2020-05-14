namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>RestoreRequest resource specific properties</summary>
    public partial class RestoreRequestProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AdjustConnectionString" /> property.</summary>
        private bool? _adjustConnectionString;

        /// <summary>
        /// <code>true</code> if SiteConfig.ConnectionStrings should be set in new app; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? AdjustConnectionString { get => this._adjustConnectionString; set => this._adjustConnectionString = value; }

        /// <summary>Backing field for <see cref="AppServicePlan" /> property.</summary>
        private string _appServicePlan;

        /// <summary>Specify app service plan that will own restored site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string AppServicePlan { get => this._appServicePlan; set => this._appServicePlan = value; }

        /// <summary>Backing field for <see cref="BlobName" /> property.</summary>
        private string _blobName;

        /// <summary>Name of a blob which contains the backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string BlobName { get => this._blobName; set => this._blobName = value; }

        /// <summary>Backing field for <see cref="Database" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSetting[] _database;

        /// <summary>
        /// Collection of databases which should be restored. This list has to match the list of databases included in the backup.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSetting[] Database { get => this._database; set => this._database = value; }

        /// <summary>Backing field for <see cref="HostingEnvironment" /> property.</summary>
        private string _hostingEnvironment;

        /// <summary>
        /// App Service Environment name, if needed (only when restoring an app to an App Service Environment).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string HostingEnvironment { get => this._hostingEnvironment; set => this._hostingEnvironment = value; }

        /// <summary>Backing field for <see cref="IgnoreConflictingHostName" /> property.</summary>
        private bool? _ignoreConflictingHostName;

        /// <summary>
        /// Changes a logic when restoring an app with custom domains. <code>true</code> to remove custom domains automatically. If
        /// <code>false</code>, custom domains are added to
        /// the app's object when it is being restored, but that might fail due to conflicts during the operation.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IgnoreConflictingHostName { get => this._ignoreConflictingHostName; set => this._ignoreConflictingHostName = value; }

        /// <summary>Backing field for <see cref="IgnoreDatabase" /> property.</summary>
        private bool? _ignoreDatabase;

        /// <summary>Ignore the databases and only restore the site content</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IgnoreDatabase { get => this._ignoreDatabase; set => this._ignoreDatabase = value; }

        /// <summary>Backing field for <see cref="OperationType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BackupRestoreOperationType? _operationType;

        /// <summary>Operation type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BackupRestoreOperationType? OperationType { get => this._operationType; set => this._operationType = value; }

        /// <summary>Backing field for <see cref="Overwrite" /> property.</summary>
        private bool _overwrite;

        /// <summary>
        /// <code>true</code> if the restore operation can overwrite target app; otherwise, <code>false</code>. <code>true</code>
        /// is needed if trying to restore over an existing app.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool Overwrite { get => this._overwrite; set => this._overwrite = value; }

        /// <summary>Backing field for <see cref="SiteName" /> property.</summary>
        private string _siteName;

        /// <summary>Name of an app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SiteName { get => this._siteName; set => this._siteName = value; }

        /// <summary>Backing field for <see cref="StorageAccountUrl" /> property.</summary>
        private string _storageAccountUrl;

        /// <summary>SAS URL to the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string StorageAccountUrl { get => this._storageAccountUrl; set => this._storageAccountUrl = value; }

        /// <summary>Creates an new <see cref="RestoreRequestProperties" /> instance.</summary>
        public RestoreRequestProperties()
        {

        }
    }
    /// RestoreRequest resource specific properties
    public partial interface IRestoreRequestProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// <code>true</code> if SiteConfig.ConnectionStrings should be set in new app; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> if SiteConfig.ConnectionStrings should be set in new app; otherwise, <code>false</code>.",
        SerializedName = @"adjustConnectionStrings",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AdjustConnectionString { get; set; }
        /// <summary>Specify app service plan that will own restored site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specify app service plan that will own restored site.",
        SerializedName = @"appServicePlan",
        PossibleTypes = new [] { typeof(string) })]
        string AppServicePlan { get; set; }
        /// <summary>Name of a blob which contains the backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of a blob which contains the backup.",
        SerializedName = @"blobName",
        PossibleTypes = new [] { typeof(string) })]
        string BlobName { get; set; }
        /// <summary>
        /// Collection of databases which should be restored. This list has to match the list of databases included in the backup.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Collection of databases which should be restored. This list has to match the list of databases included in the backup.",
        SerializedName = @"databases",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSetting) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSetting[] Database { get; set; }
        /// <summary>
        /// App Service Environment name, if needed (only when restoring an app to an App Service Environment).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"App Service Environment name, if needed (only when restoring an app to an App Service Environment).",
        SerializedName = @"hostingEnvironment",
        PossibleTypes = new [] { typeof(string) })]
        string HostingEnvironment { get; set; }
        /// <summary>
        /// Changes a logic when restoring an app with custom domains. <code>true</code> to remove custom domains automatically. If
        /// <code>false</code>, custom domains are added to
        /// the app's object when it is being restored, but that might fail due to conflicts during the operation.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Changes a logic when restoring an app with custom domains. <code>true</code> to remove custom domains automatically. If <code>false</code>, custom domains are added to
        the app's object when it is being restored, but that might fail due to conflicts during the operation.",
        SerializedName = @"ignoreConflictingHostNames",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IgnoreConflictingHostName { get; set; }
        /// <summary>Ignore the databases and only restore the site content</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Ignore the databases and only restore the site content",
        SerializedName = @"ignoreDatabases",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IgnoreDatabase { get; set; }
        /// <summary>Operation type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Operation type.",
        SerializedName = @"operationType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BackupRestoreOperationType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BackupRestoreOperationType? OperationType { get; set; }
        /// <summary>
        /// <code>true</code> if the restore operation can overwrite target app; otherwise, <code>false</code>. <code>true</code>
        /// is needed if trying to restore over an existing app.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"<code>true</code> if the restore operation can overwrite target app; otherwise, <code>false</code>. <code>true</code> is needed if trying to restore over an existing app.",
        SerializedName = @"overwrite",
        PossibleTypes = new [] { typeof(bool) })]
        bool Overwrite { get; set; }
        /// <summary>Name of an app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of an app.",
        SerializedName = @"siteName",
        PossibleTypes = new [] { typeof(string) })]
        string SiteName { get; set; }
        /// <summary>SAS URL to the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"SAS URL to the container.",
        SerializedName = @"storageAccountUrl",
        PossibleTypes = new [] { typeof(string) })]
        string StorageAccountUrl { get; set; }

    }
    /// RestoreRequest resource specific properties
    internal partial interface IRestoreRequestPropertiesInternal

    {
        /// <summary>
        /// <code>true</code> if SiteConfig.ConnectionStrings should be set in new app; otherwise, <code>false</code>.
        /// </summary>
        bool? AdjustConnectionString { get; set; }
        /// <summary>Specify app service plan that will own restored site.</summary>
        string AppServicePlan { get; set; }
        /// <summary>Name of a blob which contains the backup.</summary>
        string BlobName { get; set; }
        /// <summary>
        /// Collection of databases which should be restored. This list has to match the list of databases included in the backup.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSetting[] Database { get; set; }
        /// <summary>
        /// App Service Environment name, if needed (only when restoring an app to an App Service Environment).
        /// </summary>
        string HostingEnvironment { get; set; }
        /// <summary>
        /// Changes a logic when restoring an app with custom domains. <code>true</code> to remove custom domains automatically. If
        /// <code>false</code>, custom domains are added to
        /// the app's object when it is being restored, but that might fail due to conflicts during the operation.
        /// </summary>
        bool? IgnoreConflictingHostName { get; set; }
        /// <summary>Ignore the databases and only restore the site content</summary>
        bool? IgnoreDatabase { get; set; }
        /// <summary>Operation type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BackupRestoreOperationType? OperationType { get; set; }
        /// <summary>
        /// <code>true</code> if the restore operation can overwrite target app; otherwise, <code>false</code>. <code>true</code>
        /// is needed if trying to restore over an existing app.
        /// </summary>
        bool Overwrite { get; set; }
        /// <summary>Name of an app.</summary>
        string SiteName { get; set; }
        /// <summary>SAS URL to the container.</summary>
        string StorageAccountUrl { get; set; }

    }
}