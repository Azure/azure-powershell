namespace Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Extensions;

    /// <summary>Schema for MSIX Package Application properties.</summary>
    public partial class MsixPackageApplications :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IMsixPackageApplications,
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IMsixPackageApplicationsInternal
    {

        /// <summary>Backing field for <see cref="AppId" /> property.</summary>
        private string _appId;

        /// <summary>Package Application Id, found in appxmanifest.xml.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string AppId { get => this._appId; set => this._appId = value; }

        /// <summary>Backing field for <see cref="AppUserModelId" /> property.</summary>
        private string _appUserModelId;

        /// <summary>
        /// Used to activate Package Application. Consists of Package Name and ApplicationID. Found in appxmanifest.xml.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string AppUserModelId { get => this._appUserModelId; set => this._appUserModelId = value; }

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>Description of Package Application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="FriendlyName" /> property.</summary>
        private string _friendlyName;

        /// <summary>User friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string FriendlyName { get => this._friendlyName; set => this._friendlyName = value; }

        /// <summary>Backing field for <see cref="IconImageName" /> property.</summary>
        private string _iconImageName;

        /// <summary>User friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string IconImageName { get => this._iconImageName; set => this._iconImageName = value; }

        /// <summary>Backing field for <see cref="RawIcon" /> property.</summary>
        private byte[] _rawIcon;

        /// <summary>the icon a 64 bit string as a byte array.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public byte[] RawIcon { get => this._rawIcon; set => this._rawIcon = value; }

        /// <summary>Backing field for <see cref="RawPng" /> property.</summary>
        private byte[] _rawPng;

        /// <summary>the icon a 64 bit string as a byte array.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public byte[] RawPng { get => this._rawPng; set => this._rawPng = value; }

        /// <summary>Creates an new <see cref="MsixPackageApplications" /> instance.</summary>
        public MsixPackageApplications()
        {

        }
    }
    /// Schema for MSIX Package Application properties.
    public partial interface IMsixPackageApplications :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.IJsonSerializable
    {
        /// <summary>Package Application Id, found in appxmanifest.xml.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Package Application Id, found in appxmanifest.xml.",
        SerializedName = @"appId",
        PossibleTypes = new [] { typeof(string) })]
        string AppId { get; set; }
        /// <summary>
        /// Used to activate Package Application. Consists of Package Name and ApplicationID. Found in appxmanifest.xml.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Used to activate Package Application. Consists of Package Name and ApplicationID. Found in appxmanifest.xml.",
        SerializedName = @"appUserModelID",
        PossibleTypes = new [] { typeof(string) })]
        string AppUserModelId { get; set; }
        /// <summary>Description of Package Application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Description of Package Application.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>User friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"User friendly name.",
        SerializedName = @"friendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string FriendlyName { get; set; }
        /// <summary>User friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"User friendly name.",
        SerializedName = @"iconImageName",
        PossibleTypes = new [] { typeof(string) })]
        string IconImageName { get; set; }
        /// <summary>the icon a 64 bit string as a byte array.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"the icon a 64 bit string as a byte array.",
        SerializedName = @"rawIcon",
        PossibleTypes = new [] { typeof(byte[]) })]
        byte[] RawIcon { get; set; }
        /// <summary>the icon a 64 bit string as a byte array.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"the icon a 64 bit string as a byte array.",
        SerializedName = @"rawPng",
        PossibleTypes = new [] { typeof(byte[]) })]
        byte[] RawPng { get; set; }

    }
    /// Schema for MSIX Package Application properties.
    internal partial interface IMsixPackageApplicationsInternal

    {
        /// <summary>Package Application Id, found in appxmanifest.xml.</summary>
        string AppId { get; set; }
        /// <summary>
        /// Used to activate Package Application. Consists of Package Name and ApplicationID. Found in appxmanifest.xml.
        /// </summary>
        string AppUserModelId { get; set; }
        /// <summary>Description of Package Application.</summary>
        string Description { get; set; }
        /// <summary>User friendly name.</summary>
        string FriendlyName { get; set; }
        /// <summary>User friendly name.</summary>
        string IconImageName { get; set; }
        /// <summary>the icon a 64 bit string as a byte array.</summary>
        byte[] RawIcon { get; set; }
        /// <summary>the icon a 64 bit string as a byte array.</summary>
        byte[] RawPng { get; set; }

    }
}