---
external help file:
Module Name: Az.DesktopVirtualization
online version: https://learn.microsoft.com/powershell/module/az.desktopvirtualization/update-azwvdscalingplan
schema: 2.0.0
---

# Update-AzWvdScalingPlan

## SYNOPSIS
Update a scaling plan.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzWvdScalingPlan -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Description <String>] [-ExclusionTag <String>] [-FriendlyName <String>]
 [-HostPoolReference <IScalingHostPoolReference[]>] [-Schedule <IScalingSchedule[]>] [-Tag <Hashtable>]
 [-TimeZone <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzWvdScalingPlan -InputObject <IDesktopVirtualizationIdentity> [-Description <String>]
 [-ExclusionTag <String>] [-FriendlyName <String>] [-HostPoolReference <IScalingHostPoolReference[]>]
 [-Schedule <IScalingSchedule[]>] [-Tag <Hashtable>] [-TimeZone <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update a scaling plan.

## EXAMPLES

### Example 1: Update a Windows Virtual Desktop Scaling Plan by name
```powershell
Update-AzWvdScalingPlan `
            -ResourceGroupName ResourceGroupName `
            -Name 'scalingPlan1' `
            -Description 'Description' `
            -FriendlyName 'Friendly Name' `
            -TimeZone '(UTC-08:00) Pacific Time (US & Canada)' `
            -Schedule @(
                @{
                    'name'                           = 'Work Week';
                    'daysOfWeek'                     = @('Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday');
                    'rampUpStartTime'                = '1900-01-01T06:00:00Z';
                    'rampUpLoadBalancingAlgorithm'   = 'BreadthFirst';
                    'rampUpMinimumHostsPct'          = 20;
                    'rampUpCapacityThresholdPct'     = 20;
                    'peakStartTime'                  = '1900-01-01T08:00:00Z';
                    'peakLoadBalancingAlgorithm'     = 'DepthFirst';
                    'RampDownStartTime'              = '1900-01-01T18:00:00Z';
                    'rampDownLoadBalancingAlgorithm' = 'BreadthFirst';
                    'rampDownMinimumHostsPct'        = 20;
                    'rampDownCapacityThresholdPct'   = 20;
                    'rampDownForceLogoffUser'        = $true;
                    'rampDownWaitTimeMinute'         = 30;
                    'rampDownNotificationMessage'    = 'Log out now, please.';
                    'rampDownStopHostsWhen'          = 'ZeroSessions';
                    'offPeakStartTime'               = '1900-01-01T20:00:00Z';
                    'offPeakLoadBalancingAlgorithm'  = 'DepthFirst';
                }
            ) `
            -HostPoolReference @(
                @{
                    'hostPoolArmPath' = '/subscriptions/SubscriptionId/resourceGroups/ResourceGroupName/providers/Microsoft.DesktopVirtualization/hostPools/HostPoolName1';
                    'scalingPlanEnabled' = $false;
                },
                @{
                    'hostPoolArmPath' = '/subscriptions/SubscriptionId/resourceGroups/ResourceGroupName/providers/Microsoft.DesktopVirtualization/hostPools/HostPoolName2';
                    'scalingPlanEnabled' = $false;
                }

            )
```

```output
Location      Name         Type
--------      ----         ----
westcentralus scalingPlan1 Microsoft.DesktopVirtualization/scalingplans
```

This command updates a Windows Virtual Desktop Scaling Plan in a Resource Group.

## PARAMETERS

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

### -Description
Description of scaling plan.

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

### -ExclusionTag
Exclusion tag for scaling plan.

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

### -FriendlyName
User friendly name of scaling plan.

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

### -HostPoolReference
List of ScalingHostPoolReference definitions.
To construct, see NOTES section for HOSTPOOLREFERENCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api202209.IScalingHostPoolReference[]
Parameter Sets: (All)
Aliases:

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

### -Name
The name of the scaling plan.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: ScalingPlanName

Required: True
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

### -Schedule
List of ScalingSchedule definitions.
To construct, see NOTES section for SCHEDULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api202209.IScalingSchedule[]
Parameter Sets: (All)
Aliases:

Required: False
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

### -Tag
tags to be updated

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TimeZone
Timezone of the scaling plan.

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

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api202209.IScalingPlan

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`HOSTPOOLREFERENCE <IScalingHostPoolReference[]>`: List of ScalingHostPoolReference definitions.
  - `[HostPoolArmPath <String>]`: Arm path of referenced hostpool.
  - `[ScalingPlanEnabled <Boolean?>]`: Is the scaling plan enabled for this hostpool.

`INPUTOBJECT <IDesktopVirtualizationIdentity>`: Identity Parameter
  - `[ApplicationGroupName <String>]`: The name of the application group
  - `[ApplicationName <String>]`: The name of the application within the specified application group
  - `[DesktopName <String>]`: The name of the desktop within the specified desktop group
  - `[HostPoolName <String>]`: The name of the host pool within the specified resource group
  - `[Id <String>]`: Resource identity path
  - `[MsixPackageFullName <String>]`: The version specific package full name of the MSIX package within specified hostpool
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[ScalingPlanName <String>]`: The name of the scaling plan.
  - `[ScalingPlanScheduleName <String>]`: The name of the ScalingPlanSchedule
  - `[SessionHostName <String>]`: The name of the session host within the specified host pool
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[UserSessionId <String>]`: The name of the user session within the specified session host
  - `[WorkspaceName <String>]`: The name of the workspace

`SCHEDULE <IScalingSchedule[]>`: List of ScalingSchedule definitions.
  - `[DaysOfWeek <String[]>]`: Set of days of the week on which this schedule is active.
  - `[Name <String>]`: Name of the ScalingPlanPooledSchedule.
  - `[OffPeakLoadBalancingAlgorithm <SessionHostLoadBalancingAlgorithm?>]`: Load balancing algorithm for off-peak period.
  - `[OffPeakStartTimeHour <Int32?>]`: The hour.
  - `[OffPeakStartTimeMinute <Int32?>]`: The minute.
  - `[PeakLoadBalancingAlgorithm <SessionHostLoadBalancingAlgorithm?>]`: Load balancing algorithm for peak period.
  - `[PeakStartTimeHour <Int32?>]`: The hour.
  - `[PeakStartTimeMinute <Int32?>]`: The minute.
  - `[RampDownCapacityThresholdPct <Int32?>]`: Capacity threshold for ramp down period.
  - `[RampDownForceLogoffUser <Boolean?>]`: Should users be logged off forcefully from hosts.
  - `[RampDownLoadBalancingAlgorithm <SessionHostLoadBalancingAlgorithm?>]`: Load balancing algorithm for ramp down period.
  - `[RampDownMinimumHostsPct <Int32?>]`: Minimum host percentage for ramp down period.
  - `[RampDownNotificationMessage <String>]`: Notification message for users during ramp down period.
  - `[RampDownStartTimeHour <Int32?>]`: The hour.
  - `[RampDownStartTimeMinute <Int32?>]`: The minute.
  - `[RampDownStopHostsWhen <StopHostsWhen?>]`: Specifies when to stop hosts during ramp down period.
  - `[RampDownWaitTimeMinute <Int32?>]`: Number of minutes to wait to stop hosts during ramp down period.
  - `[RampUpCapacityThresholdPct <Int32?>]`: Capacity threshold for ramp up period.
  - `[RampUpLoadBalancingAlgorithm <SessionHostLoadBalancingAlgorithm?>]`: Load balancing algorithm for ramp up period.
  - `[RampUpMinimumHostsPct <Int32?>]`: Minimum host percentage for ramp up period.
  - `[RampUpStartTimeHour <Int32?>]`: The hour.
  - `[RampUpStartTimeMinute <Int32?>]`: The minute.

## RELATED LINKS

