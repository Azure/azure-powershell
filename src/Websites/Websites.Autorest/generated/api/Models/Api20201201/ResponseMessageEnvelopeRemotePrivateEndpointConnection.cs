namespace Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Extensions;

    /// <summary>
    /// Message envelope that contains the common Azure resource manager properties and the resource provider specific content.
    /// </summary>
    public partial class ResponseMessageEnvelopeRemotePrivateEndpointConnection :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnection,
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnectionInternal
    {

        /// <summary>Current number of instances assigned to the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public int? Capacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ISkuDescriptionInternal)Sku).Capacity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ISkuDescriptionInternal)Sku).Capacity = value ?? default(int); }

        /// <summary>Basic error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IErrorEntityInternal)Error).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IErrorEntityInternal)Error).Code = value ?? null; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IErrorEntity _error;

        /// <summary>Azure-AsyncOperation Error info.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IErrorEntity Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ErrorEntity()); set => this._error = value; }

        /// <summary>Type of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string ExtendedCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IErrorEntityInternal)Error).ExtendedCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IErrorEntityInternal)Error).ExtendedCode = value ?? null; }

        /// <summary>Private IPAddresses mapped to the remote private endpoint</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string[] IPAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionInternal)Property).IPAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionInternal)Property).IPAddress = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>
        /// Resource Id. Typically ID is populated only for responses to GET requests. Caller is responsible for passing in this
        /// value for GET requests only.
        /// For example: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupId}/providers/Microsoft.Web/sites/{sitename}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Backing field for <see cref="Identity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IManagedServiceIdentity _identity;

        /// <summary>MSI resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IManagedServiceIdentity Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ManagedServiceIdentity()); set => this._identity = value; }

        /// <summary>Principal Id of managed service identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IManagedServiceIdentityInternal)Identity).PrincipalId; }

        /// <summary>Tenant of managed service identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IManagedServiceIdentityInternal)Identity).TenantId; }

        /// <summary>Type of managed service identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.ManagedServiceIdentityType? IdentityType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IManagedServiceIdentityInternal)Identity).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IManagedServiceIdentityInternal)Identity).Type = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.ManagedServiceIdentityType)""); }

        /// <summary>
        /// The list of user assigned identities associated with the resource. The user identity dictionary key references will be
        /// ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IManagedServiceIdentityUserAssignedIdentities IdentityUserAssignedIdentity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IManagedServiceIdentityInternal)Identity).UserAssignedIdentity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IManagedServiceIdentityInternal)Identity).UserAssignedIdentity = value ?? null /* model class */; }

        /// <summary>Inner errors.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IErrorEntity[] InnerError { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IErrorEntityInternal)Error).InnerError; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IErrorEntityInternal)Error).InnerError = value ?? null /* arrayOf */; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)Property).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)Property).Kind = value ?? null; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        /// <summary>Geographical region resource belongs to e.g. SouthCentralUS, SouthEastAsia.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string Location { get => this._location; set => this._location = value; }

        /// <summary>Any details of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IErrorEntityInternal)Error).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IErrorEntityInternal)Error).Message = value ?? null; }

        /// <summary>Message template.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string MessageTemplate { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IErrorEntityInternal)Error).MessageTemplate; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IErrorEntityInternal)Error).MessageTemplate = value ?? null; }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IErrorEntity Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnectionInternal.Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ErrorEntity()); set { {_error = value;} } }

        /// <summary>Internal Acessors for Identity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IManagedServiceIdentity Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnectionInternal.Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ManagedServiceIdentity()); set { {_identity = value;} } }

        /// <summary>Internal Acessors for IdentityPrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnectionInternal.IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IManagedServiceIdentityInternal)Identity).PrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IManagedServiceIdentityInternal)Identity).PrincipalId = value; }

        /// <summary>Internal Acessors for IdentityTenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnectionInternal.IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IManagedServiceIdentityInternal)Identity).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IManagedServiceIdentityInternal)Identity).TenantId = value; }

        /// <summary>Internal Acessors for Plan</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IArmPlan Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnectionInternal.Plan { get => (this._plan = this._plan ?? new Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ArmPlan()); set { {_plan = value;} } }

        /// <summary>Internal Acessors for PrivateEndpoint</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IArmIdWrapper Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnectionInternal.PrivateEndpoint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionInternal)Property).PrivateEndpoint; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionInternal)Property).PrivateEndpoint = value; }

        /// <summary>Internal Acessors for PrivateEndpointId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnectionInternal.PrivateEndpointId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionInternal)Property).PrivateEndpointId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionInternal)Property).PrivateEndpointId = value; }

        /// <summary>Internal Acessors for PrivateLinkServiceConnectionState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IPrivateLinkConnectionState Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnectionInternal.PrivateLinkServiceConnectionState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionInternal)Property).PrivateLinkServiceConnectionState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionInternal)Property).PrivateLinkServiceConnectionState = value; }

        /// <summary>Internal Acessors for PropertiesId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnectionInternal.PropertiesId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)Property).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)Property).Id = value; }

        /// <summary>Internal Acessors for PropertiesName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnectionInternal.PropertiesName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)Property).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)Property).Name = value; }

        /// <summary>Internal Acessors for PropertiesType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnectionInternal.PropertiesType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)Property).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)Property).Type = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnection Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnectionInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.RemotePrivateEndpointConnection()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnectionInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for RemotePrivateEndpointConnectionProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionProperties Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnectionInternal.RemotePrivateEndpointConnectionProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionInternal)Property).Property; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionInternal)Property).Property = value; }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ISkuDescription Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnectionInternal.Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.SkuDescription()); set { {_sku = value;} } }

        /// <summary>Internal Acessors for SkuCapacity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ISkuCapacity Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnectionInternal.SkuCapacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ISkuDescriptionInternal)Sku).SkuCapacity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ISkuDescriptionInternal)Sku).SkuCapacity = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Parameters for the template.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string[] Parameter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IErrorEntityInternal)Error).Parameter; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IErrorEntityInternal)Error).Parameter = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="Plan" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IArmPlan _plan;

        /// <summary>Azure resource manager plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IArmPlan Plan { get => (this._plan = this._plan ?? new Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ArmPlan()); set => this._plan = value; }

        /// <summary>The name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string PlanName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IArmPlanInternal)Plan).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IArmPlanInternal)Plan).Name = value ?? null; }

        /// <summary>The product.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string PlanProduct { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IArmPlanInternal)Plan).Product; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IArmPlanInternal)Plan).Product = value ?? null; }

        /// <summary>The promotion code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string PlanPromotionCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IArmPlanInternal)Plan).PromotionCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IArmPlanInternal)Plan).PromotionCode = value ?? null; }

        /// <summary>The publisher.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string PlanPublisher { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IArmPlanInternal)Plan).Publisher; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IArmPlanInternal)Plan).Publisher = value ?? null; }

        /// <summary>Version of product.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string PlanVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IArmPlanInternal)Plan).Version; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IArmPlanInternal)Plan).Version = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string PrivateEndpointId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionInternal)Property).PrivateEndpointId; }

        /// <summary>ActionsRequired for a private link connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string PrivateLinkServiceConnectionStateActionsRequired { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionInternal)Property).PrivateLinkServiceConnectionStateActionsRequired; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionInternal)Property).PrivateLinkServiceConnectionStateActionsRequired = value ?? null; }

        /// <summary>Description of a private link connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string PrivateLinkServiceConnectionStateDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionInternal)Property).PrivateLinkServiceConnectionStateDescription; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionInternal)Property).PrivateLinkServiceConnectionStateDescription = value ?? null; }

        /// <summary>Status of a private link connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string PrivateLinkServiceConnectionStateStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionInternal)Property).PrivateLinkServiceConnectionStateStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionInternal)Property).PrivateLinkServiceConnectionStateStatus = value ?? null; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string PropertiesId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)Property).Id; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string PropertiesName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)Property).Name; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string PropertiesType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)Property).Type; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnection _property;

        /// <summary>Resource specific properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnection Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.RemotePrivateEndpointConnection()); set => this._property = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionInternal)Property).ProvisioningState; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ISkuDescription _sku;

        /// <summary>SKU description of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ISkuDescription Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.SkuDescription()); set => this._sku = value; }

        /// <summary>Capabilities of the SKU, e.g., is traffic manager enabled?</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ICapability[] SkuCapability { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ISkuDescriptionInternal)Sku).Capability; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ISkuDescriptionInternal)Sku).Capability = value ?? null /* arrayOf */; }

        /// <summary>Default number of workers for this App Service plan SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public int? SkuCapacityDefault { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ISkuDescriptionInternal)Sku).SkuCapacityDefault; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ISkuDescriptionInternal)Sku).SkuCapacityDefault = value ?? default(int); }

        /// <summary>Maximum number of Elastic workers for this App Service plan SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public int? SkuCapacityElasticMaximum { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ISkuDescriptionInternal)Sku).SkuCapacityElasticMaximum; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ISkuDescriptionInternal)Sku).SkuCapacityElasticMaximum = value ?? default(int); }

        /// <summary>Maximum number of workers for this App Service plan SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public int? SkuCapacityMaximum { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ISkuDescriptionInternal)Sku).SkuCapacityMaximum; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ISkuDescriptionInternal)Sku).SkuCapacityMaximum = value ?? default(int); }

        /// <summary>Minimum number of workers for this App Service plan SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public int? SkuCapacityMinimum { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ISkuDescriptionInternal)Sku).SkuCapacityMinimum; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ISkuDescriptionInternal)Sku).SkuCapacityMinimum = value ?? default(int); }

        /// <summary>Available scale configurations for an App Service plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string SkuCapacityScaleType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ISkuDescriptionInternal)Sku).SkuCapacityScaleType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ISkuDescriptionInternal)Sku).SkuCapacityScaleType = value ?? null; }

        /// <summary>Family code of the resource SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string SkuFamily { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ISkuDescriptionInternal)Sku).Family; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ISkuDescriptionInternal)Sku).Family = value ?? null; }

        /// <summary>Locations of the SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string[] SkuLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ISkuDescriptionInternal)Sku).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ISkuDescriptionInternal)Sku).Location = value ?? null /* arrayOf */; }

        /// <summary>Name of the resource SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ISkuDescriptionInternal)Sku).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ISkuDescriptionInternal)Sku).Name = value ?? null; }

        /// <summary>Size specifier of the resource SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string SkuSize { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ISkuDescriptionInternal)Sku).Size; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ISkuDescriptionInternal)Sku).Size = value ?? null; }

        /// <summary>Service tier of the resource SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string SkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ISkuDescriptionInternal)Sku).Tier; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ISkuDescriptionInternal)Sku).Tier = value ?? null; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private string _status;

        /// <summary>Azure-AsyncOperation Status info.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string Status { get => this._status; set => this._status = value; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnectionTags _tag;

        /// <summary>Tags associated with resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnectionTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ResponseMessageEnvelopeRemotePrivateEndpointConnectionTags()); set => this._tag = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Type of resource e.g "Microsoft.Web/sites".</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Backing field for <see cref="Zone" /> property.</summary>
        private string[] _zone;

        /// <summary>Logical Availability Zones the service is hosted in</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string[] Zone { get => this._zone; set => this._zone = value; }

        /// <summary>
        /// Creates an new <see cref="ResponseMessageEnvelopeRemotePrivateEndpointConnection" /> instance.
        /// </summary>
        public ResponseMessageEnvelopeRemotePrivateEndpointConnection()
        {

        }
    }
    /// Message envelope that contains the common Azure resource manager properties and the resource provider specific content.
    public partial interface IResponseMessageEnvelopeRemotePrivateEndpointConnection :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.IJsonSerializable
    {
        /// <summary>Current number of instances assigned to the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Current number of instances assigned to the resource.",
        SerializedName = @"capacity",
        PossibleTypes = new [] { typeof(int) })]
        int? Capacity { get; set; }
        /// <summary>Basic error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Basic error code.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get; set; }
        /// <summary>Type of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of error.",
        SerializedName = @"extendedCode",
        PossibleTypes = new [] { typeof(string) })]
        string ExtendedCode { get; set; }
        /// <summary>Private IPAddresses mapped to the remote private endpoint</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Private IPAddresses mapped to the remote private endpoint",
        SerializedName = @"ipAddresses",
        PossibleTypes = new [] { typeof(string) })]
        string[] IPAddress { get; set; }
        /// <summary>
        /// Resource Id. Typically ID is populated only for responses to GET requests. Caller is responsible for passing in this
        /// value for GET requests only.
        /// For example: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupId}/providers/Microsoft.Web/sites/{sitename}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource Id. Typically ID is populated only for responses to GET requests. Caller is responsible for passing in this
        value for GET requests only.
        For example: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupId}/providers/Microsoft.Web/sites/{sitename}",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>Principal Id of managed service identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Principal Id of managed service identity.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityPrincipalId { get;  }
        /// <summary>Tenant of managed service identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Tenant of managed service identity.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityTenantId { get;  }
        /// <summary>Type of managed service identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of managed service identity.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.ManagedServiceIdentityType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.ManagedServiceIdentityType? IdentityType { get; set; }
        /// <summary>
        /// The list of user assigned identities associated with the resource. The user identity dictionary key references will be
        /// ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of user assigned identities associated with the resource. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}",
        SerializedName = @"userAssignedIdentities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IManagedServiceIdentityUserAssignedIdentities) })]
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IManagedServiceIdentityUserAssignedIdentities IdentityUserAssignedIdentity { get; set; }
        /// <summary>Inner errors.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Inner errors.",
        SerializedName = @"innerErrors",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IErrorEntity) })]
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IErrorEntity[] InnerError { get; set; }
        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Kind of resource.",
        SerializedName = @"kind",
        PossibleTypes = new [] { typeof(string) })]
        string Kind { get; set; }
        /// <summary>Geographical region resource belongs to e.g. SouthCentralUS, SouthEastAsia.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Geographical region resource belongs to e.g. SouthCentralUS, SouthEastAsia.",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get; set; }
        /// <summary>Any details of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Any details of the error.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>Message template.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Message template.",
        SerializedName = @"messageTemplate",
        PossibleTypes = new [] { typeof(string) })]
        string MessageTemplate { get; set; }
        /// <summary>Name of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of resource.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Parameters for the template.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Parameters for the template.",
        SerializedName = @"parameters",
        PossibleTypes = new [] { typeof(string) })]
        string[] Parameter { get; set; }
        /// <summary>The name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string PlanName { get; set; }
        /// <summary>The product.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The product.",
        SerializedName = @"product",
        PossibleTypes = new [] { typeof(string) })]
        string PlanProduct { get; set; }
        /// <summary>The promotion code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The promotion code.",
        SerializedName = @"promotionCode",
        PossibleTypes = new [] { typeof(string) })]
        string PlanPromotionCode { get; set; }
        /// <summary>The publisher.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The publisher.",
        SerializedName = @"publisher",
        PossibleTypes = new [] { typeof(string) })]
        string PlanPublisher { get; set; }
        /// <summary>Version of product.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Version of product.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string PlanVersion { get; set; }

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
        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource Id.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string PropertiesId { get;  }
        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource Name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string PropertiesName { get;  }
        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string PropertiesType { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>Capabilities of the SKU, e.g., is traffic manager enabled?</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Capabilities of the SKU, e.g., is traffic manager enabled?",
        SerializedName = @"capabilities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ICapability) })]
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ICapability[] SkuCapability { get; set; }
        /// <summary>Default number of workers for this App Service plan SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Default number of workers for this App Service plan SKU.",
        SerializedName = @"default",
        PossibleTypes = new [] { typeof(int) })]
        int? SkuCapacityDefault { get; set; }
        /// <summary>Maximum number of Elastic workers for this App Service plan SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Maximum number of Elastic workers for this App Service plan SKU.",
        SerializedName = @"elasticMaximum",
        PossibleTypes = new [] { typeof(int) })]
        int? SkuCapacityElasticMaximum { get; set; }
        /// <summary>Maximum number of workers for this App Service plan SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Maximum number of workers for this App Service plan SKU.",
        SerializedName = @"maximum",
        PossibleTypes = new [] { typeof(int) })]
        int? SkuCapacityMaximum { get; set; }
        /// <summary>Minimum number of workers for this App Service plan SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Minimum number of workers for this App Service plan SKU.",
        SerializedName = @"minimum",
        PossibleTypes = new [] { typeof(int) })]
        int? SkuCapacityMinimum { get; set; }
        /// <summary>Available scale configurations for an App Service plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Available scale configurations for an App Service plan.",
        SerializedName = @"scaleType",
        PossibleTypes = new [] { typeof(string) })]
        string SkuCapacityScaleType { get; set; }
        /// <summary>Family code of the resource SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Family code of the resource SKU.",
        SerializedName = @"family",
        PossibleTypes = new [] { typeof(string) })]
        string SkuFamily { get; set; }
        /// <summary>Locations of the SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Locations of the SKU.",
        SerializedName = @"locations",
        PossibleTypes = new [] { typeof(string) })]
        string[] SkuLocation { get; set; }
        /// <summary>Name of the resource SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the resource SKU.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string SkuName { get; set; }
        /// <summary>Size specifier of the resource SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Size specifier of the resource SKU.",
        SerializedName = @"size",
        PossibleTypes = new [] { typeof(string) })]
        string SkuSize { get; set; }
        /// <summary>Service tier of the resource SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Service tier of the resource SKU.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(string) })]
        string SkuTier { get; set; }
        /// <summary>Azure-AsyncOperation Status info.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Azure-AsyncOperation Status info.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        string Status { get; set; }
        /// <summary>Tags associated with resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Tags associated with resource.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnectionTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnectionTags Tag { get; set; }
        /// <summary>Type of resource e.g "Microsoft.Web/sites".</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of resource e.g ""Microsoft.Web/sites"".",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }
        /// <summary>Logical Availability Zones the service is hosted in</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Logical Availability Zones the service is hosted in",
        SerializedName = @"zones",
        PossibleTypes = new [] { typeof(string) })]
        string[] Zone { get; set; }

    }
    /// Message envelope that contains the common Azure resource manager properties and the resource provider specific content.
    internal partial interface IResponseMessageEnvelopeRemotePrivateEndpointConnectionInternal

    {
        /// <summary>Current number of instances assigned to the resource.</summary>
        int? Capacity { get; set; }
        /// <summary>Basic error code.</summary>
        string Code { get; set; }
        /// <summary>Azure-AsyncOperation Error info.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IErrorEntity Error { get; set; }
        /// <summary>Type of error.</summary>
        string ExtendedCode { get; set; }
        /// <summary>Private IPAddresses mapped to the remote private endpoint</summary>
        string[] IPAddress { get; set; }
        /// <summary>
        /// Resource Id. Typically ID is populated only for responses to GET requests. Caller is responsible for passing in this
        /// value for GET requests only.
        /// For example: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupId}/providers/Microsoft.Web/sites/{sitename}
        /// </summary>
        string Id { get; set; }
        /// <summary>MSI resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IManagedServiceIdentity Identity { get; set; }
        /// <summary>Principal Id of managed service identity.</summary>
        string IdentityPrincipalId { get; set; }
        /// <summary>Tenant of managed service identity.</summary>
        string IdentityTenantId { get; set; }
        /// <summary>Type of managed service identity.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.ManagedServiceIdentityType? IdentityType { get; set; }
        /// <summary>
        /// The list of user assigned identities associated with the resource. The user identity dictionary key references will be
        /// ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IManagedServiceIdentityUserAssignedIdentities IdentityUserAssignedIdentity { get; set; }
        /// <summary>Inner errors.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IErrorEntity[] InnerError { get; set; }
        /// <summary>Kind of resource.</summary>
        string Kind { get; set; }
        /// <summary>Geographical region resource belongs to e.g. SouthCentralUS, SouthEastAsia.</summary>
        string Location { get; set; }
        /// <summary>Any details of the error.</summary>
        string Message { get; set; }
        /// <summary>Message template.</summary>
        string MessageTemplate { get; set; }
        /// <summary>Name of resource.</summary>
        string Name { get; set; }
        /// <summary>Parameters for the template.</summary>
        string[] Parameter { get; set; }
        /// <summary>Azure resource manager plan.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IArmPlan Plan { get; set; }
        /// <summary>The name.</summary>
        string PlanName { get; set; }
        /// <summary>The product.</summary>
        string PlanProduct { get; set; }
        /// <summary>The promotion code.</summary>
        string PlanPromotionCode { get; set; }
        /// <summary>The publisher.</summary>
        string PlanPublisher { get; set; }
        /// <summary>Version of product.</summary>
        string PlanVersion { get; set; }
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
        /// <summary>Resource Id.</summary>
        string PropertiesId { get; set; }
        /// <summary>Resource Name.</summary>
        string PropertiesName { get; set; }
        /// <summary>Resource type.</summary>
        string PropertiesType { get; set; }
        /// <summary>Resource specific properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnection Property { get; set; }

        string ProvisioningState { get; set; }
        /// <summary>RemotePrivateEndpointConnection resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionProperties RemotePrivateEndpointConnectionProperty { get; set; }
        /// <summary>SKU description of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ISkuDescription Sku { get; set; }
        /// <summary>Capabilities of the SKU, e.g., is traffic manager enabled?</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ICapability[] SkuCapability { get; set; }
        /// <summary>Min, max, and default scale values of the SKU.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ISkuCapacity SkuCapacity { get; set; }
        /// <summary>Default number of workers for this App Service plan SKU.</summary>
        int? SkuCapacityDefault { get; set; }
        /// <summary>Maximum number of Elastic workers for this App Service plan SKU.</summary>
        int? SkuCapacityElasticMaximum { get; set; }
        /// <summary>Maximum number of workers for this App Service plan SKU.</summary>
        int? SkuCapacityMaximum { get; set; }
        /// <summary>Minimum number of workers for this App Service plan SKU.</summary>
        int? SkuCapacityMinimum { get; set; }
        /// <summary>Available scale configurations for an App Service plan.</summary>
        string SkuCapacityScaleType { get; set; }
        /// <summary>Family code of the resource SKU.</summary>
        string SkuFamily { get; set; }
        /// <summary>Locations of the SKU.</summary>
        string[] SkuLocation { get; set; }
        /// <summary>Name of the resource SKU.</summary>
        string SkuName { get; set; }
        /// <summary>Size specifier of the resource SKU.</summary>
        string SkuSize { get; set; }
        /// <summary>Service tier of the resource SKU.</summary>
        string SkuTier { get; set; }
        /// <summary>Azure-AsyncOperation Status info.</summary>
        string Status { get; set; }
        /// <summary>Tags associated with resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnectionTags Tag { get; set; }
        /// <summary>Type of resource e.g "Microsoft.Web/sites".</summary>
        string Type { get; set; }
        /// <summary>Logical Availability Zones the service is hosted in</summary>
        string[] Zone { get; set; }

    }
}