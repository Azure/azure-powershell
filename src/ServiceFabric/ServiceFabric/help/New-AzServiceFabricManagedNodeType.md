---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.dll-help.xml
Module Name: Az.ServiceFabric
online version: https://learn.microsoft.com/powershell/module/az.servicefabric/new-azservicefabricmanagednodetype
schema: 2.0.0
---

# New-AzServiceFabricManagedNodeType

## SYNOPSIS
Create a Service Fabric node type of a given managed cluster.

## SYNTAX

### CreateExpanded (Default)
```
New-AzServiceFabricManagedNodeType [-Name] <String> [-ClusterName] <String> [-ResourceGroupName] <String>
 [-SubscriptionId <String>] [-AdditionalDataDisk <IVmssDataDisk[]>]
 [-AdditionalNetworkInterfaceConfiguration <IAdditionalNetworkInterfaceConfiguration[]>]
 [-ApplicationPortEndPort <Int32>] [-ApplicationPortStartPort <Int32>] [-Capacity <Hashtable>]
 [-ComputerNamePrefix <String>] [-DataDiskLetter <String>] [-DataDiskSizeGb <Int32>] [-DataDiskType <String>]
 [-DscpConfigurationId <String>] [-EnableAcceleratedNetworking] [-EnableEncryptionAtHost] [-EnableNodePublicIP]
 [-EnableNodePublicIPv6] [-EnableOverProvisioning] [-EphemeralPortEndPort <Int32>]
 [-EphemeralPortStartPort <Int32>] [-EvictionPolicy <String>]
 [-FrontendConfiguration <IFrontendConfiguration[]>] [-HostGroupId <String>] [-IsPrimary] [-IsSpotVM]
 [-IsStateless] [-MultiplePlacementGroup] [-NatConfiguration <INodeTypeNatConfig[]>] [-NatGatewayId <String>]
 [-NetworkSecurityRule <INetworkSecurityRule[]>] [-PlacementProperty <Hashtable>] [-SecureBootEnabled]
 [-SecurityEncryptionType <String>] [-SecurityType <String>] [-ServiceArtifactReferenceId <String>]
 [-SkuCapacity <Int32>] [-SkuName <String>] [-SkuTier <String>] [-SpotRestoreTimeout <String>]
 [-SubnetId <String>] [-Tag <Hashtable>] [-UseDefaultPublicLoadBalancer] [-UseEphemeralOSDisk]
 [-UseTempDataDisk] [-VMApplication <IVMApplication[]>] [-VMExtension <IVmssExtension[]>]
 [-VMImageOffer <String>] [-VMImagePlanName <String>] [-VMImagePlanProduct <String>]
 [-VMImagePlanPromotionCode <String>] [-VMImagePlanPublisher <String>] [-VMImagePublisher <String>]
 [-VMImageResourceId <String>] [-VMImageSku <String>] [-VMImageVersion <String>] [-VMInstanceCount <Int32>]
 [-VMManagedIdentityUserAssignedIdentity <String[]>] [-VMSecret <IVaultSecretGroup[]>]
 [-VMSetupAction <String[]>] [-VMSharedGalleryImageId <String>] [-VMSize <String>] [-Zone <String[]>]
 [-ZoneBalance] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzServiceFabricManagedNodeType [-Name] <String> [-ClusterName] <String> [-ResourceGroupName] <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzServiceFabricManagedNodeType [-Name] <String> [-ClusterName] <String> [-ResourceGroupName] <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityManagedClusterExpanded
```
New-AzServiceFabricManagedNodeType [-Name] <String> -ManagedClusterInputObject <IServiceFabricIdentity>
 [-AdditionalDataDisk <IVmssDataDisk[]>]
 [-AdditionalNetworkInterfaceConfiguration <IAdditionalNetworkInterfaceConfiguration[]>]
 [-ApplicationPortEndPort <Int32>] [-ApplicationPortStartPort <Int32>] [-Capacity <Hashtable>]
 [-ComputerNamePrefix <String>] [-DataDiskLetter <String>] [-DataDiskSizeGb <Int32>] [-DataDiskType <String>]
 [-DscpConfigurationId <String>] [-EnableAcceleratedNetworking] [-EnableEncryptionAtHost] [-EnableNodePublicIP]
 [-EnableNodePublicIPv6] [-EnableOverProvisioning] [-EphemeralPortEndPort <Int32>]
 [-EphemeralPortStartPort <Int32>] [-EvictionPolicy <String>]
 [-FrontendConfiguration <IFrontendConfiguration[]>] [-HostGroupId <String>] [-IsPrimary] [-IsSpotVM]
 [-IsStateless] [-MultiplePlacementGroup] [-NatConfiguration <INodeTypeNatConfig[]>] [-NatGatewayId <String>]
 [-NetworkSecurityRule <INetworkSecurityRule[]>] [-PlacementProperty <Hashtable>] [-SecureBootEnabled]
 [-SecurityEncryptionType <String>] [-SecurityType <String>] [-ServiceArtifactReferenceId <String>]
 [-SkuCapacity <Int32>] [-SkuName <String>] [-SkuTier <String>] [-SpotRestoreTimeout <String>]
 [-SubnetId <String>] [-Tag <Hashtable>] [-UseDefaultPublicLoadBalancer] [-UseEphemeralOSDisk]
 [-UseTempDataDisk] [-VMApplication <IVMApplication[]>] [-VMExtension <IVmssExtension[]>]
 [-VMImageOffer <String>] [-VMImagePlanName <String>] [-VMImagePlanProduct <String>]
 [-VMImagePlanPromotionCode <String>] [-VMImagePlanPublisher <String>] [-VMImagePublisher <String>]
 [-VMImageResourceId <String>] [-VMImageSku <String>] [-VMImageVersion <String>] [-VMInstanceCount <Int32>]
 [-VMManagedIdentityUserAssignedIdentity <String[]>] [-VMSecret <IVaultSecretGroup[]>]
 [-VMSetupAction <String[]>] [-VMSharedGalleryImageId <String>] [-VMSize <String>] [-Zone <String[]>]
 [-ZoneBalance] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a Service Fabric node type of a given managed cluster.

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

### -AdditionalDataDisk
Additional managed data disks.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.IVmssDataDisk[]
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AdditionalNetworkInterfaceConfiguration
Specifies the settings for any additional secondary network interfaces to attach to the node type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.IAdditionalNetworkInterfaceConfiguration[]
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApplicationPortEndPort
End port of a range of ports

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApplicationPortStartPort
Starting port of a range of ports

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
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

### -Capacity
The capacity tags applied to the nodes in the node type, the cluster resource manager uses these tags to understand how much resource a node has.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterName
The name of the cluster resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ComputerNamePrefix
Specifies the computer name prefix.
Limited to 9 characters.
If specified, allows for a longer name to be specified for the node type name.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataDiskLetter
Managed data disk letter.
It can not use the reserved letter C or D and it can not change after created.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataDiskSizeGb
Disk size for the managed disk attached to the vms on the node type in GBs.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataDiskType
Managed data disk type.
Specifies the storage account type for the managed disk

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
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

### -DscpConfigurationId
Specifies the resource id of the DSCP configuration to apply to the node type network interface.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableAcceleratedNetworking
Specifies whether the network interface is accelerated networking-enabled.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableEncryptionAtHost
Enable or disable the Host Encryption for the virtual machines on the node type.
This will enable the encryption for all the disks including Resource/Temp disk at host itself.
Default: The Encryption at host will be disabled unless this property is set to true for the resource.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableNodePublicIP
Specifies whether each node is allocated its own public IPv4 address.
This is only supported on secondary node types with custom Load Balancers.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableNodePublicIPv6
Specifies whether each node is allocated its own public IPv6 address.
This is only supported on secondary node types with custom Load Balancers.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableOverProvisioning
Specifies whether the node type should be overprovisioned.
It is only allowed for stateless node types.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EphemeralPortEndPort
End port of a range of ports

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EphemeralPortStartPort
Starting port of a range of ports

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EvictionPolicy
Specifies the eviction policy for virtual machines in a SPOT node type.
Default is Delete.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FrontendConfiguration
Indicates the node type uses its own frontend configurations instead of the default one for the cluster.
This setting can only be specified for non-primary node types and can not be added or removed after the node type is created.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.IFrontendConfiguration[]
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HostGroupId
Specifies the full host group resource Id.
This property is used for deploying on azure dedicated hosts.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsPrimary
Indicates the Service Fabric system services for the cluster will run on this node type.
This setting cannot be changed once the node type is created.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsSpotVM
Indicates whether the node type will be Spot Virtual Machines.
Azure will allocate the VMs if there is capacity available and the VMs can be evicted at any time.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsStateless
Indicates if the node type can only host Stateless workloads.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
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

### -ManagedClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.IServiceFabricIdentity
Parameter Sets: CreateViaIdentityManagedClusterExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MultiplePlacementGroup
Indicates if scale set associated with the node type can be composed of multiple placement groups.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the node type.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: NodeTypeName

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NatConfiguration
Specifies the NAT configuration on default public Load Balancer for the node type.
This is only supported for node types use the default public Load Balancer.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.INodeTypeNatConfig[]
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NatGatewayId
Specifies the resource id of a NAT Gateway to attach to the subnet of this node type.
Node type must use custom load balancer.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkSecurityRule
The Network Security Rules for this node type.
This setting can only be specified for node types that are configured with frontend configurations.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.INetworkSecurityRule[]
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
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

### -PlacementProperty
The placement tags applied to nodes in the node type, which can be used to indicate where certain services (workload) should run.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecureBootEnabled
Specifies whether secure boot should be enabled on the nodeType.
Can only be used with TrustedLaunch and ConfidentialVM SecurityType.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecurityEncryptionType
Specifies the EncryptionType of the managed disk.
It is set to DiskWithVMGuestState for encryption of the managed disk along with VMGuestState blob and VMGuestStateOnly for encryption of just the VMGuestState blob.
Note: It can be set for only Confidential VMs.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecurityType
Specifies the security type of the nodeType.
Supported values include Standard, TrustedLaunch and ConfidentialVM.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceArtifactReferenceId
Specifies the service artifact reference id used to set same image version for all virtual machines in the scale set when using 'latest' image version.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuCapacity
The number of nodes in the node type.
If present in request it will override properties.vmInstanceCount.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
The sku name.
Name is internally generated and is used in auto-scale scenarios.
Property does not allow to be changed to other values than generated.
To avoid deployment errors please omit the property.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuTier
Specifies the tier of the node type.
Possible Values: **Standard**

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SpotRestoreTimeout
Indicates the time duration after which the platform will not try to restore the VMSS SPOT instances specified as ISO 8601.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubnetId
Indicates the resource id of the subnet for the node type.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UseDefaultPublicLoadBalancer
Specifies whether the use public load balancer.
If not specified and the node type doesn't have its own frontend configuration, it will be attached to the default load balancer.
If the node type uses its own Load balancer and useDefaultPublicLoadBalancer is true, then the frontend has to be an Internal Load Balancer.
If the node type uses its own Load balancer and useDefaultPublicLoadBalancer is false or not set, then the custom load balancer must include a public load balancer to provide outbound connectivity.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UseEphemeralOSDisk
Indicates whether to use ephemeral os disk.
The sku selected on the vmSize property needs to support this feature.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UseTempDataDisk
Specifies whether to use the temporary disk for the service fabric data root, in which case no managed data disk will be attached and the temporary disk will be used.
It is only allowed for stateless node types.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMApplication
Specifies the gallery applications that should be made available to the underlying VMSS.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.IVMApplication[]
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMExtension
Set of extensions that should be installed onto the virtual machines.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.IVmssExtension[]
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMImageOffer
The offer type of the Azure Virtual Machines Marketplace image.
For example, UbuntuServer or WindowsServer.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMImagePlanName
The plan ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMImagePlanProduct
Specifies the product of the image from the marketplace.
This is the same value as Offer under the imageReference element.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMImagePlanPromotionCode
The promotion code.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMImagePlanPublisher
The publisher ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMImagePublisher
The publisher of the Azure Virtual Machines Marketplace image.
For example, Canonical or MicrosoftWindowsServer.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMImageResourceId
Indicates the resource id of the vm image.
This parameter is used for custom vm image.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMImageSku
The SKU of the Azure Virtual Machines Marketplace image.
For example, 14.04.0-LTS or 2012-R2-Datacenter.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMImageVersion
The version of the Azure Virtual Machines Marketplace image.
A value of 'latest' can be specified to select the latest version of an image.
If omitted, the default is 'latest'.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMInstanceCount
The number of nodes in the node type.
**Values:** -1 - Use when auto scale rules are configured or sku.capacity is defined 0 - Not supported \>0 - Use for manual scale.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMManagedIdentityUserAssignedIdentity
The list of user identities associated with the virtual machine scale set under the node type.
Each entry will be an ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMSecret
The secrets to install in the virtual machines.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.IVaultSecretGroup[]
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMSetupAction
Specifies the actions to be performed on the vms before bootstrapping the service fabric runtime.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMSharedGalleryImageId
Indicates the resource id of the vm shared galleries image.
This parameter is used for custom vm image.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMSize
The size of virtual machines in the pool.
All virtual machines in a pool are the same size.
For example, Standard_D3.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Zone
Specifies the availability zones where the node type would span across.
If the cluster is not spanning across availability zones, initiates az migration for the cluster.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ZoneBalance
Setting this to true allows stateless node types to scale out without equal distribution across zones.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.IServiceFabricIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.INodeType

## NOTES

## RELATED LINKS
