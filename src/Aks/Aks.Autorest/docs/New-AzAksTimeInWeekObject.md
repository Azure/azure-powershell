---
external help file:
Module Name: Az.Aks
online version: https://learn.microsoft.com/powershell/module/Az.Aks/new-AzAksTimeInWeekObject
schema: 2.0.0
---

# New-AzAksTimeInWeekObject

## SYNOPSIS
Create an in-memory object for TimeInWeek.

## SYNTAX

```
New-AzAksTimeInWeekObject [-Day <WeekDay>] [-HourSlot <Int32[]>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for TimeInWeek.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -Day
The day of the week.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.WeekDay
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HourSlot
Each integer hour represents a time range beginning at 0m after the hour ending at the next hour (non-inclusive).
0 corresponds to 00:00 UTC, 23 corresponds to 23:00 UTC.
Specifying [0, 1] means the 00:00 - 02:00 UTC time range.

```yaml
Type: System.Int32[]
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

### Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.TimeInWeek

## NOTES

ALIASES

## RELATED LINKS

