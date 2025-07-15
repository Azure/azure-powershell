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
  # Remove all descriptions from the swagger document
  - from: swagger-document
    where: $.definitions
    transform: >
      function removeDefinitionDescriptions(obj) {
        if (!obj || typeof obj !== 'object') return;
        
        // Use a non-recursive approach with a queue
        const queue = [obj];
        const processed = new Set(); // Track processed objects to avoid cycles
        
        while (queue.length > 0) {
          const current = queue.shift();
          
          if (current && typeof current === 'object') {
            // Skip if we've already processed this object (avoid cycles)
            if (processed.has(current)) continue;
            processed.add(current);
            
            // Remove description
            if ('description' in current) {
              delete current.description;
            }
            
            // Add child objects to queue
            for (const key in current) {
              if (current[key] && typeof current[key] === 'object') {
                queue.push(current[key]);
              }
            }
          }
        }
      }
      
      removeDefinitionDescriptions($);
      return $;
  # Remove all descriptions from parameters in the swagger document
  - from: swagger-document
    where: $.parameters
    transform: >
      function removeParameterDescriptions(parameters) {
        if (!parameters || typeof parameters !== 'object') return parameters;
        
        for (const paramName in parameters) {
          if (parameters[paramName] && parameters[paramName].description) {
            delete parameters[paramName].description;
          }
        }
        
        return parameters;
      }
      
      return removeParameterDescriptions($);


  # Replace references to common types with the local file
  - from: Skus.json
    where: $..["$ref"]
    transform: >
      return $.replace(/.*common-types\/resource-management\/v3\/types.json.*/, './common-types/common.json')
  # Replace references to common types with the local file
  - from: DiskRP.json
    where: $..["$ref"]
    transform: >
      return $.replace(/.*common-types\/resource-management\/v3\/types.json.*/, './common-types/common.json')

  # Remove all from common-types/resource-management/v3/types.json
  - from: common-types/resource-management/v3/types.json
    where: $
    transform: |
      return {};

  # dynamically add a DummyOrchestrationServiceName value to the enum 
  - from: ComputeRP.json
    where: $.definitions.OrchestrationServiceNames
    transform: |
      if ($.enum && $.enum.length === 1 && $.enum[0] === "AutomaticRepairs") {
        // Add to enum array
        $.enum.push('DummyOrchestrationServiceName');
        
        // Also update x-ms-enum values if they exist
        if ($['x-ms-enum'] && $['x-ms-enum'].values) {
          $['x-ms-enum'].values.push({
            value: 'DummyOrchestrationServiceName',
            name: 'DummyOrchestrationServiceName'
          });
        }
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
  
  # Fix inconsistency
  - from: swagger-document
    where: $.securityDefinitions.azure_auth
    transform: >
      $["description"] = "Azure Active Directory OAuth2 Flow";
  - from: swagger-document
    where: $
    transform: >
      $.tags = [];

  # Fix for enums missing x-ms-enum name. REMOVALBLE?
  - from: swagger-document
    where: $..["x-ms-enum"]
    transform: |
      if (!$.name) {
        const path = JSON.stringify(console.trackPath);
        console.log(`Adding missing enum name for path: ${path}`);
        $.name = "UnnamedEnum" + Math.random().toString(36).substring(2, 8);
      }
      return $;

  # Fix for ExtendedLocationType enum
  - from: swagger-document
    where: $.definitions.ExtendedLocationType["x-ms-enum"]
    transform: |
      $.name = "ExtendedLocationTypes";
      return $;
#
#  # Fix for duplicate OperatingSystemStateTypes -  rename in GalleryRP.json
#  - from: GalleryRP.json
#    rename-model:
#      from: OperatingSystemStateTypes
#      to: GalleryOperatingSystemStateTypes

  - from: ComputeRP.json
    where: $..properties.type
    transform: |
      if ($ && $["x-ms-enum"] && $["x-ms-enum"].name === "ResourceIdentityType") {
        $.enum = ["SystemAssigned", "UserAssigned", "SystemAssigned, UserAssigned", "None"];
      }
      return $;

  # Sku fixes 
  - from: swagger-document
    where: $.definitions.Sku.properties.capacity
    transform: >
      if ($ && $.format) {
        $.format = "int64";
      }
      return $;
 ```
###
``` yaml
commit: f8d5ec7433a099628286e1b912e94ad599510680
input-file: 
  - ./common-types/common.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2024-11-01/ComputeRP.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/DiskRP/stable/2024-03-02/DiskRP.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/Skus/stable/2021-07-01/skus.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/GalleryRP/stable/2024-03-03/GalleryRP.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/CloudserviceRP/stable/2022-09-04/cloudService.json

output-folder: Generated

namespace: Microsoft.Azure.Management.Compute
```

<!--
  # Remove one of the duplicate SubscriptionIdParameter definitions
  - from-file: Microsoft.Compute/common-types/v1/common.json
    where: $.parameters.SubscriptionIdParameter
    transform: |
      /* keep the ARM-level definition, discard this one */
      return undefined;
  
  # Fix for SubscriptionIdParameter - simplify
  - from: swagger-document
    where: $.parameters.SubscriptionIdParameter
    transform: >
      if ($.description) {
        $.description = "The ID of the target subscription.";
      }
      return $;

  # Sku fix 
  - from: ComputeRP.json
    rename-model:
      from: Sku
      to: ComputeSku
  - from: DiskRP.json
    rename-model:
      from: Sku
      to: DiskSku
  - from: skus.json
    rename-model:
      from: Sku
      to: SkusSku
  - from: GalleryRP.json
    rename-model:
      from: Sku
      to: GallerySku
  - from: CloudserviceRP.json
    rename-model:
      from: Sku
      to: CloudServiceSku


  - from: swagger-document
    where: $.definitions.ResourceModelWithAllowedPropertySet.properties.sku
    transform: return undefined;
  
  - from: swagger-document
    where: $.definitions
    transform: |
      for (const [name,schema] of Object.entries($)) {
        if (name.endsWith('Sku') &&
            schema.allOf &&
            schema.allOf.length === 1 &&
            schema.allOf[0].$ref === '#/definitions/Sku') {
          delete schema.allOf;            // make it stand-alone
        }
      }
      return $;
  
  - from: swagger-document
    where: $.definitions.Sku
    transform: return undefined;



  - from: ComputeRP.json
    where: $.definitions.Sku
    transform: >
      $ = {
        "properties": {
          "name": {
            "type": "string"
          },
          "tier": {
            "type": "string"
          },
          "capacity": {
            "type": "integer",
            "format": "int64"
          }
        }
      };
      return $;
  - from: DiskRP.json
    where: $.definitions.Sku
    transform: >
      $ = {
        "properties": {
          "name": {
            "type": "string"
          },
          "tier": {
            "type": "string"
          },
          "capacity": {
            "type": "integer",
            "format": "int64"
          }
        }
      };
      return $;
  - from: GalleryRP.json
    where: $.definitions.Sku
    transform: >
      $ = {
        "properties": {
          "name": {
            "type": "string"
          },
          "tier": {
            "type": "string"
          },
          "capacity": {
            "type": "integer",
            "format": "int64"
          }
        }
      };
      return $;


  - from-file: DiskRP.json
    rename-model:
      from: Sku
      to: DiskSku
  - from-file: skus.json
    rename-model:
      from: Sku
      to: SkusSku
  - from-file: GalleryRP.json                     # Compute Gallery
    rename-model:
      from: Sku
      to: GallerySku
  - from-file: common-types/v1/common.json        # compute/common-types
    rename-model:
      from: Sku
      to: ComputeCommonSku
  - from-file: common-types/resource-management/v3/types.json    # ARM shared
    rename-model:
      from: Sku
      to: ArmCommonSku
  - from-file: common-types/resource-management/v1/common.json
    rename-model:
      from: Sku
      to: ArmCommonSkuv1
      # Cloud Service RP
  - from-file: cloudService.json
    rename-model:
      from: Sku
      to: CloudServiceSku  # cloud-service specific

 -->

