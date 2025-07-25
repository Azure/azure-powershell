---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/Az.Cdn/new-azfrontdoorcdnruleclientportconditionobject
schema: 2.0.0
---

# New-AzFrontDoorCdnRuleClientPortConditionObject

## SYNOPSIS
Create an in-memory object for DeliveryRuleClientPortCondition.

## SYNTAX

```
New-AzFrontDoorCdnRuleClientPortConditionObject -ParameterOperator <String> -ParameterTypeName <String>
 [-ParameterMatchValue <String[]>] [-ParameterNegateCondition <Boolean>] [-ParameterTransform <String[]>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DeliveryRuleClientPortCondition.

## EXAMPLES

### Example 1: Create an in-memory object for DeliveryRuleClientPortCondition
```powershell
New-AzFrontDoorCdnRuleClientPortConditionObject -Name ClientPort -ParameterOperator Equal -ParameterMatchValue 80,81
```

```output
Name
----
ClientPort
```

Create an in-memory object for DeliveryRuleClientPortCondition

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

### -ParameterTypeName


```yaml
Type: System.String
Parameter Sets: (All)
Aliases: Name

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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.DeliveryRuleClientPortCondition

## NOTES

## RELATED LINKS

