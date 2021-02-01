namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Site REST Resource.</summary>
    public partial class VMwareSite :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSite,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal
    {

        /// <summary>ID of the agent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string AgentDetailId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal)Property).AgentDetailId; }

        /// <summary>Key vault ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string AgentDetailKeyVaultId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal)Property).AgentDetailKeyVaultId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal)Property).AgentDetailKeyVaultId = value ?? null; }

        /// <summary>Key vault URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string AgentDetailKeyVaultUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal)Property).AgentDetailKeyVaultUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal)Property).AgentDetailKeyVaultUri = value ?? null; }

        /// <summary>Last heartbeat time of the agent in UTC.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public global::System.DateTime? AgentDetailLastHeartBeatUtc { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal)Property).AgentDetailLastHeartBeatUtc; }

        /// <summary>Version of the agent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string AgentDetailVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal)Property).AgentDetailVersion; }

        /// <summary>Appliance Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ApplianceName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal)Property).ApplianceName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal)Property).ApplianceName = value ?? null; }

        /// <summary>ARM ID of migration hub solution for SDS.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string DiscoverySolutionId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal)Property).DiscoverySolutionId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal)Property).DiscoverySolutionId = value ?? null; }

        /// <summary>Backing field for <see cref="ETag" /> property.</summary>
        private string _eTag;

        /// <summary>eTag for concurrency control.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ETag { get => this._eTag; set => this._eTag = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        /// <summary>Azure location in which Sites is created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Location { get => this._location; set => this._location = value; }

        /// <summary>Internal Acessors for AgentDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteAgentProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal.AgentDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal)Property).AgentDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal)Property).AgentDetail = value; }

        /// <summary>Internal Acessors for AgentDetailId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal.AgentDetailId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal)Property).AgentDetailId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal)Property).AgentDetailId = value; }

        /// <summary>Internal Acessors for AgentDetailLastHeartBeatUtc</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal.AgentDetailLastHeartBeatUtc { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal)Property).AgentDetailLastHeartBeatUtc; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal)Property).AgentDetailLastHeartBeatUtc = value; }

        /// <summary>Internal Acessors for AgentDetailVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal.AgentDetailVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal)Property).AgentDetailVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal)Property).AgentDetailVersion = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.SiteProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ServiceEndpoint</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal.ServiceEndpoint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal)Property).ServiceEndpoint; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal)Property).ServiceEndpoint = value; }

        /// <summary>Internal Acessors for ServicePrincipalIdentityDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteSpnProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal.ServicePrincipalIdentityDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal)Property).ServicePrincipalIdentityDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal)Property).ServicePrincipalIdentityDetail = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the VMware site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteProperties _property;

        /// <summary>Nested properties of VMWare site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.SiteProperties()); set => this._property = value; }

        /// <summary>Service endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ServiceEndpoint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal)Property).ServiceEndpoint; }

        /// <summary>
        /// AAD Authority URL which was used to request the token for the service principal.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ServicePrincipalIdentityDetailAadAuthority { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal)Property).ServicePrincipalIdentityDetailAadAuthority; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal)Property).ServicePrincipalIdentityDetailAadAuthority = value ?? null; }

        /// <summary>
        /// Application/client Id for the service principal with which the on-premise management/data plane components would communicate
        /// with our Azure services.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ServicePrincipalIdentityDetailApplicationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal)Property).ServicePrincipalIdentityDetailApplicationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal)Property).ServicePrincipalIdentityDetailApplicationId = value ?? null; }

        /// <summary>Intended audience for the service principal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ServicePrincipalIdentityDetailAudience { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal)Property).ServicePrincipalIdentityDetailAudience; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal)Property).ServicePrincipalIdentityDetailAudience = value ?? null; }

        /// <summary>
        /// Object Id of the service principal with which the on-premise management/data plane components would communicate with our
        /// Azure services.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ServicePrincipalIdentityDetailObjectId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal)Property).ServicePrincipalIdentityDetailObjectId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal)Property).ServicePrincipalIdentityDetailObjectId = value ?? null; }

        /// <summary>Raw certificate data for building certificate expiry flows.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ServicePrincipalIdentityDetailRawCertData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal)Property).ServicePrincipalIdentityDetailRawCertData; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal)Property).ServicePrincipalIdentityDetailRawCertData = value ?? null; }

        /// <summary>
        /// Tenant Id for the service principal with which the on-premise management/data plane components would communicate with
        /// our Azure services.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ServicePrincipalIdentityDetailTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal)Property).ServicePrincipalIdentityDetailTenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal)Property).ServicePrincipalIdentityDetailTenantId = value ?? null; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteTags _tag;

        /// <summary>Dictionary of <string></summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.VMwareSiteTags()); set => this._tag = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Type of resource. Type = Microsoft.OffAzure/VMWareSites.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>Creates an new <see cref="VMwareSite" /> instance.</summary>
        public VMwareSite()
        {

        }
    }
    /// Site REST Resource.
    public partial interface IVMwareSite :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>ID of the agent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"ID of the agent.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string AgentDetailId { get;  }
        /// <summary>Key vault ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Key vault ARM Id.",
        SerializedName = @"keyVaultId",
        PossibleTypes = new [] { typeof(string) })]
        string AgentDetailKeyVaultId { get; set; }
        /// <summary>Key vault URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Key vault URI.",
        SerializedName = @"keyVaultUri",
        PossibleTypes = new [] { typeof(string) })]
        string AgentDetailKeyVaultUri { get; set; }
        /// <summary>Last heartbeat time of the agent in UTC.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Last heartbeat time of the agent in UTC.",
        SerializedName = @"lastHeartBeatUtc",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? AgentDetailLastHeartBeatUtc { get;  }
        /// <summary>Version of the agent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Version of the agent.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string AgentDetailVersion { get;  }
        /// <summary>Appliance Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Appliance Name.",
        SerializedName = @"applianceName",
        PossibleTypes = new [] { typeof(string) })]
        string ApplianceName { get; set; }
        /// <summary>ARM ID of migration hub solution for SDS.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"ARM ID of migration hub solution for SDS.",
        SerializedName = @"discoverySolutionId",
        PossibleTypes = new [] { typeof(string) })]
        string DiscoverySolutionId { get; set; }
        /// <summary>eTag for concurrency control.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"eTag for concurrency control.",
        SerializedName = @"eTag",
        PossibleTypes = new [] { typeof(string) })]
        string ETag { get; set; }
        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource Id.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>Azure location in which Sites is created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Azure location in which Sites is created.",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get; set; }
        /// <summary>Name of the VMware site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the VMware site.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Service endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Service endpoint.",
        SerializedName = @"serviceEndpoint",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceEndpoint { get;  }
        /// <summary>
        /// AAD Authority URL which was used to request the token for the service principal.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"AAD Authority URL which was used to request the token for the service principal.",
        SerializedName = @"aadAuthority",
        PossibleTypes = new [] { typeof(string) })]
        string ServicePrincipalIdentityDetailAadAuthority { get; set; }
        /// <summary>
        /// Application/client Id for the service principal with which the on-premise management/data plane components would communicate
        /// with our Azure services.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Application/client Id for the service principal with which the on-premise management/data plane components would communicate with our Azure services.",
        SerializedName = @"applicationId",
        PossibleTypes = new [] { typeof(string) })]
        string ServicePrincipalIdentityDetailApplicationId { get; set; }
        /// <summary>Intended audience for the service principal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Intended audience for the service principal.",
        SerializedName = @"audience",
        PossibleTypes = new [] { typeof(string) })]
        string ServicePrincipalIdentityDetailAudience { get; set; }
        /// <summary>
        /// Object Id of the service principal with which the on-premise management/data plane components would communicate with our
        /// Azure services.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Object Id of the service principal with which the on-premise management/data plane components would communicate with our Azure services.",
        SerializedName = @"objectId",
        PossibleTypes = new [] { typeof(string) })]
        string ServicePrincipalIdentityDetailObjectId { get; set; }
        /// <summary>Raw certificate data for building certificate expiry flows.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Raw certificate data for building certificate expiry flows.",
        SerializedName = @"rawCertData",
        PossibleTypes = new [] { typeof(string) })]
        string ServicePrincipalIdentityDetailRawCertData { get; set; }
        /// <summary>
        /// Tenant Id for the service principal with which the on-premise management/data plane components would communicate with
        /// our Azure services.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Tenant Id for the service principal with which the on-premise management/data plane components would communicate with our Azure services.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string ServicePrincipalIdentityDetailTenantId { get; set; }
        /// <summary>Dictionary of <string></summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Dictionary of <string>",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteTags Tag { get; set; }
        /// <summary>Type of resource. Type = Microsoft.OffAzure/VMWareSites.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Type of resource. Type = Microsoft.OffAzure/VMWareSites.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }

    }
    /// Site REST Resource.
    internal partial interface IVMwareSiteInternal

    {
        /// <summary>On-premises agent details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteAgentProperties AgentDetail { get; set; }
        /// <summary>ID of the agent.</summary>
        string AgentDetailId { get; set; }
        /// <summary>Key vault ARM Id.</summary>
        string AgentDetailKeyVaultId { get; set; }
        /// <summary>Key vault URI.</summary>
        string AgentDetailKeyVaultUri { get; set; }
        /// <summary>Last heartbeat time of the agent in UTC.</summary>
        global::System.DateTime? AgentDetailLastHeartBeatUtc { get; set; }
        /// <summary>Version of the agent.</summary>
        string AgentDetailVersion { get; set; }
        /// <summary>Appliance Name.</summary>
        string ApplianceName { get; set; }
        /// <summary>ARM ID of migration hub solution for SDS.</summary>
        string DiscoverySolutionId { get; set; }
        /// <summary>eTag for concurrency control.</summary>
        string ETag { get; set; }
        /// <summary>Resource Id.</summary>
        string Id { get; set; }
        /// <summary>Azure location in which Sites is created.</summary>
        string Location { get; set; }
        /// <summary>Name of the VMware site.</summary>
        string Name { get; set; }
        /// <summary>Nested properties of VMWare site.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteProperties Property { get; set; }
        /// <summary>Service endpoint.</summary>
        string ServiceEndpoint { get; set; }
        /// <summary>
        /// Service principal identity details used by agent for communication to the service.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteSpnProperties ServicePrincipalIdentityDetail { get; set; }
        /// <summary>
        /// AAD Authority URL which was used to request the token for the service principal.
        /// </summary>
        string ServicePrincipalIdentityDetailAadAuthority { get; set; }
        /// <summary>
        /// Application/client Id for the service principal with which the on-premise management/data plane components would communicate
        /// with our Azure services.
        /// </summary>
        string ServicePrincipalIdentityDetailApplicationId { get; set; }
        /// <summary>Intended audience for the service principal.</summary>
        string ServicePrincipalIdentityDetailAudience { get; set; }
        /// <summary>
        /// Object Id of the service principal with which the on-premise management/data plane components would communicate with our
        /// Azure services.
        /// </summary>
        string ServicePrincipalIdentityDetailObjectId { get; set; }
        /// <summary>Raw certificate data for building certificate expiry flows.</summary>
        string ServicePrincipalIdentityDetailRawCertData { get; set; }
        /// <summary>
        /// Tenant Id for the service principal with which the on-premise management/data plane components would communicate with
        /// our Azure services.
        /// </summary>
        string ServicePrincipalIdentityDetailTenantId { get; set; }
        /// <summary>Dictionary of <string></summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteTags Tag { get; set; }
        /// <summary>Type of resource. Type = Microsoft.OffAzure/VMWareSites.</summary>
        string Type { get; set; }

    }
}