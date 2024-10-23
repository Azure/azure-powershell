---
external help file:
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/az.app/update-azcontainerappauthconfig
schema: 2.0.0
---

# Update-AzContainerAppAuthConfig

## SYNOPSIS
Update the AuthConfig for a Container App.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzContainerAppAuthConfig -ContainerAppName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-CookieExpirationConvention <String>]
 [-CookieExpirationTimeToExpiration <String>] [-ForwardProxyConvention <String>]
 [-ForwardProxyCustomHostHeaderName <String>] [-ForwardProxyCustomProtoHeaderName <String>]
 [-GlobalValidationExcludedPath <String[]>] [-GlobalValidationRedirectToProvider <String>]
 [-GlobalValidationUnauthenticatedClientAction <String>] [-HttpSettingRequireHttps]
 [-IdentityProvider <IIdentityProviders>] [-LoginAllowedExternalRedirectUrl <String[]>]
 [-LoginPreserveUrlFragmentsForLogin] [-NonceExpirationInterval <String>] [-NonceValidateNonce]
 [-PlatformEnabled] [-PlatformRuntimeVersion <String>] [-RouteApiPrefix <String>]
 [-RouteLogoutEndpoint <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityContainerAppExpanded
```
Update-AzContainerAppAuthConfig -ContainerAppInputObject <IAppIdentity> -Name <String>
 [-CookieExpirationConvention <String>] [-CookieExpirationTimeToExpiration <String>]
 [-ForwardProxyConvention <String>] [-ForwardProxyCustomHostHeaderName <String>]
 [-ForwardProxyCustomProtoHeaderName <String>] [-GlobalValidationExcludedPath <String[]>]
 [-GlobalValidationRedirectToProvider <String>] [-GlobalValidationUnauthenticatedClientAction <String>]
 [-HttpSettingRequireHttps] [-IdentityProvider <IIdentityProviders>]
 [-LoginAllowedExternalRedirectUrl <String[]>] [-LoginPreserveUrlFragmentsForLogin]
 [-NonceExpirationInterval <String>] [-NonceValidateNonce] [-PlatformEnabled]
 [-PlatformRuntimeVersion <String>] [-RouteApiPrefix <String>] [-RouteLogoutEndpoint <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzContainerAppAuthConfig -InputObject <IAppIdentity> [-CookieExpirationConvention <String>]
 [-CookieExpirationTimeToExpiration <String>] [-ForwardProxyConvention <String>]
 [-ForwardProxyCustomHostHeaderName <String>] [-ForwardProxyCustomProtoHeaderName <String>]
 [-GlobalValidationExcludedPath <String[]>] [-GlobalValidationRedirectToProvider <String>]
 [-GlobalValidationUnauthenticatedClientAction <String>] [-HttpSettingRequireHttps]
 [-IdentityProvider <IIdentityProviders>] [-LoginAllowedExternalRedirectUrl <String[]>]
 [-LoginPreserveUrlFragmentsForLogin] [-NonceExpirationInterval <String>] [-NonceValidateNonce]
 [-PlatformEnabled] [-PlatformRuntimeVersion <String>] [-RouteApiPrefix <String>]
 [-RouteLogoutEndpoint <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update the AuthConfig for a Container App.

## EXAMPLES

### Example 1: Create the AuthConfig for a Container App.
```powershell
Update-AzContainerAppAuthConfig -Name current -ContainerAppName azps-containerapp-2 -ResourceGroupName azps_test_group_app -PlatformEnabled -GlobalValidationUnauthenticatedClientAction RedirectToLoginPage -IdentityProvider $identity
```

```output
Name    PlatformEnabled ResourceGroupName
----    --------------- -----------------
current True            azps_test_group_app
```

Create the AuthConfig for a Container App.

### Example 2: Create the AuthConfig for a Container App.
```powershell
$containerapp = Get-AzContainerApp -ResourceGroupName azps_test_group_app -Name azps-containerapp-2

Update-AzContainerAppAuthConfig -Name current -ContainerAppInputObject $containerapp -PlatformEnabled -GlobalValidationUnauthenticatedClientAction RedirectToLoginPage -IdentityProvider $identity
```

```output
Name    PlatformEnabled ResourceGroupName
----    --------------- -----------------
current True            azps_test_group_app
```

Create the AuthConfig for a Container App.

### Example 3: Create the AuthConfig for a Container App.
```powershell
$authconfig = Get-AzContainerAppAuthConfig -Name current -ContainerAppName azps-containerapp-2 -ResourceGroupName azps_test_group_app

Update-AzContainerAppAuthConfig -InputObject $authconfig -PlatformEnabled -GlobalValidationUnauthenticatedClientAction RedirectToLoginPage -IdentityProvider $identity
```

```output
Name    PlatformEnabled ResourceGroupName
----    --------------- -----------------
current True            azps_test_group_app
```

Create the AuthConfig for a Container App.

## PARAMETERS

### -ContainerAppInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity
Parameter Sets: UpdateViaIdentityContainerAppExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ContainerAppName
Name of the Container App.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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
Type: System.String
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
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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
Type: System.String
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
Type: System.String
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IIdentityProviders
Parameter Sets: (All)
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
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -Name
Name of the Container App AuthConfig.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityContainerAppExpanded
Aliases: AuthConfigName

Required: True
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAuthConfig

## NOTES

## RELATED LINKS

