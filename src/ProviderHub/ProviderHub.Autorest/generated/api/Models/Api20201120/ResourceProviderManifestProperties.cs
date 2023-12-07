namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class ResourceProviderManifestProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestProperties,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Capability" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderCapabilities[] _capability;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderCapabilities[] Capability { get => this._capability; set => this._capability = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public string FeatureRuleRequiredFeaturesPolicy { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IFeaturesRuleInternal)FeaturesRule).RequiredFeaturesPolicy; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IFeaturesRuleInternal)FeaturesRule).RequiredFeaturesPolicy = value ?? null; }

        /// <summary>Backing field for <see cref="FeaturesRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IFeaturesRule _featuresRule;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IFeaturesRule FeaturesRule { get => (this._featuresRule = this._featuresRule ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.FeaturesRule()); set => this._featuresRule = value; }

        /// <summary>Backing field for <see cref="Management" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManagement _management;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManagement Management { get => (this._management = this._management ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceProviderManagement()); set => this._management = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public string ManagementIncidentContactEmail { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManagementInternal)Management).IncidentContactEmail; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManagementInternal)Management).IncidentContactEmail = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public string ManagementIncidentRoutingService { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManagementInternal)Management).IncidentRoutingService; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManagementInternal)Management).IncidentRoutingService = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public string ManagementIncidentRoutingTeam { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManagementInternal)Management).IncidentRoutingTeam; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManagementInternal)Management).IncidentRoutingTeam = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public string[] ManagementManifestOwner { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManagementInternal)Management).ManifestOwner; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManagementInternal)Management).ManifestOwner = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public string ManagementResourceAccessPolicy { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManagementInternal)Management).ResourceAccessPolicy; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManagementInternal)Management).ResourceAccessPolicy = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny[] ManagementResourceAccessRole { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManagementInternal)Management).ResourceAccessRole; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManagementInternal)Management).ResourceAccessRole = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public string[] ManagementSchemaOwner { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManagementInternal)Management).SchemaOwner; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManagementInternal)Management).SchemaOwner = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IServiceTreeInfo[] ManagementServiceTreeInfo { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManagementInternal)Management).ServiceTreeInfo; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManagementInternal)Management).ServiceTreeInfo = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="Metadata" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny _metadata;

        /// <summary>Any object</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny Metadata { get => (this._metadata = this._metadata ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Any()); set => this._metadata = value; }

        /// <summary>Internal Acessors for FeaturesRule</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IFeaturesRule Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestPropertiesInternal.FeaturesRule { get => (this._featuresRule = this._featuresRule ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.FeaturesRule()); set { {_featuresRule = value;} } }

        /// <summary>Internal Acessors for Management</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManagement Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestPropertiesInternal.Management { get => (this._management = this._management ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceProviderManagement()); set { {_management = value;} } }

        /// <summary>Internal Acessors for ProviderAuthentication</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthentication Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestPropertiesInternal.ProviderAuthentication { get => (this._providerAuthentication = this._providerAuthentication ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceProviderAuthentication()); set { {_providerAuthentication = value;} } }

        /// <summary>Internal Acessors for RequestHeaderOption</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRequestHeaderOptions Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestPropertiesInternal.RequestHeaderOption { get => (this._requestHeaderOption = this._requestHeaderOption ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.RequestHeaderOptions()); set { {_requestHeaderOption = value;} } }

        /// <summary>Internal Acessors for TemplateDeploymentOption</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentOptions Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestPropertiesInternal.TemplateDeploymentOption { get => (this._templateDeploymentOption = this._templateDeploymentOption ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.TemplateDeploymentOptions()); set { {_templateDeploymentOption = value;} } }

        /// <summary>Backing field for <see cref="Namespace" /> property.</summary>
        private string _namespace;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string Namespace { get => this._namespace; set => this._namespace = value; }

        /// <summary>Backing field for <see cref="ProviderAuthentication" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthentication _providerAuthentication;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthentication ProviderAuthentication { get => (this._providerAuthentication = this._providerAuthentication ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceProviderAuthentication()); set => this._providerAuthentication = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public string[] ProviderAuthenticationAllowedAudience { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthenticationInternal)ProviderAuthentication).AllowedAudience; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthenticationInternal)ProviderAuthentication).AllowedAudience = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="ProviderAuthorization" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthorization[] _providerAuthorization;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthorization[] ProviderAuthorization { get => this._providerAuthorization; set => this._providerAuthorization = value; }

        /// <summary>Backing field for <see cref="ProviderType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ResourceProviderType? _providerType;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ResourceProviderType? ProviderType { get => this._providerType; set => this._providerType = value; }

        /// <summary>Backing field for <see cref="ProviderVersion" /> property.</summary>
        private string _providerVersion;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string ProviderVersion { get => this._providerVersion; set => this._providerVersion = value; }

        /// <summary>Backing field for <see cref="RequestHeaderOption" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRequestHeaderOptions _requestHeaderOption;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRequestHeaderOptions RequestHeaderOption { get => (this._requestHeaderOption = this._requestHeaderOption ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.RequestHeaderOptions()); set => this._requestHeaderOption = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.OptInHeaderType? RequestHeaderOptionOptInHeader { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRequestHeaderOptionsInternal)RequestHeaderOption).OptInHeader; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRequestHeaderOptionsInternal)RequestHeaderOption).OptInHeader = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.OptInHeaderType)""); }

        /// <summary>Backing field for <see cref="RequiredFeature" /> property.</summary>
        private string[] _requiredFeature;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string[] RequiredFeature { get => this._requiredFeature; set => this._requiredFeature = value; }

        /// <summary>Backing field for <see cref="TemplateDeploymentOption" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentOptions _templateDeploymentOption;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentOptions TemplateDeploymentOption { get => (this._templateDeploymentOption = this._templateDeploymentOption ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.TemplateDeploymentOptions()); set => this._templateDeploymentOption = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.PreflightOption[] TemplateDeploymentOptionPreflightOption { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentOptionsInternal)TemplateDeploymentOption).PreflightOption; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentOptionsInternal)TemplateDeploymentOption).PreflightOption = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public bool? TemplateDeploymentOptionPreflightSupported { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentOptionsInternal)TemplateDeploymentOption).PreflightSupported; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentOptionsInternal)TemplateDeploymentOption).PreflightSupported = value ?? default(bool); }

        /// <summary>Creates an new <see cref="ResourceProviderManifestProperties" /> instance.</summary>
        public ResourceProviderManifestProperties()
        {

        }
    }
    public partial interface IResourceProviderManifestProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"capabilities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderCapabilities) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderCapabilities[] Capability { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"requiredFeaturesPolicy",
        PossibleTypes = new [] { typeof(string) })]
        string FeatureRuleRequiredFeaturesPolicy { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"incidentContactEmail",
        PossibleTypes = new [] { typeof(string) })]
        string ManagementIncidentContactEmail { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"incidentRoutingService",
        PossibleTypes = new [] { typeof(string) })]
        string ManagementIncidentRoutingService { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"incidentRoutingTeam",
        PossibleTypes = new [] { typeof(string) })]
        string ManagementIncidentRoutingTeam { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"manifestOwners",
        PossibleTypes = new [] { typeof(string) })]
        string[] ManagementManifestOwner { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"resourceAccessPolicy",
        PossibleTypes = new [] { typeof(string) })]
        string ManagementResourceAccessPolicy { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"resourceAccessRoles",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny[] ManagementResourceAccessRole { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"schemaOwners",
        PossibleTypes = new [] { typeof(string) })]
        string[] ManagementSchemaOwner { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"serviceTreeInfos",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IServiceTreeInfo) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IServiceTreeInfo[] ManagementServiceTreeInfo { get; set; }
        /// <summary>Any object</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Any object",
        SerializedName = @"metadata",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny Metadata { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"namespace",
        PossibleTypes = new [] { typeof(string) })]
        string Namespace { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"allowedAudiences",
        PossibleTypes = new [] { typeof(string) })]
        string[] ProviderAuthenticationAllowedAudience { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"providerAuthorizations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthorization) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthorization[] ProviderAuthorization { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"providerType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ResourceProviderType) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ResourceProviderType? ProviderType { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"providerVersion",
        PossibleTypes = new [] { typeof(string) })]
        string ProviderVersion { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"optInHeaders",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.OptInHeaderType) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.OptInHeaderType? RequestHeaderOptionOptInHeader { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"requiredFeatures",
        PossibleTypes = new [] { typeof(string) })]
        string[] RequiredFeature { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"preflightOptions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.PreflightOption) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.PreflightOption[] TemplateDeploymentOptionPreflightOption { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"preflightSupported",
        PossibleTypes = new [] { typeof(bool) })]
        bool? TemplateDeploymentOptionPreflightSupported { get; set; }

    }
    internal partial interface IResourceProviderManifestPropertiesInternal

    {
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderCapabilities[] Capability { get; set; }

        string FeatureRuleRequiredFeaturesPolicy { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IFeaturesRule FeaturesRule { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManagement Management { get; set; }

        string ManagementIncidentContactEmail { get; set; }

        string ManagementIncidentRoutingService { get; set; }

        string ManagementIncidentRoutingTeam { get; set; }

        string[] ManagementManifestOwner { get; set; }

        string ManagementResourceAccessPolicy { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny[] ManagementResourceAccessRole { get; set; }

        string[] ManagementSchemaOwner { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IServiceTreeInfo[] ManagementServiceTreeInfo { get; set; }
        /// <summary>Any object</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny Metadata { get; set; }

        string Namespace { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthentication ProviderAuthentication { get; set; }

        string[] ProviderAuthenticationAllowedAudience { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthorization[] ProviderAuthorization { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ResourceProviderType? ProviderType { get; set; }

        string ProviderVersion { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRequestHeaderOptions RequestHeaderOption { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.OptInHeaderType? RequestHeaderOptionOptInHeader { get; set; }

        string[] RequiredFeature { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentOptions TemplateDeploymentOption { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.PreflightOption[] TemplateDeploymentOptionPreflightOption { get; set; }

        bool? TemplateDeploymentOptionPreflightSupported { get; set; }

    }
}