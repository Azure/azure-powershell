---
external help file:
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/update-azadserviceprincipal
schema: 2.0.0
---

# Update-AzADServicePrincipal

## SYNOPSIS
Updates entity in service principal

## SYNTAX

### SpObjectIdWithDisplayNameParameterSet (Default)
```
Update-AzADServicePrincipal -ObjectId <String> [-AccountEnabled] [-AddIn <IMicrosoftGraphAddIn[]>]
 [-AlternativeName <String[]>] [-AppDescription <String>] [-AppOwnerOrganizationId <String>]
 [-AppRole <IMicrosoftGraphAppRole[]>] [-AppRoleAssignedTo <IMicrosoftGraphAppRoleAssignment[]>]
 [-AppRoleAssignment <IMicrosoftGraphAppRoleAssignment[]>] [-AppRoleAssignmentRequired]
 [-ClaimsMappingPolicy <IMicrosoftGraphClaimsMappingPolicy[]>]
 [-DelegatedPermissionClassification <IMicrosoftGraphDelegatedPermissionClassification[]>]
 [-DeletedDateTime <DateTime>] [-Description <String>] [-DisabledByMicrosoftStatus <String>]
 [-DisplayName <String>] [-Endpoint <IMicrosoftGraphEndpoint[]>] [-Homepage <String>]
 [-HomeRealmDiscoveryPolicy <IMicrosoftGraphHomeRealmDiscoveryPolicy[]>] [-IdentifierUri <String[]>]
 [-Info <IMicrosoftGraphInformationalUrl>] [-KeyCredential <IMicrosoftGraphKeyCredential[]>]
 [-LoginUrl <String>] [-LogoutUrl <String>] [-Note <String>] [-NotificationEmailAddress <String[]>]
 [-Oauth2PermissionScope <IMicrosoftGraphPermissionScope[]>]
 [-PasswordCredential <IMicrosoftGraphPasswordCredential[]>] [-PreferredSingleSignOnMode <String>]
 [-PreferredTokenSigningKeyThumbprint <String>] [-ReplyUrl <String[]>]
 [-SamlSingleSignOnSetting <IMicrosoftGraphSamlSingleSignOnSettings>] [-ServicePrincipalType <String>]
 [-Tag <String[]>] [-TokenEncryptionKeyId <String>]
 [-TokenIssuancePolicy <IMicrosoftGraphTokenIssuancePolicy[]>]
 [-TokenLifetimePolicy <IMicrosoftGraphTokenLifetimePolicy[]>]
 [-TransitiveMemberOf <IMicrosoftGraphDirectoryObject[]>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### InputObjectWithDisplayNameParameterSet
```
Update-AzADServicePrincipal -InputObject <IMicrosoftGraphServicePrincipal> [-AccountEnabled]
 [-AddIn <IMicrosoftGraphAddIn[]>] [-AlternativeName <String[]>] [-AppDescription <String>]
 [-AppOwnerOrganizationId <String>] [-AppRole <IMicrosoftGraphAppRole[]>]
 [-AppRoleAssignedTo <IMicrosoftGraphAppRoleAssignment[]>]
 [-AppRoleAssignment <IMicrosoftGraphAppRoleAssignment[]>] [-AppRoleAssignmentRequired]
 [-ClaimsMappingPolicy <IMicrosoftGraphClaimsMappingPolicy[]>]
 [-DelegatedPermissionClassification <IMicrosoftGraphDelegatedPermissionClassification[]>]
 [-DeletedDateTime <DateTime>] [-Description <String>] [-DisabledByMicrosoftStatus <String>]
 [-DisplayName <String>] [-Endpoint <IMicrosoftGraphEndpoint[]>] [-Homepage <String>]
 [-HomeRealmDiscoveryPolicy <IMicrosoftGraphHomeRealmDiscoveryPolicy[]>] [-IdentifierUri <String[]>]
 [-Info <IMicrosoftGraphInformationalUrl>] [-KeyCredential <IMicrosoftGraphKeyCredential[]>]
 [-LoginUrl <String>] [-LogoutUrl <String>] [-Note <String>] [-NotificationEmailAddress <String[]>]
 [-Oauth2PermissionScope <IMicrosoftGraphPermissionScope[]>]
 [-PasswordCredential <IMicrosoftGraphPasswordCredential[]>] [-PreferredSingleSignOnMode <String>]
 [-PreferredTokenSigningKeyThumbprint <String>] [-ReplyUrl <String[]>]
 [-SamlSingleSignOnSetting <IMicrosoftGraphSamlSingleSignOnSettings>] [-ServicePrincipalType <String>]
 [-Tag <String[]>] [-TokenEncryptionKeyId <String>]
 [-TokenIssuancePolicy <IMicrosoftGraphTokenIssuancePolicy[]>]
 [-TokenLifetimePolicy <IMicrosoftGraphTokenLifetimePolicy[]>]
 [-TransitiveMemberOf <IMicrosoftGraphDirectoryObject[]>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### SpApplicationIdWithDisplayNameParameterSet
```
Update-AzADServicePrincipal -ApplicationId <Guid> [-AccountEnabled] [-AddIn <IMicrosoftGraphAddIn[]>]
 [-AlternativeName <String[]>] [-AppDescription <String>] [-AppOwnerOrganizationId <String>]
 [-AppRole <IMicrosoftGraphAppRole[]>] [-AppRoleAssignedTo <IMicrosoftGraphAppRoleAssignment[]>]
 [-AppRoleAssignment <IMicrosoftGraphAppRoleAssignment[]>] [-AppRoleAssignmentRequired]
 [-ClaimsMappingPolicy <IMicrosoftGraphClaimsMappingPolicy[]>]
 [-DelegatedPermissionClassification <IMicrosoftGraphDelegatedPermissionClassification[]>]
 [-DeletedDateTime <DateTime>] [-Description <String>] [-DisabledByMicrosoftStatus <String>]
 [-DisplayName <String>] [-Endpoint <IMicrosoftGraphEndpoint[]>] [-Homepage <String>]
 [-HomeRealmDiscoveryPolicy <IMicrosoftGraphHomeRealmDiscoveryPolicy[]>] [-IdentifierUri <String[]>]
 [-Info <IMicrosoftGraphInformationalUrl>] [-KeyCredential <IMicrosoftGraphKeyCredential[]>]
 [-LoginUrl <String>] [-LogoutUrl <String>] [-Note <String>] [-NotificationEmailAddress <String[]>]
 [-Oauth2PermissionScope <IMicrosoftGraphPermissionScope[]>]
 [-PasswordCredential <IMicrosoftGraphPasswordCredential[]>] [-PreferredSingleSignOnMode <String>]
 [-PreferredTokenSigningKeyThumbprint <String>] [-ReplyUrl <String[]>]
 [-SamlSingleSignOnSetting <IMicrosoftGraphSamlSingleSignOnSettings>] [-ServicePrincipalType <String>]
 [-Tag <String[]>] [-TokenEncryptionKeyId <String>]
 [-TokenIssuancePolicy <IMicrosoftGraphTokenIssuancePolicy[]>]
 [-TokenLifetimePolicy <IMicrosoftGraphTokenLifetimePolicy[]>]
 [-TransitiveMemberOf <IMicrosoftGraphDirectoryObject[]>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### SPNWithDisplayNameParameterSet
```
Update-AzADServicePrincipal -ServicePrincipalName <String> [-AccountEnabled] [-AddIn <IMicrosoftGraphAddIn[]>]
 [-AlternativeName <String[]>] [-AppDescription <String>] [-AppOwnerOrganizationId <String>]
 [-AppRole <IMicrosoftGraphAppRole[]>] [-AppRoleAssignedTo <IMicrosoftGraphAppRoleAssignment[]>]
 [-AppRoleAssignment <IMicrosoftGraphAppRoleAssignment[]>] [-AppRoleAssignmentRequired]
 [-ClaimsMappingPolicy <IMicrosoftGraphClaimsMappingPolicy[]>]
 [-DelegatedPermissionClassification <IMicrosoftGraphDelegatedPermissionClassification[]>]
 [-DeletedDateTime <DateTime>] [-Description <String>] [-DisabledByMicrosoftStatus <String>]
 [-DisplayName <String>] [-Endpoint <IMicrosoftGraphEndpoint[]>] [-Homepage <String>]
 [-HomeRealmDiscoveryPolicy <IMicrosoftGraphHomeRealmDiscoveryPolicy[]>] [-IdentifierUri <String[]>]
 [-Info <IMicrosoftGraphInformationalUrl>] [-KeyCredential <IMicrosoftGraphKeyCredential[]>]
 [-LoginUrl <String>] [-LogoutUrl <String>] [-Note <String>] [-NotificationEmailAddress <String[]>]
 [-Oauth2PermissionScope <IMicrosoftGraphPermissionScope[]>]
 [-PasswordCredential <IMicrosoftGraphPasswordCredential[]>] [-PreferredSingleSignOnMode <String>]
 [-PreferredTokenSigningKeyThumbprint <String>] [-ReplyUrl <String[]>]
 [-SamlSingleSignOnSetting <IMicrosoftGraphSamlSingleSignOnSettings>] [-ServicePrincipalType <String>]
 [-Tag <String[]>] [-TokenEncryptionKeyId <String>]
 [-TokenIssuancePolicy <IMicrosoftGraphTokenIssuancePolicy[]>]
 [-TokenLifetimePolicy <IMicrosoftGraphTokenLifetimePolicy[]>]
 [-TransitiveMemberOf <IMicrosoftGraphDirectoryObject[]>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates entity in service principal

## EXAMPLES

### Example 1: Update service principal and associated application by display name
```powershell
Update-AzADServicePrincipal -DisplayName $name -IdentifierUri $uri
```

Update service principal and associated application by display name, 'IdentifierUri', 'PasswordCredential', 'KeyCredential' will be assigned to application

### Example 2: Update service principal by pipeline input
```powershell
Get-AzADServicePrincipal -ObjectId $id | Update-AzADServicePrincipal -Note $note
```

Update service principal and associated application by display name, 'IdentifierUri', 'PasswordCredential', 'KeyCredential' will be assigned to application

## PARAMETERS

### -AccountEnabled
true if the service principal account is enabled; otherwise, false.
Supports $filter (eq, ne, NOT, in).

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

### -AddIn
Defines custom behavior that a consuming service can use to call an app in specific contexts.
For example, applications that can render file streams may set the addIns property for its 'FileHandler' functionality.
This will let services like Microsoft 365 call the application in the context of a document the user is working on.
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

### -AlternativeName
Used to retrieve service principals by subscription, identify resource group and full resource ids for managed identities.
Supports $filter (eq, NOT, ge, le, startsWith).

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

### -AppDescription
The description exposed by the associated application.

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

### -ApplicationId
The unique identifier for the associated application (its appId property).

```yaml
Type: System.Guid
Parameter Sets: SpApplicationIdWithDisplayNameParameterSet
Aliases: AppId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AppOwnerOrganizationId
Contains the tenant id where the application is registered.
This is applicable only to service principals backed by applications.Supports $filter (eq, ne, NOT, ge, le).

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
The roles exposed by the application which this service principal represents.
For more information see the appRoles property definition on the application entity.
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

### -AppRoleAssignedTo
App role assignments for this app or service, granted to users, groups, and other service principals.Supports $expand.
To construct, see NOTES section for APPROLEASSIGNEDTO properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphAppRoleAssignment[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AppRoleAssignment
App role assignment for another app or service, granted to this service principal.
Supports $expand.
To construct, see NOTES section for APPROLEASSIGNMENT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphAppRoleAssignment[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AppRoleAssignmentRequired
Specifies whether users or other service principals need to be granted an app role assignment for this service principal before users can sign in or apps can get tokens.
The default value is false.
Not nullable.
Supports $filter (eq, ne, NOT).

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

### -ClaimsMappingPolicy
The claimsMappingPolicies assigned to this service principal.
Supports $expand.
To construct, see NOTES section for CLAIMSMAPPINGPOLICY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphClaimsMappingPolicy[]
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

### -DelegatedPermissionClassification
The permission classifications for delegated permissions exposed by the app that this service principal represents.
Supports $expand.
To construct, see NOTES section for DELEGATEDPERMISSIONCLASSIFICATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphDelegatedPermissionClassification[]
Parameter Sets: (All)
Aliases:

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
Free text field to provide an internal end-user facing description of the service principal.
End-user portals such MyApps will display the application description in this field.
The maximum allowed size is 1024 characters.
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
The display name for the service principal.
Supports $filter (eq, ne, NOT, ge, le, in, startsWith), $search, and $orderBy.

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

### -Endpoint
Endpoints available for discovery.
Services like Sharepoint populate this property with a tenant specific SharePoint endpoints that other applications can discover and use in their experiences.
To construct, see NOTES section for ENDPOINT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphEndpoint[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Homepage
Home page or landing page of the application.

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

### -HomeRealmDiscoveryPolicy
The homeRealmDiscoveryPolicies assigned to this service principal.
Supports $expand.
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
The URIs that identify the application within its Azure AD tenant, or within a verified custom domain if the application is multi-tenant.
For more information, see Application Objects and Service Principal Objects.
The any operator is required for filter expressions on multi-valued properties.
Not nullable.
Supports $filter (eq, ne, ge, le, startsWith).

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

### -InputObject
service principal object

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphServicePrincipal
Parameter Sets: InputObjectWithDisplayNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -KeyCredential
The collection of key credentials associated with the application.
Not nullable.
Supports $filter (eq, NOT, ge, le).
To construct, see NOTES section for KEYCREDENTIALS properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphKeyCredential[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LoginUrl
Specifies the URL where the service provider redirects the user to Azure AD to authenticate.
Azure AD uses the URL to launch the application from Microsoft 365 or the Azure AD My Apps.
When blank, Azure AD performs IdP-initiated sign-on for applications configured with SAML-based single sign-on.
The user launches the application from Microsoft 365, the Azure AD My Apps, or the Azure AD SSO URL.

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

### -LogoutUrl
Specifies the URL that will be used by Microsoft's authorization service to logout an user using OpenId Connect front-channel, back-channel or SAML logout protocols.

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
Free text field to capture information about the service principal, typically used for operational purposes.
Maximum allowed size is 1024 characters.

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

### -NotificationEmailAddress
Specifies the list of email addresses where Azure AD sends a notification when the active certificate is near the expiration date.
This is only for the certificates used to sign the SAML token issued for Azure AD Gallery applications.

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

### -Oauth2PermissionScope
The delegated permissions exposed by the application.
For more information see the oauth2PermissionScopes property on the application entity's api property.
Not nullable.
To construct, see NOTES section for OAUTH2PERMISSIONSCOPE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphPermissionScope[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ObjectId
key: id of servicePrincipal

```yaml
Type: System.String
Parameter Sets: SpObjectIdWithDisplayNameParameterSet
Aliases: ServicePrincipalId, Id, ServicePrincipalObjectId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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

### -PasswordCredential
The collection of password credentials associated with the application.
Not nullable.
To construct, see NOTES section for PASSWORDCREDENTIALS properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphPasswordCredential[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PreferredSingleSignOnMode
Specifies the single sign-on mode configured for this application.
Azure AD uses the preferred single sign-on mode to launch the application from Microsoft 365 or the Azure AD My Apps.
The supported values are password, saml, notSupported, and oidc.

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

### -PreferredTokenSigningKeyThumbprint
Reserved for internal use only.
Do not write or otherwise rely on this property.
May be removed in future versions.

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

### -ReplyUrl
The URLs that user tokens are sent to for sign in with the associated application, or the redirect URIs that OAuth 2.0 authorization codes and access tokens are sent to for the associated application.
Not nullable.

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

### -SamlSingleSignOnSetting
samlSingleSignOnSettings
To construct, see NOTES section for SAMLSINGLESIGNONSETTING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphSamlSingleSignOnSettings
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServicePrincipalName
Contains the list of identifiersUris, copied over from the associated application.
Additional values can be added to hybrid applications.
These values can be used to identify the permissions exposed by this app within Azure AD.
For example,Client apps can specify a resource URI which is based on the values of this property to acquire an access token, which is the URI returned in the 'aud' claim.The any operator is required for filter expressions on multi-valued properties.
Not nullable.
Supports $filter (eq, NOT, ge, le, startsWith).

```yaml
Type: System.String
Parameter Sets: SPNWithDisplayNameParameterSet
Aliases: SPN

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServicePrincipalType
Identifies if the service principal represents an application or a managed identity.
This is set by Azure AD internally.
For a service principal that represents an application this is set as Application.
For a service principal that represent a managed identity this is set as ManagedIdentity.

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

### -Tag
Custom strings that can be used to categorize and identify the service principal.
Not nullable.
Supports $filter (eq, NOT, ge, le, startsWith).

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
When configured, Azure AD issues tokens for this application encrypted using the key specified by this property.
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
The tokenIssuancePolicies assigned to this service principal.
Supports $expand.
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
The tokenLifetimePolicies assigned to this service principal.
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

### -TransitiveMemberOf
.
To construct, see NOTES section for TRANSITIVEMEMBEROF properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphDirectoryObject[]
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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphServicePrincipal

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

Set-AzADServicePrincipal

## RELATED LINKS

