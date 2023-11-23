---
external help file:
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/new-aznetworkcloudkubernetescluster
schema: 2.0.0
---

# New-AzNetworkCloudKubernetesCluster

## SYNOPSIS
Create a new Kubernetes cluster or update the properties of the existing one.

## SYNTAX

```
New-AzNetworkCloudKubernetesCluster -KubernetesClusterName <String> -ResourceGroupName <String>
 -ControlPlaneNodeConfigurationCount <Int64> -ControlPlaneNodeConfigurationVMSkuName <String>
 -ExtendedLocationName <String> -ExtendedLocationType <String>
 -InitialAgentPoolConfiguration <IInitialAgentPoolConfiguration[]> -KubernetesVersion <String>
 -Location <String> -NetworkConfigurationCloudServicesNetworkId <String>
 -NetworkConfigurationCniNetworkId <String> [-SubscriptionId <String>]
 [-AadConfigurationAdminGroupObjectId <String[]>] [-AdminUsername <String>]
 [-AttachedNetworkConfigurationL2Network <IL2NetworkAttachmentConfiguration[]>]
 [-AttachedNetworkConfigurationL3Network <IL3NetworkAttachmentConfiguration[]>]
 [-AttachedNetworkConfigurationTrunkedNetwork <ITrunkedNetworkAttachmentConfiguration[]>]
 [-BgpAdvertisement <IBgpAdvertisement[]>] [-BgpIPAddressPool <IIPAddressPool[]>]
 [-BgpPeer <IServiceLoadBalancerBgpPeer[]>]
 [-BgpServiceLoadBalancerConfigurationFabricPeeringEnabled <FabricPeeringEnabled>]
 [-ControlPlaneNodeConfigurationAdminPublicKey <ISshPublicKey[]>]
 [-ControlPlaneNodeConfigurationAdminUsername <String>]
 [-ControlPlaneNodeConfigurationAvailabilityZone <String[]>]
 [-ManagedResourceGroupConfigurationLocation <String>] [-ManagedResourceGroupConfigurationName <String>]
 [-NetworkConfigurationDnsServiceIP <String>] [-NetworkConfigurationPodCidr <String[]>]
 [-NetworkConfigurationServiceCidr <String[]>] [-SshPublicKey <ISshPublicKey[]>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a new Kubernetes cluster or update the properties of the existing one.

## EXAMPLES

### Example 1: Create Kubernetes cluster
```powershell
$tagHash = @{tags = "tag1" }
$agentPoolConfiguration = @{
    count = 1
    mode = "System"
    name = "agentPoolName"
    vmSkuName = "vmSkuName"
    administratorConfiguration = "administratorConfiguration"
}
$sshPublicKey = @{
    KeyData = "ssh-rsa aaaKyfsdx= fakekey@vm"
}
New-AzNetworkCloudKubernetesCluster -ResourceGroupName resourceGroupName `
                -KubernetesClusterName default -Location location `
                -ExtendedLocationName extendedLocationName `
                -ExtendedLocationType "CustomLocation" `
                -KubernetesVersion kubernetesVersion `
                -AadConfigurationAdminGroupObjectId adminGroupObjectIds `
                -AdminUsername "azureuser" `
                -SshPublicKey $sshPublicKey `
                -InitialAgentPoolConfiguration $agentPoolConfiguration `
                -NetworkConfigurationCloudServicesNetworkId cloudServicesNetworkId `
                -NetworkConfigurationCniNetworkId cniNetworkId `
                -SubscriptionId subscriptionId `
                -Tag $tagHash
```

```output
Location Name    SystemDataCreatedAt SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupName
-------- ----    ------------------- -------------------    ----------------------- ------------------------ ------------------------             ---------------------------- -----------------
eastus   default 08/09/2023 20:23:17 <identity>             User                    08/09/2023 20:44:27      <identity>                            Application                 resourceGroupName

```

This command creates a Kubernetes cluster.

## PARAMETERS

### -AadConfigurationAdminGroupObjectId
The list of Azure Active Directory group object IDs that will have an administrative role on the Kubernetes cluster.

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

### -AdminUsername
The user name for the administrator that will be applied to the operating systems that run Kubernetes nodes.
If not supplied, a user name will be chosen by the service.

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

### -AttachedNetworkConfigurationL2Network
The list of Layer 2 Networks and related configuration for attachment.
To construct, see NOTES section for ATTACHEDNETWORKCONFIGURATIONL2NETWORK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20230701.IL2NetworkAttachmentConfiguration[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AttachedNetworkConfigurationL3Network
The list of Layer 3 Networks and related configuration for attachment.
To construct, see NOTES section for ATTACHEDNETWORKCONFIGURATIONL3NETWORK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20230701.IL3NetworkAttachmentConfiguration[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AttachedNetworkConfigurationTrunkedNetwork
The list of Trunked Networks and related configuration for attachment.
To construct, see NOTES section for ATTACHEDNETWORKCONFIGURATIONTRUNKEDNETWORK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20230701.ITrunkedNetworkAttachmentConfiguration[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BgpAdvertisement
The association of IP address pools to the communities and peers, allowing for announcement of IPs.
To construct, see NOTES section for BGPADVERTISEMENT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20230701.IBgpAdvertisement[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BgpIPAddressPool
The list of pools of IP addresses that can be allocated to Load Balancer services.
To construct, see NOTES section for BGPIPADDRESSPOOL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20230701.IIPAddressPool[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BgpPeer
The list of additional BgpPeer entities that the Kubernetes cluster will peer with.
All peering must be explicitly defined.
To construct, see NOTES section for BGPPEER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20230701.IServiceLoadBalancerBgpPeer[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BgpServiceLoadBalancerConfigurationFabricPeeringEnabled
The indicator to specify if the load balancer peers with the network fabric.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.FabricPeeringEnabled
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ControlPlaneNodeConfigurationAdminPublicKey
The SSH configuration for the operating systems that run the nodes in the Kubernetes cluster.
In some cases, specification of public keys may be required to produce a working environment.
To construct, see NOTES section for CONTROLPLANENODECONFIGURATIONADMINPUBLICKEY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20230701.ISshPublicKey[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ControlPlaneNodeConfigurationAdminUsername
The user name for the administrator that will be applied to the operating systems that run Kubernetes nodes.
If not supplied, a user name will be chosen by the service.

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

### -ControlPlaneNodeConfigurationAvailabilityZone
The list of availability zones of the Network Cloud cluster to be used for the provisioning of nodes in the control plane.
If not specified, all availability zones will be used.

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

### -ControlPlaneNodeConfigurationCount
The number of virtual machines that use this configuration.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ControlPlaneNodeConfigurationVMSkuName
The name of the VM SKU supplied during creation.

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

### -ExtendedLocationName
The resource ID of the extended location on which the resource will be created.

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

### -ExtendedLocationType
The extended location type, for example, CustomLocation.

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

### -InitialAgentPoolConfiguration
The agent pools that are created with this Kubernetes cluster for running critical system services and workloads.
This data in this field is only used during creation, and the field will be empty following the creation of the Kubernetes Cluster.
After creation, the management of agent pools is done using the agentPools sub-resource.
To construct, see NOTES section for INITIALAGENTPOOLCONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20230701.IInitialAgentPoolConfiguration[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KubernetesClusterName
The name of the Kubernetes cluster.

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

### -KubernetesVersion
The Kubernetes version for this cluster.
Accepts n.n, n.n.n, and n.n.n-n format.
The interpreted version used will be resolved into this field after creation or update.

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

### -Location
The geo-location where the resource lives

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

### -ManagedResourceGroupConfigurationLocation
The location of the managed resource group.
If not specified, the location of the parent resource is chosen.

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

### -ManagedResourceGroupConfigurationName
The name for the managed resource group.
If not specified, the unique name is automatically generated.

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

### -NetworkConfigurationCloudServicesNetworkId
The resource ID of the associated Cloud Services network.

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

### -NetworkConfigurationCniNetworkId
The resource ID of the Layer 3 network that is used for creation of the Container Networking Interface network.

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

### -NetworkConfigurationDnsServiceIP
The IP address assigned to the Kubernetes DNS service.
It must be within the Kubernetes service address range specified in service CIDR.

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

### -NetworkConfigurationPodCidr
The CIDR notation IP ranges from which to assign pod IPs.
One IPv4 CIDR is expected for single-stack networking.
Two CIDRs, one for each IP family (IPv4/IPv6), is expected for dual-stack networking.

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

### -NetworkConfigurationServiceCidr
The CIDR notation IP ranges from which to assign service IPs.
One IPv4 CIDR is expected for single-stack networking.
Two CIDRs, one for each IP family (IPv4/IPv6), is expected for dual-stack networking.

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

### -SshPublicKey
The SSH configuration for the operating systems that run the nodes in the Kubernetes cluster.
In some cases, specification of public keys may be required to produce a working environment.
To construct, see NOTES section for SSHPUBLICKEY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20230701.ISshPublicKey[]
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20230701.IKubernetesCluster

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`ATTACHEDNETWORKCONFIGURATIONL2NETWORK <IL2NetworkAttachmentConfiguration[]>`: The list of Layer 2 Networks and related configuration for attachment.
  - `NetworkId <String>`: The resource ID of the network that is being configured for attachment.
  - `[PluginType <KubernetesPluginType?>]`: The indicator of how this network will be utilized by the Kubernetes cluster.

`ATTACHEDNETWORKCONFIGURATIONL3NETWORK <IL3NetworkAttachmentConfiguration[]>`: The list of Layer 3 Networks and related configuration for attachment.
  - `NetworkId <String>`: The resource ID of the network that is being configured for attachment.
  - `[IpamEnabled <L3NetworkConfigurationIpamEnabled?>]`: The indication of whether this network will or will not perform IP address management and allocate IP addresses when attached.
  - `[PluginType <KubernetesPluginType?>]`: The indicator of how this network will be utilized by the Kubernetes cluster.

`ATTACHEDNETWORKCONFIGURATIONTRUNKEDNETWORK <ITrunkedNetworkAttachmentConfiguration[]>`: The list of Trunked Networks and related configuration for attachment.
  - `NetworkId <String>`: The resource ID of the network that is being configured for attachment.
  - `[PluginType <KubernetesPluginType?>]`: The indicator of how this network will be utilized by the Kubernetes cluster.

`BGPADVERTISEMENT <IBgpAdvertisement[]>`: The association of IP address pools to the communities and peers, allowing for announcement of IPs.
  - `IPAddressPool <String[]>`: The names of the IP address pools associated with this announcement.
  - `[AdvertiseToFabric <AdvertiseToFabric?>]`: The indicator of if this advertisement is also made to the network fabric associated with the Network Cloud Cluster. This field is ignored if fabricPeeringEnabled is set to False.
  - `[Community <String[]>]`: The names of the BGP communities to be associated with the announcement, utilizing a BGP community string in 1234:1234 format.
  - `[Peer <String[]>]`: The names of the BGP peers to limit this advertisement to. If no values are specified, all BGP peers will receive this advertisement.

`BGPIPADDRESSPOOL <IIPAddressPool[]>`: The list of pools of IP addresses that can be allocated to Load Balancer services.
  - `Address <String[]>`: The list of IP address ranges. Each range can be a either a subnet in CIDR format or an explicit start-end range of IP addresses.
  - `Name <String>`: The name used to identify this IP address pool for association with a BGP advertisement.
  - `[AutoAssign <BfdEnabled?>]`: The indicator to determine if automatic allocation from the pool should occur.
  - `[OnlyUseHostIP <BfdEnabled?>]`: The indicator to prevent the use of IP addresses ending with .0 and .255 for this pool. Enabling this option will only use IP addresses between .1 and .254 inclusive.

`BGPPEER <IServiceLoadBalancerBgpPeer[]>`: The list of additional BgpPeer entities that the Kubernetes cluster will peer with. All peering must be explicitly defined.
  - `Name <String>`: The name used to identify this BGP peer for association with a BGP advertisement.
  - `PeerAddress <String>`: The IPv4 or IPv6 address used to connect this BGP session.
  - `PeerAsn <Int64>`: The autonomous system number expected from the remote end of the BGP session.
  - `[BfdEnabled <BfdEnabled?>]`: The indicator of BFD enablement for this BgpPeer.
  - `[BgpMultiHop <BgpMultiHop?>]`: The indicator to enable multi-hop peering support.
  - `[HoldTime <String>]`: The requested BGP hold time value. This field uses ISO 8601 duration format, for example P1H.
  - `[KeepAliveTime <String>]`: The requested BGP keepalive time value. This field uses ISO 8601 duration format, for example P1H.
  - `[MyAsn <Int64?>]`: The autonomous system number used for the local end of the BGP session.
  - `[Password <String>]`: The authentication password for routers enforcing TCP MD5 authenticated sessions.
  - `[PeerPort <Int64?>]`: The port used to connect this BGP session.

`CONTROLPLANENODECONFIGURATIONADMINPUBLICKEY <ISshPublicKey[]>`: The SSH configuration for the operating systems that run the nodes in the Kubernetes cluster. In some cases, specification of public keys may be required to produce a working environment.
  - `KeyData <String>`: The SSH public key data.

`INITIALAGENTPOOLCONFIGURATION <IInitialAgentPoolConfiguration[]>`: The agent pools that are created with this Kubernetes cluster for running critical system services and workloads. This data in this field is only used during creation, and the field will be empty following the creation of the Kubernetes Cluster. After creation, the management of agent pools is done using the agentPools sub-resource.
  - `Count <Int64>`: The number of virtual machines that use this configuration.
  - `Mode <AgentPoolMode>`: The selection of how this agent pool is utilized, either as a system pool or a user pool. System pools run the features and critical services for the Kubernetes Cluster, while user pools are dedicated to user workloads. Every Kubernetes cluster must contain at least one system node pool with at least one node.
  - `Name <String>`: The name that will be used for the agent pool resource representing this agent pool.
  - `VMSkuName <String>`: The name of the VM SKU that determines the size of resources allocated for node VMs.
  - `[AdministratorConfigurationAdminUsername <String>]`: The user name for the administrator that will be applied to the operating systems that run Kubernetes nodes. If not supplied, a user name will be chosen by the service.
  - `[AdministratorConfigurationSshPublicKey <ISshPublicKey[]>]`: The SSH configuration for the operating systems that run the nodes in the Kubernetes cluster. In some cases, specification of public keys may be required to produce a working environment.
    - `KeyData <String>`: The SSH public key data.
  - `[AgentOptionHugepagesCount <Int64?>]`: The number of hugepages to allocate.
  - `[AgentOptionHugepagesSize <HugepagesSize?>]`: The size of the hugepages to allocate.
  - `[AttachedNetworkConfigurationL2Network <IL2NetworkAttachmentConfiguration[]>]`: The list of Layer 2 Networks and related configuration for attachment.
    - `NetworkId <String>`: The resource ID of the network that is being configured for attachment.
    - `[PluginType <KubernetesPluginType?>]`: The indicator of how this network will be utilized by the Kubernetes cluster.
  - `[AttachedNetworkConfigurationL3Network <IL3NetworkAttachmentConfiguration[]>]`: The list of Layer 3 Networks and related configuration for attachment.
    - `NetworkId <String>`: The resource ID of the network that is being configured for attachment.
    - `[IpamEnabled <L3NetworkConfigurationIpamEnabled?>]`: The indication of whether this network will or will not perform IP address management and allocate IP addresses when attached.
    - `[PluginType <KubernetesPluginType?>]`: The indicator of how this network will be utilized by the Kubernetes cluster.
  - `[AttachedNetworkConfigurationTrunkedNetwork <ITrunkedNetworkAttachmentConfiguration[]>]`: The list of Trunked Networks and related configuration for attachment.
    - `NetworkId <String>`: The resource ID of the network that is being configured for attachment.
    - `[PluginType <KubernetesPluginType?>]`: The indicator of how this network will be utilized by the Kubernetes cluster.
  - `[AvailabilityZone <String[]>]`: The list of availability zones of the Network Cloud cluster used for the provisioning of nodes in this agent pool. If not specified, all availability zones will be used.
  - `[Label <IKubernetesLabel[]>]`: The labels applied to the nodes in this agent pool.
    - `Key <String>`: The name of the label or taint.
    - `Value <String>`: The value of the label or taint.
  - `[Taint <IKubernetesLabel[]>]`: The taints applied to the nodes in this agent pool.
  - `[UpgradeSettingMaxSurge <String>]`: The maximum number or percentage of nodes that are surged during upgrade. This can either be set to an integer (e.g. '5') or a percentage (e.g. '50%'). If a percentage is specified, it is the percentage of the total agent pool size at the time of the upgrade. For percentages, fractional nodes are rounded up. If not specified, the default is 1.

`SSHPUBLICKEY <ISshPublicKey[]>`: The SSH configuration for the operating systems that run the nodes in the Kubernetes cluster. In some cases, specification of public keys may be required to produce a working environment.
  - `KeyData <String>`: The SSH public key data.

## RELATED LINKS

