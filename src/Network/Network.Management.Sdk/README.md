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
commit: 587a15661041e26ff8a3059a4886ff9e092adfda
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2025-07-01/applicationGateway.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2025-07-01/azureWebCategory.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2025-07-01/common.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2025-07-01/expressRoute.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2025-07-01/firewall.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2025-07-01/firewallPolicy.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2025-07-01/interconnectGroup.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2025-07-01/loadBalancer.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2025-07-01/networkGateway.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2025-07-01/networkManager.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2025-07-01/networkSecurityPerimeter.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2025-07-01/networkWatcher.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2025-07-01/networkingOperations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2025-07-01/serviceGateway.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2025-07-01/virtualNetwork.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2025-07-01/virtualNetworkAppliance.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2025-07-01/virtualWan.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2018-10-01/vmssNetwork.json

output-folder: Generated

namespace: Microsoft.Azure.Management.Network

directive:
# start of directives added by xiaogang
# Remove lro response headers. Srijani, you may ignore this part.
  - from: swagger-document
    where: $.paths..responses.202.headers
    transform: delete $["Location"]
  - from: swagger-document
    where: $.paths..responses.202.headers
    transform: delete $["Retry-After"]
  - from: swagger-document
    where: $.paths..responses.202.headers
    transform: delete $["Azure-AsyncOperation"]
  - from: swagger-document
    where: $.paths..responses.201.headers
    transform: delete $["Location"]
  - from: swagger-document
    where: $.paths..responses.201.headers
    transform: delete $["Retry-After"]
  - from: swagger-document
    where: $.paths..responses.201.headers
    transform: delete $["Azure-AsyncOperation"]
# remove tags in https://github.com/Azure/azure-rest-api-specs/blob/906c9971ea117692ad6e7e15fe1a0b38ac109c76/specification/network/resource-manager/Microsoft.Network/Network/stable/2025-07-01/virtualNetwork.json#L17498, since it has been defined in the parent TrackedResourceWithOptionalLocation.
# Srijani, this is a workaround. I think it should be fixed in your typespec.
# Yabo, Ideally, our code generator should be able to handle case like this. If the property is redundant in the child, we could just ignore it.
  - from: swagger-document
    where: $.definitions.DdosProtectionPlan.properties
    transform: delete $["tags"]
  - from: swagger-document
    where: $.definitions.EffectiveNetworkSecurityGroup.properties.tagMap
    transform: $.type = "object"
# Strip the "Common." prefix from all definitions so the generated C# class names
# stay backward-compatible with the handwritten Az.Network layer. Without this directive
# every "Common.X" swagger definition becomes a "CommonX" C# class (e.g. CommonRouteTable,
# CommonSubResource, CommonLoadBalancer), breaking the handwritten cmdlets that reference
# the legacy names.
# Long-term fix: drop the "Common." prefix at the TypeSpec/swagger source so this workaround
# can be removed.
  - from: swagger-document
    where: $.definitions
    transform: >
      for (const k of Object.keys($)) {
        if (k.startsWith('Common.')) {
          $[k]['x-ms-client-name'] = k.substring('Common.'.length);
        }
      }
# rename Common.CloudError to CloudError, see https://github.com/Azure/azure-rest-api-specs/blob/906c9971ea117692ad6e7e15fe1a0b38ac109c76/specification/network/resource-manager/Microsoft.Network/Network/stable/2025-07-01/common.json#L2026
# Srijani, I noticed in the swaggers generated from tsp, some model names are added the prefix "common.", the change will lead to the change of the generated C# class name. As a result, it may cause some issues and breaking changes. Following is a case. I would suggest you remove the prefix "common.".
  - from: swagger-document
    where: $.definitions["Common.CloudError"]
    transform: $["x-ms-client-name"] = "CloudError"
# Keep SubscriptionId on NetworkManagementClient typed as string. TypeSpec emits the global subscriptionId
# parameter with `format: uuid`, which makes the generated client property a System.Guid and breaks the
# handwritten helpers (e.g. ApplicationGatewayChildResourceHelper) that expect a string.
  - from: swagger-document
    where: $.parameters.SubscriptionIdParameter
    transform: delete $.format
  - from: swagger-document
    where: $..parameters[?(@.name=='subscriptionId')]
    transform: delete $.format
# Srijani, following cases are also breaking changes. I have to change them back with directives.
# Yabo, Not sure if allof and x-ms-azure-resource could co-existed in a model. If so, we need to add support for it.
# move x-ms-azure-resource from Common.SubResourceModel to Common.SubResource
  - from: swagger-document
    where: $.definitions["Common.SubResourceModel"]
    transform: delete $["x-ms-azure-resource"]
  - from: swagger-document
    where: $.definitions["Common.SubResource"]
    transform: $["x-ms-azure-resource"] = true
# move x-ms-azure-resource from CommonProxyResource and CommonTrackedResource to CommonResource
  - from: swagger-document
    where: $.definitions["CommonProxyResource"]
    transform: delete $["x-ms-azure-resource"]
  - from: swagger-document
    where: $.definitions["CommonTrackedResource"]
    transform: delete $["x-ms-azure-resource"]
  - from: swagger-document
    where: $.definitions["CommonResource"]
    transform: $["x-ms-azure-resource"] = true
# move x-ms-azure-resource from SecurityPerimeterProxyResource and SecurityPerimeterTrackedResource to SecurityPerimeterResource
  - from: swagger-document
    where: $.definitions["SecurityPerimeterProxyResource"]
    transform: delete $["x-ms-azure-resource"]
  - from: swagger-document
    where: $.definitions["SecurityPerimeterTrackedResource"]
    transform: delete $["x-ms-azure-resource"]
  - from: swagger-document
    where: $.definitions["SecurityPerimeterResource"]
    transform: $["x-ms-azure-resource"] = true
# Keep ApplicationGatewayFirewallDisabledRuleGroup.rules element non-nullable (IList<int>).
# rules.items carried "x-nullable": false in every hand-written swagger api-version from 2017-03-01
# through 2025-03-01. The TypeSpec migration (azure-rest-api-specs #40226, api-version 2025-05-01)
# dropped it, so the emitted swagger now allows null elements and autorest generates IList<int?>.
# WAF rule IDs are never null; this is an unintended breaking change (analyzer 3030) vs the released
# IList<int>. Restore x-nullable=false here until the TypeSpec source is fixed to re-emit it.
  - from: swagger-document
    where: $.definitions.ApplicationGatewayFirewallDisabledRuleGroup.properties.rules.items
    transform: $["x-nullable"] = false
# end of directives added by xiaogang
  - where:
      model-name: ManagedServiceIdentityUserAssignedIdentities
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
