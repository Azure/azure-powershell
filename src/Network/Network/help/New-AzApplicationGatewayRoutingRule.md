---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/new-azapplicationgatewayroutingrule
schema: 2.0.0
---

# New-AzApplicationGatewayRoutingRule

## SYNOPSIS
Creates a routing rule for an application gateway.

## SYNTAX

### SetByResource (Default)
```
New-AzApplicationGatewayRoutingRule -Name <String> -RuleType <String> -Priority <Int32>
 [-BackendSettings <PSApplicationGatewayBackendSettings>] [-Listener <PSApplicationGatewayListener>]
 [-BackendAddressPool <PSApplicationGatewayBackendAddressPool>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### SetByResourceId
```
New-AzApplicationGatewayRoutingRule -Name <String> -RuleType <String> -Priority <Int32>
 [-BackendSettingsId <String>] [-ListenerId <String>] [-BackendAddressPoolId <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
**The Add-AzApplicationGatewayRoutingRule** cmdlet creates a routing rule for an Azure application gateway.

## EXAMPLES

### Example 1: Create a routing rule for an application gateway
```powershell
$Rule = New-AzApplicationGatewayRoutingRule -Name "Rule01" -RuleType Basic -Priority 100 -BackendSettings $Setting -Listener $Listener -BackendAddressPool $Pool
```

This command creates a basic routing rule named Rule01 and stores the result in the variable named $Rule.

## PARAMETERS

### -BackendAddressPool
Application gateway BackendAddressPool

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayBackendAddressPool
Parameter Sets: SetByResource
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackendAddressPoolId
ID of the application gateway BackendAddressPool

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

### -BackendSettings
Application gateway BackendSettings

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayBackendSettings
Parameter Sets: SetByResource
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackendSettingsId
ID of the application gateway BackendSettings

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

### -Listener
Application gateway Listener

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayListener
Parameter Sets: SetByResource
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ListenerId
ID of the application gateway Listener

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

### -Name
The name of the Routing Rule

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

### -Priority
The priority of the rule

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RuleType
The type of rule

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Basic, PathBasedRouting

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayRoutingRule

## NOTES

## RELATED LINKS

[Add-AzApplicationGatewayRoutingRule](./Add-AzApplicationGatewayRoutingRule.md)

[Get-AzApplicationGatewayRoutingRule](./Get-AzApplicationGatewayRoutingRule.md)

[Remove-AzApplicationGatewayRoutingRule](./Remove-AzApplicationGatewayRoutingRule.md)

[Set-AzApplicationGatewayRoutingRule](./Set-AzApplicationGatewayRoutingRule.md)