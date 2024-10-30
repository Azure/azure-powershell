---
external help file:
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/Az.MachineLearningServices/new-AzMLWorkspaceComputeStartStopScheduleObject
schema: 2.0.0
---

# New-AzMLWorkspaceComputeStartStopScheduleObject

## SYNOPSIS
Create an in-memory object for ComputeStartStopSchedule.

## SYNTAX

```
New-AzMLWorkspaceComputeStartStopScheduleObject [-Action <ComputePowerAction>] [-CronExpression <String>]
 [-CronStartTime <String>] [-CronTimeZone <String>] [-RecurrenceFrequency <ComputeRecurrenceFrequency>]
 [-RecurrenceInterval <Int32>] [-RecurrenceStartTime <String>] [-RecurrenceTimeZone <String>]
 [-ScheduleHour <Int32[]>] [-ScheduleId <String>] [-ScheduleMinute <Int32[]>] [-ScheduleMonthDay <Int32[]>]
 [-ScheduleProvisioningStatus <ScheduleProvisioningState>] [-ScheduleStatus <ScheduleStatus>]
 [-ScheduleWeekDay <ComputeWeekDay[]>] [-Status <ScheduleStatus>] [-TriggerType <ComputeTriggerType>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ComputeStartStopSchedule.

## EXAMPLES

### Example 1: Create an in-memory object for ComputeStartStopSchedule
```powershell
New-AzMLWorkspaceComputeStartStopScheduleObject
```

Create an in-memory object for ComputeStartStopSchedule

## PARAMETERS

### -Action
[Required] The compute power action.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.ComputePowerAction
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CronExpression
[Required] Specifies cron expression of schedule.
        The expression should follow NCronTab format.

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

### -CronStartTime
The start time in yyyy-MM-ddTHH:mm:ss format.

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

### -CronTimeZone
Specifies time zone in which the schedule runs.
        TimeZone should follow Windows time zone format.
Refer: https://docs.microsoft.com/en-us/windows-hardware/manufacture/desktop/default-time-zones?view=windows-11.

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

### -RecurrenceFrequency
[Required] The frequency to trigger schedule.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.ComputeRecurrenceFrequency
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecurrenceInterval
[Required] Specifies schedule interval in conjunction with frequency.

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

### -RecurrenceStartTime
The start time in yyyy-MM-ddTHH:mm:ss format.

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

### -RecurrenceTimeZone
Specifies time zone in which the schedule runs.
        TimeZone should follow Windows time zone format.
Refer: https://docs.microsoft.com/en-us/windows-hardware/manufacture/desktop/default-time-zones?view=windows-11.

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

### -ScheduleHour
[Required] List of hours for the schedule.

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

### -ScheduleId
A system assigned id for the schedule.

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

### -ScheduleMinute
[Required] List of minutes for the schedule.

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

### -ScheduleMonthDay
List of month days for the schedule.

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

### -ScheduleProvisioningStatus
The current deployment state of schedule.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.ScheduleProvisioningState
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleStatus
Is the schedule enabled or disabled?.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.ScheduleStatus
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleWeekDay
List of days for the schedule.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.ComputeWeekDay[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Status
Is the schedule enabled or disabled?.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.ScheduleStatus
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TriggerType
[Required] The schedule trigger type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.ComputeTriggerType
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

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ComputeStartStopSchedule

## NOTES

## RELATED LINKS

