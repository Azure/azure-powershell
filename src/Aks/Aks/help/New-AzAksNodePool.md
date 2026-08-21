---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Aks.dll-Help.xml
Module Name: Az.Aks
online version: https://learn.microsoft.com/powershell/module/az.aks/new-azaksnodepool
schema: 2.0.0
---

# New-AzAksNodePool

## SYNOPSIS
Create a new node pool in specified cluster.

## SYNTAX

### defaultParameterSet
```
New-AzAksNodePool -ResourceGroupName <String> -ClusterName <String> -Name <String> [-Count <Int32>]
 [-OsDiskSize <Int32>] [-OSDiskType <String>] [-VmSize <String>] [-VnetSubnetID <String>]
 [-WorkloadRuntime <String>] [-MaxPodCount <Int32>] [-MessageOfTheDay <String>] [-OsType <String>]
 [-PodIPAllocationMode <String>] [-OsSKU <String>] [-EnableNodePublicIp] [-NodePublicIPPrefixID <String>]
 [-ScaleSetPriority <String>] [-ScaleSetEvictionPolicy <String>] [-VmSetType <String>]
 [-AvailabilityZone <String[]>] [-Force] [-EnableEncryptionAtHost] [-EnableUltraSSD]
 [-GatewayPublicIPPrefixSize <Int32>] [-GPUDriver <String>] [-LinuxOSConfig <LinuxOSConfig>]
 [-KubeletConfig <KubeletConfig>] [-PPG <String>] [-SpotMaxPrice <Double>] [-EnableFIPS]
 [-GpuInstanceProfile <String>] [-HostGroupID <String>] [-PodSubnetID <String>] [-KubernetesVersion <String>]
 [-MinCount <Int32>] [-MaxCount <Int32>] [-EnableAutoScaling] [-Mode <String>] [-NodeLabel <Hashtable>]
 [-Tag <Hashtable>] [-NodeTaint <String[]>] [-AksCustomHeader <Hashtable>] [-IfMatch <String>]
 [-IfNoneMatch <String>] [-NetworkProfile <AgentPoolNetworkProfile>] [-ScaleDownMode <String>]
 [-EnableSecureBoot] [-EnableVtpm] [-SshAccess <String>] [-MaxSurge <String>] [-MaxUnavailable <String>]
 [-DrainTimeoutInMinute <Int32>] [-NodeSoakDurationInMinute <Int32>] [-UndrainableNodeBehavior <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [-SubscriptionId <String>] [<CommonParameters>]
```

### ParentObjectParameterSet
```
New-AzAksNodePool -Name <String> -ClusterObject <PSKubernetesCluster> [-Count <Int32>] [-OsDiskSize <Int32>]
 [-OSDiskType <String>] [-VmSize <String>] [-VnetSubnetID <String>] [-WorkloadRuntime <String>]
 [-MaxPodCount <Int32>] [-MessageOfTheDay <String>] [-OsType <String>] [-PodIPAllocationMode <String>]
 [-OsSKU <String>] [-EnableNodePublicIp] [-NodePublicIPPrefixID <String>] [-ScaleSetPriority <String>]
 [-ScaleSetEvictionPolicy <String>] [-VmSetType <String>] [-AvailabilityZone <String[]>] [-Force]
 [-EnableEncryptionAtHost] [-EnableUltraSSD] [-GatewayPublicIPPrefixSize <Int32>] [-GPUDriver <String>]
 [-LinuxOSConfig <LinuxOSConfig>] [-KubeletConfig <KubeletConfig>] [-PPG <String>] [-SpotMaxPrice <Double>]
 [-EnableFIPS] [-GpuInstanceProfile <String>] [-HostGroupID <String>] [-PodSubnetID <String>]
 [-KubernetesVersion <String>] [-MinCount <Int32>] [-MaxCount <Int32>] [-EnableAutoScaling] [-Mode <String>]
 [-NodeLabel <Hashtable>] [-Tag <Hashtable>] [-NodeTaint <String[]>] [-AksCustomHeader <Hashtable>]
 [-IfMatch <String>] [-IfNoneMatch <String>] [-NetworkProfile <AgentPoolNetworkProfile>]
 [-ScaleDownMode <String>] [-EnableSecureBoot] [-EnableVtpm] [-SshAccess <String>] [-MaxSurge <String>]
 [-MaxUnavailable <String>] [-DrainTimeoutInMinute <Int32>] [-NodeSoakDurationInMinute <Int32>]
 [-UndrainableNodeBehavior <String>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [-SubscriptionId <String>] [<CommonParameters>]
```

## DESCRIPTION
Create a new node pool in specified cluster.

## EXAMPLES

### Example 1: Create a node pool with default parameters
```powershell
New-AzAksNodePool -ResourceGroupName myResourceGroup -ClusterName myCluster -Name mydefault
```

### Example 2: Create Windows Server container on an AKS
```powershell
$cred = ConvertTo-SecureString -String "****" -AsPlainText -Force
New-AzAksCluster -ResourceGroupName myResourceGroup -Name myCluster -WindowsProfileAdminUserName azureuser -WindowsProfileAdminUserPassword $cred -NetworkPlugin azure -NodeVmSetType VirtualMachineScaleSets
New-AzAksNodePool -ResourceGroupName myResourceGroup -ClusterName myCluster -Name win1 -OsType Windows -VmSetType VirtualMachineScaleSets
```

### Example 3: Create a node pool with LinuxOSConfig and KubeletConfig.
When you create an AKS node pool, you can specify the kubelet and OS configurations. The type of `LinuxOSConfig` and `KubeletConfig` must be `Microsoft.Azure.Management.ContainerService.Models.LinuxOSConfig` and `Microsoft.Azure.Management.ContainerService.Models.KubeletConfig` respectively.


```powershell
$linuxOsConfigJsonStr = @'
            {
             "transparentHugePageEnabled": "madvise",
             "transparentHugePageDefrag": "defer+madvise",
             "swapFileSizeMB": 1500,
             "sysctls": {
              "netCoreSomaxconn": 163849,
              "netIpv4TcpTwReuse": true,
              "netIpv4IpLocalPortRange": "32000 60000"
             }
            }
'@
$linuxOsConfig = [Microsoft.Azure.Management.ContainerService.Models.LinuxOSConfig] ($linuxOsConfigJsonStr | ConvertFrom-Json)
$kubeletConfigStr = @'
            {
             "failSwapOn": false
            }
'@
$kubeletConfig = [Microsoft.Azure.Management.ContainerService.Models.KubeletConfig] ($kubeletConfigStr | ConvertFrom-Json)

New-AzAksNodePool -ResourceGroupName myResourceGroup -ClusterName myAKSCluster -Name mypool -LinuxOSConfig $linuxOsConfig -KubeletConfig $kubeletConfig
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

### -AvailabilityZone
Availability zones for nodes. Must use VirtualMachineScaleSets AgentPoolType.

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
Specify cluster object in which to create node pool.

```yaml
Type: Microsoft.Azure.Commands.Aks.Models.PSKubernetesCluster
Parameter Sets: ParentObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Count
The default number of nodes for the node pools.

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

### -EnableEncryptionAtHost
Whether to enable host based OS and data drive

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

### -EnableFIPS
Whether to use a FIPS-enabled OS

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

### -EnableNodePublicIp
Whether to enable public IP for nodes.

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

### -EnableUltraSSD
whether to enable UltraSSD

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
Create node pool even if it already exists

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

### -GatewayPublicIPPrefixSize
The Gateway agent pool associates one public IPPrefix for each static egress gateway to provide public egress. The size of Public IPPrefix should be selected by the user. Each node in the agent pool is assigned with one IP from the IPPrefix. The IPPrefix size thus serves as a cap on the size of the Gateway agent pool. Due to Azure public IPPrefix size limitation, the valid value range is [28, 31] (/31 = 2 nodes/IPs, /30 = 4 nodes/IPs, /29 = 8 nodes/IPs, /28 = 16 nodes/IPs). The default value is 31.

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

### -GPUDriver
Whether to install GPU drivers. When it's not specified, default is Install.

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

### -GpuInstanceProfile
The GpuInstanceProfile to be used to specify GPU MIG instance profile for supported GPU VM SKU.

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

### -HostGroupID
The fully qualified resource ID of the Dedicated Host Group to provision virtual machines from, used only in creation scenario and not allowed to changed once set.

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

### -KubeletConfig
The Kubelet configuration on the agent pool nodes.

```yaml
Type: Microsoft.Azure.Management.ContainerService.Models.KubeletConfig
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

### -LinuxOSConfig
The OS configuration of Linux agent nodes.

```yaml
Type: Microsoft.Azure.Management.ContainerService.Models.LinuxOSConfig
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

### -MaxPodCount
Maximum number of pods that can run on node.

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

### -MessageOfTheDay
The message of the day for Linux nodes, base64-encoded. A base64-encoded string which will be written to /etc/motd after decoding. This allows customization of the message of the day for Linux nodes. It must not be specified for Windows nodes. It must be a static string (i.e., will be printed raw and not be executed as a script).

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
Parameter Sets: (All)
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

### -NodePublicIPPrefixID
The resource Id of public IP prefix for node pool.

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

### -OsDiskSize
The default number of nodes for the node pools.

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

### -OSDiskType
The default is 'Ephemeral' if the VM supports it and has a cache disk larger than the requested OSDiskSizeGB. Otherwise, defaults to 'Managed'. May not be changed after creation. For more information see [Ephemeral OS](https://docs.microsoft.com/azure/aks/cluster-configuration#ephemeral-os).

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

### -OsSKU
OsSKU to be used to specify OS SKU. The default is Ubuntu if OSType is Linux. The default is Windows2019 when Kubernetes <= 1.24 or Windows2022 when Kubernetes >= 1.25 if OSType is Windows.

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

### -OsType
OsType to be used to specify os type.
Choose from Linux and Windows.
Default to Linux.

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

### -PodIPAllocationMode
The Pod IP Allocation Mode. The IP allocation mode for pods in the agent pool. Must be used with podSubnetId. The default is 'DynamicIndividual'.

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

### -PodSubnetID
The ID of the subnet which pods will join when launched.

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

### -PPG
The ID for Proximity Placement Group.

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

### -ScaleSetEvictionPolicy
ScaleSetEvictionPolicy to be used to specify eviction policy for low priority virtual machine scale set.
Default to Delete.

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

### -ScaleSetPriority
ScaleSetPriority to be used to specify virtual machine scale set priority.
Default to regular.

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

### -SpotMaxPrice
The max price (in US Dollars) you are willing to pay for spot instances. Possible values are any decimal value greater than zero or -1 which indicates default price to be up-to on-demand.

```yaml
Type: System.Nullable`1[System.Double]
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

### -VmSetType
Represents types of an node pool.
Possible values include: 'VirtualMachineScaleSets', 'AvailabilitySet'

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

### -VmSize
The size of the Virtual Machine. Default value is dynamically selected by the AKS resource provider based on quota and capacity.

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

### -VnetSubnetID
VNet SubnetID specifies the VNet's subnet identifier.

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

### -WorkloadRuntime
The type of workload a node can run.

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

### Microsoft.Azure.Commands.Aks.Models.PSKubernetesCluster

## OUTPUTS

### Microsoft.Azure.Commands.Aks.Models.PSNodePool

## NOTES

## RELATED LINKS
