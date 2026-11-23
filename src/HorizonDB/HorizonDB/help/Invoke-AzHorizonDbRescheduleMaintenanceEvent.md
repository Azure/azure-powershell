---
external help file: Az.HorizonDB-help.xml
Module Name: Az.HorizonDB
online version: https://learn.microsoft.com/powershell/module/az.horizondb/invoke-azhorizondbreschedulemaintenanceevent
schema: 2.0.0
---

# Invoke-AzHorizonDbRescheduleMaintenanceEvent

## SYNOPSIS
Reschedules a maintenance event to a new date and time.

## SYNTAX

### RescheduleExpanded (Default)
```
Invoke-AzHorizonDbRescheduleMaintenanceEvent -ClusterName <String> -MaintenanceEventId <String>
 -PoolName <String> -ResourceGroupName <String> [-SubscriptionId <String>] -PostponeToDateTimeUtc <DateTime>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### RescheduleViaJsonString
```
Invoke-AzHorizonDbRescheduleMaintenanceEvent -ClusterName <String> -MaintenanceEventId <String>
 -PoolName <String> -ResourceGroupName <String> [-SubscriptionId <String>] -JsonString <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### RescheduleViaJsonFilePath
```
Invoke-AzHorizonDbRescheduleMaintenanceEvent -ClusterName <String> -MaintenanceEventId <String>
 -PoolName <String> -ResourceGroupName <String> [-SubscriptionId <String>] -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Reschedule
```
Invoke-AzHorizonDbRescheduleMaintenanceEvent -ClusterName <String> -MaintenanceEventId <String>
 -PoolName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Body <IMaintenanceEventRescheduleRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RescheduleViaIdentityPoolExpanded
```
Invoke-AzHorizonDbRescheduleMaintenanceEvent -MaintenanceEventId <String> -PoolInputObject <IHorizonDbIdentity>
 -PostponeToDateTimeUtc <DateTime> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RescheduleViaIdentityPool
```
Invoke-AzHorizonDbRescheduleMaintenanceEvent -MaintenanceEventId <String> -PoolInputObject <IHorizonDbIdentity>
 -Body <IMaintenanceEventRescheduleRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RescheduleViaIdentityClusterExpanded
```
Invoke-AzHorizonDbRescheduleMaintenanceEvent -MaintenanceEventId <String> -PoolName <String>
 -ClusterInputObject <IHorizonDbIdentity> -PostponeToDateTimeUtc <DateTime> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RescheduleViaIdentityCluster
```
Invoke-AzHorizonDbRescheduleMaintenanceEvent -MaintenanceEventId <String> -PoolName <String>
 -ClusterInputObject <IHorizonDbIdentity> -Body <IMaintenanceEventRescheduleRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### RescheduleViaIdentityExpanded
```
Invoke-AzHorizonDbRescheduleMaintenanceEvent -InputObject <IHorizonDbIdentity>
 -PostponeToDateTimeUtc <DateTime> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RescheduleViaIdentity
```
Invoke-AzHorizonDbRescheduleMaintenanceEvent -InputObject <IHorizonDbIdentity>
 -Body <IMaintenanceEventRescheduleRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Reschedules a maintenance event to a new date and time.

## EXAMPLES

### Example 1: Reschedule a maintenance event
```powershell
Invoke-AzHorizonDbRescheduleMaintenanceEvent -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -PoolName 'example-pool-01' -MaintenanceEventId 'ABCD-123' -PostponeToDateTimeUtc ([datetime]'2026-08-20T10:00:00Z') | Format-List -Property MaintenanceEventId, Status, AppliedNow, PlannedStartTimeUtc, PlannedEndTimeUtc
```

```output
MaintenanceEventId  : ABCD-123
Status              : Rescheduled
AppliedNow          : False
PlannedStartTimeUtc : 08/20/2026 10:00:00
PlannedEndTimeUtc   : 08/20/2026 11:00:00
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

## PARAMETERS

### -AsJob
Run the command as a job

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

### -Body
Parameters for rescheduling a maintenance event.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IMaintenanceEventRescheduleRequest
Parameter Sets: Reschedule, RescheduleViaIdentityPool, RescheduleViaIdentityCluster, RescheduleViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity
Parameter Sets: RescheduleViaIdentityClusterExpanded, RescheduleViaIdentityCluster
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ClusterName
The name of the HorizonDB cluster.

```yaml
Type: System.String
Parameter Sets: RescheduleExpanded, RescheduleViaJsonString, RescheduleViaJsonFilePath, Reschedule
Aliases:

Required: True
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
Type: Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity
Parameter Sets: RescheduleViaIdentityExpanded, RescheduleViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Reschedule operation

```yaml
Type: System.String
Parameter Sets: RescheduleViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Reschedule operation

```yaml
Type: System.String
Parameter Sets: RescheduleViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaintenanceEventId
The identifier of the maintenance event.

```yaml
Type: System.String
Parameter Sets: RescheduleExpanded, RescheduleViaJsonString, RescheduleViaJsonFilePath, Reschedule, RescheduleViaIdentityPoolExpanded, RescheduleViaIdentityPool, RescheduleViaIdentityClusterExpanded, RescheduleViaIdentityCluster
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -PoolInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity
Parameter Sets: RescheduleViaIdentityPoolExpanded, RescheduleViaIdentityPool
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PoolName
The name of the HorizonDB pool.

```yaml
Type: System.String
Parameter Sets: RescheduleExpanded, RescheduleViaJsonString, RescheduleViaJsonFilePath, Reschedule, RescheduleViaIdentityClusterExpanded, RescheduleViaIdentityCluster
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PostponeToDateTimeUtc
The new start time in RFC 3339 format.

```yaml
Type: System.DateTime
Parameter Sets: RescheduleExpanded, RescheduleViaIdentityPoolExpanded, RescheduleViaIdentityClusterExpanded, RescheduleViaIdentityExpanded
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
Parameter Sets: RescheduleExpanded, RescheduleViaJsonString, RescheduleViaJsonFilePath, Reschedule
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
Parameter Sets: RescheduleExpanded, RescheduleViaJsonString, RescheduleViaJsonFilePath, Reschedule
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

### Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity

### Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IMaintenanceEventRescheduleRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IMaintenanceEventActionResponse

## NOTES

## RELATED LINKS
