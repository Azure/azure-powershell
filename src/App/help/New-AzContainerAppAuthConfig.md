---
external help file:
Module Name: Az.App
online version: https://docs.microsoft.com/powershell/module/az.app/new-azcontainerappauthconfig
schema: 2.0.0
---

# New-AzContainerAppAuthConfig

## SYNOPSIS
Create or update the AuthConfig for a Container App.

## SYNTAX

```
New-AzContainerAppAuthConfig -AuthConfigName <String> -ContainerAppName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-CookieExpirationConvention <CookieExpirationConvention>]
 [-CookieExpirationTimeToExpiration <String>] [-ForwardProxyConvention <ForwardProxyConvention>]
 [-ForwardProxyCustomHostHeaderName <String>] [-ForwardProxyCustomProtoHeaderName <String>]
 [-GlobalValidationExcludedPath <String[]>] [-GlobalValidationRedirectToProvider <String>]
 [-GlobalValidationUnauthenticatedClientAction <UnauthenticatedClientActionV2>] [-HttpSettingRequireHttps]
 [-IdentityProvider <IIdentityProviders>] [-LoginAllowedExternalRedirectUrl <String[]>]
 [-LoginPreserveUrlFragmentsForLogin] [-NonceExpirationInterval <String>] [-NonceValidateNonce]
 [-PlatformEnabled] [-PlatformRuntimeVersion <String>] [-RouteApiPrefix <String>]
 [-RouteLogoutEndpoint <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or update the AuthConfig for a Container App.

## EXAMPLES

### Example 1: Create or update the AuthConfig for a Container App.
```powershell
$identity = New-AzContainerAppIdentityProviderObject -RegistrationAppId xxxxxx@xxx.com -RegistrationAppSecretSettingName facebook-secret

New-AzContainerAppAuthConfig -AuthConfigName current -ContainerAppName azps-containerapp -ResourceGroupName azpstest_gp -PlatformEnabled -GlobalValidationUnauthenticatedClientAction 'AllowAnonymous' -IdentityProvider $identity
```

```output
Name    PlatformEnabled ResourceGroupName
----    --------------- -----------------
current True            azpstest_gp
```

Create or update the AuthConfig for a Container App.

## PARAMETERS

### -AuthConfigName
Name of the Container App AuthConfig.

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

### -ContainerAppName
Name of the Container App.

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

### -CookieExpirationConvention
The convention used when determining the session cookie's expiration.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Support.CookieExpirationConvention
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CookieExpirationTimeToExpiration
The time after the request is made when the session cookie should expire.

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

### -ForwardProxyConvention
The convention used to determine the url of the request made.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Support.ForwardProxyConvention
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ForwardProxyCustomHostHeaderName
The name of the header containing the host of the request.

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

### -ForwardProxyCustomProtoHeaderName
The name of the header containing the scheme of the request.

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

### -GlobalValidationExcludedPath
The paths for which unauthenticated flow would not be redirected to the login page.

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

### -GlobalValidationRedirectToProvider
The default authentication provider to use when multiple providers are configured.This setting is only needed if multiple providers are configured and the unauthenticated clientaction is set to "RedirectToLoginPage".

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

### -GlobalValidationUnauthenticatedClientAction
The action to take when an unauthenticated client attempts to access the app.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Support.UnauthenticatedClientActionV2
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpSettingRequireHttps
\<code\>false\</code\> if the authentication/authorization responses not having the HTTPS scheme are permissible; otherwise, \<code\>true\</code\>.

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

### -IdentityProvider
The configuration settings of each of the identity providers used to configure ContainerApp Service Authentication/Authorization.
To construct, see NOTES section for IDENTITYPROVIDER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.IIdentityProviders
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LoginAllowedExternalRedirectUrl
External URLs that can be redirected to as part of logging in or logging out of the app.
Note that the query string part of the URL is ignored.This is an advanced setting typically only needed by Windows Store application backends.Note that URLs within the current domain are always implicitly allowed.

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

### -LoginPreserveUrlFragmentsForLogin
\<code\>true\</code\> if the fragments from the request are preserved after the login request is made; otherwise, \<code\>false\</code\>.

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

### -NonceExpirationInterval
The time after the request is made when the nonce should expire.

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

### -NonceValidateNonce
\<code\>false\</code\> if the nonce should not be validated while completing the login flow; otherwise, \<code\>true\</code\>.

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

### -PlatformEnabled
\<code\>true\</code\> if the Authentication / Authorization feature is enabled for the current app; otherwise, \<code\>false\</code\>.

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

### -PlatformRuntimeVersion
The RuntimeVersion of the Authentication / Authorization feature in use for the current app.The setting in this value can control the behavior of certain features in the Authentication / Authorization module.

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -RouteApiPrefix
The prefix that should precede all the authentication/authorization paths.

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

### -RouteLogoutEndpoint
The endpoint at which a logout request should be made.

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.IAuthConfig

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


IDENTITYPROVIDER <IIdentityProviders>: The configuration settings of each of the identity providers used to configure ContainerApp Service Authentication/Authorization.
  - `[AllowedPrincipalGroup <String[]>]`: The list of the allowed groups.
  - `[AllowedPrincipalIdentity <String[]>]`: The list of the allowed identities.
  - `[AppleEnabled <Boolean?>]`: <code>false</code> if the Apple provider should not be enabled despite the set registration; otherwise, <code>true</code>.
  - `[AppleLoginScope <String[]>]`: A list of the scopes that should be requested while authenticating.
  - `[AppleRegistrationClientId <String>]`: The Client ID of the app used for login.
  - `[AppleRegistrationClientSecretSettingName <String>]`: The app setting name that contains the client secret.
  - `[AzureActiveDirectoryEnabled <Boolean?>]`: <code>false</code> if the Azure Active Directory provider should not be enabled despite the set registration; otherwise, <code>true</code>.
  - `[AzureActiveDirectoryIsAutoProvisioned <Boolean?>]`: Gets a value indicating whether the Azure AD configuration was auto-provisioned using 1st party tooling.         This is an internal flag primarily intended to support the Azure Management Portal. Users should not         read or write to this property.
  - `[AzureActiveDirectoryRegistrationClientId <String>]`: The Client ID of this relying party application, known as the client_id.         This setting is required for enabling OpenID Connection authentication with Azure Active Directory or         other 3rd party OpenID Connect providers.         More information on OpenID Connect: http://openid.net/specs/openid-connect-core-1_0.html
  - `[AzureActiveDirectoryRegistrationClientSecretSettingName <String>]`: The app setting name that contains the client secret of the relying party application.
  - `[AzureActiveDirectoryValidationAllowedAudience <String[]>]`: The list of audiences that can make successful authentication/authorization requests.
  - `[AzureStaticWebAppEnabled <Boolean?>]`: <code>false</code> if the Azure Static Web Apps provider should not be enabled despite the set registration; otherwise, <code>true</code>.
  - `[AzureStaticWebAppsRegistrationClientId <String>]`: The Client ID of the app used for login.
  - `[CustomOpenIdConnectProvider <IIdentityProvidersCustomOpenIdConnectProviders>]`: The map of the name of the alias of each custom Open ID Connect provider to the         configuration settings of the custom Open ID Connect provider.
    - `[(Any) <ICustomOpenIdConnectProvider>]`: This indicates any property can be added to this object.
  - `[DefaultAuthorizationPolicyAllowedApplication <String[]>]`: The configuration settings of the Azure Active Directory allowed applications.
  - `[FacebookEnabled <Boolean?>]`: <code>false</code> if the Facebook provider should not be enabled despite the set registration; otherwise, <code>true</code>.
  - `[FacebookGraphApiVersion <String>]`: The version of the Facebook api to be used while logging in.
  - `[FacebookLoginScope <String[]>]`: A list of the scopes that should be requested while authenticating.
  - `[GitHubEnabled <Boolean?>]`: <code>false</code> if the GitHub provider should not be enabled despite the set registration; otherwise, <code>true</code>.
  - `[GitHubLoginScope <String[]>]`: A list of the scopes that should be requested while authenticating.
  - `[GitHubRegistrationClientId <String>]`: The Client ID of the app used for login.
  - `[GitHubRegistrationClientSecretSettingName <String>]`: The app setting name that contains the client secret.
  - `[GoogleEnabled <Boolean?>]`: <code>false</code> if the Google provider should not be enabled despite the set registration; otherwise, <code>true</code>.
  - `[GoogleLoginScope <String[]>]`: A list of the scopes that should be requested while authenticating.
  - `[GoogleRegistrationClientId <String>]`: The Client ID of the app used for login.
  - `[GoogleRegistrationClientSecretSettingName <String>]`: The app setting name that contains the client secret.
  - `[GoogleValidationAllowedAudience <String[]>]`: The configuration settings of the allowed list of audiences from which to validate the JWT token.
  - `[JwtClaimCheckAllowedClientApplication <String[]>]`: The list of the allowed client applications.
  - `[JwtClaimCheckAllowedGroup <String[]>]`: The list of the allowed groups.
  - `[LoginDisableWwwAuthenticate <Boolean?>]`: <code>true</code> if the www-authenticate provider should be omitted from the request; otherwise, <code>false</code>.
  - `[LoginParameter <String[]>]`: Login parameters to send to the OpenID Connect authorization endpoint when         a user logs in. Each parameter must be in the form "key=value".
  - `[RegistrationAppId <String>]`: The App ID of the app used for login.
  - `[RegistrationAppSecretSettingName <String>]`: The app setting name that contains the app secret.
  - `[RegistrationClientSecretCertificateIssuer <String>]`: An alternative to the client secret thumbprint, that is the issuer of a certificate used for signing purposes. This property acts as         a replacement for the Client Secret Certificate Thumbprint. It is also optional.
  - `[RegistrationClientSecretCertificateSubjectAlternativeName <String>]`: An alternative to the client secret thumbprint, that is the subject alternative name of a certificate used for signing purposes. This property acts as         a replacement for the Client Secret Certificate Thumbprint. It is also optional.
  - `[RegistrationClientSecretCertificateThumbprint <String>]`: An alternative to the client secret, that is the thumbprint of a certificate used for signing purposes. This property acts as         a replacement for the Client Secret. It is also optional.
  - `[RegistrationConsumerKey <String>]`: The OAuth 1.0a consumer key of the Twitter application used for sign-in.         This setting is required for enabling Twitter Sign-In.         Twitter Sign-In documentation: https://dev.twitter.com/web/sign-in
  - `[RegistrationConsumerSecretSettingName <String>]`: The app setting name that contains the OAuth 1.0a consumer secret of the Twitter         application used for sign-in.
  - `[RegistrationOpenIdIssuer <String>]`: The OpenID Connect Issuer URI that represents the entity which issues access tokens for this application.         When using Azure Active Directory, this value is the URI of the directory tenant, e.g. https://login.microsoftonline.com/v2.0/{tenant-guid}/.         This URI is a case-sensitive identifier for the token issuer.         More information on OpenID Connect Discovery: http://openid.net/specs/openid-connect-discovery-1_0.html
  - `[TwitterEnabled <Boolean?>]`: <code>false</code> if the Twitter provider should not be enabled despite the set registration; otherwise, <code>true</code>.

## RELATED LINKS

