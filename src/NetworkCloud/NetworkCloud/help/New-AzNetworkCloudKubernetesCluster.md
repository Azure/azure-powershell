---
external help file: Az.NetworkCloud-help.xml
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
 [-SubscriptionId <String>] -ControlPlaneNodeConfigurationCount <Int64>
 -ControlPlaneNodeConfigurationVMSkuName <String> -ExtendedLocationName <String> -ExtendedLocationType <String>
 -InitialAgentPoolConfiguration <IInitialAgentPoolConfiguration[]> -KubernetesVersion <String>
 -Location <String> -NetworkConfigurationCloudServicesNetworkId <String>
 -NetworkConfigurationCniNetworkId <String> [-AadConfigurationAdminGroupObjectId <String[]>]
 [-AdminUsername <String>] [-AttachedNetworkConfigurationL2Network <IL2NetworkAttachmentConfiguration[]>]
 [-AttachedNetworkConfigurationL3Network <IL3NetworkAttachmentConfiguration[]>]
 [-AttachedNetworkConfigurationTrunkedNetwork <ITrunkedNetworkAttachmentConfiguration[]>]
 [-BgpAdvertisement <IBgpAdvertisement[]>] [-BgpIPAddressPool <IIPAddressPool[]>]
 [-BgpPeer <IServiceLoadBalancerBgpPeer[]>]
 [-BgpServiceLoadBalancerConfigurationFabricPeeringEnabled <FabricPeeringEnabled>]
 [-ControlPlaneNodeConfigurationAdminPublicKey <ISshPublicKey[]>]
 [-ControlPlaneNodeConfigurationAdminUsername <String>]
 [-ControlPlaneNodeConfigurationAvailabilityZone <String[]>]
 [-L2ServiceLoadBalancerConfigurationIPAddressPool <IIPAddressPool[]>]
 [-ManagedResourceGroupConfigurationLocation <String>] [-ManagedResourceGroupConfigurationName <String>]
 [-NetworkConfigurationDnsServiceIP <String>] [-NetworkConfigurationPodCidr <String[]>]
 [-NetworkConfigurationServiceCidr <String[]>] [-SshPublicKey <ISshPublicKey[]>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IL2NetworkAttachmentConfiguration[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IL3NetworkAttachmentConfiguration[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.ITrunkedNetworkAttachmentConfiguration[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IBgpAdvertisement[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BgpIPAddressPool
The list of pools of IP addresses that can be allocated to load balancer services.
To construct, see NOTES section for BGPIPADDRESSPOOL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IIPAddressPool[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IServiceLoadBalancerBgpPeer[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.ISshPublicKey[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IInitialAgentPoolConfiguration[]
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

### -L2ServiceLoadBalancerConfigurationIPAddressPool
The list of pools of IP addresses that can be allocated to load balancer services.
To construct, see NOTES section for L2SERVICELOADBALANCERCONFIGURATIONIPADDRESSPOOL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IIPAddressPool[]
Parameter Sets: (All)
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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.ISshPublicKey[]
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IKubernetesCluster

## NOTES

## RELATED LINKS
