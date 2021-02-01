---
external help file:
Module Name: Az.AD
online version: https://docs.microsoft.com/en-us/powershell/module/az.ad/update-azadapplication
schema: 2.0.0
---

# Update-AzADApplication

## SYNOPSIS
Update an existing application.

## SYNTAX

### PatchExpanded (Default)
```
Update-AzADApplication -ObjectId <String> -TenantId <String> [-AllowGuestsSignIn] [-AllowPassthroughUser]
 [-AppLogoUrl <String>] [-AppPermission <String[]>] [-AppRole <IAppRole[]>] [-AvailableToOtherTenant]
 [-DisplayName <String>] [-ErrorUrl <String>] [-GroupMembershipClaim <GroupMembershipClaimTypes>]
 [-Homepage <String>] [-IdentifierUri <String[]>] [-InformationalUrlMarketing <String>]
 [-InformationalUrlPrivacy <String>] [-InformationalUrlSupport <String>]
 [-InformationalUrlTermsOfService <String>] [-IsDeviceOnlyAuthSupported] [-KeyCredentials <IKeyCredential[]>]
 [-KnownClientApplication <String[]>] [-LogoutUrl <String>] [-Oauth2AllowImplicitFlow]
 [-Oauth2AllowUrlPathMatching] [-Oauth2Permission <IOAuth2Permission[]>] [-Oauth2RequirePostResponse]
 [-OptionalClaimAccessToken <IOptionalClaim[]>] [-OptionalClaimIdToken <IOptionalClaim[]>]
 [-OptionalClaimSamlToken <IOptionalClaim[]>] [-OrgRestriction <String[]>]
 [-PasswordCredentials <IPasswordCredential[]>] [-PreAuthorizedApplication <IPreAuthorizedApplication[]>]
 [-PublicClient] [-PublisherDomain <String>] [-ReplyUrl <String[]>]
 [-RequiredResourceAccess <IRequiredResourceAccess[]>] [-SamlMetadataUrl <String>] [-SignInAudience <String>]
 [-WwwHomepage <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Patch
```
Update-AzADApplication -ObjectId <String> -TenantId <String> -Parameter <IApplicationUpdateParameters>
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PatchViaIdentity
```
Update-AzADApplication -InputObject <IAdIdentity> -Parameter <IApplicationUpdateParameters>
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PatchViaIdentityExpanded
```
Update-AzADApplication -InputObject <IAdIdentity> [-AllowGuestsSignIn] [-AllowPassthroughUser]
 [-AppLogoUrl <String>] [-AppPermission <String[]>] [-AppRole <IAppRole[]>] [-AvailableToOtherTenant]
 [-DisplayName <String>] [-ErrorUrl <String>] [-GroupMembershipClaim <GroupMembershipClaimTypes>]
 [-Homepage <String>] [-IdentifierUri <String[]>] [-InformationalUrlMarketing <String>]
 [-InformationalUrlPrivacy <String>] [-InformationalUrlSupport <String>]
 [-InformationalUrlTermsOfService <String>] [-IsDeviceOnlyAuthSupported] [-KeyCredentials <IKeyCredential[]>]
 [-KnownClientApplication <String[]>] [-LogoutUrl <String>] [-Oauth2AllowImplicitFlow]
 [-Oauth2AllowUrlPathMatching] [-Oauth2Permission <IOAuth2Permission[]>] [-Oauth2RequirePostResponse]
 [-OptionalClaimAccessToken <IOptionalClaim[]>] [-OptionalClaimIdToken <IOptionalClaim[]>]
 [-OptionalClaimSamlToken <IOptionalClaim[]>] [-OrgRestriction <String[]>]
 [-PasswordCredentials <IPasswordCredential[]>] [-PreAuthorizedApplication <IPreAuthorizedApplication[]>]
 [-PublicClient] [-PublisherDomain <String>] [-ReplyUrl <String[]>]
 [-RequiredResourceAccess <IRequiredResourceAccess[]>] [-SamlMetadataUrl <String>] [-SignInAudience <String>]
 [-WwwHomepage <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update an existing application.

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

### -AllowGuestsSignIn
A property on the application to indicate if the application accepts other IDPs or not or partially accepts.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AllowPassthroughUser
Indicates that the application supports pass through users who have no presence in the resource tenant.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AppLogoUrl
The url for the application logo image stored in a CDN.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AppPermission
The application permissions.

```yaml
Type: System.String[]
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AppRole
The collection of application roles that an application may declare.
These roles can be assigned to users, groups or service principals.
To construct, see NOTES section for APPROLE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRole[]
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AvailableToOtherTenant
Whether the application is available to other tenants.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### -DisplayName
The display name of the application.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ErrorUrl
A URL provided by the author of the application to report errors when using the application.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GroupMembershipClaim
Configures the groups claim issued in a user or OAuth 2.0 access token that the app expects.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AD.Support.GroupMembershipClaimTypes
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Homepage
The home page of the application.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentifierUri
A collection of URIs for the application.

```yaml
Type: System.String[]
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InformationalUrlMarketing
The marketing URI

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InformationalUrlPrivacy
The privacy policy URI

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InformationalUrlSupport
The support URI

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InformationalUrlTermsOfService
The terms of service URI

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AD.Models.IAdIdentity
Parameter Sets: PatchViaIdentity, PatchViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IsDeviceOnlyAuthSupported
Specifies whether this application supports device authentication without a user.
The default is false.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyCredentials
A collection of KeyCredential objects.
To construct, see NOTES section for KEYCREDENTIALS properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential[]
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KnownClientApplication
Client applications that are tied to this resource application.
Consent to any of the known client applications will result in implicit consent to the resource application through a combined consent dialog (showing the OAuth permission scopes required by the client and the resource).

```yaml
Type: System.String[]
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogoutUrl
the url of the logout page

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Oauth2AllowImplicitFlow
Whether to allow implicit grant flow for OAuth2

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Oauth2AllowUrlPathMatching
Specifies whether during a token Request Azure AD will allow path matching of the redirect URI against the applications collection of replyURLs.
The default is false.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Oauth2Permission
The collection of OAuth 2.0 permission scopes that the web API (resource) application exposes to client applications.
These permission scopes may be granted to client applications during consent.
To construct, see NOTES section for OAUTH2PERMISSION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2Permission[]
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Oauth2RequirePostResponse
Specifies whether, as part of OAuth 2.0 token requests, Azure AD will allow POST requests, as opposed to GET requests.
The default is false, which specifies that only GET requests will be allowed.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ObjectId
Application object ID.

```yaml
Type: System.String
Parameter Sets: Patch, PatchExpanded
Aliases: ApplicationObjectId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionalClaimAccessToken
Optional claims requested to be included in the access token.
To construct, see NOTES section for OPTIONALCLAIMACCESSTOKEN properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[]
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionalClaimIdToken
Optional claims requested to be included in the id token.
To construct, see NOTES section for OPTIONALCLAIMIDTOKEN properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[]
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionalClaimSamlToken
Optional claims requested to be included in the saml token.
To construct, see NOTES section for OPTIONALCLAIMSAMLTOKEN properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[]
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OrgRestriction
A list of tenants allowed to access application.

```yaml
Type: System.String[]
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Request parameters for updating a new application.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationUpdateParameters
Parameter Sets: Patch, PatchViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PasswordCredentials
A collection of PasswordCredential objects
To construct, see NOTES section for PASSWORDCREDENTIALS properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential[]
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PreAuthorizedApplication
list of pre-authorized applications.
To construct, see NOTES section for PREAUTHORIZEDAPPLICATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPreAuthorizedApplication[]
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicClient
Specifies whether this application is a public client (such as an installed application running on a mobile device).
Default is false.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublisherDomain
Reliable domain which can be used to identify an application.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReplyUrl
A collection of reply URLs for the application.

```yaml
Type: System.String[]
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequiredResourceAccess
Specifies resources that this application requires access to and the set of OAuth permission scopes and application roles that it needs under each of those resources.
This pre-configuration of required resource access drives the consent experience.
To construct, see NOTES section for REQUIREDRESOURCEACCESS properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IRequiredResourceAccess[]
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SamlMetadataUrl
The URL to the SAML metadata for the application.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SignInAudience
Audience for signing in to the application (AzureADMyOrganization, AzureADAllOrganizations, AzureADAndMicrosoftAccounts).

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TenantId
The tenant ID.

```yaml
Type: System.String
Parameter Sets: Patch, PatchExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WwwHomepage
The primary Web page.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationUpdateParameters

### Microsoft.Azure.PowerShell.Cmdlets.AD.Models.IAdIdentity

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


APPROLE <IAppRole[]>: The collection of application roles that an application may declare. These roles can be assigned to users, groups or service principals.
  - `[AllowedMemberType <String[]>]`: Specifies whether this app role definition can be assigned to users and groups by setting to 'User', or to other applications (that are accessing this application in daemon service scenarios) by setting to 'Application', or to both. 
  - `[Description <String>]`: Permission help text that appears in the admin app assignment and consent experiences.
  - `[DisplayName <String>]`: Display name for the permission that appears in the admin consent and app assignment experiences.
  - `[Id <String>]`: Unique role identifier inside the appRoles collection.
  - `[IsEnabled <Boolean?>]`: When creating or updating a role definition, this must be set to true (which is the default). To delete a role, this must first be set to false. At that point, in a subsequent call, this role may be removed.
  - `[Value <String>]`: Specifies the value of the roles claim that the application should expect in the authentication and access tokens.

INPUTOBJECT <IAdIdentity>: Identity Parameter
  - `[ApplicationId <String>]`: The application ID.
  - `[ApplicationObjectId <String>]`: The object ID of the application for which to get owners.
  - `[DomainName <String>]`: name of the domain.
  - `[GroupObjectId <String>]`: The object ID of the group from which to remove the member.
  - `[Id <String>]`: Resource identity path
  - `[MemberObjectId <String>]`: Member object id
  - `[NextLink <String>]`: Next link for the list operation.
  - `[ObjectId <String>]`: The object ID of the group whose members should be retrieved.
  - `[OwnerObjectId <String>]`: Owner object id
  - `[TenantId <String>]`: The tenant ID.
  - `[UpnOrObjectId <String>]`: The object ID or principal name of the user for which to get information.

KEYCREDENTIALS <IKeyCredential[]>: A collection of KeyCredential objects.
  - `[CustomKeyIdentifier <String>]`: Custom Key Identifier
  - `[EndDate <DateTime?>]`: End date.
  - `[KeyId <String>]`: Key ID.
  - `[StartDate <DateTime?>]`: Start date.
  - `[Type <String>]`: Type. Acceptable values are 'AsymmetricX509Cert' and 'Symmetric'.
  - `[Usage <String>]`: Usage. Acceptable values are 'Verify' and 'Sign'.
  - `[Value <String>]`: Key value.

OAUTH2PERMISSION <IOAuth2Permission[]>: The collection of OAuth 2.0 permission scopes that the web API (resource) application exposes to client applications. These permission scopes may be granted to client applications during consent.
  - `[AdminConsentDescription <String>]`: Permission help text that appears in the admin consent and app assignment experiences.
  - `[AdminConsentDisplayName <String>]`: Display name for the permission that appears in the admin consent and app assignment experiences.
  - `[Id <String>]`: Unique scope permission identifier inside the oauth2Permissions collection.
  - `[IsEnabled <Boolean?>]`: When creating or updating a permission, this property must be set to true (which is the default). To delete a permission, this property must first be set to false. At that point, in a subsequent call, the permission may be removed. 
  - `[Type <String>]`: Specifies whether this scope permission can be consented to by an end user, or whether it is a tenant-wide permission that must be consented to by a Company Administrator. Possible values are "User" or "Admin".
  - `[UserConsentDescription <String>]`: Permission help text that appears in the end user consent experience.
  - `[UserConsentDisplayName <String>]`: Display name for the permission that appears in the end user consent experience.
  - `[Value <String>]`: The value of the scope claim that the resource application should expect in the OAuth 2.0 access token.

OPTIONALCLAIMACCESSTOKEN <IOptionalClaim[]>: Optional claims requested to be included in the access token.
  - `[AdditionalProperty <IOptionalClaimAdditionalProperties>]`: 
  - `[Essential <Boolean?>]`: Is this a required claim.
  - `[Name <String>]`: Claim name.
  - `[Source <String>]`: Claim source.

OPTIONALCLAIMIDTOKEN <IOptionalClaim[]>: Optional claims requested to be included in the id token.
  - `[AdditionalProperty <IOptionalClaimAdditionalProperties>]`: 
  - `[Essential <Boolean?>]`: Is this a required claim.
  - `[Name <String>]`: Claim name.
  - `[Source <String>]`: Claim source.

OPTIONALCLAIMSAMLTOKEN <IOptionalClaim[]>: Optional claims requested to be included in the saml token.
  - `[AdditionalProperty <IOptionalClaimAdditionalProperties>]`: 
  - `[Essential <Boolean?>]`: Is this a required claim.
  - `[Name <String>]`: Claim name.
  - `[Source <String>]`: Claim source.

PARAMETER <IApplicationUpdateParameters>: Request parameters for updating a new application.
  - `[AllowGuestsSignIn <Boolean?>]`: A property on the application to indicate if the application accepts other IDPs or not or partially accepts.
  - `[AllowPassthroughUser <Boolean?>]`: Indicates that the application supports pass through users who have no presence in the resource tenant.
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
  - `[ErrorUrl <String>]`: A URL provided by the author of the application to report errors when using the application.
  - `[GroupMembershipClaim <GroupMembershipClaimTypes?>]`: Configures the groups claim issued in a user or OAuth 2.0 access token that the app expects.
  - `[Homepage <String>]`: The home page of the application.
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
  - `[DisplayName <String>]`: The display name of the application.
  - `[IdentifierUri <String[]>]`: A collection of URIs for the application.

PASSWORDCREDENTIALS <IPasswordCredential[]>: A collection of PasswordCredential objects
  - `[CustomKeyIdentifier <Byte[]>]`: Custom Key Identifier
  - `[EndDate <DateTime?>]`: End date.
  - `[KeyId <String>]`: Key ID.
  - `[StartDate <DateTime?>]`: Start date.
  - `[Value <String>]`: Key value.

PREAUTHORIZEDAPPLICATION <IPreAuthorizedApplication[]>: list of pre-authorized applications.
  - `[AppId <String>]`: Represents the application id.
  - `[Extension <IPreAuthorizedApplicationExtension[]>]`: Collection of extensions from the resource application.
    - `[Condition <String[]>]`: The extension's conditions.
  - `[Permission <IPreAuthorizedApplicationPermission[]>]`: Collection of required app permissions/entitlements from the resource application.
    - `[AccessGrant <String[]>]`: The list of permissions.
    - `[DirectAccessGrant <Boolean?>]`: Indicates whether the permission set is DirectAccess or impersonation.

REQUIREDRESOURCEACCESS <IRequiredResourceAccess[]>: Specifies resources that this application requires access to and the set of OAuth permission scopes and application roles that it needs under each of those resources. This pre-configuration of required resource access drives the consent experience.
  - `ResourceAccess <IResourceAccess[]>`: The list of OAuth2.0 permission scopes and app roles that the application requires from the specified resource.
    - `Id <String>`: The unique identifier for one of the OAuth2Permission or AppRole instances that the resource application exposes.
    - `[Type <String>]`: Specifies whether the id property references an OAuth2Permission or an AppRole. Possible values are "scope" or "role".
  - `[ResourceAppId <String>]`: The unique identifier for the resource that the application requires access to. This should be equal to the appId declared on the target resource application.

## RELATED LINKS

