---
external help file:
Module Name: Az.Purview
online version: https://learn.microsoft.com/powershell/module/Az.Purview/new-azpurviewtriggerobject
schema: 2.0.0
---

# New-AzPurviewTriggerObject

## SYNOPSIS
Create an in-memory object for Trigger.

## SYNTAX

```
New-AzPurviewTriggerObject [-IncrementalScanStartTime <DateTime>] [-Interval <Int32>]
 [-RecurrenceEndTime <DateTime>] [-RecurrenceFrequency <String>] [-RecurrenceInterval <String>]
 [-RecurrenceScheduleAdditionalProperty <IRecurrenceScheduleAdditionalProperties>]
 [-RecurrenceScheduleHour <Int32[]>] [-RecurrenceScheduleMinute <Int32[]>]
 [-RecurrenceScheduleMonthDay <Int32[]>]
 [-RecurrenceScheduleMonthlyOccurrence <IRecurrenceScheduleOccurrence[]>]
 [-RecurrenceScheduleWeekDay <String[]>] [-RecurrenceStartTime <DateTime>] [-RecurrenceTimeZone <String>]
 [-ScanLevel <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for Trigger.

## EXAMPLES

### Example 1: Create trigger object
```powershell
New-AzPurviewTriggerObject -RecurrenceEndTime '7/20/2022 12:00:00 AM' -RecurrenceStartTime '2/17/2022 1:32:00 PM' -Interval 1 -RecurrenceFrequency 'Month' -ScanLevel 'Full' -RecurrenceScheduleHour $(9) -RecurrenceScheduleMinute $(0) -RecurrenceScheduleMonthDay $(10)
```

```output
CreatedAt                  :
Id                         :
IncrementalScanStartTime   :
Interval                   : 1
LastModifiedAt             :
LastScheduled              :
Name                       :
RecurrenceEndTime          : 7/20/2022 12:00:00 AM
RecurrenceFrequency        : Month
RecurrenceInterval         :
RecurrenceStartTime        : 2/17/2022 1:32:00 PM
RecurrenceTimeZone         :
ResourceGroupName          :
ScanLevel                  : Full
ScheduleAdditionalProperty : {
                             }
ScheduleHour               : {9}
ScheduleMinute             : {0}
ScheduleMonthDay           : {10}
ScheduleMonthlyOccurrence  :
ScheduleWeekDay            :
```

Create trigger object

## PARAMETERS

### -IncrementalScanStartTime


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

### -Interval


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

### -RecurrenceEndTime


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

### -RecurrenceFrequency


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

### -RecurrenceInterval


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

### -RecurrenceScheduleAdditionalProperty
Dictionary of \<any\>.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IRecurrenceScheduleAdditionalProperties
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecurrenceScheduleHour


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

### -RecurrenceScheduleMinute


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

### -RecurrenceScheduleMonthDay


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

### -RecurrenceScheduleMonthlyOccurrence


```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IRecurrenceScheduleOccurrence[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecurrenceScheduleWeekDay


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

### -RecurrenceStartTime


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

### -RecurrenceTimeZone


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

### -ScanLevel


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

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.Trigger

## NOTES

## RELATED LINKS

