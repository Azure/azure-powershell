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
commit: 738879cc6e1c5569b01130fd69a2587388fc34b3
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/applicationGateway.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/applicationGatewayWafDynamicManifests.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/applicationSecurityGroup.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/availableDelegations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/availableServiceAliases.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/azureFirewall.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/azureFirewallFqdnTag.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/azureWebCategory.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/bastionHost.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/checkDnsAvailability.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/cloudServiceNetworkInterface.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/cloudServicePublicIpAddress.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/cloudServiceSwap.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/customIpPrefix.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/ddosCustomPolicy.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/ddosProtectionPlan.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/dscpConfiguration.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/endpointService.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/expressRouteCircuit.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/expressRouteCrossConnection.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/expressRoutePort.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/expressRouteProviderPort.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/firewallPolicy.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/ipAllocation.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/ipGroups.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/loadBalancer.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/natGateway.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/network.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/networkInterface.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/networkManager.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/networkManagerActiveConfiguration.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/networkManagerConnection.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/networkManagerConnectivityConfiguration.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/networkManagerEffectiveConfiguration.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/networkManagerGroup.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/networkManagerScopeConnection.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/networkManagerSecurityAdminConfiguration.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/networkProfile.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/networkSecurityGroup.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/networkVirtualAppliance.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/networkWatcher.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/operation.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/privateEndpoint.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/privateLinkService.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/publicIpAddress.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/publicIpPrefix.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/routeFilter.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/routeTable.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/securityPartnerProvider.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/serviceCommunity.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/serviceEndpointPolicy.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/serviceTags.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/usage.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/virtualNetwork.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/virtualNetworkGateway.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/virtualNetworkTap.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/virtualRouter.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/virtualWan.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/vmssNetworkInterface.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/vmssPublicIpAddress.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/webapplicationfirewall.json

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
