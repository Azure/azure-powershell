---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.Cdn/new-AzFrontDoorCdnRuleUrlFileExtensionConditionObject
schema: 2.0.0
---

# New-AzFrontDoorCdnRuleUrlFileExtensionConditionObject

## SYNOPSIS
Create an in-memory object for DeliveryRuleUrlFileExtensionCondition.

## SYNTAX

```
New-AzFrontDoorCdnRuleUrlFileExtensionConditionObject -Name <MatchVariable>
 -ParameterOperator <UrlFileExtensionOperator> [-ParameterMatchValue <String[]>]
 [-ParameterNegateCondition <Boolean>] [-ParameterTransform <Transform[]>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DeliveryRuleUrlFileExtensionCondition.

## EXAMPLES

### Example 1: Create an in-memory object for DeliveryRuleUrlFileExtensionCondition
```powershell
New-AzFrontDoorCdnRuleUrlFileExtensionConditionObject -Name UrlFileExtension -ParameterOperator Equal -ParameterMatchValue txt -ParameterNegateCondition $False -ParameterTransform Lowercase
```

```output
Name
----
UrlFileExtension
```

Create an in-memory object for DeliveryRuleUrlFileExtensionCondition

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.UrlFileExtensionOperator
Parameter Sets: (All)
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.DeliveryRuleUrlFileExtensionCondition

## NOTES

ALIASES

## RELATED LINKS

