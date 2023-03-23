---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/Az.Cdn/new-AzCdnDeliveryRuleRequestHeaderConditionObject
schema: 2.0.0
---

# New-AzCdnDeliveryRuleRequestHeaderConditionObject

## SYNOPSIS
Create an in-memory object for DeliveryRuleRequestHeaderCondition.

## SYNTAX

```
New-AzCdnDeliveryRuleRequestHeaderConditionObject -Name <MatchVariable>
 -ParameterOperator <RequestHeaderOperator> [-ParameterMatchValue <String[]>]
 [-ParameterNegateCondition <Boolean>] [-ParameterSelector <String>] [-ParameterTransform <Transform[]>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DeliveryRuleRequestHeaderCondition.

## EXAMPLES

### Example 1: Create an in-memory object for AzureCDN DeliveryRuleRequestHeaderCondition
```powershell
New-AzCdnDeliveryRuleRequestHeaderConditionObject  -Name RequestHeader -ParameterOperator Equal -ParameterSelector test -ParameterMatchValue test -ParameterNegateCondition $False -ParameterTransform Lowercase
```

```output
Name
----
RequestHeader
```

Create an in-memory object for AzureCDN DeliveryRuleRequestHeaderCondition

## PARAMETERS

### -Name
The name of the condition for the delivery rule.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.MatchVariable
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParameterMatchValue
The match value for the condition of the delivery rule.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParameterNegateCondition
Describes if this is negate condition or not.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParameterOperator
Describes operator to be matched.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.RequestHeaderOperator
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParameterSelector
Name of Header to be matched.

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

### -ParameterTransform
List of transforms.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.Transform[]
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.DeliveryRuleRequestHeaderCondition

## NOTES

ALIASES

## RELATED LINKS

