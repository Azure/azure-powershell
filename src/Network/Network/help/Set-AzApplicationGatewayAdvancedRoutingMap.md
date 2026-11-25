---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/set-azapplicationgatewayadvancedroutingmap
schema: 2.0.0
---

# Set-AzApplicationGatewayAdvancedRoutingMap

## SYNOPSIS
Modifies an advanced routing map on an application gateway.

## SYNTAX

### BackendSetByResource (Default)
```
Set-AzApplicationGatewayAdvancedRoutingMap -ApplicationGateway <PSApplicationGateway> -Name <String>
 -AdvancedRoutingRule <PSApplicationGatewayAdvancedRoutingRule[]>
 -DefaultBackendAddressPool <PSApplicationGatewayBackendAddressPool>
 -DefaultBackendHttpSettings <PSApplicationGatewayBackendHttpSettings>
 [-DefaultRewriteRuleSet <PSApplicationGatewayRewriteRuleSet>] [-DefaultProfile <IAzureContextContainer>]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

### BackendSetByResourceId
```
Set-AzApplicationGatewayAdvancedRoutingMap -ApplicationGateway <PSApplicationGateway> -Name <String>
 -AdvancedRoutingRule <PSApplicationGatewayAdvancedRoutingRule[]> -DefaultBackendAddressPoolId <String>
 -DefaultBackendHttpSettingsId <String> [-DefaultRewriteRuleSetId <String>]
 [-DefaultProfile <IAzureContextContainer>] [-AcquirePolicyToken]
 [-ChangeReference <String>] [<CommonParameters>]
```

### RedirectSetByResourceId
```
Set-AzApplicationGatewayAdvancedRoutingMap -ApplicationGateway <PSApplicationGateway> -Name <String>
 -AdvancedRoutingRule <PSApplicationGatewayAdvancedRoutingRule[]> -DefaultRedirectConfigurationId <String>
 [-DefaultRewriteRuleSetId <String>] [-DefaultProfile <IAzureContextContainer>]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

### RedirectSetByResource
```
Set-AzApplicationGatewayAdvancedRoutingMap -ApplicationGateway <PSApplicationGateway> -Name <String>
 -AdvancedRoutingRule <PSApplicationGatewayAdvancedRoutingRule[]>
 -DefaultRedirectConfiguration <PSApplicationGatewayRedirectConfiguration>
 [-DefaultRewriteRuleSet <PSApplicationGatewayRewriteRuleSet>] [-DefaultProfile <IAzureContextContainer>]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzApplicationGatewayAdvancedRoutingMap** cmdlet replaces an existing advanced routing map on an application gateway. The map is replaced in full, so supply every rule it should contain along with its default backend. Call Set-AzApplicationGateway to persist the change.

## EXAMPLES

### Example 1: Add a rule to an existing advanced routing map
```powershell
$gateway = Get-AzApplicationGateway -Name "ApplicationGateway01" -ResourceGroupName "ResourceGroup01"
$pool = Get-AzApplicationGatewayBackendAddressPool -ApplicationGateway $gateway -Name "Pool01"
$settings = Get-AzApplicationGatewayBackendHttpSetting -ApplicationGateway $gateway -Name "Settings01"
$map = Get-AzApplicationGatewayAdvancedRoutingMap -ApplicationGateway $gateway -Name "Map01"
$gateway = Set-AzApplicationGatewayAdvancedRoutingMap -ApplicationGateway $gateway -Name "Map01" -AdvancedRoutingRule ($map.AdvancedRoutingRules + $newRule) -DefaultBackendAddressPool $pool -DefaultBackendHttpSettings $settings
$gateway = Set-AzApplicationGateway -ApplicationGateway $gateway
```

This command appends a rule to the existing advanced routing map and then updates the gateway.

## PARAMETERS

### -AcquirePolicyToken
Acquire an Azure Policy token automatically for this resource operation.

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

### -AdvancedRoutingRule
List of advanced routing rules

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayAdvancedRoutingRule[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -ChangeReference
The change reference resource ID for this resource operation.

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

### -DefaultBackendAddressPool
Application gateway default BackendAddressPool

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayBackendAddressPool
Parameter Sets: BackendSetByResource
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultBackendAddressPoolId
ID of the application gateway default BackendAddressPool

```yaml
Type: System.String
Parameter Sets: BackendSetByResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultBackendHttpSettings
Application gateway default BackendHttpSettings

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayBackendHttpSettings
Parameter Sets: BackendSetByResource
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultBackendHttpSettingsId
ID of the application gateway default BackendHttpSettings

```yaml
Type: System.String
Parameter Sets: BackendSetByResourceId
Aliases:

Required: True
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

### -DefaultRedirectConfiguration
Application gateway default RedirectConfiguration

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayRedirectConfiguration
Parameter Sets: RedirectSetByResource
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultRedirectConfigurationId
ID of the application gateway default RedirectConfiguration

```yaml
Type: System.String
Parameter Sets: RedirectSetByResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultRewriteRuleSet
Application gateway default RewriteRuleSet

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayRewriteRuleSet
Parameter Sets: BackendSetByResource, RedirectSetByResource
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultRewriteRuleSetId
ID of the application gateway default RewriteRuleSet

```yaml
Type: System.String
Parameter Sets: BackendSetByResourceId, RedirectSetByResourceId
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the advanced routing map

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationGateway

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationGateway

## NOTES

## RELATED LINKS
