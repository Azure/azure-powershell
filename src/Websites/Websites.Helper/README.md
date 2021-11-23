# Overall
This directory contains the service clients of other services for Azure PowerShell Websites module.

## Run Generation
In this directory, run AutoRest:
```
autorest.cmd README.md --version=v2 --tag=Network
autorest.cmd README.md --version=v2 --tag=PrivateDns
```

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
csharp: true
clear-output-folder: true
reflect-api-versions: true
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
payload-flattening-threshold: 2
```


### Tag: Network
``` yaml $(tag) == 'Network'
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/8c8ae024cbd209644e6f93a3bb031f9cffb07401/specification/network/resource-manager/Microsoft.Network/stable/2020-07-01/virtualNetwork.json
  - https://github.com/Azure/azure-rest-api-specs/blob/8c8ae024cbd209644e6f93a3bb031f9cffb07401/specification/network/resource-manager/Microsoft.Network/stable/2020-07-01/privateEndpoint.json
  - https://github.com/Azure/azure-rest-api-specs/blob/8c8ae024cbd209644e6f93a3bb031f9cffb07401/specification/network/resource-manager/Microsoft.Network/stable/2020-07-01/networkInterface.json
  - https://github.com/Azure/azure-rest-api-specs/blob/8c8ae024cbd209644e6f93a3bb031f9cffb07401/specification/network/resource-manager/Microsoft.Network/stable/2020-07-01/routeTable.json
  - https://github.com/Azure/azure-rest-api-specs/blob/8c8ae024cbd209644e6f93a3bb031f9cffb07401/specification/network/resource-manager/Microsoft.Network/stable/2020-07-01/networkSecurityGroup.json
  - https://github.com/Azure/azure-rest-api-specs/blob/8c8ae024cbd209644e6f93a3bb031f9cffb07401/specification/network/resource-manager/Microsoft.Network/stable/2020-07-01/serviceTags.json

output-folder: Network

namespace: Microsoft.Azure.PowerShell.Cmdlets.Websites.Helper.Network

directive:
  - remove-operation:
    - PrivateEndpoints_Delete
    - PrivateEndpoints_Get
    - PrivateEndpoints_List
    - PrivateEndpoints_ListBySubscription
    - AvailablePrivateEndpointTypes_List
    - AvailablePrivateEndpointTypes_ListByResourceGroup
    - PrivateDnsZoneGroups_Delete
    - PrivateDnsZoneGroups_Get
    - PrivateDnsZoneGroups_CreateOrUpdate
    - PrivateDnsZoneGroups_List
    - VirtualNetworks_Delete
    - VirtualNetworks_Get
    - VirtualNetworks_CreateOrUpdate
    - VirtualNetworks_UpdateTags
    - VirtualNetworks_List
    - Subnets_Delete
    - Subnets_PrepareNetworkPolicies
    - Subnets_UnprepareNetworkPolicies
    - ResourceNavigationLinks_List
    - ServiceAssociationLinks_List
    - Subnets_List
    - VirtualNetworkPeerings_Delete
    - VirtualNetworkPeerings_Get
    - VirtualNetworkPeerings_CreateOrUpdate
    - VirtualNetworkPeerings_List
    - VirtualNetworks_CheckIPAddressAvailability
    - VirtualNetworks_ListUsage
    - NetworkInterfaces_Delete
    - NetworkInterfaces_CreateOrUpdate
    - NetworkInterfaces_UpdateTags
    - NetworkInterfaces_ListAll
    - NetworkInterfaces_List
    - NetworkInterfaces_GetEffectiveRouteTable
    - NetworkInterfaces_ListEffectiveNetworkSecurityGroups
    - NetworkInterfaceIPConfigurations_List
    - NetworkInterfaceIPConfigurations_Get
    - NetworkInterfaceLoadBalancers_List
    - NetworkInterfaceTapConfigurations_Delete
    - NetworkInterfaceTapConfigurations_Get
    - NetworkInterfaceTapConfigurations_CreateOrUpdate
    - NetworkInterfaceTapConfigurations_List
  - remove-model:
    - AvailablePrivateEndpointTypesResult
    - AvailablePrivateEndpointType
    - NetworkInterfaceLoadBalancerListResult
    - PrivateEndpointListResult
    - PrivateDnsZoneGroupListResult
    - ResourceNavigationLinksListResult
    - ServiceAssociationLinksListResult
    - VirtualNetworkPeeringListResult
    - VirtualNetworkListUsageResult
    - NetworkInterfaceListResult
    - EffectiveNetworkSecurityGroupListResult
    - EffectiveRouteListResult
    - NetworkInterfaceTapConfigurationListResult
    - NetworkInterfaceIPConfigurationListResult
```

### Tag: PrivateDns
``` yaml $(tag) == 'PrivateDns'
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/8c8ae024cbd209644e6f93a3bb031f9cffb07401/specification/privatedns/resource-manager/Microsoft.Network/stable/2018-09-01/privatedns.json

output-folder: PrivateDns

namespace: Microsoft.Azure.PowerShell.Cmdlets.Websites.Helper.PrivateDns

directive:
  - remove-operation:
    - PrivateZones_Update
    - PrivateZones_Delete
    - PrivateZones_Get
    - PrivateZones_List
    - PrivateZones_ListByResourceGroup
    - VirtualNetworkLinks_Update
    - VirtualNetworkLinks_Delete
    - VirtualNetworkLinks_Get
    - RecordSets_Update
    - RecordSets_Delete
    - RecordSets_Get
    - RecordSets_ListByType
    - RecordSets_List
  - remove-model:
    - PrivateZoneListResult
```