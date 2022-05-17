---
external help file:
Module Name: Az.Cdn
online version: https://docs.microsoft.com/powershell/module/az.Cdn/new-AzCdnDeliveryRuleObject
schema: 2.0.0
---

# New-AzCdnDeliveryRuleObject

## SYNOPSIS
Create an in-memory object for DeliveryRule.

## SYNTAX

```
New-AzCdnDeliveryRuleObject -Action <IDeliveryRuleAction1[]> -Order <Int32>
 [-Condition <IDeliveryRuleCondition[]>] [-Name <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DeliveryRule.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -Action
A list of actions that are executed when all the conditions of a rule are satisfied.
To construct, see NOTES section for ACTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IDeliveryRuleAction1[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Condition
A list of conditions that must be matched for the actions to be executed.
To construct, see NOTES section for CONDITION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IDeliveryRuleCondition[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the rule.

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

### -Order
The order in which the rules are applied for the endpoint.
Possible values {0,1,2,3,………}.
A rule with a lesser order will be applied before a rule with a greater order.
Rule with order 0 is a special rule.
It does not require any condition and actions listed in it will always be applied.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.DeliveryRule

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


ACTION <IDeliveryRuleAction1[]>: A list of actions that are executed when all the conditions of a rule are satisfied.
  - `Name <DeliveryRuleAction>`: The name of the action for the delivery rule.

CONDITION <IDeliveryRuleCondition[]>: A list of conditions that must be matched for the actions to be executed.
  - `Name <MatchVariable>`: The name of the condition for the delivery rule.

## RELATED LINKS

