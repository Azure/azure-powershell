namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Description of a restore request.</summary>
    public partial class RestoreRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequest,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>
        /// <code>true</code> if SiteConfig.ConnectionStrings should be set in new app; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? AdjustConnectionString { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)Property).AdjustConnectionString; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)Property).AdjustConnectionString = value; }

        /// <summary>Specify app service plan that will own restored site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string AppServicePlan { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)Property).AppServicePlan; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)Property).AppServicePlan = value; }

        /// <summary>Name of a blob which contains the backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string BlobName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)Property).BlobName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)Property).BlobName = value; }

        /// <summary>
        /// Collection of databases which should be restored. This list has to match the list of databases included in the backup.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSetting[] Database { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)Property).Database; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)Property).Database = value; }

        /// <summary>
        /// App Service Environment name, if needed (only when restoring an app to an App Service Environment).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string HostingEnvironment { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)Property).HostingEnvironment; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)Property).HostingEnvironment = value; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>
        /// Changes a logic when restoring an app with custom domains. <code>true</code> to remove custom domains automatically. If
        /// <code>false</code>, custom domains are added to
        /// the app's object when it is being restored, but that might fail due to conflicts during the operation.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? IgnoreConflictingHostName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)Property).IgnoreConflictingHostName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)Property).IgnoreConflictingHostName = value; }

        /// <summary>Ignore the databases and only restore the site content</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? IgnoreDatabase { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)Property).IgnoreDatabase; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)Property).IgnoreDatabase = value; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.RestoreRequestProperties()); set { {_property = value;} } }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Operation type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BackupRestoreOperationType? OperationType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)Property).OperationType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)Property).OperationType = value; }

        /// <summary>
        /// <code>true</code> if the restore operation can overwrite target app; otherwise, <code>false</code>. <code>true</code>
        /// is needed if trying to restore over an existing app.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool Overwrite { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)Property).Overwrite; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)Property).Overwrite = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestProperties _property;

        /// <summary>RestoreRequest resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.RestoreRequestProperties()); set => this._property = value; }

        /// <summary>Name of an app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SiteName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)Property).SiteName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)Property).SiteName = value; }

        /// <summary>SAS URL to the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string StorageAccountUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)Property).StorageAccountUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestPropertiesInternal)Property).StorageAccountUrl = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Creates an new <see cref="RestoreRequest" /> instance.</summary>
        public RestoreRequest()
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
    /// Description of a restore request.
    public partial interface IRestoreRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
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
    /// Description of a restore request.
    internal partial interface IRestoreRequestInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
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
        /// <summary>RestoreRequest resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequestProperties Property { get; set; }
        /// <summary>Name of an app.</summary>
        string SiteName { get; set; }
        /// <summary>SAS URL to the container.</summary>
        string StorageAccountUrl { get; set; }

    }
}