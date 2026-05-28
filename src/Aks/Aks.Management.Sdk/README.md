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
commit: c1a0abcedccb286ef44a03d6fb8363bc4e3dd560
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/containerservice/resource-manager/Microsoft.ContainerService/aks/stable/2025-08-01/managedClusters.json

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
  - from: ManagedClusterSecurityProfile.cs
    where: $
    transform: $ = $.replaceAll('System.Collections.Generic.IList<byte[]?>', 'System.Collections.Generic.IList<byte[]>');
output-folder: Generated
namespace: Microsoft.Azure.Management.ContainerService
```