namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>Properties of a private endpoint connection.</summary>
    public partial class PrivateEndpointConnectionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateEndpointConnectionProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateEndpointConnectionPropertiesInternal
    {

        /// <summary>Internal Acessors for PrivateEndpoint</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateEndpoint Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateEndpointConnectionPropertiesInternal.PrivateEndpoint { get => (this._privateEndpoint = this._privateEndpoint ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.PrivateEndpoint()); set { {_privateEndpoint = value;} } }

        /// <summary>Internal Acessors for PrivateLinkServiceConnectionState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateLinkServiceConnectionState Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateEndpointConnectionPropertiesInternal.PrivateLinkServiceConnectionState { get => (this._privateLinkServiceConnectionState = this._privateLinkServiceConnectionState ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.PrivateLinkServiceConnectionState()); set { {_privateLinkServiceConnectionState = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.PrivateEndpointConnectionProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateEndpointConnectionPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="PrivateEndpoint" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateEndpoint _privateEndpoint;

        /// <summary>The resource of private endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateEndpoint PrivateEndpoint { get => (this._privateEndpoint = this._privateEndpoint ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.PrivateEndpoint()); set => this._privateEndpoint = value; }

        /// <summary>The resource Id for private endpoint</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string PrivateEndpointId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateEndpointInternal)PrivateEndpoint).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateEndpointInternal)PrivateEndpoint).Id = value ?? null; }

        /// <summary>Backing field for <see cref="PrivateLinkServiceConnectionState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateLinkServiceConnectionState _privateLinkServiceConnectionState;

        /// <summary>
        /// A collection of information about the state of the connection between service consumer and provider.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get => (this._privateLinkServiceConnectionState = this._privateLinkServiceConnectionState ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.PrivateLinkServiceConnectionState()); set => this._privateLinkServiceConnectionState = value; }

        /// <summary>The private link service connection description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string PrivateLinkServiceConnectionStateDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateLinkServiceConnectionStateInternal)PrivateLinkServiceConnectionState).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateLinkServiceConnectionStateInternal)PrivateLinkServiceConnectionState).Description = value ?? null; }

        /// <summary>The private link service connection status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ConnectionStatus? PrivateLinkServiceConnectionStateStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateLinkServiceConnectionStateInternal)PrivateLinkServiceConnectionState).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateLinkServiceConnectionStateInternal)PrivateLinkServiceConnectionState).Status = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ConnectionStatus)""); }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.PrivateEndpointConnectionProvisioningState? _provisioningState;

        /// <summary>The current provisioning state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.PrivateEndpointConnectionProvisioningState? ProvisioningState { get => this._provisioningState; }

        /// <summary>Creates an new <see cref="PrivateEndpointConnectionProperties" /> instance.</summary>
        public PrivateEndpointConnectionProperties()
        {

        }
    }
    /// Properties of a private endpoint connection.
    public partial interface IPrivateEndpointConnectionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
        /// <summary>The resource Id for private endpoint</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource Id for private endpoint",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateEndpointId { get; set; }
        /// <summary>The private link service connection description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The private link service connection description.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateLinkServiceConnectionStateDescription { get; set; }
        /// <summary>The private link service connection status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The private link service connection status.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ConnectionStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ConnectionStatus? PrivateLinkServiceConnectionStateStatus { get; set; }
        /// <summary>The current provisioning state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The current provisioning state.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.PrivateEndpointConnectionProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.PrivateEndpointConnectionProvisioningState? ProvisioningState { get;  }

    }
    /// Properties of a private endpoint connection.
    internal partial interface IPrivateEndpointConnectionPropertiesInternal

    {
        /// <summary>The resource of private endpoint.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateEndpoint PrivateEndpoint { get; set; }
        /// <summary>The resource Id for private endpoint</summary>
        string PrivateEndpointId { get; set; }
        /// <summary>
        /// A collection of information about the state of the connection between service consumer and provider.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get; set; }
        /// <summary>The private link service connection description.</summary>
        string PrivateLinkServiceConnectionStateDescription { get; set; }
        /// <summary>The private link service connection status.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ConnectionStatus? PrivateLinkServiceConnectionStateStatus { get; set; }
        /// <summary>The current provisioning state.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.PrivateEndpointConnectionProvisioningState? ProvisioningState { get; set; }

    }
}