namespace Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Extensions;

    /// <summary>Schema for MSIX Package properties.</summary>
    public partial class MsixPackageProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IMsixPackageProperties,
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IMsixPackagePropertiesInternal
    {

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>User friendly Name to be displayed in the portal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; set => this._displayName = value; }

        /// <summary>Backing field for <see cref="ImagePath" /> property.</summary>
        private string _imagePath;

        /// <summary>VHD/CIM image path on Network Share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string ImagePath { get => this._imagePath; set => this._imagePath = value; }

        /// <summary>Backing field for <see cref="IsActive" /> property.</summary>
        private bool? _isActive;

        /// <summary>Make this version of the package the active one across the hostpool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public bool? IsActive { get => this._isActive; set => this._isActive = value; }

        /// <summary>Backing field for <see cref="IsRegularRegistration" /> property.</summary>
        private bool? _isRegularRegistration;

        /// <summary>Specifies how to register Package in feed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public bool? IsRegularRegistration { get => this._isRegularRegistration; set => this._isRegularRegistration = value; }

        /// <summary>Backing field for <see cref="LastUpdated" /> property.</summary>
        private global::System.DateTime? _lastUpdated;

        /// <summary>Date Package was last updated, found in the appxmanifest.xml.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public global::System.DateTime? LastUpdated { get => this._lastUpdated; set => this._lastUpdated = value; }

        /// <summary>Backing field for <see cref="PackageApplication" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IMsixPackageApplications[] _packageApplication;

        /// <summary>List of package applications.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IMsixPackageApplications[] PackageApplication { get => this._packageApplication; set => this._packageApplication = value; }

        /// <summary>Backing field for <see cref="PackageDependency" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IMsixPackageDependencies[] _packageDependency;

        /// <summary>List of package dependencies.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IMsixPackageDependencies[] PackageDependency { get => this._packageDependency; set => this._packageDependency = value; }

        /// <summary>Backing field for <see cref="PackageFamilyName" /> property.</summary>
        private string _packageFamilyName;

        /// <summary>
        /// Package Family Name from appxmanifest.xml. Contains Package Name and Publisher name.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string PackageFamilyName { get => this._packageFamilyName; set => this._packageFamilyName = value; }

        /// <summary>Backing field for <see cref="PackageName" /> property.</summary>
        private string _packageName;

        /// <summary>Package Name from appxmanifest.xml.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string PackageName { get => this._packageName; set => this._packageName = value; }

        /// <summary>Backing field for <see cref="PackageRelativePath" /> property.</summary>
        private string _packageRelativePath;

        /// <summary>Relative Path to the package inside the image.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string PackageRelativePath { get => this._packageRelativePath; set => this._packageRelativePath = value; }

        /// <summary>Backing field for <see cref="Version" /> property.</summary>
        private string _version;

        /// <summary>Package Version found in the appxmanifest.xml.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string Version { get => this._version; set => this._version = value; }

        /// <summary>Creates an new <see cref="MsixPackageProperties" /> instance.</summary>
        public MsixPackageProperties()
        {

        }
    }
    /// Schema for MSIX Package properties.
    public partial interface IMsixPackageProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.IJsonSerializable
    {
        /// <summary>User friendly Name to be displayed in the portal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"User friendly Name to be displayed in the portal. ",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get; set; }
        /// <summary>VHD/CIM image path on Network Share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"VHD/CIM image path on Network Share.",
        SerializedName = @"imagePath",
        PossibleTypes = new [] { typeof(string) })]
        string ImagePath { get; set; }
        /// <summary>Make this version of the package the active one across the hostpool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Make this version of the package the active one across the hostpool. ",
        SerializedName = @"isActive",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsActive { get; set; }
        /// <summary>Specifies how to register Package in feed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies how to register Package in feed.",
        SerializedName = @"isRegularRegistration",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsRegularRegistration { get; set; }
        /// <summary>Date Package was last updated, found in the appxmanifest.xml.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Date Package was last updated, found in the appxmanifest.xml. ",
        SerializedName = @"lastUpdated",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastUpdated { get; set; }
        /// <summary>List of package applications.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of package applications. ",
        SerializedName = @"packageApplications",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IMsixPackageApplications) })]
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IMsixPackageApplications[] PackageApplication { get; set; }
        /// <summary>List of package dependencies.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of package dependencies. ",
        SerializedName = @"packageDependencies",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IMsixPackageDependencies) })]
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IMsixPackageDependencies[] PackageDependency { get; set; }
        /// <summary>
        /// Package Family Name from appxmanifest.xml. Contains Package Name and Publisher name.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Package Family Name from appxmanifest.xml. Contains Package Name and Publisher name. ",
        SerializedName = @"packageFamilyName",
        PossibleTypes = new [] { typeof(string) })]
        string PackageFamilyName { get; set; }
        /// <summary>Package Name from appxmanifest.xml.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Package Name from appxmanifest.xml. ",
        SerializedName = @"packageName",
        PossibleTypes = new [] { typeof(string) })]
        string PackageName { get; set; }
        /// <summary>Relative Path to the package inside the image.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Relative Path to the package inside the image. ",
        SerializedName = @"packageRelativePath",
        PossibleTypes = new [] { typeof(string) })]
        string PackageRelativePath { get; set; }
        /// <summary>Package Version found in the appxmanifest.xml.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Package Version found in the appxmanifest.xml. ",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string Version { get; set; }

    }
    /// Schema for MSIX Package properties.
    internal partial interface IMsixPackagePropertiesInternal

    {
        /// <summary>User friendly Name to be displayed in the portal.</summary>
        string DisplayName { get; set; }
        /// <summary>VHD/CIM image path on Network Share.</summary>
        string ImagePath { get; set; }
        /// <summary>Make this version of the package the active one across the hostpool.</summary>
        bool? IsActive { get; set; }
        /// <summary>Specifies how to register Package in feed.</summary>
        bool? IsRegularRegistration { get; set; }
        /// <summary>Date Package was last updated, found in the appxmanifest.xml.</summary>
        global::System.DateTime? LastUpdated { get; set; }
        /// <summary>List of package applications.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IMsixPackageApplications[] PackageApplication { get; set; }
        /// <summary>List of package dependencies.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IMsixPackageDependencies[] PackageDependency { get; set; }
        /// <summary>
        /// Package Family Name from appxmanifest.xml. Contains Package Name and Publisher name.
        /// </summary>
        string PackageFamilyName { get; set; }
        /// <summary>Package Name from appxmanifest.xml.</summary>
        string PackageName { get; set; }
        /// <summary>Relative Path to the package inside the image.</summary>
        string PackageRelativePath { get; set; }
        /// <summary>Package Version found in the appxmanifest.xml.</summary>
        string Version { get; set; }

    }
}