---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/Az.Cdn/new-AzCdnDeliveryRuleCookiesConditionObject
schema: 2.0.0
---

# New-AzCdnDeliveryRuleCookiesConditionObject

## SYNOPSIS
Create an in-memory object for DeliveryRuleCookiesCondition.

## SYNTAX

```
New-AzCdnDeliveryRuleCookiesConditionObject -Name <MatchVariable> -ParameterOperator <CookiesOperator>
 [-ParameterMatchValue <String[]>] [-ParameterNegateCondition <Boolean>] [-ParameterSelector <String>]
 [-ParameterTransform <Transform[]>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DeliveryRuleCookiesCondition.

## EXAMPLES

### Example 1: Create an in-memory object for AzureCDN DeliveryRuleCookiesCondition
```powershell
New-AzCdnDeliveryRuleCookiesConditionObject -Name Cookies -ParameterOperator Equal -ParameterSelector test -ParameterMatchValue test -ParameterNegateCondition $False -ParameterTransform Lowercase
```

```output
Name
----
Cookies
```

Create an in-memory object for AzureCDN DeliveryRuleCookiesCondition

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.CookiesOperator
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParameterSelector
Name of Cookies to be matched.

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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.DeliveryRuleCookiesCondition

## NOTES

ALIASES

## RELATED LINKS

