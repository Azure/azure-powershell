---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/set-azapplicationgatewayadvancedroutingconditionset
schema: 2.0.0
---

# Set-AzApplicationGatewayAdvancedRoutingConditionSet

## SYNOPSIS
Modifies an advanced routing condition set on an application gateway.

## SYNTAX

```
Set-AzApplicationGatewayAdvancedRoutingConditionSet -ApplicationGateway <PSApplicationGateway> -Name <String>
 -RoutingCondition <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayAdvancedRoutingCondition]>
 [-DefaultProfile <IAzureContextContainer>] [-AcquirePolicyToken]
 [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzApplicationGatewayAdvancedRoutingConditionSet** cmdlet replaces an existing advanced routing condition set on an application gateway. The condition set is replaced in full, so supply every condition it should contain. Call Set-AzApplicationGateway to persist the change.

## EXAMPLES

### Example 1: Replace the conditions in an advanced routing condition set
```powershell
$gateway = Get-AzApplicationGateway -Name "ApplicationGateway01" -ResourceGroupName "ResourceGroup01"
$condition = New-AzApplicationGatewayAdvancedRoutingCondition -ConditionType Header -PropertyName "X-Region" -PropertyValues "emea", "apac"
$gateway = Set-AzApplicationGatewayAdvancedRoutingConditionSet -ApplicationGateway $gateway -Name "emeaConditions" -RoutingCondition $condition
$gateway = Set-AzApplicationGateway -ApplicationGateway $gateway
```

This command replaces the conditions in the emeaConditions condition set and then updates the gateway.

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
The name of the AdvancedRoutingConditionSet

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

### -RoutingCondition
List of routing conditions evaluated by this condition set

```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayAdvancedRoutingCondition]
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
