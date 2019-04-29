---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/update-azadapplication
schema: 2.0.0
---

# Update-AzADApplication

## SYNOPSIS
Update an existing application.

## SYNTAX

### Patch (Default)
```
Update-AzADApplication -ObjectId <String> -TenantId <String> [-Parameters <IApplicationUpdateParameters>]
 [-PassThru] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PatchExpanded
```
Update-AzADApplication -ObjectId <String> -TenantId <String> [-PassThru] [-AllowGuestsSignIn <Boolean>]
 [-AllowPassthroughUsers <Boolean>] [-AppLogoUrl <String>] [-AppPermissions <String[]>]
 [-AppRoles <IAppRole[]>] [-AvailableToOtherTenants <Boolean>] [-DisplayName <String>] [-ErrorUrl <String>]
 [-GroupMembershipClaims <GroupMembershipClaimTypes>] [-Homepage <String>] [-IdentifierUris <String[]>]
 [-InformationalUrlsMarketing <String>] [-InformationalUrlsPrivacy <String>]
 [-InformationalUrlsSupport <String>] [-InformationalUrlsTermsOfService <String>]
 [-IsDeviceOnlyAuthSupported <Boolean>] [-KeyCredentials <IKeyCredential[]>]
 [-KnownClientApplications <String[]>] [-LogoutUrl <String>] [-Oauth2AllowImplicitFlow <Boolean>]
 [-Oauth2AllowUrlPathMatching <Boolean>] [-Oauth2Permissions <IOAuth2Permission[]>]
 [-Oauth2RequirePostResponse <Boolean>] [-OptionalClaimsAccessToken <IOptionalClaim[]>]
 [-OptionalClaimsIdToken <IOptionalClaim[]>] [-OptionalClaimsSamlToken <IOptionalClaim[]>]
 [-OrgRestrictions <String[]>] [-PasswordCredentials <IPasswordCredential[]>]
 [-PreAuthorizedApplications <IPreAuthorizedApplication[]>] [-PublicClient <Boolean>]
 [-PublisherDomain <String>] [-ReplyUrls <String[]>] [-RequiredResourceAccess <IRequiredResourceAccess[]>]
 [-SamlMetadataUrl <String>] [-SignInAudience <String>] [-WwwHomepage <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update an existing application.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -AllowGuestsSignIn
A property on the application to indicate if the application accepts other IDPs or not or partially accepts.

```yaml
Type: System.Boolean
Parameter Sets: PatchExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -AllowPassthroughUsers
Indicates that the application supports pass through users who have no presence in the resource tenant.

```yaml
Type: System.Boolean
Parameter Sets: PatchExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -AppLogoUrl
The url for the application logo image stored in a CDN.

```yaml
Type: System.String
Parameter Sets: PatchExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AppPermissions
The application permissions.

```yaml
Type: System.String[]
Parameter Sets: PatchExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AppRoles
The collection of application roles that an application may declare.
These roles can be assigned to users, groups or service principals.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IAppRole[]
Parameter Sets: PatchExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AvailableToOtherTenants
Whether the application is available to other tenants.

```yaml
Type: System.Boolean
Parameter Sets: PatchExpanded
Aliases:

Required: False
Position: Named
Default value: False
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
Parameter Sets: PatchExpanded
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
Parameter Sets: PatchExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GroupMembershipClaims
Configures the groups claim issued in a user or OAuth 2.0 access token that the app expects.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.GroupMembershipClaimTypes
Parameter Sets: PatchExpanded
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
Parameter Sets: PatchExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentifierUris
A collection of URIs for the application.

```yaml
Type: System.String[]
Parameter Sets: PatchExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InformationalUrlsMarketing
The marketing URI

```yaml
Type: System.String
Parameter Sets: PatchExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InformationalUrlsPrivacy
The privacy policy URI

```yaml
Type: System.String
Parameter Sets: PatchExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InformationalUrlsSupport
The support URI

```yaml
Type: System.String
Parameter Sets: PatchExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InformationalUrlsTermsOfService
The terms of service URI

```yaml
Type: System.String
Parameter Sets: PatchExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsDeviceOnlyAuthSupported
Specifies whether this application supports device authentication without a user.
The default is false.

```yaml
Type: System.Boolean
Parameter Sets: PatchExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyCredentials
A collection of KeyCredential objects.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IKeyCredential[]
Parameter Sets: PatchExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KnownClientApplications
Client applications that are tied to this resource application.
Consent to any of the known client applications will result in implicit consent to the resource application through a combined consent dialog (showing the OAuth permission scopes required by the client and the resource).

```yaml
Type: System.String[]
Parameter Sets: PatchExpanded
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
Parameter Sets: PatchExpanded
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
Type: System.Boolean
Parameter Sets: PatchExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Oauth2AllowUrlPathMatching
Specifies whether during a token Request Azure AD will allow path matching of the redirect URI against the applications collection of replyURLs.
The default is false.

```yaml
Type: System.Boolean
Parameter Sets: PatchExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Oauth2Permissions
The collection of OAuth 2.0 permission scopes that the web API (resource) application exposes to client applications.
These permission scopes may be granted to client applications during consent.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IOAuth2Permission[]
Parameter Sets: PatchExpanded
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
Type: System.Boolean
Parameter Sets: PatchExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ObjectId
Application object ID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionalClaimsAccessToken
Optional claims requested to be included in the access token.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IOptionalClaim[]
Parameter Sets: PatchExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionalClaimsIdToken
Optional claims requested to be included in the id token.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IOptionalClaim[]
Parameter Sets: PatchExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionalClaimsSamlToken
Optional claims requested to be included in the saml token.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IOptionalClaim[]
Parameter Sets: PatchExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OrgRestrictions
A list of tenants allowed to access application.

```yaml
Type: System.String[]
Parameter Sets: PatchExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameters
Request parameters for updating a new application.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IApplicationUpdateParameters
Parameter Sets: Patch
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PassThru
When specified, PassThru will force the cmdlet return a 'bool' given that there isn't a return type by default.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -PasswordCredentials
A collection of PasswordCredential objects

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IPasswordCredential[]
Parameter Sets: PatchExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PreAuthorizedApplications
list of pre-authorized applications.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IPreAuthorizedApplication[]
Parameter Sets: PatchExpanded
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
Type: System.Boolean
Parameter Sets: PatchExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublisherDomain
Reliable domain which can be used to identify an application.

```yaml
Type: System.String
Parameter Sets: PatchExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReplyUrls
A collection of reply URLs for the application.

```yaml
Type: System.String[]
Parameter Sets: PatchExpanded
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IRequiredResourceAccess[]
Parameter Sets: PatchExpanded
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
Parameter Sets: PatchExpanded
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
Parameter Sets: PatchExpanded
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
Parameter Sets: (All)
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
Parameter Sets: PatchExpanded
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

## OUTPUTS

### System.Boolean
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.resources/update-azadapplication](https://docs.microsoft.com/en-us/powershell/module/az.resources/update-azadapplication)

