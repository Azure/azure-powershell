---
external help file:
Module Name: Az.AppService
online version: https://docs.microsoft.com/en-us/powershell/module/az.appservice/set-azwebappauthsettingslot
schema: 2.0.0
---

# Set-AzWebAppAuthSettingSlot

## SYNOPSIS
Updates the Authentication / Authorization settings associated with web app.

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzWebAppAuthSettingSlot -Name <String> -ResourceGroupName <String> -Slot <String> -SubscriptionId <String>
 [-AdditionalLoginParam <String[]>] [-AllowedAudience <String[]>] [-AllowedExternalRedirectUrl <String[]>]
 [-ClientId <String>] [-ClientSecret <String>] [-ClientSecretCertificateThumbprint <String>]
 [-DefaultProvider <BuiltInAuthenticationProvider>] [-Enabled] [-FacebookAppId <String>]
 [-FacebookAppSecret <String>] [-FacebookOAuthScope <String[]>] [-GoogleClientId <String>]
 [-GoogleClientSecret <String>] [-GoogleOAuthScope <String[]>] [-Issuer <String>] [-Kind <String>]
 [-MicrosoftAccountClientId <String>] [-MicrosoftAccountClientSecret <String>]
 [-MicrosoftAccountOAuthScope <String[]>] [-RuntimeVersion <String>] [-TokenRefreshExtensionHour <Double>]
 [-TokenStoreEnabled] [-TwitterConsumerKey <String>] [-TwitterConsumerSecret <String>]
 [-UnauthenticatedClientAction <UnauthenticatedClientAction>] [-ValidateIssuer] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Set-AzWebAppAuthSettingSlot -Name <String> -ResourceGroupName <String> -Slot <String> -SubscriptionId <String>
 -SiteAuthSetting <ISiteAuthSettings> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates the Authentication / Authorization settings associated with web app.

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

### -AdditionalLoginParam
Login parameters to send to the OpenID Connect authorization endpoint whena user logs in.
Each parameter must be in the form "key=value".

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AllowedAudience
Allowed audience values to consider when validating JWTs issued by Azure Active Directory.
Note that the \<code\>ClientID\</code\> value is always considered anallowed audience, regardless of this setting.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AllowedExternalRedirectUrl
External URLs that can be redirected to as part of logging in or logging out of the app.
Note that the query string part of the URL is ignored.This is an advanced setting typically only needed by Windows Store application backends.Note that URLs within the current domain are always implicitly allowed.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ClientId
The Client ID of this relying party application, known as the client_id.This setting is required for enabling OpenID Connection authentication with Azure Active Directory or other 3rd party OpenID Connect providers.More information on OpenID Connect: http://openid.net/specs/openid-connect-core-1_0.html

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ClientSecret
The Client Secret of this relying party application (in Azure Active Directory, this is also referred to as the Key).This setting is optional.
If no client secret is configured, the OpenID Connect implicit auth flow is used to authenticate end users.Otherwise, the OpenID Connect Authorization Code Flow is used to authenticate end users.More information on OpenID Connect: http://openid.net/specs/openid-connect-core-1_0.html

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ClientSecretCertificateThumbprint
An alternative to the client secret, that is the thumbprint of a certificate used for signing purposes.
This property acts asa replacement for the Client Secret.
It is also optional.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
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

### -DefaultProvider
The default authentication provider to use when multiple providers are configured.This setting is only needed if multiple providers are configured and the unauthenticated clientaction is set to "RedirectToLoginPage".

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Support.BuiltInAuthenticationProvider
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Enabled
\<code\>true\</code\> if the Authentication / Authorization feature is enabled for the current app; otherwise, \<code\>false\</code\>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -FacebookAppId
The App ID of the Facebook app used for login.This setting is required for enabling Facebook Login.Facebook Login documentation: https://developers.facebook.com/docs/facebook-login

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -FacebookAppSecret
The App Secret of the Facebook app used for Facebook Login.This setting is required for enabling Facebook Login.Facebook Login documentation: https://developers.facebook.com/docs/facebook-login

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -FacebookOAuthScope
The OAuth 2.0 scopes that will be requested as part of Facebook Login authentication.This setting is optional.Facebook Login documentation: https://developers.facebook.com/docs/facebook-login

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -GoogleClientId
The OpenID Connect Client ID for the Google web application.This setting is required for enabling Google Sign-In.Google Sign-In documentation: https://developers.google.com/identity/sign-in/web/

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -GoogleClientSecret
The client secret associated with the Google web application.This setting is required for enabling Google Sign-In.Google Sign-In documentation: https://developers.google.com/identity/sign-in/web/

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -GoogleOAuthScope
The OAuth 2.0 scopes that will be requested as part of Google Sign-In authentication.This setting is optional.
If not specified, "openid", "profile", and "email" are used as default scopes.Google Sign-In documentation: https://developers.google.com/identity/sign-in/web/

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Issuer
The OpenID Connect Issuer URI that represents the entity which issues access tokens for this application.When using Azure Active Directory, this value is the URI of the directory tenant, e.g.
https://sts.windows.net/{tenant-guid}/.This URI is a case-sensitive identifier for the token issuer.More information on OpenID Connect Discovery: http://openid.net/specs/openid-connect-discovery-1_0.html

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Kind
Kind of resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MicrosoftAccountClientId
The OAuth 2.0 client ID that was created for the app used for authentication.This setting is required for enabling Microsoft Account authentication.Microsoft Account OAuth documentation: https://dev.onedrive.com/auth/msa_oauth.htm

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MicrosoftAccountClientSecret
The OAuth 2.0 client secret that was created for the app used for authentication.This setting is required for enabling Microsoft Account authentication.Microsoft Account OAuth documentation: https://dev.onedrive.com/auth/msa_oauth.htm

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MicrosoftAccountOAuthScope
The OAuth 2.0 scopes that will be requested as part of Microsoft Account authentication.This setting is optional.
If not specified, "wl.basic" is used as the default scope.Microsoft Account Scopes and permissions documentation: https://msdn.microsoft.com/en-us/library/dn631845.aspx

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
Name of web app.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
Name of the resource group to which the resource belongs.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RuntimeVersion
The RuntimeVersion of the Authentication / Authorization feature in use for the current app.The setting in this value can control the behavior of certain features in the Authentication / Authorization module.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SiteAuthSetting
Configuration settings for the Azure App Service Authentication / Authorization feature.
To construct, see NOTES section for SITEAUTHSETTING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20180201.ISiteAuthSettings
Parameter Sets: Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Slot
Name of web app slot.
If not specified then will default to production slot.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Your Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000).

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TokenRefreshExtensionHour
The number of hours after session token expiration that a session token can be used tocall the token refresh API.
The default is 72 hours.

```yaml
Type: System.Double
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TokenStoreEnabled
\<code\>true\</code\> to durably store platform-specific security tokens that are obtained during login flows; otherwise, \<code\>false\</code\>.
The default is \<code\>false\</code\>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TwitterConsumerKey
The OAuth 1.0a consumer key of the Twitter application used for sign-in.This setting is required for enabling Twitter Sign-In.Twitter Sign-In documentation: https://dev.twitter.com/web/sign-in

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TwitterConsumerSecret
The OAuth 1.0a consumer secret of the Twitter application used for sign-in.This setting is required for enabling Twitter Sign-In.Twitter Sign-In documentation: https://dev.twitter.com/web/sign-in

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -UnauthenticatedClientAction
The action to take when an unauthenticated client attempts to access the app.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Support.UnauthenticatedClientAction
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ValidateIssuer
Gets a value indicating whether the issuer should be a valid HTTPS url and be validated as such.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20180201.ISiteAuthSettings

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20180201.ISiteAuthSettings

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### SITEAUTHSETTING <ISiteAuthSettings>: Configuration settings for the Azure App Service Authentication / Authorization feature.
  - `[Kind <String>]`: Kind of resource.
  - `[AdditionalLoginParam <String[]>]`: Login parameters to send to the OpenID Connect authorization endpoint when         a user logs in. Each parameter must be in the form "key=value".
  - `[AllowedAudience <String[]>]`: Allowed audience values to consider when validating JWTs issued by         Azure Active Directory. Note that the <code>ClientID</code> value is always considered an         allowed audience, regardless of this setting.
  - `[AllowedExternalRedirectUrl <String[]>]`: External URLs that can be redirected to as part of logging in or logging out of the app. Note that the query string part of the URL is ignored.         This is an advanced setting typically only needed by Windows Store application backends.         Note that URLs within the current domain are always implicitly allowed.
  - `[ClientId <String>]`: The Client ID of this relying party application, known as the client_id.         This setting is required for enabling OpenID Connection authentication with Azure Active Directory or         other 3rd party OpenID Connect providers.         More information on OpenID Connect: http://openid.net/specs/openid-connect-core-1_0.html
  - `[ClientSecret <String>]`: The Client Secret of this relying party application (in Azure Active Directory, this is also referred to as the Key).         This setting is optional. If no client secret is configured, the OpenID Connect implicit auth flow is used to authenticate end users.         Otherwise, the OpenID Connect Authorization Code Flow is used to authenticate end users.         More information on OpenID Connect: http://openid.net/specs/openid-connect-core-1_0.html
  - `[ClientSecretCertificateThumbprint <String>]`: An alternative to the client secret, that is the thumbprint of a certificate used for signing purposes. This property acts as         a replacement for the Client Secret. It is also optional.
  - `[DefaultProvider <BuiltInAuthenticationProvider?>]`: The default authentication provider to use when multiple providers are configured.         This setting is only needed if multiple providers are configured and the unauthenticated client         action is set to "RedirectToLoginPage".
  - `[Enabled <Boolean?>]`: <code>true</code> if the Authentication / Authorization feature is enabled for the current app; otherwise, <code>false</code>.
  - `[FacebookAppId <String>]`: The App ID of the Facebook app used for login.         This setting is required for enabling Facebook Login.         Facebook Login documentation: https://developers.facebook.com/docs/facebook-login
  - `[FacebookAppSecret <String>]`: The App Secret of the Facebook app used for Facebook Login.         This setting is required for enabling Facebook Login.         Facebook Login documentation: https://developers.facebook.com/docs/facebook-login
  - `[FacebookOAuthScope <String[]>]`: The OAuth 2.0 scopes that will be requested as part of Facebook Login authentication.         This setting is optional.         Facebook Login documentation: https://developers.facebook.com/docs/facebook-login
  - `[GoogleClientId <String>]`: The OpenID Connect Client ID for the Google web application.         This setting is required for enabling Google Sign-In.         Google Sign-In documentation: https://developers.google.com/identity/sign-in/web/
  - `[GoogleClientSecret <String>]`: The client secret associated with the Google web application.         This setting is required for enabling Google Sign-In.         Google Sign-In documentation: https://developers.google.com/identity/sign-in/web/
  - `[GoogleOAuthScope <String[]>]`: The OAuth 2.0 scopes that will be requested as part of Google Sign-In authentication.         This setting is optional. If not specified, "openid", "profile", and "email" are used as default scopes.         Google Sign-In documentation: https://developers.google.com/identity/sign-in/web/
  - `[Issuer <String>]`: The OpenID Connect Issuer URI that represents the entity which issues access tokens for this application.         When using Azure Active Directory, this value is the URI of the directory tenant, e.g. https://sts.windows.net/{tenant-guid}/.         This URI is a case-sensitive identifier for the token issuer.         More information on OpenID Connect Discovery: http://openid.net/specs/openid-connect-discovery-1_0.html
  - `[MicrosoftAccountClientId <String>]`: The OAuth 2.0 client ID that was created for the app used for authentication.         This setting is required for enabling Microsoft Account authentication.         Microsoft Account OAuth documentation: https://dev.onedrive.com/auth/msa_oauth.htm
  - `[MicrosoftAccountClientSecret <String>]`: The OAuth 2.0 client secret that was created for the app used for authentication.         This setting is required for enabling Microsoft Account authentication.         Microsoft Account OAuth documentation: https://dev.onedrive.com/auth/msa_oauth.htm
  - `[MicrosoftAccountOAuthScope <String[]>]`: The OAuth 2.0 scopes that will be requested as part of Microsoft Account authentication.         This setting is optional. If not specified, "wl.basic" is used as the default scope.         Microsoft Account Scopes and permissions documentation: https://msdn.microsoft.com/en-us/library/dn631845.aspx
  - `[RuntimeVersion <String>]`: The RuntimeVersion of the Authentication / Authorization feature in use for the current app.         The setting in this value can control the behavior of certain features in the Authentication / Authorization module.
  - `[TokenRefreshExtensionHour <Double?>]`: The number of hours after session token expiration that a session token can be used to         call the token refresh API. The default is 72 hours.
  - `[TokenStoreEnabled <Boolean?>]`: <code>true</code> to durably store platform-specific security tokens that are obtained during login flows; otherwise, <code>false</code>.          The default is <code>false</code>.
  - `[TwitterConsumerKey <String>]`: The OAuth 1.0a consumer key of the Twitter application used for sign-in.         This setting is required for enabling Twitter Sign-In.         Twitter Sign-In documentation: https://dev.twitter.com/web/sign-in
  - `[TwitterConsumerSecret <String>]`: The OAuth 1.0a consumer secret of the Twitter application used for sign-in.         This setting is required for enabling Twitter Sign-In.         Twitter Sign-In documentation: https://dev.twitter.com/web/sign-in
  - `[UnauthenticatedClientAction <UnauthenticatedClientAction?>]`: The action to take when an unauthenticated client attempts to access the app.
  - `[ValidateIssuer <Boolean?>]`: Gets a value indicating whether the issuer should be a valid HTTPS url and be validated as such.

## RELATED LINKS

