---
external help file:
Module Name: Az.HorizonDB
online version: https://learn.microsoft.com/powershell/module/az.horizondb/stop-azhorizondbpool
schema: 2.0.0
---

# Stop-AzHorizonDbPool

## SYNOPSIS
Stops a running HorizonDB pool and deallocates compute.
Power operations are supported only at pool scope in this API version; there is no cluster-level stop action.
Stop does not apply pending dynamic or static parameter changes; parameterGroup.syncStatus remains PendingReboot.
A subsequent Start also preserves those pending changes.
The operation succeeds as an idempotent no-op when the pool is already Stopped.
It is allowed when the pool has no allocated nodes.
The Pool-scoped ReadOnly Endpoint remains discoverable but has no routing destination while the Pool is Stopped.
The request fails with 409 Conflict when another operation is in progress or the pool is in any other incompatible state.

## SYNTAX

### Stop (Default)
```
Stop-AzHorizonDbPool -ClusterName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### StopViaIdentity
```
Stop-AzHorizonDbPool -InputObject <IHorizonDbIdentity> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### StopViaIdentityCluster
```
Stop-AzHorizonDbPool -ClusterInputObject <IHorizonDbIdentity> -Name <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Stops a running HorizonDB pool and deallocates compute.
Power operations are supported only at pool scope in this API version; there is no cluster-level stop action.
Stop does not apply pending dynamic or static parameter changes; parameterGroup.syncStatus remains PendingReboot.
A subsequent Start also preserves those pending changes.
The operation succeeds as an idempotent no-op when the pool is already Stopped.
It is allowed when the pool has no allocated nodes.
The Pool-scoped ReadOnly Endpoint remains discoverable but has no routing destination while the Pool is Stopped.
The request fails with 409 Conflict when another operation is in progress or the pool is in any other incompatible state.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

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
Parameter Sets: StopViaIdentityCluster
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
Parameter Sets: Stop
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
Parameter Sets: StopViaIdentity
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
Parameter Sets: Stop, StopViaIdentityCluster
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
Parameter Sets: Stop
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
Parameter Sets: Stop
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

