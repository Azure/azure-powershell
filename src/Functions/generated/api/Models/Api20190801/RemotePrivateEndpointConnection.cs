namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>A remote private endpoint connection</summary>
    public partial class RemotePrivateEndpointConnection :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRemotePrivateEndpointConnection,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRemotePrivateEndpointConnectionInternal
    {

        /// <summary>Internal Acessors for PrivateEndpoint</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IArmIdWrapper Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRemotePrivateEndpointConnectionInternal.PrivateEndpoint { get => (this._privateEndpoint = this._privateEndpoint ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ArmIdWrapper()); set { {_privateEndpoint = value;} } }

        /// <summary>Internal Acessors for PrivateEndpointId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRemotePrivateEndpointConnectionInternal.PrivateEndpointId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IArmIdWrapperInternal)PrivateEndpoint).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IArmIdWrapperInternal)PrivateEndpoint).Id = value; }

        /// <summary>Internal Acessors for PrivateLinkServiceConnectionState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkConnectionState Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRemotePrivateEndpointConnectionInternal.PrivateLinkServiceConnectionState { get => (this._privateLinkServiceConnectionState = this._privateLinkServiceConnectionState ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.PrivateLinkConnectionState()); set { {_privateLinkServiceConnectionState = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRemotePrivateEndpointConnectionInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="PrivateEndpoint" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IArmIdWrapper _privateEndpoint;

        /// <summary>PrivateEndpoint of a remote private endpoint connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IArmIdWrapper PrivateEndpoint { get => (this._privateEndpoint = this._privateEndpoint ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ArmIdWrapper()); set => this._privateEndpoint = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PrivateEndpointId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IArmIdWrapperInternal)PrivateEndpoint).Id; }

        /// <summary>Backing field for <see cref="PrivateLinkServiceConnectionState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkConnectionState _privateLinkServiceConnectionState;

        /// <summary>The state of a private link connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkConnectionState PrivateLinkServiceConnectionState { get => (this._privateLinkServiceConnectionState = this._privateLinkServiceConnectionState ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.PrivateLinkConnectionState()); set => this._privateLinkServiceConnectionState = value; }

        /// <summary>ActionsRequired for a private link connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PrivateLinkServiceConnectionStateActionsRequired { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkConnectionStateInternal)PrivateLinkServiceConnectionState).ActionsRequired; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkConnectionStateInternal)PrivateLinkServiceConnectionState).ActionsRequired = value; }

        /// <summary>Description of a private link connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PrivateLinkServiceConnectionStateDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkConnectionStateInternal)PrivateLinkServiceConnectionState).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkConnectionStateInternal)PrivateLinkServiceConnectionState).Description = value; }

        /// <summary>Status of a private link connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PrivateLinkServiceConnectionStateStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkConnectionStateInternal)PrivateLinkServiceConnectionState).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkConnectionStateInternal)PrivateLinkServiceConnectionState).Status = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Creates an new <see cref="RemotePrivateEndpointConnection" /> instance.</summary>
        public RemotePrivateEndpointConnection()
        {

        }
    }
    /// A remote private endpoint connection
    public partial interface IRemotePrivateEndpointConnection :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateEndpointId { get;  }
        /// <summary>ActionsRequired for a private link connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"ActionsRequired for a private link connection",
        SerializedName = @"actionsRequired",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateLinkServiceConnectionStateActionsRequired { get; set; }
        /// <summary>Description of a private link connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Description of a private link connection",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateLinkServiceConnectionStateDescription { get; set; }
        /// <summary>Status of a private link connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Status of a private link connection",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateLinkServiceConnectionStateStatus { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }

    }
    /// A remote private endpoint connection
    internal partial interface IRemotePrivateEndpointConnectionInternal

    {
        /// <summary>PrivateEndpoint of a remote private endpoint connection</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IArmIdWrapper PrivateEndpoint { get; set; }

        string PrivateEndpointId { get; set; }
        /// <summary>The state of a private link connection</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkConnectionState PrivateLinkServiceConnectionState { get; set; }
        /// <summary>ActionsRequired for a private link connection</summary>
        string PrivateLinkServiceConnectionStateActionsRequired { get; set; }
        /// <summary>Description of a private link connection</summary>
        string PrivateLinkServiceConnectionStateDescription { get; set; }
        /// <summary>Status of a private link connection</summary>
        string PrivateLinkServiceConnectionStateStatus { get; set; }

        string ProvisioningState { get; set; }

    }
}