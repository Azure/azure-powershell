---
external help file:
Module Name: Az.VMware
online version: https://learn.microsoft.com/powershell/module/az.vmware/invoke-azvmwareschedulemaintenance
schema: 2.0.0
---

# Invoke-AzVMwareScheduleMaintenance

## SYNOPSIS
Schedule a maintenance

## SYNTAX

### ScheduleExpanded (Default)
```
Invoke-AzVMwareScheduleMaintenance -MaintenanceName <String> -PrivateCloudName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-Message <String>] [-ScheduleTime <DateTime>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Schedule
```
Invoke-AzVMwareScheduleMaintenance -MaintenanceName <String> -PrivateCloudName <String>
 -ResourceGroupName <String> -Body <IMaintenanceSchedule> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ScheduleViaIdentity
```
Invoke-AzVMwareScheduleMaintenance -InputObject <IVMwareIdentity> -Body <IMaintenanceSchedule>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ScheduleViaIdentityExpanded
```
Invoke-AzVMwareScheduleMaintenance -InputObject <IVMwareIdentity> [-Message <String>]
 [-ScheduleTime <DateTime>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ScheduleViaIdentityPrivateCloud
```
Invoke-AzVMwareScheduleMaintenance -MaintenanceName <String> -PrivateCloudInputObject <IVMwareIdentity>
 -Body <IMaintenanceSchedule> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ScheduleViaIdentityPrivateCloudExpanded
```
Invoke-AzVMwareScheduleMaintenance -MaintenanceName <String> -PrivateCloudInputObject <IVMwareIdentity>
 [-Message <String>] [-ScheduleTime <DateTime>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Schedule a maintenance

## EXAMPLES

### Example 1: Schedule a maintenance
```powershell
Invoke-AzVMwareScheduleMaintenance -MaintenanceName maintenance1 -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```

```output
Name         DisplayName      StateName    ScheduledStartTime   ReadinessStatus ProvisioningState
----         -----------      ---------    ------------------   --------------- -----------------
maintenance1 vcsa 7.0 upgrade NotScheduled 1/12/2023 4:17:55 PM NotReady        Succeeded
```

Schedules the specified maintenance item within the private cloud and resource group.

## PARAMETERS

### -Body
schedule a maintenance

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IMaintenanceSchedule
Parameter Sets: Schedule, ScheduleViaIdentity, ScheduleViaIdentityPrivateCloud
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Type: Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IVMwareIdentity
Parameter Sets: ScheduleViaIdentity, ScheduleViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MaintenanceName
Name of the maintenance

```yaml
Type: System.String
Parameter Sets: Schedule, ScheduleExpanded, ScheduleViaIdentityPrivateCloud, ScheduleViaIdentityPrivateCloudExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Message
scheduling message

```yaml
Type: System.String
Parameter Sets: ScheduleExpanded, ScheduleViaIdentityExpanded, ScheduleViaIdentityPrivateCloudExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateCloudInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IVMwareIdentity
Parameter Sets: ScheduleViaIdentityPrivateCloud, ScheduleViaIdentityPrivateCloudExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PrivateCloudName
Name of the private cloud

```yaml
Type: System.String
Parameter Sets: Schedule, ScheduleExpanded
Aliases:

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
Parameter Sets: Schedule, ScheduleExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleTime
schedule time

```yaml
Type: System.DateTime
Parameter Sets: ScheduleExpanded, ScheduleViaIdentityExpanded, ScheduleViaIdentityPrivateCloudExpanded
Aliases:

Required: False
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
Parameter Sets: Schedule, ScheduleExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IMaintenanceSchedule

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IVMwareIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IMaintenance

## NOTES

## RELATED LINKS

