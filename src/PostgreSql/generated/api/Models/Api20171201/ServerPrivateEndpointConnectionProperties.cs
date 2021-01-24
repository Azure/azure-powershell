namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Extensions;

    /// <summary>Properties of a private endpoint connection.</summary>
    public partial class ServerPrivateEndpointConnectionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPrivateEndpointConnectionProperties,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPrivateEndpointConnectionPropertiesInternal
    {

        /// <summary>Internal Acessors for PrivateEndpoint</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IPrivateEndpointProperty Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPrivateEndpointConnectionPropertiesInternal.PrivateEndpoint { get => (this._privateEndpoint = this._privateEndpoint ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.PrivateEndpointProperty()); set { {_privateEndpoint = value;} } }

        /// <summary>Internal Acessors for PrivateLinkServiceConnectionState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPrivateLinkServiceConnectionStateProperty Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPrivateEndpointConnectionPropertiesInternal.PrivateLinkServiceConnectionState { get => (this._privateLinkServiceConnectionState = this._privateLinkServiceConnectionState ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ServerPrivateLinkServiceConnectionStateProperty()); set { {_privateLinkServiceConnectionState = value;} } }

        /// <summary>Internal Acessors for PrivateLinkServiceConnectionStateActionsRequired</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.PrivateLinkServiceConnectionStateActionsRequire? Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPrivateEndpointConnectionPropertiesInternal.PrivateLinkServiceConnectionStateActionsRequired { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPrivateLinkServiceConnectionStatePropertyInternal)PrivateLinkServiceConnectionState).ActionsRequired; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPrivateLinkServiceConnectionStatePropertyInternal)PrivateLinkServiceConnectionState).ActionsRequired = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.PrivateEndpointProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPrivateEndpointConnectionPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="PrivateEndpoint" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IPrivateEndpointProperty _privateEndpoint;

        /// <summary>Private endpoint which the connection belongs to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IPrivateEndpointProperty PrivateEndpoint { get => (this._privateEndpoint = this._privateEndpoint ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.PrivateEndpointProperty()); set => this._privateEndpoint = value; }

        /// <summary>Resource id of the private endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inlined)]
        public string PrivateEndpointId { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IPrivateEndpointPropertyInternal)PrivateEndpoint).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IPrivateEndpointPropertyInternal)PrivateEndpoint).Id = value ?? null; }

        /// <summary>Backing field for <see cref="PrivateLinkServiceConnectionState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPrivateLinkServiceConnectionStateProperty _privateLinkServiceConnectionState;

        /// <summary>Connection state of the private endpoint connection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPrivateLinkServiceConnectionStateProperty PrivateLinkServiceConnectionState { get => (this._privateLinkServiceConnectionState = this._privateLinkServiceConnectionState ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ServerPrivateLinkServiceConnectionStateProperty()); set => this._privateLinkServiceConnectionState = value; }

        /// <summary>The actions required for private link service connection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.PrivateLinkServiceConnectionStateActionsRequire? PrivateLinkServiceConnectionStateActionsRequired { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPrivateLinkServiceConnectionStatePropertyInternal)PrivateLinkServiceConnectionState).ActionsRequired; }

        /// <summary>The private link service connection description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inlined)]
        public string PrivateLinkServiceConnectionStateDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPrivateLinkServiceConnectionStatePropertyInternal)PrivateLinkServiceConnectionState).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPrivateLinkServiceConnectionStatePropertyInternal)PrivateLinkServiceConnectionState).Description = value ?? null; }

        /// <summary>The private link service connection status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.PrivateLinkServiceConnectionStateStatus? PrivateLinkServiceConnectionStateStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPrivateLinkServiceConnectionStatePropertyInternal)PrivateLinkServiceConnectionState).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPrivateLinkServiceConnectionStatePropertyInternal)PrivateLinkServiceConnectionState).Status = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.PrivateLinkServiceConnectionStateStatus)""); }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.PrivateEndpointProvisioningState? _provisioningState;

        /// <summary>State of the private endpoint connection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.PrivateEndpointProvisioningState? ProvisioningState { get => this._provisioningState; }

        /// <summary>
        /// Creates an new <see cref="ServerPrivateEndpointConnectionProperties" /> instance.
        /// </summary>
        public ServerPrivateEndpointConnectionProperties()
        {

        }
    }
    /// Properties of a private endpoint connection.
    public partial interface IServerPrivateEndpointConnectionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.IJsonSerializable
    {
        /// <summary>Resource id of the private endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource id of the private endpoint.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateEndpointId { get; set; }
        /// <summary>The actions required for private link service connection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The actions required for private link service connection.",
        SerializedName = @"actionsRequired",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.PrivateLinkServiceConnectionStateActionsRequire) })]
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.PrivateLinkServiceConnectionStateActionsRequire? PrivateLinkServiceConnectionStateActionsRequired { get;  }
        /// <summary>The private link service connection description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The private link service connection description.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateLinkServiceConnectionStateDescription { get; set; }
        /// <summary>The private link service connection status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The private link service connection status.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.PrivateLinkServiceConnectionStateStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.PrivateLinkServiceConnectionStateStatus? PrivateLinkServiceConnectionStateStatus { get; set; }
        /// <summary>State of the private endpoint connection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"State of the private endpoint connection.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.PrivateEndpointProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.PrivateEndpointProvisioningState? ProvisioningState { get;  }

    }
    /// Properties of a private endpoint connection.
    internal partial interface IServerPrivateEndpointConnectionPropertiesInternal

    {
        /// <summary>Private endpoint which the connection belongs to.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IPrivateEndpointProperty PrivateEndpoint { get; set; }
        /// <summary>Resource id of the private endpoint.</summary>
        string PrivateEndpointId { get; set; }
        /// <summary>Connection state of the private endpoint connection.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPrivateLinkServiceConnectionStateProperty PrivateLinkServiceConnectionState { get; set; }
        /// <summary>The actions required for private link service connection.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.PrivateLinkServiceConnectionStateActionsRequire? PrivateLinkServiceConnectionStateActionsRequired { get; set; }
        /// <summary>The private link service connection description.</summary>
        string PrivateLinkServiceConnectionStateDescription { get; set; }
        /// <summary>The private link service connection status.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.PrivateLinkServiceConnectionStateStatus? PrivateLinkServiceConnectionStateStatus { get; set; }
        /// <summary>State of the private endpoint connection.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.PrivateEndpointProvisioningState? ProvisioningState { get; set; }

    }
}