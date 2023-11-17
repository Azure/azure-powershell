---
external help file:
Module Name: Az.Aks
online version: https://learn.microsoft.com/powershell/module/Az.Aks/new-AzAksTimeSpanObject
schema: 2.0.0
---

# New-AzAksTimeSpanObject

## SYNOPSIS
Create an in-memory object for TimeSpan.

## SYNTAX

```
New-AzAksTimeSpanObject [-End <DateTime>] [-Start <DateTime>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for TimeSpan.

## EXAMPLES

### Example 1: Create Create an in-memory object for a time span
```powershell
$startDate = Get-Date -Year 2023 -Month 3 -Day 1
$endDate = Get-Date -Year 2023 -Month 3 -Day 2
New-AzAksTimeSpanObject -Start  $startDate -End $endDate
```

```output
End                 Start
---                 -----
3/2/2023 1:53:53 PM 3/1/2023 1:53:45 PM
```

*New-AzAksTimeSpanObject* creates an in-memory object of type *TimeSpan*.
This object represents a time span and will be used for parameter *NotAllowedTime* in cmdlet *New-AzAksMaintenanceConfiguration*.

## PARAMETERS

### -End
The end of a time span.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Start
The start of a time span.

```yaml
Type: System.DateTime
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

### Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.TimeSpan

## NOTES

ALIASES

## RELATED LINKS

