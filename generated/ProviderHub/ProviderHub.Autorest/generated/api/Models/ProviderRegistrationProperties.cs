// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class ProviderRegistrationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGenerated"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGenerated __providerRegistrationPropertiesAutoGenerated = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ProviderRegistrationPropertiesAutoGenerated();

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderCapabilities> Capability { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).Capability; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).Capability = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public string FeatureRuleRequiredFeaturesPolicy { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).FeatureRuleRequiredFeaturesPolicy; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).FeatureRuleRequiredFeaturesPolicy = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesFeaturesRule FeaturesRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).FeaturesRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).FeaturesRule = value ?? null /* model class */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesManagement Management { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).Management; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).Management = value ?? null /* model class */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public string ManagementIncidentContactEmail { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).ManagementIncidentContactEmail; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).ManagementIncidentContactEmail = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public string ManagementIncidentRoutingService { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).ManagementIncidentRoutingService; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).ManagementIncidentRoutingService = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public string ManagementIncidentRoutingTeam { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).ManagementIncidentRoutingTeam; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).ManagementIncidentRoutingTeam = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public System.Collections.Generic.List<string> ManagementManifestOwner { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).ManagementManifestOwner; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).ManagementManifestOwner = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public string ManagementResourceAccessPolicy { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).ManagementResourceAccessPolicy; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).ManagementResourceAccessPolicy = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny> ManagementResourceAccessRole { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).ManagementResourceAccessRole; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).ManagementResourceAccessRole = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public System.Collections.Generic.List<string> ManagementSchemaOwner { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).ManagementSchemaOwner; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).ManagementSchemaOwner = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IServiceTreeInfo> ManagementServiceTreeInfo { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).ManagementServiceTreeInfo; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).ManagementServiceTreeInfo = value ?? null /* arrayOf */; }

        /// <summary>Anything</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny Metadata { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).Metadata; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).Metadata = value ?? null /* model class */; }

        /// <summary>Internal Acessors for ProviderHubMetadata</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesProviderHubMetadata Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGeneratedInternal.ProviderHubMetadata { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGeneratedInternal)__providerRegistrationPropertiesAutoGenerated).ProviderHubMetadata; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGeneratedInternal)__providerRegistrationPropertiesAutoGenerated).ProviderHubMetadata = value ?? null /* model class */; }

        /// <summary>Internal Acessors for ProviderHubMetadataProviderAuthentication</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubMetadataProviderAuthentication Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGeneratedInternal.ProviderHubMetadataProviderAuthentication { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGeneratedInternal)__providerRegistrationPropertiesAutoGenerated).ProviderHubMetadataProviderAuthentication; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGeneratedInternal)__providerRegistrationPropertiesAutoGenerated).ProviderHubMetadataProviderAuthentication = value ?? null /* model class */; }

        /// <summary>Internal Acessors for ProviderHubMetadataThirdPartyProviderAuthorization</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubMetadataThirdPartyProviderAuthorization Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGeneratedInternal.ProviderHubMetadataThirdPartyProviderAuthorization { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGeneratedInternal)__providerRegistrationPropertiesAutoGenerated).ProviderHubMetadataThirdPartyProviderAuthorization; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGeneratedInternal)__providerRegistrationPropertiesAutoGenerated).ProviderHubMetadataThirdPartyProviderAuthorization = value ?? null /* model class */; }

        /// <summary>Internal Acessors for SubscriptionLifecycleNotificationSpecification</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesSubscriptionLifecycleNotificationSpecifications Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGeneratedInternal.SubscriptionLifecycleNotificationSpecification { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGeneratedInternal)__providerRegistrationPropertiesAutoGenerated).SubscriptionLifecycleNotificationSpecification; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGeneratedInternal)__providerRegistrationPropertiesAutoGenerated).SubscriptionLifecycleNotificationSpecification = value ?? null /* model class */; }

        /// <summary>Internal Acessors for FeaturesRule</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesFeaturesRule Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal.FeaturesRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).FeaturesRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).FeaturesRule = value ?? null /* model class */; }

        /// <summary>Internal Acessors for Management</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesManagement Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal.Management { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).Management; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).Management = value ?? null /* model class */; }

        /// <summary>Internal Acessors for ProviderAuthentication</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesProviderAuthentication Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal.ProviderAuthentication { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).ProviderAuthentication; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).ProviderAuthentication = value ?? null /* model class */; }

        /// <summary>Internal Acessors for RequestHeaderOption</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesRequestHeaderOptions Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal.RequestHeaderOption { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).RequestHeaderOption; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).RequestHeaderOption = value ?? null /* model class */; }

        /// <summary>Internal Acessors for TemplateDeploymentOption</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesTemplateDeploymentOptions Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal.TemplateDeploymentOption { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).TemplateDeploymentOption; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).TemplateDeploymentOption = value ?? null /* model class */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public string Namespace { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).Namespace; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).Namespace = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesProviderAuthentication ProviderAuthentication { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).ProviderAuthentication; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).ProviderAuthentication = value ?? null /* model class */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public System.Collections.Generic.List<string> ProviderAuthenticationAllowedAudience { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).ProviderAuthenticationAllowedAudience; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).ProviderAuthenticationAllowedAudience = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderAuthorization> ProviderAuthorization { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).ProviderAuthorization; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).ProviderAuthorization = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesProviderHubMetadata ProviderHubMetadata { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGeneratedInternal)__providerRegistrationPropertiesAutoGenerated).ProviderHubMetadata; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGeneratedInternal)__providerRegistrationPropertiesAutoGenerated).ProviderHubMetadata = value ?? null /* model class */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubMetadataProviderAuthentication ProviderHubMetadataProviderAuthentication { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGeneratedInternal)__providerRegistrationPropertiesAutoGenerated).ProviderHubMetadataProviderAuthentication; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGeneratedInternal)__providerRegistrationPropertiesAutoGenerated).ProviderHubMetadataProviderAuthentication = value ?? null /* model class */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public System.Collections.Generic.List<string> ProviderHubMetadataProviderAuthenticationAllowedAudience { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGeneratedInternal)__providerRegistrationPropertiesAutoGenerated).ProviderHubMetadataProviderAuthenticationAllowedAudience; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGeneratedInternal)__providerRegistrationPropertiesAutoGenerated).ProviderHubMetadataProviderAuthenticationAllowedAudience = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderAuthorization> ProviderHubMetadataProviderAuthorization { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGeneratedInternal)__providerRegistrationPropertiesAutoGenerated).ProviderHubMetadataProviderAuthorization; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGeneratedInternal)__providerRegistrationPropertiesAutoGenerated).ProviderHubMetadataProviderAuthorization = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubMetadataThirdPartyProviderAuthorization ProviderHubMetadataThirdPartyProviderAuthorization { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGeneratedInternal)__providerRegistrationPropertiesAutoGenerated).ProviderHubMetadataThirdPartyProviderAuthorization; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGeneratedInternal)__providerRegistrationPropertiesAutoGenerated).ProviderHubMetadataThirdPartyProviderAuthorization = value ?? null /* model class */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ILightHouseAuthorization> ProviderHubMetadataThirdPartyProviderAuthorizationAuthorizations { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGeneratedInternal)__providerRegistrationPropertiesAutoGenerated).ProviderHubMetadataThirdPartyProviderAuthorizationAuthorizations; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGeneratedInternal)__providerRegistrationPropertiesAutoGenerated).ProviderHubMetadataThirdPartyProviderAuthorizationAuthorizations = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public string ProviderHubMetadataThirdPartyProviderAuthorizationManagedByTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGeneratedInternal)__providerRegistrationPropertiesAutoGenerated).ProviderHubMetadataThirdPartyProviderAuthorizationManagedByTenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGeneratedInternal)__providerRegistrationPropertiesAutoGenerated).ProviderHubMetadataThirdPartyProviderAuthorizationManagedByTenantId = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public string ProviderType { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).ProviderType; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).ProviderType = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public string ProviderVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).ProviderVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).ProviderVersion = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGeneratedInternal)__providerRegistrationPropertiesAutoGenerated).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGeneratedInternal)__providerRegistrationPropertiesAutoGenerated).ProvisioningState = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesRequestHeaderOptions RequestHeaderOption { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).RequestHeaderOption; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).RequestHeaderOption = value ?? null /* model class */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public string RequestHeaderOptionOptInHeader { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).RequestHeaderOptionOptInHeader; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).RequestHeaderOptionOptInHeader = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public System.Collections.Generic.List<string> RequiredFeature { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).RequiredFeature; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).RequiredFeature = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesSubscriptionLifecycleNotificationSpecifications SubscriptionLifecycleNotificationSpecification { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGeneratedInternal)__providerRegistrationPropertiesAutoGenerated).SubscriptionLifecycleNotificationSpecification; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGeneratedInternal)__providerRegistrationPropertiesAutoGenerated).SubscriptionLifecycleNotificationSpecification = value ?? null /* model class */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public global::System.TimeSpan? SubscriptionLifecycleNotificationSpecificationSoftDeleteTtl { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGeneratedInternal)__providerRegistrationPropertiesAutoGenerated).SubscriptionLifecycleNotificationSpecificationSoftDeleteTtl; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGeneratedInternal)__providerRegistrationPropertiesAutoGenerated).SubscriptionLifecycleNotificationSpecificationSoftDeleteTtl = value ?? default(global::System.TimeSpan); }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISubscriptionStateOverrideAction> SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGeneratedInternal)__providerRegistrationPropertiesAutoGenerated).SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGeneratedInternal)__providerRegistrationPropertiesAutoGenerated).SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesTemplateDeploymentOptions TemplateDeploymentOption { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).TemplateDeploymentOption; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).TemplateDeploymentOption = value ?? null /* model class */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public System.Collections.Generic.List<string> TemplateDeploymentOptionPreflightOption { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).TemplateDeploymentOptionPreflightOption; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).TemplateDeploymentOptionPreflightOption = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public bool? TemplateDeploymentOptionPreflightSupported { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).TemplateDeploymentOptionPreflightSupported; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderManifestPropertiesInternal)__providerRegistrationPropertiesAutoGenerated).TemplateDeploymentOptionPreflightSupported = value ?? default(bool); }

        /// <summary>Creates an new <see cref="ProviderRegistrationProperties" /> instance.</summary>
        public ProviderRegistrationProperties()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__providerRegistrationPropertiesAutoGenerated), __providerRegistrationPropertiesAutoGenerated);
            await eventListener.AssertObjectIsValid(nameof(__providerRegistrationPropertiesAutoGenerated), __providerRegistrationPropertiesAutoGenerated);
        }
    }
    public partial interface IProviderRegistrationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGenerated
    {

    }
    internal partial interface IProviderRegistrationPropertiesInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesAutoGeneratedInternal
    {

    }
}