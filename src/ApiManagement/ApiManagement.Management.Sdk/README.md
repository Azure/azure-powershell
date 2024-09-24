# Overall
This directory contains management plane service clients of Az.Storage module.

## Run Generation
In this directory, run AutoRest:
```
autorest --reset
autorest --use:@microsoft.azure/autorest.csharp@2.3.91
autorest.cmd README.md --version=v2
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
# title: ApiManagementClient
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

output-folder: Generated

namespace: Microsoft.Azure.Management.ApiManagement
```