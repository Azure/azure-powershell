---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/Az.Cdn/new-azcdndeliveryruleresponseheaderactionobject
schema: 2.0.0
---

# New-AzCdnDeliveryRuleResponseHeaderActionObject

## SYNOPSIS
Create an in-memory object for DeliveryRuleResponseHeaderAction.

## SYNTAX

```
New-AzCdnDeliveryRuleResponseHeaderActionObject -ParameterHeaderAction <String> -ParameterHeaderName <String>
 [-ParameterValue <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DeliveryRuleResponseHeaderAction.

## EXAMPLES

### Example 1: Create an in-memory object for AzureCDN DeliveryRuleResponseHeaderAction
```powershell
New-AzCdnDeliveryRuleResponseHeaderActionObject -Name ModifyResponseHeader -ParameterHeaderAction Append -ParameterHeaderName a1 -ParameterValue a1
```

```output
Name
----
ModifyResponseHeader
```

Create an in-memory object for AzureCDN DeliveryRuleResponseHeaderAction

## PARAMETERS

### -ParameterHeaderAction
Action to perform.

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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.DeliveryRuleResponseHeaderAction

## NOTES

ALIASES

## RELATED LINKS

