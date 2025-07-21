# Overall
This directory contains the service clients of Az.Compute module.

## Run Generation
In this directory, run AutoRest:
```
autorest --reset
autorest --use:@microsoft.azure/autorest.csharp@2.3.90 --memory:32g --node-options="--stack-size=8192"
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

commit: 21f9b6302bb5b6f647e1b4d716c684e1af3119a8
input-file: 
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2024-11-01/ComputeRP.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/DiskRP/stable/2025-01-02/DiskRP.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/GalleryRP/stable/2024-03-03/GalleryRP.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/common-types/v1/common.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/Skus/stable/2021-07-01/skus.json



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

  # Hard Code duplicate parameters 
  - from: swagger-document
    where: $.parameters
    transform: |
      $.SubscriptionIdParameter = {
        "name": "subscriptionId",
        "in": "path",
        "required": true,
        "type": "string",
        "description": "Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call."
      };
      $.ApiVersionParameter={
        "name": "api-version",
        "in": "query",
        "required": true,
        "type": "string",
        "description": "Client Api Version."
      };
      return $

  # Hard code duplicate definitions 
  - from: swagger-document
    where: $.definitions
    transform: |
      $.TrackedResource = {
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
      $.Sku = {
        "type": "object",
        "description": "Describes a virtual machine scale set sku. NOTE: If the new VM SKU is not supported on the hardware the scale set is currently on, you need to deallocate the VMs in the scale set before you modify the SKU name.",
        "properties": {
          "name": {
            "type": "string",
            "description": "The sku name."
          },
          "tier": {
            "type": "string",
            "description": "Specifies the tier of virtual machines in a scale set.<br /><br /> Possible Values:<br /><br /> **Standard**<br /><br /> **Basic**"
          },
          "capacity": {
            "type": "integer",
            "format": "int64",
            "description": "Specifies the number of virtual machines in the scale set."
          }
        }
      };
      $.Resource = {
        "type": "object",
        "title": "Resource",
        "description": "Common fields that are returned in the response for all Azure Resource Manager resources",
        "properties": {
          "id": {
            "type": "string",
            "description": "Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}",
            "readOnly": true
          },
          "name": {
            "type": "string",
            "description": "The name of the resource",
            "readOnly": true
          },
          "type": {
            "type": "string",
            "description": "The type of the resource. E.g. \"Microsoft.Compute/virtualMachines\" or \"Microsoft.Storage/storageAccounts\"",
            "readOnly": true
          }
        },
        "x-ms-azure-resource": true
      };
      $.Plan = {
        "type": "object",
        "description": "Plan for the resource.",
        "properties": {
          "name": {
            "type": "string",
            "description": "A user defined name of the 3rd Party Artifact that is being procured."
          },
          "publisher": {
            "type": "string",
            "description": "The publisher of the 3rd Party Artifact that is being bought. E.g. NewRelic"
          },
          "product": {
            "type": "string",
            "description": "The 3rd Party artifact that is being procured. E.g. NewRelic. Product maps to the OfferID specified for the artifact at the time of Data Market onboarding."
          },
          "promotionCode": {
            "type": "string",
            "description": "A publisher provided promotion code as provisioned in Data Market for the said product/artifact."
          },
          "version": {
            "type": "string",
            "description": "The version of the desired product/artifact."
          }
        },
        "required": [
          "name",
          "publisher",
          "product"
        ]
      };
      
      // Assign Identity dummy value
      $.Identity = {
        "type": "object",
        "description": "Identity for the resource.",
        "properties": {
          "principalId": {
            "type": "string",
            "description": "The principal ID of resource identity.",
            "readOnly": true
          },
          "tenantId": {
            "type": "string",
            "description": "The tenant ID of resource.",
            "readOnly": true
          }
        }
      };
      return $

  # Simplify 202 responses for specific operations
  - from: swagger-document
    where: $..paths.*.*
    transform: |
      const operationsToModify = [
        "AvailabilitySets_ConvertToVirtualMachineScaleSet",
        "CapacityReservations_Delete",
        "CapacityReservations_Update",
        "DedicatedHosts_Delete",
        "DiskAccesses_CreateOrUpdate",
        "DiskAccesses_Delete",
        "DiskAccesses_DeleteAPrivateEndpointConnection",
        "DiskAccesses_Update",
        "DiskAccesses_UpdateAPrivateEndpointConnection",
        "DiskEncryptionSets_CreateOrUpdate",
        "DiskEncryptionSets_Delete",
        "DiskEncryptionSets_Update",
        "DiskRestorePoint_GrantAccess",
        "DiskRestorePoint_RevokeAccess",
        "Disks_CreateOrUpdate",
        "Disks_Delete",
        "Disks_GrantAccess",
        "Disks_RevokeAccess",
        "Disks_Update",
        "Galleries_CreateOrUpdate",
        "Galleries_Delete",
        "GalleryApplicationVersions_CreateOrUpdate",
        "GalleryApplicationVersions_Delete",
        "GalleryApplications_CreateOrUpdate",
        "GalleryApplications_Delete",
        "GalleryImageVersions_CreateOrUpdate",
        "GalleryImageVersions_Delete",
        "GalleryImages_CreateOrUpdate",
        "GalleryImages_Delete",
        "GallerySharingProfile_Update",
        "Images_Delete",
        "LogAnalytics_ExportRequestRateByInterval",
        "LogAnalytics_ExportThrottledRequests",
        "RestorePointCollections_Delete",
        "RestorePoints_Delete",
        "Snapshots_CreateOrUpdate",
        "Snapshots_Delete",
        "Snapshots_GrantAccess",
        "Snapshots_RevokeAccess",
        "Snapshots_Update",
        "VirtualMachineExtensions_Delete",
        "VirtualMachineRunCommands_Delete",
        "VirtualMachineScaleSetExtensions_Delete",
        "VirtualMachineScaleSetRollingUpgrades_Cancel",
        "VirtualMachineScaleSetRollingUpgrades_StartExtensionUpgrade",
        "VirtualMachineScaleSetRollingUpgrades_StartOSUpgrade",
        "VirtualMachineScaleSetVMExtensions_Delete",
        "VirtualMachineScaleSetVMRunCommands_Delete",
        "VirtualMachineScaleSetVMs_Deallocate",
        "VirtualMachineScaleSetVMs_Delete",
        "VirtualMachineScaleSetVMs_PerformMaintenance",
        "VirtualMachineScaleSetVMs_PowerOff",
        "VirtualMachineScaleSetVMs_Redeploy",
        "VirtualMachineScaleSetVMs_Reimage",
        "VirtualMachineScaleSetVMs_ReimageAll",
        "VirtualMachineScaleSetVMs_Restart",
        "VirtualMachineScaleSetVMs_RunCommand",
        "VirtualMachineScaleSetVMs_Start",
        "VirtualMachineScaleSetVMs_Update",
        "VirtualMachineScaleSets_Deallocate",
        "VirtualMachineScaleSets_Delete",
        "VirtualMachineScaleSets_DeleteInstances",
        "VirtualMachineScaleSets_PerformMaintenance",
        "VirtualMachineScaleSets_PowerOff",
        "VirtualMachineScaleSets_Redeploy",
        "VirtualMachineScaleSets_Reimage",
        "VirtualMachineScaleSets_ReimageAll",
        "VirtualMachineScaleSets_Restart",
        "VirtualMachineScaleSets_SetOrchestrationServiceState",
        "VirtualMachineScaleSets_Start",
        "VirtualMachineScaleSets_UpdateInstances",
        "VirtualMachines_AssessPatches",
        "VirtualMachines_Capture",
        "VirtualMachines_ConvertToManagedDisks",
        "VirtualMachines_Deallocate",
        "VirtualMachines_Delete",
        "VirtualMachines_InstallPatches",
        "VirtualMachines_PerformMaintenance",
        "VirtualMachines_PowerOff",
        "VirtualMachines_Reapply",
        "VirtualMachines_Redeploy",
        "VirtualMachines_Reimage",
        "VirtualMachines_Restart",
        "VirtualMachines_RunCommand",
        "VirtualMachines_Start",
        "VirtualMachines_migrateToVMScaleSet"
      ];
      
      if ($.operationId && operationsToModify.includes($.operationId)) {
        if ($.responses && $.responses["202"]) {
          $.responses["202"] = {
            "description": "Accepted"
          };
        }
      }
      
      return $;

  # Simplify 202 responses for operations in x-ms-paths
  - from: swagger-document
    where: $["x-ms-paths"].*.*
    transform: |
      const operationsToModify = [
        "AvailabilitySets_ConvertToVirtualMachineScaleSet",
        "CapacityReservations_Delete",
        "CapacityReservations_Update",
        "DedicatedHosts_Delete",
        "DiskAccesses_CreateOrUpdate",
        "DiskAccesses_Delete",
        "DiskAccesses_DeleteAPrivateEndpointConnection",
        "DiskAccesses_Update",
        "DiskAccesses_UpdateAPrivateEndpointConnection",
        "DiskEncryptionSets_CreateOrUpdate",
        "DiskEncryptionSets_Delete",
        "DiskEncryptionSets_Update",
        "DiskRestorePoint_GrantAccess",
        "DiskRestorePoint_RevokeAccess",
        "Disks_CreateOrUpdate",
        "Disks_Delete",
        "Disks_GrantAccess",
        "Disks_RevokeAccess",
        "Disks_Update",
        "Galleries_CreateOrUpdate",
        "Galleries_Delete",
        "GalleryApplicationVersions_CreateOrUpdate",
        "GalleryApplicationVersions_Delete",
        "GalleryApplications_CreateOrUpdate",
        "GalleryApplications_Delete",
        "GalleryImageVersions_CreateOrUpdate",
        "GalleryImageVersions_Delete",
        "GalleryImages_CreateOrUpdate",
        "GalleryImages_Delete",
        "GallerySharingProfile_Update",
        "Images_Delete",
        "LogAnalytics_ExportRequestRateByInterval",
        "LogAnalytics_ExportThrottledRequests",
        "RestorePointCollections_Delete",
        "RestorePoints_Delete",
        "Snapshots_CreateOrUpdate",
        "Snapshots_Delete",
        "Snapshots_GrantAccess",
        "Snapshots_RevokeAccess",
        "Snapshots_Update",
        "VirtualMachineExtensions_Delete",
        "VirtualMachineRunCommands_Delete",
        "VirtualMachineScaleSetExtensions_Delete",
        "VirtualMachineScaleSetRollingUpgrades_Cancel",
        "VirtualMachineScaleSetRollingUpgrades_StartExtensionUpgrade",
        "VirtualMachineScaleSetRollingUpgrades_StartOSUpgrade",
        "VirtualMachineScaleSetVMExtensions_Delete",
        "VirtualMachineScaleSetVMRunCommands_Delete",
        "VirtualMachineScaleSetVMs_Deallocate",
        "VirtualMachineScaleSetVMs_Delete",
        "VirtualMachineScaleSetVMs_PerformMaintenance",
        "VirtualMachineScaleSetVMs_PowerOff",
        "VirtualMachineScaleSetVMs_Redeploy",
        "VirtualMachineScaleSetVMs_Reimage",
        "VirtualMachineScaleSetVMs_ReimageAll",
        "VirtualMachineScaleSetVMs_Restart",
        "VirtualMachineScaleSetVMs_RunCommand",
        "VirtualMachineScaleSetVMs_Start",
        "VirtualMachineScaleSetVMs_Update",
        "VirtualMachineScaleSets_Deallocate",
        "VirtualMachineScaleSets_Delete",
        "VirtualMachineScaleSets_DeleteInstances",
        "VirtualMachineScaleSets_PerformMaintenance",
        "VirtualMachineScaleSets_PowerOff",
        "VirtualMachineScaleSets_Redeploy",
        "VirtualMachineScaleSets_Reimage",
        "VirtualMachineScaleSets_ReimageAll",
        "VirtualMachineScaleSets_Restart",
        "VirtualMachineScaleSets_SetOrchestrationServiceState",
        "VirtualMachineScaleSets_Start",
        "VirtualMachineScaleSets_UpdateInstances",
        "VirtualMachines_AssessPatches",
        "VirtualMachines_Capture",
        "VirtualMachines_ConvertToManagedDisks",
        "VirtualMachines_Deallocate",
        "VirtualMachines_Delete",
        "VirtualMachines_InstallPatches",
        "VirtualMachines_PerformMaintenance",
        "VirtualMachines_PowerOff",
        "VirtualMachines_Reapply",
        "VirtualMachines_Redeploy",
        "VirtualMachines_Reimage",
        "VirtualMachines_Restart",
        "VirtualMachines_RunCommand",
        "VirtualMachines_Start",
        "VirtualMachines_migrateToVMScaleSet"
      ];
      
      if ($.operationId && operationsToModify.includes($.operationId)) {
        if ($.responses && $.responses["202"]) {
          $.responses["202"] = {
            "description": "Accepted"
          };
        }
      }
      
      return $;

  - from: swagger-document
    where: $.definitions.ExtendedLocationType
    transform: |
      return {
        "type": "string", 
        "description": "The type of extendedLocation.",
        "enum": [
          "EdgeZone"
        ],
        "x-ms-enum": {
          "name": "ExtendedLocationTypes",
          "modelAsString": true
        }
      };
```