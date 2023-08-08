# Overall
This directory contains management plane service clients of Az.Aks module.

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
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
payload-flattening-threshold: 1
```

###
``` yaml
commit: d27233c75caefa067a59c37538486da5b535cf15
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/containerservice/resource-manager/Microsoft.ContainerService/aks/stable/2023-04-01/managedClusters.json

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
    transform: $["description"] = $["description"].replace(/</g, "(");
  - from: swagger-document
    where: $.definitions.ManagedClusterAgentPoolProfileProperties.properties.orchestratorVersion
    transform: $["description"] = $["description"].replace(/>/g, ")");
  - from: swagger-document
    where: $.definitions.ManagedClusterAgentPoolProfileProperties.properties.currentOrchestratorVersion
    transform: $["description"] = $["description"].replace(/</g, "(");
  - from: swagger-document
    where: $.definitions.ManagedClusterAgentPoolProfileProperties.properties.currentOrchestratorVersion
    transform: $["description"] = $["description"].replace(/>/g, ")");
  - from: swagger-document
    where: $.definitions.ManagedClusterProperties.properties.kubernetesVersion
    transform: $["description"] = $["description"].replace(/</g, "(");
  - from: swagger-document
    where: $.definitions.ManagedClusterProperties.properties.kubernetesVersion
    transform: $["description"] = $["description"].replace(/>/g, ")");
  - from: swagger-document
    where: $.definitions.ManagedClusterProperties.properties.currentKubernetesVersion
    transform: $["description"] = $["description"].replace(/</g, "(");
  - from: swagger-document
    where: $.definitions.ManagedClusterProperties.properties.currentKubernetesVersion
    transform: $["description"] = $["description"].replace(/>/g, ")");
  - where:
      model-name: AgentPool
      property-name: PropertiesType
    set:
      property-name: AgentPoolType

output-folder: Generated
namespace: Microsoft.Azure.Management.ContainerService
```