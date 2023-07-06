---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.Cdn/new-AzFrontDoorCdnRuleResponseHeaderActionObject
schema: 2.0.0
---

# New-AzFrontDoorCdnRuleResponseHeaderActionObject

## SYNOPSIS
Create an in-memory object for DeliveryRuleResponseHeaderAction.

## SYNTAX

```
New-AzFrontDoorCdnRuleResponseHeaderActionObject -Name <DeliveryRuleAction>
 -ParameterHeaderAction <HeaderAction> -ParameterHeaderName <String> [-ParameterValue <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DeliveryRuleResponseHeaderAction.

## EXAMPLES

### Example 1: Create an in-memory object for DeliveryRuleResponseHeaderAction
```powershell
New-AzFrontDoorCdnRuleResponseHeaderActionObject -Name ModifyResponseHeader -ParameterHeaderAction Append -ParameterHeaderName a1 -ParameterValue a1
```

```output
Name
----
ModifyResponseHeader
```

Create an in-memory object for DeliveryRuleResponseHeaderAction

## PARAMETERS

### -Name
The name of the action for the delivery rule.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.DeliveryRuleAction
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParameterHeaderAction
Action to perform.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.HeaderAction
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParameterHeaderName
Name of the header to modify.

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

### -ParameterValue
Value for the specified action.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.DeliveryRuleResponseHeaderAction

## NOTES

ALIASES

## RELATED LINKS

