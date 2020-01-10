namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Collection of SecurityProviders.</summary>
    public partial class VirtualWanSecurityProvider :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanSecurityProvider,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanSecurityProviderInternal
    {

        /// <summary>Internal Acessors for Type</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualWanSecurityProviderType? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanSecurityProviderInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the security provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualWanSecurityProviderType? _type;

        /// <summary>Name of the security provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualWanSecurityProviderType? Type { get => this._type; }

        /// <summary>Backing field for <see cref="Url" /> property.</summary>
        private string _url;

        /// <summary>Url of the security provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Url { get => this._url; set => this._url = value; }

        /// <summary>Creates an new <see cref="VirtualWanSecurityProvider" /> instance.</summary>
        public VirtualWanSecurityProvider()
        {

        }
    }
    /// Collection of SecurityProviders.
    public partial interface IVirtualWanSecurityProvider :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Name of the security provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the security provider.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Name of the security provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the security provider.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualWanSecurityProviderType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualWanSecurityProviderType? Type { get;  }
        /// <summary>Url of the security provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Url of the security provider.",
        SerializedName = @"url",
        PossibleTypes = new [] { typeof(string) })]
        string Url { get; set; }

    }
    /// Collection of SecurityProviders.
    internal partial interface IVirtualWanSecurityProviderInternal

    {
        /// <summary>Name of the security provider.</summary>
        string Name { get; set; }
        /// <summary>Name of the security provider.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualWanSecurityProviderType? Type { get; set; }
        /// <summary>Url of the security provider.</summary>
        string Url { get; set; }

    }
}