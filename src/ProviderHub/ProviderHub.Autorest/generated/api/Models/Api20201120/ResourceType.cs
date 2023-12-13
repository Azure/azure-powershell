namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class ResourceType :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceType,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeInternal
    {

        /// <summary>Backing field for <see cref="AllowedUnauthorizedAction" /> property.</summary>
        private string[] _allowedUnauthorizedAction;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string[] AllowedUnauthorizedAction { get => this._allowedUnauthorizedAction; set => this._allowedUnauthorizedAction = value; }

        /// <summary>Backing field for <see cref="AuthorizationActionMapping" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IAuthorizationActionMapping[] _authorizationActionMapping;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IAuthorizationActionMapping[] AuthorizationActionMapping { get => this._authorizationActionMapping; set => this._authorizationActionMapping = value; }

        /// <summary>Backing field for <see cref="DefaultApiVersion" /> property.</summary>
        private string _defaultApiVersion;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string DefaultApiVersion { get => this._defaultApiVersion; set => this._defaultApiVersion = value; }

        /// <summary>Backing field for <see cref="DisallowedActionVerb" /> property.</summary>
        private string[] _disallowedActionVerb;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string[] DisallowedActionVerb { get => this._disallowedActionVerb; set => this._disallowedActionVerb = value; }

        /// <summary>Backing field for <see cref="Endpoint" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderEndpoint[] _endpoint;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderEndpoint[] Endpoint { get => this._endpoint; set => this._endpoint = value; }

        /// <summary>Backing field for <see cref="ExtendedLocation" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtendedLocationOptions[] _extendedLocation;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtendedLocationOptions[] ExtendedLocation { get => this._extendedLocation; set => this._extendedLocation = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public string FeatureRuleRequiredFeaturesPolicy { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IFeaturesRuleInternal)FeaturesRule).RequiredFeaturesPolicy; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IFeaturesRuleInternal)FeaturesRule).RequiredFeaturesPolicy = value ?? null; }

        /// <summary>Backing field for <see cref="FeaturesRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IFeaturesRule _featuresRule;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IFeaturesRule FeaturesRule { get => (this._featuresRule = this._featuresRule ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.FeaturesRule()); set => this._featuresRule = value; }

        /// <summary>Backing field for <see cref="IdentityManagement" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IIdentityManagement _identityManagement;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IIdentityManagement IdentityManagement { get => (this._identityManagement = this._identityManagement ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IdentityManagement()); set => this._identityManagement = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.IdentityManagementTypes? IdentityManagementType { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IIdentityManagementInternal)IdentityManagement).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IIdentityManagementInternal)IdentityManagement).Type = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.IdentityManagementTypes)""); }

        /// <summary>Backing field for <see cref="LinkedAccessCheck" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILinkedAccessCheck[] _linkedAccessCheck;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILinkedAccessCheck[] LinkedAccessCheck { get => this._linkedAccessCheck; set => this._linkedAccessCheck = value; }

        /// <summary>Backing field for <see cref="LinkedOperationRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILinkedOperationRule[] _linkedOperationRule;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILinkedOperationRule[] LinkedOperationRule { get => this._linkedOperationRule; set => this._linkedOperationRule = value; }

        /// <summary>Backing field for <see cref="LoggingRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingRule[] _loggingRule;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingRule[] LoggingRule { get => this._loggingRule; set => this._loggingRule = value; }

        /// <summary>Backing field for <see cref="MarketplaceType" /> property.</summary>
        private string _marketplaceType;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string MarketplaceType { get => this._marketplaceType; set => this._marketplaceType = value; }

        /// <summary>Backing field for <see cref="Metadata" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny _metadata;

        /// <summary>Any object</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny Metadata { get => (this._metadata = this._metadata ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Any()); set => this._metadata = value; }

        /// <summary>Internal Acessors for FeaturesRule</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IFeaturesRule Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeInternal.FeaturesRule { get => (this._featuresRule = this._featuresRule ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.FeaturesRule()); set { {_featuresRule = value;} } }

        /// <summary>Internal Acessors for IdentityManagement</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IIdentityManagement Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeInternal.IdentityManagement { get => (this._identityManagement = this._identityManagement ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IdentityManagement()); set { {_identityManagement = value;} } }

        /// <summary>Internal Acessors for RequestHeaderOption</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRequestHeaderOptions Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeInternal.RequestHeaderOption { get => (this._requestHeaderOption = this._requestHeaderOption ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.RequestHeaderOptions()); set { {_requestHeaderOption = value;} } }

        /// <summary>Internal Acessors for TemplateDeploymentPolicy</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentPolicy Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeInternal.TemplateDeploymentPolicy { get => (this._templateDeploymentPolicy = this._templateDeploymentPolicy ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.TemplateDeploymentPolicy()); set { {_templateDeploymentPolicy = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

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

        /// <summary>Backing field for <see cref="ResourceDeletionPolicy" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ManifestResourceDeletionPolicy? _resourceDeletionPolicy;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ManifestResourceDeletionPolicy? ResourceDeletionPolicy { get => this._resourceDeletionPolicy; set => this._resourceDeletionPolicy = value; }

        /// <summary>Backing field for <see cref="ResourceValidation" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ResourceValidation? _resourceValidation;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ResourceValidation? ResourceValidation { get => this._resourceValidation; set => this._resourceValidation = value; }

        /// <summary>Backing field for <see cref="RoutingType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.RoutingType? _routingType;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.RoutingType? RoutingType { get => this._routingType; set => this._routingType = value; }

        /// <summary>Backing field for <see cref="ServiceTreeInfo" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IServiceTreeInfo[] _serviceTreeInfo;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IServiceTreeInfo[] ServiceTreeInfo { get => this._serviceTreeInfo; set => this._serviceTreeInfo = value; }

        /// <summary>Backing field for <see cref="SkuLink" /> property.</summary>
        private string _skuLink;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string SkuLink { get => this._skuLink; set => this._skuLink = value; }

        /// <summary>Backing field for <see cref="SubscriptionStateRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionStateRule[] _subscriptionStateRule;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionStateRule[] SubscriptionStateRule { get => this._subscriptionStateRule; set => this._subscriptionStateRule = value; }

        /// <summary>Backing field for <see cref="TemplateDeploymentPolicy" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentPolicy _templateDeploymentPolicy;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentPolicy TemplateDeploymentPolicy { get => (this._templateDeploymentPolicy = this._templateDeploymentPolicy ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.TemplateDeploymentPolicy()); set => this._templateDeploymentPolicy = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.TemplateDeploymentCapabilities? TemplateDeploymentPolicyCapability { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentPolicyInternal)TemplateDeploymentPolicy).Capability; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentPolicyInternal)TemplateDeploymentPolicy).Capability = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.TemplateDeploymentCapabilities)""); }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.TemplateDeploymentPreflightOptions? TemplateDeploymentPolicyPreflightOption { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentPolicyInternal)TemplateDeploymentPolicy).PreflightOption; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentPolicyInternal)TemplateDeploymentPolicy).PreflightOption = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.TemplateDeploymentPreflightOptions)""); }

        /// <summary>Backing field for <see cref="ThrottlingRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThrottlingRule[] _throttlingRule;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThrottlingRule[] ThrottlingRule { get => this._throttlingRule; set => this._throttlingRule = value; }

        /// <summary>Creates an new <see cref="ResourceType" /> instance.</summary>
        public ResourceType()
        {

        }
    }
    public partial interface IResourceType :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"allowedUnauthorizedActions",
        PossibleTypes = new [] { typeof(string) })]
        string[] AllowedUnauthorizedAction { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"authorizationActionMappings",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IAuthorizationActionMapping) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IAuthorizationActionMapping[] AuthorizationActionMapping { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"defaultApiVersion",
        PossibleTypes = new [] { typeof(string) })]
        string DefaultApiVersion { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"disallowedActionVerbs",
        PossibleTypes = new [] { typeof(string) })]
        string[] DisallowedActionVerb { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"endpoints",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderEndpoint) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderEndpoint[] Endpoint { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"extendedLocations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtendedLocationOptions) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtendedLocationOptions[] ExtendedLocation { get; set; }

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
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.IdentityManagementTypes) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.IdentityManagementTypes? IdentityManagementType { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"linkedAccessChecks",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILinkedAccessCheck) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILinkedAccessCheck[] LinkedAccessCheck { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"linkedOperationRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILinkedOperationRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILinkedOperationRule[] LinkedOperationRule { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"loggingRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingRule[] LoggingRule { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"marketplaceType",
        PossibleTypes = new [] { typeof(string) })]
        string MarketplaceType { get; set; }
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
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

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
        SerializedName = @"resourceDeletionPolicy",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ManifestResourceDeletionPolicy) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ManifestResourceDeletionPolicy? ResourceDeletionPolicy { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"resourceValidation",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ResourceValidation) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ResourceValidation? ResourceValidation { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"routingType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.RoutingType) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.RoutingType? RoutingType { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"serviceTreeInfos",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IServiceTreeInfo) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IServiceTreeInfo[] ServiceTreeInfo { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"skuLink",
        PossibleTypes = new [] { typeof(string) })]
        string SkuLink { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"subscriptionStateRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionStateRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionStateRule[] SubscriptionStateRule { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"capabilities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.TemplateDeploymentCapabilities) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.TemplateDeploymentCapabilities? TemplateDeploymentPolicyCapability { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"preflightOptions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.TemplateDeploymentPreflightOptions) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.TemplateDeploymentPreflightOptions? TemplateDeploymentPolicyPreflightOption { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"throttlingRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThrottlingRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThrottlingRule[] ThrottlingRule { get; set; }

    }
    internal partial interface IResourceTypeInternal

    {
        string[] AllowedUnauthorizedAction { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IAuthorizationActionMapping[] AuthorizationActionMapping { get; set; }

        string DefaultApiVersion { get; set; }

        string[] DisallowedActionVerb { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderEndpoint[] Endpoint { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtendedLocationOptions[] ExtendedLocation { get; set; }

        string FeatureRuleRequiredFeaturesPolicy { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IFeaturesRule FeaturesRule { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IIdentityManagement IdentityManagement { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.IdentityManagementTypes? IdentityManagementType { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILinkedAccessCheck[] LinkedAccessCheck { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILinkedOperationRule[] LinkedOperationRule { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingRule[] LoggingRule { get; set; }

        string MarketplaceType { get; set; }
        /// <summary>Any object</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny Metadata { get; set; }

        string Name { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRequestHeaderOptions RequestHeaderOption { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.OptInHeaderType? RequestHeaderOptionOptInHeader { get; set; }

        string[] RequiredFeature { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ManifestResourceDeletionPolicy? ResourceDeletionPolicy { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ResourceValidation? ResourceValidation { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.RoutingType? RoutingType { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IServiceTreeInfo[] ServiceTreeInfo { get; set; }

        string SkuLink { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionStateRule[] SubscriptionStateRule { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentPolicy TemplateDeploymentPolicy { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.TemplateDeploymentCapabilities? TemplateDeploymentPolicyCapability { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.TemplateDeploymentPreflightOptions? TemplateDeploymentPolicyPreflightOption { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThrottlingRule[] ThrottlingRule { get; set; }

    }
}