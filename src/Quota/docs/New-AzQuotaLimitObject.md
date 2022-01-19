---
external help file:
Module Name: Az.Quota
online version: https://docs.microsoft.com/powershell/module/az.Quota/new-AzQuotaLimitObject
schema: 2.0.0
---

# New-AzQuotaLimitObject

## SYNOPSIS
Create an in-memory object for LimitValue.

## SYNTAX

```
New-AzQuotaLimitObject -Value <Int32> [-Type <QuotaLimitTypes>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for LimitValue.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -Type
The quota or usages limit types.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Quota.Support.QuotaLimitTypes
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Value
The quota/limit value.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.Api20210315Preview.LimitValue

## NOTES

ALIASES

## RELATED LINKS

