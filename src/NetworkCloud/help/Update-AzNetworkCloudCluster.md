---
external help file:
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/update-aznetworkcloudcluster
schema: 2.0.0
---

# Update-AzNetworkCloudCluster

## SYNOPSIS
Patch the properties of the provided cluster, or update the tags associated with the cluster.
Properties and tag updates can be done independently.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzNetworkCloudCluster -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AggregatorOrSingleRackDefinitionAvailabilityZone <String>]
 [-AggregatorOrSingleRackDefinitionBareMetalMachineConfiguration <IBareMetalMachineConfigurationData[]>]
 [-AggregatorOrSingleRackDefinitionNetworkRackId <String>]
 [-AggregatorOrSingleRackDefinitionRackLocation <String>]
 [-AggregatorOrSingleRackDefinitionRackSerialNumber <String>]
 [-AggregatorOrSingleRackDefinitionRackSkuId <String>]
 [-AggregatorOrSingleRackDefinitionStorageApplianceConfiguration <IStorageApplianceConfigurationData[]>]
 [-ClusterLocation <String>] [-ClusterServicePrincipalApplicationId <String>]
 [-ClusterServicePrincipalId <String>] [-ClusterServicePrincipalPassword <SecureString>]
 [-ClusterServicePrincipalTenantId <String>]
 [-ComputeDeploymentThresholdGrouping <ValidationThresholdGrouping>]
 [-ComputeDeploymentThresholdType <ValidationThresholdType>] [-ComputeDeploymentThresholdValue <Int64>]
 [-ComputeRackDefinition <IRackDefinition[]>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzNetworkCloudCluster -InputObject <INetworkCloudIdentity>
 [-AggregatorOrSingleRackDefinitionAvailabilityZone <String>]
 [-AggregatorOrSingleRackDefinitionBareMetalMachineConfiguration <IBareMetalMachineConfigurationData[]>]
 [-AggregatorOrSingleRackDefinitionNetworkRackId <String>]
 [-AggregatorOrSingleRackDefinitionRackLocation <String>]
 [-AggregatorOrSingleRackDefinitionRackSerialNumber <String>]
 [-AggregatorOrSingleRackDefinitionRackSkuId <String>]
 [-AggregatorOrSingleRackDefinitionStorageApplianceConfiguration <IStorageApplianceConfigurationData[]>]
 [-ClusterLocation <String>] [-ClusterServicePrincipalApplicationId <String>]
 [-ClusterServicePrincipalId <String>] [-ClusterServicePrincipalPassword <SecureString>]
 [-ClusterServicePrincipalTenantId <String>]
 [-ComputeDeploymentThresholdGrouping <ValidationThresholdGrouping>]
 [-ComputeDeploymentThresholdType <ValidationThresholdType>] [-ComputeDeploymentThresholdValue <Int64>]
 [-ComputeRackDefinition <IRackDefinition[]>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Patch the properties of the provided cluster, or update the tags associated with the cluster.
Properties and tag updates can be done independently.

## EXAMPLES

### Example 1: Update cluster
```powershell
$storageapplianceconfigurationdata = @()
$baremetalmachineconfigurationdata = @()
$computerackdefinition = @(@{IRackDefinition = "The list of rack definitions for the compute racks in a multi-rackcluster, or an empty list in a single-rack cluster."})
$tagHash = @{
    tag = "tag"
    tagUpdate = "tagUpdate"
}
$securePassword = ConvertTo-SecureString "password" -asplaintext -force

Update-AzNetworkCloudCluster -ResourceGroupName resourceGroup -Name clusterName -SubscriptionId subscriptionId -AggregatorOrSingleRackDefinitionNetworkRackId rackId -AggregatorOrSingleRackDefinitionRackSerialNumber sr1234 -AggregatorOrSingleRackDefinitionRackSkuId rackSku -AggregatorOrSingleRackDefinitionAvailabilityZone availabilityzone -AggregatorOrSingleRackDefinitionBareMetalMachineConfiguration $baremetalmachineconfigurationdata -AggregatorOrSingleRackDefinitionRackLocation rackLocation -AggregatorOrSingleRackDefinitionStorageApplianceConfiguration $storageapplianceconfigurationdata -ClusterServicePrincipalApplicationId clusterServicePrincipalAppId -ClusterServicePrincipalId ClusterServicePrincipalId -ClusterServicePrincipalPassword $securePassword -ClusterServicePrincipalTenantId tenantId -ComputeRackDefinition $computerackdefinition -Tag $tagHash
```

```output
Location Name             SystemDataCreatedAt SystemDataCreatedBy       SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGro
                                                                                                                                                                                           upName
-------- ----             ------------------- -------------------       ----------------------- ------------------------ ------------------------             ---------------------------- -----------
eastus   clusterName        08/09/2023 18:33:54   user                          User             08/09/2023 19:45:35           user                                       User              RGName
```

Patch the properties of the provided cluster, or update the tags associated with the cluster.
Properties and tag updates can be done independently.

## PARAMETERS

### -AggregatorOrSingleRackDefinitionAvailabilityZone
The zone name used for this rack when created.
Availability zones are used for workload placement.

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

### -AggregatorOrSingleRackDefinitionBareMetalMachineConfiguration
The unordered list of bare metal machine configuration.
To construct, see NOTES section for AGGREGATORORSINGLERACKDEFINITIONBAREMETALMACHINECONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20230701.IBareMetalMachineConfigurationData[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AggregatorOrSingleRackDefinitionNetworkRackId
The resource ID of the network rack that matches this rack definition.

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

### -AggregatorOrSingleRackDefinitionRackLocation
The free-form description of the rack's location.

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

### -AggregatorOrSingleRackDefinitionRackSerialNumber
The unique identifier for the rack within Network Cloud cluster.
An alternate unique alphanumeric value other than a serial number may be provided if desired.

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

### -AggregatorOrSingleRackDefinitionRackSkuId
The resource ID of the sku for the rack being added.

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

### -AggregatorOrSingleRackDefinitionStorageApplianceConfiguration
The list of storage appliance configuration data for this rack.
To construct, see NOTES section for AGGREGATORORSINGLERACKDEFINITIONSTORAGEAPPLIANCECONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20230701.IStorageApplianceConfigurationData[]
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

### -ClusterLocation
The customer-provided location information to identify where the cluster resides.

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

### -ClusterServicePrincipalApplicationId
The application ID, also known as client ID, of the service principal.

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

### -ClusterServicePrincipalId
The principal ID, also known as the object ID, of the service principal.

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

### -ClusterServicePrincipalPassword
The password of the service principal.

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterServicePrincipalTenantId
The tenant ID, also known as the directory ID, of the tenant in which the service principal is created.

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

### -ComputeDeploymentThresholdGrouping
Selection of how the type evaluation is applied to the cluster calculation.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.ValidationThresholdGrouping
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ComputeDeploymentThresholdType
Selection of how the threshold should be evaluated.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.ValidationThresholdType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ComputeDeploymentThresholdValue
The numeric threshold value.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ComputeRackDefinition
The list of rack definitions for the compute racks in a multi-rackcluster, or an empty list in a single-rack cluster.
To construct, see NOTES section for COMPUTERACKDEFINITION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20230701.IRackDefinition[]
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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.INetworkCloudIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the cluster.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: ClusterName

Required: True
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
The Azure resource tags that will replace the existing ones.

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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.INetworkCloudIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20230701.ICluster

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`AGGREGATORORSINGLERACKDEFINITIONBAREMETALMACHINECONFIGURATION <IBareMetalMachineConfigurationData[]>`: The unordered list of bare metal machine configuration.
  - `BmcCredentialsPassword <SecureString>`: The password of the administrator of the device used during initialization.
  - `BmcCredentialsUsername <String>`: The username of the administrator of the device used during initialization.
  - `BmcMacAddress <String>`: The MAC address of the BMC for this machine.
  - `BootMacAddress <String>`: The MAC address associated with the PXE NIC card.
  - `RackSlot <Int64>`: The slot the physical machine is in the rack based on the BOM configuration.
  - `SerialNumber <String>`: The serial number of the machine. Hardware suppliers may use an alternate value. For example, service tag.
  - `[MachineDetail <String>]`: The free-form additional information about the machine, e.g. an asset tag.
  - `[MachineName <String>]`: The user-provided name for the bare metal machine created from this specification.         If not provided, the machine name will be generated programmatically.

`AGGREGATORORSINGLERACKDEFINITIONSTORAGEAPPLIANCECONFIGURATION <IStorageApplianceConfigurationData[]>`: The list of storage appliance configuration data for this rack.
  - `AdminCredentialsPassword <SecureString>`: The password of the administrator of the device used during initialization.
  - `AdminCredentialsUsername <String>`: The username of the administrator of the device used during initialization.
  - `RackSlot <Int64>`: The slot that storage appliance is in the rack based on the BOM configuration.
  - `SerialNumber <String>`: The serial number of the appliance.
  - `[StorageApplianceName <String>]`: The user-provided name for the storage appliance that will be created from this specification.

`COMPUTERACKDEFINITION <IRackDefinition[]>`: The list of rack definitions for the compute racks in a multi-rackcluster, or an empty list in a single-rack cluster.
  - `NetworkRackId <String>`: The resource ID of the network rack that matches this rack definition.
  - `RackSerialNumber <String>`: The unique identifier for the rack within Network Cloud cluster. An alternate unique alphanumeric value other than a serial number may be provided if desired.
  - `RackSkuId <String>`: The resource ID of the sku for the rack being added.
  - `[AvailabilityZone <String>]`: The zone name used for this rack when created. Availability zones are used for workload placement.
  - `[BareMetalMachineConfigurationData <IBareMetalMachineConfigurationData[]>]`: The unordered list of bare metal machine configuration.
    - `BmcCredentialsPassword <SecureString>`: The password of the administrator of the device used during initialization.
    - `BmcCredentialsUsername <String>`: The username of the administrator of the device used during initialization.
    - `BmcMacAddress <String>`: The MAC address of the BMC for this machine.
    - `BootMacAddress <String>`: The MAC address associated with the PXE NIC card.
    - `RackSlot <Int64>`: The slot the physical machine is in the rack based on the BOM configuration.
    - `SerialNumber <String>`: The serial number of the machine. Hardware suppliers may use an alternate value. For example, service tag.
    - `[MachineDetail <String>]`: The free-form additional information about the machine, e.g. an asset tag.
    - `[MachineName <String>]`: The user-provided name for the bare metal machine created from this specification.         If not provided, the machine name will be generated programmatically.
  - `[RackLocation <String>]`: The free-form description of the rack's location.
  - `[StorageApplianceConfigurationData <IStorageApplianceConfigurationData[]>]`: The list of storage appliance configuration data for this rack.
    - `AdminCredentialsPassword <SecureString>`: The password of the administrator of the device used during initialization.
    - `AdminCredentialsUsername <String>`: The username of the administrator of the device used during initialization.
    - `RackSlot <Int64>`: The slot that storage appliance is in the rack based on the BOM configuration.
    - `SerialNumber <String>`: The serial number of the appliance.
    - `[StorageApplianceName <String>]`: The user-provided name for the storage appliance that will be created from this specification.

`INPUTOBJECT <INetworkCloudIdentity>`: Identity Parameter
  - `[AgentPoolName <String>]`: The name of the Kubernetes cluster agent pool.
  - `[BareMetalMachineKeySetName <String>]`: The name of the bare metal machine key set.
  - `[BareMetalMachineName <String>]`: The name of the bare metal machine.
  - `[BmcKeySetName <String>]`: The name of the baseboard management controller key set.
  - `[CloudServicesNetworkName <String>]`: The name of the cloud services network.
  - `[ClusterManagerName <String>]`: The name of the cluster manager.
  - `[ClusterName <String>]`: The name of the cluster.
  - `[ConsoleName <String>]`: The name of the virtual machine console.
  - `[Id <String>]`: Resource identity path
  - `[KubernetesClusterName <String>]`: The name of the Kubernetes cluster.
  - `[L2NetworkName <String>]`: The name of the L2 network.
  - `[L3NetworkName <String>]`: The name of the L3 network.
  - `[MetricsConfigurationName <String>]`: The name of the metrics configuration for the cluster.
  - `[RackName <String>]`: The name of the rack.
  - `[RackSkuName <String>]`: The name of the rack SKU.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[StorageApplianceName <String>]`: The name of the storage appliance.
  - `[SubscriptionId <String>]`: The ID of the target subscription. The value must be an UUID.
  - `[TrunkedNetworkName <String>]`: The name of the trunked network.
  - `[VirtualMachineName <String>]`: The name of the virtual machine.
  - `[VolumeName <String>]`: The name of the volume.

## RELATED LINKS

