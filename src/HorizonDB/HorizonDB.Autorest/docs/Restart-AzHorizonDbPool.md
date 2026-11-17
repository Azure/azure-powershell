---
external help file:
Module Name: Az.HorizonDB
online version: https://learn.microsoft.com/powershell/module/az.horizondb/restart-azhorizondbpool
schema: 2.0.0
---

# Restart-AzHorizonDbPool

## SYNOPSIS
Restarts the PostgreSQL container on all allocated nodes in a ready HorizonDB pool and applies pending dynamic and static parameter changes.
This customer-initiated Restart is the only operation that applies static parameter changes or dynamic parameter changes requested with PendingReboot; Stop followed by Start and scheduled maintenance do not apply them.
Power operations are supported only at pool scope in this API version; there is no cluster-level restart action.
When the pool has no allocated nodes, the operation succeeds without restarting any nodes, pending changes are considered applied, parameterGroup.syncStatus becomes InSync, and the resulting configuration applies to nodes allocated later.
The request fails with 409 Conflict when another operation is in progress or the pool is in any other incompatible state.

## SYNTAX

### Restart (Default)
```
Restart-AzHorizonDbPool -ClusterName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### RestartViaIdentity
```
Restart-AzHorizonDbPool -InputObject <IHorizonDbIdentity> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RestartViaIdentityCluster
```
Restart-AzHorizonDbPool -ClusterInputObject <IHorizonDbIdentity> -Name <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Restarts the PostgreSQL container on all allocated nodes in a ready HorizonDB pool and applies pending dynamic and static parameter changes.
This customer-initiated Restart is the only operation that applies static parameter changes or dynamic parameter changes requested with PendingReboot; Stop followed by Start and scheduled maintenance do not apply them.
Power operations are supported only at pool scope in this API version; there is no cluster-level restart action.
When the pool has no allocated nodes, the operation succeeds without restarting any nodes, pending changes are considered applied, parameterGroup.syncStatus becomes InSync, and the resulting configuration applies to nodes allocated later.
The request fails with 409 Conflict when another operation is in progress or the pool is in any other incompatible state.

## EXAMPLES

### Example 1: Restart a pool
```powershell
Restart-AzHorizonDbPool -ResourceGroupName 'exampleresourcegroup' -ClusterName 'examplecluster' -Name 'example-pool-01' | Format-List -Property Name, ComputeModelVCore, NodeCount, HighAvailabilityMode, State, ProvisioningState, ParameterGroupApplyMethod, ParameterGroupSyncStatus
```

```output
Name                      : example-pool-01
ComputeModelVCore         : 2
NodeCount                 : 3
HighAvailabilityMode      : AnyZone
State                     : Ready
ProvisioningState         : Succeeded
ParameterGroupApplyMethod : PendingReboot
ParameterGroupSyncStatus  : InSync
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

### -ClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity
Parameter Sets: RestartViaIdentityCluster
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
Parameter Sets: Restart
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
Parameter Sets: RestartViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the HorizonDB pool.

```yaml
Type: System.String
Parameter Sets: Restart, RestartViaIdentityCluster
Aliases: PoolName

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Restart
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
Parameter Sets: Restart
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IPool

## NOTES

## RELATED LINKS

