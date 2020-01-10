namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Collection of SecurityProviders.</summary>
    public partial class VirtualWanSecurityProviders :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanSecurityProviders,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanSecurityProvidersInternal
    {

        /// <summary>Backing field for <see cref="SupportedProvider" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanSecurityProvider[] _supportedProvider;

        /// <summary>List of VirtualWAN security providers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanSecurityProvider[] SupportedProvider { get => this._supportedProvider; set => this._supportedProvider = value; }

        /// <summary>Creates an new <see cref="VirtualWanSecurityProviders" /> instance.</summary>
        public VirtualWanSecurityProviders()
        {

        }
    }
    /// Collection of SecurityProviders.
    public partial interface IVirtualWanSecurityProviders :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>List of VirtualWAN security providers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of VirtualWAN security providers.",
        SerializedName = @"supportedProviders",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanSecurityProvider) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanSecurityProvider[] SupportedProvider { get; set; }

    }
    /// Collection of SecurityProviders.
    internal partial interface IVirtualWanSecurityProvidersInternal

    {
        /// <summary>List of VirtualWAN security providers.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanSecurityProvider[] SupportedProvider { get; set; }

    }
}