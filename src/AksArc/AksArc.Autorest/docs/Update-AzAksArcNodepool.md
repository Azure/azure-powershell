---
external help file:
Module Name: Az.AksArc
online version: https://learn.microsoft.com/powershell/module/az.aksarc/update-azaksarcnodepool
schema: 2.0.0
---

# Update-AzAksArcNodepool

## SYNOPSIS
Update the agent pool in the provisioned cluster

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzAksArcNodepool -ClusterName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Count <Int32>] [-NodeLabel <Hashtable>] [-NodeTaint <String[]>]
 [-Tag <Hashtable>] [-VMSize <String>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### AutoScaling
```
Update-AzAksArcNodepool -ClusterName <String> -Name <String> -ResourceGroupName <String> -EnableAutoScaling
 -MaxCount <Int32> -MinCount <Int32> [-SubscriptionId <String>] [-Count <Int32>] [-NodeLabel <Hashtable>]
 [-NodeTaint <String[]>] [-Tag <Hashtable>] [-VMSize <String>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
Update-AzAksArcNodepool -ClusterName <String> -InputObject <IAksArcIdentity> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-Count <Int32>] [-NodeLabel <Hashtable>]
 [-NodeTaint <String[]>] [-Tag <Hashtable>] [-VMSize <String>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Update the agent pool in the provisioned cluster

## EXAMPLES

### Example 1: Scale up nodes in provisioned cluster nodepool. 
```powershell
Update-AzAksArcNodepool -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -Name azps_test_nodepool_example -Count 3
```

Scales up the number of nodes in the provisioned cluster nodepool.

### Example 2: Update tags in nodepool
```powershell
Update-AzAksArcNodepool -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -Name azps_test_nodepool_example -Tag @{'key1'= 1; 'key2'= 2}
```

Adds the specified tags to the nodepool resource.

### Example 3: Enable autoscaling in nodepool
```powershell
Update-AzAksArcNodepool -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -Name azps_test_nodepool_example -EnableAutoScaling -MinCount 1 -MaxCount 5
```

Enables autoscaling in the nodepool with specified MinCount and MaxCount.

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

### -ClusterName
The name of the Kubernetes cluster on which get is called.

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

### -Count
Number of nodes in the agent pool.
The default value is 1.

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

### -EnableAutoScaling
Whether to enable auto-scaler.
Default value is false

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AutoScaling
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AksArc.Models.IAksArcIdentity
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MaxCount
The maximum number of nodes for auto-scaling

```yaml
Type: System.Int32
Parameter Sets: AutoScaling
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MinCount
The minimum number of nodes for auto-scaling

```yaml
Type: System.Int32
Parameter Sets: AutoScaling
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Parameter for the name of the agent pool in the provisioned cluster.

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

### -NodeLabel
The node labels to be persisted across all nodes in agent pool.

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

### -NodeTaint
Taints added to new nodes during node pool create and scale.
For example, key=value:NoSchedule.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
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

### -Tag
Resource tags

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

### -VMSize
The VM sku size of the agent pool node VMs.

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

### Microsoft.Azure.PowerShell.Cmdlets.AksArc.Models.IAksArcIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AksArc.Models.IAgentPool

## NOTES

## RELATED LINKS

