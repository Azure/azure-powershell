namespace Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Extensions;

    /// <summary>Remote Private Endpoint Connection ARM resource.</summary>
    public partial class RemotePrivateEndpointConnectionArmResource :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionArmResource,
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionArmResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ProxyOnlyResource();

        /// <summary>Private IPAddresses mapped to the remote private endpoint</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string[] IPAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionArmResourcePropertiesInternal)Property).IPAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionArmResourcePropertiesInternal)Property).IPAddress = value ?? null /* arrayOf */; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value ?? null; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Internal Acessors for PrivateEndpoint</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IArmIdWrapper Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionArmResourceInternal.PrivateEndpoint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionArmResourcePropertiesInternal)Property).PrivateEndpoint; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionArmResourcePropertiesInternal)Property).PrivateEndpoint = value; }

        /// <summary>Internal Acessors for PrivateEndpointId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionArmResourceInternal.PrivateEndpointId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionArmResourcePropertiesInternal)Property).PrivateEndpointId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionArmResourcePropertiesInternal)Property).PrivateEndpointId = value; }

        /// <summary>Internal Acessors for PrivateLinkServiceConnectionState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IPrivateLinkConnectionState Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionArmResourceInternal.PrivateLinkServiceConnectionState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionArmResourcePropertiesInternal)Property).PrivateLinkServiceConnectionState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionArmResourcePropertiesInternal)Property).PrivateLinkServiceConnectionState = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionArmResourceProperties Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionArmResourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.RemotePrivateEndpointConnectionArmResourceProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionArmResourceInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionArmResourcePropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionArmResourcePropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string PrivateEndpointId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionArmResourcePropertiesInternal)Property).PrivateEndpointId; }

        /// <summary>ActionsRequired for a private link connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string PrivateLinkServiceConnectionStateActionsRequired { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionArmResourcePropertiesInternal)Property).PrivateLinkServiceConnectionStateActionsRequired; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionArmResourcePropertiesInternal)Property).PrivateLinkServiceConnectionStateActionsRequired = value ?? null; }

        /// <summary>Description of a private link connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string PrivateLinkServiceConnectionStateDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionArmResourcePropertiesInternal)Property).PrivateLinkServiceConnectionStateDescription; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionArmResourcePropertiesInternal)Property).PrivateLinkServiceConnectionStateDescription = value ?? null; }

        /// <summary>Status of a private link connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string PrivateLinkServiceConnectionStateStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionArmResourcePropertiesInternal)Property).PrivateLinkServiceConnectionStateStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionArmResourcePropertiesInternal)Property).PrivateLinkServiceConnectionStateStatus = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionArmResourceProperties _property;

        /// <summary>RemotePrivateEndpointConnectionARMResource resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionArmResourceProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.RemotePrivateEndpointConnectionArmResourceProperties()); set => this._property = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionArmResourcePropertiesInternal)Property).ProvisioningState; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>
        /// Creates an new <see cref="RemotePrivateEndpointConnectionArmResource" /> instance.
        /// </summary>
        public RemotePrivateEndpointConnectionArmResource()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyOnlyResource), __proxyOnlyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyOnlyResource), __proxyOnlyResource);
        }
    }
    /// Remote Private Endpoint Connection ARM resource.
    public partial interface IRemotePrivateEndpointConnectionArmResource :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResource
    {
        /// <summary>Private IPAddresses mapped to the remote private endpoint</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Private IPAddresses mapped to the remote private endpoint",
        SerializedName = @"ipAddresses",
        PossibleTypes = new [] { typeof(string) })]
        string[] IPAddress { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateEndpointId { get;  }
        /// <summary>ActionsRequired for a private link connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"ActionsRequired for a private link connection",
        SerializedName = @"actionsRequired",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateLinkServiceConnectionStateActionsRequired { get; set; }
        /// <summary>Description of a private link connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Description of a private link connection",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateLinkServiceConnectionStateDescription { get; set; }
        /// <summary>Status of a private link connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Status of a private link connection",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateLinkServiceConnectionStateStatus { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }

    }
    /// Remote Private Endpoint Connection ARM resource.
    internal partial interface IRemotePrivateEndpointConnectionArmResourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal
    {
        /// <summary>Private IPAddresses mapped to the remote private endpoint</summary>
        string[] IPAddress { get; set; }
        /// <summary>PrivateEndpoint of a remote private endpoint connection</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IArmIdWrapper PrivateEndpoint { get; set; }

        string PrivateEndpointId { get; set; }
        /// <summary>The state of a private link connection</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IPrivateLinkConnectionState PrivateLinkServiceConnectionState { get; set; }
        /// <summary>ActionsRequired for a private link connection</summary>
        string PrivateLinkServiceConnectionStateActionsRequired { get; set; }
        /// <summary>Description of a private link connection</summary>
        string PrivateLinkServiceConnectionStateDescription { get; set; }
        /// <summary>Status of a private link connection</summary>
        string PrivateLinkServiceConnectionStateStatus { get; set; }
        /// <summary>RemotePrivateEndpointConnectionARMResource resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionArmResourceProperties Property { get; set; }

        string ProvisioningState { get; set; }

    }
}