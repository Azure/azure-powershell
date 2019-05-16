---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/new-azadapplication
schema: 2.0.0
---

# New-AzADApplication

## SYNOPSIS
Create a new application.

## SYNTAX

### Create2 (Default)
```
New-AzADApplication -TenantId <String> [-Parameter <IApplicationCreateParameters>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateExpanded2
```
New-AzADApplication -TenantId <String> [-AllowGuestsSignIn <Boolean>] [-AllowPassthroughUser <Boolean>]
 [-AppLogoUrl <String>] [-AppPermission <String[]>] [-AppRole <IAppRole[]>] [-AvailableToOtherTenant <Boolean>]
 -DisplayName <String> [-ErrorUrl <String>] [-GroupMembershipClaim <GroupMembershipClaimTypes>]
 [-Homepage <String>] [-IdentifierUri <String[]>] [-InformationalUrlsMarketing <String>]
 [-InformationalUrlsPrivacy <String>] [-InformationalUrlsSupport <String>]
 [-InformationalUrlsTermsOfService <String>] [-IsDeviceOnlyAuthSupported <Boolean>]
 [-KeyCredential <IKeyCredential[]>] [-KnownClientApplication <String[]>] [-LogoutUrl <String>]
 [-Oauth2AllowImplicitFlow <Boolean>] [-Oauth2AllowUrlPathMatching <Boolean>]
 [-Oauth2Permissions <IOAuth2Permission[]>] [-Oauth2RequirePostResponse <Boolean>]
 [-OptionalClaimsAccessToken <IOptionalClaim[]>] [-OptionalClaimsIdToken <IOptionalClaim[]>]
 [-OptionalClaimsSamlToken <IOptionalClaim[]>] [-OrgRestriction <String[]>]
 [-PasswordCredential <IPasswordCredential[]>] [-PreAuthorizedApplication <IPreAuthorizedApplication[]>]
 [-PublicClient <Boolean>] [-PublisherDomain <String>] [-ReplyUrl <String[]>]
 [-RequiredResourceAccess <IRequiredResourceAccess[]>] [-SamlMetadataUrl <String>] [-SignInAudience <String>]
 [-WwwHomepage <String>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityExpanded2
```
New-AzADApplication -InputObject <IResourcesIdentity> [-AllowGuestsSignIn <Boolean>]
 [-AllowPassthroughUser <Boolean>] [-AppLogoUrl <String>] [-AppPermission <String[]>] [-AppRole <IAppRole[]>]
 [-AvailableToOtherTenant <Boolean>] -DisplayName <String> [-ErrorUrl <String>]
 [-GroupMembershipClaim <GroupMembershipClaimTypes>] [-Homepage <String>] [-IdentifierUri <String[]>]
 [-InformationalUrlsMarketing <String>] [-InformationalUrlsPrivacy <String>]
 [-InformationalUrlsSupport <String>] [-InformationalUrlsTermsOfService <String>]
 [-IsDeviceOnlyAuthSupported <Boolean>] [-KeyCredential <IKeyCredential[]>]
 [-KnownClientApplication <String[]>] [-LogoutUrl <String>] [-Oauth2AllowImplicitFlow <Boolean>]
 [-Oauth2AllowUrlPathMatching <Boolean>] [-Oauth2Permissions <IOAuth2Permission[]>]
 [-Oauth2RequirePostResponse <Boolean>] [-OptionalClaimsAccessToken <IOptionalClaim[]>]
 [-OptionalClaimsIdToken <IOptionalClaim[]>] [-OptionalClaimsSamlToken <IOptionalClaim[]>]
 [-OrgRestriction <String[]>] [-PasswordCredential <IPasswordCredential[]>]
 [-PreAuthorizedApplication <IPreAuthorizedApplication[]>] [-PublicClient <Boolean>]
 [-PublisherDomain <String>] [-ReplyUrl <String[]>] [-RequiredResourceAccess <IRequiredResourceAccess[]>]
 [-SamlMetadataUrl <String>] [-SignInAudience <String>] [-WwwHomepage <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentity2
```
New-AzADApplication -InputObject <IResourcesIdentity> [-Parameter <IApplicationCreateParameters>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a new application.

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
Parameter Sets: CreateExpanded2, CreateViaIdentityExpanded2
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -AllowPassthroughUser
Indicates that the application supports pass through users who have no presence in the resource tenant.

```yaml
Type: System.Boolean
Parameter Sets: CreateExpanded2, CreateViaIdentityExpanded2
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
Parameter Sets: CreateExpanded2, CreateViaIdentityExpanded2
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
Parameter Sets: CreateExpanded2, CreateViaIdentityExpanded2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AppRole
The collection of application roles that an application may declare. These roles can be assigned to users, groups or service principals.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IAppRole[]
Parameter Sets: CreateExpanded2, CreateViaIdentityExpanded2
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
Type: System.Boolean
Parameter Sets: CreateExpanded2, CreateViaIdentityExpanded2
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
Parameter Sets: CreateExpanded2, CreateViaIdentityExpanded2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ErrorUrl
A URL provided by the author of the application to report errors when using the application.

```yaml
Type: System.String
Parameter Sets: CreateExpanded2, CreateViaIdentityExpanded2
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.GroupMembershipClaimTypes
Parameter Sets: CreateExpanded2, CreateViaIdentityExpanded2
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
Parameter Sets: CreateExpanded2, CreateViaIdentityExpanded2
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
Parameter Sets: CreateExpanded2, CreateViaIdentityExpanded2
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
Parameter Sets: CreateExpanded2, CreateViaIdentityExpanded2
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
Parameter Sets: CreateExpanded2, CreateViaIdentityExpanded2
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
Parameter Sets: CreateExpanded2, CreateViaIdentityExpanded2
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
Parameter Sets: CreateExpanded2, CreateViaIdentityExpanded2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.IResourcesIdentity
Parameter Sets: CreateViaIdentityExpanded2, CreateViaIdentity2
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
Type: System.Boolean
Parameter Sets: CreateExpanded2, CreateViaIdentityExpanded2
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyCredential
A collection of KeyCredential objects.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IKeyCredential[]
Parameter Sets: CreateExpanded2, CreateViaIdentityExpanded2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KnownClientApplication
Client applications that are tied to this resource application. Consent to any of the known client applications will result in implicit consent to the resource application through a combined consent dialog (showing the OAuth permission scopes required by the client and the resource).

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded2, CreateViaIdentityExpanded2
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
Parameter Sets: CreateExpanded2, CreateViaIdentityExpanded2
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
Parameter Sets: CreateExpanded2, CreateViaIdentityExpanded2
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
Parameter Sets: CreateExpanded2, CreateViaIdentityExpanded2
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
Parameter Sets: CreateExpanded2, CreateViaIdentityExpanded2
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
Parameter Sets: CreateExpanded2, CreateViaIdentityExpanded2
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionalClaimsAccessToken
Optional claims requested to be included in the access token.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IOptionalClaim[]
Parameter Sets: CreateExpanded2, CreateViaIdentityExpanded2
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
Parameter Sets: CreateExpanded2, CreateViaIdentityExpanded2
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
Parameter Sets: CreateExpanded2, CreateViaIdentityExpanded2
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
Parameter Sets: CreateExpanded2, CreateViaIdentityExpanded2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Request parameters for creating a new application.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IApplicationCreateParameters
Parameter Sets: Create2, CreateViaIdentity2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PasswordCredential
A collection of PasswordCredential objects

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IPasswordCredential[]
Parameter Sets: CreateExpanded2, CreateViaIdentityExpanded2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PreAuthorizedApplication
list of pre-authorized applications.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IPreAuthorizedApplication[]
Parameter Sets: CreateExpanded2, CreateViaIdentityExpanded2
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
Parameter Sets: CreateExpanded2, CreateViaIdentityExpanded2
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
Parameter Sets: CreateExpanded2, CreateViaIdentityExpanded2
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
Parameter Sets: CreateExpanded2, CreateViaIdentityExpanded2
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
Parameter Sets: CreateExpanded2, CreateViaIdentityExpanded2
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
Parameter Sets: CreateExpanded2, CreateViaIdentityExpanded2
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
Parameter Sets: CreateExpanded2, CreateViaIdentityExpanded2
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
Parameter Sets: Create2, CreateExpanded2
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
Parameter Sets: CreateExpanded2, CreateViaIdentityExpanded2
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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IApplication
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.resources/new-azadapplication](https://docs.microsoft.com/en-us/powershell/module/az.resources/new-azadapplication)

