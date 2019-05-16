## Generated

### Resources

#### Resources

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzResource` | No | - `-Top` parameter doesn't work<br>- `-Filter` should be removed in favor of additional variants<br> - Providing a value for `-ResourceId` returns "NoRegisteredProviderFound" -- need to determine a way to use a different API version in this scenario |
| `Get-AzResourceLink` | Yes | - `-Filter` should be removed in favor of variants |
| `Move-AzResource` | No | - Sanitizing the parameters results in the `-Resources` parameter being changed to `-S`<br>- `-TargetResourceGroup` is the id of the resource group -- we should rename this or break it up into components<br>- `-SourceResourceGroupName` seems unnecessary since it can be parsed from the id(s) of the resource(s) being moved |
| `New-AzResource` | No | - Do we introduce a hashtable `-Plan` parameter that consolidates all plan parameters? (five total)<br>- Do we introduce a hashtable `-Sku` parameter that consolidates all sku parameters? (six total)<br>- Don't bring over `-ExtensionResourceName` or `-ExtensionResourceType` (use `-ParentResourcePath`) |
| `New-AzResourceLink` | Yes |  |
| `Remove-AzResource` | No | - Don't bring over `-ExtensionResourceName` or `-ExtensionResourceType` (use `-ParentResourcePath`)<br>- Providing a value for `-ResourceId` returns "NoRegisteredProviderFound" -- need to determine a way to use a different API version in this scenario |
| `Remove-AzResourceLink` | Yes |  |
| `Set-AzResource` | No | - Do we introduce a hashtable `-Plan` parameter that consolidates all plan parameters? (five total)<br>- Do we introduce a hashtable `-Sku` parameter that consolidates all sku parameters? (six total)<br>- Don't bring over `-ExtensionResourceName` or `-ExtensionResourceType` (use `-ParentResourcePath`) |
| `Set-AzResourceLink` | Yes |  |
| `Test-AzResourceExistence` | Yes | - Should probably rename this to `Test-AzResource`<br>- Weird behavior - providing the id of a resource that exists will return an error (but the error isn't seen in the body of the response), but providing the id of a non-existent resource will return a success |
| `Test-AzResourceMove` | Yes | - Same comments as `Move-AzResource` |
| `Update-AzResource` | Yes | - Parameters should be cleaned up |

#### Resource Groups

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Export-AzResourceGroupTemplate` | No -`Export-AzResourceGroup` | - Cmdlet doesn't work without providing a value for `-Resources` (resource ids), which is an optional parameter, and even when providing a value for that parameter, the export operation still fails |
| `Get-AzResourceGroup` | No | - `-Top` parameter doesn't work<br> - `-Filter` should be removed in favor of additional variants (`-Tag`, `-TagName`, `-TagValue`)<br>- Potentially add `-Id` (or `-ResourceId`) parameter and parse resource group name |
| `New-AzResourceGroup` | No |  |
| `Remove-AzResourceGroup` | No |  |
| `Set-AzResourceGroup` | No | - Parameters should be cleaned up |
| `Test-AzResourceGroupExistence` | Yes | - No difference in command calls for existing and non-existing resource groups |
| `Update-AzResourceGroup` | Yes | - Parameters should be cleaned up |

#### Deployments

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Export-AzDeploymentTemplate` | No - also includes `Save-AzDeploymentTemplate` and `Save-AzResourceGroupDeploymentTemplate` |  |
| `Get-AzDeployment` | No - also includes `Get-AzResourceGroupDeployment` |  |
| `Get-AzDeploymentOperation` | No - also includes `Get-AzResourceGroupDeploymentOperation` |  |
| `New-AzDeployment` | No - also includes `New-AzResourceGroupDeployment` | - Variants should be created to introduce `-TemplateParameterObject`, `-TemplateParameterFile`, `-TemplateParameterUri`, `-TemplateObject`, `-TemplateFile` and `-TemplateUri` |
| `Remove-AzDeployment` | No - also includes `Remove-AzResourceGroupDeployment` | - Should we add `-Id` parameter? How to make differentiation from RG deployment?<br>- Look into variants that add `-InputObject` |
| `Set-AzDeployment` | Yes |  |
| `Stop-AzDeployment` | No - also includes `Stop-AzResourceGroupDeployment` | - Should we add `-Id` parameter? How to make differentiation from RG deployment?<br>- Look into variants that add `-InputObject` |
| `Test-AzDeployment` | No - also includes `Test-AzResourceGroupDeployment` | - Variants should be created to introduce `-TemplateParameterObject`, `-TemplateParameterFile`, `-TemplateParameterUri`, `-TemplateObject`, `-TemplateFile` and `-TemplateUri` |
| `Test-AzDeploymentExistence` | Yes |  |

#### Managed Application

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzManagedApplication` | No |  |
| `Get-AzManagedApplicationDefinition` | No |  |
| `New-AzManagedApplication` | No | - Don't bring over `-ManagedResourceGroupName` (can use `-ManagedResourceGroupId`), `-ManagedApplicationDefinitionId` (can use `-DefinitionId`) or `-Parameter` (can use new `-Parameters` parameter with better type) |
| `New-AzManagedApplicationDefinition` | No | |
| `Remove-AzManagedApplication` | No | - Don't bring over `-GroupName` (use `-GroupId`)<br>- Look into variant that adds `-InputObject` |
| `Remove-AzManagedApplicationDefinition` | No | - Don't bring over `-GroupName` (use `-GroupId`) |
| `Set-AzManagedApplication` | No | - Don't bring over `-ManagedResourceGroupName` (use `-ManagedResourceGroupId`) or `-ManagedApplicationDefinitionId` (use `-Id`) |
| `Set-AzManagedApplicationDefinition` | No |  |
| `Update-AzManagedApplication` | Yes |  |

#### Policy

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzPolicyAssignment` | No | - Add variants for `-PolicyDefinitionId` (`$filter=policyDefinition eq 'foo'`) and `-IncludeDescendent` (`$filter=atScope()`) |
| `Get-AzPolicyDefinition` | No |  |
| `Get-AzPolicyDefinitionBuilt` | Yes | - See if this can be merged into `Get-AzPolicyDefinition` |
| `Get-AzPolicySetDefinition` | No |  |
| `Get-AzPolicySetDefinitionBuilt` | Yes | - See if this can be merged into `Get-AzPolicySetDefinition` |
| `New-AzPolicyAssignment` | No | - Don't bring over `-AssignIdentity` (use `-IdentityType`), `-PolicyParameter` (use `-Parameters`) or `-PolicyDefinition` (use `-PolicyDefinitionId`)<br>- Add alias for `-PolicySetDefinitionId` to `-PolicyDefinition` |
| `New-AzPolicyDefinition` | No | - Don't bring over `-Policy` (use `-PolicyRule`) or `-ManagementGroupName` (use `-ManagementGroupId`) |
| `New-AzPolicySetDefinition` | No | - Don't bring over `-ManagementGroupName` (use `-ManagementGroupId`) |
| `Remove-AzPolicyAssignment` | No |  |
| `Remove-AzPolicyDefinition` | No | - Don't bring over `-ManagementGroupName` (use `-ManagementGroupId`) |
| `Remove-AzPolicySetDefinition` | No | - Don't bring over `-ManagementGroupName` (use `-ManagementGroupId`) |
| `Set-AzPolicyDefinition` | No | - Don't bring over `-ManagementGroupName` (use `-ManagementGroupId`) or `-Policy` (use `-PolicyRule`) |
| `Set-AzPolicySetDefinition` | No | - Don't bring over `-ManagementGroupName` (use `-ManagementGroupId`) |

#### Provider

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzProvider` | No - `Get-AzResourceProvider` | - Look into hiding `-Expand` and creating a new variant to call it |
| `Get-AzProviderFeature` | No | - Shows all features by default where `Az.Resources` implementation only shows registered features and provides `-ListAvailable` switch to show all |
| `Get-AzResourceProviderOperationDetail` | Yes | - Cmdlet fails due to incorrect API version being used |
| `Register-AzProvider` | No - `Register-AzResourceProvider` |  |
| `Register-AzProviderFeature` | No | - Don't bring over `-ProviderNamespace` (use `-ResourceProviderNamespace`) |
| `Unregister-AzProvider` | No - `Unregister-AzResourceProvider` |  |

#### Tag

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzTag` | No | - Don't bring over `-Name` or `-Detailed` parameters |
| `New-AzTag` | No | - Need to combine with `New-AzTagValue` |
| `New-AzTagValue` | Yes | - This cmdlet should be merged into `New-AzTag` |
| `Remove-AzTag` | No | - Need to combine with `Remove-AzTagValue` |
| `Remove-AzTagValue` | Yes | - This cmdlet should be merged into `Remove-AzTag` |
| `Set-AzTag` | Yes | - Need to combine with `Set-AzTag` |
| `Set-AzTagValue` | Yes | - This cmdlet should be merged into `Set-AzTag` |

#### Other

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzAuthorizationOperation` | Yes | - Always fails since given API version is not supported for the operation |
| `Get-AzManagementLock` | Yes |  |
| `Get-AzSubscriptionLocation` | Yes |  |
| `Get-AzTenant` | No - found in `Az.Accounts` |  |
| `New-AzManagementLock` | Yes |  |
| `Remove-AzManagementLock` | Yes |  |
| `Set-AzManagementLock` | Yes |  |





### Graph

#### General

- Cmdlets currently do not work -- "The given header was not found"
- Need to add support for `-ApplicationId` parameters

#### Application

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Add-AzADApplicationOwner` | Yes |  |
| `Get-AzADApplication` | No | - Possible variants for `-DisplayNameStartsWith` and `-IdentifierUri` |
| `Get-AzADApplicationKeyCredential` | No - `Get-AzADAppCredential` | - Should be combined with `Get-AzADApplicationPasswordCredential` |
| `Get-AzADApplicationOwner` | Yes |  |
| `Get-AzADApplicationPasswordCredential` | No - `Get-AzADAppCredential` | - Should be combined with `Get-AzADApplicationKeyCredential` |
| `Get-AzADApplicationServicePrincipalId` | Yes | - Should this be kept? If so, rename to `Get-AzADObjectId` |
| `Get-AzDeletedApplication` | Yes | - This should be bundled with `Get-AzADApplication` as a switch to include deleted applications |
| `New-AzADApplication` | No | - Don't bring over `-Password` parameter<br>- Add parameters around creating a key credential (`-CertValue`, `-StartDate`, `-EndDate`) |
| `Remove-AzADApplication` | No | - Look into variants that add `-ApplicationId`, `-DisplayName` and `-InputObject` |
| `Remove-AzADApplicationOwner` | Yes |  |
| `Remove-AzDeletedApplicationHard` | Yes | - This should be bundled with `Remove-AzADApplication` as a switch to include deleted applications |
| `Restore-AzDeletedApplication` | Yes |  |
| `Update-AzADApplication` | No | - Look into variants that add `-ApplicationId` and `-InputObject` |
| `Update-AzADApplicationKeyCredential` | No - `New-AzADAppCredential` | - Should be combined with `Update-AzADApplicationPasswordCredential` |
| `Update-AzADApplicationPasswordCredential` | No - `New-AzADAppCredential` | - Should be combined with `Update-AzADApplicationKeyCredential` |

#### Group

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Add-AzADGroupMember` | No | - Need to remove `-Url` parameter and introduce variant that allows user to provide pieces of URL to make request to add member |
| `Add-AzADGroupOwner` | Yes | - Need to remove `-Url` parameter and introduce variant that allows user to provide pieces of URL to make request to add owner |
| `Get-AzADGroup` | No | - Possible variant for `-DisplayNameStartsWith` |
| `Get-AzADGroupMember` | No | - Possibly rename `-ObjectId` to `-GroupObjectId`<br>- Add `-DisplayName` (or `-GroupDisplayName`) and `-GroupObject` parameters |
| `Get-AzADGroupOwner` | Yes | - Possibly combine with `Get-AzADGroupMember` as a separate parameter set |
| `New-AzADGroup` | No |  |
| `Remove-AzADGroup` | No | - Look into variants that add `-DisplayName` and `-InputObject` |
| `Remove-AzADGroupMember` | No | - Look into variants that add `-MemberUserPrincipalName`, `-GroupDisplayName` and `-GroupObject` |
| `Remove-AzADGroupOwner` | Yes |  |
| `Test-AzADGroupMember` | Yes |  |

#### Service Principal

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzADServicePrincipal` | No | - Possible variants for `-DisplayNameStartsWith` and `-ServicePrincipalName` |
| `Get-AzADServicePrincipalKeyCredential` | No - `Get-AzADSpCredential` | - Should be combined with `Get-AzADServicePrincipalPasswordCredential` |
| `Get-AzADServicePrincipalOwner` | Yes | - Possibly combine this into the result of `Get-AzADServicePrincipal` |
| `Get-AzADServicePrincipalPasswordCredential` | No - `Get-AzADSpCredential` | - Should be combined with `Get-AzADServicePrincipalKeyCredential` |
| `New-AzADServicePrincipal` | No | - Add variants for `-ApplicationId`, `-DisplayName`, `-ApplicationObject` using `-Filter` parameter<br>- Add variants for key credential (`-CertValue`, `-StartDate`, `-EndDate`)<br>- Add variants for providing `-Scope`, `-Role` and `-SkipAssignment` |
| `Remove-AzADServicePrincipal` | No | - Look into variants that add `-ApplicationId`, `-ServicePrincipalName`, `-DisplayName`, `-InputObject` and `-ApplicationObject` |
| `Update-AzADServicePrincipal` | No | - `-AccountEnabled` and `-AppRoleAssignmentRequired` should be switches<br>- `-Tag` should be a hashtable<br>- Look into getting missing parameters from existing cmdlet |
| `Update-AzADServicePrincipalKeyCredential` | No - `New-AzADSpCredential` | - Should be combined with `Update-AzADServicePrincipalPasswordCredential` |
| `Update-AzADServicePrincipalPasswordCredential` | No - `New-AzADSpCredential` | - Should be combined with `Update-AzADServicePrincipalKeyCredential` |

#### User

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzADUser` | No | - Possibly split `-UpnOrObjectId` into separate parameters `-ObjectId` and `-UserPrincipalName`<br>- Possibly add variants for `-Mail` and `-StartsWith` |
| `Get-AzADUserMemberGroup` | Yes | - Default parameter set is incorrect<br>- `-SecurityEnabledOnly` should be a switch |
| `Get-AzSignedInUser` | Yes | - This needs testing, it should probably be removed |
| `Get-AzSignedInUserOwnedObject` | Yes | - This needs testing, it should probably be removed |
| `New-AzADUser` | No | - Don't bring over `-Password` parameter<br>- Should we flatten `-PasswordProfile` or remove it? This would also prevent us from bringing over `-ForceChangePasswordNextLogin` |
| `Remove-AzADUser` | No | - Possibly split `-UpnOrObjectId` into separate parameters<br>- Look into variants that add `-DisplayName` and `-InputObject` |
| `Update-AzADUser` | No | - Don't bring over `-EnableAccount` (use `-AccountEnabled`), or `-Password` and `-ForceChangePasswordNextLogin` (use `-PasswordProfile`, if we decide to keep)<br>- Make sure that `-AccountEnabled` is a switch parameter |

#### OAuth2

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzOAuth2PermissionGrant` | Yes | - This needs testing, not sure if this should be kept |
| `New-AzOAuth2PermissionGrant` | Yes | - This needs testing, not sure if this should be kept |
| `Remove-AzOAuth2PermissionGrant` | Yes | - This needs testing, not sure if this should be kept |

#### Other

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzADObject` | Yes | - This needs testing, not sure if this should be kept<br>- `-IncludeDirectoryObjectReferences` should be a switch |
| `Get-AzDomain` | Yes | - This needs testing, not sure if this should be kept |





### Management Group

#### General

- Do not have proper permissions to run these cmdlets -- need to investigate if that's due to how the cmdlets were generated
- Check if `-GroupId` is the same thing as `-GroupName`

#### Management Group

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzMagnagementGroup` | No |  |
| `New-AzManagementGroup` | No | - Don't bring over `-GroupName` (use `-GroupId`) |
| `New-AzManagementGroupSubscription` | No | - Don't bring over `-GroupName` (use `-GroupId`) |
| `Remove-AzManagementGroup` | No |  |
| `Remove-AzManagementGroupSubscription` | No |  |
| `Set-AzManagementGroup` | Yes | - This should probably be removed in favor of `Update-AzManagementGroup` |
| `Update-AzManagementGroup` | No | - Don't bring over `-GroupName` (use `-GroupId`)<br>- Look into variants that add `-InputObject` |

#### Other

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzEntity` | Yes | - A lot of parameter sets |
| `Invoke-AzTenantBackfillStatus` | Yes |  |
| `Start-AzTenantBackfill` | Yes |  |
| `Test-AzNameAvailability` | Yes | - Running with no parameters returns "BadRequest - Unsupported resource type specified: " |





### Authorization

#### Role Assignment

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzRoleAssignment` | No | - Need to look at adding `RoleDefinitionName` as a parameter and a property of the output type<br>- Remove `-Filter` parameter and see if we can add variants to leverage the functionality |
| `New-AzRoleAssignment` | No | - Remove `-ResourceGroupName`, `-ResourceName`, `-ResourceType` and `-ParentResource` in favor of `-Scope`<br>- Look to see if we can remove `-RoleDefinitionName` in favor of `-RoleDefinitionId` |
| `Remove-AzRoleAssignment` | No | - Remove `-ResourceGroupName`, `-ResourceName`, `-ResourceType` and `-ParentResource` in favor of `-Scope`<br>- Can we add variants for `-RoleDefinitionName` and `-RoleDefinitionId`? |

#### Role Definition

- Cmdlets fail with error "The request did not have a subscription or a valid tenant level resource provider."

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzRoleDefinition` | No | - Add variant for `-Name` (use `-Filter`)<br>- Default parameter set should allow user to get all role definitions, which will involve the previous point about leveraging the removed `-Filter` parameter |
| `New-AzRoleDefinition` | No | - `-Id` parameter should be removed and should be a random GUID<br>- Add variant to allow the user to pass `-InputFile`<br>- See if we need to add `-Role` parameter |
| `Remove-AzRoleDefinition` | No | -Look into variants that add `-Name` and `-InputObject` |
| `Set-AzRoleDefinition` | No | - Add variant to allow the user to pass `-InputFile`<br>- See if we need to add `-Role` parameter |

#### Other

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzClassicAdministrator` | Yes | - Cmdlet fails due to API version: "The resource type 'classicAdministrators' could not be found in the namespace 'Microsoft.Authorization' for api version '2015-07-01'." |
| `Get-AzDenyAssignment` | Yes | - Cmdlet in `Az.Resources` is still in preview |
| `Get-AzPermission` | Yes |  |
| `Get-AzProviderOperationMetadata` | No - `Get-AzProviderOperation` |  |
| `Invoke-AzElevateAccess` | Yes |  |





## Not Generated

### Resources

#### Lock

- `Get-AzResourceLock`
- `New-AzResourceLock`
- `Remove-AzResourceLock`
- `Set-AzResourceLock`

#### Policy

- `Set-AzPolicyAssignment`

#### Other

- `Get-AzLocation`
- `Invoke-AzResourceAction`