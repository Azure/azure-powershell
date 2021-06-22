namespace Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Extensions;

    public partial class DatadogMonitorResource :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResource,
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal
    {

        /// <summary>Api key associated to the Datadog organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string DatadogOrganizationPropertyApiKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).DatadogOrganizationPropertyApiKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).DatadogOrganizationPropertyApiKey = value ?? null; }

        /// <summary>Application key associated to the Datadog organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string DatadogOrganizationPropertyApplicationKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).DatadogOrganizationPropertyApplicationKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).DatadogOrganizationPropertyApplicationKey = value ?? null; }

        /// <summary>The Id of the Enterprise App used for Single sign on.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string DatadogOrganizationPropertyEnterpriseAppId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).DatadogOrganizationPropertyEnterpriseAppId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).DatadogOrganizationPropertyEnterpriseAppId = value ?? null; }

        /// <summary>Id of the Datadog organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string DatadogOrganizationPropertyId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).DatadogOrganizationPropertyId; }

        /// <summary>The auth code used to linking to an existing datadog organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string DatadogOrganizationPropertyLinkingAuthCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).DatadogOrganizationPropertyLinkingAuthCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).DatadogOrganizationPropertyLinkingAuthCode = value ?? null; }

        /// <summary>
        /// The client_id from an existing in exchange for an auth token to link organization.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string DatadogOrganizationPropertyLinkingClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).DatadogOrganizationPropertyLinkingClientId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).DatadogOrganizationPropertyLinkingClientId = value ?? null; }

        /// <summary>Name of the Datadog organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string DatadogOrganizationPropertyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).DatadogOrganizationPropertyName; }

        /// <summary>The redirect uri for linking.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string DatadogOrganizationPropertyRedirectUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).DatadogOrganizationPropertyRedirectUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).DatadogOrganizationPropertyRedirectUri = value ?? null; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>ARM id of the monitor resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Backing field for <see cref="Identity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IIdentityProperties _identity;

        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IIdentityProperties Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IdentityProperties()); set => this._identity = value; }

        /// <summary>The identity ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IIdentityPropertiesInternal)Identity).PrincipalId; }

        /// <summary>The tenant ID of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IIdentityPropertiesInternal)Identity).TenantId; }

        /// <summary>Identity type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ManagedIdentityTypes? IdentityType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IIdentityPropertiesInternal)Identity).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IIdentityPropertiesInternal)Identity).Type = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ManagedIdentityTypes)""); }

        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.LiftrResourceCategories? LiftrResourceCategory { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).LiftrResourceCategory; }

        /// <summary>The priority of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public int? LiftrResourcePreference { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).LiftrResourcePreference; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string Location { get => this._location; set => this._location = value; }

        /// <summary>
        /// Flag specifying the Marketplace Subscription Status of the resource. If payment is not made in time, the resource will
        /// go in Suspended state.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MarketplaceSubscriptionStatus? MarketplaceSubscriptionStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).MarketplaceSubscriptionStatus; }

        /// <summary>Internal Acessors for DatadogOrganizationProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationProperties Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal.DatadogOrganizationProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).DatadogOrganizationProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).DatadogOrganizationProperty = value; }

        /// <summary>Internal Acessors for DatadogOrganizationPropertyId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal.DatadogOrganizationPropertyId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).DatadogOrganizationPropertyId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).DatadogOrganizationPropertyId = value; }

        /// <summary>Internal Acessors for DatadogOrganizationPropertyName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal.DatadogOrganizationPropertyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).DatadogOrganizationPropertyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).DatadogOrganizationPropertyName = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for Identity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IIdentityProperties Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal.Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IdentityProperties()); set { {_identity = value;} } }

        /// <summary>Internal Acessors for IdentityPrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal.IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IIdentityPropertiesInternal)Identity).PrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IIdentityPropertiesInternal)Identity).PrincipalId = value; }

        /// <summary>Internal Acessors for IdentityTenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal.IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IIdentityPropertiesInternal)Identity).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IIdentityPropertiesInternal)Identity).TenantId = value; }

        /// <summary>Internal Acessors for LiftrResourceCategory</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.LiftrResourceCategories? Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal.LiftrResourceCategory { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).LiftrResourceCategory; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).LiftrResourceCategory = value; }

        /// <summary>Internal Acessors for LiftrResourcePreference</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal.LiftrResourcePreference { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).LiftrResourcePreference; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).LiftrResourcePreference = value; }

        /// <summary>Internal Acessors for MarketplaceSubscriptionStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MarketplaceSubscriptionStatus? Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal.MarketplaceSubscriptionStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).MarketplaceSubscriptionStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).MarketplaceSubscriptionStatus = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorProperties Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.MonitorProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IResourceSku Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal.Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.ResourceSku()); set { {_sku = value;} } }

        /// <summary>Internal Acessors for SystemData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.ISystemData Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal.SystemData { get => (this._systemData = this._systemData ?? new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.SystemData()); set { {_systemData = value;} } }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Internal Acessors for UserInfo</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IUserInfo Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal.UserInfo { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).UserInfo; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).UserInfo = value; }

        /// <summary>Flag specifying if the resource monitoring is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MonitoringStatus? MonitoringStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).MonitoringStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).MonitoringStatus = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MonitoringStatus)""); }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the monitor resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorProperties _property;

        /// <summary>Properties specific to the monitor resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.MonitorProperties()); set => this._property = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).ProvisioningState; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IResourceSku _sku;

        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IResourceSku Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.ResourceSku()); set => this._sku = value; }

        /// <summary>Name of the SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IResourceSkuInternal)Sku).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IResourceSkuInternal)Sku).Name = value ?? null; }

        /// <summary>Backing field for <see cref="SystemData" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.ISystemData _systemData;

        /// <summary>Metadata pertaining to creation and last modification of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.ISystemData SystemData { get => (this._systemData = this._systemData ?? new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.SystemData()); }

        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public global::System.DateTime? SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.ISystemDataInternal)SystemData).CreatedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.ISystemDataInternal)SystemData).CreatedAt = value ?? default(global::System.DateTime); }

        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.ISystemDataInternal)SystemData).CreatedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.ISystemDataInternal)SystemData).CreatedBy = value ?? null; }

        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.CreatedByType? SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.ISystemDataInternal)SystemData).CreatedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.ISystemDataInternal)SystemData).CreatedByType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.CreatedByType)""); }

        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public global::System.DateTime? SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.ISystemDataInternal)SystemData).LastModifiedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.ISystemDataInternal)SystemData).LastModifiedAt = value ?? default(global::System.DateTime); }

        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.ISystemDataInternal)SystemData).LastModifiedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.ISystemDataInternal)SystemData).LastModifiedBy = value ?? null; }

        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.CreatedByType? SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.ISystemDataInternal)SystemData).LastModifiedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.ISystemDataInternal)SystemData).LastModifiedByType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.CreatedByType)""); }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceTags _tag;

        /// <summary>Dictionary of <string></summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogMonitorResourceTags()); set => this._tag = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>The type of the monitor resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>Email of the user used by Datadog for contacting them if needed</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string UserInfoEmailAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).UserInfoEmailAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).UserInfoEmailAddress = value ?? null; }

        /// <summary>Name of the user</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string UserInfoName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).UserInfoName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).UserInfoName = value ?? null; }

        /// <summary>Phone number of the user used by Datadog for contacting them if needed</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string UserInfoPhoneNumber { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).UserInfoPhoneNumber; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal)Property).UserInfoPhoneNumber = value ?? null; }

        /// <summary>Creates an new <see cref="DatadogMonitorResource" /> instance.</summary>
        public DatadogMonitorResource()
        {

        }
    }
    public partial interface IDatadogMonitorResource :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.IJsonSerializable
    {
        /// <summary>Api key associated to the Datadog organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Api key associated to the Datadog organization.",
        SerializedName = @"apiKey",
        PossibleTypes = new [] { typeof(string) })]
        string DatadogOrganizationPropertyApiKey { get; set; }
        /// <summary>Application key associated to the Datadog organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Application key associated to the Datadog organization.",
        SerializedName = @"applicationKey",
        PossibleTypes = new [] { typeof(string) })]
        string DatadogOrganizationPropertyApplicationKey { get; set; }
        /// <summary>The Id of the Enterprise App used for Single sign on.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Id of the Enterprise App used for Single sign on.",
        SerializedName = @"enterpriseAppId",
        PossibleTypes = new [] { typeof(string) })]
        string DatadogOrganizationPropertyEnterpriseAppId { get; set; }
        /// <summary>Id of the Datadog organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Id of the Datadog organization.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string DatadogOrganizationPropertyId { get;  }
        /// <summary>The auth code used to linking to an existing datadog organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The auth code used to linking to an existing datadog organization.",
        SerializedName = @"linkingAuthCode",
        PossibleTypes = new [] { typeof(string) })]
        string DatadogOrganizationPropertyLinkingAuthCode { get; set; }
        /// <summary>
        /// The client_id from an existing in exchange for an auth token to link organization.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The client_id from an existing in exchange for an auth token to link organization.",
        SerializedName = @"linkingClientId",
        PossibleTypes = new [] { typeof(string) })]
        string DatadogOrganizationPropertyLinkingClientId { get; set; }
        /// <summary>Name of the Datadog organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the Datadog organization.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string DatadogOrganizationPropertyName { get;  }
        /// <summary>The redirect uri for linking.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The redirect uri for linking.",
        SerializedName = @"redirectUri",
        PossibleTypes = new [] { typeof(string) })]
        string DatadogOrganizationPropertyRedirectUri { get; set; }
        /// <summary>ARM id of the monitor resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"ARM id of the monitor resource.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>The identity ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The identity ID.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityPrincipalId { get;  }
        /// <summary>The tenant ID of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The tenant ID of resource.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityTenantId { get;  }
        /// <summary>Identity type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Identity type",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ManagedIdentityTypes) })]
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ManagedIdentityTypes? IdentityType { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"liftrResourceCategory",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.LiftrResourceCategories) })]
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.LiftrResourceCategories? LiftrResourceCategory { get;  }
        /// <summary>The priority of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The priority of the resource.",
        SerializedName = @"liftrResourcePreference",
        PossibleTypes = new [] { typeof(int) })]
        int? LiftrResourcePreference { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get; set; }
        /// <summary>
        /// Flag specifying the Marketplace Subscription Status of the resource. If payment is not made in time, the resource will
        /// go in Suspended state.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Flag specifying the Marketplace Subscription Status of the resource. If payment is not made in time, the resource will go in Suspended state.",
        SerializedName = @"marketplaceSubscriptionStatus",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MarketplaceSubscriptionStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MarketplaceSubscriptionStatus? MarketplaceSubscriptionStatus { get;  }
        /// <summary>Flag specifying if the resource monitoring is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Flag specifying if the resource monitoring is enabled or disabled.",
        SerializedName = @"monitoringStatus",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MonitoringStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MonitoringStatus? MonitoringStatus { get; set; }
        /// <summary>Name of the monitor resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the monitor resource.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState? ProvisioningState { get;  }
        /// <summary>Name of the SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the SKU.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string SkuName { get; set; }
        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The timestamp of resource creation (UTC).",
        SerializedName = @"createdAt",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? SystemDataCreatedAt { get; set; }
        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The identity that created the resource.",
        SerializedName = @"createdBy",
        PossibleTypes = new [] { typeof(string) })]
        string SystemDataCreatedBy { get; set; }
        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of identity that created the resource.",
        SerializedName = @"createdByType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.CreatedByType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.CreatedByType? SystemDataCreatedByType { get; set; }
        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The timestamp of resource last modification (UTC)",
        SerializedName = @"lastModifiedAt",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? SystemDataLastModifiedAt { get; set; }
        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The identity that last modified the resource.",
        SerializedName = @"lastModifiedBy",
        PossibleTypes = new [] { typeof(string) })]
        string SystemDataLastModifiedBy { get; set; }
        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of identity that last modified the resource.",
        SerializedName = @"lastModifiedByType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.CreatedByType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.CreatedByType? SystemDataLastModifiedByType { get; set; }
        /// <summary>Dictionary of <string></summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Dictionary of <string>",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceTags Tag { get; set; }
        /// <summary>The type of the monitor resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of the monitor resource.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }
        /// <summary>Email of the user used by Datadog for contacting them if needed</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Email of the user used by Datadog for contacting them if needed",
        SerializedName = @"emailAddress",
        PossibleTypes = new [] { typeof(string) })]
        string UserInfoEmailAddress { get; set; }
        /// <summary>Name of the user</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the user",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string UserInfoName { get; set; }
        /// <summary>Phone number of the user used by Datadog for contacting them if needed</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Phone number of the user used by Datadog for contacting them if needed",
        SerializedName = @"phoneNumber",
        PossibleTypes = new [] { typeof(string) })]
        string UserInfoPhoneNumber { get; set; }

    }
    internal partial interface IDatadogMonitorResourceInternal

    {
        /// <summary>Datadog organization properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationProperties DatadogOrganizationProperty { get; set; }
        /// <summary>Api key associated to the Datadog organization.</summary>
        string DatadogOrganizationPropertyApiKey { get; set; }
        /// <summary>Application key associated to the Datadog organization.</summary>
        string DatadogOrganizationPropertyApplicationKey { get; set; }
        /// <summary>The Id of the Enterprise App used for Single sign on.</summary>
        string DatadogOrganizationPropertyEnterpriseAppId { get; set; }
        /// <summary>Id of the Datadog organization.</summary>
        string DatadogOrganizationPropertyId { get; set; }
        /// <summary>The auth code used to linking to an existing datadog organization.</summary>
        string DatadogOrganizationPropertyLinkingAuthCode { get; set; }
        /// <summary>
        /// The client_id from an existing in exchange for an auth token to link organization.
        /// </summary>
        string DatadogOrganizationPropertyLinkingClientId { get; set; }
        /// <summary>Name of the Datadog organization.</summary>
        string DatadogOrganizationPropertyName { get; set; }
        /// <summary>The redirect uri for linking.</summary>
        string DatadogOrganizationPropertyRedirectUri { get; set; }
        /// <summary>ARM id of the monitor resource.</summary>
        string Id { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IIdentityProperties Identity { get; set; }
        /// <summary>The identity ID.</summary>
        string IdentityPrincipalId { get; set; }
        /// <summary>The tenant ID of resource.</summary>
        string IdentityTenantId { get; set; }
        /// <summary>Identity type</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ManagedIdentityTypes? IdentityType { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.LiftrResourceCategories? LiftrResourceCategory { get; set; }
        /// <summary>The priority of the resource.</summary>
        int? LiftrResourcePreference { get; set; }

        string Location { get; set; }
        /// <summary>
        /// Flag specifying the Marketplace Subscription Status of the resource. If payment is not made in time, the resource will
        /// go in Suspended state.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MarketplaceSubscriptionStatus? MarketplaceSubscriptionStatus { get; set; }
        /// <summary>Flag specifying if the resource monitoring is enabled or disabled.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MonitoringStatus? MonitoringStatus { get; set; }
        /// <summary>Name of the monitor resource.</summary>
        string Name { get; set; }
        /// <summary>Properties specific to the monitor resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorProperties Property { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState? ProvisioningState { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IResourceSku Sku { get; set; }
        /// <summary>Name of the SKU.</summary>
        string SkuName { get; set; }
        /// <summary>Metadata pertaining to creation and last modification of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.ISystemData SystemData { get; set; }
        /// <summary>The timestamp of resource creation (UTC).</summary>
        global::System.DateTime? SystemDataCreatedAt { get; set; }
        /// <summary>The identity that created the resource.</summary>
        string SystemDataCreatedBy { get; set; }
        /// <summary>The type of identity that created the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.CreatedByType? SystemDataCreatedByType { get; set; }
        /// <summary>The timestamp of resource last modification (UTC)</summary>
        global::System.DateTime? SystemDataLastModifiedAt { get; set; }
        /// <summary>The identity that last modified the resource.</summary>
        string SystemDataLastModifiedBy { get; set; }
        /// <summary>The type of identity that last modified the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.CreatedByType? SystemDataLastModifiedByType { get; set; }
        /// <summary>Dictionary of <string></summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceTags Tag { get; set; }
        /// <summary>The type of the monitor resource.</summary>
        string Type { get; set; }
        /// <summary>User info</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IUserInfo UserInfo { get; set; }
        /// <summary>Email of the user used by Datadog for contacting them if needed</summary>
        string UserInfoEmailAddress { get; set; }
        /// <summary>Name of the user</summary>
        string UserInfoName { get; set; }
        /// <summary>Phone number of the user used by Datadog for contacting them if needed</summary>
        string UserInfoPhoneNumber { get; set; }

    }
}