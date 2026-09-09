---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/Az.Cdn/new-azcdndeliveryruleremoteaddressconditionobject
schema: 2.0.0
---

# New-AzCdnDeliveryRuleRemoteAddressConditionObject

## SYNOPSIS
Create an in-memory object for DeliveryRuleRemoteAddressCondition.

## SYNTAX

```
New-AzCdnDeliveryRuleRemoteAddressConditionObject -ParameterOperator <String> -ParameterTypeName <String>
 [-ParameterMatchValue <String[]>] [-ParameterNegateCondition <Boolean>] [-ParameterTransform <String[]>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DeliveryRuleRemoteAddressCondition.

## EXAMPLES

### Example 1: Create an in-memory object for AzureCDN DeliveryRuleRemoteAddressCondition
```powershell
New-AzCdnDeliveryRuleRemoteAddressConditionObject -Name RemoteAddress -ParameterOperator GeoMatch -ParameterMatchValue BJ -ParameterNegateCondition $False -ParameterTransform Lowercase
```

```output
Name
----
RemoteAddress
```

Create an in-memory object for AzureCDN DeliveryRuleRemoteAddressCondition

## PARAMETERS

### -ParameterMatchValue
Match values to match against.
The operator will apply to each value in here with OR semantics.
If any of them match the variable with the given operator this match condition is considered a match.

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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.DeliveryRuleRemoteAddressCondition

## NOTES

## RELATED LINKS

