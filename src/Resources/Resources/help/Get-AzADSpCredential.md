---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/get-azadspcredential
schema: 2.0.0
---

# Get-AzADSpCredential

## SYNOPSIS
Lists key credentials and password credentials for an service principal.

## SYNTAX

### ObjectIdParameterSet (Default)
```
Get-AzADSpCredential -ObjectId <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SPNParameterSet
```
Get-AzADSpCredential -ServicePrincipalName <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### DisplayNameParameterSet
```
Get-AzADSpCredential -DisplayName <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SPNObjectParameterSet
```
Get-AzADSpCredential -ServicePrincipalObject <IMicrosoftGraphServicePrincipal> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Lists key credentials and password credentials for an service principal.

## EXAMPLES

### Example 1: List credentials from service principal by display name
```powershell
Get-AzADSpCredential -DisplayName $name
```

List credentials from service principal by display name

## PARAMETERS

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

### -DisplayName
Display name of the service principal.

```yaml
Type: System.String
Parameter Sets: DisplayNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ObjectId
The object Id of service principal.

```yaml
Type: System.String
Parameter Sets: ObjectIdParameterSet
Aliases: Id

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServicePrincipalName
The service principal name.

```yaml
Type: System.String
Parameter Sets: SPNParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServicePrincipalObject
The service principal object, could be used as pipeline input.
To construct, see NOTES section for SERVICEPRINCIPALOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphServicePrincipal
Parameter Sets: SPNObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphServicePrincipal

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphKeyCredential

### Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphPasswordCredential

## NOTES

ALIASES

Get-AzADServicePrincipalCredential

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


SERVICEPRINCIPALOBJECT <IMicrosoftGraphServicePrincipal>: The service principal object, could be used as pipeline input.
  - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[DeletedDateTime <DateTime?>]`: 
  - `[DisplayName <String>]`: The name displayed in directory
  - `[AccountEnabled <Boolean?>]`: true if the service principal account is enabled; otherwise, false. Supports $filter (eq, ne, NOT, in).
  - `[AddIn <List<IMicrosoftGraphAddIn>>]`: Defines custom behavior that a consuming service can use to call an app in specific contexts. For example, applications that can render file streams may set the addIns property for its 'FileHandler' functionality. This will let services like Microsoft 365 call the application in the context of a document the user is working on.
    - `[Id <String>]`: 
    - `[Property <List<IMicrosoftGraphKeyValue>>]`: 
      - `[Key <String>]`: Key.
      - `[Value <String>]`: Value.
    - `[Type <String>]`: 
  - `[AlternativeName <List<String>>]`: Used to retrieve service principals by subscription, identify resource group and full resource ids for managed identities. Supports $filter (eq, NOT, ge, le, startsWith).
  - `[AppDescription <String>]`: The description exposed by the associated application.
  - `[AppDisplayName <String>]`: The display name exposed by the associated application.
  - `[AppId <String>]`: The unique identifier for the associated application (its appId property).
  - `[AppOwnerOrganizationId <String>]`: Contains the tenant id where the application is registered. This is applicable only to service principals backed by applications.Supports $filter (eq, ne, NOT, ge, le).
  - `[AppRole <List<IMicrosoftGraphAppRole>>]`: The roles exposed by the application which this service principal represents. For more information see the appRoles property definition on the application entity. Not nullable.
    - `[AllowedMemberType <List<String>>]`: Specifies whether this app role can be assigned to users and groups (by setting to ['User']), to other application's (by setting to ['Application'], or both (by setting to ['User', 'Application']). App roles supporting assignment to other applications' service principals are also known as application permissions. The 'Application' value is only supported for app roles defined on application entities.
    - `[Description <String>]`: The description for the app role. This is displayed when the app role is being assigned and, if the app role functions as an application permission, during  consent experiences.
    - `[DisplayName <String>]`: Display name for the permission that appears in the app role assignment and consent experiences.
    - `[Id <String>]`: Unique role identifier inside the appRoles collection. When creating a new app role, a new Guid identifier must be provided.
    - `[IsEnabled <Boolean?>]`: When creating or updating an app role, this must be set to true (which is the default). To delete a role, this must first be set to false.  At that point, in a subsequent call, this role may be removed.
    - `[Value <String>]`: Specifies the value to include in the roles claim in ID tokens and access tokens authenticating an assigned user or service principal. Must not exceed 120 characters in length. Allowed characters are : ! # $ % & ' ( ) * + , - . / : ;  =  ? @ [ ] ^ + _  {  } ~, as well as characters in the ranges 0-9, A-Z and a-z. Any other character, including the space character, are not allowed. May not begin with ..
  - `[AppRoleAssignedTo <List<IMicrosoftGraphAppRoleAssignment>>]`: App role assignments for this app or service, granted to users, groups, and other service principals.Supports $expand.
    - `[AppRoleId <String>]`: The identifier (id) for the app role which is assigned to the principal. This app role must be exposed in the appRoles property on the resource application's service principal (resourceId). If the resource application has not declared any app roles, a default app role ID of 00000000-0000-0000-0000-000000000000 can be specified to signal that the principal is assigned to the resource app without any specific app roles. Required on create.
    - `[PrincipalId <String>]`: The unique identifier (id) for the user, group or service principal being granted the app role. Required on create.
    - `[ResourceDisplayName <String>]`: The display name of the resource app's service principal to which the assignment is made.
    - `[ResourceId <String>]`: The unique identifier (id) for the resource service principal for which the assignment is made. Required on create. Supports $filter (eq only).
  - `[AppRoleAssignment <List<IMicrosoftGraphAppRoleAssignment>>]`: App role assignment for another app or service, granted to this service principal. Supports $expand.
  - `[AppRoleAssignmentRequired <Boolean?>]`: Specifies whether users or other service principals need to be granted an app role assignment for this service principal before users can sign in or apps can get tokens. The default value is false. Not nullable. Supports $filter (eq, ne, NOT).
  - `[ClaimsMappingPolicy <List<IMicrosoftGraphClaimsMappingPolicy>>]`: The claimsMappingPolicies assigned to this service principal. Supports $expand.
  - `[DelegatedPermissionClassification <List<IMicrosoftGraphDelegatedPermissionClassification>>]`: The permission classifications for delegated permissions exposed by the app that this service principal represents. Supports $expand.
  - `[Description <String>]`: Free text field to provide an internal end-user facing description of the service principal. End-user portals such MyApps will display the application description in this field. The maximum allowed size is 1024 characters. Supports $filter (eq, ne, NOT, ge, le, startsWith) and $search.
  - `[DisabledByMicrosoftStatus <String>]`: Specifies whether Microsoft has disabled the registered application. Possible values are: null (default value), NotDisabled, and DisabledDueToViolationOfServicesAgreement (reasons may include suspicious, abusive, or malicious activity, or a violation of the Microsoft Services Agreement).  Supports $filter (eq, ne, NOT).
  - `[Endpoint <List<IMicrosoftGraphEndpoint>>]`: Endpoints available for discovery. Services like Sharepoint populate this property with a tenant specific SharePoint endpoints that other applications can discover and use in their experiences.
  - `[FederatedIdentityCredentials <List<IMicrosoftGraphFederatedIdentityCredential>>]`: 
  - `[HomeRealmDiscoveryPolicy <List<IMicrosoftGraphHomeRealmDiscoveryPolicy>>]`: The homeRealmDiscoveryPolicies assigned to this service principal. Supports $expand.
  - `[Homepage <String>]`: Home page or landing page of the application.
  - `[Info <IMicrosoftGraphInformationalUrl>]`: informationalUrl
  - `[KeyCredentials <List<IMicrosoftGraphKeyCredential>>]`: The collection of key credentials associated with the service principal. Not nullable. Supports $filter (eq, NOT, ge, le).
  - `[LoginUrl <String>]`: Specifies the URL where the service provider redirects the user to Azure AD to authenticate. Azure AD uses the URL to launch the application from Microsoft 365 or the Azure AD My Apps. When blank, Azure AD performs IdP-initiated sign-on for applications configured with SAML-based single sign-on. The user launches the application from Microsoft 365, the Azure AD My Apps, or the Azure AD SSO URL.
  - `[LogoutUrl <String>]`: Specifies the URL that will be used by Microsoft's authorization service to logout an user using OpenId Connect front-channel, back-channel or SAML logout protocols.
  - `[Note <String>]`: Free text field to capture information about the service principal, typically used for operational purposes. Maximum allowed size is 1024 characters.
  - `[NotificationEmailAddress <List<String>>]`: Specifies the list of email addresses where Azure AD sends a notification when the active certificate is near the expiration date. This is only for the certificates used to sign the SAML token issued for Azure AD Gallery applications.
  - `[Oauth2PermissionScope <List<IMicrosoftGraphPermissionScope>>]`: The delegated permissions exposed by the application. For more information see the oauth2PermissionScopes property on the application entity's api property. Not nullable.
  - `[PasswordCredentials <List<IMicrosoftGraphPasswordCredential>>]`: The collection of password credentials associated with the service principal. Not nullable.
  - `[PreferredSingleSignOnMode <String>]`: Specifies the single sign-on mode configured for this application. Azure AD uses the preferred single sign-on mode to launch the application from Microsoft 365 or the Azure AD My Apps. The supported values are password, saml, notSupported, and oidc.
  - `[PreferredTokenSigningKeyThumbprint <String>]`: Reserved for internal use only. Do not write or otherwise rely on this property. May be removed in future versions.
  - `[ReplyUrl <List<String>>]`: The URLs that user tokens are sent to for sign in with the associated application, or the redirect URIs that OAuth 2.0 authorization codes and access tokens are sent to for the associated application. Not nullable.
  - `[SamlSingleSignOnSetting <IMicrosoftGraphSamlSingleSignOnSettings>]`: samlSingleSignOnSettings
  - `[ServicePrincipalName <List<String>>]`: Contains the list of identifiersUris, copied over from the associated application. Additional values can be added to hybrid applications. These values can be used to identify the permissions exposed by this app within Azure AD. For example,Client apps can specify a resource URI which is based on the values of this property to acquire an access token, which is the URI returned in the 'aud' claim.The any operator is required for filter expressions on multi-valued properties. Not nullable.  Supports $filter (eq, NOT, ge, le, startsWith).
  - `[ServicePrincipalType <String>]`: Identifies if the service principal represents an application or a managed identity. This is set by Azure AD internally. For a service principal that represents an application this is set as Application. For a service principal that represent a managed identity this is set as ManagedIdentity.
  - `[Tag <List<String>>]`: Custom strings that can be used to categorize and identify the service principal. Not nullable. Supports $filter (eq, NOT, ge, le, startsWith).
  - `[TokenEncryptionKeyId <String>]`: Specifies the keyId of a public key from the keyCredentials collection. When configured, Azure AD issues tokens for this application encrypted using the key specified by this property. The application code that receives the encrypted token must use the matching private key to decrypt the token before it can be used for the signed-in user.
  - `[TokenIssuancePolicy <List<IMicrosoftGraphTokenIssuancePolicy>>]`: The tokenIssuancePolicies assigned to this service principal. Supports $expand.
  - `[TokenLifetimePolicy <List<IMicrosoftGraphTokenLifetimePolicy>>]`: The tokenLifetimePolicies assigned to this service principal. Supports $expand.
  - `[TransitiveMemberOf <List<IMicrosoftGraphDirectoryObject>>]`: 

## RELATED LINKS

## RELATED LINKS
