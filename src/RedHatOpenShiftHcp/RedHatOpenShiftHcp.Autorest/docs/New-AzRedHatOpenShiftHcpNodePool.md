---
external help file:
Module Name: Az.RedHatOpenShiftHcp
online version: https://learn.microsoft.com/powershell/module/az.redhatopenshifthcp/new-azredhatopenshifthcpnodepool
schema: 2.0.0
---

# New-AzRedHatOpenShiftHcpNodePool

## SYNOPSIS
Create a NodePool

## SYNTAX

### CreateExpanded (Default)
```
New-AzRedHatOpenShiftHcpNodePool -HcpOpenShiftClusterName <String> -Name <String> -ResourceGroupName <String>
 -Location <String> [-SubscriptionId <String>] [-AutoRepair] [-AutoScalingMax <Int32>]
 [-AutoScalingMin <Int32>] [-EnableSystemAssignedIdentity] [-Label <ILabel[]>]
 [-NodeDrainTimeoutMinute <Int32>] [-OSDiskEncryptionSetId <String>] [-OSDiskSizeGiB <Int32>]
 [-OSDiskStorageAccountType <String>] [-OSDiskType <String>] [-PlatformAvailabilityZone <String>]
 [-PlatformEnableEncryptionAtHost] [-PlatformSubnetId <String>] [-PlatformVMSize <String>] [-Replica <Int32>]
 [-Tag <Hashtable>] [-Taint <ITaint[]>] [-UserAssignedIdentity <String[]>] [-VersionChannelGroup <String>]
 [-VersionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Create
```
New-AzRedHatOpenShiftHcpNodePool -HcpOpenShiftClusterName <String> -Name <String> -ResourceGroupName <String>
 -Resource <INodePool> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityHcpOpenShiftCluster
```
New-AzRedHatOpenShiftHcpNodePool -HcpOpenShiftClusterInputObject <IRedHatOpenShiftHcpIdentity> -Name <String>
 -Resource <INodePool> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityHcpOpenShiftClusterExpanded
```
New-AzRedHatOpenShiftHcpNodePool -HcpOpenShiftClusterInputObject <IRedHatOpenShiftHcpIdentity> -Name <String>
 -Location <String> [-AutoRepair] [-AutoScalingMax <Int32>] [-AutoScalingMin <Int32>]
 [-EnableSystemAssignedIdentity] [-Label <ILabel[]>] [-NodeDrainTimeoutMinute <Int32>]
 [-OSDiskEncryptionSetId <String>] [-OSDiskSizeGiB <Int32>] [-OSDiskStorageAccountType <String>]
 [-OSDiskType <String>] [-PlatformAvailabilityZone <String>] [-PlatformEnableEncryptionAtHost]
 [-PlatformSubnetId <String>] [-PlatformVMSize <String>] [-Replica <Int32>] [-Tag <Hashtable>]
 [-Taint <ITaint[]>] [-UserAssignedIdentity <String[]>] [-VersionChannelGroup <String>] [-VersionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzRedHatOpenShiftHcpNodePool -HcpOpenShiftClusterName <String> -Name <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzRedHatOpenShiftHcpNodePool -HcpOpenShiftClusterName <String> -Name <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a NodePool

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

### -AutoRepair
Auto-repair

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityHcpOpenShiftClusterExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityHcpOpenShiftClusterExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityHcpOpenShiftClusterExpanded
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
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityHcpOpenShiftClusterExpanded
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
Parameter Sets: CreateViaIdentityHcpOpenShiftCluster, CreateViaIdentityHcpOpenShiftClusterExpanded
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
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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

### -Label
Kubernetes labels to propagate to the NodePool NodesNote that when the labels are updated this is only applied to newlycreate nodes in the Nodepool, existing node labels remain unchanged.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.ILabel[]
Parameter Sets: CreateExpanded, CreateViaIdentityHcpOpenShiftClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityHcpOpenShiftClusterExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the NodePool

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: CreateExpanded, CreateViaIdentityHcpOpenShiftClusterExpanded
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

### -OSDiskEncryptionSetId
The ID of the DiskEncryptionSet resource to use to encrypt the OS disks for the VMs.This needs to exist in the same subscription id listed in the Hosted Cluster, HostedCluster.Spec.Platform.Azure.SubscriptionID.DiskEncryptionSetID should also exist in a resource group under the same subscription id and the same locationlisted in the Hosted Cluster, HostedCluster.Spec.Platform.Azure.Location.Details on how to create a Disk Encryption Set can be found here:https://learn.microsoft.com/en-us/azure/virtual-machines/disks-enable-customer-managed-keys-portal#set-up-your-disk-encryption-set

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityHcpOpenShiftClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OSDiskSizeGiB
The OS disk size in GiB.
Maximum is 4095 GiB for Managed disks.
For Ephemeral disks,the maximum is 2040 GiB; Azure may enforce a lower effective limit based on theselected VM size's local cache, temp, or NVMe capacity.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityHcpOpenShiftClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OSDiskStorageAccountType
The type of the disk storage account- https://learn.microsoft.com/en-us/azure/virtual-machines/disks-types

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityHcpOpenShiftClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OSDiskType
The type of the OS disk.- https://learn.microsoft.com/en-us/azure/virtual-machines/ephemeral-os-disks

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityHcpOpenShiftClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlatformAvailabilityZone
The availability zone for the node pool.Please read the documentation to see which regions support availability zones- https://learn.microsoft.com/en-us/azure/availability-zones/az-overview

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityHcpOpenShiftClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlatformEnableEncryptionAtHost
Whether to enable host based OS and data drive encryption.- https://learn.microsoft.com/en-us/azure/virtual-machines/disk-encryption#encryption-at-host---end-to-end-encryption-for-your-vm-data

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityHcpOpenShiftClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlatformSubnetId
The Azure resource ID of the worker subnetNote that a subnet cannot be reused between ARO-HCP Clusters, however thesame subnet can be used for NodePools of the same cluster.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityHcpOpenShiftClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlatformVMSize
The VM size according to the documentation:- https://learn.microsoft.com/en-us/azure/virtual-machines/sizes

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityHcpOpenShiftClusterExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityHcpOpenShiftClusterExpanded
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
Parameter Sets: Create, CreateViaIdentityHcpOpenShiftCluster
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
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: CreateExpanded, CreateViaIdentityHcpOpenShiftClusterExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityHcpOpenShiftClusterExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityHcpOpenShiftClusterExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityHcpOpenShiftClusterExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityHcpOpenShiftClusterExpanded
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

