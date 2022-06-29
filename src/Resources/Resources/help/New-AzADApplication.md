---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://docs.microsoft.com/powershell/module/az.resources/new-azadapplication
schema: 2.0.0
---

# New-AzADApplication

## SYNOPSIS
Adds new entity to applications

## SYNTAX

### ApplicationWithoutCredentialParameterSet (Default)
```
New-AzADApplication -DisplayName <String> [-AvailableToOtherTenants <Boolean>] [-HomePage <String>]
 [-ReplyUrls <String[]>] [-IdentifierUri <String[]>] [-Web <IMicrosoftGraphWebApplication>]
 [-AddIn <IMicrosoftGraphAddIn[]>] [-Api <IMicrosoftGraphApiApplication>] [-AppRole <IMicrosoftGraphAppRole[]>]
 [-ApplicationTemplateId <String>] [-CreatedOnBehalfOfDeletedDateTime <DateTime>] [-DeletedDateTime <DateTime>]
 [-Description <String>] [-DisabledByMicrosoftStatus <String>] [-GroupMembershipClaim <String>]
 [-HomeRealmDiscoveryPolicy <IMicrosoftGraphHomeRealmDiscoveryPolicy[]>]
 [-Info <IMicrosoftGraphInformationalUrl>] [-IsDeviceOnlyAuthSupported] [-IsFallbackPublicClient]
 [-LogoInputFile <String>] [-Note <String>] [-Oauth2RequirePostResponse]
 [-OptionalClaim <IMicrosoftGraphOptionalClaims>]
 [-ParentalControlSetting <IMicrosoftGraphParentalControlSettings>] [-PublicClientRedirectUri <String[]>]
 [-RequiredResourceAccess <IMicrosoftGraphRequiredResourceAccess[]>] [-SignInAudience <String>]
 [-SPARedirectUri <String[]>] [-Tag <String[]>] [-TokenEncryptionKeyId <String>]
 [-TokenIssuancePolicy <IMicrosoftGraphTokenIssuancePolicy[]>]
 [-TokenLifetimePolicy <IMicrosoftGraphTokenLifetimePolicy[]>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### ApplicationWithKeyCredentialParameterSet
```
New-AzADApplication -DisplayName <String> [-AvailableToOtherTenants <Boolean>] [-HomePage <String>]
 [-ReplyUrls <String[]>] [-IdentifierUri <String[]>] [-Web <IMicrosoftGraphWebApplication>]
 [-AddIn <IMicrosoftGraphAddIn[]>] [-Api <IMicrosoftGraphApiApplication>] [-AppRole <IMicrosoftGraphAppRole[]>]
 [-ApplicationTemplateId <String>] [-CreatedOnBehalfOfDeletedDateTime <DateTime>] [-DeletedDateTime <DateTime>]
 [-Description <String>] [-DisabledByMicrosoftStatus <String>] [-GroupMembershipClaim <String>]
 [-HomeRealmDiscoveryPolicy <IMicrosoftGraphHomeRealmDiscoveryPolicy[]>]
 [-Info <IMicrosoftGraphInformationalUrl>] [-IsDeviceOnlyAuthSupported] [-IsFallbackPublicClient]
 [-LogoInputFile <String>] [-Note <String>] [-Oauth2RequirePostResponse]
 [-OptionalClaim <IMicrosoftGraphOptionalClaims>]
 [-ParentalControlSetting <IMicrosoftGraphParentalControlSettings>] [-PublicClientRedirectUri <String[]>]
 [-RequiredResourceAccess <IMicrosoftGraphRequiredResourceAccess[]>] [-SignInAudience <String>]
 [-SPARedirectUri <String[]>] [-Tag <String[]>] [-TokenEncryptionKeyId <String>]
 [-TokenIssuancePolicy <IMicrosoftGraphTokenIssuancePolicy[]>]
 [-TokenLifetimePolicy <IMicrosoftGraphTokenLifetimePolicy[]>] -KeyCredentials <IMicrosoftGraphKeyCredential[]>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ApplicationWithPasswordCredentialParameterSet
```
New-AzADApplication -DisplayName <String> [-AvailableToOtherTenants <Boolean>] [-HomePage <String>]
 [-ReplyUrls <String[]>] [-IdentifierUri <String[]>] [-Web <IMicrosoftGraphWebApplication>]
 [-AddIn <IMicrosoftGraphAddIn[]>] [-Api <IMicrosoftGraphApiApplication>] [-AppRole <IMicrosoftGraphAppRole[]>]
 [-ApplicationTemplateId <String>] [-CreatedOnBehalfOfDeletedDateTime <DateTime>] [-DeletedDateTime <DateTime>]
 [-Description <String>] [-DisabledByMicrosoftStatus <String>] [-GroupMembershipClaim <String>]
 [-HomeRealmDiscoveryPolicy <IMicrosoftGraphHomeRealmDiscoveryPolicy[]>]
 [-Info <IMicrosoftGraphInformationalUrl>] [-IsDeviceOnlyAuthSupported] [-IsFallbackPublicClient]
 [-LogoInputFile <String>] [-Note <String>] [-Oauth2RequirePostResponse]
 [-OptionalClaim <IMicrosoftGraphOptionalClaims>]
 [-ParentalControlSetting <IMicrosoftGraphParentalControlSettings>] [-PublicClientRedirectUri <String[]>]
 [-RequiredResourceAccess <IMicrosoftGraphRequiredResourceAccess[]>] [-SignInAudience <String>]
 [-SPARedirectUri <String[]>] [-Tag <String[]>] [-TokenEncryptionKeyId <String>]
 [-TokenIssuancePolicy <IMicrosoftGraphTokenIssuancePolicy[]>]
 [-TokenLifetimePolicy <IMicrosoftGraphTokenLifetimePolicy[]>]
 -PasswordCredentials <IMicrosoftGraphPasswordCredential[]> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ApplicationWithKeyPlainParameterSet
```
New-AzADApplication -DisplayName <String> [-AvailableToOtherTenants <Boolean>] [-HomePage <String>]
 [-ReplyUrls <String[]>] [-IdentifierUri <String[]>] [-Web <IMicrosoftGraphWebApplication>]
 [-AddIn <IMicrosoftGraphAddIn[]>] [-Api <IMicrosoftGraphApiApplication>] [-AppRole <IMicrosoftGraphAppRole[]>]
 [-ApplicationTemplateId <String>] [-CreatedOnBehalfOfDeletedDateTime <DateTime>] [-DeletedDateTime <DateTime>]
 [-Description <String>] [-DisabledByMicrosoftStatus <String>] [-GroupMembershipClaim <String>]
 [-HomeRealmDiscoveryPolicy <IMicrosoftGraphHomeRealmDiscoveryPolicy[]>]
 [-Info <IMicrosoftGraphInformationalUrl>] [-IsDeviceOnlyAuthSupported] [-IsFallbackPublicClient]
 [-LogoInputFile <String>] [-Note <String>] [-Oauth2RequirePostResponse]
 [-OptionalClaim <IMicrosoftGraphOptionalClaims>]
 [-ParentalControlSetting <IMicrosoftGraphParentalControlSettings>] [-PublicClientRedirectUri <String[]>]
 [-RequiredResourceAccess <IMicrosoftGraphRequiredResourceAccess[]>] [-SignInAudience <String>]
 [-SPARedirectUri <String[]>] [-Tag <String[]>] [-TokenEncryptionKeyId <String>]
 [-TokenIssuancePolicy <IMicrosoftGraphTokenIssuancePolicy[]>]
 [-TokenLifetimePolicy <IMicrosoftGraphTokenLifetimePolicy[]>] -CertValue <String> [-StartDate <DateTime>]
 [-EndDate <DateTime>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ApplicationWithPasswordPlainParameterSet
```
New-AzADApplication -DisplayName <String> [-AvailableToOtherTenants <Boolean>] [-HomePage <String>]
 [-ReplyUrls <String[]>] [-IdentifierUri <String[]>] [-Web <IMicrosoftGraphWebApplication>]
 [-AddIn <IMicrosoftGraphAddIn[]>] [-Api <IMicrosoftGraphApiApplication>] [-AppRole <IMicrosoftGraphAppRole[]>]
 [-ApplicationTemplateId <String>] [-CreatedOnBehalfOfDeletedDateTime <DateTime>] [-DeletedDateTime <DateTime>]
 [-Description <String>] [-DisabledByMicrosoftStatus <String>] [-GroupMembershipClaim <String>]
 [-HomeRealmDiscoveryPolicy <IMicrosoftGraphHomeRealmDiscoveryPolicy[]>]
 [-Info <IMicrosoftGraphInformationalUrl>] [-IsDeviceOnlyAuthSupported] [-IsFallbackPublicClient]
 [-LogoInputFile <String>] [-Note <String>] [-Oauth2RequirePostResponse]
 [-OptionalClaim <IMicrosoftGraphOptionalClaims>]
 [-ParentalControlSetting <IMicrosoftGraphParentalControlSettings>] [-PublicClientRedirectUri <String[]>]
 [-RequiredResourceAccess <IMicrosoftGraphRequiredResourceAccess[]>] [-SignInAudience <String>]
 [-SPARedirectUri <String[]>] [-Tag <String[]>] [-TokenEncryptionKeyId <String>]
 [-TokenIssuancePolicy <IMicrosoftGraphTokenIssuancePolicy[]>]
 [-TokenLifetimePolicy <IMicrosoftGraphTokenLifetimePolicy[]>] [-StartDate <DateTime>] [-EndDate <DateTime>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
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
To construct, see NOTES section for KEYCREDENTIALS properties and create a hash table.

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
To construct, see NOTES section for PASSWORDCREDENTIALS properties and create a hash table.

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

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


ADDIN <IMicrosoftGraphAddIn[]>: Defines custom behavior that a consuming service can use to call an app in specific contexts. For example, applications that can render file streams may set the addIns property for its 'FileHandler' functionality. This will let services like Office 365 call the application in the context of a document the user is working on.
  - `[Id <String>]`: 
  - `[Property <IMicrosoftGraphKeyValue[]>]`: 
    - `[Key <String>]`: Key.
    - `[Value <String>]`: Value.
  - `[Type <String>]`: 

API `<IMicrosoftGraphApiApplication>`: apiApplication
  - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[AcceptMappedClaim <Boolean?>]`: When true, allows an application to use claims mapping without specifying a custom signing key.
  - `[KnownClientApplication <String[]>]`: Used for bundling consent if you have a solution that contains two parts: a client app and a custom web API app. If you set the appID of the client app to this value, the user only consents once to the client app. Azure AD knows that consenting to the client means implicitly consenting to the web API and automatically provisions service principals for both APIs at the same time. Both the client and the web API app must be registered in the same tenant.
  - `[Oauth2PermissionScope <IMicrosoftGraphPermissionScope[]>]`: The definition of the delegated permissions exposed by the web API represented by this application registration. These delegated permissions may be requested by a client application, and may be granted by users or administrators during consent. Delegated permissions are sometimes referred to as OAuth 2.0 scopes.
    - `[AdminConsentDescription <String>]`: A description of the delegated permissions, intended to be read by an administrator granting the permission on behalf of all users. This text appears in tenant-wide admin consent experiences.
    - `[AdminConsentDisplayName <String>]`: The permission's title, intended to be read by an administrator granting the permission on behalf of all users.
    - `[Id <String>]`: Unique delegated permission identifier inside the collection of delegated permissions defined for a resource application.
    - `[IsEnabled <Boolean?>]`: When creating or updating a permission, this property must be set to true (which is the default). To delete a permission, this property must first be set to false.  At that point, in a subsequent call, the permission may be removed.
    - `[Origin <String>]`: 
    - `[Type <String>]`: Specifies whether this delegated permission should be considered safe for non-admin users to consent to on behalf of themselves, or whether an administrator should be required for consent to the permissions. This will be the default behavior, but each customer can choose to customize the behavior in their organization (by allowing, restricting or limiting user consent to this delegated permission.)
    - `[UserConsentDescription <String>]`: A description of the delegated permissions, intended to be read by a user granting the permission on their own behalf. This text appears in consent experiences where the user is consenting only on behalf of themselves.
    - `[UserConsentDisplayName <String>]`: A title for the permission, intended to be read by a user granting the permission on their own behalf. This text appears in consent experiences where the user is consenting only on behalf of themselves.
    - `[Value <String>]`: Specifies the value to include in the scp (scope) claim in access tokens. Must not exceed 120 characters in length. Allowed characters are : ! # $ % & ' ( ) * + , - . / : ;  =  ? @ [ ] ^ + _  {  } ~, as well as characters in the ranges 0-9, A-Z and a-z. Any other character, including the space character, are not allowed. May not begin with ..
  - `[PreAuthorizedApplication <IMicrosoftGraphPreAuthorizedApplication[]>]`: Lists the client applications that are pre-authorized with the specified delegated permissions to access this application's APIs. Users are not required to consent to any pre-authorized application (for the permissions specified). However, any additional permissions not listed in preAuthorizedApplications (requested through incremental consent for example) will require user consent.
    - `[AppId <String>]`: The unique identifier for the application.
    - `[DelegatedPermissionId <String[]>]`: The unique identifier for the oauth2PermissionScopes the application requires.
  - `[RequestedAccessTokenVersion <Int32?>]`: Specifies the access token version expected by this resource. This changes the version and format of the JWT produced independent of the endpoint or client used to request the access token.  The endpoint used, v1.0 or v2.0, is chosen by the client and only impacts the version of id_tokens. Resources need to explicitly configure requestedAccessTokenVersion to indicate the supported access token format.  Possible values for requestedAccessTokenVersion are 1, 2, or null. If the value is null, this defaults to 1, which corresponds to the v1.0 endpoint.  If signInAudience on the application is configured as AzureADandPersonalMicrosoftAccount, the value for this property must be 2

APPROLE <IMicrosoftGraphAppRole[]>: The collection of roles assigned to the application. With app role assignments, these roles can be assigned to users, groups, or service principals associated with other applications. Not nullable.
  - `[AllowedMemberType <String[]>]`: Specifies whether this app role can be assigned to users and groups (by setting to ['User']), to other application's (by setting to ['Application'], or both (by setting to ['User', 'Application']). App roles supporting assignment to other applications' service principals are also known as application permissions. The 'Application' value is only supported for app roles defined on application entities.
  - `[Description <String>]`: The description for the app role. This is displayed when the app role is being assigned and, if the app role functions as an application permission, during  consent experiences.
  - `[DisplayName <String>]`: Display name for the permission that appears in the app role assignment and consent experiences.
  - `[Id <String>]`: Unique role identifier inside the appRoles collection. When creating a new app role, a new Guid identifier must be provided.
  - `[IsEnabled <Boolean?>]`: When creating or updating an app role, this must be set to true (which is the default). To delete a role, this must first be set to false.  At that point, in a subsequent call, this role may be removed.
  - `[Value <String>]`: Specifies the value to include in the roles claim in ID tokens and access tokens authenticating an assigned user or service principal. Must not exceed 120 characters in length. Allowed characters are : ! # $ % & ' ( ) * + , - . / : ;  =  ? @ [ ] ^ + _  {  } ~, as well as characters in the ranges 0-9, A-Z and a-z. Any other character, including the space character, are not allowed. May not begin with ..

HOMEREALMDISCOVERYPOLICY <IMicrosoftGraphHomeRealmDiscoveryPolicy[]>: .
  - `[AppliesTo <IMicrosoftGraphDirectoryObject[]>]`: 
    - `[DeletedDateTime <DateTime?>]`: 
    - `[DisplayName <String>]`: The name displayed in directory
  - `[Definition <String[]>]`: A string collection containing a JSON string that defines the rules and settings for a policy. The syntax for the definition differs for each derived policy type. Required.
  - `[IsOrganizationDefault <Boolean?>]`: If set to true, activates this policy. There can be many policies for the same policy type, but only one can be activated as the organization default. Optional, default value is false.
  - `[Description <String>]`: Description for this policy.
  - `[DeletedDateTime <DateTime?>]`: 
  - `[DisplayName <String>]`: The name displayed in directory

INFO `<IMicrosoftGraphInformationalUrl>`: informationalUrl
  - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[MarketingUrl <String>]`: Link to the application's marketing page. For example, https://www.contoso.com/app/marketing
  - `[PrivacyStatementUrl <String>]`: Link to the application's privacy statement. For example, https://www.contoso.com/app/privacy
  - `[SupportUrl <String>]`: Link to the application's support page. For example, https://www.contoso.com/app/support
  - `[TermsOfServiceUrl <String>]`: Link to the application's terms of service statement. For example, https://www.contoso.com/app/termsofservice

KEYCREDENTIALS <IMicrosoftGraphKeyCredential[]>: key credentials associated with the application.
  - `[CustomKeyIdentifier <Byte[]>]`: Custom key identifier
  - `[DisplayName <String>]`: Friendly name for the key. Optional.
  - `[EndDateTime <DateTime?>]`: The date and time at which the credential expires.The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
  - `[Key <Byte[]>]`: Value for the key credential. Should be a base 64 encoded value.
  - `[KeyId <String>]`: The unique identifier (GUID) for the key.
  - `[StartDateTime <DateTime?>]`: The date and time at which the credential becomes valid.The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z
  - `[Type <String>]`: The type of key credential; for example, 'Symmetric'.
  - `[Usage <String>]`: A string that describes the purpose for which the key can be used; for example, 'Verify'.

OPTIONALCLAIM `<IMicrosoftGraphOptionalClaims>`: optionalClaims
  - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[AccessToken <IMicrosoftGraphOptionalClaim[]>]`: The optional claims returned in the JWT access token.
    - `[AdditionalProperty <String[]>]`: Additional properties of the claim. If a property exists in this collection, it modifies the behavior of the optional claim specified in the name property.
    - `[Essential <Boolean?>]`: If the value is true, the claim specified by the client is necessary to ensure a smooth authorization experience for the specific task requested by the end user. The default value is false.
    - `[Name <String>]`: The name of the optional claim.
    - `[Source <String>]`: The source (directory object) of the claim. There are predefined claims and user-defined claims from extension properties. If the source value is null, the claim is a predefined optional claim. If the source value is user, the value in the name property is the extension property from the user object.
  - `[IdToken <IMicrosoftGraphOptionalClaim[]>]`: The optional claims returned in the JWT ID token.
  - `[Saml2Token <IMicrosoftGraphOptionalClaim[]>]`: The optional claims returned in the SAML token.

PARENTALCONTROLSETTING `<IMicrosoftGraphParentalControlSettings>`: parentalControlSettings
  - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[CountriesBlockedForMinor <String[]>]`: Specifies the two-letter ISO country codes. Access to the application will be blocked for minors from the countries specified in this list.
  - `[LegalAgeGroupRule <String>]`: Specifies the legal age group rule that applies to users of the app. Can be set to one of the following values: ValueDescriptionAllowDefault. Enforces the legal minimum. This means parental consent is required for minors in the European Union and Korea.RequireConsentForPrivacyServicesEnforces the user to specify date of birth to comply with COPPA rules. RequireConsentForMinorsRequires parental consent for ages below 18, regardless of country minor rules.RequireConsentForKidsRequires parental consent for ages below 14, regardless of country minor rules.BlockMinorsBlocks minors from using the app.

PASSWORDCREDENTIALS <IMicrosoftGraphPasswordCredential[]>: Password credentials associated with the application.
  - `[CustomKeyIdentifier <Byte[]>]`: Do not use.
  - `[DisplayName <String>]`: Friendly name for the password. Optional.
  - `[EndDateTime <DateTime?>]`: The date and time at which the password expires represented using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Optional.
  - `[KeyId <String>]`: The unique identifier for the password.
  - `[StartDateTime <DateTime?>]`: The date and time at which the password becomes valid. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Optional.

REQUIREDRESOURCEACCESS <IMicrosoftGraphRequiredResourceAccess[]>: Specifies the resources that the application needs to access. This property also specifies the set of OAuth permission scopes and application roles that it needs for each of those resources. This configuration of access to the required resources drives the consent experience. Not nullable. Supports $filter (eq, NOT, ge, le).
  - `[ResourceAccess <IMicrosoftGraphResourceAccess[]>]`: The list of OAuth2.0 permission scopes and app roles that the application requires from the specified resource.
    - `[Id <String>]`: The unique identifier for one of the oauth2PermissionScopes or appRole instances that the resource application exposes.
    - `[Type <String>]`: Specifies whether the id property references an oauth2PermissionScopes or an appRole. Possible values are Scope or Role.
  - `[ResourceAppId <String>]`: The unique identifier for the resource that the application requires access to.  This should be equal to the appId declared on the target resource application.

TOKENISSUANCEPOLICY <IMicrosoftGraphTokenIssuancePolicy[]>: .
  - `[AppliesTo <IMicrosoftGraphDirectoryObject[]>]`: 
    - `[DeletedDateTime <DateTime?>]`: 
    - `[DisplayName <String>]`: The name displayed in directory
  - `[Definition <String[]>]`: A string collection containing a JSON string that defines the rules and settings for a policy. The syntax for the definition differs for each derived policy type. Required.
  - `[IsOrganizationDefault <Boolean?>]`: If set to true, activates this policy. There can be many policies for the same policy type, but only one can be activated as the organization default. Optional, default value is false.
  - `[Description <String>]`: Description for this policy.
  - `[DeletedDateTime <DateTime?>]`: 
  - `[DisplayName <String>]`: The name displayed in directory

TOKENLIFETIMEPOLICY <IMicrosoftGraphTokenLifetimePolicy[]>: The tokenLifetimePolicies assigned to this application. Supports $expand.
  - `[AppliesTo <IMicrosoftGraphDirectoryObject[]>]`: 
    - `[DeletedDateTime <DateTime?>]`: 
    - `[DisplayName <String>]`: The name displayed in directory
  - `[Definition <String[]>]`: A string collection containing a JSON string that defines the rules and settings for a policy. The syntax for the definition differs for each derived policy type. Required.
  - `[IsOrganizationDefault <Boolean?>]`: If set to true, activates this policy. There can be many policies for the same policy type, but only one can be activated as the organization default. Optional, default value is false.
  - `[Description <String>]`: Description for this policy.
  - `[DeletedDateTime <DateTime?>]`: 
  - `[DisplayName <String>]`: The name displayed in directory

WEB `<IMicrosoftGraphWebApplication>`: webApplication
  - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[HomePageUrl <String>]`: Home page or landing page of the application.
  - `[ImplicitGrantSetting <IMicrosoftGraphImplicitGrantSettings>]`: implicitGrantSettings
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
    - `[EnableAccessTokenIssuance <Boolean?>]`: Specifies whether this web application can request an access token using the OAuth 2.0 implicit flow.
    - `[EnableIdTokenIssuance <Boolean?>]`: Specifies whether this web application can request an ID token using the OAuth 2.0 implicit flow.
  - `[LogoutUrl <String>]`: Specifies the URL that will be used by Microsoft's authorization service to logout an user using front-channel, back-channel or SAML logout protocols.
  - `[RedirectUri <String[]>]`: Specifies the URLs where user tokens are sent for sign-in, or the redirect URIs where OAuth 2.0 authorization codes and access tokens are sent.

## RELATED LINKS

## RELATED LINKS
