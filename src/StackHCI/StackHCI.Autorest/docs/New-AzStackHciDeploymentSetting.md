---
external help file:
Module Name: Az.StackHCI
online version: https://learn.microsoft.com/powershell/module/az.stackhci/new-azstackhcideploymentsetting
schema: 2.0.0
---

# New-AzStackHciDeploymentSetting

## SYNOPSIS
Create a DeploymentSetting

## SYNTAX

```
New-AzStackHciDeploymentSetting -ClusterName <String> -ResourceGroupName <String> -SName <String>
 [-SubscriptionId <String>] [-ArcNodeResourceId <String[]>]
 [-DeploymentConfigurationScaleUnit <IScaleUnits[]>] [-DeploymentConfigurationVersion <String>]
 [-DeploymentMode <DeploymentMode>] [-OperationType <OperationType>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a DeploymentSetting

## EXAMPLES

### Example 1:
```powershell
New-AzStackHciDeploymentSetting -ClusterName 'test-cluster' -ResourceGroupName 'test-rg' -SName 'default'
```

```output
Name      Resource Group   SystemDataCreatedAt
----      ---------------  -------------------   ....
default   test-rg     
```

Creates a new Deployment Setting

## PARAMETERS

### -ArcNodeResourceId
Azure resource ids of Arc machines to be part of cluster.

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

### -ClusterName
The name of the cluster.

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

### -DeploymentConfigurationScaleUnit
Scale units will contains list of deployment data
To construct, see NOTES section for DEPLOYMENTCONFIGURATIONSCALEUNIT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.Api20240401.IScaleUnits[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeploymentConfigurationVersion
deployment template version

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

### -DeploymentMode
The deployment mode for cluster deployment.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Support.DeploymentMode
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

### -OperationType
The intended operation for a cluster.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Support.OperationType
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

### -SName
Name of Deployment Setting

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: DeploymentSettingsName

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

### Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.Api20240401.IDeploymentSetting

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`DEPLOYMENTCONFIGURATIONSCALEUNIT <IScaleUnits[]>`: Scale units will contains list of deployment data
  - `[ClusterAzureServiceEndpoint <String>]`: For Azure blob service endpoint type, select either Default or Custom domain. If you selected **Custom domain, enter the domain for the blob service in this format core.windows.net.
  - `[ClusterCloudAccountName <String>]`: Specify the Azure Storage account name for cloud witness for your Azure Stack HCI cluster.
  - `[ClusterName <String>]`: The cluster name provided when preparing Active Directory.
  - `[ClusterWitnessPath <String>]`: Specify the fileshare path for the local witness for your Azure Stack HCI cluster.
  - `[ClusterWitnessType <String>]`: Use a cloud witness if you have internet access and if you use an Azure Storage account to provide a vote on cluster quorum. A cloud witness uses Azure Blob Storage to read or write a blob file and then uses it to arbitrate in split-brain resolution. Only allowed values are 'Cloud', 'FileShare'. 
  - `[DeploymentDataAdouPath <String>]`: The path to the Active Directory Organizational Unit container object prepared for the deployment. 
  - `[DeploymentDataDomainFqdn <String>]`: FQDN to deploy cluster
  - `[DeploymentDataInfrastructureNetwork <IInfrastructureNetwork[]>]`: InfrastructureNetwork config to deploy AzureStackHCI Cluster.
    - `[DnsServer <String[]>]`: IPv4 address of the DNS servers in your environment.
    - `[Gateway <String>]`: Default gateway that should be used for the provided IP address space.
    - `[IPPool <IIPPools[]>]`: Range of IP addresses from which addresses are allocated for nodes within a subnet.
      - `[EndingAddress <String>]`: Ending IP address for the management network. A minimum of six free, contiguous IPv4 addresses (excluding your host IPs) are needed for infrastructure services such as clustering.
      - `[StartingAddress <String>]`: Starting IP address for the management network. A minimum of six free, contiguous IPv4 addresses (excluding your host IPs) are needed for infrastructure services such as clustering.
    - `[SubnetMask <String>]`: Subnet mask that matches the provided IP address space.
    - `[UseDhcp <Boolean?>]`: Allows customers to use DHCP for Hosts and Cluster IPs. If not declared, the deployment will default to static IPs. When true, GW and DNS servers are not required
  - `[DeploymentDataNamingPrefix <String>]`: naming prefix to deploy cluster.
  - `[DeploymentDataPhysicalNode <IPhysicalNodes[]>]`: list of physical nodes config to deploy AzureStackHCI Cluster.
    - `[Ipv4Address <String>]`: The IPv4 address assigned to each physical server on your Azure Stack HCI cluster.
    - `[Name <String>]`: NETBIOS name of each physical server on your Azure Stack HCI cluster.
  - `[DeploymentDataSecret <IEceDeploymentSecrets[]>]`: secrets used for cloud deployment.
    - `[EceSecretName <EceSecrets?>]`: Secret name expected for Enterprise Cloud Engine (ECE) deployment.
    - `[SecretLocation <String>]`: Secret URI stored in keyvault.
    - `[SecretName <String>]`: Secret name stored in keyvault.
  - `[DeploymentDataSecretsLocation <String>]`: Azure keyvault endpoint. This property is deprecated from 2023-12-01-preview. Please use secrets property instead.
  - `[HostNetworkEnableStorageAutoIP <Boolean?>]`: Optional parameter required only for 3 Nodes Switchless deployments. This allows users to specify IPs and Mask for Storage NICs when Network ATC is not assigning the IPs for storage automatically.
  - `[HostNetworkIntent <IIntents[]>]`: The network intents assigned to the network reference pattern used for the deployment. Each intent will define its own name, traffic type, adapter names, and overrides as recommended by your OEM.
    - `[Adapter <String[]>]`: Array of network interfaces used for the network intent.
    - `[AdapterPropertyOverrideJumboPacket <String>]`: This parameter should only be modified based on your OEM guidance. Do not modify this parameter without OEM validation.
    - `[AdapterPropertyOverrideNetworkDirect <String>]`: This parameter should only be modified based on your OEM guidance. Do not modify this parameter without OEM validation.
    - `[AdapterPropertyOverrideNetworkDirectTechnology <String>]`: This parameter should only be modified based on your OEM guidance. Do not modify this parameter without OEM validation. Expected values are 'iWARP', 'RoCEv2', 'RoCE'
    - `[Name <String>]`: Name of the network intent you wish to create.
    - `[OverrideAdapterProperty <Boolean?>]`: This parameter should only be modified based on your OEM guidance. Do not modify this parameter without OEM validation.
    - `[OverrideQosPolicy <Boolean?>]`: This parameter should only be modified based on your OEM guidance. Do not modify this parameter without OEM validation.
    - `[OverrideVirtualSwitchConfiguration <Boolean?>]`: This parameter should only be modified based on your OEM guidance. Do not modify this parameter without OEM validation.
    - `[QoPolicyOverrideBandwidthPercentageSmb <String>]`: This parameter should only be modified based on your OEM guidance. Do not modify this parameter without OEM validation.
    - `[QoPolicyOverridePriorityValue8021ActionCluster <String>]`: This parameter should only be modified based on your OEM guidance. Do not modify this parameter without OEM validation.
    - `[QoPolicyOverridePriorityValue8021ActionSmb <String>]`: This parameter should only be modified based on your OEM guidance. Do not modify this parameter without OEM validation.
    - `[TrafficType <String[]>]`: List of network traffic types. Only allowed values are 'Compute', 'Storage', 'Management'.
    - `[VirtualSwitchConfigurationOverrideEnableIov <String>]`: Enable IoV for Virtual Switch
    - `[VirtualSwitchConfigurationOverrideLoadBalancingAlgorithm <String>]`: Load Balancing Algorithm for Virtual Switch
  - `[HostNetworkStorageConnectivitySwitchless <Boolean?>]`: Defines how the storage adapters between nodes are connected either switch or switch less..
  - `[HostNetworkStorageNetwork <IStorageNetworks[]>]`: List of StorageNetworks config to deploy AzureStackHCI Cluster.
    - `[Name <String>]`: Name of the storage network.
    - `[NetworkAdapterName <String>]`: Name of the storage network adapter.
    - `[StorageAdapterIPInfo <IStorageAdapterIPInfo[]>]`: List of Storage adapter physical nodes config to deploy AzureStackHCI Cluster.
      - `[Ipv4Address <String>]`: The IPv4 address assigned to each storage adapter physical node on your Azure Stack HCI cluster.
      - `[PhysicalNode <String>]`: storage adapter physical node name.
      - `[SubnetMask <String>]`: The SubnetMask address assigned to each storage adapter physical node on your Azure Stack HCI cluster.
    - `[VlanId <String>]`: ID specified for the VLAN storage network. This setting is applied to the network interfaces that route the storage and VM migration traffic. 
  - `[NetworkControllerMacAddressPoolStart <String>]`: macAddressPoolStart of network controller used for SDN Integration.
  - `[NetworkControllerMacAddressPoolStop <String>]`: macAddressPoolStop of network controller used for SDN Integration.
  - `[NetworkControllerNetworkVirtualizationEnabled <Boolean?>]`: NetworkVirtualizationEnabled of network controller used for SDN Integration.
  - `[ObservabilityEpisodicDataUpload <Boolean?>]`: When set to true, collects log data to facilitate quicker issue resolution.
  - `[ObservabilityEuLocation <Boolean?>]`: Location of your cluster. The log and diagnostic data is sent to the appropriate diagnostics servers depending upon where your cluster resides. Setting this to false results in all data sent to Microsoft to be stored outside of the EU.
  - `[ObservabilityStreamingDataClient <Boolean?>]`: Enables telemetry data to be sent to Microsoft
  - `[OptionalServiceCustomLocation <String>]`: The name of custom location.
  - `[SbeDeploymentInfoFamily <String>]`: SBE family name.
  - `[SbeDeploymentInfoPublisher <String>]`: SBE manifest publisher.
  - `[SbeDeploymentInfoSbeManifestCreationDate <DateTime?>]`: SBE Manifest Creation Date.
  - `[SbeDeploymentInfoSbeManifestSource <String>]`: SBE Manifest Source.
  - `[SbeDeploymentInfoVersion <String>]`: SBE package version.
  - `[SbePartnerInfoCredentialList <ISbeCredentials[]>]`: SBE credentials list for AzureStackHCI cluster deployment.
    - `[EceSecretName <String>]`: secret name expected for Enterprise Cloud Engine (ECE).
    - `[SecretLocation <String>]`: secret URI stored in keyvault.
    - `[SecretName <String>]`: secret name stored in keyvault.
  - `[SbePartnerInfoPartnerProperty <ISbePartnerProperties[]>]`: List of SBE partner properties for AzureStackHCI cluster deployment.
    - `[Name <String>]`: SBE partner property name.
    - `[Value <String>]`: SBE partner property value.
  - `[SecuritySettingBitlockerBootVolume <Boolean?>]`: When set to true, BitLocker XTS_AES 256-bit encryption is enabled for all data-at-rest on the OS volume of your Azure Stack HCI cluster. This setting is TPM-hardware dependent. 
  - `[SecuritySettingBitlockerDataVolume <Boolean?>]`: When set to true, BitLocker XTS-AES 256-bit encryption is enabled for all data-at-rest on your Azure Stack HCI cluster shared volumes.
  - `[SecuritySettingCredentialGuardEnforced <Boolean?>]`: When set to true, Credential Guard is enabled.
  - `[SecuritySettingDriftControlEnforced <Boolean?>]`: When set to true, the security baseline is re-applied regularly.
  - `[SecuritySettingDrtmProtection <Boolean?>]`: By default, Secure Boot is enabled on your Azure HCI cluster. This setting is hardware dependent.
  - `[SecuritySettingHvciProtection <Boolean?>]`: By default, Hypervisor-protected Code Integrity is enabled on your Azure HCI cluster.
  - `[SecuritySettingSideChannelMitigationEnforced <Boolean?>]`: When set to true, all the side channel mitigations are enabled
  - `[SecuritySettingSmbClusterEncryption <Boolean?>]`: When set to true, cluster east-west traffic is encrypted.
  - `[SecuritySettingSmbSigningEnforced <Boolean?>]`: When set to true, the SMB default instance requires sign in for the client and server services.
  - `[SecuritySettingWdacEnforced <Boolean?>]`: WDAC is enabled by default and limits the applications and the code that you can run on your Azure Stack HCI cluster.
  - `[StorageConfigurationMode <String>]`: By default, this mode is set to Express and your storage is configured as per best practices based on the number of nodes in the cluster. Allowed values are 'Express','InfraOnly', 'KeepStorage'

## RELATED LINKS

