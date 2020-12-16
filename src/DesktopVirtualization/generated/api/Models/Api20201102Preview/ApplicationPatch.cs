namespace Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Extensions;

    /// <summary>Application properties that can be patched.</summary>
    public partial class ApplicationPatch :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPatch,
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPatchInternal
    {

        /// <summary>Resource Type of Application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.RemoteApplicationType? ApplicationType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPatchPropertiesInternal)Property).ApplicationType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPatchPropertiesInternal)Property).ApplicationType = value; }

        /// <summary>Command Line Arguments for Application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public string CommandLineArgument { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPatchPropertiesInternal)Property).CommandLineArgument; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPatchPropertiesInternal)Property).CommandLineArgument = value; }

        /// <summary>
        /// Specifies whether this published application can be launched with command line arguments provided by the client, command
        /// line arguments specified at publish time, or no command line arguments at all.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.CommandLineSetting? CommandLineSetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPatchPropertiesInternal)Property).CommandLineSetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPatchPropertiesInternal)Property).CommandLineSetting = value; }

        /// <summary>Description of Application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public string Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPatchPropertiesInternal)Property).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPatchPropertiesInternal)Property).Description = value; }

        /// <summary>Specifies a path for the executable file for the application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public string FilePath { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPatchPropertiesInternal)Property).FilePath; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPatchPropertiesInternal)Property).FilePath = value; }

        /// <summary>Friendly name of Application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public string FriendlyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPatchPropertiesInternal)Property).FriendlyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPatchPropertiesInternal)Property).FriendlyName = value; }

        /// <summary>Index of the icon.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public int? IconIndex { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPatchPropertiesInternal)Property).IconIndex; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPatchPropertiesInternal)Property).IconIndex = value; }

        /// <summary>Path to icon.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public string IconPath { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPatchPropertiesInternal)Property).IconPath; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPatchPropertiesInternal)Property).IconPath = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPatchProperties Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPatchInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ApplicationPatchProperties()); set { {_property = value;} } }

        /// <summary>Specifies the package application Id for MSIX applications</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public string MsixPackageApplicationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPatchPropertiesInternal)Property).MsixPackageApplicationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPatchPropertiesInternal)Property).MsixPackageApplicationId = value; }

        /// <summary>Specifies the package family name for MSIX applications</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public string MsixPackageFamilyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPatchPropertiesInternal)Property).MsixPackageFamilyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPatchPropertiesInternal)Property).MsixPackageFamilyName = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPatchProperties _property;

        /// <summary>Detailed properties for Application</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPatchProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ApplicationPatchProperties()); set => this._property = value; }

        /// <summary>Specifies whether to show the RemoteApp program in the RD Web Access server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public bool? ShowInPortal { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPatchPropertiesInternal)Property).ShowInPortal; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPatchPropertiesInternal)Property).ShowInPortal = value; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPatchTags _tag;

        /// <summary>tags to be updated</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPatchTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ApplicationPatchTags()); set => this._tag = value; }

        /// <summary>Creates an new <see cref="ApplicationPatch" /> instance.</summary>
        public ApplicationPatch()
        {

        }
    }
    /// Application properties that can be patched.
    public partial interface IApplicationPatch :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.IJsonSerializable
    {
        /// <summary>Resource Type of Application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource Type of Application.",
        SerializedName = @"applicationType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.RemoteApplicationType) })]
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.RemoteApplicationType? ApplicationType { get; set; }
        /// <summary>Command Line Arguments for Application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Command Line Arguments for Application.",
        SerializedName = @"commandLineArguments",
        PossibleTypes = new [] { typeof(string) })]
        string CommandLineArgument { get; set; }
        /// <summary>
        /// Specifies whether this published application can be launched with command line arguments provided by the client, command
        /// line arguments specified at publish time, or no command line arguments at all.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies whether this published application can be launched with command line arguments provided by the client, command line arguments specified at publish time, or no command line arguments at all.",
        SerializedName = @"commandLineSetting",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.CommandLineSetting) })]
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.CommandLineSetting? CommandLineSetting { get; set; }
        /// <summary>Description of Application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Description of Application.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>Specifies a path for the executable file for the application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies a path for the executable file for the application.",
        SerializedName = @"filePath",
        PossibleTypes = new [] { typeof(string) })]
        string FilePath { get; set; }
        /// <summary>Friendly name of Application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Friendly name of Application.",
        SerializedName = @"friendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string FriendlyName { get; set; }
        /// <summary>Index of the icon.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Index of the icon.",
        SerializedName = @"iconIndex",
        PossibleTypes = new [] { typeof(int) })]
        int? IconIndex { get; set; }
        /// <summary>Path to icon.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Path to icon.",
        SerializedName = @"iconPath",
        PossibleTypes = new [] { typeof(string) })]
        string IconPath { get; set; }
        /// <summary>Specifies the package application Id for MSIX applications</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the package application Id for MSIX applications",
        SerializedName = @"msixPackageApplicationId",
        PossibleTypes = new [] { typeof(string) })]
        string MsixPackageApplicationId { get; set; }
        /// <summary>Specifies the package family name for MSIX applications</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the package family name for MSIX applications",
        SerializedName = @"msixPackageFamilyName",
        PossibleTypes = new [] { typeof(string) })]
        string MsixPackageFamilyName { get; set; }
        /// <summary>Specifies whether to show the RemoteApp program in the RD Web Access server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies whether to show the RemoteApp program in the RD Web Access server.",
        SerializedName = @"showInPortal",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ShowInPortal { get; set; }
        /// <summary>tags to be updated</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"tags to be updated",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPatchTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPatchTags Tag { get; set; }

    }
    /// Application properties that can be patched.
    internal partial interface IApplicationPatchInternal

    {
        /// <summary>Resource Type of Application.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.RemoteApplicationType? ApplicationType { get; set; }
        /// <summary>Command Line Arguments for Application.</summary>
        string CommandLineArgument { get; set; }
        /// <summary>
        /// Specifies whether this published application can be launched with command line arguments provided by the client, command
        /// line arguments specified at publish time, or no command line arguments at all.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.CommandLineSetting? CommandLineSetting { get; set; }
        /// <summary>Description of Application.</summary>
        string Description { get; set; }
        /// <summary>Specifies a path for the executable file for the application.</summary>
        string FilePath { get; set; }
        /// <summary>Friendly name of Application.</summary>
        string FriendlyName { get; set; }
        /// <summary>Index of the icon.</summary>
        int? IconIndex { get; set; }
        /// <summary>Path to icon.</summary>
        string IconPath { get; set; }
        /// <summary>Specifies the package application Id for MSIX applications</summary>
        string MsixPackageApplicationId { get; set; }
        /// <summary>Specifies the package family name for MSIX applications</summary>
        string MsixPackageFamilyName { get; set; }
        /// <summary>Detailed properties for Application</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPatchProperties Property { get; set; }
        /// <summary>Specifies whether to show the RemoteApp program in the RD Web Access server.</summary>
        bool? ShowInPortal { get; set; }
        /// <summary>tags to be updated</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPatchTags Tag { get; set; }

    }
}