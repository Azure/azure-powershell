---
external help file:
Module Name: Az.Aks
online version: https://learn.microsoft.com/powershell/module/az.aks/new-azaksmaintenanceconfiguration
schema: 2.0.0
---

# New-AzAksMaintenanceConfiguration

## SYNOPSIS
Create a maintenance configuration in the specified managed cluster.

## SYNTAX

### CreateExpanded (Default)
```
New-AzAksMaintenanceConfiguration -ConfigName <String> -ResourceGroupName <String> -ResourceName <String>
 [-SubscriptionId <String>] [-AbsoluteMonthlyDayOfMonth <Int32>] [-AbsoluteMonthlyIntervalMonth <Int32>]
 [-DailyIntervalDay <Int32>] [-MaintenanceWindowDurationHour <Int32>]
 [-MaintenanceWindowNotAllowedDate <IDateSpan[]>] [-MaintenanceWindowStartDate <DateTime>]
 [-MaintenanceWindowStartTime <String>] [-MaintenanceWindowUtcOffset <String>] [-NotAllowedTime <ITimeSpan[]>]
 [-RelativeMonthlyDayOfWeek <String>] [-RelativeMonthlyIntervalMonth <Int32>]
 [-RelativeMonthlyWeekIndex <String>] [-TimeInWeek <ITimeInWeek[]>] [-WeeklyDayOfWeek <String>]
 [-WeeklyIntervalWeek <Int32>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzAksMaintenanceConfiguration -ConfigName <String> -ResourceGroupName <String> -ResourceName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzAksMaintenanceConfiguration -ConfigName <String> -ResourceGroupName <String> -ResourceName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create a maintenance configuration in the specified managed cluster.

## EXAMPLES

### Example 1: Creates or updates a maintenance configuration in the specified managed cluster
```powershell
$TimeSpan = New-AzAksTimeSpanObject -Start (Get-Date -Year 2023 -Month 3 -Day 1) -End (Get-Date -Year 2023 -Month 3 -Day 2)
$TimeInWeek = New-AzAksTimeInWeekObject -Day Sunday -HourSlot 1,2
New-AzAksMaintenanceConfiguration -ResourceGroupName mygroup -ResourceName myCluster -ConfigName 'aks_maintenance_config' -TimeInWeek $TimeInWeek -NotAllowedTime $TimeSpan
```

```output
Id                           : /subscriptions/{subId}/resourceGroups/mygroup/providers/Microsoft.ContainerService/managedClusters/myCluster/maintenanceConfigurations/aks_mainten
                               ance_config
Name                         : aks_maintenance_config
NotAllowedTime               : {{
                                 "start": "2023-03-01T07:56:08.2725383Z",
                                 "end": "2023-03-02T07:56:08.2727034Z"
                               }}
ResourceGroupName            : mygroup
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
TimeInWeek                   : {{
                                 "day": "Sunday",
                                 "hourSlots": [ 1, 2 ]
                               }}
Type                         :
```

Create a maintenance configuration "aks_maintenance_config" in a managed cluster "myCluster" with a time in week and a not allowed time span.

## PARAMETERS

### -AbsoluteMonthlyDayOfMonth
The date of the month.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AbsoluteMonthlyIntervalMonth
Specifies the number of months between each set of occurrences.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigName
The name of the maintenance configuration.

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

### -DailyIntervalDay
Specifies the number of days between each set of occurrences.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaintenanceWindowDurationHour
Length of maintenance window range from 4 to 24 hours.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaintenanceWindowNotAllowedDate
Date ranges on which upgrade is not allowed.
'utcOffset' applies to this field.
For example, with 'utcOffset: +02:00' and 'dateSpan' being '2022-12-23' to '2023-01-03', maintenance will be blocked from '2022-12-22 22:00' to '2023-01-03 22:00' in UTC time.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IDateSpan[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaintenanceWindowStartDate
The date the maintenance window activates.
If the current date is before this date, the maintenance window is inactive and will not be used for upgrades.
If not specified, the maintenance window will be active right away.

```yaml
Type: System.DateTime
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaintenanceWindowStartTime
The start time of the maintenance window.
Accepted values are from '00:00' to '23:59'.
'utcOffset' applies to this field.
For example: '02:00' with 'utcOffset: +02:00' means UTC time '00:00'.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaintenanceWindowUtcOffset
The UTC offset in format +/-HH:mm.
For example, '+05:30' for IST and '-07:00' for PST.
If not specified, the default is '+00:00'.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NotAllowedTime
Time slots on which upgrade is not allowed.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeSpan[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RelativeMonthlyDayOfWeek
Specifies on which day of the week the maintenance occurs.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RelativeMonthlyIntervalMonth
Specifies the number of months between each set of occurrences.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RelativeMonthlyWeekIndex
The week index.
Specifies on which week of the month the dayOfWeek applies.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -ResourceName
The name of the managed cluster resource.

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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TimeInWeek
Time slots during the week when planned maintenance is allowed to proceed.
If two array entries specify the same day of the week, the applied configuration is the union of times in both entries.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeInWeek[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WeeklyDayOfWeek
Specifies on which day of the week the maintenance occurs.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WeeklyIntervalWeek
Specifies the number of weeks between each set of occurrences.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
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
Type: System.Management.Automation.SwitchParameter
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IMaintenanceConfiguration

## NOTES

## RELATED LINKS

