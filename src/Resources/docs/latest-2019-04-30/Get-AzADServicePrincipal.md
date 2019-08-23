---
external help file:
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/get-azadserviceprincipal
schema: 2.0.0
---

# Get-AzADServicePrincipal

## SYNOPSIS
Gets service principal information from the directory.
Query by objectId or pass a filter to query by appId

## SYNTAX

### List (Default)
```
Get-AzADServicePrincipal -TenantId <String> [-Filter <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzADServicePrincipal -ObjectId <String> -TenantId <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetByApplicationId
```
Get-AzADServicePrincipal -TenantId <String> -ApplicationId <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetByApplicationObject
```
Get-AzADServicePrincipal -TenantId <String> -ApplicationObject <IApplication> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetByDisplayName
```
Get-AzADServicePrincipal -TenantId <String> -DisplayName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetByDisplayNamePrefix
```
Get-AzADServicePrincipal -TenantId <String> -DisplayNameBeginsWith <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetBySPN
```
Get-AzADServicePrincipal -TenantId <String> -ServicePrincipalName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzADServicePrincipal -InputObject <IResourcesIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets service principal information from the directory.
Query by objectId or pass a filter to query by appId

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -ApplicationId
The application id of the application.

```yaml
Type: System.String
Parameter Sets: GetByApplicationId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ApplicationObject
The object representation of the application.
To construct, see NOTES section for APPLICATIONOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IApplication
Parameter Sets: GetByApplicationObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DisplayName
The display name of the application.

```yaml
Type: System.String
Parameter Sets: GetByDisplayName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DisplayNameBeginsWith
The prefix of the display name of the application.

```yaml
Type: System.String
Parameter Sets: GetByDisplayNamePrefix
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Filter
The filter to apply to the operation.

```yaml
Type: System.String
Parameter Sets: List
Aliases: ODataQuery

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.IResourcesIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ObjectId
The object ID of the service principal to get.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ServicePrincipalName
The display name of the application.

```yaml
Type: System.String
Parameter Sets: GetBySPN
Aliases: SPN

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TenantId
The tenant ID.

```yaml
Type: System.String
Parameter Sets: Get, GetByApplicationId, GetByApplicationObject, GetByDisplayName, GetByDisplayNamePrefix, GetBySPN, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.IResourcesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IServicePrincipal

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### APPLICATIONOBJECT <IApplication>: The object representation of the application.
  - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[AllowGuestsSignIn <Boolean?>]`: A property on the application to indicate if the application accepts other IDPs or not or partially accepts.
  - `[AllowPassthroughUser <Boolean?>]`: Indicates that the application supports pass through users who have no presence in the resource tenant.
  - `[AppId <String>]`: The application ID.
  - `[AppLogoUrl <String>]`: The url for the application logo image stored in a CDN.
  - `[AppPermission <String[]>]`: The application permissions.
  - `[AppRole <IAppRole[]>]`: The collection of application roles that an application may declare. These roles can be assigned to users, groups or service principals.
    - `[AllowedMemberType <String[]>]`: Specifies whether this app role definition can be assigned to users and groups by setting to 'User', or to other applications (that are accessing this application in daemon service scenarios) by setting to 'Application', or to both. 
    - `[Description <String>]`: Permission help text that appears in the admin app assignment and consent experiences.
    - `[DisplayName <String>]`: Display name for the permission that appears in the admin consent and app assignment experiences.
    - `[Id <String>]`: Unique role identifier inside the appRoles collection.
    - `[IsEnabled <Boolean?>]`: When creating or updating a role definition, this must be set to true (which is the default). To delete a role, this must first be set to false. At that point, in a subsequent call, this role may be removed.
    - `[Value <String>]`: Specifies the value of the roles claim that the application should expect in the authentication and access tokens.
  - `[AvailableToOtherTenant <Boolean?>]`: Whether the application is available to other tenants.
  - `[DisplayName <String>]`: The display name of the application.
  - `[ErrorUrl <String>]`: A URL provided by the author of the application to report errors when using the application.
  - `[GroupMembershipClaim <GroupMembershipClaimTypes?>]`: Configures the groups claim issued in a user or OAuth 2.0 access token that the app expects.
  - `[Homepage <String>]`: The home page of the application.
  - `[IdentifierUri <String[]>]`: A collection of URIs for the application.
  - `[InformationalUrlMarketing <String>]`: The marketing URI
  - `[InformationalUrlPrivacy <String>]`: The privacy policy URI
  - `[InformationalUrlSupport <String>]`: The support URI
  - `[InformationalUrlTermsOfService <String>]`: The terms of service URI
  - `[IsDeviceOnlyAuthSupported <Boolean?>]`: Specifies whether this application supports device authentication without a user. The default is false.
  - `[KeyCredentials <IKeyCredential[]>]`: A collection of KeyCredential objects.
    - `[CustomKeyIdentifier <String>]`: Custom Key Identifier
    - `[EndDate <DateTime?>]`: End date.
    - `[KeyId <String>]`: Key ID.
    - `[StartDate <DateTime?>]`: Start date.
    - `[Type <String>]`: Type. Acceptable values are 'AsymmetricX509Cert' and 'Symmetric'.
    - `[Usage <String>]`: Usage. Acceptable values are 'Verify' and 'Sign'.
    - `[Value <String>]`: Key value.
  - `[KnownClientApplication <String[]>]`: Client applications that are tied to this resource application. Consent to any of the known client applications will result in implicit consent to the resource application through a combined consent dialog (showing the OAuth permission scopes required by the client and the resource).
  - `[LogoutUrl <String>]`: the url of the logout page
  - `[Oauth2AllowImplicitFlow <Boolean?>]`: Whether to allow implicit grant flow for OAuth2
  - `[Oauth2AllowUrlPathMatching <Boolean?>]`: Specifies whether during a token Request Azure AD will allow path matching of the redirect URI against the applications collection of replyURLs. The default is false.
  - `[Oauth2Permission <IOAuth2Permission[]>]`: The collection of OAuth 2.0 permission scopes that the web API (resource) application exposes to client applications. These permission scopes may be granted to client applications during consent.
    - `[AdminConsentDescription <String>]`: Permission help text that appears in the admin consent and app assignment experiences.
    - `[AdminConsentDisplayName <String>]`: Display name for the permission that appears in the admin consent and app assignment experiences.
    - `[Id <String>]`: Unique scope permission identifier inside the oauth2Permissions collection.
    - `[IsEnabled <Boolean?>]`: When creating or updating a permission, this property must be set to true (which is the default). To delete a permission, this property must first be set to false. At that point, in a subsequent call, the permission may be removed. 
    - `[Type <String>]`: Specifies whether this scope permission can be consented to by an end user, or whether it is a tenant-wide permission that must be consented to by a Company Administrator. Possible values are "User" or "Admin".
    - `[UserConsentDescription <String>]`: Permission help text that appears in the end user consent experience.
    - `[UserConsentDisplayName <String>]`: Display name for the permission that appears in the end user consent experience.
    - `[Value <String>]`: The value of the scope claim that the resource application should expect in the OAuth 2.0 access token.
  - `[Oauth2RequirePostResponse <Boolean?>]`: Specifies whether, as part of OAuth 2.0 token requests, Azure AD will allow POST requests, as opposed to GET requests. The default is false, which specifies that only GET requests will be allowed.
  - `[OptionalClaimAccessToken <IOptionalClaim[]>]`: Optional claims requested to be included in the access token.
    - `[AdditionalProperty <IOptionalClaimAdditionalProperties>]`: 
    - `[Essential <Boolean?>]`: Is this a required claim.
    - `[Name <String>]`: Claim name.
    - `[Source <String>]`: Claim source.
  - `[OptionalClaimIdToken <IOptionalClaim[]>]`: Optional claims requested to be included in the id token.
  - `[OptionalClaimSamlToken <IOptionalClaim[]>]`: Optional claims requested to be included in the saml token.
  - `[OrgRestriction <String[]>]`: A list of tenants allowed to access application.
  - `[PasswordCredentials <IPasswordCredential[]>]`: A collection of PasswordCredential objects
    - `[CustomKeyIdentifier <Byte[]>]`: Custom Key Identifier
    - `[EndDate <DateTime?>]`: End date.
    - `[KeyId <String>]`: Key ID.
    - `[StartDate <DateTime?>]`: Start date.
    - `[Value <String>]`: Key value.
  - `[PreAuthorizedApplication <IPreAuthorizedApplication[]>]`: list of pre-authorized applications.
    - `[AppId <String>]`: Represents the application id.
    - `[Extension <IPreAuthorizedApplicationExtension[]>]`: Collection of extensions from the resource application.
      - `[Condition <String[]>]`: The extension's conditions.
    - `[Permission <IPreAuthorizedApplicationPermission[]>]`: Collection of required app permissions/entitlements from the resource application.
      - `[AccessGrant <String[]>]`: The list of permissions.
      - `[DirectAccessGrant <Boolean?>]`: Indicates whether the permission set is DirectAccess or impersonation.
  - `[PublicClient <Boolean?>]`: Specifies whether this application is a public client (such as an installed application running on a mobile device). Default is false.
  - `[PublisherDomain <String>]`: Reliable domain which can be used to identify an application.
  - `[ReplyUrl <String[]>]`: A collection of reply URLs for the application.
  - `[RequiredResourceAccess <IRequiredResourceAccess[]>]`: Specifies resources that this application requires access to and the set of OAuth permission scopes and application roles that it needs under each of those resources. This pre-configuration of required resource access drives the consent experience.
    - `ResourceAccess <IResourceAccess[]>`: The list of OAuth2.0 permission scopes and app roles that the application requires from the specified resource.
      - `Id <String>`: The unique identifier for one of the OAuth2Permission or AppRole instances that the resource application exposes.
      - `[Type <String>]`: Specifies whether the id property references an OAuth2Permission or an AppRole. Possible values are "scope" or "role".
    - `[ResourceAppId <String>]`: The unique identifier for the resource that the application requires access to. This should be equal to the appId declared on the target resource application.
  - `[SamlMetadataUrl <String>]`: The URL to the SAML metadata for the application.
  - `[SignInAudience <String>]`: Audience for signing in to the application (AzureADMyOrganization, AzureADAllOrganizations, AzureADAndMicrosoftAccounts).
  - `[WwwHomepage <String>]`: The primary Web page.

#### INPUTOBJECT <IResourcesIdentity>: Identity Parameter
  - `[ApplianceDefinitionId <String>]`: The fully qualified ID of the appliance definition, including the appliance name and the appliance definition resource type. Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/Microsoft.Solutions/applianceDefinitions/{applianceDefinition-name}
  - `[ApplianceDefinitionName <String>]`: The name of the appliance definition.
  - `[ApplianceId <String>]`: The fully qualified ID of the appliance, including the appliance name and the appliance resource type. Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/Microsoft.Solutions/appliances/{appliance-name}
  - `[ApplianceName <String>]`: The name of the appliance.
  - `[ApplicationDefinitionId <String>]`: The fully qualified ID of the managed application definition, including the managed application name and the managed application definition resource type. Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/Microsoft.Solutions/applicationDefinitions/{applicationDefinition-name}
  - `[ApplicationDefinitionName <String>]`: The name of the managed application definition.
  - `[ApplicationId <String>]`: The application ID.
  - `[ApplicationId1 <String>]`: The fully qualified ID of the managed application, including the managed application name and the managed application resource type. Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/Microsoft.Solutions/applications/{application-name}
  - `[ApplicationName <String>]`: The name of the managed application.
  - `[ApplicationObjectId <String>]`: Application object ID.
  - `[DenyAssignmentId <String>]`: The ID of the deny assignment to get.
  - `[DeploymentName <String>]`: The name of the deployment.
  - `[DomainName <String>]`: name of the domain.
  - `[FeatureName <String>]`: The name of the feature to get.
  - `[GroupId <String>]`: Management Group ID.
  - `[GroupObjectId <String>]`: The object ID of the group from which to remove the member.
  - `[Id <String>]`: Resource identity path
  - `[LinkId <String>]`: The fully qualified ID of the resource link. Use the format, /subscriptions/{subscription-id}/resourceGroups/{resource-group-name}/{provider-namespace}/{resource-type}/{resource-name}/Microsoft.Resources/links/{link-name}. For example, /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myGroup/Microsoft.Web/sites/mySite/Microsoft.Resources/links/myLink
  - `[LockName <String>]`: The name of lock.
  - `[ManagementGroupId <String>]`: The ID of the management group.
  - `[MemberObjectId <String>]`: Member object id
  - `[ObjectId <String>]`: Application object ID.
  - `[OperationId <String>]`: The ID of the operation to get.
  - `[OwnerObjectId <String>]`: Owner object id
  - `[ParentResourcePath <String>]`: The parent resource identity.
  - `[PolicyAssignmentId <String>]`: The ID of the policy assignment to delete. Use the format '{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}'.
  - `[PolicyAssignmentName <String>]`: The name of the policy assignment to delete.
  - `[PolicyDefinitionName <String>]`: The name of the policy definition to create.
  - `[PolicySetDefinitionName <String>]`: The name of the policy set definition to create.
  - `[ResourceGroupName <String>]`: The name of the resource group that contains the resource to delete. The name is case insensitive.
  - `[ResourceId <String>]`: The fully qualified ID of the resource, including the resource name and resource type. Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}
  - `[ResourceName <String>]`: The name of the resource to delete.
  - `[ResourceProviderNamespace <String>]`: The namespace of the resource provider.
  - `[ResourceType <String>]`: The resource type.
  - `[RoleAssignmentId <String>]`: The ID of the role assignment to delete.
  - `[RoleAssignmentName <String>]`: The name of the role assignment to delete.
  - `[RoleDefinitionId <String>]`: The ID of the role definition to delete.
  - `[RoleId <String>]`: The ID of the role assignment to delete.
  - `[Scope <String>]`: The scope for the lock. 
  - `[SourceResourceGroupName <String>]`: The name of the resource group containing the resources to move.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[TagName <String>]`: The name of the tag.
  - `[TagValue <String>]`: The value of the tag to delete.
  - `[TenantId <String>]`: The tenant ID.
  - `[UpnOrObjectId <String>]`: The object ID or principal name of the user for which to get information.

## RELATED LINKS

