# Overall
This directory contains the service clients of Az.Compute module.

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
reflect-api-versions: true
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION

title: ComputeManagementClient
payload-flattening-threshold: 1

directive:
    # dynamically add a DummyOrchestrationServiceName value to the enum 
  - from: ComputeRP.json
    where: $..enum
    transform: >-
      if( $.length === 1 && $[0] === "AutomaticRepairs") { 
        $.push('DummyOrchestrationServiceName');
      }
      return $;
    
    # remove it from the C# generated code
  - from: source-file-csharp
    where: $ 
    transform: >-
      return $.
        replace(/.*public const string DummyOrchestrationServiceName.*/g,'').
        replace(/, 'DummyOrchestrationServiceName'/g,'');
  - from: GalleryRP.json
    where: $.definitions.GalleryTargetExtendedLocation.properties.storageAccountType["x-ms-enum"].name
    transform: return "EdgeZoneStorageAccountType"
  - from: ComputeRP.json
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualMachines/{instanceId}"].get.parameters[?(@.name === "$expand")]["x-ms-enum"].name
    transform: return "VmssVMInstanceViewTypes"
  - from: swagger-document
    where: $.securityDefinitions.azure_auth
    transform: >
      $["description"] = "Azure Active Directory OAuth2 Flow";
  - from: swagger-document
    where: $
    transform: >
      $.tags = [];
```
<!--
  - from: swagger-document
    where: $
    transform: >
      const fixDescriptionConflicts = (obj, path) => {
        if (!obj || typeof obj !== 'object') return;
        
        // Handle description at current level
        if ('description' in obj && obj.description) {
          if (typeof obj.description === 'object') {
            obj.description = Array.isArray(obj.description) ? 
              obj.description[0] : 
              Object.values(obj.description)[0];
          }
        }
        
        // Process child objects
        for (const key in obj) {
          if (obj[key] && typeof obj[key] === 'object') {
            fixDescriptionConflicts(obj[key], path + '.' + key);
          }
        }
      };
      
      fixDescriptionConflicts($, '$');
      return $;
  - from: swagger-document
    where: $.definitions.Operation.properties.display.properties.description
    transform: >
      if (typeof $ === 'string') {
        return { "type": "string", "description": $ };
      }
      return $;
  
  - from: swagger-document
    where: $.definitions.RunCommandDocumentBase.properties.description
    transform: >
      if (typeof $ === 'string') {
        return { "type": "string", "description": $ };
      }
      return $;


  - from: swagger-document
    where: $.definitions.HyperVGeneration
    transform: >
      $.description = "The hypervisor generation of the Virtual Machine. [V1, V2]"
  - from: swagger-document
    where: $.definitions
    transform: >
      for (const definitionName in $) {
        const definition = $[definitionName];
        if (definition.description && typeof definition.description === 'object' && definition.description[0]) {
          definition.description = definition.description[0];
        }
      }
      return $;
-->
###
``` yaml
commit: f8d5ec7433a099628286e1b912e94ad599510680
input-file: 
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2024-11-01/ComputeRP.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/DiskRP/stable/2024-03-02/DiskRP.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/Skus/stable/2021-07-01/skus.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/GalleryRP/stable/2024-03-03/GalleryRP.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/CloudserviceRP/stable/2022-09-04/cloudService.json

output-folder: Generated

namespace: Microsoft.Azure.Management.Compute
```