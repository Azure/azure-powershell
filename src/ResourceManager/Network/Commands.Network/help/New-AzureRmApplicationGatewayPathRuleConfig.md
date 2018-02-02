---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
ms.assetid: A1F949A9-7AEF-41C1-B757-114421B79493
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/new-azurermapplicationgatewaypathruleconfig
schema: 2.0.0
---

# New-AzureRmApplicationGatewayPathRuleConfig

## SYNOPSIS
Creates an application gateway path rule.

## SYNTAX

### SetByResourceId
```
New-AzureRmApplicationGatewayPathRuleConfig -Name <String>
 -Paths <System.Collections.Generic.List`1[System.String]> [-BackendAddressPoolId <String>]
 [-BackendHttpSettingsId <String>] [-RedirectConfigurationId <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### SetByResource
```
New-AzureRmApplicationGatewayPathRuleConfig -Name <String>
 -Paths <System.Collections.Generic.List`1[System.String]>
 [-BackendAddressPool <PSApplicationGatewayBackendAddressPool>]
 [-BackendHttpSettings <PSApplicationGatewayBackendHttpSettings>]
 [-RedirectConfiguration <PSApplicationGatewayRedirectConfiguration>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureRmApplicationGatewayPathRuleConfig** cmdlet creates an application gateway path rule.
Rules created by this cmdlet can be added to a collection of URL path map configuration settings and then assigned to a gateway.

Path map configuration settings are used in application gateway load balancing.

## EXAMPLES

### Example 1
```
PS C:\>$Gateway = Get-AzureRmApplicationGateway -Name "ContosoApplicationGateway"
PS C:\> $AddressPool = New-AzureRmApplicationGatewayBackendAddressPool -Name "ContosoAddressPool" -BackendIPAddresses "192.168.1.1", "192.168.1.2"
PS C:\> $HttpSettings = New-AzureRmApplicationGatewayBackendHttpSettings -Name "ContosoHttpSetings" -Port 80 -Protocol "Http" -CookieBasedAffinity "Disabled"
PS C:\> $PathRuleConfig = New-AzureRmApplicationGatewayPathRuleConfig -Name "base" -Paths "/base" -BackendAddressPool $AddressPool -BackendHttpSettings $HttpSettings
PS C:\> Add-AzureRmApplicationGatewayUrlPathMapConfig -ApplicationGateway $Gateway -Name "ContosoUrlPathMap" -PathRules $PathRuleConfig -DefaultBackendAddressPool $AddressPool -DefaultBackendHttpSettings $HttpSettings
```

These commands create a new application gateway path rule and then use the **Add-AzureRmApplicationGatewayUrlPathMapConfig** cmdlet to assign that rule to an application gateway.
To do this, the first command creates an object reference to the gateway ContosoApplicationGateway.
This object reference is stored in a variable named $Gateway.

The next two commands create a backend address pool and a backend HTTP settings object; these objects (stored in the variables $AddressPool and $HttpSettings) are needed in order to create a path rule object.

The fourth command creates the path rule object and is stored in a variable named $PathRuleConfig.

The fifth command uses **Add-AzureRmApplicationGatewayUrlPathMapConfig** to add the configuration settings and the new path rule contained within those settings to ContosoApplicationGateway.

## PARAMETERS

### -BackendAddressPool
Specifies an object reference to a collection of backend address pool settings to be added to the gateway path rules configuration settings.
You can create this object reference by using the New-AzureRmApplicationGatewayBackendAddressPool cmdlet and syntax similar to this:

`$AddressPool = New-AzureRmApplicationGatewayBackendAddressPool -Name "ContosoAddressPool" -BackendIPAddresses "192.168.1.1", "192.168.1.2"`

The preceding command adds two IP addresses (192.16.1.1 and 192.168.1.2) to the address pool.
Note that the IP address are enclosed in quote marks and separated by using commas.

The resulting variable, $AddressPool, can then be used as the parameter value for the *DefaultBackendAddressPool* parameter.

The backend address pool represents the IP addresses on the backend servers.
These IP addresses should either belong to the virtual network subnet or should be public IP addresses.
If you use this parameter you cannot use the *DefaultBackendAddressPoolId* parameter in the same command.

```yaml
Type: PSApplicationGatewayBackendAddressPool
Parameter Sets: SetByResource
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackendAddressPoolId
Specifies the ID of an existing backend address pool that can be added to the gateway path rule configuration settings.
Address pool IDs can be returned by using the Get-AzureRmApplicationGatewayBackendAddressPool cmdlet.
After you have the ID you can then use the *DefaultBackendAddressPoolId* parameter instead of the *DefaultBackendAddressPool* parameter.
For instance:

-DefaultBackendAddressPoolId "/subscriptions/39c54063-01d3-4abf-8f4c-234777bc1f10/resourceGroups/appgw-rg/providers/Microsoft.Network/applicationGateways/appgwtest/backendAddressPools/ContosoAddressPool"

The backend address pool represents the IP addresses on the backend servers.
These IP addresses should either belong to the virtual network subnet or should be public IP addresses.

```yaml
Type: String
Parameter Sets: SetByResourceId
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackendHttpSettings
Specifies an object reference to a collection of backend HTTP settings to be added to the gateway path rule configuration settings.
You can create this object reference by using the New-AzureRmApplicationGatewayBackendHttpSettings cmdlet and syntax similar to this:

$HttpSettings = New-AzureRmApplicationGatewayBackendHttpSettings -Name "ContosoHttpSetings" -Port 80 -Protocol "Http" -CookieBasedAffinity "Disabled"

The resulting variable, $HttpSettings, can then be used as the parameter value for the *DefaultBackendAddressPool* parameter:

-DefaultBackendHttpSettings $HttpSettings

The backend HTTP settings configure properties such as port, protocol, and cookie-based affinity for a backend pool.
If you use this parameter you cannot use the *DefaultBackendHttpSettingsId* parameter in the same command.

```yaml
Type: PSApplicationGatewayBackendHttpSettings
Parameter Sets: SetByResource
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackendHttpSettingsId
Specifies the ID of an existing backend HTTP settings collection that can be added to the gateway path rule configuration settings.
HTTP setting IDs can be returned by using the Get-AzureRmApplicationGatewayBackendHttpSettings cmdlet.
After you have the ID you can then use the *DefaultBackendHttpSettingsId* parameter instead of the *DefaultBackendHttpSettings* parameter.
For instance:

-DefaultBackendSettings Id "/subscriptions/39c54063-01d3-4abf-8f4c-234777bc1f10/resourceGroups/appgw-rg/providers/Microsoft.Network/applicationGateways/appgwtest/backendHttpSettingsCollection/ContosoHttpSettings"

The backend HTTP settings configure properties such as port, protocol, and cookie-based affinity for a backend pool.
If you use this parameter you cannot use the *DefaultBackendHttpSettings* parameter in the same command.

```yaml
Type: String
Parameter Sets: SetByResourceId
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Specifies the name of the path rule configuration that this cmdlet creates.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Paths
Specifies one or more application gateway path rules.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RedirectConfiguration
Application gateway RedirectConfiguration

```yaml
Type: PSApplicationGatewayRedirectConfiguration
Parameter Sets: SetByResource
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RedirectConfigurationId
ID of the application gateway RedirectConfiguration

```yaml
Type: String
Parameter Sets: SetByResourceId
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

###  
**New-AzureRmApplicationGatewayPathRuleConfig** does not accept pipelined input.

## OUTPUTS

###  
**New-AzureRmApplicationGatewayPathRuleConfig** creates new instances of the **Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayPathRule** object.

## NOTES

## RELATED LINKS

[Add-AzureRmApplicationGatewayUrlPathMapConfig](./Add-AzureRmApplicationGatewayUrlPathMapConfig.md)

[Get-AzureRmApplicationGateway](./Get-AzureRmApplicationGateway.md)

[Get-AzureRmApplicationGatewayUrlPathMapConfig](./Get-AzureRmApplicationGatewayUrlPathMapConfig.md)

[New-AzureRmApplicationGatewayBackendAddressPool](./New-AzureRmApplicationGatewayBackendAddressPool.md)

[New-AzureRmApplicationGatewayBackendHttpSettings](./New-AzureRmApplicationGatewayBackendHttpSettings.md)

[New-AzureRmApplicationGatewayPathRuleConfig](./New-AzureRmApplicationGatewayPathRuleConfig.md)

[New-AzureRmApplicationGatewayUrlPathMapConfig](./New-AzureRmApplicationGatewayUrlPathMapConfig.md)

[Remove-AzureRmApplicationGatewayUrlPathMapConfig](./Remove-AzureRmApplicationGatewayUrlPathMapConfig.md)

[Set-AzureRmApplicationGatewayUrlPathMapConfig](./Set-AzureRmApplicationGatewayUrlPathMapConfig.md)


