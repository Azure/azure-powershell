---
external help file:
Module Name: Az.DesktopVirtualization
online version: https://learn.microsoft.com/powershell/module/az.desktopvirtualization/update-azwvdscalingplanpooledschedule
schema: 2.0.0
---

# Update-AzWvdScalingPlanPooledSchedule

## SYNOPSIS
Update a ScalingPlanPooledSchedule.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzWvdScalingPlanPooledSchedule -ResourceGroupName <String> -ScalingPlanName <String>
 -ScalingPlanScheduleName <String> [-SubscriptionId <String>] [-DaysOfWeek <DayOfWeek[]>]
 [-OffPeakLoadBalancingAlgorithm <SessionHostLoadBalancingAlgorithm>] [-OffPeakStartTimeHour <Int32>]
 [-OffPeakStartTimeMinute <Int32>] [-PeakLoadBalancingAlgorithm <SessionHostLoadBalancingAlgorithm>]
 [-PeakStartTimeHour <Int32>] [-PeakStartTimeMinute <Int32>] [-RampDownCapacityThresholdPct <Int32>]
 [-RampDownForceLogoffUser] [-RampDownLoadBalancingAlgorithm <SessionHostLoadBalancingAlgorithm>]
 [-RampDownMinimumHostsPct <Int32>] [-RampDownNotificationMessage <String>] [-RampDownStartTimeHour <Int32>]
 [-RampDownStartTimeMinute <Int32>] [-RampDownStopHostsWhen <StopHostsWhen>] [-RampDownWaitTimeMinute <Int32>]
 [-RampUpCapacityThresholdPct <Int32>] [-RampUpLoadBalancingAlgorithm <SessionHostLoadBalancingAlgorithm>]
 [-RampUpMinimumHostsPct <Int32>] [-RampUpStartTimeHour <Int32>] [-RampUpStartTimeMinute <Int32>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzWvdScalingPlanPooledSchedule -InputObject <IDesktopVirtualizationIdentity>
 [-DaysOfWeek <DayOfWeek[]>] [-OffPeakLoadBalancingAlgorithm <SessionHostLoadBalancingAlgorithm>]
 [-OffPeakStartTimeHour <Int32>] [-OffPeakStartTimeMinute <Int32>]
 [-PeakLoadBalancingAlgorithm <SessionHostLoadBalancingAlgorithm>] [-PeakStartTimeHour <Int32>]
 [-PeakStartTimeMinute <Int32>] [-RampDownCapacityThresholdPct <Int32>] [-RampDownForceLogoffUser]
 [-RampDownLoadBalancingAlgorithm <SessionHostLoadBalancingAlgorithm>] [-RampDownMinimumHostsPct <Int32>]
 [-RampDownNotificationMessage <String>] [-RampDownStartTimeHour <Int32>] [-RampDownStartTimeMinute <Int32>]
 [-RampDownStopHostsWhen <StopHostsWhen>] [-RampDownWaitTimeMinute <Int32>]
 [-RampUpCapacityThresholdPct <Int32>] [-RampUpLoadBalancingAlgorithm <SessionHostLoadBalancingAlgorithm>]
 [-RampUpMinimumHostsPct <Int32>] [-RampUpStartTimeHour <Int32>] [-RampUpStartTimeMinute <Int32>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update a ScalingPlanPooledSchedule.

## EXAMPLES

### Example 1: Update a ScalingPlanPooledSchedule
```powershell
Update-AzWvdScalingPlanPooledSchedule -ResourceGroupName rgName `
                                        -ScalingPlanName spName `
                                        -ScalingPlanScheduleName scheduleName `
                                        -DaysOfWeek @('Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday') `
                                        -RampUpStartTimeHour 6 `
                                        -RampUpStartTimeMinute 30 `
                                        -RampUpLoadBalancingAlgorithm BreadthFirst `
                                        -RampUpMinimumHostsPct 20 `
                                        -RampUpCapacityThresholdPct 20 `
                                        -PeakStartTimeHour 8 `
                                        -PeakStartTimeMinute 30 `
                                        -PeakLoadBalancingAlgorithm DepthFirst `
                                        -RampDownStartTimeHour 16 `
                                        -RampDownStartTimeMinute 0 `
                                        -RampDownLoadBalancingAlgorithm BreadthFirst `
                                        -RampDownMinimumHostsPct 20 `
                                        -RampDownCapacityThresholdPct 20 `
                                        -RampDownForceLogoffUser:$true `
                                        -RampDownWaitTimeMinute 30 `
                                        -RampDownNotificationMessage "Log out now, please." `
                                        -RampDownStopHostsWhen ZeroSessions `
                                        -OffPeakStartTimeHour 22 `
                                        -OffPeakStartTimeMinute 45 `
                                        -OffPeakLoadBalancingAlgorithm DepthFirst
```

```output
Name
----
spName/scheduleName
```

Updates an existing PooledSchedule in a Scaling Plan.

## PARAMETERS

### -DaysOfWeek
Set of days of the week on which this schedule is active.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.DayOfWeek[]
Parameter Sets: (All)
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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IDesktopVirtualizationIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -OffPeakLoadBalancingAlgorithm
Load balancing algorithm for off-peak period.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.SessionHostLoadBalancingAlgorithm
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OffPeakStartTimeHour
The hour.

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

### -OffPeakStartTimeMinute
The minute.

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

### -PeakLoadBalancingAlgorithm
Load balancing algorithm for peak period.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.SessionHostLoadBalancingAlgorithm
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PeakStartTimeHour
The hour.

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

### -PeakStartTimeMinute
The minute.

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

### -RampDownCapacityThresholdPct
Capacity threshold for ramp down period.

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

### -RampDownForceLogoffUser
Should users be logged off forcefully from hosts.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RampDownLoadBalancingAlgorithm
Load balancing algorithm for ramp down period.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.SessionHostLoadBalancingAlgorithm
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RampDownMinimumHostsPct
Minimum host percentage for ramp down period.

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

### -RampDownNotificationMessage
Notification message for users during ramp down period.

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

### -RampDownStartTimeHour
The hour.

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

### -RampDownStartTimeMinute
The minute.

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

### -RampDownStopHostsWhen
Specifies when to stop hosts during ramp down period.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.StopHostsWhen
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RampDownWaitTimeMinute
Number of minutes to wait to stop hosts during ramp down period.

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

### -RampUpCapacityThresholdPct
Capacity threshold for ramp up period.

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

### -RampUpLoadBalancingAlgorithm
Load balancing algorithm for ramp up period.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.SessionHostLoadBalancingAlgorithm
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RampUpMinimumHostsPct
Minimum host percentage for ramp up period.

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

### -RampUpStartTimeHour
The hour.

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

### -RampUpStartTimeMinute
The minute.

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScalingPlanName
The name of the scaling plan.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScalingPlanScheduleName
The name of the ScalingPlanSchedule

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IDesktopVirtualizationIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20230905.IScalingPlanPooledSchedule

## NOTES

## RELATED LINKS

