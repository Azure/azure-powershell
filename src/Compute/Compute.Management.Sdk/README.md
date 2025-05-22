# Overall
This directory contains the service clients of Az.Compute module.

## Run Generation
In this directory, run AutoRest:
```
.\Rest-api-specs\preprocess-rest-api-spec.ps1
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

input-file: 
  - ./Rest-api-specs/types.json
  - ./Rest-api-specs/common.json
  - ./Rest-api-specs/ComputeRP.json
  - ./Rest-api-specs/DiskRP.json
  - ./Rest-api-specs/GalleryRP.json
  - ./Rest-api-specs/skus.json

output-folder: Generated
namespace: Microsoft.Azure.Management.Compute


directive:


  - from: swagger-document
    where: $..definitions.OperatingSystemStateTypes
    transform: >
      $.description = "This property allows the user to specify whether the virtual machines created under this image are 'Generalized' or 'Specialized'.";
      $.type = "string";
      $.enum = ["Generalized", "Specialized"];
      $["x-ms-enum"] = { "name": "OperatingSystemStateTypes", "modelAsString": false };
  - from: swagger-document
    where: $..definitions.Architecture
    transform: >
      $.description = "The architecture of the image. Applicable to OS disks only.";
  - from: swagger-document
    where: $..definitions.ResourceIdentityType
    transform: >
      $.description = "The type of identity used for the virtual machine scale set. The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity and a set of user assigned identities. The type 'None' will remove any identities from the virtual machine scale set.";
  - from: swagger-document
    where: $..definitions.OperatingSystemTypes
    transform: >
      $.description = "The Operating System type.";
  - from: swagger-document
    where: $..definitions.HyperVGeneration
    transform: >
      $.description = "The hypervisor generation of the Virtual Machine [V1, V2]";
  - from: swagger-document
    where: $.securityDefinitions.azure_auth
    transform: >
      $["description"] = "Azure Active Directory OAuth2 Flow";
  - from: swagger-document
    where: $
    transform: >
      $.tags = [];

  # Set PassNames enum name
  - from: swagger-document
    where: $.definitions.PassNames
    transform: |
      $["x-ms-enum"].name = "PassNames";
      $["x-ms-enum"].modelAsString = false;
      return $;
  
  # Set ComponentNames enum name
  - from: swagger-document
    where: $.definitions.ComponentNames
    transform: |
      $["x-ms-enum"].name = "ComponentNames";
      $["x-ms-enum"].modelAsString = false;
      return $;

  # Rename TrackedResource definition to Resource
  - from: swagger-document
    where: $.definitions
    transform: |
      if ($.TrackedResource) {
        $.Resource = $.TrackedResource;
        delete $.TrackedResource;
      }
      return $;
      
  # Fix all references to TrackedResource
  - from: swagger-document
    where: $
    transform: |
      const traverse = (obj) => {
        if (obj === null || typeof obj !== 'object') return obj;
        
        if (obj.$ref === '#/definitions/TrackedResource') {
          obj.$ref = '#/definitions/Resource';
        }
        
        Object.keys(obj).forEach(key => {
          obj[key] = traverse(obj[key]);
        });
        
        return obj;
      };
      
      return traverse($);

  # Set PassNames as enum name for the enum containing OobeSystem
  - from: swagger-document
    where: $..["x-ms-enum"]
    transform: |
      if ($ && $.values && $.values.some(v => v.value === 'OobeSystem') && !$.name) {
        $.name = "PassNames";
      }
      return $;

  - from: swagger-document
    where: $..["x-ms-enum"]
    transform: |
      if ($ && $.values && $.values.some(v => v.value === 'Microsoft-Windows-Shell-Setup') && !$.name) {
        $.name = "ComponentNames";
      }
      return $;

  # Update OrchestrationServiceNames enum consistently
  - from: ComputeRP.json
    where: $.definitions.OrchestrationServiceNames
    transform: |
      if ($.enum && $.enum.length === 1 && $.enum[0] === "AutomaticRepairs") {
        // Add to enum array
        $.enum.push('DummyOrchestrationServiceName');
        
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
```