---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/Az.Cdn/new-azcdndeliveryruleurlfileextensionconditionobject
schema: 2.0.0
---

# New-AzCdnDeliveryRuleUrlFileExtensionConditionObject

## SYNOPSIS
Create an in-memory object for DeliveryRuleUrlFileExtensionCondition.

## SYNTAX

```
New-AzCdnDeliveryRuleUrlFileExtensionConditionObject -ParameterOperator <String>
 [-ParameterMatchValue <String[]>] [-ParameterNegateCondition <Boolean>] [-ParameterTransform <String[]>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DeliveryRuleUrlFileExtensionCondition.

## EXAMPLES

### Example 1: Create an in-memory object for AzureCDN DeliveryRuleUrlFileExtensionCondition
```powershell
New-AzCdnDeliveryRuleUrlFileExtensionConditionObject -Name UrlFileExtension -ParameterOperator Equal -ParameterMatchValue txt -ParameterNegateCondition $False -ParameterTransform Lowercase
```

```output
Name
----
UrlFileExtension
```

Create an in-memory object for AzureCDN DeliveryRuleUrlFileExtensionCondition

## PARAMETERS

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
Type: System.String
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
Type: System.String[]
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.DeliveryRuleUrlFileExtensionCondition

## NOTES

ALIASES

## RELATED LINKS

