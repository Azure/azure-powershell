# Overall
This directory contains management plane service clients of Az.Resources module.

## Run Generation
In this directory, run AutoRest:
```
autorest --reset
autorest --use:@microsoft.azure/autorest.csharp@2.3.90
autorest.cmd README.md --version=v2
```

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
title: ResourceManagementClient
csharp: true
clear-output-folder: true
reflect-api-versions: true
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
```



###
``` yaml
commit: 49401294370eed6ed25de57fce89ac901c671cf4
input-file:
- https://github.com/Azure/azure-rest-api-specs/tree/b204f956fd42ef64380f2ef3f2999dcd5bb4bbe4/specification/resources/resource-manager/Microsoft.Resources/preview/2022-08-01-preview/deploymentStacks.json
- https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/resources/resource-manager/Microsoft.Resources/stable/2022-09-01/resources.json
- https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/resources/resource-manager/Microsoft.Resources/stable/2021-01-01/subscriptions.json
- https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/resources/resource-manager/Microsoft.Resources/stable/2020-10-01/deploymentScripts.json
- https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/resources/resource-manager/Microsoft.Resources/stable/2021-05-01/templateSpecs.json
- https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/resources/resource-manager/Microsoft.Resources/stable/2016-09-01/links.json
- https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/resources/resource-manager/Microsoft.Authorization/stable/2020-09-01/dataPolicyManifests.json
- https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/resources/resource-manager/Microsoft.Authorization/stable/2020-09-01/policyAssignments.json
- https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/resources/resource-manager/Microsoft.Authorization/stable/2020-09-01/policyDefinitions.json
- https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/resources/resource-manager/Microsoft.Authorization/stable/2020-09-01/policySetDefinitions.json
- https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/resources/resource-manager/Microsoft.Authorization/preview/2020-07-01-preview/policyExemptions.json
- https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/resources/resource-manager/Microsoft.Authorization/stable/2020-05-01/locks.json
- https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/resources/resource-manager/Microsoft.Authorization/stable/2020-05-01/privateLinks.json
- https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/resources/resource-manager/Microsoft.Features/stable/2021-07-01/features.json
- https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/resources/resource-manager/Microsoft.Features/stable/2021-07-01/SubscriptionFeatureRegistration.json



output-folder: Generated

namespace: Microsoft.Azure.Management.Resources
```