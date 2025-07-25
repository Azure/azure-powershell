---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://learn.microsoft.com/powershell/module/az.sql/new-azsqlinstancescheduleitem
schema: 2.0.0
---

# New-AzSqlInstanceScheduleItem

## SYNOPSIS
Helper command for creating ScheduleItem object that is uses for New-AzSqlInstanceStartStopSchedule cmdlet

## SYNTAX

```
New-AzSqlInstanceScheduleItem -StartDay <DayOfWeek> -StartTime <String> -StopDay <DayOfWeek> -StopTime <String>
 [-ScheduleList <ScheduleItem[]>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Creates ScheduleItem object used for creating start/stop schedule on Azure SQL Managed Instance.

## EXAMPLES

### Example 1
```powershell
$sc = New-AzSqlInstanceScheduleItem -StartDay Monday -StopDay Friday -StartTime "09:00" -StopTime "17:00"
```

Creates one schedule item thats starts on Monday at 9 AM and stops on Friday at 5 PM.

### Example 2
```powershell
$mi = Get-AzSqlInstanceStartStopSchedule -InstanceName instance-name -ResourceGroupName rg-name

$existingSchedule = $mi.ScheduleList

$newSchedule = New-AzSqlInstanceScheduleItem -StartDay Monday -StopDay Friday -StartTime "09:00" -StopTime "17:00" -ScheduleList $existingSchedule
```

Appends one more schedule item thats starts on Monday at 9 AM and stops on Friday at 5 PM on the existing schedule of the instance-name Azure SQL Managed Instance.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleList
Existing schedule items to append new one on.

```yaml
Type: ScheduleItem[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -StartDay
Start day for schedule

```yaml
Type: DayOfWeek
Parameter Sets: (All)
Aliases:
Accepted values: Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartTime
Start time for schedule

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StopDay
Stop day for schedule

```yaml
Type: DayOfWeek
Parameter Sets: (All)
Aliases:
Accepted values: Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StopTime
Stop time for schedule

```yaml
Type: String
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

### Microsoft.Azure.Commands.Sql.ManagedInstanceSchedule.Model.ScheduleItem[]

## OUTPUTS

### Microsoft.Azure.Commands.Sql.ManagedInstanceSchedule.Model.ScheduleItem

## NOTES

## RELATED LINKS
[Get-AzSqlInstanceStartStopSchedule](./Get-AzSqlInstanceStartStopSchedule.md)

[New-AzSqlInstanceStartStopSchedule](./New-AzSqlInstanceStartStopSchedule.md)

[Remove-AzSqlInstanceStartStopSchedule](./Remove-AzSqlInstanceStartStopSchedule.md)
