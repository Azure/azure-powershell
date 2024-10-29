# Overall
This directory contains management plane service clients of Az.Network module.

## Run Generation
In this directory, run AutoRest:
```
autorest --reset
autorest --use:@autorest/powershell@4.x
```

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
title: NetworkManagementClient
isSdkGenerator: true
powershell: true
clear-output-folder: true
reflect-api-versions: true
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
use-extension:
  "@autorest/powershell": "4.x"
```



###
``` yaml
commit: 3516acc4e60bd9fed55e488da0b4aad7baa93fb2
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/applicationGateway.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/applicationGatewayWafDynamicManifests.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/applicationSecurityGroup.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/availableDelegations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/availableServiceAliases.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/azureFirewall.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/azureFirewallFqdnTag.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/azureWebCategory.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/bastionHost.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/checkDnsAvailability.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/cloudServiceNetworkInterface.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/cloudServicePublicIpAddress.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/cloudServiceSwap.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/customIpPrefix.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/ddosCustomPolicy.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/ddosProtectionPlan.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/dscpConfiguration.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/endpointService.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/expressRouteCircuit.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/expressRouteCrossConnection.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/expressRoutePort.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/expressRouteProviderPort.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/firewallPolicy.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/ipAddressManager.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/ipAllocation.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/ipGroups.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/loadBalancer.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/natGateway.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/network.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/networkInterface.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/networkManager.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/networkManagerActiveConfiguration.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/networkManagerConnection.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/networkManagerConnectivityConfiguration.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/networkManagerEffectiveConfiguration.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/networkManagerGroup.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/networkManagerScopeConnection.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/networkManagerSecurityAdminConfiguration.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/networkManagerRoutingConfiguration.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/networkManagerSecurityUserConfiguration.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/networkProfile.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/networkSecurityGroup.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/networkVerifier.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/networkVirtualAppliance.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/networkWatcher.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/operation.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/privateEndpoint.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/privateLinkService.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/publicIpAddress.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/publicIpPrefix.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/routeFilter.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/routeTable.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/securityPartnerProvider.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/serviceCommunity.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/serviceEndpointPolicy.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/serviceTags.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/usage.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/virtualNetwork.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/virtualNetworkGateway.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/virtualNetworkTap.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/virtualRouter.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/virtualWan.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/vmssNetworkInterface.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/vmssPublicIpAddress.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-05-01/webapplicationfirewall.json


output-folder: Generated

namespace: Microsoft.Azure.Management.Network

directive:
  - from: swagger-document
    where: $.definitions.EffectiveNetworkSecurityGroup.properties.tagMap
    transform: $.type = "object"
  - where:
      model-name: Components1Jq1T4ISchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties
    set:
      model-name: ManagedServiceIdentityUserAssignedIdentitiesValue
```