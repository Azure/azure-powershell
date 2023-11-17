namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class ResourceTypeRegistrationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistrationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistrationPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AllowedUnauthorizedAction" /> property.</summary>
        private string[] _allowedUnauthorizedAction;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string[] AllowedUnauthorizedAction { get => this._allowedUnauthorizedAction; set => this._allowedUnauthorizedAction = value; }

        /// <summary>Backing field for <see cref="AuthorizationActionMapping" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IAuthorizationActionMapping[] _authorizationActionMapping;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IAuthorizationActionMapping[] AuthorizationActionMapping { get => this._authorizationActionMapping; set => this._authorizationActionMapping = value; }

        /// <summary>Backing field for <see cref="CheckNameAvailabilitySpecification" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICheckNameAvailabilitySpecifications _checkNameAvailabilitySpecification;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICheckNameAvailabilitySpecifications CheckNameAvailabilitySpecification { get => (this._checkNameAvailabilitySpecification = this._checkNameAvailabilitySpecification ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.CheckNameAvailabilitySpecifications()); set => this._checkNameAvailabilitySpecification = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public bool? CheckNameAvailabilitySpecificationEnableDefaultValidation { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICheckNameAvailabilitySpecificationsInternal)CheckNameAvailabilitySpecification).EnableDefaultValidation; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICheckNameAvailabilitySpecificationsInternal)CheckNameAvailabilitySpecification).EnableDefaultValidation = value ?? default(bool); }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public string[] CheckNameAvailabilitySpecificationResourceTypesWithCustomValidation { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICheckNameAvailabilitySpecificationsInternal)CheckNameAvailabilitySpecification).ResourceTypesWithCustomValidation; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICheckNameAvailabilitySpecificationsInternal)CheckNameAvailabilitySpecification).ResourceTypesWithCustomValidation = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="DefaultApiVersion" /> property.</summary>
        private string _defaultApiVersion;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string DefaultApiVersion { get => this._defaultApiVersion; set => this._defaultApiVersion = value; }

        /// <summary>Backing field for <see cref="DisallowedActionVerb" /> property.</summary>
        private string[] _disallowedActionVerb;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string[] DisallowedActionVerb { get => this._disallowedActionVerb; set => this._disallowedActionVerb = value; }

        /// <summary>Backing field for <see cref="EnableAsyncOperation" /> property.</summary>
        private bool? _enableAsyncOperation;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public bool? EnableAsyncOperation { get => this._enableAsyncOperation; set => this._enableAsyncOperation = value; }

        /// <summary>Backing field for <see cref="EnableThirdPartyS2S" /> property.</summary>
        private bool? _enableThirdPartyS2S;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public bool? EnableThirdPartyS2S { get => this._enableThirdPartyS2S; set => this._enableThirdPartyS2S = value; }

        /// <summary>Backing field for <see cref="Endpoint" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeEndpoint[] _endpoint;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeEndpoint[] Endpoint { get => this._endpoint; set => this._endpoint = value; }

        /// <summary>Backing field for <see cref="ExtendedLocation" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtendedLocationOptions[] _extendedLocation;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtendedLocationOptions[] ExtendedLocation { get => this._extendedLocation; set => this._extendedLocation = value; }

        /// <summary>Backing field for <see cref="ExtensionOption" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeExtensionOptions _extensionOption;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeExtensionOptions ExtensionOption { get => (this._extensionOption = this._extensionOption ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceTypeExtensionOptions()); set => this._extensionOption = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public string FeatureRuleRequiredFeaturesPolicy { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IFeaturesRuleInternal)FeaturesRule).RequiredFeaturesPolicy; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IFeaturesRuleInternal)FeaturesRule).RequiredFeaturesPolicy = value ?? null; }

        /// <summary>Backing field for <see cref="FeaturesRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IFeaturesRule _featuresRule;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IFeaturesRule FeaturesRule { get => (this._featuresRule = this._featuresRule ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.FeaturesRule()); set => this._featuresRule = value; }

        /// <summary>Backing field for <see cref="IdentityManagement" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IIdentityManagementProperties _identityManagement;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IIdentityManagementProperties IdentityManagement { get => (this._identityManagement = this._identityManagement ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IdentityManagementProperties()); set => this._identityManagement = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public string IdentityManagementApplicationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IIdentityManagementPropertiesInternal)IdentityManagement).ApplicationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IIdentityManagementPropertiesInternal)IdentityManagement).ApplicationId = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.IdentityManagementTypes? IdentityManagementType { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IIdentityManagementPropertiesInternal)IdentityManagement).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IIdentityManagementPropertiesInternal)IdentityManagement).Type = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.IdentityManagementTypes)""); }

        /// <summary>Backing field for <see cref="IsPureProxy" /> property.</summary>
        private bool? _isPureProxy;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public bool? IsPureProxy { get => this._isPureProxy; set => this._isPureProxy = value; }

        /// <summary>Backing field for <see cref="LinkedAccessCheck" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILinkedAccessCheck[] _linkedAccessCheck;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILinkedAccessCheck[] LinkedAccessCheck { get => this._linkedAccessCheck; set => this._linkedAccessCheck = value; }

        /// <summary>Backing field for <see cref="LoggingRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingRule[] _loggingRule;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingRule[] LoggingRule { get => this._loggingRule; set => this._loggingRule = value; }

        /// <summary>Backing field for <see cref="MarketplaceType" /> property.</summary>
        private string _marketplaceType;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string MarketplaceType { get => this._marketplaceType; set => this._marketplaceType = value; }

        /// <summary>Internal Acessors for CheckNameAvailabilitySpecification</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICheckNameAvailabilitySpecifications Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistrationPropertiesInternal.CheckNameAvailabilitySpecification { get => (this._checkNameAvailabilitySpecification = this._checkNameAvailabilitySpecification ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.CheckNameAvailabilitySpecifications()); set { {_checkNameAvailabilitySpecification = value;} } }

        /// <summary>Internal Acessors for ExtensionOption</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeExtensionOptions Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistrationPropertiesInternal.ExtensionOption { get => (this._extensionOption = this._extensionOption ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceTypeExtensionOptions()); set { {_extensionOption = value;} } }

        /// <summary>Internal Acessors for ExtensionOptionResourceCreationBegin</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtensionOptions Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistrationPropertiesInternal.ExtensionOptionResourceCreationBegin { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeExtensionOptionsInternal)ExtensionOption).ResourceCreationBegin; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeExtensionOptionsInternal)ExtensionOption).ResourceCreationBegin = value; }

        /// <summary>Internal Acessors for FeaturesRule</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IFeaturesRule Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistrationPropertiesInternal.FeaturesRule { get => (this._featuresRule = this._featuresRule ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.FeaturesRule()); set { {_featuresRule = value;} } }

        /// <summary>Internal Acessors for IdentityManagement</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IIdentityManagementProperties Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistrationPropertiesInternal.IdentityManagement { get => (this._identityManagement = this._identityManagement ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IdentityManagementProperties()); set { {_identityManagement = value;} } }

        /// <summary>Internal Acessors for RequestHeaderOption</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRequestHeaderOptions Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistrationPropertiesInternal.RequestHeaderOption { get => (this._requestHeaderOption = this._requestHeaderOption ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.RequestHeaderOptions()); set { {_requestHeaderOption = value;} } }

        /// <summary>Internal Acessors for ResourceMovePolicy</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceMovePolicy Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistrationPropertiesInternal.ResourceMovePolicy { get => (this._resourceMovePolicy = this._resourceMovePolicy ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceMovePolicy()); set { {_resourceMovePolicy = value;} } }

        /// <summary>Internal Acessors for SubscriptionLifecycleNotificationSpecification</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionLifecycleNotificationSpecifications Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistrationPropertiesInternal.SubscriptionLifecycleNotificationSpecification { get => (this._subscriptionLifecycleNotificationSpecification = this._subscriptionLifecycleNotificationSpecification ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.SubscriptionLifecycleNotificationSpecifications()); set { {_subscriptionLifecycleNotificationSpecification = value;} } }

        /// <summary>Internal Acessors for TemplateDeploymentOption</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentOptions Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistrationPropertiesInternal.TemplateDeploymentOption { get => (this._templateDeploymentOption = this._templateDeploymentOption ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.TemplateDeploymentOptions()); set { {_templateDeploymentOption = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ProvisioningState? _provisioningState;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Backing field for <see cref="Regionality" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.Regionality? _regionality;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.Regionality? Regionality { get => this._regionality; set => this._regionality = value; }

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

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionOptionType[] ResourceCreationBeginRequest { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeExtensionOptionsInternal)ExtensionOption).ResourceCreationBeginRequest; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeExtensionOptionsInternal)ExtensionOption).ResourceCreationBeginRequest = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionOptionType[] ResourceCreationBeginResponse { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeExtensionOptionsInternal)ExtensionOption).ResourceCreationBeginResponse; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeExtensionOptionsInternal)ExtensionOption).ResourceCreationBeginResponse = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="ResourceDeletionPolicy" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ResourceDeletionPolicy? _resourceDeletionPolicy;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ResourceDeletionPolicy? ResourceDeletionPolicy { get => this._resourceDeletionPolicy; set => this._resourceDeletionPolicy = value; }

        /// <summary>Backing field for <see cref="ResourceMovePolicy" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceMovePolicy _resourceMovePolicy;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceMovePolicy ResourceMovePolicy { get => (this._resourceMovePolicy = this._resourceMovePolicy ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceMovePolicy()); set => this._resourceMovePolicy = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public bool? ResourceMovePolicyCrossResourceGroupMoveEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceMovePolicyInternal)ResourceMovePolicy).CrossResourceGroupMoveEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceMovePolicyInternal)ResourceMovePolicy).CrossResourceGroupMoveEnabled = value ?? default(bool); }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public bool? ResourceMovePolicyCrossSubscriptionMoveEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceMovePolicyInternal)ResourceMovePolicy).CrossSubscriptionMoveEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceMovePolicyInternal)ResourceMovePolicy).CrossSubscriptionMoveEnabled = value ?? default(bool); }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public bool? ResourceMovePolicyValidationRequired { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceMovePolicyInternal)ResourceMovePolicy).ValidationRequired; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceMovePolicyInternal)ResourceMovePolicy).ValidationRequired = value ?? default(bool); }

        /// <summary>Backing field for <see cref="RoutingType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.RoutingType? _routingType;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.RoutingType? RoutingType { get => this._routingType; set => this._routingType = value; }

        /// <summary>Backing field for <see cref="ServiceTreeInfo" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IServiceTreeInfo[] _serviceTreeInfo;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IServiceTreeInfo[] ServiceTreeInfo { get => this._serviceTreeInfo; set => this._serviceTreeInfo = value; }

        /// <summary>
        /// Backing field for <see cref="SubscriptionLifecycleNotificationSpecification" /> property.
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionLifecycleNotificationSpecifications _subscriptionLifecycleNotificationSpecification;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionLifecycleNotificationSpecifications SubscriptionLifecycleNotificationSpecification { get => (this._subscriptionLifecycleNotificationSpecification = this._subscriptionLifecycleNotificationSpecification ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.SubscriptionLifecycleNotificationSpecifications()); set => this._subscriptionLifecycleNotificationSpecification = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public global::System.TimeSpan? SubscriptionLifecycleNotificationSpecificationSoftDeleteTtl { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionLifecycleNotificationSpecificationsInternal)SubscriptionLifecycleNotificationSpecification).SoftDeleteTtl; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionLifecycleNotificationSpecificationsInternal)SubscriptionLifecycleNotificationSpecification).SoftDeleteTtl = value ?? default(global::System.TimeSpan); }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionStateOverrideAction[] SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionLifecycleNotificationSpecificationsInternal)SubscriptionLifecycleNotificationSpecification).SubscriptionStateOverrideAction; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionLifecycleNotificationSpecificationsInternal)SubscriptionLifecycleNotificationSpecification).SubscriptionStateOverrideAction = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="SubscriptionStateRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionStateRule[] _subscriptionStateRule;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionStateRule[] SubscriptionStateRule { get => this._subscriptionStateRule; set => this._subscriptionStateRule = value; }

        /// <summary>Backing field for <see cref="SwaggerSpecification" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISwaggerSpecification[] _swaggerSpecification;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISwaggerSpecification[] SwaggerSpecification { get => this._swaggerSpecification; set => this._swaggerSpecification = value; }

        /// <summary>Backing field for <see cref="TemplateDeploymentOption" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentOptions _templateDeploymentOption;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentOptions TemplateDeploymentOption { get => (this._templateDeploymentOption = this._templateDeploymentOption ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.TemplateDeploymentOptions()); set => this._templateDeploymentOption = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.PreflightOption[] TemplateDeploymentOptionPreflightOption { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentOptionsInternal)TemplateDeploymentOption).PreflightOption; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentOptionsInternal)TemplateDeploymentOption).PreflightOption = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public bool? TemplateDeploymentOptionPreflightSupported { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentOptionsInternal)TemplateDeploymentOption).PreflightSupported; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentOptionsInternal)TemplateDeploymentOption).PreflightSupported = value ?? default(bool); }

        /// <summary>Backing field for <see cref="ThrottlingRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThrottlingRule[] _throttlingRule;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThrottlingRule[] ThrottlingRule { get => this._throttlingRule; set => this._throttlingRule = value; }

        /// <summary>Creates an new <see cref="ResourceTypeRegistrationProperties" /> instance.</summary>
        public ResourceTypeRegistrationProperties()
        {

        }
    }
    public partial interface IResourceTypeRegistrationProperties :
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
        SerializedName = @"enableDefaultValidation",
        PossibleTypes = new [] { typeof(bool) })]
        bool? CheckNameAvailabilitySpecificationEnableDefaultValidation { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"resourceTypesWithCustomValidation",
        PossibleTypes = new [] { typeof(string) })]
        string[] CheckNameAvailabilitySpecificationResourceTypesWithCustomValidation { get; set; }

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
        SerializedName = @"enableAsyncOperation",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableAsyncOperation { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"enableThirdPartyS2S",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableThirdPartyS2S { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"endpoints",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeEndpoint) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeEndpoint[] Endpoint { get; set; }

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
        SerializedName = @"applicationId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityManagementApplicationId { get; set; }

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
        SerializedName = @"isPureProxy",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsPureProxy { get; set; }

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

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ProvisioningState? ProvisioningState { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"regionality",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.Regionality) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.Regionality? Regionality { get; set; }

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
        SerializedName = @"request",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionOptionType) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionOptionType[] ResourceCreationBeginRequest { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"response",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionOptionType) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionOptionType[] ResourceCreationBeginResponse { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"resourceDeletionPolicy",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ResourceDeletionPolicy) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ResourceDeletionPolicy? ResourceDeletionPolicy { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"crossResourceGroupMoveEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ResourceMovePolicyCrossResourceGroupMoveEnabled { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"crossSubscriptionMoveEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ResourceMovePolicyCrossSubscriptionMoveEnabled { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"validationRequired",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ResourceMovePolicyValidationRequired { get; set; }

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
        SerializedName = @"softDeleteTTL",
        PossibleTypes = new [] { typeof(global::System.TimeSpan) })]
        global::System.TimeSpan? SubscriptionLifecycleNotificationSpecificationSoftDeleteTtl { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"subscriptionStateOverrideActions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionStateOverrideAction) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionStateOverrideAction[] SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction { get; set; }

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
        SerializedName = @"swaggerSpecifications",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISwaggerSpecification) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISwaggerSpecification[] SwaggerSpecification { get; set; }

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

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"throttlingRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThrottlingRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThrottlingRule[] ThrottlingRule { get; set; }

    }
    internal partial interface IResourceTypeRegistrationPropertiesInternal

    {
        string[] AllowedUnauthorizedAction { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IAuthorizationActionMapping[] AuthorizationActionMapping { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICheckNameAvailabilitySpecifications CheckNameAvailabilitySpecification { get; set; }

        bool? CheckNameAvailabilitySpecificationEnableDefaultValidation { get; set; }

        string[] CheckNameAvailabilitySpecificationResourceTypesWithCustomValidation { get; set; }

        string DefaultApiVersion { get; set; }

        string[] DisallowedActionVerb { get; set; }

        bool? EnableAsyncOperation { get; set; }

        bool? EnableThirdPartyS2S { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeEndpoint[] Endpoint { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtendedLocationOptions[] ExtendedLocation { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeExtensionOptions ExtensionOption { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtensionOptions ExtensionOptionResourceCreationBegin { get; set; }

        string FeatureRuleRequiredFeaturesPolicy { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IFeaturesRule FeaturesRule { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IIdentityManagementProperties IdentityManagement { get; set; }

        string IdentityManagementApplicationId { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.IdentityManagementTypes? IdentityManagementType { get; set; }

        bool? IsPureProxy { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILinkedAccessCheck[] LinkedAccessCheck { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingRule[] LoggingRule { get; set; }

        string MarketplaceType { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ProvisioningState? ProvisioningState { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.Regionality? Regionality { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRequestHeaderOptions RequestHeaderOption { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.OptInHeaderType? RequestHeaderOptionOptInHeader { get; set; }

        string[] RequiredFeature { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionOptionType[] ResourceCreationBeginRequest { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionOptionType[] ResourceCreationBeginResponse { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ResourceDeletionPolicy? ResourceDeletionPolicy { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceMovePolicy ResourceMovePolicy { get; set; }

        bool? ResourceMovePolicyCrossResourceGroupMoveEnabled { get; set; }

        bool? ResourceMovePolicyCrossSubscriptionMoveEnabled { get; set; }

        bool? ResourceMovePolicyValidationRequired { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.RoutingType? RoutingType { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IServiceTreeInfo[] ServiceTreeInfo { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionLifecycleNotificationSpecifications SubscriptionLifecycleNotificationSpecification { get; set; }

        global::System.TimeSpan? SubscriptionLifecycleNotificationSpecificationSoftDeleteTtl { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionStateOverrideAction[] SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionStateRule[] SubscriptionStateRule { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISwaggerSpecification[] SwaggerSpecification { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITemplateDeploymentOptions TemplateDeploymentOption { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.PreflightOption[] TemplateDeploymentOptionPreflightOption { get; set; }

        bool? TemplateDeploymentOptionPreflightSupported { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThrottlingRule[] ThrottlingRule { get; set; }

    }
}