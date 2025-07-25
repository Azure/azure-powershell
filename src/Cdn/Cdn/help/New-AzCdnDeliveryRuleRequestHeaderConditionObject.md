---
external help file: Az.Cdn-help.xml
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/Az.Cdn/new-azcdndeliveryrulerequestheaderconditionobject
schema: 2.0.0
---

# New-AzCdnDeliveryRuleRequestHeaderConditionObject

## SYNOPSIS
Create an in-memory object for DeliveryRuleRequestHeaderCondition.

## SYNTAX

```
New-AzCdnDeliveryRuleRequestHeaderConditionObject -ParameterOperator <String> -ParameterTypeName <String>
 [-ParameterMatchValue <String[]>] [-ParameterNegateCondition <Boolean>] [-ParameterSelector <String>]
 [-ParameterTransform <String[]>] [<CommonParameters>]
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.DeliveryRuleRequestHeaderCondition

## NOTES

## RELATED LINKS
