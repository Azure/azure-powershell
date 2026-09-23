---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Aks.dll-Help.xml
Module Name: Az.Aks
online version: https://learn.microsoft.com/powershell/module/az.aks/update-azaksnodepool
schema: 2.0.0
---

# Update-AzAksNodePool

## SYNOPSIS
Update node pool in a managed cluster.

## SYNTAX

### defaultParameterSet (Default)
```
Update-AzAksNodePool -ResourceGroupName <String> -ClusterName <String> -Name <String> [-NodeCount <Int32>]
 [-NodeImageOnly] [-AsJob] [-Force] [-KubernetesVersion <String>] [-MinCount <Int32>] [-MaxCount <Int32>]
 [-EnableAutoScaling] [-Mode <String>] [-NodeLabel <Hashtable>] [-Tag <Hashtable>] [-NodeTaint <String[]>]
 [-AksCustomHeader <Hashtable>] [-IfMatch <String>] [-IfNoneMatch <String>]
 [-NetworkProfile <AgentPoolNetworkProfile>] [-ScaleDownMode <String>] [-EnableSecureBoot] [-EnableVtpm]
 [-SshAccess <String>] [-MaxSurge <String>] [-MaxUnavailable <String>] [-DrainTimeoutInMinute <Int32>]
 [-NodeSoakDurationInMinute <Int32>] [-UndrainableNodeBehavior <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [-SubscriptionId <String>] [<CommonParameters>]
```

### ParentObjectParameterSet
```
Update-AzAksNodePool -Name <String> -ClusterObject <PSKubernetesCluster> [-NodeCount <Int32>] [-NodeImageOnly]
 [-AsJob] [-Force] [-KubernetesVersion <String>] [-MinCount <Int32>] [-MaxCount <Int32>] [-EnableAutoScaling]
 [-Mode <String>] [-NodeLabel <Hashtable>] [-Tag <Hashtable>] [-NodeTaint <String[]>]
 [-AksCustomHeader <Hashtable>] [-IfMatch <String>] [-IfNoneMatch <String>]
 [-NetworkProfile <AgentPoolNetworkProfile>] [-ScaleDownMode <String>] [-EnableSecureBoot] [-EnableVtpm]
 [-SshAccess <String>] [-MaxSurge <String>] [-MaxUnavailable <String>] [-DrainTimeoutInMinute <Int32>]
 [-NodeSoakDurationInMinute <Int32>] [-UndrainableNodeBehavior <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [-SubscriptionId <String>] [<CommonParameters>]
```

### InputObjectParameterSet
```
Update-AzAksNodePool -InputObject <PSNodePool> [-NodeCount <Int32>] [-NodeImageOnly] [-AsJob] [-Force]
 [-KubernetesVersion <String>] [-MinCount <Int32>] [-MaxCount <Int32>] [-EnableAutoScaling] [-Mode <String>]
 [-NodeLabel <Hashtable>] [-Tag <Hashtable>] [-NodeTaint <String[]>] [-AksCustomHeader <Hashtable>]
 [-IfMatch <String>] [-IfNoneMatch <String>] [-NetworkProfile <AgentPoolNetworkProfile>]
 [-ScaleDownMode <String>] [-EnableSecureBoot] [-EnableVtpm] [-SshAccess <String>] [-MaxSurge <String>]
 [-MaxUnavailable <String>] [-DrainTimeoutInMinute <Int32>] [-NodeSoakDurationInMinute <Int32>]
 [-UndrainableNodeBehavior <String>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [-SubscriptionId <String>] [<CommonParameters>]
```

### IdParameterSet
```
Update-AzAksNodePool -Id <String> [-NodeCount <Int32>] [-NodeImageOnly] [-AsJob] [-Force]
 [-KubernetesVersion <String>] [-MinCount <Int32>] [-MaxCount <Int32>] [-EnableAutoScaling] [-Mode <String>]
 [-NodeLabel <Hashtable>] [-Tag <Hashtable>] [-NodeTaint <String[]>] [-AksCustomHeader <Hashtable>]
 [-IfMatch <String>] [-IfNoneMatch <String>] [-NetworkProfile <AgentPoolNetworkProfile>]
 [-ScaleDownMode <String>] [-EnableSecureBoot] [-EnableVtpm] [-SshAccess <String>] [-MaxSurge <String>]
 [-MaxUnavailable <String>] [-DrainTimeoutInMinute <Int32>] [-NodeSoakDurationInMinute <Int32>]
 [-UndrainableNodeBehavior <String>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [-SubscriptionId <String>] [<CommonParameters>]
```

## DESCRIPTION
Update node pool in a managed cluster.

## EXAMPLES

### Example 1: Change minimum count to 5 for specified node pool
```powershell
Update-AzAksNodePool -ResourceGroupName myResourceGroup -ClusterName myCluster -Name linuxpool -MinCount 5
```

## PARAMETERS

### -AksCustomHeader
Aks custom headers

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

### -AsJob
Run cmdlet in the background

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
The name of the managed cluster resource.

```yaml
Type: System.String
Parameter Sets: defaultParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterObject
The cluster object

```yaml
Type: Microsoft.Azure.Commands.Aks.Models.PSKubernetesCluster
Parameter Sets: ParentObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DrainTimeoutInMinute
The drain timeout for a node. The amount of time (in minutes) to wait on eviction of pods and graceful termination per node. This eviction wait time honors waiting on pod disruption budgets. If this time is exceeded, the upgrade fails. If not specified, the default is 30 minutes.

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
Whether to enable auto-scaler

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

### -EnableSecureBoot
The secure Boot is a feature of Trusted Launch which ensures that only signed operating systems and drivers can boot. For more details, see aka.ms/aks/trustedlaunch.  If not specified, the default is false.

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

### -EnableVtpm
The vTPM is a Trusted Launch feature for configuring a dedicated secure vault for keys and measurements held locally on the node. For more details, see aka.ms/aks/trustedlaunch. If not specified, the default is false.

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

### -Force
Update node pool without prompt

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

### -Id
Id of an node pool in managed Kubernetes cluster

```yaml
Type: System.String
Parameter Sets: IdParameterSet
Aliases: ResourceId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IfMatch
The request should only proceed if an entity matches this string.

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

### -IfNoneMatch
The request should only proceed if no entity matches this string.

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
A PSAgentPool object, normally passed through the pipeline.

```yaml
Type: Microsoft.Azure.Commands.Aks.Models.PSNodePool
Parameter Sets: InputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -KubernetesVersion
The version of Kubernetes to use for creating the cluster.

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

### -MaxCount
Maximum number of nodes for auto-scaling

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

### -MaxSurge
The maximum number or percentage of nodes that ar surged during upgrade.

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

### -MaxUnavailable
The maximum number or percentage of nodes that can be simultaneously unavailable during upgrade. This can either be set to an integer (e.g. &#39;1&#39;) or a percentage (e.g. &#39;5%&#39;). If a percentage is specified, it is the percentage of the total agent pool size at the time of the upgrade. For percentages, fractional nodes are rounded up. If not specified, the default is 0. For more information, including best practices, see: https://learn.microsoft.com/en-us/azure/aks/upgrade-cluster

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

### -MinCount
Minimum number of nodes for auto-scaling.

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

### -Mode
The pool mode

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

### -Name
The name of the node pool.

```yaml
Type: System.String
Parameter Sets: defaultParameterSet, ParentObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkProfile
The network-related settings of an agent pool.

```yaml
Type: Microsoft.Azure.Management.ContainerService.Models.AgentPoolNetworkProfile
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NodeCount
The number of nodes for the node pools.

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

### -NodeImageOnly
Will only upgrade the node image of agent pools.

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

### -NodeLabel
Node pool labels used for building Kubernetes network.

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

### -NodeSoakDurationInMinute
The the soak duration for a node. The amount of time (in minutes) to wait after draining a node and before reimaging it and moving on to next node. If not specified, the default is 0 minutes.

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

### -NodeTaint
The node taints added to new nodes during node pool create and scale

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

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: defaultParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScaleDownMode
The scale down mode to use when scaling the Agent Pool. This also effects the cluster autoscaler behavior. If not specified, it defaults to Delete.

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

### -SshAccess
The sSH access method of an agent pool.

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

### -SubscriptionId
The ID of the subscription.
By default, cmdlets are executed in the subscription that is set in the current context. If the user specifies another subscription, the current cmdlet is executed in the subscription specified by the user.
Overriding subscriptions only take effect during the lifecycle of the current cmdlet. It does not change the subscription in the context, and does not affect subsequent cmdlets.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tag
The tags to be persisted on the agent pool virtual machine scale set.

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

### -UndrainableNodeBehavior
The behavior for undrainable nodes during upgrade. The most common cause of undrainable nodes is Pod Disruption Budgets (PDBs), but other issues, such as pod termination grace period is exceeding the remaining per-node drain timeout or pod is still being in a running state, can also cause undrainable nodes.

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

### Microsoft.Azure.Commands.Aks.Models.PSNodePool

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Aks.Models.PSNodePool

## NOTES

## RELATED LINKS
