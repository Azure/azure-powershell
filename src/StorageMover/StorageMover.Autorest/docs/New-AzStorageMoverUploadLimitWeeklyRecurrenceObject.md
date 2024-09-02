---
external help file:
Module Name: Az.StorageMover
online version: https://learn.microsoft.com/powershell/module/Az.StorageMover/new-AzStorageMoverUploadLimitWeeklyRecurrenceObject
schema: 2.0.0
---

# New-AzStorageMoverUploadLimitWeeklyRecurrenceObject

## SYNOPSIS
Create an in-memory object for UploadLimitWeeklyRecurrence.

## SYNTAX

```
New-AzStorageMoverUploadLimitWeeklyRecurrenceObject -Day <DayOfWeek[]> -EndTimeHour <Int32>
 -LimitInMbps <Int32> -StartTimeHour <Int32> [-EndTimeMinute <Int32>] [-StartTimeMinute <Int32>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for UploadLimitWeeklyRecurrence.

## EXAMPLES

### Example 1: Create an upload limit weekly recurrence object 
```powershell
New-AzStorageMoverUploadLimitWeeklyRecurrenceObject -Day 'Monday','Tuesday','Friday' -LimitInMbps 100 -EndTimeHour 5 -StartTimeHour 1 -StartTimeMinute 30 -EndTimeMinute 0
```

```output
Day                       EndTimeHour EndTimeMinute LimitInMbps StartTimeHour StartTimeMinute
---                       ----------- ------------- ----------- ------------- ---------------
{Monday, Tuesday, Friday} 5           0             100         1             30
```

This command creates an upload limit weekly recurrence object.

## PARAMETERS

### -Day
The set of days of week for the schedule recurrence.
A day must not be specified more than once in a recurrence.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Support.DayOfWeek[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndTimeHour
The hour element of the time.
Allowed values range from 0 (start of the selected day) to 24 (end of the selected day).
Hour value 24 cannot be combined with any other minute value but 0.

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

### -EndTimeMinute
The minute element of the time.
Allowed values are 0 and 30.
If not specified, its value defaults to 0.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LimitInMbps
The WAN-link upload bandwidth (maximum data transfer rate) in megabits per second.
Value of 0 indicates no throughput is allowed and any running migration job is effectively paused for the duration of this recurrence.
Only data plane operations are governed by this limit.
Control plane operations ensure seamless functionality.
The agent may exceed this limit with control messages, if necessary.

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

### -StartTimeHour
The hour element of the time.
Allowed values range from 0 (start of the selected day) to 24 (end of the selected day).
Hour value 24 cannot be combined with any other minute value but 0.

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

### -StartTimeMinute
The minute element of the time.
Allowed values are 0 and 30.
If not specified, its value defaults to 0.

```yaml
Type: System.Int32
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

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20240701.UploadLimitWeeklyRecurrence

## NOTES

## RELATED LINKS

