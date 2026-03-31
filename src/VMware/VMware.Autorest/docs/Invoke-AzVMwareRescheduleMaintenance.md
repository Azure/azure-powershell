---
external help file:
Module Name: Az.VMware
online version: https://learn.microsoft.com/powershell/module/az.vmware/invoke-azvmwarereschedulemaintenance
schema: 2.0.0
---

# Invoke-AzVMwareRescheduleMaintenance

## SYNOPSIS
Reschedule a maintenance

## SYNTAX

### RescheduleExpanded (Default)
```
Invoke-AzVMwareRescheduleMaintenance -MaintenanceName <String> -PrivateCloudName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-Message <String>] [-RescheduleTime <DateTime>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Reschedule
```
Invoke-AzVMwareRescheduleMaintenance -MaintenanceName <String> -PrivateCloudName <String>
 -ResourceGroupName <String> -Body <IMaintenanceReschedule> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RescheduleViaIdentity
```
Invoke-AzVMwareRescheduleMaintenance -InputObject <IVMwareIdentity> -Body <IMaintenanceReschedule>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RescheduleViaIdentityExpanded
```
Invoke-AzVMwareRescheduleMaintenance -InputObject <IVMwareIdentity> [-Message <String>]
 [-RescheduleTime <DateTime>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RescheduleViaIdentityPrivateCloud
```
Invoke-AzVMwareRescheduleMaintenance -MaintenanceName <String> -PrivateCloudInputObject <IVMwareIdentity>
 -Body <IMaintenanceReschedule> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RescheduleViaIdentityPrivateCloudExpanded
```
Invoke-AzVMwareRescheduleMaintenance -MaintenanceName <String> -PrivateCloudInputObject <IVMwareIdentity>
 [-Message <String>] [-RescheduleTime <DateTime>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Reschedule a maintenance

## EXAMPLES

### Example 1: Reschedule a maintenance
```powershell
Invoke-AzVMwareRescheduleMaintenance -MaintenanceName maintenance1 -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```

```output
Name         DisplayName      StateName ScheduledStartTime   ProvisioningState
----         -----------      --------- ------------------   -----------------
maintenance1 vcsa 7.0 upgrade Scheduled 1/12/2023 4:17:55 PM Succeeded
```

Reschedules the specified maintenance within the private cloud and resource group.

## PARAMETERS

### -Body
reschedule a maintenance

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IMaintenanceReschedule
Parameter Sets: Reschedule, RescheduleViaIdentity, RescheduleViaIdentityPrivateCloud
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
Parameter Sets: RescheduleViaIdentity, RescheduleViaIdentityExpanded
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
Parameter Sets: Reschedule, RescheduleExpanded, RescheduleViaIdentityPrivateCloud, RescheduleViaIdentityPrivateCloudExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Message
rescheduling reason

```yaml
Type: System.String
Parameter Sets: RescheduleExpanded, RescheduleViaIdentityExpanded, RescheduleViaIdentityPrivateCloudExpanded
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
Parameter Sets: RescheduleViaIdentityPrivateCloud, RescheduleViaIdentityPrivateCloudExpanded
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
Parameter Sets: Reschedule, RescheduleExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RescheduleTime
reschedule time

```yaml
Type: System.DateTime
Parameter Sets: RescheduleExpanded, RescheduleViaIdentityExpanded, RescheduleViaIdentityPrivateCloudExpanded
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
Parameter Sets: Reschedule, RescheduleExpanded
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
Parameter Sets: Reschedule, RescheduleExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IMaintenanceReschedule

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IVMwareIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IMaintenance

## NOTES

## RELATED LINKS

