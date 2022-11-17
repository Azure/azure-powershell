# Overall
This directory contains management plane service clients of Az.Aks module.

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
csharp: true
clear-output-folder: true
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
payload-flattening-threshold: 1
```

###
``` yaml
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/195cd610db0accd0422c3e00a72df739ab4de677/specification/containerservice/resource-manager/Microsoft.ContainerService/stable/2022-09-01/managedClusters.json

### There are 2 same "type" property with same x-ms-enum.name="ResourceIdentityType" defined in both managedClusters.json and its referenced types.json. 
### Rename the one in types.json to avoid autorest converting error.
### There are <> in description of orchestratorVersion & currentOrchestratorVersion & kubernetesVersion & currentKubernetesVersion, which will make dotnet build failed.
### Replace <> with () in these descriptions.
directive:
  - from: swagger-document
    where: $.definitions.Identity.properties.type["x-ms-enum"]
    transform: $.name = "ResourceIdentityTypeForCommonTypes"
  - from: swagger-document
    where: $.definitions.ManagedClusterAgentPoolProfileProperties.properties.orchestratorVersion
    transform: $["description"] = $["description"].replaceAll("<", "(");
  - from: swagger-document
    where: $.definitions.ManagedClusterAgentPoolProfileProperties.properties.orchestratorVersion
    transform: $["description"] = $["description"].replaceAll(">", ")");
  - from: swagger-document
    where: $.definitions.ManagedClusterAgentPoolProfileProperties.properties.currentOrchestratorVersion
    transform: $["description"] = $["description"].replaceAll("<", "(");
  - from: swagger-document
    where: $.definitions.ManagedClusterAgentPoolProfileProperties.properties.currentOrchestratorVersion
    transform: $["description"] = $["description"].replaceAll(">", ")");
  - from: swagger-document
    where: $.definitions.ManagedClusterProperties.properties.kubernetesVersion
    transform: $["description"] = $["description"].replaceAll("<", "(");
  - from: swagger-document
    where: $.definitions.ManagedClusterProperties.properties.kubernetesVersion
    transform: $["description"] = $["description"].replaceAll(">", ")");
  - from: swagger-document
    where: $.definitions.ManagedClusterProperties.properties.currentKubernetesVersion
    transform: $["description"] = $["description"].replaceAll("<", "(");
  - from: swagger-document
    where: $.definitions.ManagedClusterProperties.properties.currentKubernetesVersion
    transform: $["description"] = $["description"].replaceAll(">", ")");

output-folder: Generated
namespace: Microsoft.Azure.Management.ContainerService
```