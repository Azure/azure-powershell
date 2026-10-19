---
external help file:
Module Name: Az.RedHatOpenShiftHcp
online version: https://learn.microsoft.com/powershell/module/az.redhatopenshifthcp/new-azredhatopenshifthcpcluster
schema: 2.0.0
---

# New-AzRedHatOpenShiftHcpCluster

## SYNOPSIS
Create a HcpOpenShiftCluster

## SYNTAX

### CreateExpanded (Default)
```
New-AzRedHatOpenShiftHcpCluster -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-ActiveKeyName <String>] [-ActiveKeyVersion <String>]
 [-ApiAuthorizedCidR <String[]>] [-ApiVisibility <String>] [-AutoscalingMaxNodeProvisionTimeSecond <Int32>]
 [-AutoscalingMaxNodesTotal <Int32>] [-AutoscalingMaxPodGracePeriodSecond <Int32>]
 [-AutoscalingPodPriorityThreshold <Int32>] [-ClusterImageRegistryState <String>]
 [-CryptoRestriction <String>] [-CustomerManagedEncryptionType <String>] [-DnsBaseDomainPrefix <String>]
 [-EnableSystemAssignedIdentity] [-ImageDigestMirror <IImageDigestMirror[]>] [-IngressType <String>]
 [-KmVaultName <String>] [-KmVisibility <String>] [-NetworkHostPrefix <Int32>] [-NetworkMachineCidr <String>]
 [-NetworkPodCidr <String>] [-NetworkServiceCidr <String>] [-NetworkType <String>]
 [-NodeDrainTimeoutMinute <Int32>] [-PlatformManagedResourceGroup <String>]
 [-PlatformNetworkSecurityGroupId <String>] [-PlatformOutboundType <String>] [-PlatformSubnetId <String>]
 [-PlatformVnetIntegrationSubnetId <String>] [-Tag <Hashtable>] [-UserAssignedIdentity <String[]>]
 [-UserAssignedIdentityControlPlaneOperator <Hashtable>] [-UserAssignedIdentityDataPlaneOperator <Hashtable>]
 [-UserAssignedIdentityServiceManagedIdentity <String>] [-VersionChannelGroup <String>] [-VersionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzRedHatOpenShiftHcpCluster -Name <String> -ResourceGroupName <String> -Resource <IHcpOpenShiftCluster>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzRedHatOpenShiftHcpCluster -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzRedHatOpenShiftHcpCluster -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create a HcpOpenShiftCluster

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

### -ActiveKeyName
name is the name of the keyvault key used for encryption/decryption.

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

### -ActiveKeyVersion
version contains the version of the key to use.

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

### -ApiAuthorizedCidR
The list of authorized IPv4 CIDR blocks allowed to access the API server.
Maximum 500 entries.

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

### -ApiVisibility
The internet visibility of the OpenShift API server

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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoscalingMaxNodesTotal
maxNodesTotal is the maximum allowable number of nodes for the Autoscaler scale out to be operational.The autoscaler will not grow the cluster beyond this number.
If omitted, the autoscaler will not have a maximum limit.

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

### -AutoscalingMaxPodGracePeriodSecond
maxPodGracePeriod is the maximum seconds to wait for graceful pod termination before scaling down a NodePool.The default is 600 seconds.

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

### -AutoscalingPodPriorityThreshold
podPriorityThreshold enables users to schedule "best-effort" pods, which shouldn't trigger autoscaler actions,but only run when there are spare resources available.
The default is -10.See the following for more details:https://github.com/kubernetes/autoscaler/blob/master/cluster-autoscaler/FAQ.md#how-does-cluster-autoscaler-work-with-pod-priority-and-preemption

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

### -ClusterImageRegistryState
state indicates the desired ImageStream-backed cluster image registry installation mode.This can only be set during cluster creation and cannot be changed after cluster creation.Enabled means the ImageStream-backed image registry will be run as pods on worker nodes inthe cluster.
Disabled means the ImageStream-backed image registry will not be present inthe cluster.
The default is Enabled.

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

### -CryptoRestriction
Cryptographic restrictions for kernel and userspace libraries

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

### -CustomerManagedEncryptionType
The encryption type used.By default, "KMS" is used.

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

### -DnsBaseDomainPrefix
BaseDomainPrefix is the unique name of the cluster representing the OpenShift's cluster name.BaseDomainPrefix is the name that will appear in the cluster's DNS, provisioned cloud providers resources

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

### -EnableSystemAssignedIdentity
Determines whether to enable a system-assigned identity for the resource.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IngressType
The type of the default cluster ingress.

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

### -KmVaultName
vaultName is the name of the keyvault that contains the secret.

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

### -KmVisibility
visibility of the keyvault that contains the secret.

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

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the HcpOpenShiftCluster

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: HcpOpenShiftClusterName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkHostPrefix
Network host prefix

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

### -NetworkMachineCidr
The CIDR block from which to assign machine IP addresses

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

### -NetworkPodCidr
The CIDR of the pod IP addresses

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

### -NetworkServiceCidr
The CIDR block for assigned service IPs

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

### -NetworkType
The main controller responsible for rendering the core networking components

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

### -NodeDrainTimeoutMinute
nodeDrainTimeoutMinutes is the grace period for how long Pod Disruption Budget-protected workloads will berespected during any node draining operation.
After this grace period, any workloads protected by Pod DisruptionBudgets that have not been successfully drained from a node will be forcibly evicted.
This isespecially relevant to cluster upgrades.Valid values are in minutes and from 0 to 10080 minutes (1 week).0 means that the MachinePool can be drained without any time limitation.This is the value is used a default for all NodePools.
It can be overriddenby specifying nodeDrainTimeoutMinutes for a given NodePool

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

### -PlatformManagedResourceGroup
Resource group name to put cluster resourcesIf not specified then a unique name is generated from thefollowing pattern"aro-hcp-" + clusterName + "-" + UUIDwhere clusterName means the hcpOpenShiftClusters resource name(up to 45 characters) followed by a 16-byte universally uniqueidentifier per RFC 4122.

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

### -PlatformNetworkSecurityGroupId
ResourceId for the NSG (network security group) attached to the cluster subnetNote that NSGs cannot be reused for other ARO-HCP clusters.

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

### -PlatformOutboundType
The core outgoing configuration

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

### -PlatformSubnetId
The Azure resource ID of the worker subnetNote that a subnet cannot be reused between ARO-HCP Clusters.

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

### -PlatformVnetIntegrationSubnetId
The Azure resource ID of a subnet that enables direct,private network connectivity between the hosted control planeand your cluster's nodes.
This subnet must be dedicated to ARO HCPand cannot be shared with the cluster subnet or any node pool subnets.

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

### -Resource
HCP cluster resource

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IHcpOpenShiftCluster
Parameter Sets: Create
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
The value must be an UUID.

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
Resource tags.

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

### -UserAssignedIdentity
The array of user assigned identities associated with the resource.
The elements in array will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'

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

### -UserAssignedIdentityControlPlaneOperator
The set of Azure User-Assigned Managed Identities leveraged for the Control Planeoperators of the cluster.
The set of required managed identities is dependent on theCluster's OpenShift version.

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

### -UserAssignedIdentityDataPlaneOperator
The set of Azure User-Assigned Managed Identities leveraged for the Data Planeoperators of the cluster.
The set of required managed identities is dependent on theCluster's OpenShift version.

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

### -UserAssignedIdentityServiceManagedIdentity
Represents the information associated to an Azure User-Assigned Managed Identity whosepurpose is to perform service level actions.

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

### -VersionChannelGroup
ChannelGroup is the name of the set to which this version belongs.Each version belongs to only a single set.If not specified, the default value is 'stable'.

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

### -VersionId
ID is the desired X.Y version of the cluster control plane.

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

### Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IHcpOpenShiftCluster

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IHcpOpenShiftCluster

## NOTES

## RELATED LINKS

