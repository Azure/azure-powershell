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
# end of directives added by xiaogang
  - where:
      model-name: ManagedServiceIdentityUserAssignedIdentities
    set:
      model-name: ManagedServiceIdentityUserAssignedIdentitiesValue
```
