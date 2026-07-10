---
Module Name: Az.ManagedNetworkFabric
Module Guid: 95e96bd7-4548-4973-a345-3f982b13f681
Download Help Link: https://learn.microsoft.com/powershell/module/az.managednetworkfabric
Help Version: 1.0.0.0
Locale: en-US
---

# Az.ManagedNetworkFabric Module
## Description
Microsoft Azure PowerShell: ManagedNetworkFabric cmdlets

## Az.ManagedNetworkFabric Cmdlets
### [Get-AzNetworkFabric](Get-AzNetworkFabric.md)
Get Network Fabric resource details.

### [Get-AzNetworkFabricAcl](Get-AzNetworkFabricAcl.md)
Implements Access Control List GET method.

### [Get-AzNetworkFabricController](Get-AzNetworkFabricController.md)
Shows the provisioning status of Network Fabric Controller.

### [Get-AzNetworkFabricDevice](Get-AzNetworkFabricDevice.md)
Gets the Network Device resource details.

### [Get-AzNetworkFabricExternalNetwork](Get-AzNetworkFabricExternalNetwork.md)
Implements ExternalNetworks GET method.

### [Get-AzNetworkFabricInterface](Get-AzNetworkFabricInterface.md)
Get the Network Interface resource details.

### [Get-AzNetworkFabricInternalNetwork](Get-AzNetworkFabricInternalNetwork.md)
Gets a InternalNetworks.

### [Get-AzNetworkFabricInternetGateway](Get-AzNetworkFabricInternetGateway.md)
Implements Gateway GET method.

### [Get-AzNetworkFabricInternetGatewayRule](Get-AzNetworkFabricInternetGatewayRule.md)
Gets an Internet Gateway Rule resource.

### [Get-AzNetworkFabricIPCommunity](Get-AzNetworkFabricIPCommunity.md)
Implements an IP Community GET method.

### [Get-AzNetworkFabricIPExtendedCommunity](Get-AzNetworkFabricIPExtendedCommunity.md)
Implements IP Extended Community GET method.

### [Get-AzNetworkFabricIPPrefix](Get-AzNetworkFabricIPPrefix.md)
Implements IP Prefix GET method.

### [Get-AzNetworkFabricL2Domain](Get-AzNetworkFabricL2Domain.md)
Implements L2 Isolation Domain GET method.

### [Get-AzNetworkFabricL3Domain](Get-AzNetworkFabricL3Domain.md)
Retrieves details of this L3 Isolation Domain.

### [Get-AzNetworkFabricNeighborGroup](Get-AzNetworkFabricNeighborGroup.md)
Gets the Neighbor Group.

### [Get-AzNetworkFabricNetworkBootstrapDevice](Get-AzNetworkFabricNetworkBootstrapDevice.md)
Gets a Network Bootstrap Device resource details.

### [Get-AzNetworkFabricNetworkBootstrapInterface](Get-AzNetworkFabricNetworkBootstrapInterface.md)
Get the Network Bootstrap Interface resource details.

### [Get-AzNetworkFabricNni](Get-AzNetworkFabricNni.md)
Implements NetworkToNetworkInterconnects GET method.

### [Get-AzNetworkFabricNpb](Get-AzNetworkFabricNpb.md)
Retrieves details of this Network Packet Broker.

### [Get-AzNetworkFabricRack](Get-AzNetworkFabricRack.md)
Get Network Rack resource details.

### [Get-AzNetworkFabricRoutePolicy](Get-AzNetworkFabricRoutePolicy.md)
Implements Route Policy GET method.

### [Get-AzNetworkFabricTap](Get-AzNetworkFabricTap.md)
Retrieves details of this Network Tap.

### [Get-AzNetworkFabricTapRule](Get-AzNetworkFabricTapRule.md)
Get Network Tap Rule resource details.

### [Invoke-AzNetworkFabricArmConfigurationDiff](Invoke-AzNetworkFabricArmConfigurationDiff.md)
Post action: Triggers diff of NetworkFabric ARM Configuration.

### [Invoke-AzNetworkFabricCommitBatchStatus](Invoke-AzNetworkFabricCommitBatchStatus.md)
Post action: Returns a status of commit batch operation.

### [Invoke-AzNetworkFabricCommitConfiguration](Invoke-AzNetworkFabricCommitConfiguration.md)
Atomic commit of the given Network Fabric instance.
Sync commit of NFA resources at Fabric level.

### [Invoke-AzNetworkFabricDeprovision](Invoke-AzNetworkFabricDeprovision.md)
Deprovisions the underlying resources in the given Network Fabric instance.

### [Invoke-AzNetworkFabricDeviceConfiguration](Invoke-AzNetworkFabricDeviceConfiguration.md)
Post action: Triggers view of network fabric configuration.

### [Invoke-AzNetworkFabricDeviceUpgrade](Invoke-AzNetworkFabricDeviceUpgrade.md)
Upgrades the version of the Network Device.

### [Invoke-AzNetworkFabricExternalNetworkAdministrativeState](Invoke-AzNetworkFabricExternalNetworkAdministrativeState.md)
Executes update operation to enable or disable administrative State for externalNetwork.

### [Invoke-AzNetworkFabricExternalNetworkBfdAdministrativeState](Invoke-AzNetworkFabricExternalNetworkBfdAdministrativeState.md)
BFD administrative state for either static or bgp for internalNetwork.

### [Invoke-AzNetworkFabricInterfaceUpdateAdminState](Invoke-AzNetworkFabricInterfaceUpdateAdminState.md)
Update the admin state of the Network Interface.

### [Invoke-AzNetworkFabricL2DomainUpdateAdminState](Invoke-AzNetworkFabricL2DomainUpdateAdminState.md)
Enables isolation domain across the fabric or on specified racks.

### [Invoke-AzNetworkFabricL3DomainUpdateAdminState](Invoke-AzNetworkFabricL3DomainUpdateAdminState.md)
Update the administrative state of the L3 Isolation Domain resource.

### [Invoke-AzNetworkFabricNniBfdAdministrativeState](Invoke-AzNetworkFabricNniBfdAdministrativeState.md)
Update the Admin State.

### [Invoke-AzNetworkFabricProvision](Invoke-AzNetworkFabricProvision.md)
Provisions the underlying resources in the given Network Fabric instance.

### [Invoke-AzNetworkFabricResyncNeighborGroup](Invoke-AzNetworkFabricResyncNeighborGroup.md)
Resync the Neighbor Group after a configuration change.

### [Invoke-AzNetworkFabricResyncNetworkBootstrapDevicePassword](Invoke-AzNetworkFabricResyncNetworkBootstrapDevicePassword.md)
Resync the Network Bootstrap Device to use the latest passwords.
Does not generate new passwords.
Allows network bootstrap devices missed during a previous password rotation to be brought back into sync.

### [Invoke-AzNetworkFabricResyncNetworkDeviceCertificate](Invoke-AzNetworkFabricResyncNetworkDeviceCertificate.md)
Resync the Network Device to use the latest certificates.
Does not generate new certificates.
Allows network devices missed during a previous certificate rotation to be brought back into sync.

### [Invoke-AzNetworkFabricResyncNetworkDevicePassword](Invoke-AzNetworkFabricResyncNetworkDevicePassword.md)
Resync the Network Device to use the latest passwords.
Does not generate new passwords.
Allows network devices missed during a previous password rotation to be brought back into sync.

### [Invoke-AzNetworkFabricResyncNetworkFabricCertificate](Invoke-AzNetworkFabricResyncNetworkFabricCertificate.md)
Resync all Network Devices to use the latest certificates.
Does not generate new certificates.
Allows network devices missed during a previous certificate rotation to be brought back into sync.

### [Invoke-AzNetworkFabricResyncNetworkFabricPassword](Invoke-AzNetworkFabricResyncNetworkFabricPassword.md)
Resync the Terminal Server and all Network Devices to use the latest passwords.
Does not generate new passwords.\n\nAllows devices to be brought back in sync after a partially successful password rotation.

### [Invoke-AzNetworkFabricRotateNetworkFabricCertificate](Invoke-AzNetworkFabricRotateNetworkFabricCertificate.md)
Rotate new certificates, then rotate the Network Devices to use the new certificates.
Note that disabled devices cannot be updated and must be resynchronized with the new certificates once they are enabled.

### [Invoke-AzNetworkFabricRotateNetworkFabricPassword](Invoke-AzNetworkFabricRotateNetworkFabricPassword.md)
Rotate new passwords, then rotate the Terminal Server and Network Devices to use the new passwords.\n\nNote that disabled devices cannot be updated and must be resynchronized with the new passwords once they are enabled.\n\nFails if any of the devices could not be updated with the new password.\nFailed devices should be resynchronized with the new passwords once possible.

### [Invoke-AzNetworkFabricTapUpdateAdminState](Invoke-AzNetworkFabricTapUpdateAdminState.md)
Implements the operation to the underlying resources.

### [Lock-AzNetworkFabric](Lock-AzNetworkFabric.md)
Post action: Triggers network fabric lock operation.

### [New-AzNetworkFabric](New-AzNetworkFabric.md)
Create Network Fabric resource.

### [New-AzNetworkFabricAcl](New-AzNetworkFabricAcl.md)
Implements Access Control List PUT method.

### [New-AzNetworkFabricController](New-AzNetworkFabricController.md)
Create a Network Fabric Controller.

### [New-AzNetworkFabricExternalNetwork](New-AzNetworkFabricExternalNetwork.md)
Create ExternalNetwork PUT method.

### [New-AzNetworkFabricInternalNetwork](New-AzNetworkFabricInternalNetwork.md)
Create InternalNetwork PUT method.

### [New-AzNetworkFabricInternetGatewayRule](New-AzNetworkFabricInternetGatewayRule.md)
Create an Internet Gateway rule resource.

### [New-AzNetworkFabricIPCommunity](New-AzNetworkFabricIPCommunity.md)
Implements an IP Community PUT method.

### [New-AzNetworkFabricIPExtendedCommunity](New-AzNetworkFabricIPExtendedCommunity.md)
Implements IP Extended Community PUT method.

### [New-AzNetworkFabricIPPrefix](New-AzNetworkFabricIPPrefix.md)
Implements IP Prefix PUT method.

### [New-AzNetworkFabricL2Domain](New-AzNetworkFabricL2Domain.md)
Create layer 2 network connectivity between compute nodes within a rack and across racks.The configuration is applied on the devices only after the isolation domain is enabled.

### [New-AzNetworkFabricL3Domain](New-AzNetworkFabricL3Domain.md)
Create isolation domain resources for layer 3 connectivity between compute nodes and for communication with external services .This configuration is applied on the devices only after the creation of networks is completed and isolation domain is enabled.

### [New-AzNetworkFabricNeighborGroup](New-AzNetworkFabricNeighborGroup.md)
Implements the Neighbor Group PUT method.

### [New-AzNetworkFabricNetworkBootstrapDevice](New-AzNetworkFabricNetworkBootstrapDevice.md)
Create a Network Bootstrap Device resource

### [New-AzNetworkFabricNetworkBootstrapInterface](New-AzNetworkFabricNetworkBootstrapInterface.md)
Create a Network Bootstrap Interface resource.

### [New-AzNetworkFabricNni](New-AzNetworkFabricNni.md)
Configuration used to setup CE-PE connectivity PUT Method.

### [New-AzNetworkFabricRoutePolicy](New-AzNetworkFabricRoutePolicy.md)
Implements Route Policy PUT method.

### [New-AzNetworkFabricTap](New-AzNetworkFabricTap.md)
Create a Network Tap.

### [New-AzNetworkFabricTapRule](New-AzNetworkFabricTapRule.md)
Create Network Tap Rule resource.

### [Remove-AzNetworkFabric](Remove-AzNetworkFabric.md)
Delete Network Fabric resource.

### [Remove-AzNetworkFabricAcl](Remove-AzNetworkFabricAcl.md)
Implements Access Control List DELETE method.

### [Remove-AzNetworkFabricCommitBatch](Remove-AzNetworkFabricCommitBatch.md)
Post action: Discards a Batch operation in progress.

### [Remove-AzNetworkFabricController](Remove-AzNetworkFabricController.md)
Deletes the Network Fabric Controller resource.

### [Remove-AzNetworkFabricExternalNetwork](Remove-AzNetworkFabricExternalNetwork.md)
Implements ExternalNetworks DELETE method.

### [Remove-AzNetworkFabricInternalNetwork](Remove-AzNetworkFabricInternalNetwork.md)
Implements InternalNetworks DELETE method.

### [Remove-AzNetworkFabricInternetGatewayRule](Remove-AzNetworkFabricInternetGatewayRule.md)
Implements Internet Gateway Rules DELETE method.

### [Remove-AzNetworkFabricIPCommunity](Remove-AzNetworkFabricIPCommunity.md)
Implements IP Community DELETE method.

### [Remove-AzNetworkFabricIPExtendedCommunity](Remove-AzNetworkFabricIPExtendedCommunity.md)
Implements IP Extended Community DELETE method.

### [Remove-AzNetworkFabricIPPrefix](Remove-AzNetworkFabricIPPrefix.md)
Implements IP Prefix DELETE method.

### [Remove-AzNetworkFabricL2Domain](Remove-AzNetworkFabricL2Domain.md)
Deletes layer 2 connectivity between compute nodes by managed by named L2 Isolation name.

### [Remove-AzNetworkFabricL3Domain](Remove-AzNetworkFabricL3Domain.md)
Deletes layer 3 connectivity between compute nodes by managed by named L3 Isolation name.

### [Remove-AzNetworkFabricNeighborGroup](Remove-AzNetworkFabricNeighborGroup.md)
Implements Neighbor Group DELETE method.

### [Remove-AzNetworkFabricNetworkBootstrapDevice](Remove-AzNetworkFabricNetworkBootstrapDevice.md)
Deletes a Network Bootstrap Device resource.

### [Remove-AzNetworkFabricNetworkBootstrapInterface](Remove-AzNetworkFabricNetworkBootstrapInterface.md)
Delete the Network Bootstrap Interface resource.

### [Remove-AzNetworkFabricNni](Remove-AzNetworkFabricNni.md)
Implements NetworkToNetworkInterconnects DELETE method.

### [Remove-AzNetworkFabricRoutePolicy](Remove-AzNetworkFabricRoutePolicy.md)
Implements Route Policy DELETE method.

### [Remove-AzNetworkFabricTap](Remove-AzNetworkFabricTap.md)
Deletes Network Tap.

### [Remove-AzNetworkFabricTapRule](Remove-AzNetworkFabricTapRule.md)
Delete Network Tap Rule resource.

### [Restart-AzNetworkFabricDevice](Restart-AzNetworkFabricDevice.md)
Reboot the Network Device.

### [Restart-AzNetworkFabricNetworkBootstrapDevice](Restart-AzNetworkFabricNetworkBootstrapDevice.md)
Reboot the Network Bootstrap Device.

### [Start-AzNetworkFabricNetworkDeviceRoCommand](Start-AzNetworkFabricNetworkDeviceRoCommand.md)
Run the RO Command on the Network Device.

### [Start-AzNetworkFabricNetworkDeviceRwCommand](Start-AzNetworkFabricNetworkDeviceRwCommand.md)
Run the RW Command on the Network Device.

### [Update-AzNetworkFabric](Update-AzNetworkFabric.md)
Update Network Fabric resource.

### [Update-AzNetworkFabricAccessControlList](Update-AzNetworkFabricAccessControlList.md)
API to update certain properties of the Access Control List resource.

### [Update-AzNetworkFabricController](Update-AzNetworkFabricController.md)
Update a Network Fabric Controller.

### [Update-AzNetworkFabricDevice](Update-AzNetworkFabricDevice.md)
Update a Network Device resource

### [Update-AzNetworkFabricExternalNetwork](Update-AzNetworkFabricExternalNetwork.md)
API to update certain properties of the ExternalNetworks resource.

### [Update-AzNetworkFabricExternalNetworkStaticRouteBfdAdministrativeState](Update-AzNetworkFabricExternalNetworkStaticRouteBfdAdministrativeState.md)
Update Static Route BFD for external Network.

### [Update-AzNetworkFabricInternalNetwork](Update-AzNetworkFabricInternalNetwork.md)
Update a InternalNetworks.

### [Update-AzNetworkFabricInternalNetworkStaticRouteBfdAdministrativeState](Update-AzNetworkFabricInternalNetworkStaticRouteBfdAdministrativeState.md)
Update Static Route BFD administrative state for internalNetwork.

### [Update-AzNetworkFabricInternetGateway](Update-AzNetworkFabricInternetGateway.md)
Execute patch on Network Fabric Service Internet Gateway.

### [Update-AzNetworkFabricInternetGatewayRule](Update-AzNetworkFabricInternetGatewayRule.md)
API to update certain properties of the Internet Gateway Rule resource.

### [Update-AzNetworkFabricIPCommunity](Update-AzNetworkFabricIPCommunity.md)
API to update certain properties of the IP Community resource.

### [Update-AzNetworkFabricIPExtendedCommunity](Update-AzNetworkFabricIPExtendedCommunity.md)
API to update certain properties of the IP Extended Community resource.

### [Update-AzNetworkFabricIPPrefix](Update-AzNetworkFabricIPPrefix.md)
API to update certain properties of the IP Prefix resource.

### [Update-AzNetworkFabricL2IsolationDomain](Update-AzNetworkFabricL2IsolationDomain.md)
Update layer 2 network connectivity between compute nodes within a rack and across racks.The configuration is applied on the devices only after the isolation domain is enabled.

### [Update-AzNetworkFabricL3IsolationDomain](Update-AzNetworkFabricL3IsolationDomain.md)
Update isolation domain resources for layer 3 connectivity between compute nodes and for communication with external services .This configuration is applied on the devices only after the creation of networks is completed and isolation domain is enabled.

### [Update-AzNetworkFabricNeighborGroup](Update-AzNetworkFabricNeighborGroup.md)
Implements the Neighbor Group PUT method.

### [Update-AzNetworkFabricNetworkBootstrapDevice](Update-AzNetworkFabricNetworkBootstrapDevice.md)
Update a Network Bootstrap Device resource

### [Update-AzNetworkFabricNetworkBootstrapDeviceAdministrativeState](Update-AzNetworkFabricNetworkBootstrapDeviceAdministrativeState.md)
Update the Administrative state of the Network Bootstrap Device.

### [Update-AzNetworkFabricNetworkBootstrapDeviceConfiguration](Update-AzNetworkFabricNetworkBootstrapDeviceConfiguration.md)
Refreshes the configuration of Network Bootstrap Device.

### [Update-AzNetworkFabricNetworkBootstrapInterface](Update-AzNetworkFabricNetworkBootstrapInterface.md)
Update certain properties of the Network Bootstrap Interface resource.

### [Update-AzNetworkFabricNetworkBootstrapInterfaceAdministrativeState](Update-AzNetworkFabricNetworkBootstrapInterfaceAdministrativeState.md)
Update the admin state of the Network Interface.

### [Update-AzNetworkFabricNetworkDeviceAdministrativeState](Update-AzNetworkFabricNetworkDeviceAdministrativeState.md)
Update the Administrative state of the Network Device.

### [Update-AzNetworkFabricNetworkTap](Update-AzNetworkFabricNetworkTap.md)
Update a Network Tap.

### [Update-AzNetworkFabricNetworkTapRule](Update-AzNetworkFabricNetworkTapRule.md)
Update Network Tap Rule resource.

### [Update-AzNetworkFabricNetworkToNetworkInterconnectNpbStaticRouteBfdAdministrativeState](Update-AzNetworkFabricNetworkToNetworkInterconnectNpbStaticRouteBfdAdministrativeState.md)
Update the NPB Static Route BFD Administrative State.

### [Update-AzNetworkFabricRoutePolicy](Update-AzNetworkFabricRoutePolicy.md)
API to update certain properties of the Route Policy resource.

