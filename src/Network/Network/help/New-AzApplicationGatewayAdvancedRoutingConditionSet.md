---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azapplicationgatewayadvancedroutingconditionset
schema: 2.0.0
---

# New-AzApplicationGatewayAdvancedRoutingConditionSet

## SYNOPSIS
Creates an advanced routing condition set for an application gateway.

## SYNTAX

```
New-AzApplicationGatewayAdvancedRoutingConditionSet -Name <String>
 -RoutingCondition <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayAdvancedRoutingCondition]>
 [-DefaultProfile <IAzureContextContainer>] [-AcquirePolicyToken]
 [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzApplicationGatewayAdvancedRoutingConditionSet** cmdlet creates a named set of routing conditions. An advanced routing rule references a condition set, and is selected when the conditions in that set match the incoming request.

## EXAMPLES

### Example 1: Create an advanced routing condition set
```powershell
$condition = New-AzApplicationGatewayAdvancedRoutingCondition -ConditionType Header -PropertyName "X-Region" -PropertyValues "emea"
$conditionSet = New-AzApplicationGatewayAdvancedRoutingConditionSet -Name "emeaConditions" -RoutingCondition $condition
```

This command creates a condition set named emeaConditions containing a single header condition.

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

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayAdvancedRoutingConditionSet

## NOTES

## RELATED LINKS
