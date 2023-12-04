---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://learn.microsoft.com/powershell/module/az.sql/get-azsqlinstancestartstopschedule
schema: 2.0.0
---

# Get-AzSqlInstanceStartStopSchedule

## SYNOPSIS
Get start/stop schedule for Azure SQL Managed Instance

## SYNTAX

### GetInstanceScheduleInputParameters (Default)
```
Get-AzSqlInstanceStartStopSchedule -InstanceName <String> [-ResourceGroupName] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetInstanceScheduleByInstanceModelInputParameters
```
Get-AzSqlInstanceStartStopSchedule -InstanceModel <AzureSqlManagedInstanceModel> [-ResourceGroupName] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Get start/stop schedule for Azure SQL Managed Instance

## EXAMPLES

### Example 1
```powershell
Get-AzSqlInstanceStartStopSchedule -InstanceName instance-name -ResourceGroupName rg-name
```
```output
Description TimeZoneId                   ScheduleList
----------- ----------                   ------------
            Central Europe Standard Time {Microsoft.Azure.Commands.Sql.ManagedInstanceSchedule.Model.ScheduleItem}
```

Gets start/stop schedule for instance-name in rg-name resource group.

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

### -InstanceModel
Instance model input object.

```yaml
Type: AzureSqlManagedInstanceModel
Parameter Sets: GetInstanceScheduleByInstanceModelInputParameters
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
Parameter Sets: GetInstanceScheduleInputParameters
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel

## OUTPUTS

### Microsoft.Azure.Commands.Sql.ManagedInstanceSchedule.Model.AzureSqlManagedInstanceScheduleModel

## NOTES

## RELATED LINKS
[Remove-AzSqlInstanceStartStopSchedule](./Remove-AzSqlInstanceStartStopSchedule.md)

[New-AzSqlInstanceStartStopSchedule](./New-AzSqlInstanceStartStopSchedule.md)
