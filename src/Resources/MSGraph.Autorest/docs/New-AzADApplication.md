---
external help file:
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/new-azadapplication
schema: 2.0.0
---

# New-AzADApplication

## SYNOPSIS
Adds new entity to applications

## SYNTAX

### ApplicationWithoutCredentialParameterSet (Default)
```
New-AzADApplication -DisplayName <String> [-AddIn <IMicrosoftGraphAddIn[]>]
 [-Api <IMicrosoftGraphApiApplication>] [-ApplicationTemplateId <String>]
 [-AppRole <IMicrosoftGraphAppRole[]>] [-AvailableToOtherTenants <Boolean>]
 [-CreatedOnBehalfOfDeletedDateTime <DateTime>] [-DeletedDateTime <DateTime>] [-Description <String>]
 [-DisabledByMicrosoftStatus <String>] [-GroupMembershipClaim <String>] [-HomePage <String>]
 [-HomeRealmDiscoveryPolicy <IMicrosoftGraphHomeRealmDiscoveryPolicy[]>] [-IdentifierUri <String[]>]
 [-Info <IMicrosoftGraphInformationalUrl>] [-IsDeviceOnlyAuthSupported] [-IsFallbackPublicClient]
 [-LogoInputFile <String>] [-Note <String>] [-Oauth2RequirePostResponse]
 [-OptionalClaim <IMicrosoftGraphOptionalClaims>]
 [-ParentalControlSetting <IMicrosoftGraphParentalControlSettings>] [-PublicClientRedirectUri <String[]>]
 [-ReplyUrls <String[]>] [-RequestedAccessTokenVersion <Int32>]
 [-RequiredResourceAccess <IMicrosoftGraphRequiredResourceAccess[]>] [-ServiceManagementReference <String>]
 [-SignInAudience <String>] [-SPARedirectUri <String[]>] [-Tag <String[]>] [-TokenEncryptionKeyId <String>]
 [-TokenIssuancePolicy <IMicrosoftGraphTokenIssuancePolicy[]>]
 [-TokenLifetimePolicy <IMicrosoftGraphTokenLifetimePolicy[]>] [-Web <IMicrosoftGraphWebApplication>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ApplicationWithKeyCredentialParameterSet
```
New-AzADApplication -DisplayName <String> -KeyCredentials <IMicrosoftGraphKeyCredential[]>
 [-AddIn <IMicrosoftGraphAddIn[]>] [-Api <IMicrosoftGraphApiApplication>] [-ApplicationTemplateId <String>]
 [-AppRole <IMicrosoftGraphAppRole[]>] [-AvailableToOtherTenants <Boolean>]
 [-CreatedOnBehalfOfDeletedDateTime <DateTime>] [-DeletedDateTime <DateTime>] [-Description <String>]
 [-DisabledByMicrosoftStatus <String>] [-GroupMembershipClaim <String>] [-HomePage <String>]
 [-HomeRealmDiscoveryPolicy <IMicrosoftGraphHomeRealmDiscoveryPolicy[]>] [-IdentifierUri <String[]>]
 [-Info <IMicrosoftGraphInformationalUrl>] [-IsDeviceOnlyAuthSupported] [-IsFallbackPublicClient]
 [-LogoInputFile <String>] [-Note <String>] [-Oauth2RequirePostResponse]
 [-OptionalClaim <IMicrosoftGraphOptionalClaims>]
 [-ParentalControlSetting <IMicrosoftGraphParentalControlSettings>] [-PublicClientRedirectUri <String[]>]
 [-ReplyUrls <String[]>] [-RequestedAccessTokenVersion <Int32>]
 [-RequiredResourceAccess <IMicrosoftGraphRequiredResourceAccess[]>] [-ServiceManagementReference <String>]
 [-SignInAudience <String>] [-SPARedirectUri <String[]>] [-Tag <String[]>] [-TokenEncryptionKeyId <String>]
 [-TokenIssuancePolicy <IMicrosoftGraphTokenIssuancePolicy[]>]
 [-TokenLifetimePolicy <IMicrosoftGraphTokenLifetimePolicy[]>] [-Web <IMicrosoftGraphWebApplication>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ApplicationWithKeyPlainParameterSet
```
New-AzADApplication -CertValue <String> -DisplayName <String> [-AddIn <IMicrosoftGraphAddIn[]>]
 [-Api <IMicrosoftGraphApiApplication>] [-ApplicationTemplateId <String>]
 [-AppRole <IMicrosoftGraphAppRole[]>] [-AvailableToOtherTenants <Boolean>]
 [-CreatedOnBehalfOfDeletedDateTime <DateTime>] [-DeletedDateTime <DateTime>] [-Description <String>]
 [-DisabledByMicrosoftStatus <String>] [-EndDate <DateTime>] [-GroupMembershipClaim <String>]
 [-HomePage <String>] [-HomeRealmDiscoveryPolicy <IMicrosoftGraphHomeRealmDiscoveryPolicy[]>]
 [-IdentifierUri <String[]>] [-Info <IMicrosoftGraphInformationalUrl>] [-IsDeviceOnlyAuthSupported]
 [-IsFallbackPublicClient] [-LogoInputFile <String>] [-Note <String>] [-Oauth2RequirePostResponse]
 [-OptionalClaim <IMicrosoftGraphOptionalClaims>]
 [-ParentalControlSetting <IMicrosoftGraphParentalControlSettings>] [-PublicClientRedirectUri <String[]>]
 [-ReplyUrls <String[]>] [-RequestedAccessTokenVersion <Int32>]
 [-RequiredResourceAccess <IMicrosoftGraphRequiredResourceAccess[]>] [-ServiceManagementReference <String>]
 [-SignInAudience <String>] [-SPARedirectUri <String[]>] [-StartDate <DateTime>] [-Tag <String[]>]
 [-TokenEncryptionKeyId <String>] [-TokenIssuancePolicy <IMicrosoftGraphTokenIssuancePolicy[]>]
 [-TokenLifetimePolicy <IMicrosoftGraphTokenLifetimePolicy[]>] [-Web <IMicrosoftGraphWebApplication>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ApplicationWithPasswordCredentialParameterSet
```
New-AzADApplication -DisplayName <String> -PasswordCredentials <IMicrosoftGraphPasswordCredential[]>
 [-AddIn <IMicrosoftGraphAddIn[]>] [-Api <IMicrosoftGraphApiApplication>] [-ApplicationTemplateId <String>]
 [-AppRole <IMicrosoftGraphAppRole[]>] [-AvailableToOtherTenants <Boolean>]
 [-CreatedOnBehalfOfDeletedDateTime <DateTime>] [-DeletedDateTime <DateTime>] [-Description <String>]
 [-DisabledByMicrosoftStatus <String>] [-GroupMembershipClaim <String>] [-HomePage <String>]
 [-HomeRealmDiscoveryPolicy <IMicrosoftGraphHomeRealmDiscoveryPolicy[]>] [-IdentifierUri <String[]>]
 [-Info <IMicrosoftGraphInformationalUrl>] [-IsDeviceOnlyAuthSupported] [-IsFallbackPublicClient]
 [-LogoInputFile <String>] [-Note <String>] [-Oauth2RequirePostResponse]
 [-OptionalClaim <IMicrosoftGraphOptionalClaims>]
 [-ParentalControlSetting <IMicrosoftGraphParentalControlSettings>] [-PublicClientRedirectUri <String[]>]
 [-ReplyUrls <String[]>] [-RequestedAccessTokenVersion <Int32>]
 [-RequiredResourceAccess <IMicrosoftGraphRequiredResourceAccess[]>] [-ServiceManagementReference <String>]
 [-SignInAudience <String>] [-SPARedirectUri <String[]>] [-Tag <String[]>] [-TokenEncryptionKeyId <String>]
 [-TokenIssuancePolicy <IMicrosoftGraphTokenIssuancePolicy[]>]
 [-TokenLifetimePolicy <IMicrosoftGraphTokenLifetimePolicy[]>] [-Web <IMicrosoftGraphWebApplication>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ApplicationWithPasswordPlainParameterSet
```
New-AzADApplication -DisplayName <String> [-AddIn <IMicrosoftGraphAddIn[]>]
 [-Api <IMicrosoftGraphApiApplication>] [-ApplicationTemplateId <String>]
 [-AppRole <IMicrosoftGraphAppRole[]>] [-AvailableToOtherTenants <Boolean>]
 [-CreatedOnBehalfOfDeletedDateTime <DateTime>] [-DeletedDateTime <DateTime>] [-Description <String>]
 [-DisabledByMicrosoftStatus <String>] [-EndDate <DateTime>] [-GroupMembershipClaim <String>]
 [-HomePage <String>] [-HomeRealmDiscoveryPolicy <IMicrosoftGraphHomeRealmDiscoveryPolicy[]>]
 [-IdentifierUri <String[]>] [-Info <IMicrosoftGraphInformationalUrl>] [-IsDeviceOnlyAuthSupported]
 [-IsFallbackPublicClient] [-LogoInputFile <String>] [-Note <String>] [-Oauth2RequirePostResponse]
 [-OptionalClaim <IMicrosoftGraphOptionalClaims>]
 [-ParentalControlSetting <IMicrosoftGraphParentalControlSettings>] [-PublicClientRedirectUri <String[]>]
 [-ReplyUrls <String[]>] [-RequestedAccessTokenVersion <Int32>]
 [-RequiredResourceAccess <IMicrosoftGraphRequiredResourceAccess[]>] [-ServiceManagementReference <String>]
 [-SignInAudience <String>] [-SPARedirectUri <String[]>] [-StartDate <DateTime>] [-Tag <String[]>]
 [-TokenEncryptionKeyId <String>] [-TokenIssuancePolicy <IMicrosoftGraphTokenIssuancePolicy[]>]
 [-TokenLifetimePolicy <IMicrosoftGraphTokenLifetimePolicy[]>] [-Web <IMicrosoftGraphWebApplication>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Adds new entity to applications

## EXAMPLES

### Example 1: Create application
```powershell
New-AzADApplication -SigninAudience AzureADandPersonalMicrosoftAccount
```

Create application with signin audience 'AzureADandPersonalMicrosoftAccount', other available options are: 'AzureADMyOrg', 'AzureADMultipleOrgs', 'PersonalMicrosoftAccount'

## PARAMETERS

### -AddIn
Defines custom behavior that a consuming service can use to call an app in specific contexts.
For example, applications that can render file streams may set the addIns property for its 'FileHandler' functionality.
This will let services like Office 365 call the application in the context of a document the user is working on.
To construct, see NOTES section for ADDIN properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphAddIn[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Api
apiApplication
To construct, see NOTES section for API properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphApiApplication
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApplicationTemplateId
Unique identifier of the applicationTemplate.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AppRole
The collection of roles assigned to the application.
With app role assignments, these roles can be assigned to users, groups, or service principals associated with other applications.
Not nullable.
To construct, see NOTES section for APPROLE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphAppRole[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AvailableToOtherTenants
The value specifying whether the application is a single tenant or a multi-tenant.
Is equivalent to '-SignInAudience AzureADMultipleOrgs' when switch is on

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CertValue
The value of the 'asymmetric' credential type.
It represents the base 64 encoded certificate.

```yaml
Type: System.String
Parameter Sets: ApplicationWithKeyPlainParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CreatedOnBehalfOfDeletedDateTime
.

```yaml
Type: System.DateTime
Parameter Sets: (All)
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
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeletedDateTime
.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
An optional description of the application.
Returned by default.
Supports $filter (eq, ne, NOT, ge, le, startsWith) and $search.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisabledByMicrosoftStatus
Specifies whether Microsoft has disabled the registered application.
Possible values are: null (default value), NotDisabled, and DisabledDueToViolationOfServicesAgreement (reasons may include suspicious, abusive, or malicious activity, or a violation of the Microsoft Services Agreement).
Supports $filter (eq, ne, NOT).

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayName
The display name for the application.
Supports $filter (eq, ne, NOT, ge, le, in, startsWith), $search, and $orderBy.

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

### -EndDate
The effective end date of the credential usage.
The default end date value is one year from today.
For an 'asymmetric' type credential, this must be set to on or before the date that the X509 certificate is valid.

```yaml
Type: System.DateTime
Parameter Sets: ApplicationWithKeyPlainParameterSet, ApplicationWithPasswordPlainParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GroupMembershipClaim
Configures the groups claim issued in a user or OAuth 2.0 access token that the application expects.
To set this attribute, use one of the following string values: None, SecurityGroup (for security groups and Azure AD roles), All (this gets all security groups, distribution groups, and Azure AD directory roles that the signed-in user is a member of).

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HomePage
The URL to the application homepage.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: WebHomePageUrl

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HomeRealmDiscoveryPolicy
.
To construct, see NOTES section for HOMEREALMDISCOVERYPOLICY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphHomeRealmDiscoveryPolicy[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentifierUri
The URIs that identify the application.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases: IdentifierUris

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Info
informationalUrl
To construct, see NOTES section for INFO properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphInformationalUrl
Parameter Sets: (All)
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
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsFallbackPublicClient
Specifies the fallback application type as public client, such as an installed application running on a mobile device.
The default value is false which means the fallback application type is confidential client such as a web app.
There are certain scenarios where Azure AD cannot determine the client application type.
For example, the ROPC flow where the application is configured without specifying a redirect URI.
In those cases Azure AD interprets the application type based on the value of this property.

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

### -KeyCredentials
key credentials associated with the application.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphKeyCredential[]
Parameter Sets: ApplicationWithKeyCredentialParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogoInputFile
Input File for Logo (The main logo for the application.
Not nullable.)

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Note
Notes relevant for the management of the application.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Oauth2RequirePostResponse
.

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

### -OptionalClaim
optionalClaims
To construct, see NOTES section for OPTIONALCLAIM properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphOptionalClaims
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParentalControlSetting
parentalControlSettings
To construct, see NOTES section for PARENTALCONTROLSETTING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphParentalControlSettings
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PasswordCredentials
Password credentials associated with the application.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphPasswordCredential[]
Parameter Sets: ApplicationWithPasswordCredentialParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicClientRedirectUri


```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReplyUrls
The application reply Urls.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases: WebRedirectUri

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequestedAccessTokenVersion


```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequiredResourceAccess
Specifies the resources that the application needs to access.
This property also specifies the set of OAuth permission scopes and application roles that it needs for each of those resources.
This configuration of access to the required resources drives the consent experience.
Not nullable.
Supports $filter (eq, NOT, ge, le).
To construct, see NOTES section for REQUIREDRESOURCEACCESS properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphRequiredResourceAccess[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceManagementReference
References application or service contact information from a Service or Asset Management database.
Nullable.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SignInAudience
Specifies the Microsoft accounts that are supported for the current application.
Supported values are: AzureADMyOrg, AzureADMultipleOrgs, AzureADandPersonalMicrosoftAccount, PersonalMicrosoftAccount.
See more in the table below.
Supports $filter (eq, ne, NOT).

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SPARedirectUri


```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartDate
The effective start date of the credential usage.
The default start date value is today.
For an 'asymmetric' type credential, this must be set to on or after the date that the X509 certificate is valid from.

```yaml
Type: System.DateTime
Parameter Sets: ApplicationWithKeyPlainParameterSet, ApplicationWithPasswordPlainParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Custom strings that can be used to categorize and identify the application.
Not nullable.Supports $filter (eq, NOT, ge, le, startsWith).

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TokenEncryptionKeyId
Specifies the keyId of a public key from the keyCredentials collection.
When configured, Azure AD encrypts all the tokens it emits by using the key this property points to.
The application code that receives the encrypted token must use the matching private key to decrypt the token before it can be used for the signed-in user.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TokenIssuancePolicy
.
To construct, see NOTES section for TOKENISSUANCEPOLICY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphTokenIssuancePolicy[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TokenLifetimePolicy
The tokenLifetimePolicies assigned to this application.
Supports $expand.
To construct, see NOTES section for TOKENLIFETIMEPOLICY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphTokenLifetimePolicy[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Web
webApplication
To construct, see NOTES section for WEB properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphWebApplication
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphApplication

## NOTES

## RELATED LINKS

