# Overall
This directory contains the service clients of Az.Compute module.

## Run Generation
In this directory, run AutoRest:
```
$env:NODE_OPTIONS = "--max_old_space_size=8192"
autorest --reset
autorest --use:@microsoft.azure/autorest.csharp@2.3.90
autorest.cmd README.md --version=v2
```

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
csharp: true
clear-output-folder: false
reflect-api-versions: true
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION

title: ComputeManagementClient
payload-flattening-threshold: 1


commit: f8d5ec7433a099628286e1b912e94ad599510680
input-file: 
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2024-11-01/ComputeRP.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/DiskRP/stable/2024-03-02/DiskRP.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/GalleryRP/stable/2024-03-03/GalleryRP.json

output-folder: Generated
namespace: Microsoft.Azure.Management.Compute


directive:
  # Update OrchestrationServiceNames enum consistently
  - from: ComputeRP.json
    where: $.definitions.OrchestrationServiceNames
    transform: |
      if ($.enum && $.enum.length === 1 && $.enum[0] === "AutomaticRepairs") {
        // Add to enum array
        $.enum.push('DummyOrchestrationServiceName');
        
        // Make sure x-ms-enum exists and has a values property
        if (!$['x-ms-enum']) {
          $['x-ms-enum'] = { name: "OrchestrationServiceNames", modelAsString: true };
        }
        
        if (!$['x-ms-enum'].values) {
          $['x-ms-enum'].values = [
            { value: "AutomaticRepairs", name: "AutomaticRepairs" }
          ];
        }
        
        // Add the new value to x-ms-enum.values
        $['x-ms-enum'].values.push({
          value: 'DummyOrchestrationServiceName',
          name: 'DummyOrchestrationServiceName'
        });
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

  # Override Operation definition
  - from: swagger-document
    where: $.definitions.Operation
    transform: |
      return {
        "type": "object",
        "properties": {}
      };

  # Remove all descriptions from the definitions in swagger document (optimized version)
  - from: swagger-document
    where: $.definitions
    transform: |
      // Non-recursive approach to prevent stack overflow
      const processObject = (obj) => {
        const queue = [{ obj, path: [] }];
        const processed = new WeakSet();
        
        while (queue.length > 0) {
          const { obj: current } = queue.shift();
          
          if (!current || typeof current !== 'object' || processed.has(current)) {
            continue;
          }
          
          processed.add(current);
          
          // Remove description
          if ('description' in current) {
            delete current.description;
          }
          
          // Add child objects to queue
          for (const key in current) {
            if (current[key] && typeof current[key] === 'object') {
              queue.push({ obj: current[key], path: [] });
            }
          }
        }
      };
      
      processObject($);
      return $;

  # Remove all descriptions from the parameters in swagger document
  - from: swagger-document
    where: $.parameters
    transform: >
      function removeParameterDescriptions(parameters) {
        if (!parameters || typeof parameters !== 'object') return parameters;
        
        for (const paramName in parameters) {
          const param = parameters[paramName];
          if (param && param.description !== undefined) {
            param.description = '';
          }
          
          // Handle schema if present
          if (param && param.schema && param.schema.description !== undefined) {
            param.schema.description = '';
          }
        }
        
        return parameters;
      }
      
      return removeParameterDescriptions($);

  # Remove descriptions from other common locations in the swagger document
  - from: swagger-document
    where: $.paths
    transform: >
      function removePathDescriptions(paths) {
        if (!paths || typeof paths !== 'object') return paths;
        
        for (const pathKey in paths) {
          const path = paths[pathKey];
          
          // Handle operations (get, post, put, delete, etc.)
          for (const opKey in path) {
            const operation = path[opKey];
            
            // Remove operation description
            if (operation.description !== undefined) {
              operation.description = '';
            }
            
            // Remove parameter descriptions
            if (operation.parameters && Array.isArray(operation.parameters)) {
              operation.parameters.forEach(param => {
                if (param.description !== undefined) {
                  param.description = '';
                }
              });
            }
            
            // Remove response descriptions
            if (operation.responses) {
              for (const respKey in operation.responses) {
                const response = operation.responses[respKey];
                if (response.description !== undefined) {
                  response.description = '';
                }
              }
            }
          }
        }
        
        return paths;
      }
      
      return removePathDescriptions($);

  # Fix for duplicate SubscriptionIdParameter
  - from: swagger-document
    where: $
    transform: |
      // Keep only one SubscriptionIdParameter definition
      if ($.parameters && $.parameters.SubscriptionIdParameter) {
        // Define our preferred version
        $.parameters.SubscriptionIdParameter = {
          "name": "subscriptionId",
          "in": "path",
          "required": true,
          "type": "string",
          "description": "The ID of the target subscription.",
          "minLength": 1
        };
      }
      return $;

  - from: swagger-document
    where: $..properties.type
    transform: |        
      if ($ && $["x-ms-enum"] && $["x-ms-enum"].name === "ResourceIdentityType") {
        // Ensure the enum values are consistent with the standard format
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

  # Fix for Operation.display.properties.description field type
  - from: swagger-document
    where: $.definitions.Operation.properties.display.properties.description
    transform: |
      // If description is an object, convert it to a string
      if ($ && typeof $ === 'object') {
        return { 
          "type": "string",
          "description": "Description of the operation."
        };
      }
      return $;

  # Fix for enums missing x-ms-enum name
  - from: swagger-document
    where: $..["x-ms-enum"]
    transform: |
      if (!$.name) {
        // Generate a unique name based on location in the document
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

  - from: swagger-document
    where: $.definitions.Sku
    transform: |
      return {
        "type": "object",
        "properties": {
          "name": {
            "type": "string",
            "description": "The sku name."
          },
          "tier": {
            "type": "string",
            "description": "Specifies the tier of virtual machines in a scale set."
          },
          "capacity": {
            "type": "integer",
            "format": "int64",
            "description": "Specifies the number of virtual machines in the scale set."
          }
        }
      };
      
  # Standardize OperatingSystemStateTypes definition
  - from: swagger-document
    where: $.definitions.OperatingSystemStateTypes
    transform: |
      return {
        "type": "string",
        "description": "This property allows the user to specify whether the virtual machines created under this image are 'Generalized' or 'Specialized'.",
        "enum": [
          "Generalized",
          "Specialized"
        ],
        "x-ms-enum": {
          "name": "OperatingSystemStateTypes",
          "modelAsString": false
        }
      };
  
  # Override Resource definition with the specific structure needed
  - from: swagger-document
    where: $.definitions.TrackedResource
    transform: |
      return {
        "type": "object",
        "description": "The Resource model definition.",
        "properties": {
          "id": {
            "readOnly": true,
            "type": "string",
            "description": "Resource Id"
          },
          "name": {
            "readOnly": true,
            "type": "string",
            "description": "Resource name"
          },
          "type": {
            "readOnly": true,
            "type": "string",
            "description": "Resource type"
          },
          "location": {
            "type": "string",
            "description": "Resource location"
          },
          "tags": {
            "type": "object",
            "additionalProperties": {
              "type": "string"
            },
            "description": "Resource tags"
          }
        },
        "required": [
          "location"
        ],
        "x-ms-azure-resource": true
      };
```