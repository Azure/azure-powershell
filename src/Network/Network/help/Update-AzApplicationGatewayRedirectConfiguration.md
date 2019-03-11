---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/update-azapplicationgatewayredirectconfiguration
schema: 2.0.0
---

# Update-AzApplicationGatewayRedirectConfiguration

## SYNOPSIS
Incrementally updates redirect configuration of an application gateway.

## SYNTAX

### SetByResource (Default)
```
Update-AzApplicationGatewayRedirectConfiguration -ApplicationGateway <PSApplicationGateway>
 [-RedirectType <String>] -Name <String> [-TargetListener <PSApplicationGatewayHttpListener>]
 [-IncludePath <Boolean>] [-IncludeQueryString <Boolean>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### SetByResourceId
```
Update-AzApplicationGatewayRedirectConfiguration -ApplicationGateway <PSApplicationGateway>
 [-RedirectType <String>] -Name <String> [-TargetListenerID <String>] [-IncludePath <Boolean>]
 [-IncludeQueryString <Boolean>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### SetByURL
```
Update-AzApplicationGatewayRedirectConfiguration -ApplicationGateway <PSApplicationGateway>
 [-RedirectType <String>] -Name <String> [-TargetUrl <String>] [-IncludePath <Boolean>]
 [-IncludeQueryString <Boolean>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzApplicationGatewayRedirectConfiguration** incrementally updates redirect configuration of an application gateway. I.e. only the specified parameters values are changed and values of the unspecified properties are kept unlike of Set-AzApplicationGatewayRedirectConfiguration cmdlet.

## EXAMPLES

### Example 1
```powershell
PS C:> Update-AzApplicationGatewayRedirectConfiguration -ApplicationGateway $appgw -Name $redirectName -IncludeQueryString $false
```

This command updates include query string value of redirect configuration keeping other parameters unchanged.

## PARAMETERS

### -ApplicationGateway
The applicationGateway

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSApplicationGateway
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludePath
Include path in the redirected url.
Default is true.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeQueryString
Include query string in the redirected url.
Default is true.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Redirect Configuration

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

### -RedirectType
The type of redirect

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Permanent, Found, SeeOther, Temporary

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetListener
HTTPListener to redirect the request to

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayHttpListener
Parameter Sets: SetByResource
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetListenerID
ID of  listener to redirect the request to

```yaml
Type: System.String
Parameter Sets: SetByResourceId
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetUrl
Target URL fo redirection

```yaml
Type: System.String
Parameter Sets: SetByURL
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationGateway

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationGateway

## NOTES

## RELATED LINKS
