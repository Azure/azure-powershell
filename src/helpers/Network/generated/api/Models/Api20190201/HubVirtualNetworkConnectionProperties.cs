namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Parameters for HubVirtualNetworkConnection</summary>
    public partial class HubVirtualNetworkConnectionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHubVirtualNetworkConnectionProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHubVirtualNetworkConnectionPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AllowHubToRemoteVnetTransit" /> property.</summary>
        private bool? _allowHubToRemoteVnetTransit;

        /// <summary>VirtualHub to RemoteVnet transit to enabled or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? AllowHubToRemoteVnetTransit { get => this._allowHubToRemoteVnetTransit; set => this._allowHubToRemoteVnetTransit = value; }

        /// <summary>Backing field for <see cref="AllowRemoteVnetToUseHubVnetGateway" /> property.</summary>
        private bool? _allowRemoteVnetToUseHubVnetGateway;

        /// <summary>Allow RemoteVnet to use Virtual Hub's gateways.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? AllowRemoteVnetToUseHubVnetGateway { get => this._allowRemoteVnetToUseHubVnetGateway; set => this._allowRemoteVnetToUseHubVnetGateway = value; }

        /// <summary>Backing field for <see cref="EnableInternetSecurity" /> property.</summary>
        private bool? _enableInternetSecurity;

        /// <summary>Enable internet security</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? EnableInternetSecurity { get => this._enableInternetSecurity; set => this._enableInternetSecurity = value; }

        /// <summary>Internal Acessors for RemoteVnet</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHubVirtualNetworkConnectionPropertiesInternal.RemoteVnet { get => (this._remoteVnet = this._remoteVnet ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set { {_remoteVnet = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? _provisioningState;

        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Backing field for <see cref="RemoteVnet" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource _remoteVnet;

        /// <summary>Reference to the remote virtual network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource RemoteVnet { get => (this._remoteVnet = this._remoteVnet ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set => this._remoteVnet = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RemoteVnetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)RemoteVnet).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)RemoteVnet).Id = value; }

        /// <summary>Creates an new <see cref="HubVirtualNetworkConnectionProperties" /> instance.</summary>
        public HubVirtualNetworkConnectionProperties()
        {

        }
    }
    /// Parameters for HubVirtualNetworkConnection
    public partial interface IHubVirtualNetworkConnectionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>VirtualHub to RemoteVnet transit to enabled or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"VirtualHub to RemoteVnet transit to enabled or not.",
        SerializedName = @"allowHubToRemoteVnetTransit",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AllowHubToRemoteVnetTransit { get; set; }
        /// <summary>Allow RemoteVnet to use Virtual Hub's gateways.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Allow RemoteVnet to use Virtual Hub's gateways.",
        SerializedName = @"allowRemoteVnetToUseHubVnetGateways",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AllowRemoteVnetToUseHubVnetGateway { get; set; }
        /// <summary>Enable internet security</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Enable internet security",
        SerializedName = @"enableInternetSecurity",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableInternetSecurity { get; set; }
        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The provisioning state of the resource.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string RemoteVnetId { get; set; }

    }
    /// Parameters for HubVirtualNetworkConnection
    internal partial interface IHubVirtualNetworkConnectionPropertiesInternal

    {
        /// <summary>VirtualHub to RemoteVnet transit to enabled or not.</summary>
        bool? AllowHubToRemoteVnetTransit { get; set; }
        /// <summary>Allow RemoteVnet to use Virtual Hub's gateways.</summary>
        bool? AllowRemoteVnetToUseHubVnetGateway { get; set; }
        /// <summary>Enable internet security</summary>
        bool? EnableInternetSecurity { get; set; }
        /// <summary>The provisioning state of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>Reference to the remote virtual network.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource RemoteVnet { get; set; }
        /// <summary>Resource ID.</summary>
        string RemoteVnetId { get; set; }

    }
}