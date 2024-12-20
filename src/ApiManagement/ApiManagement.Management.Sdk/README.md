# Overall
This directory contains management plane service clients of Az.Storage module.

## Run Generation
In this directory, run AutoRest:
```
autorest --reset
autorest --use:@autorest/powershell@4.x
```

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
isSdkGenerator: true
powershell: true
clear-output-folder: true
reflect-api-versions: true
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
title: ApiManagementClient
```



###
``` yaml
commit: e1b38934a6e3bd0fcb22a7c8e0a8522957aa1d9b
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimanagement.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimapis.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimapisByTags.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimapiversionsets.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimauthorizationservers.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimbackends.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimcaches.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimcertificates.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimconnectivitycheck.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimcontenttypes.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimdeletedservices.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimdeployment.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimdiagnostics.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimemailtemplates.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimgateways.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimgroups.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimidentityprovider.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimissues.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimloggers.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimnamedvalues.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimnetworkstatus.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimnotifications.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimopenidconnectproviders.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimoutbounddependency.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimpolicies.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimpolicydescriptions.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimportalrevisions.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimportalsettings.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimprivatelink.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimproducts.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimproductsByTags.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimquotas.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimregions.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimreports.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimschema.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimsettings.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimskus.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimsubscriptions.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimtagresources.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimtags.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimtenant.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/apimusers.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/definitions.json

directive:
  - suppress: R3016
    reason: existing properties, can't be changed without breaking API.
  - suppress: R4009
    from: apimapis.json
    reason: Warning raised to error while PR was being reviewed. SystemData will implement in next preview version.
  - suppress: R4009
    from: apimapiversionsets.json
    reason: Warning raised to error while PR was being reviewed. SystemData will implement in next preview version.
  - suppress: R4009
    from: apimauthorizationservers.json
    reason: Warning raised to error while PR was being reviewed. SystemData will implement in next preview version.
  - suppress: R4009
    from: apimbackends.json
    reason: Warning raised to error while PR was being reviewed. SystemData will implement in next preview version.
  - suppress: R4009
    from: apimbackends.json
    reason: Warning raised to error while PR was being reviewed. SystemData will implement in next preview version.
  - suppress: R4009
    from: apimcaches.json
    reason: Warning raised to error while PR was being reviewed. SystemData will implement in next preview version.
  - suppress: R4009
    from: apimcertificates.json
    reason: Warning raised to error while PR was being reviewed. SystemData will implement in next preview version.
  - suppress: R4009
    from: apimdeployment.json
    reason: Warning raised to error while PR was being reviewed. SystemData will implement in next preview version.
  - suppress: R4009
    from: apimsubscriptions.json
    reason: Warning raised to error while PR was being reviewed. SystemData will implement in next preview version.
  - suppress: R4009
    from: apimusers.json
    reason: Warning raised to error while PR was being reviewed. SystemData will implement in next preview version.
  - suppress: R4009
    from: apimproducts.json
    reason: Warning raised to error while PR was being reviewed. SystemData will implement in next preview version.
  - suppress: R4009
    from: apimnamedvalues.json
    reason: Warning raised to error while PR was being reviewed. SystemData will implement in next preview version.
  - suppress: R4009
    from: apimgateways.json
    reason: Warning raised to error while PR was being reviewed. SystemData will implement in next preview version.
  - suppress: R4009
    from: apimgroups.json
    reason: Warning raised to error while PR was being reviewed. SystemData will implement in next preview version.
  - suppress: R4009
    from: apimcontenttypes.json
    reason: Warning raised to error while PR was being reviewed. SystemData will implement in next preview version.
  - suppress: R4009
    from: apimdeletedservices.json
    reason: Warning raised to error while PR was being reviewed. SystemData will implement in next preview version.
  - suppress: R4009
    from: apimdiagnostics.json
    reason: Warning raised to error while PR was being reviewed. SystemData will implement in next preview version.
  - suppress: R4009
    from: apimemailtemplates.json
    reason: Warning raised to error while PR was being reviewed. SystemData will implement in next preview version.
  - suppress: R4009
    from: apimidentityprovider.json
    reason: Warning raised to error while PR was being reviewed. SystemData will implement in next preview version.
  - suppress: R4009
    from: apimissues.json
    reason: Warning raised to error while PR was being reviewed. SystemData will implement in next preview version.
  - suppress: R4009
    from: apimloggers.json
    reason: Warning raised to error while PR was being reviewed. SystemData will implement in next preview version.
  - suppress: R4009
    from: apimopenidconnectproviders.json
    reason: Warning raised to error while PR was being reviewed. SystemData will implement in next preview version.
  - suppress: R4009
    from: apimpolicies.json
    reason: Warning raised to error while PR was being reviewed. SystemData will implement in next preview version.
  - suppress: R4009
    from: apimportalrevisions.json
    reason: Warning raised to error while PR was being reviewed. SystemData will implement in next preview version.
  - suppress: R4009
    from: apimschema.json
    reason: Warning raised to error while PR was being reviewed. SystemData will implement in next preview version.
  - suppress: R4009
    from: apimsettings.json
    reason: Warning raised to error while PR was being reviewed. SystemData will implement in next preview version.
  - suppress: R4009
    from: apimtags.json
    reason: Warning raised to error while PR was being reviewed. SystemData will implement in next preview version.
  - suppress: R4009
    from: apimtenant.json
    reason: Warning raised to error while PR was being reviewed. SystemData will implement in next preview version.
  - suppress: R4009
    from: apimnotifications.json
    reason: Warning raised to error while PR was being reviewed. SystemData will implement in next preview version.
  - suppress: R4037
    from: definitions.json
    reason: We want customers to be able to supply any valid JSON token, object or otherwise    
  - suppress: R4009
    from: apimprivatelink.json
    reason: Warning raised to error while PR was being reviewed. SystemData will implement in next preview version.  
  - suppress: R4009
    from: apimprivatelink.json
    reason: Warning raised to error while PR was being reviewed. SystemData will implement in next preview version.  
  - suppress: R4009
    from: apimprivatelink.json
    reason: Warning raised to error while PR was being reviewed. SystemData will implement in next preview version.  
  - from: apimproducts.json
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/products/{productId}/groups/{groupId}"].head.responses
    transform: >-
      return {
          "204": {
            "description": "The Group is associated with the Product."
          },
          "404": {
            "description": "The Group is not associated with the Product."
          },
          "default": {
            "description": "Error response describing why the operation failed.",
            "schema": {
              "$ref": "./apimanagement.json#/definitions/ErrorResponse"
            }
          }
      }
  - from: apimproducts.json
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/products/{productId}/apis/{apiId}"].head.responses
    transform: >-
      return {
          "204": {
            "description": "Entity exists"
          },
          "404": {
            "description": "Entity does not exists."
          },
          "default": {
            "description": "Error response describing why the operation failed.",
            "schema": {
              "$ref": "./apimanagement.json#/definitions/ErrorResponse"
            }
          }
      }
  - where:
      model-name: AdditionalLocation
      property-name: PublicIPAddressId
    set:
      property-name: PublicIpAddressId
  - where:
      model-name: ApiManagementServiceResource
      property-name: PublicIPAddressId
    set:
      property-name: PublicIpAddressId

output-folder: Generated

namespace: Microsoft.Azure.Management.ApiManagement
```