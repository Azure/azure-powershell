namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Site Extension Information.</summary>
    public partial class SiteExtensionInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfo,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>List of authors.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] Author { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).Author; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).Author = value; }

        /// <summary>Site Extension comment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Comment { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).Comment; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).Comment = value; }

        /// <summary>Detailed description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).Description = value; }

        /// <summary>Count of downloads.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? DownloadCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).DownloadCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).DownloadCount = value; }

        /// <summary>Site extension ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ExtensionId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).ExtensionId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).ExtensionId = value; }

        /// <summary>Site extension type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SiteExtensionType? ExtensionType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).ExtensionType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).ExtensionType = value; }

        /// <summary>Extension URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ExtensionUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).ExtensionUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).ExtensionUrl = value; }

        /// <summary>Feed URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string FeedUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).FeedUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).FeedUrl = value; }

        /// <summary>Icon URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string IconUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).IconUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).IconUrl = value; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>Installed timestamp.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? InstalledDateTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).InstalledDateTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).InstalledDateTime = value; }

        /// <summary>Installer command line parameters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string InstallerCommandLineParam { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).InstallerCommandLineParam; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).InstallerCommandLineParam = value; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>License URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string LicenseUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).LicenseUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).LicenseUrl = value; }

        /// <summary>
        /// <code>true</code> if the local version is the latest version; <code>false</code> otherwise.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? LocalIsLatestVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).LocalIsLatestVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).LocalIsLatestVersion = value; }

        /// <summary>Local path.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string LocalPath { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).LocalPath; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).LocalPath = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteExtensionInfoProperties()); set { {_property = value;} } }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Project URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ProjectUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).ProjectUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).ProjectUrl = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoProperties _property;

        /// <summary>SiteExtensionInfo resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteExtensionInfoProperties()); set => this._property = value; }

        /// <summary>Provisioning state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Published timestamp.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? PublishedDateTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).PublishedDateTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).PublishedDateTime = value; }

        /// <summary>Summary description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Summary { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).Summary; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).Summary = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Title { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).Title; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).Title = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Version information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Version { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).Version; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal)Property).Version = value; }

        /// <summary>Creates an new <see cref="SiteExtensionInfo" /> instance.</summary>
        public SiteExtensionInfo()
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
    /// Site Extension Information.
    public partial interface ISiteExtensionInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
    {
        /// <summary>List of authors.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of authors.",
        SerializedName = @"authors",
        PossibleTypes = new [] { typeof(string) })]
        string[] Author { get; set; }
        /// <summary>Site Extension comment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Site Extension comment.",
        SerializedName = @"comment",
        PossibleTypes = new [] { typeof(string) })]
        string Comment { get; set; }
        /// <summary>Detailed description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Detailed description.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>Count of downloads.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Count of downloads.",
        SerializedName = @"download_count",
        PossibleTypes = new [] { typeof(int) })]
        int? DownloadCount { get; set; }
        /// <summary>Site extension ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Site extension ID.",
        SerializedName = @"extension_id",
        PossibleTypes = new [] { typeof(string) })]
        string ExtensionId { get; set; }
        /// <summary>Site extension type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Site extension type.",
        SerializedName = @"extension_type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SiteExtensionType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SiteExtensionType? ExtensionType { get; set; }
        /// <summary>Extension URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Extension URL.",
        SerializedName = @"extension_url",
        PossibleTypes = new [] { typeof(string) })]
        string ExtensionUrl { get; set; }
        /// <summary>Feed URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Feed URL.",
        SerializedName = @"feed_url",
        PossibleTypes = new [] { typeof(string) })]
        string FeedUrl { get; set; }
        /// <summary>Icon URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Icon URL.",
        SerializedName = @"icon_url",
        PossibleTypes = new [] { typeof(string) })]
        string IconUrl { get; set; }
        /// <summary>Installed timestamp.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Installed timestamp.",
        SerializedName = @"installed_date_time",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? InstalledDateTime { get; set; }
        /// <summary>Installer command line parameters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Installer command line parameters.",
        SerializedName = @"installer_command_line_params",
        PossibleTypes = new [] { typeof(string) })]
        string InstallerCommandLineParam { get; set; }
        /// <summary>License URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"License URL.",
        SerializedName = @"license_url",
        PossibleTypes = new [] { typeof(string) })]
        string LicenseUrl { get; set; }
        /// <summary>
        /// <code>true</code> if the local version is the latest version; <code>false</code> otherwise.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> if the local version is the latest version; <code>false</code> otherwise.",
        SerializedName = @"local_is_latest_version",
        PossibleTypes = new [] { typeof(bool) })]
        bool? LocalIsLatestVersion { get; set; }
        /// <summary>Local path.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Local path.",
        SerializedName = @"local_path",
        PossibleTypes = new [] { typeof(string) })]
        string LocalPath { get; set; }
        /// <summary>Project URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Project URL.",
        SerializedName = @"project_url",
        PossibleTypes = new [] { typeof(string) })]
        string ProjectUrl { get; set; }
        /// <summary>Provisioning state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Provisioning state.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get; set; }
        /// <summary>Published timestamp.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Published timestamp.",
        SerializedName = @"published_date_time",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? PublishedDateTime { get; set; }
        /// <summary>Summary description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Summary description.",
        SerializedName = @"summary",
        PossibleTypes = new [] { typeof(string) })]
        string Summary { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"title",
        PossibleTypes = new [] { typeof(string) })]
        string Title { get; set; }
        /// <summary>Version information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Version information.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string Version { get; set; }

    }
    /// Site Extension Information.
    internal partial interface ISiteExtensionInfoInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
    {
        /// <summary>List of authors.</summary>
        string[] Author { get; set; }
        /// <summary>Site Extension comment.</summary>
        string Comment { get; set; }
        /// <summary>Detailed description.</summary>
        string Description { get; set; }
        /// <summary>Count of downloads.</summary>
        int? DownloadCount { get; set; }
        /// <summary>Site extension ID.</summary>
        string ExtensionId { get; set; }
        /// <summary>Site extension type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SiteExtensionType? ExtensionType { get; set; }
        /// <summary>Extension URL.</summary>
        string ExtensionUrl { get; set; }
        /// <summary>Feed URL.</summary>
        string FeedUrl { get; set; }
        /// <summary>Icon URL.</summary>
        string IconUrl { get; set; }
        /// <summary>Installed timestamp.</summary>
        global::System.DateTime? InstalledDateTime { get; set; }
        /// <summary>Installer command line parameters.</summary>
        string InstallerCommandLineParam { get; set; }
        /// <summary>License URL.</summary>
        string LicenseUrl { get; set; }
        /// <summary>
        /// <code>true</code> if the local version is the latest version; <code>false</code> otherwise.
        /// </summary>
        bool? LocalIsLatestVersion { get; set; }
        /// <summary>Local path.</summary>
        string LocalPath { get; set; }
        /// <summary>Project URL.</summary>
        string ProjectUrl { get; set; }
        /// <summary>SiteExtensionInfo resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoProperties Property { get; set; }
        /// <summary>Provisioning state.</summary>
        string ProvisioningState { get; set; }
        /// <summary>Published timestamp.</summary>
        global::System.DateTime? PublishedDateTime { get; set; }
        /// <summary>Summary description.</summary>
        string Summary { get; set; }

        string Title { get; set; }
        /// <summary>Version information.</summary>
        string Version { get; set; }

    }
}