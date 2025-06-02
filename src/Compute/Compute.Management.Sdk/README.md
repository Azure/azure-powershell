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
  
  # Description updates for various definitions
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

  # Ensure VirtualMachineSizeListResult doesn't have nextLink property
  - from: swagger-document
    where: $.definitions.VirtualMachineSizeListResult
    transform: |
      if ($.properties && $.properties.nextLink) {
        delete $.properties.nextLink;
      }
      return $;
  - from: swagger-document
    where: $.definitions.DedicatedHostSizeListResult
    transform: |
      if ($.properties && $.properties.nextLink) {
        delete $.properties.nextLink;
      }
      return $;

  # Set x-ms-pageable to null for VirtualMachineSizes_List operation
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/vmSizes"].get
    transform: |
      if ($["x-ms-pageable"]) {
        $["x-ms-pageable"] = { "nextLinkName": null };
      }
      return $;

  # Set x-ms-pageable to null for VirtualMachines_ListAvailableSizes operation
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/vmSizes"].get
    transform: |
      if ($["x-ms-pageable"]) {
        $["x-ms-pageable"] = { "nextLinkName": null };
      }
      return $;
  
  # Set x-ms-pageable to null for AvailabilitySets_ListAvailableSizes operation
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/vmSizes"].get
    transform: |
      if ($["x-ms-pageable"]) {
        $["x-ms-pageable"] = { "nextLinkName": null };
      }
      return $;
  
  # Set x-ms-pageable to null for DedicatedHosts_ListAvailableSizes operation
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/hostGroups/{hostGroupName}/hosts/{hostName}/hostSizes"].get
    transform: |
      if ($["x-ms-pageable"]) {
        $["x-ms-pageable"] = { "nextLinkName": null };
      }
      return $;

  # Set x-ms-pageable to null for operations_list_ operation
  - from: swagger-document
    where: $.paths["/providers/Microsoft.Compute/operations"].get
    transform: |
      if ($["x-ms-pageable"]) {
        $["x-ms-pageable"] = { "nextLinkName": null };
      }
      return $;

  # Remove x-ms-client-name from VirtualMachineScaleSetExtension name property
  - from: swagger-document
    where: $.definitions.VirtualMachineScaleSetExtension.properties.name
    transform: |
      if ($["x-ms-client-name"]) {
        delete $["x-ms-client-name"];
      }
      return $;

  # Remove x-ms-client-name from VirtualMachineScaleSetExtension name property
  - from: swagger-document
    where: $.definitions.VirtualMachineScaleSetVMExtension.properties.name
    transform: |
      if ($["x-ms-client-name"]) {
        delete $["x-ms-client-name"];
      }
      return $;

  # Remove existing PassNames and ComponentNames definitions
  - from: swagger-document
    where: $.definitions
    transform: |
      // Delete existing definitions if they exist
      if ($.PassNames) {
        delete $.PassNames;
      }
      if ($.ComponentNames) {
        delete $.ComponentNames;
      }
      if ($.SettingNames) {
        delete $.SettingNames;
      }
      return $;

  # Remove PurchasePlan definitions
  - from: ComputeRP.json
    where: $.definitions
    transform: |
      // Delete existing definitions if they exist
      if ($.PurchasePlan) {
        delete $.PurchasePlan;
      }

  # Rename DiskPurchasePlan to PurchasePlan
  - from: DiskRP.json
    where: $.definitions
    transform: |
      if ($.DiskPurchasePlan) {
        $.PurchasePlan = $.DiskPurchasePlan;
        delete $.DiskPurchasePlan;
      }
      return $;
      
  # Update all references from DiskPurchasePlan to PurchasePlan
  - from: swagger-document
    where: $
    transform: |
      const traverse = (obj) => {
        if (obj === null || typeof obj !== 'object') return obj;
        
        if (obj.$ref === '#/definitions/DiskPurchasePlan') {
          obj.$ref = '#/definitions/PurchasePlan';
        }
        
        Object.keys(obj).forEach(key => {
          obj[key] = traverse(obj[key]);
        });
        
        return obj;
      };
      
      return traverse($);

  # Define AdditionalUnattendContent structure
  - from: swagger-document
    where: $.definitions
    transform: |
      $.AdditionalUnattendContent = {
        "type": "object",
        "description": "Specifies additional XML formatted information that can be included in the Unattend.xml file, which is used by Windows Setup. Contents are defined by setting name, component name, and the pass in which the content is applied.",
        "properties": {
          "passName": {
            "type": "string",
            "description": "The pass name. Currently, the only allowable value is OobeSystem.",
            "enum": [
              "OobeSystem"
            ],
            "x-ms-enum": {
              "name": "PassNames",
              "modelAsString": false
            },
            "x-nullable": true
          },
          "componentName": {
            "type": "string",
            "description": "The component name. Currently, the only allowable value is Microsoft-Windows-Shell-Setup.",
            "enum": [
              "Microsoft-Windows-Shell-Setup"
            ],
            "x-ms-enum": {
              "name": "ComponentNames",
              "modelAsString": false
            },
            "x-nullable": true
          },
          "settingName": {
            "type": "string",
            "description": "Specifies the name of the setting to which the content applies. Possible values are: FirstLogonCommands and AutoLogon.",
            "enum": [
              "AutoLogon",
              "FirstLogonCommands"
            ],
            "x-ms-enum": {
              "name": "SettingNames",
              "modelAsString": false
            }
          },
          "content": {
            "type": "string",
            "description": "Specifies the XML formatted content that is added to the unattend.xml file for the specified path and component. The XML must be less than 4KB and must include the root element for the setting or feature that is being inserted."
          }
        }
      };
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