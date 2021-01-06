namespace Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Extensions;

    /// <summary>Schema for Application properties.</summary>
    public partial class ApplicationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ApplicationType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.RemoteApplicationType? _applicationType;

        /// <summary>Resource Type of Application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.RemoteApplicationType? ApplicationType { get => this._applicationType; set => this._applicationType = value; }

        /// <summary>Backing field for <see cref="CommandLineArgument" /> property.</summary>
        private string _commandLineArgument;

        /// <summary>Command Line Arguments for Application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string CommandLineArgument { get => this._commandLineArgument; set => this._commandLineArgument = value; }

        /// <summary>Backing field for <see cref="CommandLineSetting" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.CommandLineSetting _commandLineSetting;

        /// <summary>
        /// Specifies whether this published application can be launched with command line arguments provided by the client, command
        /// line arguments specified at publish time, or no command line arguments at all.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.CommandLineSetting CommandLineSetting { get => this._commandLineSetting; set => this._commandLineSetting = value; }

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>Description of Application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="FilePath" /> property.</summary>
        private string _filePath;

        /// <summary>Specifies a path for the executable file for the application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string FilePath { get => this._filePath; set => this._filePath = value; }

        /// <summary>Backing field for <see cref="FriendlyName" /> property.</summary>
        private string _friendlyName;

        /// <summary>Friendly name of Application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string FriendlyName { get => this._friendlyName; set => this._friendlyName = value; }

        /// <summary>Backing field for <see cref="IconContent" /> property.</summary>
        private byte[] _iconContent;

        /// <summary>the icon a 64 bit string as a byte array.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public byte[] IconContent { get => this._iconContent; }

        /// <summary>Backing field for <see cref="IconHash" /> property.</summary>
        private string _iconHash;

        /// <summary>Hash of the icon.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string IconHash { get => this._iconHash; }

        /// <summary>Backing field for <see cref="IconIndex" /> property.</summary>
        private int? _iconIndex;

        /// <summary>Index of the icon.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public int? IconIndex { get => this._iconIndex; set => this._iconIndex = value; }

        /// <summary>Backing field for <see cref="IconPath" /> property.</summary>
        private string _iconPath;

        /// <summary>Path to icon.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string IconPath { get => this._iconPath; set => this._iconPath = value; }

        /// <summary>Internal Acessors for IconContent</summary>
        byte[] Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPropertiesInternal.IconContent { get => this._iconContent; set { {_iconContent = value;} } }

        /// <summary>Internal Acessors for IconHash</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPropertiesInternal.IconHash { get => this._iconHash; set { {_iconHash = value;} } }

        /// <summary>Backing field for <see cref="MsixPackageApplicationId" /> property.</summary>
        private string _msixPackageApplicationId;

        /// <summary>Specifies the package application Id for MSIX applications</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string MsixPackageApplicationId { get => this._msixPackageApplicationId; set => this._msixPackageApplicationId = value; }

        /// <summary>Backing field for <see cref="MsixPackageFamilyName" /> property.</summary>
        private string _msixPackageFamilyName;

        /// <summary>Specifies the package family name for MSIX applications</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string MsixPackageFamilyName { get => this._msixPackageFamilyName; set => this._msixPackageFamilyName = value; }

        /// <summary>Backing field for <see cref="ShowInPortal" /> property.</summary>
        private bool? _showInPortal;

        /// <summary>Specifies whether to show the RemoteApp program in the RD Web Access server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public bool? ShowInPortal { get => this._showInPortal; set => this._showInPortal = value; }

        /// <summary>Creates an new <see cref="ApplicationProperties" /> instance.</summary>
        public ApplicationProperties()
        {

        }
    }
    /// Schema for Application properties.
    public partial interface IApplicationProperties :
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
        Required = true,
        ReadOnly = false,
        Description = @"Specifies whether this published application can be launched with command line arguments provided by the client, command line arguments specified at publish time, or no command line arguments at all.",
        SerializedName = @"commandLineSetting",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.CommandLineSetting) })]
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.CommandLineSetting CommandLineSetting { get; set; }
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
        /// <summary>the icon a 64 bit string as a byte array.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"the icon a 64 bit string as a byte array.",
        SerializedName = @"iconContent",
        PossibleTypes = new [] { typeof(byte[]) })]
        byte[] IconContent { get;  }
        /// <summary>Hash of the icon.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Hash of the icon.",
        SerializedName = @"iconHash",
        PossibleTypes = new [] { typeof(string) })]
        string IconHash { get;  }
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

    }
    /// Schema for Application properties.
    internal partial interface IApplicationPropertiesInternal

    {
        /// <summary>Resource Type of Application.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.RemoteApplicationType? ApplicationType { get; set; }
        /// <summary>Command Line Arguments for Application.</summary>
        string CommandLineArgument { get; set; }
        /// <summary>
        /// Specifies whether this published application can be launched with command line arguments provided by the client, command
        /// line arguments specified at publish time, or no command line arguments at all.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.CommandLineSetting CommandLineSetting { get; set; }
        /// <summary>Description of Application.</summary>
        string Description { get; set; }
        /// <summary>Specifies a path for the executable file for the application.</summary>
        string FilePath { get; set; }
        /// <summary>Friendly name of Application.</summary>
        string FriendlyName { get; set; }
        /// <summary>the icon a 64 bit string as a byte array.</summary>
        byte[] IconContent { get; set; }
        /// <summary>Hash of the icon.</summary>
        string IconHash { get; set; }
        /// <summary>Index of the icon.</summary>
        int? IconIndex { get; set; }
        /// <summary>Path to icon.</summary>
        string IconPath { get; set; }
        /// <summary>Specifies the package application Id for MSIX applications</summary>
        string MsixPackageApplicationId { get; set; }
        /// <summary>Specifies the package family name for MSIX applications</summary>
        string MsixPackageFamilyName { get; set; }
        /// <summary>Specifies whether to show the RemoteApp program in the RD Web Access server.</summary>
        bool? ShowInPortal { get; set; }

    }
}