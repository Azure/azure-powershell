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

### [Invoke-AzNetworkFabricDeprovision](Invoke-AzNetworkFabricDeprovision.md)
Deprovisions the underlying resources in the given Network Fabric instance.

### [Invoke-AzNetworkFabricInterfaceUpdateAdminState](Invoke-AzNetworkFabricInterfaceUpdateAdminState.md)
Update the admin state of the Network Interface.

### [Invoke-AzNetworkFabricL2DomainUpdateAdminState](Invoke-AzNetworkFabricL2DomainUpdateAdminState.md)
Enables isolation domain across the fabric or on specified racks.

### [Invoke-AzNetworkFabricL3DomainUpdateAdminState](Invoke-AzNetworkFabricL3DomainUpdateAdminState.md)
Enables racks for this Isolation Domain.

### [Invoke-AzNetworkFabricProvision](Invoke-AzNetworkFabricProvision.md)
Provisions the underlying resources in the given Network Fabric instance.

### [Invoke-AzNetworkFabricTapUpdateAdminState](Invoke-AzNetworkFabricTapUpdateAdminState.md)
Implements the operation to the underlying resources.

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

### [Remove-AzNetworkFabricNni](Remove-AzNetworkFabricNni.md)
Implements NetworkToNetworkInterconnects DELETE method.

### [Remove-AzNetworkFabricRoutePolicy](Remove-AzNetworkFabricRoutePolicy.md)
Implements Route Policy DELETE method.

### [Remove-AzNetworkFabricTap](Remove-AzNetworkFabricTap.md)
Deletes Network Tap.

### [Remove-AzNetworkFabricTapRule](Remove-AzNetworkFabricTapRule.md)
Delete Network Tap Rule resource.

### [Update-AzNetworkFabricDevice](Update-AzNetworkFabricDevice.md)
Update certain properties of the Network Device resource.

### [Update-AzNetworkFabricInternetGateway](Update-AzNetworkFabricInternetGateway.md)
Execute patch on Network Fabric Service Internet Gateway.

### [Update-AzNetworkFabricNeighborGroup](Update-AzNetworkFabricNeighborGroup.md)
Update the Neighbor Group.

