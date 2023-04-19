---
external help file:
Module Name: Az.ContainerService
online version: https://learn.microsoft.com/powershell/module/az.containerservice/new-azcontainerserviceagentpool
schema: 2.0.0
---

# New-AzContainerServiceAgentPool

## SYNOPSIS
Creates or updates an agent pool in the specified managed cluster.

## SYNTAX

```
New-AzContainerServiceAgentPool -Name <String> -ResourceGroupName <String> -ResourceName <String>
 [-SubscriptionId <String>] [-AvailabilityZone <String[]>] [-Count <Int32>]
 [-CreationDataSourceResourceId <String>] [-EnableAutoScaling] [-EnableEncryptionAtHost] [-EnableFips]
 [-EnableNodePublicIP] [-EnableUltraSsd] [-GpuInstanceProfile <GpuInstanceProfile>] [-HostGroupId <String>]
 [-KubeletConfigAllowedUnsafeSysctl <String[]>] [-KubeletConfigContainerLogMaxFile <Int32>]
 [-KubeletConfigContainerLogMaxSizeMb <Int32>] [-KubeletConfigCpuCfsQuota]
 [-KubeletConfigCpuCfsQuotaPeriod <String>] [-KubeletConfigCpuManagerPolicy <String>]
 [-KubeletConfigFailSwapOn] [-KubeletConfigImageGcHighThreshold <Int32>]
 [-KubeletConfigImageGcLowThreshold <Int32>] [-KubeletConfigPodMaxPid <Int32>]
 [-KubeletConfigTopologyManagerPolicy <String>] [-KubeletDiskType <KubeletDiskType>]
 [-LinuxOSConfigSwapFileSizeMb <Int32>] [-LinuxOSConfigSysctl <ISysctlConfig>]
 [-LinuxOSConfigTransparentHugePageDefrag <String>] [-LinuxOSConfigTransparentHugePageEnabled <String>]
 [-MaxCount <Int32>] [-MaxPod <Int32>] [-MinCount <Int32>] [-Mode <AgentPoolMode>] [-NodeLabel <Hashtable>]
 [-NodePublicIPPrefixId <String>] [-NodeTaint <String[]>] [-OrchestratorVersion <String>]
 [-OSDiskSizeGb <Int32>] [-OSDiskType <OSDiskType>] [-OSSku <Ossku>] [-OSType <OSType>]
 [-PodSubnetId <String>] [-PowerStateCode <Code>] [-PropertiesType <AgentPoolType>]
 [-ProximityPlacementGroupId <String>] [-ScaleDownMode <ScaleDownMode>]
 [-ScaleSetEvictionPolicy <ScaleSetEvictionPolicy>] [-ScaleSetPriority <ScaleSetPriority>]
 [-SpotMaxPrice <Single>] [-Tag <Hashtable>] [-UpgradeSettingMaxSurge <String>] [-VMSize <String>]
 [-VnetSubnetId <String>] [-WorkloadRuntime <WorkloadRuntime>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates an agent pool in the specified managed cluster.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
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

### -AvailabilityZone
The list of Availability zones to use for nodes.
This can only be specified if the AgentPoolType property is 'VirtualMachineScaleSets'.

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

### -Count
Number of agents (VMs) to host docker containers.
Allowed values must be in the range of 0 to 1000 (inclusive) for user pools and in the range of 1 to 1000 (inclusive) for system pools.
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

### -CreationDataSourceResourceId
This is the ARM ID of the source object to be used to create the target object.

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
This is only supported on certain VM sizes and in certain Azure regions.
For more information, see: https://docs.microsoft.com/azure/aks/enable-host-encryption

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

### -EnableFips
See [Add a FIPS-enabled node pool](https://docs.microsoft.com/azure/aks/use-multiple-node-pools#add-a-fips-enabled-node-pool-preview) for more details.

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

### -EnableNodePublicIP
Some scenarios may require nodes in a node pool to receive their own dedicated public IP addresses.
A common scenario is for gaming workloads, where a console needs to make a direct connection to a cloud virtual machine to minimize hops.
For more information see [assigning a public IP per node](https://docs.microsoft.com/azure/aks/use-multiple-node-pools#assign-a-public-ip-per-node-for-your-node-pools).
The default is false.

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

### -EnableUltraSsd
Whether to enable UltraSSD

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

### -GpuInstanceProfile
GPUInstanceProfile to be used to specify GPU MIG instance profile for supported GPU VM SKU.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Support.GpuInstanceProfile
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HostGroupId
This is of the form: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/hostGroups/{hostGroupName}.
For more information see [Azure dedicated hosts](https://docs.microsoft.com/azure/virtual-machines/dedicated-hosts).

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

### -KubeletConfigAllowedUnsafeSysctl
Allowed list of unsafe sysctls or unsafe sysctl patterns (ending in `*`).

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

### -KubeletConfigContainerLogMaxFile
The maximum number of container log files that can be present for a container.
The number must be ≥ 2.

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

### -KubeletConfigContainerLogMaxSizeMb
The maximum size (e.g.
10Mi) of container log file before it is rotated.

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

### -KubeletConfigCpuCfsQuota
The default is true.

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

### -KubeletConfigCpuCfsQuotaPeriod
The default is '100ms.' Valid values are a sequence of decimal numbers with an optional fraction and a unit suffix.
For example: '300ms', '2h45m'.
Supported units are 'ns', 'us', 'ms', 's', 'm', and 'h'.

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

### -KubeletConfigCpuManagerPolicy
The default is 'none'.
See [Kubernetes CPU management policies](https://kubernetes.io/docs/tasks/administer-cluster/cpu-management-policies/#cpu-management-policies) for more information.
Allowed values are 'none' and 'static'.

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

### -KubeletConfigFailSwapOn
If set to true it will make the Kubelet fail to start if swap is enabled on the node.

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

### -KubeletConfigImageGcHighThreshold
To disable image garbage collection, set to 100.
The default is 85%

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

### -KubeletConfigImageGcLowThreshold
This cannot be set higher than imageGcHighThreshold.
The default is 80%

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

### -KubeletConfigPodMaxPid
The maximum number of processes per pod.

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

### -KubeletConfigTopologyManagerPolicy
For more information see [Kubernetes Topology Manager](https://kubernetes.io/docs/tasks/administer-cluster/topology-manager).
The default is 'none'.
Allowed values are 'none', 'best-effort', 'restricted', and 'single-numa-node'.

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

### -KubeletDiskType
Determines the placement of emptyDir volumes, container runtime data root, and Kubelet ephemeral storage.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Support.KubeletDiskType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LinuxOSConfigSwapFileSizeMb
The size in MB of a swap file that will be created on each node.

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

### -LinuxOSConfigSysctl
Sysctl settings for Linux agent nodes.
To construct, see NOTES section for LINUXOSCONFIGSYSCTL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Models.Api20230301.ISysctlConfig
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LinuxOSConfigTransparentHugePageDefrag
Valid values are 'always', 'defer', 'defer+madvise', 'madvise' and 'never'.
The default is 'madvise'.
For more information see [Transparent Hugepages](https://www.kernel.org/doc/html/latest/admin-guide/mm/transhuge.html#admin-guide-transhuge).

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

### -LinuxOSConfigTransparentHugePageEnabled
Valid values are 'always', 'madvise', and 'never'.
The default is 'always'.
For more information see [Transparent Hugepages](https://www.kernel.org/doc/html/latest/admin-guide/mm/transhuge.html#admin-guide-transhuge).

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
The maximum number of nodes for auto-scaling

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

### -MaxPod
The maximum number of pods that can run on a node.

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

### -MinCount
The minimum number of nodes for auto-scaling

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
A cluster must have at least one 'System' Agent Pool at all times.
For additional information on agent pool restrictions and best practices, see: https://docs.microsoft.com/azure/aks/use-system-pools

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Support.AgentPoolMode
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the agent pool.

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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NodePublicIPPrefixId
This is of the form: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/publicIPPrefixes/{publicIPPrefixName}

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

### -NodeTaint
The taints added to new nodes during node pool create and scale.
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

### -OrchestratorVersion
Both patch version \<major.minor.patch\> (e.g.
1.20.13) and \<major.minor\> (e.g.
1.20) are supported.
When \<major.minor\> is specified, the latest supported GA patch version is chosen automatically.
Updating the cluster with the same \<major.minor\> once it has been created (e.g.
1.14.x -\> 1.14) will not trigger an upgrade, even if a newer patch version is available.
As a best practice, you should upgrade all node pools in an AKS cluster to the same Kubernetes version.
The node pool version must have the same major version as the control plane.
The node pool minor version must be within two minor versions of the control plane version.
The node pool version cannot be greater than the control plane version.
For more information see [upgrading a node pool](https://docs.microsoft.com/azure/aks/use-multiple-node-pools#upgrade-a-node-pool).

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

### -OSDiskSizeGb
OS Disk Size in GB to be used to specify the disk size for every machine in the master/agent pool.
If you specify 0, it will apply the default osDisk size according to the vmSize specified.

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
The default is 'Ephemeral' if the VM supports it and has a cache disk larger than the requested OSDiskSizeGB.
Otherwise, defaults to 'Managed'.
May not be changed after creation.
For more information see [Ephemeral OS](https://docs.microsoft.com/azure/aks/cluster-configuration#ephemeral-os).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Support.OSDiskType
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
The default is Ubuntu if OSType is Linux.
The default is Windows2019 when Kubernetes \<= 1.24 or Windows2022 when Kubernetes \>= 1.25 if OSType is Windows.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Support.Ossku
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OSType
The operating system type.
The default is Linux.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Support.OSType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PodSubnetId
If omitted, pod IPs are statically assigned on the node subnet (see vnetSubnetID for more details).
This is of the form: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/subnets/{subnetName}

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

### -PowerStateCode
Tells whether the cluster is Running or Stopped

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Support.Code
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PropertiesType
The type of Agent Pool.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Support.AgentPoolType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProximityPlacementGroupId
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

### -ResourceName
The name of the managed cluster resource.

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

### -ScaleDownMode
This also effects the cluster autoscaler behavior.
If not specified, it defaults to Delete.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Support.ScaleDownMode
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScaleSetEvictionPolicy
This cannot be specified unless the scaleSetPriority is 'Spot'.
If not specified, the default is 'Delete'.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Support.ScaleSetEvictionPolicy
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScaleSetPriority
The Virtual Machine Scale Set priority.
If not specified, the default is 'Regular'.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Support.ScaleSetPriority
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SpotMaxPrice
Possible values are any decimal value greater than zero or -1 which indicates the willingness to pay any on-demand price.
For more details on spot pricing, see [spot VMs pricing](https://docs.microsoft.com/azure/virtual-machines/spot-vms#pricing)

```yaml
Type: System.Single
Parameter Sets: (All)
Aliases:

Required: False
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

### -UpgradeSettingMaxSurge
This can either be set to an integer (e.g.
'5') or a percentage (e.g.
'50%').
If a percentage is specified, it is the percentage of the total agent pool size at the time of the upgrade.
For percentages, fractional nodes are rounded up.
If not specified, the default is 1.
For more information, including best practices, see: https://docs.microsoft.com/azure/aks/upgrade-cluster#customize-node-surge-upgrade

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

### -VMSize
VM size availability varies by region.
If a node contains insufficient compute resources (memory, cpu, etc) pods might fail to run correctly.
For more details on restricted VM sizes, see: https://docs.microsoft.com/azure/aks/quotas-skus-regions

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

### -VnetSubnetId
If this is not specified, a VNET and subnet will be generated and used.
If no podSubnetID is specified, this applies to nodes and pods, otherwise it applies to just nodes.
This is of the form: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/subnets/{subnetName}

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
Determines the type of workload a node can run.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Support.WorkloadRuntime
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Models.Api20230301.IAgentPool

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`LINUXOSCONFIGSYSCTL <ISysctlConfig>`: Sysctl settings for Linux agent nodes.
  - `[FsAioMaxNr <Int32?>]`: Sysctl setting fs.aio-max-nr.
  - `[FsFileMax <Int32?>]`: Sysctl setting fs.file-max.
  - `[FsInotifyMaxUserWatch <Int32?>]`: Sysctl setting fs.inotify.max_user_watches.
  - `[FsNrOpen <Int32?>]`: Sysctl setting fs.nr_open.
  - `[KernelThreadsMax <Int32?>]`: Sysctl setting kernel.threads-max.
  - `[NetCoreNetdevMaxBacklog <Int32?>]`: Sysctl setting net.core.netdev_max_backlog.
  - `[NetCoreOptmemMax <Int32?>]`: Sysctl setting net.core.optmem_max.
  - `[NetCoreRmemDefault <Int32?>]`: Sysctl setting net.core.rmem_default.
  - `[NetCoreRmemMax <Int32?>]`: Sysctl setting net.core.rmem_max.
  - `[NetCoreSomaxconn <Int32?>]`: Sysctl setting net.core.somaxconn.
  - `[NetCoreWmemDefault <Int32?>]`: Sysctl setting net.core.wmem_default.
  - `[NetCoreWmemMax <Int32?>]`: Sysctl setting net.core.wmem_max.
  - `[NetIpv4IPLocalPortRange <String>]`: Sysctl setting net.ipv4.ip_local_port_range.
  - `[NetIpv4NeighDefaultGcThresh1 <Int32?>]`: Sysctl setting net.ipv4.neigh.default.gc_thresh1.
  - `[NetIpv4NeighDefaultGcThresh2 <Int32?>]`: Sysctl setting net.ipv4.neigh.default.gc_thresh2.
  - `[NetIpv4NeighDefaultGcThresh3 <Int32?>]`: Sysctl setting net.ipv4.neigh.default.gc_thresh3.
  - `[NetIpv4TcpFinTimeout <Int32?>]`: Sysctl setting net.ipv4.tcp_fin_timeout.
  - `[NetIpv4TcpKeepaliveProbe <Int32?>]`: Sysctl setting net.ipv4.tcp_keepalive_probes.
  - `[NetIpv4TcpKeepaliveTime <Int32?>]`: Sysctl setting net.ipv4.tcp_keepalive_time.
  - `[NetIpv4TcpMaxSynBacklog <Int32?>]`: Sysctl setting net.ipv4.tcp_max_syn_backlog.
  - `[NetIpv4TcpMaxTwBucket <Int32?>]`: Sysctl setting net.ipv4.tcp_max_tw_buckets.
  - `[NetIpv4TcpTwReuse <Boolean?>]`: Sysctl setting net.ipv4.tcp_tw_reuse.
  - `[NetIpv4TcpkeepaliveIntvl <Int32?>]`: Sysctl setting net.ipv4.tcp_keepalive_intvl.
  - `[NetNetfilterNfConntrackBucket <Int32?>]`: Sysctl setting net.netfilter.nf_conntrack_buckets.
  - `[NetNetfilterNfConntrackMax <Int32?>]`: Sysctl setting net.netfilter.nf_conntrack_max.
  - `[VMMaxMapCount <Int32?>]`: Sysctl setting vm.max_map_count.
  - `[VMSwappiness <Int32?>]`: Sysctl setting vm.swappiness.
  - `[VMVfsCachePressure <Int32?>]`: Sysctl setting vm.vfs_cache_pressure.

## RELATED LINKS

