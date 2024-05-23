---
external help file:
Module Name: Az.AksArc
online version: https://learn.microsoft.com/powershell/module/az.aksarc/new-azaksarcnodepool
schema: 2.0.0
---

# New-AzAksArcNodepool

## SYNOPSIS
Create the agent pool in the provisioned cluster

## SYNTAX

### CreateExpanded (Default)
```
New-AzAksArcNodepool -ClusterName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Count <Int32>] [-ExtendedLocationName <String>] [-ExtendedLocationType <String>]
 [-NodeLabel <Hashtable>] [-NodeTaint <String[]>] [-OSSku <String>] [-OSType <String>] [-Tag <Hashtable>]
 [-VMSize <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### AutoScaling
```
New-AzAksArcNodepool -ClusterName <String> -Name <String> -ResourceGroupName <String> -EnableAutoScaling
 -MaxCount <Int32> -MinCount <Int32> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzAksArcNodepool -ClusterName <String> -InputObject <IAksArcIdentity> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-ExtendedLocationName <String>]
 [-ExtendedLocationType <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzAksArcNodepool -ClusterName <String> -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzAksArcNodepool -ClusterName <String> -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create the agent pool in the provisioned cluster

## EXAMPLES

### Example 1: Create a nodepool
```powershell
New-AzAksArcNodepool -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -Name azps_test_nodepool_example
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

Adds a nodepool in the provisioned cluster with default configuration.

### Example 2: Create a nodepool with 3 nodes
```powershell
New-AzAksArcNodepool -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -Name azps_test_nodepool_example -Count 3
```

Adds a nodepool in the provisioned cluster with 3 worker nodes.

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

### -ExtendedLocationName
ARM Id of the extended location.

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

### -ExtendedLocationType
The extended location type.
Allowed value: 'CustomLocation'

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
Aliases: AgentPoolName

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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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

### -OSSku
Specifies the OS SKU used by the agent pool.
The default is CBLMariner if OSType is Linux.
The default is Windows2019 when OSType is Windows.

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

### -OSType
The particular KubernetesVersion Image OS Type (Linux, Windows)

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
Aliases: resource-group

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
Parameter Sets: CreateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.AksArc.Models.IAksArcIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AksArc.Models.IAgentPool

## NOTES

## RELATED LINKS

