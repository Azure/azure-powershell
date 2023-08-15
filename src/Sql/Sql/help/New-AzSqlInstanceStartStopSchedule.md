---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://learn.microsoft.com/powershell/module/az.sql/new-azsqlinstancestartstopschedule
schema: 2.0.0
---

# New-AzSqlInstanceStartStopSchedule

## SYNOPSIS
Creates start/stop schedule for Azure SQL Managed Instance

## SYNTAX

### NewInstanceScheduleInputParameters (Default)
```
New-AzSqlInstanceStartStopSchedule -InstanceName <String> -TimeZone <String> -ScheduleList <ScheduleItem[]>
 [-Description <String>] [-Force] [-ResourceGroupName] <String> [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### NewInstanceScheduleByInstanceModelInputParameters
```
New-AzSqlInstanceStartStopSchedule -TimeZone <String> -ScheduleList <ScheduleItem[]> [-Description <String>]
 -InstanceModel <AzureSqlManagedInstanceModel> [-Force] [-ResourceGroupName] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates start/stop schedule for Azure SQL Managed Instance

## EXAMPLES

### Example 1
```powershell
$newSchedule = New-AzSqlInstanceScheduleItem -StartDay Monday -StopDay Friday -StartTime "09:00" -StopTime "17:00"
New-AzSqlInstanceStartStopSchedule -InstanceName managed-instance-v2 -ResourceGroupName CustomerExperienceTeam_RG -ScheduleList $newSchedule -TimeZone "Central Europe Standard Time"
```

Creates new start/stop schedule that starts at Monday 9 AM and stops at Friday 5 PM.

### Example 2
```powershell
$mi = Get-AzSqlInstanceStartStopSchedule -InstanceName instance-name -ResourceGroupName rg-name

$existingSchedule = $mi.ScheduleList

$newSchedule = New-AzSqlInstanceScheduleItem -StartDay Monday -StopDay Friday -StartTime "09:00" -StopTime "17:00" -ScheduleList $existingSchedule

New-AzSqlInstanceStartStopSchedule -InstanceName managed-instance-v2 -ResourceGroupName CustomerExperienceTeam_RG -ScheduleList $newSchedule -TimeZone "Central Europe Standard Time"
```

Updates existing start/stop schedule with new schedule item starts at Monday 9 AM and stops at Friday 5 PM.

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

### -Description
The description of the schedule.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Skip confirmation message for performing the action

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InstanceModel
Instance model input object.

```yaml
Type: AzureSqlManagedInstanceModel
Parameter Sets: NewInstanceScheduleByInstanceModelInputParameters
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InstanceName
The name of the Azure SQL Managed Instance

```yaml
Type: String
Parameter Sets: NewInstanceScheduleInputParameters
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ScheduleList
Array of valid SheduleItem objects.

```yaml
Type: ScheduleItem[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TimeZone
The name of the timezone for the schedule.
Please refer to https://learn.microsoft.com/en-us/powershell/module/microsoft.powershell.management/get-timezone?view=powershell-7.3#examples for valid values.

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

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel

## OUTPUTS

### Microsoft.Azure.Commands.Sql.ManagedInstanceSchedule.Model.AzureSqlManagedInstanceScheduleModel

## NOTES

## RELATED LINKS
[Get-AzSqlInstanceStartStopSchedule](./Get-AzSqlInstanceStartStopSchedule.md)

[New-AzSqlInstanceScheduleItem](./New-AzSqlInstanceScheduleItem.md)

[Remove-AzSqlInstanceStartStopSchedule](./Remove-AzSqlInstanceStartStopSchedule.md)
