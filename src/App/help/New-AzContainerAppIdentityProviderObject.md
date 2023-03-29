---
external help file:
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/az.app/new-azcontainerappidentityproviderobject
schema: 2.0.0
---

# New-AzContainerAppIdentityProviderObject

## SYNOPSIS
Create an in-memory object for IdentityProviders.

## SYNTAX

```
New-AzContainerAppIdentityProviderObject [-AllowedPrincipalGroup <String[]>]
 [-AllowedPrincipalIdentity <String[]>] [-AppleEnabled <Boolean>] [-AppleLoginScope <String[]>]
 [-AppleRegistrationClientId <String>] [-AppleRegistrationClientSecretSettingName <String>]
 [-AzureActiveDirectoryEnabled <Boolean>] [-AzureActiveDirectoryIsAutoProvisioned <Boolean>]
 [-AzureActiveDirectoryRegistrationClientId <String>]
 [-AzureActiveDirectoryRegistrationClientSecretSettingName <String>]
 [-AzureActiveDirectoryValidationAllowedAudience <String[]>] [-AzureStaticWebAppEnabled <Boolean>]
 [-AzureStaticWebAppsRegistrationClientId <String>]
 [-CustomOpenIdConnectProvider <IIdentityProvidersCustomOpenIdConnectProviders>]
 [-DefaultAuthorizationPolicyAllowedApplication <String[]>] [-FacebookEnabled <Boolean>]
 [-FacebookGraphApiVersion <String>] [-FacebookLoginScope <String[]>] [-GitHubEnabled <Boolean>]
 [-GitHubLoginScope <String[]>] [-GitHubRegistrationClientId <String>]
 [-GitHubRegistrationClientSecretSettingName <String>] [-GoogleEnabled <Boolean>]
 [-GoogleLoginScope <String[]>] [-GoogleRegistrationClientId <String>]
 [-GoogleRegistrationClientSecretSettingName <String>] [-GoogleValidationAllowedAudience <String[]>]
 [-JwtClaimCheckAllowedClientApplication <String[]>] [-JwtClaimCheckAllowedGroup <String[]>]
 [-LoginDisableWwwAuthenticate <Boolean>] [-LoginParameter <String[]>] [-RegistrationAppId <String>]
 [-RegistrationAppSecretSettingName <String>] [-RegistrationClientSecretCertificateIssuer <String>]
 [-RegistrationClientSecretCertificateSubjectAlternativeName <String>]
 [-RegistrationClientSecretCertificateThumbprint <String>] [-RegistrationConsumerKey <String>]
 [-RegistrationConsumerSecretSettingName <String>] [-RegistrationOpenIdIssuer <String>]
 [-TwitterEnabled <Boolean>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for IdentityProviders.

## EXAMPLES

### Example 1: Create an IdentityProviders object for AuthConfig.
```powershell
New-AzContainerAppIdentityProviderObject -RegistrationAppId xxxxxx@xxx.com -RegistrationAppSecretSettingName facebook-secret
```

```output
...                              : ...
RegistrationAppId                : xxxxxx@xxx.com
RegistrationAppSecretSettingName : facebook-secret
...                              : ...
```

Create an IdentityProviders object for AuthConfig.

## PARAMETERS

### -AllowedPrincipalGroup
The list of the allowed groups.

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

### -AllowedPrincipalIdentity
The list of the allowed identities.

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

### -AppleEnabled
\<code\>false\</code\> if the Apple provider should not be enabled despite the set registration; otherwise, \<code\>true\</code\>.

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

### -AppleLoginScope
A list of the scopes that should be requested while authenticating.

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

### -AppleRegistrationClientId
The Client ID of the app used for login.

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

### -AppleRegistrationClientSecretSettingName
The app setting name that contains the client secret.

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

### -AzureActiveDirectoryEnabled
\<code\>false\</code\> if the Azure Active Directory provider should not be enabled despite the set registration; otherwise, \<code\>true\</code\>.

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

### -AzureActiveDirectoryIsAutoProvisioned
Gets a value indicating whether the Azure AD configuration was auto-provisioned using 1st party tooling.
        This is an internal flag primarily intended to support the Azure Management Portal.
Users should not
        read or write to this property.

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

### -AzureActiveDirectoryRegistrationClientId
The Client ID of this relying party application, known as the client_id.
        This setting is required for enabling OpenID Connection authentication with Azure Active Directory or
        other 3rd party OpenID Connect providers.
        More information on OpenID Connect: http://openid.net/specs/openid-connect-core-1_0.html.

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

### -AzureActiveDirectoryRegistrationClientSecretSettingName
The app setting name that contains the client secret of the relying party application.

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

### -AzureActiveDirectoryValidationAllowedAudience
The list of audiences that can make successful authentication/authorization requests.

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

### -AzureStaticWebAppEnabled
\<code\>false\</code\> if the Azure Static Web Apps provider should not be enabled despite the set registration; otherwise, \<code\>true\</code\>.

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

### -AzureStaticWebAppsRegistrationClientId
The Client ID of the app used for login.

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

### -CustomOpenIdConnectProvider
The map of the name of the alias of each custom Open ID Connect provider to the
        configuration settings of the custom Open ID Connect provider.
To construct, see NOTES section for CUSTOMOPENIDCONNECTPROVIDER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.IIdentityProvidersCustomOpenIdConnectProviders
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultAuthorizationPolicyAllowedApplication
The configuration settings of the Azure Active Directory allowed applications.

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

### -FacebookEnabled
\<code\>false\</code\> if the Facebook provider should not be enabled despite the set registration; otherwise, \<code\>true\</code\>.

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

### -FacebookGraphApiVersion
The version of the Facebook api to be used while logging in.

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

### -FacebookLoginScope
A list of the scopes that should be requested while authenticating.

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

### -GitHubEnabled
\<code\>false\</code\> if the GitHub provider should not be enabled despite the set registration; otherwise, \<code\>true\</code\>.

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

### -GitHubLoginScope
A list of the scopes that should be requested while authenticating.

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

### -GitHubRegistrationClientId
The Client ID of the app used for login.

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

### -GitHubRegistrationClientSecretSettingName
The app setting name that contains the client secret.

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

### -GoogleEnabled
\<code\>false\</code\> if the Google provider should not be enabled despite the set registration; otherwise, \<code\>true\</code\>.

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

### -GoogleLoginScope
A list of the scopes that should be requested while authenticating.

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

### -GoogleRegistrationClientId
The Client ID of the app used for login.

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

### -GoogleRegistrationClientSecretSettingName
The app setting name that contains the client secret.

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

### -GoogleValidationAllowedAudience
The configuration settings of the allowed list of audiences from which to validate the JWT token.

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

### -JwtClaimCheckAllowedClientApplication
The list of the allowed client applications.

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

### -JwtClaimCheckAllowedGroup
The list of the allowed groups.

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

### -LoginDisableWwwAuthenticate
\<code\>true\</code\> if the www-authenticate provider should be omitted from the request; otherwise, \<code\>false\</code\>.

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

### -LoginParameter
Login parameters to send to the OpenID Connect authorization endpoint when
        a user logs in.
Each parameter must be in the form "key=value".

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

### -RegistrationAppId
The App ID of the app used for login.

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

### -RegistrationAppSecretSettingName
The app setting name that contains the app secret.

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

### -RegistrationClientSecretCertificateIssuer
An alternative to the client secret thumbprint, that is the issuer of a certificate used for signing purposes.
This property acts as
        a replacement for the Client Secret Certificate Thumbprint.
It is also optional.

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

### -RegistrationClientSecretCertificateSubjectAlternativeName
An alternative to the client secret thumbprint, that is the subject alternative name of a certificate used for signing purposes.
This property acts as
        a replacement for the Client Secret Certificate Thumbprint.
It is also optional.

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

### -RegistrationClientSecretCertificateThumbprint
An alternative to the client secret, that is the thumbprint of a certificate used for signing purposes.
This property acts as
        a replacement for the Client Secret.
It is also optional.

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

### -RegistrationConsumerKey
The OAuth 1.0a consumer key of the Twitter application used for sign-in.
        This setting is required for enabling Twitter Sign-In.
        Twitter Sign-In documentation: https://dev.twitter.com/web/sign-in.

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

### -RegistrationConsumerSecretSettingName
The app setting name that contains the OAuth 1.0a consumer secret of the Twitter
        application used for sign-in.

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

### -RegistrationOpenIdIssuer
The OpenID Connect Issuer URI that represents the entity which issues access tokens for this application.
        When using Azure Active Directory, this value is the URI of the directory tenant, e.g.
https://login.microsoftonline.com/v2.0/{tenant-guid}/.
        This URI is a case-sensitive identifier for the token issuer.
        More information on OpenID Connect Discovery: http://openid.net/specs/openid-connect-discovery-1_0.html.

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

### -TwitterEnabled
\<code\>false\</code\> if the Twitter provider should not be enabled despite the set registration; otherwise, \<code\>true\</code\>.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.IdentityProviders

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`CUSTOMOPENIDCONNECTPROVIDER <IIdentityProvidersCustomOpenIdConnectProviders>`: The map of the name of the alias of each custom Open ID Connect provider to the         configuration settings of the custom Open ID Connect provider.
  - `[(Any) <ICustomOpenIdConnectProvider>]`: This indicates any property can be added to this object.

## RELATED LINKS

