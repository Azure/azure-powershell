---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/Az.Cdn/new-AzCdnDeliveryRuleRequestHeaderActionObject
schema: 2.0.0
---

# New-AzCdnDeliveryRuleRequestHeaderActionObject

## SYNOPSIS
Create an in-memory object for DeliveryRuleRequestHeaderAction.

## SYNTAX

```
New-AzCdnDeliveryRuleRequestHeaderActionObject -Name <DeliveryRuleAction>
 -ParameterHeaderAction <HeaderAction> -ParameterHeaderName <String> [-ParameterValue <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DeliveryRuleRequestHeaderAction.

## EXAMPLES

### Example 1: Create an in-memory object for AzureCDN DeliveryRuleRequestHeaderAction
```powershell
New-AzCdnDeliveryRuleRequestHeaderActionObject -Name ModifyRequestHeader -ParameterHeaderAction Append -ParameterHeaderName a1 -ParameterValue a1
```

```output
Name
----
ModifyRequestHeader
```

Create an in-memory object for AzureCDN DeliveryRuleRequestHeaderAction

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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.DeliveryRuleRequestHeaderAction

## NOTES

ALIASES

## RELATED LINKS

