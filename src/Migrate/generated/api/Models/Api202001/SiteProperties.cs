namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Class for site properties.</summary>
    public partial class SiteProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal
    {

        /// <summary>Backing field for <see cref="AgentDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteAgentProperties _agentDetail;

        /// <summary>On-premises agent details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteAgentProperties AgentDetail { get => (this._agentDetail = this._agentDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.SiteAgentProperties()); set => this._agentDetail = value; }

        /// <summary>ID of the agent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string AgentDetailId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteAgentPropertiesInternal)AgentDetail).Id; }

        /// <summary>Key vault ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string AgentDetailKeyVaultId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteAgentPropertiesInternal)AgentDetail).KeyVaultId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteAgentPropertiesInternal)AgentDetail).KeyVaultId = value ?? null; }

        /// <summary>Key vault URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string AgentDetailKeyVaultUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteAgentPropertiesInternal)AgentDetail).KeyVaultUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteAgentPropertiesInternal)AgentDetail).KeyVaultUri = value ?? null; }

        /// <summary>Last heartbeat time of the agent in UTC.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public global::System.DateTime? AgentDetailLastHeartBeatUtc { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteAgentPropertiesInternal)AgentDetail).LastHeartBeatUtc; }

        /// <summary>Version of the agent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string AgentDetailVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteAgentPropertiesInternal)AgentDetail).Version; }

        /// <summary>Backing field for <see cref="ApplianceName" /> property.</summary>
        private string _applianceName;

        /// <summary>Appliance Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ApplianceName { get => this._applianceName; set => this._applianceName = value; }

        /// <summary>Backing field for <see cref="DiscoverySolutionId" /> property.</summary>
        private string _discoverySolutionId;

        /// <summary>ARM ID of migration hub solution for SDS.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DiscoverySolutionId { get => this._discoverySolutionId; set => this._discoverySolutionId = value; }

        /// <summary>Internal Acessors for AgentDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteAgentProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal.AgentDetail { get => (this._agentDetail = this._agentDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.SiteAgentProperties()); set { {_agentDetail = value;} } }

        /// <summary>Internal Acessors for AgentDetailId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal.AgentDetailId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteAgentPropertiesInternal)AgentDetail).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteAgentPropertiesInternal)AgentDetail).Id = value; }

        /// <summary>Internal Acessors for AgentDetailLastHeartBeatUtc</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal.AgentDetailLastHeartBeatUtc { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteAgentPropertiesInternal)AgentDetail).LastHeartBeatUtc; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteAgentPropertiesInternal)AgentDetail).LastHeartBeatUtc = value; }

        /// <summary>Internal Acessors for AgentDetailVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal.AgentDetailVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteAgentPropertiesInternal)AgentDetail).Version; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteAgentPropertiesInternal)AgentDetail).Version = value; }

        /// <summary>Internal Acessors for ServiceEndpoint</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal.ServiceEndpoint { get => this._serviceEndpoint; set { {_serviceEndpoint = value;} } }

        /// <summary>Internal Acessors for ServicePrincipalIdentityDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteSpnProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISitePropertiesInternal.ServicePrincipalIdentityDetail { get => (this._servicePrincipalIdentityDetail = this._servicePrincipalIdentityDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.SiteSpnProperties()); set { {_servicePrincipalIdentityDetail = value;} } }

        /// <summary>Backing field for <see cref="ServiceEndpoint" /> property.</summary>
        private string _serviceEndpoint;

        /// <summary>Service endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ServiceEndpoint { get => this._serviceEndpoint; }

        /// <summary>Backing field for <see cref="ServicePrincipalIdentityDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteSpnProperties _servicePrincipalIdentityDetail;

        /// <summary>
        /// Service principal identity details used by agent for communication to the service.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteSpnProperties ServicePrincipalIdentityDetail { get => (this._servicePrincipalIdentityDetail = this._servicePrincipalIdentityDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.SiteSpnProperties()); set => this._servicePrincipalIdentityDetail = value; }

        /// <summary>
        /// AAD Authority URL which was used to request the token for the service principal.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ServicePrincipalIdentityDetailAadAuthority { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteSpnPropertiesInternal)ServicePrincipalIdentityDetail).AadAuthority; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteSpnPropertiesInternal)ServicePrincipalIdentityDetail).AadAuthority = value ?? null; }

        /// <summary>
        /// Application/client Id for the service principal with which the on-premise management/data plane components would communicate
        /// with our Azure services.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ServicePrincipalIdentityDetailApplicationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteSpnPropertiesInternal)ServicePrincipalIdentityDetail).ApplicationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteSpnPropertiesInternal)ServicePrincipalIdentityDetail).ApplicationId = value ?? null; }

        /// <summary>Intended audience for the service principal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ServicePrincipalIdentityDetailAudience { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteSpnPropertiesInternal)ServicePrincipalIdentityDetail).Audience; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteSpnPropertiesInternal)ServicePrincipalIdentityDetail).Audience = value ?? null; }

        /// <summary>
        /// Object Id of the service principal with which the on-premise management/data plane components would communicate with our
        /// Azure services.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ServicePrincipalIdentityDetailObjectId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteSpnPropertiesInternal)ServicePrincipalIdentityDetail).ObjectId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteSpnPropertiesInternal)ServicePrincipalIdentityDetail).ObjectId = value ?? null; }

        /// <summary>Raw certificate data for building certificate expiry flows.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ServicePrincipalIdentityDetailRawCertData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteSpnPropertiesInternal)ServicePrincipalIdentityDetail).RawCertData; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteSpnPropertiesInternal)ServicePrincipalIdentityDetail).RawCertData = value ?? null; }

        /// <summary>
        /// Tenant Id for the service principal with which the on-premise management/data plane components would communicate with
        /// our Azure services.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ServicePrincipalIdentityDetailTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteSpnPropertiesInternal)ServicePrincipalIdentityDetail).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteSpnPropertiesInternal)ServicePrincipalIdentityDetail).TenantId = value ?? null; }

        /// <summary>Creates an new <see cref="SiteProperties" /> instance.</summary>
        public SiteProperties()
        {

        }
    }
    /// Class for site properties.
    public partial interface ISiteProperties :
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

    }
    /// Class for site properties.
    internal partial interface ISitePropertiesInternal

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

    }
}