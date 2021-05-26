# Overall
This directory contains the service clients of other services for Azure PowerShell Compute module.

## Run Generation
In this directory, run AutoRest:
```
autorest.cmd README.md --version=v2 --tag=Network
autorest.cmd README.md --version=v2 --tag=Storage
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
  - https://github.com/Azure/azure-rest-api-specs/blob/f5fb71085c6846fd5d11b59a57381a5fcfd36840/specification/network/resource-manager/Microsoft.Network/stable/2020-11-01/virtualNetwork.json
  - https://github.com/Azure/azure-rest-api-specs/blob/f5fb71085c6846fd5d11b59a57381a5fcfd36840/specification/network/resource-manager/Microsoft.Network/stable/2020-11-01/loadBalancer.json
  - https://github.com/Azure/azure-rest-api-specs/blob/f5fb71085c6846fd5d11b59a57381a5fcfd36840/specification/network/resource-manager/Microsoft.Network/stable/2020-11-01/networkInterface.json
  - https://github.com/Azure/azure-rest-api-specs/blob/f5fb71085c6846fd5d11b59a57381a5fcfd36840/specification/network/resource-manager/Microsoft.Network/stable/2020-11-01/checkDnsAvailability.json
  - https://github.com/Azure/azure-rest-api-specs/blob/f5fb71085c6846fd5d11b59a57381a5fcfd36840/specification/network/resource-manager/Microsoft.Network/stable/2020-11-01/networkSecurityGroup.json
  - https://github.com/Azure/azure-rest-api-specs/blob/f5fb71085c6846fd5d11b59a57381a5fcfd36840/specification/network/resource-manager/Microsoft.Network/stable/2020-11-01/publicIpAddress.json

output-folder: Network

namespace: Microsoft.Azure.PowerShell.Cmdlets.Compute.Helpers.Network

directive:
  - remove-operation:
    - VirtualNetworks_Delete
    - VirtualNetworks_UpdateTags
    - VirtualNetworks_ListAll
    - VirtualNetworks_List
    - Subnets_Delete
    - Subnets_Get
    - Subnets_CreateOrUpdate
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
    - LoadBalancers_Delete
    - LoadBalancers_UpdateTags
    - LoadBalancers_ListAll
    - LoadBalancers_List
    - LoadBalancerBackendAddressPools_List
    - LoadBalancerBackendAddressPools_Get
    - LoadBalancerBackendAddressPools_CreateOrUpdate
    - LoadBalancerBackendAddressPools_Delete
    - LoadBalancerFrontendIPConfigurations_List
    - LoadBalancerFrontendIPConfigurations_Get
    - InboundNatRules_List
    - InboundNatRules_Delete
    - InboundNatRules_Get
    - InboundNatRules_CreateOrUpdate
    - LoadBalancerLoadBalancingRules_List
    - LoadBalancerLoadBalancingRules_Get
    - LoadBalancerOutboundRules_List
    - LoadBalancerOutboundRules_Get
    - LoadBalancerNetworkInterfaces_List
    - LoadBalancerProbes_List
    - LoadBalancerProbes_Get
    - NetworkInterfaces_Delete
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
    - NetworkSecurityGroups_Delete
    - NetworkSecurityGroups_UpdateTags
    - NetworkSecurityGroups_ListAll
    - NetworkSecurityGroups_List
    - SecurityRules_Delete
    - SecurityRules_Get
    - SecurityRules_CreateOrUpdate
    - SecurityRules_List
    - DefaultSecurityRules_List
    - DefaultSecurityRules_Get
    - PublicIPAddresses_Delete
    - PublicIPAddresses_UpdateTags
    - PublicIPAddresses_ListAll
    - PublicIPAddresses_List
```

### Tag: Storage
``` yaml $(tag) == 'Storage'
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/f5fb71085c6846fd5d11b59a57381a5fcfd36840/specification/storage/resource-manager/Microsoft.Storage/stable/2021-02-01/storage.json

output-folder: Storage

namespace: Microsoft.Azure.PowerShell.Cmdlets.Compute.Helpers.Storage

directive:
  - remove-operation:
    - Operations_List
    - Skus_List
#    - StorageAccounts_CheckNameAvailability
#    - StorageAccounts_Create
    - StorageAccounts_Delete
#    - StorageAccounts_GetProperties
    - StorageAccounts_Update
    - DeletedAccounts_List
    - DeletedAccounts_Get
#    - StorageAccounts_List
#    - StorageAccounts_ListByResourceGroup
#    - StorageAccounts_ListKeys
    - StorageAccounts_RegenerateKey
    - Usages_ListByLocation
    - StorageAccounts_ListAccountSAS
    - StorageAccounts_ListServiceSAS
    - StorageAccounts_Failover
    - StorageAccounts_RestoreBlobRanges
    - ManagementPolicies_Get
    - ManagementPolicies_CreateOrUpdate
    - ManagementPolicies_Delete
    - BlobInventoryPolicies_Get
    - BlobInventoryPolicies_CreateOrUpdate
    - BlobInventoryPolicies_Delete
    - BlobInventoryPolicies_List
    - PrivateEndpointConnections_List
    - PrivateEndpointConnections_Get
    - PrivateEndpointConnections_Put
    - PrivateEndpointConnections_Delete
    - PrivateLinkResources_ListByStorageAccount
    - ObjectReplicationPolicies_List
    - ObjectReplicationPolicies_Get
    - ObjectReplicationPolicies_CreateOrUpdate
    - ObjectReplicationPolicies_Delete
    - StorageAccounts_RevokeUserDelegationKeys
    - EncryptionScopes_Put
    - EncryptionScopes_Patch
    - EncryptionScopes_Get
    - EncryptionScopes_List
```