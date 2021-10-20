---
external help file:
Module Name: Az.LabServices
online version: https://docs.microsoft.com/powershell/module/az.LabServices/new-AzLabServicesScheduleObject
schema: 2.0.0
---

# New-AzLabServicesScheduleObject

## SYNOPSIS
Create a in-memory object for Lab Services Schedule.

## SYNTAX

```
New-AzLabServicesScheduleObject -RecurrencePatternExpirationDate <DateTime>
 -RecurrencePatternFrequency <RecurrenceFrequency> -RecurrencePatternInterval <Int32>
 -RecurrencePatternWeekDay <WeekDay[]> -StartAt <DateTime> -StopAt <DateTime> -TimeZoneId <String>
 [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for Lab Services Schedule.

## EXAMPLES

### Example 1: Create schedule body.
```powershell
PS C:\> $scheduleBody = New-AzLabServicesScheduleObject -StartAt "$((Get-Date).AddHours(5))" `
            -StopAt "$((Get-Date).AddHours(6))" `
            -RecurrencePatternFrequency 'Weekly' `
            -RecurrencePatternInterval 1 `
            -RecurrencePatternWeekDay @($((Get-Date).DayOfWeek)) `
            -RecurrencePatternExpirationDate $((Get-Date).AddDays(20)) `
            -TimeZoneId 'America/Los_Angeles'
PS C:\> New-AzLabServicesSchedule -ResourceGroupName "Group Name" -LabName "Lab Name" -Name "Schedule Name" -Body $scheduleBody


Name
----
Schedule Name
```

This cmdlet creates the minimum information to save or update a schedule using the body parameter.

## PARAMETERS

### -RecurrencePatternExpirationDate


```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecurrencePatternFrequency


```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.RecurrenceFrequency
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecurrencePatternInterval


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

### -RecurrencePatternWeekDay


```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.WeekDay[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartAt


```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StopAt


```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TimeZoneId


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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.ISchedule

## NOTES

ALIASES

## RELATED LINKS

