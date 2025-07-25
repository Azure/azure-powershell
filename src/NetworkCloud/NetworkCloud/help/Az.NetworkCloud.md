---
Module Name: Az.NetworkCloud
Module Guid: c1da95ce-b8cb-46c5-bb1c-80e3132dbb72
Download Help Link: https://learn.microsoft.com/powershell/module/az.networkcloud
Help Version: 1.0.0.0
Locale: en-US
---

# Az.NetworkCloud Module
## Description
Microsoft Azure PowerShell: NetworkCloud cmdlets

## Az.NetworkCloud Cmdlets
### [Deploy-AzNetworkCloudCluster](Deploy-AzNetworkCloudCluster.md)
Deploy the cluster using the rack configuration provided during creation.

### [Disable-AzNetworkCloudStorageApplianceRemoteVendorManagement](Disable-AzNetworkCloudStorageApplianceRemoteVendorManagement.md)
Disable remote vendor management of the provided storage appliance.

### [Enable-AzNetworkCloudStorageApplianceRemoteVendorManagement](Enable-AzNetworkCloudStorageApplianceRemoteVendorManagement.md)
Enable remote vendor management of the provided storage appliance.

### [Get-AzNetworkCloudAgentPool](Get-AzNetworkCloudAgentPool.md)
Get properties of the provided Kubernetes cluster agent pool.

### [Get-AzNetworkCloudBareMetalMachine](Get-AzNetworkCloudBareMetalMachine.md)
Get properties of the provided bare metal machine.

### [Get-AzNetworkCloudBareMetalMachineKeySet](Get-AzNetworkCloudBareMetalMachineKeySet.md)
Get bare metal machine key set of the provided cluster.

### [Get-AzNetworkCloudBmcKeySet](Get-AzNetworkCloudBmcKeySet.md)
Get baseboard management controller key set of the provided cluster.

### [Get-AzNetworkCloudCluster](Get-AzNetworkCloudCluster.md)
Get properties of the provided cluster.

### [Get-AzNetworkCloudClusterManager](Get-AzNetworkCloudClusterManager.md)
Get the properties of the provided cluster manager.

### [Get-AzNetworkCloudConsole](Get-AzNetworkCloudConsole.md)
Get properties of the provided virtual machine console.

### [Get-AzNetworkCloudKubernetesCluster](Get-AzNetworkCloudKubernetesCluster.md)
Get properties of the provided the Kubernetes cluster.

### [Get-AzNetworkCloudKubernetesClusterFeature](Get-AzNetworkCloudKubernetesClusterFeature.md)
Get properties of the provided the Kubernetes cluster feature.

### [Get-AzNetworkCloudL2Network](Get-AzNetworkCloudL2Network.md)
Get properties of the provided layer 2 (L2) network.

### [Get-AzNetworkCloudL3Network](Get-AzNetworkCloudL3Network.md)
Get properties of the provided layer 3 (L3) network.

### [Get-AzNetworkCloudMetricsConfiguration](Get-AzNetworkCloudMetricsConfiguration.md)
Get metrics configuration of the provided cluster.

### [Get-AzNetworkCloudRack](Get-AzNetworkCloudRack.md)
Get properties of the provided rack.

### [Get-AzNetworkCloudRackSku](Get-AzNetworkCloudRackSku.md)
Get the properties of the provided rack SKU.

### [Get-AzNetworkCloudServicesNetwork](Get-AzNetworkCloudServicesNetwork.md)
Get properties of the provided cloud services network.

### [Get-AzNetworkCloudStorageAppliance](Get-AzNetworkCloudStorageAppliance.md)
Get properties of the provided storage appliance.

### [Get-AzNetworkCloudTrunkedNetwork](Get-AzNetworkCloudTrunkedNetwork.md)
Get properties of the provided trunked network.

### [Get-AzNetworkCloudVirtualMachine](Get-AzNetworkCloudVirtualMachine.md)
Get properties of the provided virtual machine.

### [Get-AzNetworkCloudVolume](Get-AzNetworkCloudVolume.md)
Get properties of the provided volume.

### [Invoke-AzNetworkCloudBareMetalMachineCordon](Invoke-AzNetworkCloudBareMetalMachineCordon.md)
Cordon the provided bare metal machine's Kubernetes node.

### [Invoke-AzNetworkCloudBareMetalMachineDataExtract](Invoke-AzNetworkCloudBareMetalMachineDataExtract.md)
Run one or more data extractions on the provided bare metal machine.
The URL to storage account with the command execution results and the command exit code can be retrieved from the operation status API once available.

### [Invoke-AzNetworkCloudBareMetalMachineReimage](Invoke-AzNetworkCloudBareMetalMachineReimage.md)
Reimage the provided bare metal machine.

### [Invoke-AzNetworkCloudBareMetalMachineReplace](Invoke-AzNetworkCloudBareMetalMachineReplace.md)
Replace the provided bare metal machine.

### [Invoke-AzNetworkCloudBareMetalMachineRunCommand](Invoke-AzNetworkCloudBareMetalMachineRunCommand.md)
Run the command or the script on the provided bare metal machine.
The URL to storage account with the command execution results and the command exit code can be retrieved from the operation status API once available.

### [Invoke-AzNetworkCloudBareMetalMachineRunReadCommand](Invoke-AzNetworkCloudBareMetalMachineRunReadCommand.md)
Run one or more read-only commands on the provided bare metal machine.
The URL to storage account with the command execution results and the command exit code can be retrieved from the operation status API once available.

### [Invoke-AzNetworkCloudBareMetalMachineUncordon](Invoke-AzNetworkCloudBareMetalMachineUncordon.md)
Uncordon the provided bare metal machine's Kubernetes node.

### [Invoke-AzNetworkCloudClusterContinueVersionUpdate](Invoke-AzNetworkCloudClusterContinueVersionUpdate.md)
Trigger the continuation of an update for a cluster with a matching update strategy that has paused after completing a segment of the update.

### [Invoke-AzNetworkCloudClusterVersionUpdate](Invoke-AzNetworkCloudClusterVersionUpdate.md)
Update the version of the provided cluster to one of the available supported versions.

### [Invoke-AzNetworkCloudScanClusterRuntime](Invoke-AzNetworkCloudScanClusterRuntime.md)
Triggers the execution of a runtime protection scan to detect and remediate detected issues, in accordance with the cluster configuration.

### [Invoke-AzNetworkCloudVirtualMachineReimage](Invoke-AzNetworkCloudVirtualMachineReimage.md)
Reimage the provided virtual machine.

### [New-AzNetworkCloudAgentPool](New-AzNetworkCloudAgentPool.md)
Create a new Kubernetes cluster agent pool or update the properties of the existing one.

### [New-AzNetworkCloudBareMetalMachineConfigurationDataObject](New-AzNetworkCloudBareMetalMachineConfigurationDataObject.md)
Create an in-memory object for BareMetalMachineConfigurationData.

### [New-AzNetworkCloudBareMetalMachineKeySet](New-AzNetworkCloudBareMetalMachineKeySet.md)
Create a new bare metal machine key set or update the existing one for the provided cluster.

### [New-AzNetworkCloudBgpAdvertisementObject](New-AzNetworkCloudBgpAdvertisementObject.md)
Create an in-memory object for BgpAdvertisement.

### [New-AzNetworkCloudBgpServiceLoadBalancerConfigurationObject](New-AzNetworkCloudBgpServiceLoadBalancerConfigurationObject.md)
Create an in-memory object for BgpServiceLoadBalancerConfiguration.

### [New-AzNetworkCloudBmcKeySet](New-AzNetworkCloudBmcKeySet.md)
Create a new baseboard management controller key set or update the existing one for the provided cluster.

### [New-AzNetworkCloudCluster](New-AzNetworkCloudCluster.md)
Create a new cluster or update the properties of the cluster if it exists.

### [New-AzNetworkCloudClusterManager](New-AzNetworkCloudClusterManager.md)
Create a new cluster manager or update properties of the cluster manager if it exists.

### [New-AzNetworkCloudConsole](New-AzNetworkCloudConsole.md)
Create a new virtual machine console or update the properties of the existing virtual machine console.

### [New-AzNetworkCloudControlPlaneNodeConfigurationObject](New-AzNetworkCloudControlPlaneNodeConfigurationObject.md)
Create an in-memory object for ControlPlaneNodeConfiguration.

### [New-AzNetworkCloudEgressEndpointObject](New-AzNetworkCloudEgressEndpointObject.md)
Create an in-memory object for EgressEndpoint.

### [New-AzNetworkCloudEndpointDependencyObject](New-AzNetworkCloudEndpointDependencyObject.md)
Create an in-memory object for EndpointDependency.

### [New-AzNetworkCloudInitialAgentPoolConfigurationObject](New-AzNetworkCloudInitialAgentPoolConfigurationObject.md)
Create an in-memory object for InitialAgentPoolConfiguration.

### [New-AzNetworkCloudIpAddressPoolObject](New-AzNetworkCloudIpAddressPoolObject.md)
Create an in-memory object for IpAddressPool.

### [New-AzNetworkCloudKeySetUserObject](New-AzNetworkCloudKeySetUserObject.md)
Create an in-memory object for KeySetUser.

### [New-AzNetworkCloudKubernetesCluster](New-AzNetworkCloudKubernetesCluster.md)
Create a new Kubernetes cluster or update the properties of the existing one.

### [New-AzNetworkCloudKubernetesClusterFeature](New-AzNetworkCloudKubernetesClusterFeature.md)
Create a new Kubernetes cluster feature or update properties of the Kubernetes cluster feature if it exists.

### [New-AzNetworkCloudL2Network](New-AzNetworkCloudL2Network.md)
Create a new layer 2 (L2) network or update the properties of the existing network.

### [New-AzNetworkCloudL3Network](New-AzNetworkCloudL3Network.md)
Create a new layer 3 (L3) network or update the properties of the existing network.

### [New-AzNetworkCloudL3NetworkAttachmentConfigurationObject](New-AzNetworkCloudL3NetworkAttachmentConfigurationObject.md)
Create an in-memory object for L3NetworkAttachmentConfiguration.

### [New-AzNetworkCloudMetricsConfiguration](New-AzNetworkCloudMetricsConfiguration.md)
Create new or update the existing metrics configuration of the provided cluster.

### [New-AzNetworkCloudNetworkAttachmentObject](New-AzNetworkCloudNetworkAttachmentObject.md)
Create an in-memory object for NetworkAttachment.

### [New-AzNetworkCloudRackDefinitionObject](New-AzNetworkCloudRackDefinitionObject.md)
Create an in-memory object for RackDefinition.

### [New-AzNetworkCloudServiceLoadBalancerBgpPeerObject](New-AzNetworkCloudServiceLoadBalancerBgpPeerObject.md)
Create an in-memory object for ServiceLoadBalancerBgpPeer.

### [New-AzNetworkCloudServicesNetwork](New-AzNetworkCloudServicesNetwork.md)
Create a new cloud services network or update the properties of the existing cloud services network.

### [New-AzNetworkCloudStorageApplianceConfigurationDataObject](New-AzNetworkCloudStorageApplianceConfigurationDataObject.md)
Create an in-memory object for StorageApplianceConfigurationData.

### [New-AzNetworkCloudTrunkedNetwork](New-AzNetworkCloudTrunkedNetwork.md)
Create a new trunked network or update the properties of the existing trunked network.

### [New-AzNetworkCloudVirtualMachine](New-AzNetworkCloudVirtualMachine.md)
Create a new virtual machine or update the properties of the existing virtual machine.

### [New-AzNetworkCloudVirtualMachinePlacementHintObject](New-AzNetworkCloudVirtualMachinePlacementHintObject.md)
Create an in-memory object for VirtualMachinePlacementHint.

### [New-AzNetworkCloudVolume](New-AzNetworkCloudVolume.md)
Create a new volume or update the properties of the existing one.

### [Remove-AzNetworkCloudAgentPool](Remove-AzNetworkCloudAgentPool.md)
Delete the provided Kubernetes cluster agent pool.

### [Remove-AzNetworkCloudBareMetalMachineKeySet](Remove-AzNetworkCloudBareMetalMachineKeySet.md)
Delete the bare metal machine key set of the provided cluster.

### [Remove-AzNetworkCloudBmcKeySet](Remove-AzNetworkCloudBmcKeySet.md)
Delete the baseboard management controller key set of the provided cluster.

### [Remove-AzNetworkCloudCluster](Remove-AzNetworkCloudCluster.md)
Delete the provided cluster.

### [Remove-AzNetworkCloudClusterManager](Remove-AzNetworkCloudClusterManager.md)
Delete the provided cluster manager.

### [Remove-AzNetworkCloudConsole](Remove-AzNetworkCloudConsole.md)
Delete the provided virtual machine console.

### [Remove-AzNetworkCloudKubernetesCluster](Remove-AzNetworkCloudKubernetesCluster.md)
Delete the provided Kubernetes cluster.

### [Remove-AzNetworkCloudKubernetesClusterFeature](Remove-AzNetworkCloudKubernetesClusterFeature.md)
Delete the provided Kubernetes cluster feature.

### [Remove-AzNetworkCloudL2Network](Remove-AzNetworkCloudL2Network.md)
Delete the provided layer 2 (L2) network.

### [Remove-AzNetworkCloudL3Network](Remove-AzNetworkCloudL3Network.md)
Delete the provided layer 3 (L3) network.

### [Remove-AzNetworkCloudMetricsConfiguration](Remove-AzNetworkCloudMetricsConfiguration.md)
Delete the metrics configuration of the provided cluster.

### [Remove-AzNetworkCloudServicesNetwork](Remove-AzNetworkCloudServicesNetwork.md)
Delete the provided cloud services network.

### [Remove-AzNetworkCloudTrunkedNetwork](Remove-AzNetworkCloudTrunkedNetwork.md)
Delete the provided trunked network.

### [Remove-AzNetworkCloudVirtualMachine](Remove-AzNetworkCloudVirtualMachine.md)
Delete the provided virtual machine.

### [Remove-AzNetworkCloudVolume](Remove-AzNetworkCloudVolume.md)
Delete the provided volume.

### [Restart-AzNetworkCloudBareMetalMachine](Restart-AzNetworkCloudBareMetalMachine.md)
Restart the provided bare metal machine.

### [Restart-AzNetworkCloudKubernetesClusterNode](Restart-AzNetworkCloudKubernetesClusterNode.md)
Restart a targeted node of a Kubernetes cluster.

### [Restart-AzNetworkCloudVirtualMachine](Restart-AzNetworkCloudVirtualMachine.md)
Restart the provided virtual machine.

### [Start-AzNetworkCloudBareMetalMachine](Start-AzNetworkCloudBareMetalMachine.md)
Start the provided bare metal machine.

### [Start-AzNetworkCloudVirtualMachine](Start-AzNetworkCloudVirtualMachine.md)
Start the provided virtual machine.

### [Stop-AzNetworkCloudBareMetalMachine](Stop-AzNetworkCloudBareMetalMachine.md)
Power off the provided bare metal machine.

### [Stop-AzNetworkCloudVirtualMachine](Stop-AzNetworkCloudVirtualMachine.md)
Power off the provided virtual machine.

### [Update-AzNetworkCloudAgentPool](Update-AzNetworkCloudAgentPool.md)
Patch the properties of the provided Kubernetes cluster agent pool, or update the tags associated with the Kubernetes cluster agent pool.
Properties and tag updates can be done independently.

### [Update-AzNetworkCloudBareMetalMachine](Update-AzNetworkCloudBareMetalMachine.md)
Patch properties of the provided bare metal machine, or update tags associated with the bare metal machine.
Properties and tag updates can be done independently.

### [Update-AzNetworkCloudBareMetalMachineKeySet](Update-AzNetworkCloudBareMetalMachineKeySet.md)
Patch properties of bare metal machine key set for the provided cluster, or update the tags associated with it.
Properties and tag updates can be done independently.

### [Update-AzNetworkCloudBmcKeySet](Update-AzNetworkCloudBmcKeySet.md)
Patch properties of baseboard management controller key set for the provided cluster, or update the tags associated with it.
Properties and tag updates can be done independently.

### [Update-AzNetworkCloudCluster](Update-AzNetworkCloudCluster.md)
Patch the properties of the provided cluster, or update the tags associated with the cluster.
Properties and tag updates can be done independently.

### [Update-AzNetworkCloudClusterManager](Update-AzNetworkCloudClusterManager.md)
Patch properties of the provided cluster manager, or update the tags assigned to the cluster manager.
Properties and tag updates can be done independently.

### [Update-AzNetworkCloudConsole](Update-AzNetworkCloudConsole.md)
Patch the properties of the provided virtual machine console, or update the tags associated with the virtual machine console.
Properties and tag updates can be done independently.

### [Update-AzNetworkCloudKubernetesCluster](Update-AzNetworkCloudKubernetesCluster.md)
Patch the properties of the provided Kubernetes cluster, or update the tags associated with the Kubernetes cluster.
Properties and tag updates can be done independently.

### [Update-AzNetworkCloudKubernetesClusterFeature](Update-AzNetworkCloudKubernetesClusterFeature.md)
Patch properties of the provided Kubernetes cluster feature.

### [Update-AzNetworkCloudL2Network](Update-AzNetworkCloudL2Network.md)
Update tags associated with the provided layer 2 (L2) network.

### [Update-AzNetworkCloudL3Network](Update-AzNetworkCloudL3Network.md)
Update tags associated with the provided layer 3 (L3) network.

### [Update-AzNetworkCloudMetricsConfiguration](Update-AzNetworkCloudMetricsConfiguration.md)
Patch properties of metrics configuration for the provided cluster, or update the tags associated with it.
Properties and tag updates can be done independently.

### [Update-AzNetworkCloudRack](Update-AzNetworkCloudRack.md)
Patch properties of the provided rack, or update the tags associated with the rack.
Properties and tag updates can be done independently.

### [Update-AzNetworkCloudServicesNetwork](Update-AzNetworkCloudServicesNetwork.md)
Update properties of the provided cloud services network, or update the tags associated with it.
Properties and tag updates can be done independently.

### [Update-AzNetworkCloudStorageAppliance](Update-AzNetworkCloudStorageAppliance.md)
Update properties of the provided storage appliance, or update tags associated with the storage appliance Properties and tag updates can be done independently.

### [Update-AzNetworkCloudTrunkedNetwork](Update-AzNetworkCloudTrunkedNetwork.md)
Update tags associated with the provided trunked network.

### [Update-AzNetworkCloudVirtualMachine](Update-AzNetworkCloudVirtualMachine.md)
Patch the properties of the provided virtual machine, or update the tags associated with the virtual machine.
Properties and tag updates can be done independently.

### [Update-AzNetworkCloudVolume](Update-AzNetworkCloudVolume.md)
Update tags associated with the provided volume.

