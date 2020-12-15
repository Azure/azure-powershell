namespace Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Extensions;

    /// <summary>Schema for Desktop properties.</summary>
    public partial class DesktopProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IDesktopProperties,
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IDesktopPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>Description of Desktop.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="FriendlyName" /> property.</summary>
        private string _friendlyName;

        /// <summary>Friendly name of Desktop.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string FriendlyName { get => this._friendlyName; set => this._friendlyName = value; }

        /// <summary>Backing field for <see cref="IconContent" /> property.</summary>
        private byte[] _iconContent;

        /// <summary>The icon a 64 bit string as a byte array.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public byte[] IconContent { get => this._iconContent; }

        /// <summary>Backing field for <see cref="IconHash" /> property.</summary>
        private string _iconHash;

        /// <summary>Hash of the icon.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string IconHash { get => this._iconHash; }

        /// <summary>Internal Acessors for IconContent</summary>
        byte[] Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IDesktopPropertiesInternal.IconContent { get => this._iconContent; set { {_iconContent = value;} } }

        /// <summary>Internal Acessors for IconHash</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IDesktopPropertiesInternal.IconHash { get => this._iconHash; set { {_iconHash = value;} } }

        /// <summary>Creates an new <see cref="DesktopProperties" /> instance.</summary>
        public DesktopProperties()
        {

        }
    }
    /// Schema for Desktop properties.
    public partial interface IDesktopProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.IJsonSerializable
    {
        /// <summary>Description of Desktop.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Description of Desktop.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>Friendly name of Desktop.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Friendly name of Desktop.",
        SerializedName = @"friendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string FriendlyName { get; set; }
        /// <summary>The icon a 64 bit string as a byte array.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The icon a 64 bit string as a byte array.",
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

    }
    /// Schema for Desktop properties.
    internal partial interface IDesktopPropertiesInternal

    {
        /// <summary>Description of Desktop.</summary>
        string Description { get; set; }
        /// <summary>Friendly name of Desktop.</summary>
        string FriendlyName { get; set; }
        /// <summary>The icon a 64 bit string as a byte array.</summary>
        byte[] IconContent { get; set; }
        /// <summary>Hash of the icon.</summary>
        string IconHash { get; set; }

    }
}