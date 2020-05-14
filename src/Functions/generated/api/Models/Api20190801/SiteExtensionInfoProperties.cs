namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>SiteExtensionInfo resource specific properties</summary>
    public partial class SiteExtensionInfoProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Author" /> property.</summary>
        private string[] _author;

        /// <summary>List of authors.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] Author { get => this._author; set => this._author = value; }

        /// <summary>Backing field for <see cref="Comment" /> property.</summary>
        private string _comment;

        /// <summary>Site Extension comment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Comment { get => this._comment; set => this._comment = value; }

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>Detailed description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="DownloadCount" /> property.</summary>
        private int? _downloadCount;

        /// <summary>Count of downloads.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? DownloadCount { get => this._downloadCount; set => this._downloadCount = value; }

        /// <summary>Backing field for <see cref="ExtensionId" /> property.</summary>
        private string _extensionId;

        /// <summary>Site extension ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ExtensionId { get => this._extensionId; set => this._extensionId = value; }

        /// <summary>Backing field for <see cref="ExtensionType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SiteExtensionType? _extensionType;

        /// <summary>Site extension type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SiteExtensionType? ExtensionType { get => this._extensionType; set => this._extensionType = value; }

        /// <summary>Backing field for <see cref="ExtensionUrl" /> property.</summary>
        private string _extensionUrl;

        /// <summary>Extension URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ExtensionUrl { get => this._extensionUrl; set => this._extensionUrl = value; }

        /// <summary>Backing field for <see cref="FeedUrl" /> property.</summary>
        private string _feedUrl;

        /// <summary>Feed URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string FeedUrl { get => this._feedUrl; set => this._feedUrl = value; }

        /// <summary>Backing field for <see cref="IconUrl" /> property.</summary>
        private string _iconUrl;

        /// <summary>Icon URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string IconUrl { get => this._iconUrl; set => this._iconUrl = value; }

        /// <summary>Backing field for <see cref="InstalledDateTime" /> property.</summary>
        private global::System.DateTime? _installedDateTime;

        /// <summary>Installed timestamp.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? InstalledDateTime { get => this._installedDateTime; set => this._installedDateTime = value; }

        /// <summary>Backing field for <see cref="InstallerCommandLineParam" /> property.</summary>
        private string _installerCommandLineParam;

        /// <summary>Installer command line parameters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string InstallerCommandLineParam { get => this._installerCommandLineParam; set => this._installerCommandLineParam = value; }

        /// <summary>Backing field for <see cref="LicenseUrl" /> property.</summary>
        private string _licenseUrl;

        /// <summary>License URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string LicenseUrl { get => this._licenseUrl; set => this._licenseUrl = value; }

        /// <summary>Backing field for <see cref="LocalIsLatestVersion" /> property.</summary>
        private bool? _localIsLatestVersion;

        /// <summary>
        /// <code>true</code> if the local version is the latest version; <code>false</code> otherwise.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? LocalIsLatestVersion { get => this._localIsLatestVersion; set => this._localIsLatestVersion = value; }

        /// <summary>Backing field for <see cref="LocalPath" /> property.</summary>
        private string _localPath;

        /// <summary>Local path.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string LocalPath { get => this._localPath; set => this._localPath = value; }

        /// <summary>Backing field for <see cref="ProjectUrl" /> property.</summary>
        private string _projectUrl;

        /// <summary>Project URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ProjectUrl { get => this._projectUrl; set => this._projectUrl = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>Provisioning state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Backing field for <see cref="PublishedDateTime" /> property.</summary>
        private global::System.DateTime? _publishedDateTime;

        /// <summary>Published timestamp.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? PublishedDateTime { get => this._publishedDateTime; set => this._publishedDateTime = value; }

        /// <summary>Backing field for <see cref="Summary" /> property.</summary>
        private string _summary;

        /// <summary>Summary description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Summary { get => this._summary; set => this._summary = value; }

        /// <summary>Backing field for <see cref="Title" /> property.</summary>
        private string _title;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Title { get => this._title; set => this._title = value; }

        /// <summary>Backing field for <see cref="Version" /> property.</summary>
        private string _version;

        /// <summary>Version information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Version { get => this._version; set => this._version = value; }

        /// <summary>Creates an new <see cref="SiteExtensionInfoProperties" /> instance.</summary>
        public SiteExtensionInfoProperties()
        {

        }
    }
    /// SiteExtensionInfo resource specific properties
    public partial interface ISiteExtensionInfoProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
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
    /// SiteExtensionInfo resource specific properties
    internal partial interface ISiteExtensionInfoPropertiesInternal

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