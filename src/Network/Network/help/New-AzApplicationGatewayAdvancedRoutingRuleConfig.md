---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azapplicationgatewayadvancedroutingruleconfig
schema: 2.0.0
---

# New-AzApplicationGatewayAdvancedRoutingRuleConfig

## SYNOPSIS
Creates an advanced routing rule for an application gateway advanced routing map.

## SYNTAX

### SetByResource (Default)
```
New-AzApplicationGatewayAdvancedRoutingRuleConfig -Name <String> -Priority <Int32>
 [-AdvancedRoutingConditionSet <PSApplicationGatewayAdvancedRoutingConditionSet>]
 [-BackendAddressPool <PSApplicationGatewayBackendAddressPool>]
 [-BackendHttpSettings <PSApplicationGatewayBackendHttpSettings>]
 [-RedirectConfiguration <PSApplicationGatewayRedirectConfiguration>]
 [-RewriteRuleSet <PSApplicationGatewayRewriteRuleSet>] [-DefaultProfile <IAzureContextContainer>]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

### SetByResourceId
```
New-AzApplicationGatewayAdvancedRoutingRuleConfig -Name <String> -Priority <Int32>
 [-AdvancedRoutingConditionSetId <String>] [-BackendAddressPoolId <String>] [-BackendHttpSettingsId <String>]
 [-RedirectConfigurationId <String>] [-RewriteRuleSetId <String>] [-DefaultProfile <IAzureContextContainer>]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzApplicationGatewayAdvancedRoutingRuleConfig** cmdlet creates an advanced routing rule. A rule references an advanced routing condition set and the backend to use when that condition set matches. Rules are evaluated in ascending priority order, and each priority must be unique within the containing advanced routing map. Supply either a backend address pool and backend HTTP settings, or a redirect configuration, but not both.

## EXAMPLES

### Example 1: Create an advanced routing rule that targets a backend pool
```powershell
$gateway = Get-AzApplicationGateway -Name "ApplicationGateway01" -ResourceGroupName "ResourceGroup01"
$pool = Get-AzApplicationGatewayBackendAddressPool -ApplicationGateway $gateway -Name "Pool01"
$settings = Get-AzApplicationGatewayBackendHttpSetting -ApplicationGateway $gateway -Name "Settings01"
$conditionSet = Get-AzApplicationGatewayAdvancedRoutingConditionSet -ApplicationGateway $gateway -Name "emeaConditions"
$rule = New-AzApplicationGatewayAdvancedRoutingRuleConfig -Name "emeaRule" -Priority 100 -AdvancedRoutingConditionSet $conditionSet -BackendAddressPool $pool -BackendHttpSettings $settings
```

This command creates an advanced routing rule that sends matching requests to Pool01.

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

### -AdvancedRoutingConditionSet
Application gateway AdvancedRoutingConditionSet evaluated by this rule

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayAdvancedRoutingConditionSet
Parameter Sets: SetByResource
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AdvancedRoutingConditionSetId
ID of the application gateway AdvancedRoutingConditionSet evaluated by this rule

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

### -BackendHttpSettings
Application gateway BackendHttpSettings

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayBackendHttpSettings
Parameter Sets: SetByResource
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackendHttpSettingsId
ID of the application gateway BackendHttpSettings

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

### -Name
Name of the advanced routing rule

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
The priority of the advanced routing rule.
Must be unique within the containing advanced routing map

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RedirectConfiguration
Application gateway RedirectConfiguration.
Cannot be combined with BackendAddressPool or BackendHttpSettings

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayRedirectConfiguration
Parameter Sets: SetByResource
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RedirectConfigurationId
ID of the application gateway RedirectConfiguration.
Cannot be combined with BackendAddressPoolId or BackendHttpSettingsId

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

### -RewriteRuleSet
Application gateway RewriteRuleSet

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayRewriteRuleSet
Parameter Sets: SetByResource
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RewriteRuleSetId
ID of the application gateway RewriteRuleSet

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayAdvancedRoutingRule

## NOTES

## RELATED LINKS
