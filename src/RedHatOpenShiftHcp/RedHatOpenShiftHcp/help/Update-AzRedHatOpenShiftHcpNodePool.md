---
external help file: Az.RedHatOpenShiftHcp-help.xml
Module Name: Az.RedHatOpenShiftHcp
online version: https://learn.microsoft.com/powershell/module/az.redhatopenshifthcp/update-azredhatopenshifthcpnodepool
schema: 2.0.0
---

# Update-AzRedHatOpenShiftHcpNodePool

## SYNOPSIS
Update a NodePool

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzRedHatOpenShiftHcpNodePool -HcpOpenShiftClusterName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-AutoScalingMax <Int32>] [-AutoScalingMin <Int32>]
 [-EnableSystemAssignedIdentity <Boolean>] [-Label <ILabel[]>] [-NodeDrainTimeoutMinute <Int32>]
 [-Replica <Int32>] [-Tag <Hashtable>] [-Taint <ITaint[]>] [-UserAssignedIdentity <String[]>]
 [-VersionChannelGroup <String>] [-VersionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Update
```
Update-AzRedHatOpenShiftHcpNodePool -HcpOpenShiftClusterName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -Resource <INodePool> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityHcpOpenShiftClusterExpanded
```
Update-AzRedHatOpenShiftHcpNodePool -Name <String>
 -HcpOpenShiftClusterInputObject <IRedHatOpenShiftHcpIdentity> [-AutoScalingMax <Int32>]
 [-AutoScalingMin <Int32>] [-EnableSystemAssignedIdentity <Boolean>] [-Label <ILabel[]>]
 [-NodeDrainTimeoutMinute <Int32>] [-Replica <Int32>] [-Tag <Hashtable>] [-Taint <ITaint[]>]
 [-UserAssignedIdentity <String[]>] [-VersionChannelGroup <String>] [-VersionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityHcpOpenShiftCluster
```
Update-AzRedHatOpenShiftHcpNodePool -Name <String>
 -HcpOpenShiftClusterInputObject <IRedHatOpenShiftHcpIdentity> -Resource <INodePool>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzRedHatOpenShiftHcpNodePool -InputObject <IRedHatOpenShiftHcpIdentity> [-AutoScalingMax <Int32>]
 [-AutoScalingMin <Int32>] [-EnableSystemAssignedIdentity <Boolean>] [-Label <ILabel[]>]
 [-NodeDrainTimeoutMinute <Int32>] [-Replica <Int32>] [-Tag <Hashtable>] [-Taint <ITaint[]>]
 [-UserAssignedIdentity <String[]>] [-VersionChannelGroup <String>] [-VersionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzRedHatOpenShiftHcpNodePool -InputObject <IRedHatOpenShiftHcpIdentity> -Resource <INodePool>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Update a NodePool

## EXAMPLES

### Example 1: Scale a node pool by changing its replica count
```powershell
Update-AzRedHatOpenShiftHcpNodePool -ResourceGroupName myResourceGroup -HcpOpenShiftClusterName myCluster `
  -Name mynodepool -Replica 3
```

```output
Name        Location ProvisioningState Replica PlatformVMSize   OSDiskSizeGiB VersionId
----        -------- ----------------- ------- --------------   ------------- ---------
mynodepool  eastus   Succeeded         3       Standard_D8s_v3  128           4.22.18
```

Patches the node pool `mynodepool` to run 3 replicas.
This is an asynchronous (LRO) PATCH.

### Example 2: Change the node drain timeout
```powershell
Update-AzRedHatOpenShiftHcpNodePool -ResourceGroupName myResourceGroup -HcpOpenShiftClusterName myCluster `
  -Name mynodepool -NodeDrainTimeoutMinute 45
```

```output
Name        Location ProvisioningState Replica NodeDrainTimeoutMinute VersionId
----        -------- ----------------- ------- ---------------------- ---------
mynodepool  eastus   Succeeded         3       45                     4.22.18
```

A cheap, config-only PATCH (no node churn) that updates the node drain timeout to 45 minutes.
Only a subset of fields is patchable on a node pool (`-Replica`, `-AutoScalingMin`/`-AutoScalingMax`, `-Label`, `-Taint`, `-NodeDrainTimeoutMinute`, `-Tag`, `-VersionId`, `-VersionChannelGroup`) - not platform/subnet/osDisk/vmSize.

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

### -AutoScalingMax
The maximum number of nodes in the node pool.Validation:- Minimum: 0 (must be \>= min)- Maximum: 200 (only when availabilityZone is not specified)- No maximum when availabilityZone is specified

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityHcpOpenShiftClusterExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoScalingMin
The minimum number of nodes in the node pool.Validation:- Minimum: 0- Maximum: 200 (only when availabilityZone is not specified)- No maximum when availabilityZone is specified

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityHcpOpenShiftClusterExpanded, UpdateViaIdentityExpanded
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

### -EnableSystemAssignedIdentity
Determines whether to enable a system-assigned identity for the resource.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: UpdateExpanded, UpdateViaIdentityHcpOpenShiftClusterExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HcpOpenShiftClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IRedHatOpenShiftHcpIdentity
Parameter Sets: UpdateViaIdentityHcpOpenShiftClusterExpanded, UpdateViaIdentityHcpOpenShiftCluster
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -HcpOpenShiftClusterName
The name of the HcpOpenShiftCluster

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, Update
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
Type: Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IRedHatOpenShiftHcpIdentity
Parameter Sets: UpdateViaIdentityExpanded, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Label
Kubernetes labels to propagate to the NodePool NodesNote that when the labels are updated this is only applied to newlycreate nodes in the Nodepool, existing node labels remain unchanged.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.ILabel[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityHcpOpenShiftClusterExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the NodePool

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, Update, UpdateViaIdentityHcpOpenShiftClusterExpanded, UpdateViaIdentityHcpOpenShiftCluster
Aliases: NodePoolName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NodeDrainTimeoutMinute
nodeDrainTimeoutMinutes is the grace period for how long Pod Disruption Budget-protected workloads will berespected during any node draining operation.
After this grace period, any workloads protected by Pod DisruptionBudgets that have not been successfully drained from a node will be forcibly evicted.
This isespecially relevant to cluster upgrades.Valid values are from 0 to 10080 minutes (1 week) .0 means that the NodePool can be drained without any time limitation.If unset the cluster nodeDrainTimeoutMinutes value is used as a default.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityHcpOpenShiftClusterExpanded, UpdateViaIdentityExpanded
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

### -Replica
The number of worker nodes, it cannot be used together with autoscaling.Validation:- Minimum: 0- Maximum: 200 (only when availabilityZone is not specified)- No maximum when availabilityZone is specified

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityHcpOpenShiftClusterExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Resource
Concrete tracked resource types can be created by aliasing this type using a specific property type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.INodePool
Parameter Sets: Update, UpdateViaIdentityHcpOpenShiftCluster, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, Update
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
Parameter Sets: UpdateExpanded, Update
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityHcpOpenShiftClusterExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Taint
Taints for the nodes

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.ITaint[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityHcpOpenShiftClusterExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentity
The array of user assigned identities associated with the resource.
The elements in array will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityHcpOpenShiftClusterExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VersionChannelGroup
ChannelGroup is the name of the set to which this version belongs.Each version belongs to only a single set.If not specified, the default value is 'stable'.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityHcpOpenShiftClusterExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VersionId
ID is the unique identifier of the version.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityHcpOpenShiftClusterExpanded, UpdateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.INodePool

### Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IRedHatOpenShiftHcpIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.INodePool

## NOTES

## RELATED LINKS
