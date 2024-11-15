### AzADApplication [Get, New, Remove, Update] `IApplication, Boolean`
  - TenantId `String`
  - ObjectId `String`
  - IncludeDeleted `SwitchParameter`
  - InputObject `IResourcesIdentity`
  - HardDelete `SwitchParameter`
  - Filter `String`
  - IdentifierUri `String`
  - DisplayNameStartWith `String`
  - DisplayName `String`
  - ApplicationId `String`
  - AllowGuestsSignIn `SwitchParameter`
  - AllowPassthroughUser `SwitchParameter`
  - AppLogoUrl `String`
  - AppPermission `String[]`
  - AppRole `IAppRole[]`
  - AvailableToOtherTenants `SwitchParameter`
  - ErrorUrl `String`
  - GroupMembershipClaim `GroupMembershipClaimTypes`
  - Homepage `String`
  - InformationalUrlMarketing `String`
  - InformationalUrlPrivacy `String`
  - InformationalUrlSupport `String`
  - InformationalUrlTermsOfService `String`
  - IsDeviceOnlyAuthSupported `SwitchParameter`
  - KeyCredentials `IKeyCredential[]`
  - KnownClientApplication `String[]`
  - LogoutUrl `String`
  - Oauth2AllowImplicitFlow `SwitchParameter`
  - Oauth2AllowUrlPathMatching `SwitchParameter`
  - Oauth2Permission `IOAuth2Permission[]`
  - Oauth2RequirePostResponse `SwitchParameter`
  - OptionalClaimAccessToken `IOptionalClaim[]`
  - OptionalClaimIdToken `IOptionalClaim[]`
  - OptionalClaimSamlToken `IOptionalClaim[]`
  - OrgRestriction `String[]`
  - PasswordCredentials `IPasswordCredential[]`
  - PreAuthorizedApplication `IPreAuthorizedApplication[]`
  - PublicClient `SwitchParameter`
  - PublisherDomain `String`
  - ReplyUrl `String[]`
  - RequiredResourceAccess `IRequiredResourceAccess[]`
  - SamlMetadataUrl `String`
  - SignInAudience `String`
  - WwwHomepage `String`
  - Parameter `IApplicationCreateParameters`
  - PassThru `SwitchParameter`
  - AvailableToOtherTenant `SwitchParameter`

### AzADApplicationOwner [Add, Get, Remove] `Boolean, IDirectoryObject`
  - ObjectId `String`
  - TenantId `String`
  - InputObject `IResourcesIdentity`
  - OwnerObjectId `String`
  - AdditionalProperties `Hashtable`
  - Url `String`
  - Parameter `IAddOwnerParameters`

### AzADDeletedApplication [Restore] `IApplication`
  - ObjectId `String`
  - TenantId `String`
  - InputObject `IResourcesIdentity`

### AzADGroup [Get, New, Remove] `IAdGroup, Boolean`
  - TenantId `String`
  - ObjectId `String`
  - InputObject `IResourcesIdentity`
  - Filter `String`
  - DisplayNameStartsWith `String`
  - DisplayName `String`
  - AdditionalProperties `Hashtable`
  - MailNickname `String`
  - Parameter `IGroupCreateParameters`
  - PassThru `SwitchParameter`

### AzADGroupMember [Add, Get, Remove, Test] `Boolean, IDirectoryObject, SwitchParameter`
  - GroupObjectId `String`
  - TenantId `String`
  - MemberObjectId `String[]`
  - MemberUserPrincipalName `String[]`
  - GroupObject `IAdGroup`
  - GroupDisplayName `String`
  - InputObject `IResourcesIdentity`
  - ObjectId `String`
  - ShowOwner `SwitchParameter`
  - PassThru `SwitchParameter`
  - AdditionalProperties `Hashtable`
  - Url `String`
  - Parameter `IGroupAddMemberParameters`
  - DisplayName `String`
  - GroupId `String`
  - MemberId `String`

### AzADGroupMemberGroup [Get] `String`
  - ObjectId `String`
  - TenantId `String`
  - InputObject `IResourcesIdentity`
  - AdditionalProperties `Hashtable`
  - SecurityEnabledOnly `SwitchParameter`
  - Parameter `IGroupGetMemberGroupsParameters`

### AzADGroupOwner [Add, Remove] `Boolean`
  - ObjectId `String`
  - TenantId `String`
  - GroupObjectId `String`
  - MemberObjectId `String[]`
  - InputObject `IResourcesIdentity`
  - OwnerObjectId `String`
  - PassThru `SwitchParameter`
  - AdditionalProperties `Hashtable`
  - Url `String`
  - Parameter `IAddOwnerParameters`

### AzADObject [Get] `IDirectoryObject`
  - TenantId `String`
  - InputObject `IResourcesIdentity`
  - AdditionalProperties `Hashtable`
  - IncludeDirectoryObjectReference `SwitchParameter`
  - ObjectId `String[]`
  - Type `String[]`
  - Parameter `IGetObjectsParameters`

### AzADServicePrincipal [Get, New, Remove, Update] `IServicePrincipal, Boolean`
  - TenantId `String`
  - ObjectId `String`
  - InputObject `IResourcesIdentity`
  - Filter `String`
  - ApplicationObject `IApplication`
  - ServicePrincipalName `String`
  - DisplayNameBeginsWith `String`
  - DisplayName `String`
  - ApplicationId `String`
  - AccountEnabled `SwitchParameter`
  - AppId `String`
  - AppRoleAssignmentRequired `SwitchParameter`
  - KeyCredentials `IKeyCredential[]`
  - PasswordCredentials `IPasswordCredential[]`
  - ServicePrincipalType `String`
  - Tag `String[]`
  - Parameter `IServicePrincipalCreateParameters`
  - PassThru `SwitchParameter`

### AzADServicePrincipalOwner [Get] `IDirectoryObject`
  - ObjectId `String`
  - TenantId `String`

### AzADUser [Get, New, Remove, Update] `IUser, Boolean`
  - TenantId `String`
  - UpnOrObjectId `String`
  - InputObject `IResourcesIdentity`
  - Filter `String`
  - DisplayName `String`
  - StartsWith `String`
  - Mail `String`
  - MailNickname `String`
  - Parameter `IUserCreateParameters`
  - AccountEnabled `SwitchParameter`
  - GivenName `String`
  - ImmutableId `String`
  - PasswordProfile `IPasswordProfile`
  - Surname `String`
  - UsageLocation `String`
  - UserPrincipalName `String`
  - UserType `UserType`
  - PassThru `SwitchParameter`
  - EnableAccount `SwitchParameter`

### AzADUserMemberGroup [Get] `String`
  - ObjectId `String`
  - TenantId `String`
  - InputObject `IResourcesIdentity`
  - AdditionalProperties `Hashtable`
  - SecurityEnabledOnly `SwitchParameter`
  - Parameter `IUserGetMemberGroupsParameters`

### AzApplicationKeyCredentials [Get, Update] `IKeyCredential, Boolean`
  - ObjectId `String`
  - TenantId `String`
  - InputObject `IResourcesIdentity`
  - Parameter `IKeyCredentialsUpdateParameters`
  - Value `IKeyCredential[]`

### AzApplicationPasswordCredentials [Get, Update] `IPasswordCredential, Boolean`
  - ObjectId `String`
  - TenantId `String`
  - InputObject `IResourcesIdentity`
  - Parameter `IPasswordCredentialsUpdateParameters`
  - Value `IPasswordCredential[]`

### AzAuthorizationOperation [Get] `IOperation`

### AzClassicAdministrator [Get] `IClassicAdministrator`
  - SubscriptionId `String[]`

### AzDenyAssignment [Get] `IDenyAssignment`
  - Id `String`
  - Scope `String`
  - InputObject `IResourcesIdentity`
  - ParentResourcePath `String`
  - ResourceGroupName `String`
  - ResourceName `String`
  - ResourceProviderNamespace `String`
  - ResourceType `String`
  - SubscriptionId `String[]`
  - Filter `String`

### AzDeployment [Get, New, Remove, Set, Stop, Test] `IDeploymentExtended, Boolean, IDeploymentValidateResult`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - Id `String`
  - InputObject `IResourcesIdentity`
  - Filter `String`
  - Top `Int32`
  - Parameter `IDeployment`
  - DebugSettingDetailLevel `String`
  - Location `String`
  - Mode `DeploymentMode`
  - OnErrorDeploymentName `String`
  - OnErrorDeploymentType `OnErrorDeploymentType`
  - ParameterLinkContentVersion `String`
  - ParameterLinkUri `String`
  - Template `IDeploymentPropertiesTemplate`
  - TemplateLinkContentVersion `String`
  - TemplateLinkUri `String`
  - PassThru `SwitchParameter`

### AzDeploymentExistence [Test] `Boolean`
  - DeploymentName `String`
  - SubscriptionId `String`
  - ResourceGroupName `String`
  - InputObject `IResourcesIdentity`

### AzDeploymentOperation [Get] `IDeploymentOperation`
  - DeploymentName `String`
  - SubscriptionId `String[]`
  - ResourceGroupName `String`
  - OperationId `String`
  - DeploymentObject `IDeploymentExtended`
  - InputObject `IResourcesIdentity`
  - Top `Int32`

### AzDeploymentTemplate [Export] `IDeploymentExportResultTemplate`
  - DeploymentName `String`
  - SubscriptionId `String`
  - ResourceGroupName `String`
  - InputObject `IResourcesIdentity`

### AzDomain [Get] `IDomain`
  - TenantId `String`
  - Name `String`
  - InputObject `IResourcesIdentity`
  - Filter `String`

### AzElevateGlobalAdministratorAccess [Invoke] `Boolean`

### AzEntity [Get] `IEntityInfo`
  - Filter `String`
  - GroupName `String`
  - Search `String`
  - Select `String`
  - Skip `Int32`
  - Skiptoken `String`
  - Top `Int32`
  - View `String`
  - CacheControl `String`

### AzManagedApplication [Get, New, Remove, Set, Update] `IApplication, Boolean`
  - Id `String`
  - Name `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - InputObject `IResourcesIdentity`
  - Parameter `IApplication`
  - ApplicationDefinitionId `String`
  - IdentityType `ResourceIdentityType`
  - Kind `String`
  - Location `String`
  - ManagedBy `String`
  - ManagedResourceGroupId `String`
  - PlanName `String`
  - PlanProduct `String`
  - PlanPromotionCode `String`
  - PlanPublisher `String`
  - PlanVersion `String`
  - SkuCapacity `Int32`
  - SkuFamily `String`
  - SkuModel `String`
  - SkuName `String`
  - SkuSize `String`
  - SkuTier `String`
  - Tag `Hashtable`

### AzManagedApplicationDefinition [Get, New, Remove, Set] `IApplicationDefinition, Boolean`
  - Id `String`
  - Name `String`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - InputObject `IResourcesIdentity`
  - Parameter `IApplicationDefinition`
  - Artifact `IApplicationArtifact[]`
  - Authorization `IApplicationProviderAuthorization[]`
  - CreateUiDefinition `IApplicationDefinitionPropertiesCreateUiDefinition`
  - Description `String`
  - DisplayName `String`
  - IdentityType `ResourceIdentityType`
  - IsEnabled `String`
  - Location `String`
  - LockLevel `ApplicationLockLevel`
  - MainTemplate `IApplicationDefinitionPropertiesMainTemplate`
  - ManagedBy `String`
  - PackageFileUri `String`
  - SkuCapacity `Int32`
  - SkuFamily `String`
  - SkuModel `String`
  - SkuName `String`
  - SkuSize `String`
  - SkuTier `String`
  - Tag `Hashtable`

### AzManagementGroup [Get, New, Remove, Set, Update] `IManagementGroup, IManagementGroupInfo, Boolean`
  - GroupId `String`
  - InputObject `IResourcesIdentity`
  - Skiptoken `String`
  - Expand `String`
  - Filter `String`
  - Recurse `SwitchParameter`
  - CacheControl `String`
  - DisplayName `String`
  - Name `String`
  - ParentId `String`
  - CreateManagementGroupRequest `ICreateManagementGroupRequest`
  - PatchGroupRequest `IPatchManagementGroupRequest`

### AzManagementGroupDescendant [Get] `IDescendantInfo`
  - GroupId `String`
  - InputObject `IResourcesIdentity`
  - Skiptoken `String`
  - Top `Int32`

### AzManagementGroupSubscription [New, Remove] `Boolean`
  - GroupId `String`
  - SubscriptionId `String`
  - InputObject `IResourcesIdentity`
  - CacheControl `String`

### AzManagementLock [Get, New, Remove, Set] `IManagementLockObject, Boolean`
  - SubscriptionId `String[]`
  - LockName `String`
  - ResourceGroupName `String`
  - ParentResourcePath `String`
  - ResourceName `String`
  - ResourceProviderNamespace `String`
  - ResourceType `String`
  - Scope `String`
  - InputObject `IResourcesIdentity`
  - Filter `String`
  - Level `LockLevel`
  - Note `String`
  - Owner `IManagementLockOwner[]`
  - Parameter `IManagementLockObject`

### AzNameAvailability [Test] `ICheckNameAvailabilityResult`
  - Name `String`
  - Type `Type`
  - CheckNameAvailabilityRequest `ICheckNameAvailabilityRequest`

### AzOAuth2PermissionGrant [Get, New, Remove] `IOAuth2PermissionGrant, Boolean`
  - TenantId `String`
  - InputObject `IResourcesIdentity`
  - Filter `String`
  - ClientId `String`
  - ConsentType `ConsentType`
  - ExpiryTime `String`
  - ObjectId `String`
  - OdataType `String`
  - PrincipalId `String`
  - ResourceId `String`
  - Scope `String`
  - StartTime `String`
  - Body `IOAuth2PermissionGrant`

### AzPermission [Get] `IPermission`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - ParentResourcePath `String`
  - ResourceName `String`
  - ResourceProviderNamespace `String`
  - ResourceType `String`

### AzPolicyAssignment [Get, New, Remove] `IPolicyAssignment`
  - Id `String`
  - Name `String`
  - Scope `String`
  - InputObject `IResourcesIdentity`
  - ParentResourcePath `String`
  - ResourceGroupName `String`
  - ResourceName `String`
  - ResourceProviderNamespace `String`
  - ResourceType `String`
  - SubscriptionId `String[]`
  - PolicyDefinitionId `String`
  - IncludeDescendent `SwitchParameter`
  - Filter `String`
  - Parameter `IPolicyAssignment`
  - Description `String`
  - DisplayName `String`
  - IdentityType `ResourceIdentityType`
  - Location `String`
  - Metadata `IPolicyAssignmentPropertiesMetadata`
  - NotScope `String[]`
  - SkuName `String`
  - SkuTier `String`
  - PropertiesScope `String`

### AzPolicyDefinition [Get, New, Remove, Set] `IPolicyDefinition, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ManagementGroupName `String`
  - Id `String`
  - InputObject `IResourcesIdentity`
  - BuiltIn `SwitchParameter`
  - Parameter `IPolicyDefinition`
  - Description `String`
  - DisplayName `String`
  - Metadata `IPolicyDefinitionPropertiesMetadata`
  - Mode `PolicyMode`
  - PolicyRule `IPolicyDefinitionPropertiesPolicyRule`
  - PolicyType `PolicyType`
  - PassThru `SwitchParameter`

### AzPolicySetDefinition [Get, New, Remove, Set] `IPolicySetDefinition, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ManagementGroupName `String`
  - Id `String`
  - InputObject `IResourcesIdentity`
  - BuiltIn `SwitchParameter`
  - Parameter `IPolicySetDefinition`
  - Description `String`
  - DisplayName `String`
  - Metadata `IPolicySetDefinitionPropertiesMetadata`
  - PolicyDefinition `IPolicyDefinitionReference[]`
  - PolicyType `PolicyType`
  - PassThru `SwitchParameter`

### AzProviderFeature [Get, Register] `IFeatureResult`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceProviderNamespace `String`
  - InputObject `IResourcesIdentity`

### AzProviderOperationsMetadata [Get] `IProviderOperationsMetadata`
  - ResourceProviderNamespace `String`
  - InputObject `IResourcesIdentity`
  - Expand `String`

### AzResource [Get, Move, New, Remove, Set, Test, Update] `IGenericResource, Boolean`
  - ResourceId `String`
  - Name `String`
  - ParentResourcePath `String`
  - ProviderNamespace `String`
  - ResourceGroupName `String`
  - ResourceType `String`
  - SubscriptionId `String[]`
  - InputObject `IResourcesIdentity`
  - SourceResourceGroupName `String`
  - ResourceName `String`
  - ResourceProviderNamespace `String`
  - Expand `String`
  - Top `Int32`
  - TagName `String`
  - TagValue `String`
  - Tag `Hashtable`
  - Filter `String`
  - PassThru `SwitchParameter`
  - Resource `String[]`
  - TargetResourceGroup `String`
  - TargetSubscriptionId `String`
  - TargetResourceGroupName `String`
  - Parameter `IResourcesMoveInfo`
  - IdentityType `ResourceIdentityType`
  - IdentityUserAssignedIdentity `Hashtable`
  - Kind `String`
  - Location `String`
  - ManagedBy `String`
  - PlanName `String`
  - PlanProduct `String`
  - PlanPromotionCode `String`
  - PlanPublisher `String`
  - PlanVersion `String`
  - Property `IGenericResourceProperties`
  - SkuCapacity `Int32`
  - SkuFamily `String`
  - SkuModel `String`
  - SkuName `String`
  - SkuSize `String`
  - SkuTier `String`

### AzResourceGroup [Export, Get, New, Remove, Set, Test, Update] `IResourceGroupExportResult, IResourceGroup, Boolean`
  - ResourceGroupName `String`
  - SubscriptionId `String`
  - InputObject `IResourcesIdentity`
  - Name `String`
  - Id `String`
  - Filter `String`
  - Top `Int32`
  - TagName `String`
  - TagValue `String`
  - Tag `Hashtable`
  - Option `String`
  - Resource `String[]`
  - Parameter `IExportTemplateRequest`
  - Location `String`
  - ManagedBy `String`

### AzResourceLink [Get, New, Remove, Set] `IResourceLink, Boolean`
  - ResourceId `String`
  - InputObject `IResourcesIdentity`
  - SubscriptionId `String[]`
  - Scope `String`
  - FilterById `String`
  - FilterByScope `Filter`
  - Note `String`
  - TargetId `String`
  - Parameter `IResourceLink`

### AzResourceMove [Test] `Boolean`
  - SourceResourceGroupName `String`
  - SubscriptionId `String`
  - InputObject `IResourcesIdentity`
  - PassThru `SwitchParameter`
  - Resource `String[]`
  - TargetResourceGroup `String`
  - TargetSubscriptionId `String`
  - TargetResourceGroupName `String`
  - Parameter `IResourcesMoveInfo`

### AzResourceProvider [Get, Register, Unregister] `IProvider`
  - SubscriptionId `String[]`
  - ResourceProviderNamespace `String`
  - InputObject `IResourcesIdentity`
  - Expand `String`
  - Top `Int32`

### AzResourceProviderOperationDetail [Get] `IResourceProviderOperationDefinition`
  - ResourceProviderNamespace `String`

### AzRoleAssignment [Get, New, Remove] `IRoleAssignment`
  - Id `String`
  - Name `String`
  - Scope `String`
  - RoleId `String`
  - InputObject `IResourcesIdentity`
  - ParentResourceId `String`
  - ResourceGroupName `String`
  - ResourceName `String`
  - ResourceProviderNamespace `String`
  - ResourceType `String`
  - SubscriptionId `String[]`
  - ExpandPrincipalGroups `String`
  - ServicePrincipalName `String`
  - SignInName `String`
  - Filter `String`
  - CanDelegate `SwitchParameter`
  - PrincipalId `String`
  - RoleDefinitionId `String`
  - Parameter `IRoleAssignmentCreateParameters`
  - PrincipalType `PrincipalType`

### AzRoleDefinition [Get, New, Remove, Set] `IRoleDefinition`
  - Id `String`
  - Scope `String`
  - InputObject `IResourcesIdentity`
  - Name `String`
  - Custom `SwitchParameter`
  - Filter `String`
  - AssignableScope `String[]`
  - Description `String`
  - Permission `IPermission[]`
  - RoleName `String`
  - RoleType `String`
  - RoleDefinition `IRoleDefinition`

### AzSubscriptionLocation [Get] `ILocation`
  - SubscriptionId `String[]`

### AzTag [Get, New, Remove] `ITagDetails, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - Value `String`
  - InputObject `IResourcesIdentity`
  - PassThru `SwitchParameter`

### AzTenantBackfill [Start] `ITenantBackfillStatusResult`

### AzTenantBackfillStatus [Invoke] `ITenantBackfillStatusResult`

