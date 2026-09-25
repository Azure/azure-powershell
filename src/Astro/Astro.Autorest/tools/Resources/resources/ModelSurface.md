### AddOwnerParameters \<Object\> [Api16]
  - Url `String`

### AdGroup \<Object\> [Api16]
  - DeletionTimestamp `DateTime?` **{MinValue, MaxValue}**
  - DisplayName `String`
  - Mail `String`
  - MailEnabled `Boolean?`
  - MailNickname `String`
  - ObjectId `String`
  - ObjectType `String`
  - SecurityEnabled `Boolean?`

### AliasPathType [Api20180501]
  - ApiVersion `String[]`
  - Path `String`

### AliasType [Api20180501]
  - Name `String`
  - Path `IAliasPathType[]`

### Appliance [Api20160901Preview]
  - DefinitionId `String`
  - Id `String`
  - Identity `IIdentity`
  - IdentityPrincipalId `String`
  - IdentityTenantId `String`
  - IdentityType `ResourceIdentityType?` **{None, SystemAssigned, SystemAssignedUserAssigned, UserAssigned}**
  - Kind `String`
  - Location `String`
  - ManagedBy `String`
  - ManagedResourceGroupId `String`
  - Name `String`
  - Output `IAppliancePropertiesOutputs`
  - Parameter `IAppliancePropertiesParameters`
  - PlanName `String`
  - PlanProduct `String`
  - PlanPromotionCode `String`
  - PlanPublisher `String`
  - PlanVersion `String`
  - ProvisioningState `String`
  - Sku `ISku`
  - SkuCapacity `Int32?`
  - SkuFamily `String`
  - SkuModel `String`
  - SkuName `String`
  - SkuSize `String`
  - SkuTier `String`
  - Tag `IResourceTags <String>`
  - Type `String`
  - UiDefinitionUri `String`

### ApplianceArtifact [Api20160901Preview]
  - Name `String`
  - Type `ApplianceArtifactType?` **{Custom, Template}**
  - Uri `String`

### ApplianceDefinition [Api20160901Preview]
  - Artifact `IApplianceArtifact[]`
  - Authorization `IApplianceProviderAuthorization[]`
  - Description `String`
  - DisplayName `String`
  - Id `String`
  - Identity `IIdentity`
  - IdentityPrincipalId `String`
  - IdentityTenantId `String`
  - IdentityType `ResourceIdentityType?` **{None, SystemAssigned, SystemAssignedUserAssigned, UserAssigned}**
  - Location `String`
  - LockLevel `ApplianceLockLevel` **{CanNotDelete, None, ReadOnly}**
  - ManagedBy `String`
  - Name `String`
  - PackageFileUri `String`
  - Sku `ISku`
  - SkuCapacity `Int32?`
  - SkuFamily `String`
  - SkuModel `String`
  - SkuName `String`
  - SkuSize `String`
  - SkuTier `String`
  - Tag `IResourceTags <String>`
  - Type `String`

### ApplianceDefinitionListResult [Api20160901Preview]
  - NextLink `String`
  - Value `IApplianceDefinition[]`

### ApplianceDefinitionProperties [Api20160901Preview]
  - Artifact `IApplianceArtifact[]`
  - Authorization `IApplianceProviderAuthorization[]`
  - Description `String`
  - DisplayName `String`
  - LockLevel `ApplianceLockLevel` **{CanNotDelete, None, ReadOnly}**
  - PackageFileUri `String`

### ApplianceListResult [Api20160901Preview]
  - NextLink `String`
  - Value `IAppliance[]`

### AppliancePatchable [Api20160901Preview]
  - ApplianceDefinitionId `String`
  - Id `String`
  - Identity `IIdentity`
  - IdentityPrincipalId `String`
  - IdentityTenantId `String`
  - IdentityType `ResourceIdentityType?` **{None, SystemAssigned, SystemAssignedUserAssigned, UserAssigned}**
  - Kind `String`
  - Location `String`
  - ManagedBy `String`
  - ManagedResourceGroupId `String`
  - Name `String`
  - Output `IAppliancePropertiesPatchableOutputs`
  - Parameter `IAppliancePropertiesPatchableParameters`
  - PlanName `String`
  - PlanProduct `String`
  - PlanPromotionCode `String`
  - PlanPublisher `String`
  - PlanVersion `String`
  - ProvisioningState `String`
  - Sku `ISku`
  - SkuCapacity `Int32?`
  - SkuFamily `String`
  - SkuModel `String`
  - SkuName `String`
  - SkuSize `String`
  - SkuTier `String`
  - Tag `IResourceTags <String>`
  - Type `String`
  - UiDefinitionUri `String`

### ApplianceProperties [Api20160901Preview]
  - ApplianceDefinitionId `String`
  - ManagedResourceGroupId `String`
  - Output `IAppliancePropertiesOutputs`
  - Parameter `IAppliancePropertiesParameters`
  - ProvisioningState `String`
  - UiDefinitionUri `String`

### AppliancePropertiesPatchable [Api20160901Preview]
  - ApplianceDefinitionId `String`
  - ManagedResourceGroupId `String`
  - Output `IAppliancePropertiesPatchableOutputs`
  - Parameter `IAppliancePropertiesPatchableParameters`
  - ProvisioningState `String`
  - UiDefinitionUri `String`

### ApplianceProviderAuthorization [Api20160901Preview]
  - PrincipalId `String`
  - RoleDefinitionId `String`

### Application \<Object\> [Api16, Api20170901, Api20180601]
  - AllowGuestsSignIn `Boolean?`
  - AllowPassthroughUser `Boolean?`
  - AppId `String`
  - AppLogoUrl `String`
  - AppPermission `String[]`
  - AppRole `IAppRole[]`
  - AvailableToOtherTenant `Boolean?`
  - DefinitionId `String`
  - DeletionTimestamp `DateTime?` **{MinValue, MaxValue}**
  - DisplayName `String`
  - ErrorUrl `String`
  - GroupMembershipClaim `GroupMembershipClaimTypes?` **{All, None, SecurityGroup}**
  - Homepage `String`
  - Id `String`
  - IdentifierUri `String[]`
  - Identity `IIdentity`
  - IdentityPrincipalId `String`
  - IdentityTenantId `String`
  - IdentityType `ResourceIdentityType?` **{None, SystemAssigned, SystemAssignedUserAssigned, UserAssigned}**
  - InformationalUrlMarketing `String`
  - InformationalUrlPrivacy `String`
  - InformationalUrlSupport `String`
  - InformationalUrlTermsOfService `String`
  - IsDeviceOnlyAuthSupported `Boolean?`
  - KeyCredentials `IKeyCredential[]`
  - Kind `String`
  - KnownClientApplication `String[]`
  - Location `String`
  - LogoutUrl `String`
  - ManagedBy `String`
  - ManagedResourceGroupId `String`
  - Name `String`
  - Oauth2AllowImplicitFlow `Boolean?`
  - Oauth2AllowUrlPathMatching `Boolean?`
  - Oauth2Permission `IOAuth2Permission[]`
  - Oauth2RequirePostResponse `Boolean?`
  - ObjectId `String`
  - ObjectType `String`
  - OptionalClaimAccessToken `IOptionalClaim[]`
  - OptionalClaimIdToken `IOptionalClaim[]`
  - OptionalClaimSamlToken `IOptionalClaim[]`
  - OrgRestriction `String[]`
  - Output `IApplicationPropertiesOutputs`
  - Parameter `IApplicationPropertiesParameters`
  - PasswordCredentials `IPasswordCredential[]`
  - PlanName `String`
  - PlanProduct `String`
  - PlanPromotionCode `String`
  - PlanPublisher `String`
  - PlanVersion `String`
  - PreAuthorizedApplication `IPreAuthorizedApplication[]`
  - ProvisioningState `String`
  - PublicClient `Boolean?`
  - PublisherDomain `String`
  - ReplyUrl `String[]`
  - RequiredResourceAccess `IRequiredResourceAccess[]`
  - SamlMetadataUrl `String`
  - SignInAudience `String`
  - Sku `ISku`
  - SkuCapacity `Int32?`
  - SkuFamily `String`
  - SkuModel `String`
  - SkuName `String`
  - SkuSize `String`
  - SkuTier `String`
  - Tag `IResourceTags <String>`
  - Type `String`
  - UiDefinitionUri `String`
  - WwwHomepage `String`

### ApplicationArtifact [Api20170901]
  - Name `String`
  - Type `ApplicationArtifactType?` **{Custom, Template}**
  - Uri `String`

### ApplicationBase [Api16]
  - AllowGuestsSignIn `Boolean?`
  - AllowPassthroughUser `Boolean?`
  - AppLogoUrl `String`
  - AppPermission `String[]`
  - AppRole `IAppRole[]`
  - AvailableToOtherTenant `Boolean?`
  - ErrorUrl `String`
  - GroupMembershipClaim `GroupMembershipClaimTypes?` **{All, None, SecurityGroup}**
  - Homepage `String`
  - InformationalUrlMarketing `String`
  - InformationalUrlPrivacy `String`
  - InformationalUrlSupport `String`
  - InformationalUrlTermsOfService `String`
  - IsDeviceOnlyAuthSupported `Boolean?`
  - KeyCredentials `IKeyCredential[]`
  - KnownClientApplication `String[]`
  - LogoutUrl `String`
  - Oauth2AllowImplicitFlow `Boolean?`
  - Oauth2AllowUrlPathMatching `Boolean?`
  - Oauth2Permission `IOAuth2Permission[]`
  - Oauth2RequirePostResponse `Boolean?`
  - OptionalClaimAccessToken `IOptionalClaim[]`
  - OptionalClaimIdToken `IOptionalClaim[]`
  - OptionalClaimSamlToken `IOptionalClaim[]`
  - OrgRestriction `String[]`
  - PasswordCredentials `IPasswordCredential[]`
  - PreAuthorizedApplication `IPreAuthorizedApplication[]`
  - PublicClient `Boolean?`
  - PublisherDomain `String`
  - ReplyUrl `String[]`
  - RequiredResourceAccess `IRequiredResourceAccess[]`
  - SamlMetadataUrl `String`
  - SignInAudience `String`
  - WwwHomepage `String`

### ApplicationCreateParameters [Api16]
  - AllowGuestsSignIn `Boolean?`
  - AllowPassthroughUser `Boolean?`
  - AppLogoUrl `String`
  - AppPermission `String[]`
  - AppRole `IAppRole[]`
  - AvailableToOtherTenant `Boolean?`
  - DisplayName `String`
  - ErrorUrl `String`
  - GroupMembershipClaim `GroupMembershipClaimTypes?` **{All, None, SecurityGroup}**
  - Homepage `String`
  - IdentifierUri `String[]`
  - InformationalUrl `IInformationalUrl`
  - InformationalUrlMarketing `String`
  - InformationalUrlPrivacy `String`
  - InformationalUrlSupport `String`
  - InformationalUrlTermsOfService `String`
  - IsDeviceOnlyAuthSupported `Boolean?`
  - KeyCredentials `IKeyCredential[]`
  - KnownClientApplication `String[]`
  - LogoutUrl `String`
  - Oauth2AllowImplicitFlow `Boolean?`
  - Oauth2AllowUrlPathMatching `Boolean?`
  - Oauth2Permission `IOAuth2Permission[]`
  - Oauth2RequirePostResponse `Boolean?`
  - OptionalClaim `IOptionalClaims`
  - OptionalClaimAccessToken `IOptionalClaim[]`
  - OptionalClaimIdToken `IOptionalClaim[]`
  - OptionalClaimSamlToken `IOptionalClaim[]`
  - OrgRestriction `String[]`
  - PasswordCredentials `IPasswordCredential[]`
  - PreAuthorizedApplication `IPreAuthorizedApplication[]`
  - PublicClient `Boolean?`
  - PublisherDomain `String`
  - ReplyUrl `String[]`
  - RequiredResourceAccess `IRequiredResourceAccess[]`
  - SamlMetadataUrl `String`
  - SignInAudience `String`
  - WwwHomepage `String`

### ApplicationDefinition [Api20170901]
  - Artifact `IApplicationArtifact[]`
  - Authorization `IApplicationProviderAuthorization[]`
  - CreateUiDefinition `IApplicationDefinitionPropertiesCreateUiDefinition`
  - Description `String`
  - DisplayName `String`
  - Id `String`
  - Identity `IIdentity`
  - IdentityPrincipalId `String`
  - IdentityTenantId `String`
  - IdentityType `ResourceIdentityType?` **{None, SystemAssigned, SystemAssignedUserAssigned, UserAssigned}**
  - IsEnabled `String`
  - Location `String`
  - LockLevel `ApplicationLockLevel` **{CanNotDelete, None, ReadOnly}**
  - MainTemplate `IApplicationDefinitionPropertiesMainTemplate`
  - ManagedBy `String`
  - Name `String`
  - PackageFileUri `String`
  - Sku `ISku`
  - SkuCapacity `Int32?`
  - SkuFamily `String`
  - SkuModel `String`
  - SkuName `String`
  - SkuSize `String`
  - SkuTier `String`
  - Tag `IResourceTags <String>`
  - Type `String`

### ApplicationDefinitionListResult [Api20180601]
  - NextLink `String`
  - Value `IApplicationDefinition[]`

### ApplicationDefinitionProperties [Api20170901]
  - Artifact `IApplicationArtifact[]`
  - Authorization `IApplicationProviderAuthorization[]`
  - CreateUiDefinition `IApplicationDefinitionPropertiesCreateUiDefinition`
  - Description `String`
  - DisplayName `String`
  - IsEnabled `String`
  - LockLevel `ApplicationLockLevel` **{CanNotDelete, None, ReadOnly}**
  - MainTemplate `IApplicationDefinitionPropertiesMainTemplate`
  - PackageFileUri `String`

### ApplicationListResult [Api16, Api20180601]
  - NextLink `String`
  - OdataNextLink `String`
  - Value `IApplication[]`

### ApplicationPatchable [Api20170901, Api20180601]
  - ApplicationDefinitionId `String`
  - Id `String`
  - Identity `IIdentity`
  - IdentityPrincipalId `String`
  - IdentityTenantId `String`
  - IdentityType `ResourceIdentityType?` **{None, SystemAssigned, SystemAssignedUserAssigned, UserAssigned}**
  - Kind `String`
  - Location `String`
  - ManagedBy `String`
  - ManagedResourceGroupId `String`
  - Name `String`
  - Output `IApplicationPropertiesPatchableOutputs`
  - Parameter `IApplicationPropertiesPatchableParameters`
  - PlanName `String`
  - PlanProduct `String`
  - PlanPromotionCode `String`
  - PlanPublisher `String`
  - PlanVersion `String`
  - ProvisioningState `String`
  - Sku `ISku`
  - SkuCapacity `Int32?`
  - SkuFamily `String`
  - SkuModel `String`
  - SkuName `String`
  - SkuSize `String`
  - SkuTier `String`
  - Tag `IResourceTags <String>`
  - Type `String`
  - UiDefinitionUri `String`

### ApplicationProperties [Api20170901, Api20180601]
  - ApplicationDefinitionId `String`
  - ManagedResourceGroupId `String`
  - Output `IApplicationPropertiesOutputs`
  - Parameter `IApplicationPropertiesParameters`
  - ProvisioningState `String`
  - UiDefinitionUri `String`

### ApplicationPropertiesPatchable [Api20170901, Api20180601]
  - ApplicationDefinitionId `String`
  - ManagedResourceGroupId `String`
  - Output `IApplicationPropertiesPatchableOutputs`
  - Parameter `IApplicationPropertiesPatchableParameters`
  - ProvisioningState `String`
  - UiDefinitionUri `String`

### ApplicationProviderAuthorization [Api20170901]
  - PrincipalId `String`
  - RoleDefinitionId `String`

### ApplicationUpdateParameters [Api16]
  - AllowGuestsSignIn `Boolean?`
  - AllowPassthroughUser `Boolean?`
  - AppLogoUrl `String`
  - AppPermission `String[]`
  - AppRole `IAppRole[]`
  - AvailableToOtherTenant `Boolean?`
  - DisplayName `String`
  - ErrorUrl `String`
  - GroupMembershipClaim `GroupMembershipClaimTypes?` **{All, None, SecurityGroup}**
  - Homepage `String`
  - IdentifierUri `String[]`
  - InformationalUrl `IInformationalUrl`
  - InformationalUrlMarketing `String`
  - InformationalUrlPrivacy `String`
  - InformationalUrlSupport `String`
  - InformationalUrlTermsOfService `String`
  - IsDeviceOnlyAuthSupported `Boolean?`
  - KeyCredentials `IKeyCredential[]`
  - KnownClientApplication `String[]`
  - LogoutUrl `String`
  - Oauth2AllowImplicitFlow `Boolean?`
  - Oauth2AllowUrlPathMatching `Boolean?`
  - Oauth2Permission `IOAuth2Permission[]`
  - Oauth2RequirePostResponse `Boolean?`
  - OptionalClaim `IOptionalClaims`
  - OptionalClaimAccessToken `IOptionalClaim[]`
  - OptionalClaimIdToken `IOptionalClaim[]`
  - OptionalClaimSamlToken `IOptionalClaim[]`
  - OrgRestriction `String[]`
  - PasswordCredentials `IPasswordCredential[]`
  - PreAuthorizedApplication `IPreAuthorizedApplication[]`
  - PublicClient `Boolean?`
  - PublisherDomain `String`
  - ReplyUrl `String[]`
  - RequiredResourceAccess `IRequiredResourceAccess[]`
  - SamlMetadataUrl `String`
  - SignInAudience `String`
  - WwwHomepage `String`

### AppRole [Api16]
  - AllowedMemberType `String[]`
  - Description `String`
  - DisplayName `String`
  - Id `String`
  - IsEnabled `Boolean?`
  - Value `String`

### BasicDependency [Api20180501]
  - Id `String`
  - ResourceName `String`
  - ResourceType `String`

### CheckGroupMembershipParameters \<Object\> [Api16]
  - GroupId `String`
  - MemberId `String`

### CheckGroupMembershipResult \<Object\> [Api16]
  - Value `Boolean?`

### CheckNameAvailabilityRequest [Api20180301Preview]
  - Name `String`
  - Type `Type?` **{ProvidersMicrosoftManagementGroups}**

### CheckNameAvailabilityResult [Api20180301Preview]
  - Message `String`
  - NameAvailable `Boolean?`
  - Reason `Reason?` **{AlreadyExists, Invalid}**

### ClassicAdministrator [Api20150701]
  - EmailAddress `String`
  - Id `String`
  - Name `String`
  - Role `String`
  - Type `String`

### ClassicAdministratorListResult [Api20150701]
  - NextLink `String`
  - Value `IClassicAdministrator[]`

### ClassicAdministratorProperties [Api20150701]
  - EmailAddress `String`
  - Role `String`

### ComponentsSchemasIdentityPropertiesUserassignedidentitiesAdditionalproperties [Api20180501]
  - ClientId `String`
  - PrincipalId `String`

### CreateManagementGroupChildInfo [Api20180301Preview]
  - Child `ICreateManagementGroupChildInfo[]`
  - DisplayName `String`
  - Id `String`
  - Name `String`
  - Role `String[]`
  - Type `String`

### CreateManagementGroupDetails [Api20180301Preview]
  - ParentDisplayName `String`
  - ParentId `String`
  - ParentName `String`
  - UpdatedBy `String`
  - UpdatedTime `DateTime?` **{MinValue, MaxValue}**
  - Version `Single?`

### CreateManagementGroupProperties [Api20180301Preview]
  - Child `ICreateManagementGroupChildInfo[]`
  - DetailUpdatedBy `String`
  - DetailUpdatedTime `DateTime?` **{MinValue, MaxValue}**
  - DetailVersion `Single?`
  - DisplayName `String`
  - ParentDisplayName `String`
  - ParentId `String`
  - ParentName `String`
  - Role `String[]`
  - TenantId `String`

### CreateManagementGroupRequest [Api20180301Preview]
  - Child `ICreateManagementGroupChildInfo[]`
  - DetailUpdatedBy `String`
  - DetailUpdatedTime `DateTime?` **{MinValue, MaxValue}**
  - DetailVersion `Single?`
  - DisplayName `String`
  - Id `String`
  - Name `String`
  - ParentDisplayName `String`
  - ParentId `String`
  - ParentName `String`
  - Role `String[]`
  - TenantId `String`
  - Type `String`

### CreateParentGroupInfo [Api20180301Preview]
  - DisplayName `String`
  - Id `String`
  - Name `String`

### DebugSetting [Api20180501]
  - DetailLevel `String`

### DenyAssignment [Api20180701Preview]
  - DenyAssignmentName `String`
  - Description `String`
  - DoNotApplyToChildScope `Boolean?`
  - ExcludePrincipal `IPrincipal[]`
  - Id `String`
  - IsSystemProtected `Boolean?`
  - Name `String`
  - Permission `IDenyAssignmentPermission[]`
  - Principal `IPrincipal[]`
  - Scope `String`
  - Type `String`

### DenyAssignmentListResult [Api20180701Preview]
  - NextLink `String`
  - Value `IDenyAssignment[]`

### DenyAssignmentPermission [Api20180701Preview]
  - Action `String[]`
  - DataAction `String[]`
  - NotAction `String[]`
  - NotDataAction `String[]`

### DenyAssignmentProperties [Api20180701Preview]
  - DenyAssignmentName `String`
  - Description `String`
  - DoNotApplyToChildScope `Boolean?`
  - ExcludePrincipal `IPrincipal[]`
  - IsSystemProtected `Boolean?`
  - Permission `IDenyAssignmentPermission[]`
  - Principal `IPrincipal[]`
  - Scope `String`

### Dependency [Api20180501]
  - DependsOn `IBasicDependency[]`
  - Id `String`
  - ResourceName `String`
  - ResourceType `String`

### Deployment [Api20180501]
  - DebugSettingDetailLevel `String`
  - Location `String`
  - Mode `DeploymentMode` **{Complete, Incremental}**
  - OnErrorDeploymentName `String`
  - OnErrorDeploymentType `OnErrorDeploymentType?` **{LastSuccessful, SpecificDeployment}**
  - Parameter `IDeploymentPropertiesParameters`
  - ParameterLinkContentVersion `String`
  - ParameterLinkUri `String`
  - Template `IDeploymentPropertiesTemplate`
  - TemplateLinkContentVersion `String`
  - TemplateLinkUri `String`

### DeploymentExportResult [Api20180501]
  - Template `IDeploymentExportResultTemplate`

### DeploymentExtended [Api20180501]
  - CorrelationId `String`
  - DebugSettingDetailLevel `String`
  - Dependency `IDependency[]`
  - Id `String`
  - Location `String`
  - Mode `DeploymentMode?` **{Complete, Incremental}**
  - Name `String`
  - OnErrorDeploymentName `String`
  - OnErrorDeploymentProvisioningState `String`
  - OnErrorDeploymentType `OnErrorDeploymentType?` **{LastSuccessful, SpecificDeployment}**
  - Output `IDeploymentPropertiesExtendedOutputs`
  - Parameter `IDeploymentPropertiesExtendedParameters`
  - ParameterLinkContentVersion `String`
  - ParameterLinkUri `String`
  - Provider `IProvider[]`
  - ProvisioningState `String`
  - Template `IDeploymentPropertiesExtendedTemplate`
  - TemplateLinkContentVersion `String`
  - TemplateLinkUri `String`
  - Timestamp `DateTime?` **{MinValue, MaxValue}**
  - Type `String`

### DeploymentListResult [Api20180501]
  - NextLink `String`
  - Value `IDeploymentExtended[]`

### DeploymentOperation [Api20180501]
  - Id `String`
  - OperationId `String`
  - ProvisioningState `String`
  - RequestContent `IHttpMessageContent`
  - ResponseContent `IHttpMessageContent`
  - ServiceRequestId `String`
  - StatusCode `String`
  - StatusMessage `IDeploymentOperationPropertiesStatusMessage`
  - TargetResourceId `String`
  - TargetResourceName `String`
  - TargetResourceType `String`
  - Timestamp `DateTime?` **{MinValue, MaxValue}**

### DeploymentOperationProperties [Api20180501]
  - ProvisioningState `String`
  - RequestContent `IHttpMessageContent`
  - ResponseContent `IHttpMessageContent`
  - ServiceRequestId `String`
  - StatusCode `String`
  - StatusMessage `IDeploymentOperationPropertiesStatusMessage`
  - TargetResourceId `String`
  - TargetResourceName `String`
  - TargetResourceType `String`
  - Timestamp `DateTime?` **{MinValue, MaxValue}**

### DeploymentOperationsListResult [Api20180501]
  - NextLink `String`
  - Value `IDeploymentOperation[]`

### DeploymentProperties [Api20180501]
  - DebugSettingDetailLevel `String`
  - Mode `DeploymentMode` **{Complete, Incremental}**
  - OnErrorDeploymentName `String`
  - OnErrorDeploymentType `OnErrorDeploymentType?` **{LastSuccessful, SpecificDeployment}**
  - Parameter `IDeploymentPropertiesParameters`
  - ParameterLinkContentVersion `String`
  - ParameterLinkUri `String`
  - Template `IDeploymentPropertiesTemplate`
  - TemplateLinkContentVersion `String`
  - TemplateLinkUri `String`

### DeploymentPropertiesExtended [Api20180501]
  - CorrelationId `String`
  - DebugSettingDetailLevel `String`
  - Dependency `IDependency[]`
  - Mode `DeploymentMode?` **{Complete, Incremental}**
  - OnErrorDeploymentName `String`
  - OnErrorDeploymentProvisioningState `String`
  - OnErrorDeploymentType `OnErrorDeploymentType?` **{LastSuccessful, SpecificDeployment}**
  - Output `IDeploymentPropertiesExtendedOutputs`
  - Parameter `IDeploymentPropertiesExtendedParameters`
  - ParameterLinkContentVersion `String`
  - ParameterLinkUri `String`
  - Provider `IProvider[]`
  - ProvisioningState `String`
  - Template `IDeploymentPropertiesExtendedTemplate`
  - TemplateLinkContentVersion `String`
  - TemplateLinkUri `String`
  - Timestamp `DateTime?` **{MinValue, MaxValue}**

### DeploymentValidateResult [Api20180501]
  - CorrelationId `String`
  - DebugSettingDetailLevel `String`
  - Dependency `IDependency[]`
  - ErrorCode `String`
  - ErrorDetail `IResourceManagementErrorWithDetails[]`
  - ErrorMessage `String`
  - ErrorTarget `String`
  - Mode `DeploymentMode?` **{Complete, Incremental}**
  - OnErrorDeploymentName `String`
  - OnErrorDeploymentProvisioningState `String`
  - OnErrorDeploymentType `OnErrorDeploymentType?` **{LastSuccessful, SpecificDeployment}**
  - Output `IDeploymentPropertiesExtendedOutputs`
  - Parameter `IDeploymentPropertiesExtendedParameters`
  - ParameterLinkContentVersion `String`
  - ParameterLinkUri `String`
  - Provider `IProvider[]`
  - ProvisioningState `String`
  - Template `IDeploymentPropertiesExtendedTemplate`
  - TemplateLinkContentVersion `String`
  - TemplateLinkUri `String`
  - Timestamp `DateTime?` **{MinValue, MaxValue}**

### DescendantInfo [Api20180301Preview]
  - DisplayName `String`
  - Id `String`
  - Name `String`
  - ParentId `String`
  - Type `String`

### DescendantInfoProperties [Api20180301Preview]
  - DisplayName `String`
  - ParentId `String`

### DescendantListResult [Api20180301Preview]
  - NextLink `String`
  - Value `IDescendantInfo[]`

### DescendantParentGroupInfo [Api20180301Preview]
  - Id `String`

### DirectoryObject \<Object\> [Api16]
  - DeletionTimestamp `DateTime?` **{MinValue, MaxValue}**
  - ObjectId `String`
  - ObjectType `String`

### DirectoryObjectListResult [Api16]
  - OdataNextLink `String`
  - Value `IDirectoryObject[]`

### Domain \<Object\> [Api16]
  - AuthenticationType `String`
  - IsDefault `Boolean?`
  - IsVerified `Boolean?`
  - Name `String`

### DomainListResult [Api16]
  - Value `IDomain[]`

### EntityInfo [Api20180301Preview]
  - DisplayName `String`
  - Id `String`
  - InheritedPermission `String`
  - Name `String`
  - NumberOfChild `Int32?`
  - NumberOfChildGroup `Int32?`
  - NumberOfDescendant `Int32?`
  - ParentDisplayNameChain `String[]`
  - ParentId `String`
  - ParentNameChain `String[]`
  - Permission `String`
  - TenantId `String`
  - Type `String`

### EntityInfoProperties [Api20180301Preview]
  - DisplayName `String`
  - InheritedPermission `String`
  - NumberOfChild `Int32?`
  - NumberOfChildGroup `Int32?`
  - NumberOfDescendant `Int32?`
  - ParentDisplayNameChain `String[]`
  - ParentId `String`
  - ParentNameChain `String[]`
  - Permission `String`
  - TenantId `String`

### EntityListResult [Api20180301Preview]
  - Count `Int32?`
  - NextLink `String`
  - Value `IEntityInfo[]`

### EntityParentGroupInfo [Api20180301Preview]
  - Id `String`

### ErrorDetails [Api20180301Preview]
  - Code `String`
  - Detail `String`
  - Message `String`

### ErrorMessage [Api16]
  - Message `String`

### ErrorResponse [Api20160901Preview, Api20180301Preview]
  - ErrorCode `String`
  - ErrorDetail `String`
  - ErrorMessage `String`
  - HttpStatus `String`

### ExportTemplateRequest [Api20180501]
  - Option `String`
  - Resource `String[]`

### FeatureOperationsListResult [Api20151201]
  - NextLink `String`
  - Value `IFeatureResult[]`

### FeatureProperties [Api20151201]
  - State `String`

### FeatureResult [Api20151201]
  - Id `String`
  - Name `String`
  - State `String`
  - Type `String`

### GenericResource [Api20160901Preview, Api20180501]
  - Id `String`
  - IdentityPrincipalId `String`
  - IdentityTenantId `String`
  - IdentityType `ResourceIdentityType?` **{None, SystemAssigned, SystemAssignedUserAssigned, UserAssigned}**
  - IdentityUserAssignedIdentity `IIdentityUserAssignedIdentities <IComponentsSchemasIdentityPropertiesUserassignedidentitiesAdditionalproperties>`
  - Kind `String`
  - Location `String`
  - ManagedBy `String`
  - Name `String`
  - PlanName `String`
  - PlanProduct `String`
  - PlanPromotionCode `String`
  - PlanPublisher `String`
  - PlanVersion `String`
  - Property `IGenericResourceProperties`
  - SkuCapacity `Int32?`
  - SkuFamily `String`
  - SkuModel `String`
  - SkuName `String`
  - SkuSize `String`
  - SkuTier `String`
  - Tag `IResourceTags <String>`
  - Type `String`

### GetObjectsParameters \<Object\> [Api16]
  - IncludeDirectoryObjectReference `Boolean?`
  - ObjectId `String[]`
  - Type `String[]`

### GraphError [Api16]
  - ErrorMessageValueMessage `String`
  - OdataErrorCode `String`

### GroupAddMemberParameters \<Object\> [Api16]
  - Url `String`

### GroupCreateParameters \<Object\> [Api16]
  - DisplayName `String`
  - MailEnabled `Boolean`
  - MailNickname `String`
  - SecurityEnabled `Boolean`

### GroupGetMemberGroupsParameters \<Object\> [Api16]
  - SecurityEnabledOnly `Boolean`

### GroupGetMemberGroupsResult [Api16]
  - Value `String[]`

### GroupListResult [Api16]
  - OdataNextLink `String`
  - Value `IAdGroup[]`

### HttpMessage [Api20180501]
  - Content `IHttpMessageContent`

### Identity [Api20160901Preview, Api20180501]
  - PrincipalId `String`
  - TenantId `String`
  - Type `ResourceIdentityType?` **{None, SystemAssigned, SystemAssignedUserAssigned, UserAssigned}**
  - UserAssignedIdentity `IIdentityUserAssignedIdentities <IComponentsSchemasIdentityPropertiesUserassignedidentitiesAdditionalproperties>`

### Identity1 [Api20180501]
  - PrincipalId `String`
  - TenantId `String`
  - Type `ResourceIdentityType?` **{None, SystemAssigned, SystemAssignedUserAssigned, UserAssigned}**

### InformationalUrl [Api16]
  - Marketing `String`
  - Privacy `String`
  - Support `String`
  - TermsOfService `String`

### KeyCredential \<Object\> [Api16]
  - CustomKeyIdentifier `String`
  - EndDate `DateTime?` **{MinValue, MaxValue}**
  - KeyId `String`
  - StartDate `DateTime?` **{MinValue, MaxValue}**
  - Type `String`
  - Usage `String`
  - Value `String`

### KeyCredentialListResult [Api16]
  - Value `IKeyCredential[]`

### KeyCredentialsUpdateParameters [Api16]
  - Value `IKeyCredential[]`

### Location [Api20160601]
  - DisplayName `String`
  - Id `String`
  - Latitude `String`
  - Longitude `String`
  - Name `String`
  - SubscriptionId `String`

### LocationListResult [Api20160601]
  - Value `ILocation[]`

### ManagementGroup [Api20180301Preview]
  - Child `IManagementGroupChildInfo[]`
  - DetailUpdatedBy `String`
  - DetailUpdatedTime `DateTime?` **{MinValue, MaxValue}**
  - DetailVersion `Single?`
  - DisplayName `String`
  - Id `String`
  - Name `String`
  - ParentDisplayName `String`
  - ParentId `String`
  - ParentName `String`
  - Role `String[]`
  - TenantId `String`
  - Type `String`

### ManagementGroupChildInfo [Api20180301Preview]
  - Child `IManagementGroupChildInfo[]`
  - DisplayName `String`
  - Id `String`
  - Name `String`
  - Role `String[]`
  - Type `String`

### ManagementGroupDetails [Api20180301Preview]
  - ParentDisplayName `String`
  - ParentId `String`
  - ParentName `String`
  - UpdatedBy `String`
  - UpdatedTime `DateTime?` **{MinValue, MaxValue}**
  - Version `Single?`

### ManagementGroupInfo [Api20180301Preview]
  - DisplayName `String`
  - Id `String`
  - Name `String`
  - TenantId `String`
  - Type `String`

### ManagementGroupInfoProperties [Api20180301Preview]
  - DisplayName `String`
  - TenantId `String`

### ManagementGroupListResult [Api20180301Preview]
  - NextLink `String`
  - Value `IManagementGroupInfo[]`

### ManagementGroupProperties [Api20180301Preview]
  - Child `IManagementGroupChildInfo[]`
  - DetailUpdatedBy `String`
  - DetailUpdatedTime `DateTime?` **{MinValue, MaxValue}**
  - DetailVersion `Single?`
  - DisplayName `String`
  - ParentDisplayName `String`
  - ParentId `String`
  - ParentName `String`
  - Role `String[]`
  - TenantId `String`

### ManagementLockListResult [Api20160901]
  - NextLink `String`
  - Value `IManagementLockObject[]`

### ManagementLockObject [Api20160901]
  - Id `String`
  - Level `LockLevel` **{CanNotDelete, NotSpecified, ReadOnly}**
  - Name `String`
  - Note `String`
  - Owner `IManagementLockOwner[]`
  - Type `String`

### ManagementLockOwner [Api20160901]
  - ApplicationId `String`

### ManagementLockProperties [Api20160901]
  - Level `LockLevel` **{CanNotDelete, NotSpecified, ReadOnly}**
  - Note `String`
  - Owner `IManagementLockOwner[]`

### OAuth2Permission [Api16]
  - AdminConsentDescription `String`
  - AdminConsentDisplayName `String`
  - Id `String`
  - IsEnabled `Boolean?`
  - Type `String`
  - UserConsentDescription `String`
  - UserConsentDisplayName `String`
  - Value `String`

### OAuth2PermissionGrant [Api16]
  - ClientId `String`
  - ConsentType `ConsentType?` **{AllPrincipals, Principal}**
  - ExpiryTime `String`
  - ObjectId `String`
  - OdataType `String`
  - PrincipalId `String`
  - ResourceId `String`
  - Scope `String`
  - StartTime `String`

### OAuth2PermissionGrantListResult [Api16]
  - OdataNextLink `String`
  - Value `IOAuth2PermissionGrant[]`

### OdataError [Api16]
  - Code `String`
  - ErrorMessageValueMessage `String`

### OnErrorDeployment [Api20180501]
  - DeploymentName `String`
  - Type `OnErrorDeploymentType?` **{LastSuccessful, SpecificDeployment}**

### OnErrorDeploymentExtended [Api20180501]
  - DeploymentName `String`
  - ProvisioningState `String`
  - Type `OnErrorDeploymentType?` **{LastSuccessful, SpecificDeployment}**

### Operation [Api20151201, Api20180301Preview]
  - DisplayDescription `String`
  - DisplayOperation `String`
  - DisplayProvider `String`
  - DisplayResource `String`
  - Name `String`

### OperationDisplay [Api20151201]
  - Operation `String`
  - Provider `String`
  - Resource `String`

### OperationDisplayProperties [Api20180301Preview]
  - Description `String`
  - Operation `String`
  - Provider `String`
  - Resource `String`

### OperationListResult [Api20151201, Api20180301Preview]
  - NextLink `String`
  - Value `IOperation[]`

### OperationResults [Api20180301Preview]
  - Id `String`
  - Name `String`
  - ProvisioningState `String`
  - Type `String`

### OperationResultsProperties [Api20180301Preview]
  - ProvisioningState `String`

### OptionalClaim [Api16]
  - AdditionalProperty `IOptionalClaimAdditionalProperties`
  - Essential `Boolean?`
  - Name `String`
  - Source `String`

### OptionalClaims [Api16]
  - AccessToken `IOptionalClaim[]`
  - IdToken `IOptionalClaim[]`
  - SamlToken `IOptionalClaim[]`

### ParametersLink [Api20180501]
  - ContentVersion `String`
  - Uri `String`

### ParentGroupInfo [Api20180301Preview]
  - DisplayName `String`
  - Id `String`
  - Name `String`

### PasswordCredential \<Object\> [Api16]
  - CustomKeyIdentifier `Byte[]`
  - EndDate `DateTime?` **{MinValue, MaxValue}**
  - KeyId `String`
  - StartDate `DateTime?` **{MinValue, MaxValue}**
  - Value `String`

### PasswordCredentialListResult [Api16]
  - Value `IPasswordCredential[]`

### PasswordCredentialsUpdateParameters [Api16]
  - Value `IPasswordCredential[]`

### PasswordProfile \<Object\> [Api16]
  - ForceChangePasswordNextLogin `Boolean?`
  - Password `String`

### PatchManagementGroupRequest [Api20180301Preview]
  - DisplayName `String`
  - ParentId `String`

### Permission [Api20150701, Api201801Preview]
  - Action `String[]`
  - DataAction `String[]`
  - NotAction `String[]`
  - NotDataAction `String[]`

### PermissionGetResult [Api20150701, Api201801Preview]
  - NextLink `String`
  - Value `IPermission[]`

### Plan [Api20160901Preview, Api20180501]
  - Name `String`
  - Product `String`
  - PromotionCode `String`
  - Publisher `String`
  - Version `String`

### PlanPatchable [Api20160901Preview]
  - Name `String`
  - Product `String`
  - PromotionCode `String`
  - Publisher `String`
  - Version `String`

### PolicyAssignment [Api20151101, Api20161201, Api20180501]
  - Description `String`
  - DisplayName `String`
  - Id `String`
  - IdentityPrincipalId `String`
  - IdentityTenantId `String`
  - IdentityType `ResourceIdentityType?` **{None, SystemAssigned, SystemAssignedUserAssigned, UserAssigned}**
  - Location `String`
  - Metadata `IPolicyAssignmentPropertiesMetadata`
  - Name `String`
  - NotScope `String[]`
  - Parameter `IPolicyAssignmentPropertiesParameters`
  - PolicyDefinitionId `String`
  - Scope `String`
  - SkuName `String`
  - SkuTier `String`
  - Type `String`

### PolicyAssignmentListResult [Api20151101, Api20161201, Api20180501]
  - NextLink `String`
  - Value `IPolicyAssignment[]`

### PolicyAssignmentProperties [Api20151101, Api20161201, Api20180501]
  - Description `String`
  - DisplayName `String`
  - Metadata `IPolicyAssignmentPropertiesMetadata`
  - NotScope `String[]`
  - Parameter `IPolicyAssignmentPropertiesParameters`
  - PolicyDefinitionId `String`
  - Scope `String`

### PolicyDefinition [Api20161201, Api20180501]
  - Description `String`
  - DisplayName `String`
  - Id `String`
  - Metadata `IPolicyDefinitionPropertiesMetadata`
  - Mode `PolicyMode?` **{All, Indexed, NotSpecified}**
  - Name `String`
  - Parameter `IPolicyDefinitionPropertiesParameters`
  - PolicyRule `IPolicyDefinitionPropertiesPolicyRule`
  - PolicyType `PolicyType?` **{BuiltIn, Custom, NotSpecified}**
  - Property `IPolicyDefinitionProperties`
  - Type `String`

### PolicyDefinitionListResult [Api20161201, Api20180501]
  - NextLink `String`
  - Value `IPolicyDefinition[]`

### PolicyDefinitionProperties [Api20161201]
  - Description `String`
  - DisplayName `String`
  - Metadata `IPolicyDefinitionPropertiesMetadata`
  - Mode `PolicyMode?` **{All, Indexed, NotSpecified}**
  - Parameter `IPolicyDefinitionPropertiesParameters`
  - PolicyRule `IPolicyDefinitionPropertiesPolicyRule`
  - PolicyType `PolicyType?` **{BuiltIn, Custom, NotSpecified}**

### PolicyDefinitionReference [Api20180501]
  - Parameter `IPolicyDefinitionReferenceParameters`
  - PolicyDefinitionId `String`

### PolicySetDefinition [Api20180501]
  - Description `String`
  - DisplayName `String`
  - Id `String`
  - Metadata `IPolicySetDefinitionPropertiesMetadata`
  - Name `String`
  - Parameter `IPolicySetDefinitionPropertiesParameters`
  - PolicyDefinition `IPolicyDefinitionReference[]`
  - PolicyType `PolicyType?` **{BuiltIn, Custom, NotSpecified}**
  - Type `String`

### PolicySetDefinitionListResult [Api20180501]
  - NextLink `String`
  - Value `IPolicySetDefinition[]`

### PolicySetDefinitionProperties [Api20180501]
  - Description `String`
  - DisplayName `String`
  - Metadata `IPolicySetDefinitionPropertiesMetadata`
  - Parameter `IPolicySetDefinitionPropertiesParameters`
  - PolicyDefinition `IPolicyDefinitionReference[]`
  - PolicyType `PolicyType?` **{BuiltIn, Custom, NotSpecified}**

### PolicySku [Api20180501]
  - Name `String`
  - Tier `String`

### PreAuthorizedApplication [Api16]
  - AppId `String`
  - Extension `IPreAuthorizedApplicationExtension[]`
  - Permission `IPreAuthorizedApplicationPermission[]`

### PreAuthorizedApplicationExtension [Api16]
  - Condition `String[]`

### PreAuthorizedApplicationPermission [Api16]
  - AccessGrant `String[]`
  - DirectAccessGrant `Boolean?`

### Principal [Api20180701Preview]
  - Id `String`
  - Type `String`

### Provider [Api20180501]
  - Id `String`
  - Namespace `String`
  - RegistrationState `String`
  - ResourceType `IProviderResourceType[]`

### ProviderListResult [Api20180501]
  - NextLink `String`
  - Value `IProvider[]`

### ProviderOperation [Api20150701, Api201801Preview]
  - Description `String`
  - DisplayName `String`
  - IsDataAction `Boolean?`
  - Name `String`
  - Origin `String`
  - Property `IProviderOperationProperties`

### ProviderOperationsMetadata [Api20150701, Api201801Preview]
  - DisplayName `String`
  - Id `String`
  - Name `String`
  - Operation `IProviderOperation[]`
  - ResourceType `IResourceType[]`
  - Type `String`

### ProviderOperationsMetadataListResult [Api20150701, Api201801Preview]
  - NextLink `String`
  - Value `IProviderOperationsMetadata[]`

### ProviderResourceType [Api20180501]
  - Alias `IAliasType[]`
  - ApiVersion `String[]`
  - Location `String[]`
  - Property `IProviderResourceTypeProperties <String>`
  - ResourceType `String`

### RequiredResourceAccess \<Object\> [Api16]
  - ResourceAccess `IResourceAccess[]`
  - ResourceAppId `String`

### Resource [Api20160901Preview]
  - Id `String`
  - Location `String`
  - Name `String`
  - Tag `IResourceTags <String>`
  - Type `String`

### ResourceAccess \<Object\> [Api16]
  - Id `String`
  - Type `String`

### ResourceGroup [Api20180501]
  - Id `String`
  - Location `String`
  - ManagedBy `String`
  - Name `String`
  - ProvisioningState `String`
  - Tag `IResourceGroupTags <String>`
  - Type `String`

### ResourceGroupExportResult [Api20180501]
  - ErrorCode `String`
  - ErrorDetail `IResourceManagementErrorWithDetails[]`
  - ErrorMessage `String`
  - ErrorTarget `String`
  - Template `IResourceGroupExportResultTemplate`

### ResourceGroupListResult [Api20180501]
  - NextLink `String`
  - Value `IResourceGroup[]`

### ResourceGroupPatchable [Api20180501]
  - ManagedBy `String`
  - Name `String`
  - ProvisioningState `String`
  - Tag `IResourceGroupPatchableTags <String>`

### ResourceGroupProperties [Api20180501]
  - ProvisioningState `String`

### ResourceLink [Api20160901]
  - Id `String`
  - Name `String`
  - Note `String`
  - SourceId `String`
  - TargetId `String`
  - Type `IResourceLinkType`

### ResourceLinkProperties [Api20160901]
  - Note `String`
  - SourceId `String`
  - TargetId `String`

### ResourceLinkResult [Api20160901]
  - NextLink `String`
  - Value `IResourceLink[]`

### ResourceListResult [Api20180501]
  - NextLink `String`
  - Value `IGenericResource[]`

### ResourceManagementErrorWithDetails [Api20180501]
  - Code `String`
  - Detail `IResourceManagementErrorWithDetails[]`
  - Message `String`
  - Target `String`

### ResourceProviderOperationDefinition [Api20151101]
  - DisplayDescription `String`
  - DisplayOperation `String`
  - DisplayProvider `String`
  - DisplayPublisher `String`
  - DisplayResource `String`
  - Name `String`

### ResourceProviderOperationDetailListResult [Api20151101]
  - NextLink `String`
  - Value `IResourceProviderOperationDefinition[]`

### ResourceProviderOperationDisplayProperties [Api20151101]
  - Description `String`
  - Operation `String`
  - Provider `String`
  - Publisher `String`
  - Resource `String`

### ResourcesIdentity [Models]
  - ApplianceDefinitionId `String`
  - ApplianceDefinitionName `String`
  - ApplianceId `String`
  - ApplianceName `String`
  - ApplicationDefinitionId `String`
  - ApplicationDefinitionName `String`
  - ApplicationId `String`
  - ApplicationId1 `String`
  - ApplicationName `String`
  - ApplicationObjectId `String`
  - DenyAssignmentId `String`
  - DeploymentName `String`
  - DomainName `String`
  - FeatureName `String`
  - GroupId `String`
  - GroupObjectId `String`
  - Id `String`
  - LinkId `String`
  - LockName `String`
  - ManagementGroupId `String`
  - MemberObjectId `String`
  - ObjectId `String`
  - OperationId `String`
  - OwnerObjectId `String`
  - ParentResourcePath `String`
  - PolicyAssignmentId `String`
  - PolicyAssignmentName `String`
  - PolicyDefinitionName `String`
  - PolicySetDefinitionName `String`
  - ResourceGroupName `String`
  - ResourceId `String`
  - ResourceName `String`
  - ResourceProviderNamespace `String`
  - ResourceType `String`
  - RoleAssignmentId `String`
  - RoleAssignmentName `String`
  - RoleDefinitionId `String`
  - RoleId `String`
  - Scope `String`
  - SourceResourceGroupName `String`
  - SubscriptionId `String`
  - TagName `String`
  - TagValue `String`
  - TenantId `String`
  - UpnOrObjectId `String`

### ResourcesMoveInfo [Api20180501]
  - Resource `String[]`
  - TargetResourceGroup `String`

### ResourceType [Api20150701, Api201801Preview]
  - DisplayName `String`
  - Name `String`
  - Operation `IProviderOperation[]`

### RoleAssignment [Api20150701, Api20171001Preview, Api20180901Preview]
  - CanDelegate `Boolean?`
  - Id `String`
  - Name `String`
  - PrincipalId `String`
  - PrincipalType `PrincipalType?` **{Application, DirectoryObjectOrGroup, DirectoryRoleTemplate, Everyone, ForeignGroup, Group, Msi, ServicePrincipal, Unknown, User}**
  - RoleDefinitionId `String`
  - Scope `String`
  - Type `String`

### RoleAssignmentCreateParameters [Api20150701, Api20171001Preview, Api20180901Preview]
  - CanDelegate `Boolean?`
  - PrincipalId `String`
  - PrincipalType `PrincipalType?` **{Application, DirectoryObjectOrGroup, DirectoryRoleTemplate, Everyone, ForeignGroup, Group, Msi, ServicePrincipal, Unknown, User}**
  - RoleDefinitionId `String`

### RoleAssignmentListResult [Api20150701, Api20180901Preview]
  - NextLink `String`
  - Value `IRoleAssignment[]`

### RoleAssignmentProperties [Api20150701, Api20171001Preview, Api20180901Preview]
  - CanDelegate `Boolean?`
  - PrincipalId `String`
  - PrincipalType `PrincipalType?` **{Application, DirectoryObjectOrGroup, DirectoryRoleTemplate, Everyone, ForeignGroup, Group, Msi, ServicePrincipal, Unknown, User}**
  - RoleDefinitionId `String`

### RoleAssignmentPropertiesWithScope [Api20150701, Api20171001Preview, Api20180901Preview]
  - CanDelegate `Boolean?`
  - PrincipalId `String`
  - PrincipalType `PrincipalType?` **{Application, DirectoryObjectOrGroup, DirectoryRoleTemplate, Everyone, ForeignGroup, Group, Msi, ServicePrincipal, Unknown, User}**
  - RoleDefinitionId `String`
  - Scope `String`

### RoleDefinition [Api20150701, Api201801Preview]
  - AssignableScope `String[]`
  - Description `String`
  - Id `String`
  - Name `String`
  - Permission `IPermission[]`
  - RoleName `String`
  - RoleType `String`
  - Type `String`

### RoleDefinitionListResult [Api20150701, Api201801Preview]
  - NextLink `String`
  - Value `IRoleDefinition[]`

### RoleDefinitionProperties [Api20150701, Api201801Preview]
  - AssignableScope `String[]`
  - Description `String`
  - Permission `IPermission[]`
  - RoleName `String`
  - RoleType `String`

### ServicePrincipal \<Object\> [Api16]
  - AccountEnabled `Boolean?`
  - AlternativeName `String[]`
  - AppDisplayName `String`
  - AppId `String`
  - AppOwnerTenantId `String`
  - AppRole `IAppRole[]`
  - AppRoleAssignmentRequired `Boolean?`
  - DeletionTimestamp `DateTime?` **{MinValue, MaxValue}**
  - DisplayName `String`
  - ErrorUrl `String`
  - Homepage `String`
  - KeyCredentials `IKeyCredential[]`
  - LogoutUrl `String`
  - Name `String[]`
  - Oauth2Permission `IOAuth2Permission[]`
  - ObjectId `String`
  - ObjectType `String`
  - PasswordCredentials `IPasswordCredential[]`
  - PreferredTokenSigningKeyThumbprint `String`
  - PublisherName `String`
  - ReplyUrl `String[]`
  - SamlMetadataUrl `String`
  - Tag `String[]`
  - Type `String`

### ServicePrincipalBase [Api16]
  - AccountEnabled `Boolean?`
  - AppRoleAssignmentRequired `Boolean?`
  - KeyCredentials `IKeyCredential[]`
  - PasswordCredentials `IPasswordCredential[]`
  - ServicePrincipalType `String`
  - Tag `String[]`

### ServicePrincipalCreateParameters [Api16]
  - AccountEnabled `Boolean?`
  - AppId `String`
  - AppRoleAssignmentRequired `Boolean?`
  - KeyCredentials `IKeyCredential[]`
  - PasswordCredentials `IPasswordCredential[]`
  - ServicePrincipalType `String`
  - Tag `String[]`

### ServicePrincipalListResult [Api16]
  - OdataNextLink `String`
  - Value `IServicePrincipal[]`

### ServicePrincipalObjectResult [Api16]
  - OdataMetadata `String`
  - Value `String`

### ServicePrincipalUpdateParameters [Api16]
  - AccountEnabled `Boolean?`
  - AppRoleAssignmentRequired `Boolean?`
  - KeyCredentials `IKeyCredential[]`
  - PasswordCredentials `IPasswordCredential[]`
  - ServicePrincipalType `String`
  - Tag `String[]`

### SignInName \<Object\> [Api16]
  - Type `String`
  - Value `String`

### Sku [Api20160901Preview, Api20180501]
  - Capacity `Int32?`
  - Family `String`
  - Model `String`
  - Name `String`
  - Size `String`
  - Tier `String`

### Subscription [Api20160601]
  - AuthorizationSource `String`
  - DisplayName `String`
  - Id `String`
  - PolicyLocationPlacementId `String`
  - PolicyQuotaId `String`
  - PolicySpendingLimit `SpendingLimit?` **{CurrentPeriodOff, Off, On}**
  - State `SubscriptionState?` **{Deleted, Disabled, Enabled, PastDue, Warned}**
  - SubscriptionId `String`

### SubscriptionPolicies [Api20160601]
  - LocationPlacementId `String`
  - QuotaId `String`
  - SpendingLimit `SpendingLimit?` **{CurrentPeriodOff, Off, On}**

### TagCount [Api20180501]
  - Type `String`
  - Value `Int32?`

### TagDetails [Api20180501]
  - CountType `String`
  - CountValue `Int32?`
  - Id `String`
  - TagName `String`
  - Value `ITagValue[]`

### TagsListResult [Api20180501]
  - NextLink `String`
  - Value `ITagDetails[]`

### TagValue [Api20180501]
  - CountType `String`
  - CountValue `Int32?`
  - Id `String`
  - TagValue1 `String`

### TargetResource [Api20180501]
  - Id `String`
  - ResourceName `String`
  - ResourceType `String`

### TemplateLink [Api20180501]
  - ContentVersion `String`
  - Uri `String`

### TenantBackfillStatusResult [Api20180301Preview]
  - Status `Status?` **{Cancelled, Completed, Failed, NotStarted, NotStartedButGroupsExist, Started}**
  - TenantId `String`

### TenantIdDescription [Api20160601]
  - Id `String`
  - TenantId `String`

### TenantListResult [Api20160601]
  - NextLink `String`
  - Value `ITenantIdDescription[]`

### User \<Object\> [Api16]
  - AccountEnabled `Boolean?`
  - DeletionTimestamp `DateTime?` **{MinValue, MaxValue}**
  - DisplayName `String`
  - GivenName `String`
  - ImmutableId `String`
  - Mail `String`
  - MailNickname `String`
  - ObjectId `String`
  - ObjectType `String`
  - PrincipalName `String`
  - SignInName `ISignInName[]`
  - Surname `String`
  - Type `UserType?` **{Guest, Member}**
  - UsageLocation `String`

### UserBase \<Object\> [Api16]
  - GivenName `String`
  - ImmutableId `String`
  - Surname `String`
  - UsageLocation `String`
  - UserType `UserType?` **{Guest, Member}**

### UserCreateParameters \<Object\> [Api16]
  - AccountEnabled `Boolean`
  - DisplayName `String`
  - GivenName `String`
  - ImmutableId `String`
  - Mail `String`
  - MailNickname `String`
  - PasswordProfile `IPasswordProfile <Object>`
  - Surname `String`
  - UsageLocation `String`
  - UserPrincipalName `String`
  - UserType `UserType?` **{Guest, Member}**

### UserGetMemberGroupsParameters \<Object\> [Api16]
  - SecurityEnabledOnly `Boolean`

### UserGetMemberGroupsResult [Api16]
  - Value `String[]`

### UserListResult [Api16]
  - OdataNextLink `String`
  - Value `IUser[]`

### UserUpdateParameters \<Object\> [Api16]
  - AccountEnabled `Boolean?`
  - DisplayName `String`
  - GivenName `String`
  - ImmutableId `String`
  - MailNickname `String`
  - PasswordProfile `IPasswordProfile <Object>`
  - Surname `String`
  - UsageLocation `String`
  - UserPrincipalName `String`
  - UserType `UserType?` **{Guest, Member}**

