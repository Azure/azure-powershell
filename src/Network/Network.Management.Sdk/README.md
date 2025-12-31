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
commit: b6d0dc8ef749d50348f0e27f5eee38ac3e5469d0 
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/applicationGateway.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/applicationGatewayWafDynamicManifests.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/applicationSecurityGroup.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/availableDelegations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/availableServiceAliases.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/azureFirewall.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/azureFirewallFqdnTag.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/azureWebCategory.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/bastionHost.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/checkDnsAvailability.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/cloudServiceNetworkInterface.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/cloudServicePublicIpAddress.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/cloudServiceSwap.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/customIpPrefix.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/ddosCustomPolicy.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/ddosProtectionPlan.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/dscpConfiguration.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/endpointService.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/expressRouteCircuit.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/expressRouteCrossConnection.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/expressRoutePort.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/expressRouteProviderPort.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/firewallPolicy.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/ipAddressManager.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/ipAllocation.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/ipGroups.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/loadBalancer.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/natGateway.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/network.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/networkInterface.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/networkManager.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/networkManagerActiveConfiguration.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/networkManagerConnection.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/networkManagerConnectivityConfiguration.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/networkManagerEffectiveConfiguration.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/networkManagerGroup.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/networkManagerScopeConnection.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/networkManagerSecurityAdminConfiguration.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/networkManagerRoutingConfiguration.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/networkManagerSecurityUserConfiguration.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/networkProfile.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/networkSecurityGroup.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/networkVerifier.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/networkVirtualAppliance.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/networkWatcher.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/operation.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/privateEndpoint.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/privateLinkService.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/publicIpAddress.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/publicIpPrefix.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/routeFilter.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/routeTable.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/securityPartnerProvider.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/serviceCommunity.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/serviceEndpointPolicy.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/serviceTags.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/usage.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/virtualNetwork.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/virtualNetworkAppliance.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/virtualNetworkGateway.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/virtualNetworkTap.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/virtualRouter.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/virtualWan.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/vmssNetworkInterface.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/vmssPublicIpAddress.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/stable/2025-05-01/webapplicationfirewall.json


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
  # Merge duplicate AutoGenerated models from VirtualNetworkAppliance swagger (2025-05-01)
  # These duplicates are created because the VNA swagger is from a different commit
  - where:
      model-name: CloudErrorAutoGenerated
    set:
      model-name: CloudError
  - where:
      model-name: CloudErrorBodyAutoGenerated
    set:
      model-name: CloudErrorBody
  - where:
      model-name: ApplicationGatewayBackendAddressPoolAutoGenerated
    set:
      model-name: ApplicationGatewayBackendAddressPool
  - where:
      model-name: ApplicationGatewayBackendAddressPoolPropertiesFormatAutoGenerated
    set:
      model-name: ApplicationGatewayBackendAddressPoolPropertiesFormat
  - where:
      model-name: NetworkInterfaceIPConfigurationAutoGenerated
    set:
      model-name: NetworkInterfaceIPConfiguration
  - where:
      model-name: NetworkInterfaceIPConfigurationPropertiesFormatAutoGenerated
    set:
      model-name: NetworkInterfaceIPConfigurationPropertiesFormat
  - where:
      model-name: VirtualNetworkTapAutoGenerated
    set:
      model-name: VirtualNetworkTap
  - where:
      model-name: VirtualNetworkTapPropertiesFormatAutoGenerated
    set:
      model-name: VirtualNetworkTapPropertiesFormat
  - where:
      model-name: NetworkInterfaceTapConfigurationAutoGenerated
    set:
      model-name: NetworkInterfaceTapConfiguration
  - where:
      model-name: NetworkInterfaceTapConfigurationPropertiesFormatAutoGenerated
    set:
      model-name: NetworkInterfaceTapConfigurationPropertiesFormat
  - where:
      model-name: FrontendIPConfigurationAutoGenerated
    set:
      model-name: FrontendIPConfiguration
  - where:
      model-name: FrontendIPConfigurationPropertiesFormatAutoGenerated
    set:
      model-name: FrontendIPConfigurationPropertiesFormat
  - where:
      model-name: SubnetAutoGenerated
    set:
      model-name: Subnet
  - where:
      model-name: SubnetPropertiesFormatAutoGenerated
    set:
      model-name: SubnetPropertiesFormat
  - where:
      model-name: NetworkSecurityGroupAutoGenerated
    set:
      model-name: NetworkSecurityGroup
  - where:
      model-name: NetworkSecurityGroupPropertiesFormatAutoGenerated
    set:
      model-name: NetworkSecurityGroupPropertiesFormat
  - where:
      model-name: NetworkInterfaceAutoGenerated
    set:
      model-name: NetworkInterface
  - where:
      model-name: NetworkInterfacePropertiesFormatAutoGenerated
    set:
      model-name: NetworkInterfacePropertiesFormat
  - where:
      model-name: PrivateEndpointAutoGenerated
    set:
      model-name: PrivateEndpoint
  - where:
      model-name: PrivateEndpointPropertiesAutoGenerated
    set:
      model-name: PrivateEndpointProperties
  - where:
      model-name: PrivateLinkServiceAutoGenerated
    set:
      model-name: PrivateLinkService
  - where:
      model-name: PrivateLinkServicePropertiesAutoGenerated
    set:
      model-name: PrivateLinkServiceProperties
  - where:
      model-name: PrivateLinkServiceIpConfigurationAutoGenerated
    set:
      model-name: PrivateLinkServiceIpConfiguration
  - where:
      model-name: PrivateLinkServiceIpConfigurationPropertiesAutoGenerated
    set:
      model-name: PrivateLinkServiceIpConfigurationProperties
  - where:
      model-name: PrivateEndpointConnectionAutoGenerated
    set:
      model-name: PrivateEndpointConnection
  - where:
      model-name: PrivateEndpointConnectionPropertiesAutoGenerated
    set:
      model-name: PrivateEndpointConnectionProperties
  - where:
      model-name: RouteTableAutoGenerated
    set:
      model-name: RouteTable
  - where:
      model-name: RouteTablePropertiesFormatAutoGenerated
    set:
      model-name: RouteTablePropertiesFormat
  - where:
      model-name: ServiceEndpointPolicyAutoGenerated
    set:
      model-name: ServiceEndpointPolicy
  - where:
      model-name: ServiceEndpointPolicyPropertiesFormatAutoGenerated
    set:
      model-name: ServiceEndpointPolicyPropertiesFormat
  - where:
      model-name: IPConfigurationAutoGenerated
    set:
      model-name: IPConfiguration
  - where:
      model-name: IPConfigurationPropertiesFormatAutoGenerated
    set:
      model-name: IPConfigurationPropertiesFormat
  - where:
      model-name: PublicIPAddressAutoGenerated
    set:
      model-name: PublicIPAddress
  - where:
      model-name: PublicIPAddressPropertiesFormatAutoGenerated
    set:
      model-name: PublicIPAddressPropertiesFormat
  - where:
      model-name: NatGatewayAutoGenerated
    set:
      model-name: NatGateway
  - where:
      model-name: NatGatewayPropertiesFormatAutoGenerated
    set:
      model-name: NatGatewayPropertiesFormat
  - where:
      model-name: IPConfigurationProfileAutoGenerated
    set:
      model-name: IPConfigurationProfile
  - where:
      model-name: IPConfigurationProfilePropertiesFormatAutoGenerated
    set:
      model-name: IPConfigurationProfilePropertiesFormat
  - where:
      model-name: BackendAddressPoolAutoGenerated
    set:
      model-name: BackendAddressPool
  - where:
      model-name: BackendAddressPoolPropertiesFormatAutoGenerated
    set:
      model-name: BackendAddressPoolPropertiesFormat
  - where:
      model-name: InboundNatRuleAutoGenerated
    set:
      model-name: InboundNatRule
  - where:
      model-name: InboundNatRulePropertiesFormatAutoGenerated
    set:
      model-name: InboundNatRulePropertiesFormat
```
