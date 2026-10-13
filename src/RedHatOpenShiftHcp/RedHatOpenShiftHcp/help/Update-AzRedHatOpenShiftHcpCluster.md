---
external help file: Az.RedHatOpenShiftHcp-help.xml
Module Name: Az.RedHatOpenShiftHcp
online version: https://learn.microsoft.com/powershell/module/az.redhatopenshifthcp/update-azredhatopenshifthcpcluster
schema: 2.0.0
---

# Update-AzRedHatOpenShiftHcpCluster

## SYNOPSIS
Update a HcpOpenShiftCluster

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzRedHatOpenShiftHcpCluster -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-ActiveKeyVersion <String>] [-ApiAuthorizedCidR <String[]>] [-AutoscalingMaxNodeProvisionTimeSecond <Int32>]
 [-AutoscalingMaxNodesTotal <Int32>] [-AutoscalingMaxPodGracePeriodSecond <Int32>]
 [-AutoscalingPodPriorityThreshold <Int32>] [-ContainerRegistryManagedIdentity <String>]
 [-EnableSystemAssignedIdentity <Boolean>] [-ImageDigestMirror <IImageDigestMirror[]>]
 [-NodeDrainTimeoutMinute <Int32>] [-Tag <Hashtable>] [-UserAssignedIdentity <String[]>]
 [-UserAssignedIdentityControlPlaneOperator <Hashtable>] [-UserAssignedIdentityDataPlaneOperator <Hashtable>]
 [-UserAssignedIdentityServiceManagedIdentity <String>] [-VersionChannelGroup <String>] [-VersionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Update
```
Update-AzRedHatOpenShiftHcpCluster -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Resource <IHcpOpenShiftCluster> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzRedHatOpenShiftHcpCluster -InputObject <IRedHatOpenShiftHcpIdentity> [-ActiveKeyVersion <String>]
 [-ApiAuthorizedCidR <String[]>] [-AutoscalingMaxNodeProvisionTimeSecond <Int32>]
 [-AutoscalingMaxNodesTotal <Int32>] [-AutoscalingMaxPodGracePeriodSecond <Int32>]
 [-AutoscalingPodPriorityThreshold <Int32>] [-ContainerRegistryManagedIdentity <String>]
 [-EnableSystemAssignedIdentity <Boolean>] [-ImageDigestMirror <IImageDigestMirror[]>]
 [-NodeDrainTimeoutMinute <Int32>] [-Tag <Hashtable>] [-UserAssignedIdentity <String[]>]
 [-UserAssignedIdentityControlPlaneOperator <Hashtable>] [-UserAssignedIdentityDataPlaneOperator <Hashtable>]
 [-UserAssignedIdentityServiceManagedIdentity <String>] [-VersionChannelGroup <String>] [-VersionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzRedHatOpenShiftHcpCluster -InputObject <IRedHatOpenShiftHcpIdentity> -Resource <IHcpOpenShiftCluster>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Update a HcpOpenShiftCluster

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

### -ActiveKeyVersion
version contains the version of the key to use.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApiAuthorizedCidR
The list of authorized IPv4 CIDR blocks allowed to access the API server.
Maximum 500 entries.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -AutoscalingMaxNodeProvisionTimeSecond
maxNodeProvisionTimeSeconds is the maximum time to wait for node provisioning before considering theprovisioning to be unsuccessful.
The default is 900 seconds, or 15 minutes.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoscalingMaxNodesTotal
maxNodesTotal is the maximum allowable number of nodes.
The autoscaler will not grow the cluster beyond this number.If omitted, the autoscaler will not have a maximum limit.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoscalingMaxPodGracePeriodSecond
maxPodGracePeriodSeconds is the maximum amount of time in seconds to wait for graceful pod termination before scaling down a NodePool.The default is 600 seconds.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoscalingPodPriorityThreshold
podPriorityThreshold enables users to schedule "best-effort" pods, which shouldn't trigger autoscaler actions,but only run when there are spare resources available.
The default is -10.See the following for more details:https://github.com/kubernetes/autoscaler/blob/master/cluster-autoscaler/FAQ.md#how-does-cluster-autoscaler-work-with-pod-priority-and-preemption

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContainerRegistryManagedIdentity
The user-assigned managed identity used for container registry image pulls.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageDigestMirror
imageDigestMirrors is a set of rules to allow pulling images from amirrored registry by using digest specifications.WARNING: Updating this array will redeploy all node pools in the cluster.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IImageDigestMirror[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IRedHatOpenShiftHcpIdentity
Parameter Sets: UpdateViaIdentityExpanded, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the HcpOpenShiftCluster

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, Update
Aliases: HcpOpenShiftClusterName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NodeDrainTimeoutMinute
nodeDrainTimeoutMinutes is the grace period for how long Pod Disruption Budget-protected workloads will berespected during any node draining operation.
After this grace period, any workloads protected by Pod DisruptionBudgets that have not been successfully drained from a node will be forcibly evicted.
This isespecially relevant to cluster upgrades.Valid values are in minutes and from 0 to 10080 minutes (1 week).0 means that the MachinePool can be drained without any time limitation.This value is used as a default for all NodePools.
It can be overriddenby specifying nodeDrainTimeoutMinutes for a given NodePool

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### -Resource
HCP cluster resource

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IHcpOpenShiftCluster
Parameter Sets: Update, UpdateViaIdentity
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentityControlPlaneOperator
The set of Azure User-Assigned Managed Identities leveraged for the Control Planeoperators of the cluster.
The set of required managed identities is dependent on theCluster's OpenShift version.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentityDataPlaneOperator
The set of Azure User-Assigned Managed Identities leveraged for the Data Planeoperators of the cluster.
The set of required managed identities is dependent on theCluster's OpenShift version.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentityServiceManagedIdentity
Represents the information associated to an Azure User-Assigned Managed Identity whosepurpose is to perform service level actions.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VersionChannelGroup
ChannelGroup is the name of the set to which this version belongs.Each version belongs to only a single set.If not specified, the default value is 'stable'.This property is intended to be updateable, but that support is not yetcomplete.
Until then, changing this value after cluster creation is rejected.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VersionId
ID is the desired X.Y version of the cluster control plane.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IHcpOpenShiftCluster

### Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IRedHatOpenShiftHcpIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IHcpOpenShiftCluster

## NOTES

## RELATED LINKS
