---
external help file:
Module Name: Az.DesktopVirtualization
online version: https://learn.microsoft.com/powershell/module/az.desktopvirtualization/update-azwvdscalingplanpersonalschedule
schema: 2.0.0
---

# Update-AzWvdScalingPlanPersonalSchedule

## SYNOPSIS
update a ScalingPlanPersonalSchedule.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzWvdScalingPlanPersonalSchedule -ResourceGroupName <String> -ScalingPlanName <String>
 -ScalingPlanScheduleName <String> [-SubscriptionId <String>] [-DaysOfWeek <String[]>]
 [-OffPeakActionOnDisconnect <String>] [-OffPeakActionOnLogoff <String>]
 [-OffPeakMinutesToWaitOnDisconnect <Int32>] [-OffPeakMinutesToWaitOnLogoff <Int32>]
 [-OffPeakStartTimeHour <Int32>] [-OffPeakStartTimeMinute <Int32>] [-OffPeakStartVMOnConnect <String>]
 [-PeakActionOnDisconnect <String>] [-PeakActionOnLogoff <String>] [-PeakMinutesToWaitOnDisconnect <Int32>]
 [-PeakMinutesToWaitOnLogoff <Int32>] [-PeakStartTimeHour <Int32>] [-PeakStartTimeMinute <Int32>]
 [-PeakStartVMOnConnect <String>] [-RampDownActionOnDisconnect <String>] [-RampDownActionOnLogoff <String>]
 [-RampDownMinutesToWaitOnDisconnect <Int32>] [-RampDownMinutesToWaitOnLogoff <Int32>]
 [-RampDownStartTimeHour <Int32>] [-RampDownStartTimeMinute <Int32>] [-RampDownStartVMOnConnect <String>]
 [-RampUpActionOnDisconnect <String>] [-RampUpActionOnLogoff <String>] [-RampUpAutoStartHost <String>]
 [-RampUpMinutesToWaitOnDisconnect <Int32>] [-RampUpMinutesToWaitOnLogoff <Int32>]
 [-RampUpStartTimeHour <Int32>] [-RampUpStartTimeMinute <Int32>] [-RampUpStartVMOnConnect <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzWvdScalingPlanPersonalSchedule -InputObject <IDesktopVirtualizationIdentity> [-DaysOfWeek <String[]>]
 [-OffPeakActionOnDisconnect <String>] [-OffPeakActionOnLogoff <String>]
 [-OffPeakMinutesToWaitOnDisconnect <Int32>] [-OffPeakMinutesToWaitOnLogoff <Int32>]
 [-OffPeakStartTimeHour <Int32>] [-OffPeakStartTimeMinute <Int32>] [-OffPeakStartVMOnConnect <String>]
 [-PeakActionOnDisconnect <String>] [-PeakActionOnLogoff <String>] [-PeakMinutesToWaitOnDisconnect <Int32>]
 [-PeakMinutesToWaitOnLogoff <Int32>] [-PeakStartTimeHour <Int32>] [-PeakStartTimeMinute <Int32>]
 [-PeakStartVMOnConnect <String>] [-RampDownActionOnDisconnect <String>] [-RampDownActionOnLogoff <String>]
 [-RampDownMinutesToWaitOnDisconnect <Int32>] [-RampDownMinutesToWaitOnLogoff <Int32>]
 [-RampDownStartTimeHour <Int32>] [-RampDownStartTimeMinute <Int32>] [-RampDownStartVMOnConnect <String>]
 [-RampUpActionOnDisconnect <String>] [-RampUpActionOnLogoff <String>] [-RampUpAutoStartHost <String>]
 [-RampUpMinutesToWaitOnDisconnect <Int32>] [-RampUpMinutesToWaitOnLogoff <Int32>]
 [-RampUpStartTimeHour <Int32>] [-RampUpStartTimeMinute <Int32>] [-RampUpStartVMOnConnect <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityScalingPlan
```
Update-AzWvdScalingPlanPersonalSchedule -ScalingPlanInputObject <IDesktopVirtualizationIdentity>
 -ScalingPlanScheduleName <String> -ScalingPlanSchedule <IScalingPlanPersonalSchedulePatch>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityScalingPlanExpanded
```
Update-AzWvdScalingPlanPersonalSchedule -ScalingPlanInputObject <IDesktopVirtualizationIdentity>
 -ScalingPlanScheduleName <String> [-DaysOfWeek <String[]>] [-OffPeakActionOnDisconnect <String>]
 [-OffPeakActionOnLogoff <String>] [-OffPeakMinutesToWaitOnDisconnect <Int32>]
 [-OffPeakMinutesToWaitOnLogoff <Int32>] [-OffPeakStartTimeHour <Int32>] [-OffPeakStartTimeMinute <Int32>]
 [-OffPeakStartVMOnConnect <String>] [-PeakActionOnDisconnect <String>] [-PeakActionOnLogoff <String>]
 [-PeakMinutesToWaitOnDisconnect <Int32>] [-PeakMinutesToWaitOnLogoff <Int32>] [-PeakStartTimeHour <Int32>]
 [-PeakStartTimeMinute <Int32>] [-PeakStartVMOnConnect <String>] [-RampDownActionOnDisconnect <String>]
 [-RampDownActionOnLogoff <String>] [-RampDownMinutesToWaitOnDisconnect <Int32>]
 [-RampDownMinutesToWaitOnLogoff <Int32>] [-RampDownStartTimeHour <Int32>] [-RampDownStartTimeMinute <Int32>]
 [-RampDownStartVMOnConnect <String>] [-RampUpActionOnDisconnect <String>] [-RampUpActionOnLogoff <String>]
 [-RampUpAutoStartHost <String>] [-RampUpMinutesToWaitOnDisconnect <Int32>]
 [-RampUpMinutesToWaitOnLogoff <Int32>] [-RampUpStartTimeHour <Int32>] [-RampUpStartTimeMinute <Int32>]
 [-RampUpStartVMOnConnect <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzWvdScalingPlanPersonalSchedule -ResourceGroupName <String> -ScalingPlanName <String>
 -ScalingPlanScheduleName <String> -JsonFilePath <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzWvdScalingPlanPersonalSchedule -ResourceGroupName <String> -ScalingPlanName <String>
 -ScalingPlanScheduleName <String> -JsonString <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
update a ScalingPlanPersonalSchedule.

## EXAMPLES

### Example 1: Update a ScalingPlanPersonalSchedule
```powershell
Update-AzWvdScalingPlanPersonalSchedule -ResourceGroupName rgName `
                                        -ScalingPlanName spName `
                                        -ScalingPlanScheduleName scheduleName `
                                        -DaysOfWeek @('Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday') `
                                        -RampUpStartTimeHour 6 `
                                        -RampUpStartTimeMinute 30 `
                                        -RampUpAutoStartHost All `
                                        -RampUpStartVMOnConnect Enable `
                                        -RampUpActionOnDisconnect None `
                                        -RampUpMinutesToWaitOnDisconnect 10 `
                                        -RampUpActionOnLogoff None `
                                        -RampUpMinutesToWaitOnLogoff 10 `
                                        -PeakStartTimeHour 8 `
                                        -PeakStartTimeMinute 30 `
                                        -PeakStartVMOnConnect Enable `
                                        -PeakActionOnDisconnect None `
                                        -PeakMinutesToWaitOnDisconnect 10 `
                                        -PeakMinutesToWaitOnLogoff 10 `
                                        -RampDownStartTimeHour 16 `
                                        -RampDownStartTimeMinute 0 `
                                        -RampDownStartVMOnConnect Enable `
                                        -RampDownActionOnDisconnect None `
                                        -RampDownMinutesToWaitOnDisconnect 10 `
                                        -RampDownMinutesToWaitOnLogoff 10 `
                                        -RampDownActionOnLogoff None `
                                        -OffPeakStartTimeHour 22 `
                                        -OffPeakStartTimeMinute 45 `
                                        -OffPeakStartVMOnConnect Enable `
                                        -OffPeakActionOnDisconnect None `
                                        -OffPeakMinutesToWaitOnDisconnect 10 `
                                        -OffPeakActionOnLogoff Deallocate `
                                        -OffPeakMinutesToWaitOnLogoff 10
```

```output
Name
----
spName/scheduleName
```

Updates an existing PersonalSchedule in a Scaling Plan.

## PARAMETERS

### -DaysOfWeek
Set of days of the week on which this schedule is active.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityScalingPlanExpanded
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

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OffPeakActionOnDisconnect
Action to be taken after a user disconnect during the off-peak period.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityScalingPlanExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OffPeakActionOnLogoff
Action to be taken after a logoff during the off-peak period.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityScalingPlanExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OffPeakMinutesToWaitOnDisconnect
The time in minutes to wait before performing the desired session handling action when a user disconnects during the off-peak period.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityScalingPlanExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OffPeakMinutesToWaitOnLogoff
The time in minutes to wait before performing the desired session handling action when a user logs off during the off-peak period.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityScalingPlanExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityScalingPlanExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityScalingPlanExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OffPeakStartVMOnConnect
The desired configuration of Start VM On Connect for the hostpool during the off-peak phase.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityScalingPlanExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PeakActionOnDisconnect
Action to be taken after a user disconnect during the peak period.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityScalingPlanExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PeakActionOnLogoff
Action to be taken after a logoff during the peak period.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityScalingPlanExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PeakMinutesToWaitOnDisconnect
The time in minutes to wait before performing the desired session handling action when a user disconnects during the peak period.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityScalingPlanExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PeakMinutesToWaitOnLogoff
The time in minutes to wait before performing the desired session handling action when a user logs off during the peak period.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityScalingPlanExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityScalingPlanExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityScalingPlanExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PeakStartVMOnConnect
The desired configuration of Start VM On Connect for the hostpool during the peak phase.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityScalingPlanExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RampDownActionOnDisconnect
Action to be taken after a user disconnect during the ramp down period.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityScalingPlanExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RampDownActionOnLogoff
Action to be taken after a logoff during the ramp down period.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityScalingPlanExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RampDownMinutesToWaitOnDisconnect
The time in minutes to wait before performing the desired session handling action when a user disconnects during the ramp down period.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityScalingPlanExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RampDownMinutesToWaitOnLogoff
The time in minutes to wait before performing the desired session handling action when a user logs off during the ramp down period.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityScalingPlanExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityScalingPlanExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityScalingPlanExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RampDownStartVMOnConnect
The desired configuration of Start VM On Connect for the hostpool during the ramp down phase.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityScalingPlanExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RampUpActionOnDisconnect
Action to be taken after a user disconnect during the ramp up period.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityScalingPlanExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RampUpActionOnLogoff
Action to be taken after a logoff during the ramp up period.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityScalingPlanExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RampUpAutoStartHost
The desired startup behavior during the ramp up period for personal vms in the hostpool.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityScalingPlanExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RampUpMinutesToWaitOnDisconnect
The time in minutes to wait before performing the desired session handling action when a user disconnects during the ramp up period.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityScalingPlanExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RampUpMinutesToWaitOnLogoff
The time in minutes to wait before performing the desired session handling action when a user logs off during the ramp up period.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityScalingPlanExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityScalingPlanExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityScalingPlanExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RampUpStartVMOnConnect
The desired configuration of Start VM On Connect for the hostpool during the ramp up phase.
If this is disabled, session hosts must be turned on using rampUpAutoStartHosts or by turning them on manually.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityScalingPlanExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScalingPlanInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IDesktopVirtualizationIdentity
Parameter Sets: UpdateViaIdentityScalingPlan, UpdateViaIdentityScalingPlanExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ScalingPlanName
The name of the scaling plan.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScalingPlanSchedule
ScalingPlanPersonalSchedule properties that can be patched.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IScalingPlanPersonalSchedulePatch
Parameter Sets: UpdateViaIdentityScalingPlan
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ScalingPlanScheduleName
The name of the ScalingPlanSchedule

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityScalingPlan, UpdateViaIdentityScalingPlanExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IScalingPlanPersonalSchedulePatch

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IScalingPlanPersonalSchedule

## NOTES

## RELATED LINKS

