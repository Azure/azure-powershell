# Overall
This directory contains the service clients of Az.Compute module.

## Run Generation
In this directory, run AutoRest:
```
.\Rest-api-specs\preprocess-rest-api-spec.ps1
autorest --reset
autorest --use:@autorest/powershell@4.x
```

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
isSdkGenerator: true
powershell: true
clear-output-folder: true
reflect-api-versions: true
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION

title: ComputeManagementClient
payload-flattening-threshold: 1

# Azure REST API Specs commit
commit: 5df56443d7ed2402adbea31f30eb68e71b469536

input-file: 
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/common-types/resource-management/v3/types.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/common-types/v1/common.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2025-04-01/ComputeRP.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/DiskRP/stable/2025-01-02/DiskRP.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/GalleryRP/stable/2025-03-03/GalleryRP.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/Skus/stable/2021-07-01/skus.json

output-folder: Generated
namespace: Microsoft.Azure.Management.Compute


directive:

  # Remove SystemData from Resource and TrackedResource definitions in swagger
  # This will make them generate with the old constructor signature
  - from: swagger-document
    where: $.definitions.Resource
    transform: |
      if ($.properties && $.properties.systemData) {
        delete $.properties.systemData;
      }
      if ($.allOf) {
        $.allOf = $.allOf.filter(item => !item.$ref || !item.$ref.includes('SystemData'));
      }
      return $;
      
  - from: swagger-document
    where: $.definitions.TrackedResource
    transform: |
      if ($.properties && $.properties.systemData) {
        delete $.properties.systemData;
      }
      if ($.allOf) {
        $.allOf = $.allOf.filter(item => !item.$ref || !item.$ref.includes('SystemData'));
      }
      return $;

  # Remove ResourceModelWithAllowedPropertySet from definitions - not used in Compute
  - from: swagger-document
    where: $.definitions
    transform: |
      if ($.ResourceModelWithAllowedPropertySet) {
        delete $.ResourceModelWithAllowedPropertySet;
      }
      return $;

  # Simplify 202 responses by removing headers for specific async operations
  # This matches the preprocessing script logic exactly
  - from: swagger-document
    where: $.paths
    transform: |
      const operationsToSimplify = [
        'AvailabilitySets_ConvertToVirtualMachineScaleSet',
        'CapacityReservations_Delete',
        'CapacityReservations_Update',
        'DedicatedHosts_Delete',
        'DiskAccesses_CreateOrUpdate',
        'DiskAccesses_Delete',
        'DiskAccesses_DeleteAPrivateEndpointConnection',
        'DiskAccesses_Update',
        'DiskAccesses_UpdateAPrivateEndpointConnection',
        'DiskEncryptionSets_CreateOrUpdate',
        'DiskEncryptionSets_Delete',
        'DiskEncryptionSets_Update',
        'DiskRestorePoint_GrantAccess',
        'DiskRestorePoint_RevokeAccess',
        'Disks_CreateOrUpdate',
        'Disks_Delete',
        'Disks_GrantAccess',
        'Disks_RevokeAccess',
        'Disks_Update',
        'Galleries_CreateOrUpdate',
        'Galleries_Delete',
        'GalleryApplicationVersions_CreateOrUpdate',
        'GalleryApplicationVersions_Delete',
        'GalleryApplications_CreateOrUpdate',
        'GalleryApplications_Delete',
        'GalleryImageVersions_CreateOrUpdate',
        'GalleryImageVersions_Delete',
        'GalleryImages_CreateOrUpdate',
        'GalleryImages_Delete',
        'GallerySharingProfile_Update',
        'Images_Delete',
        'LogAnalytics_ExportRequestRateByInterval',
        'LogAnalytics_ExportThrottledRequests',
        'RestorePointCollections_Delete',
        'RestorePoints_Delete',
        'Snapshots_CreateOrUpdate',
        'Snapshots_Delete',
        'Snapshots_GrantAccess',
        'Snapshots_RevokeAccess',
        'Snapshots_Update',
        'VirtualMachineExtensions_Delete',
        'VirtualMachineRunCommands_Delete',
        'VirtualMachineScaleSetExtensions_Delete',
        'VirtualMachineScaleSetRollingUpgrades_Cancel',
        'VirtualMachineScaleSetRollingUpgrades_StartExtensionUpgrade',
        'VirtualMachineScaleSetRollingUpgrades_StartOSUpgrade',
        'VirtualMachineScaleSetVMExtensions_Delete',
        'VirtualMachineScaleSetVMRunCommands_Delete',
        'VirtualMachineScaleSetVMs_Deallocate',
        'VirtualMachineScaleSetVMs_Delete',
        'VirtualMachineScaleSetVMs_PerformMaintenance',
        'VirtualMachineScaleSetVMs_PowerOff',
        'VirtualMachineScaleSetVMs_Redeploy',
        'VirtualMachineScaleSetVMs_Reimage',
        'VirtualMachineScaleSetVMs_ReimageAll',
        'VirtualMachineScaleSetVMs_Restart',
        'VirtualMachineScaleSetVMs_RunCommand',
        'VirtualMachineScaleSetVMs_Start',
        'VirtualMachineScaleSetVMs_Update',
        'VirtualMachineScaleSets_Deallocate',
        'VirtualMachineScaleSets_Delete',
        'VirtualMachineScaleSets_DeleteInstances',
        'VirtualMachineScaleSets_PerformMaintenance',
        'VirtualMachineScaleSets_PowerOff',
        'VirtualMachineScaleSets_Redeploy',
        'VirtualMachineScaleSets_Reimage',
        'VirtualMachineScaleSets_ReimageAll',
        'VirtualMachineScaleSets_Restart',
        'VirtualMachineScaleSets_SetOrchestrationServiceState',
        'VirtualMachineScaleSets_Start',
        'VirtualMachineScaleSets_UpdateInstances',
        'VirtualMachines_AssessPatches',
        'VirtualMachines_Capture',
        'VirtualMachines_ConvertToManagedDisks',
        'VirtualMachines_Deallocate',
        'VirtualMachines_Delete',
        'VirtualMachines_InstallPatches',
        'VirtualMachines_PerformMaintenance',
        'VirtualMachines_PowerOff',
        'VirtualMachines_Reapply',
        'VirtualMachines_Redeploy',
        'VirtualMachines_Reimage',
        'VirtualMachines_Restart',
        'VirtualMachines_RunCommand',
        'VirtualMachines_Start',
        'VirtualMachines_migrateToVMScaleSet'
      ];
      
      for (const path in $) {
        for (const method in $[path]) {
          if (typeof $[path][method] === 'object' && $[path][method].operationId) {
            const operationId = $[path][method].operationId;
            const response202 = $[path][method].responses && $[path][method].responses['202'];
            
            // Only modify if in the included list
            if (response202 && operationsToSimplify.includes(operationId)) {
              if (response202.headers) {
                delete response202.headers;
              }
              if (!response202.description) {
                response202.description = "Accepted";
              }
            }
          }
        }
      }
      return $;

  # Fix OS-related properties
  - where:
      property-name: OSType
    set:
      property-name: OsType
  - where:
      property-name: OSDisk
    set:
      property-name: OsDisk
  - where:
      property-name: OSState
    set:
      property-name: OsState
  - where:
      property-name: OSName
    set:
      property-name: OsName
  - where:
      property-name: OSVersion
    set:
      property-name: OsVersion
  - where:
      property-name: OSProfile
    set:
      property-name: OsProfile
  - where:
      property-name: OSDiskImage
    set:
      property-name: OsDiskImage
  - where:
      property-name: OSRollingUpgradeDeferral
    set:
      property-name: OsRollingUpgradeDeferral
  - where:
      property-name: OSImageNotificationProfile
    set:
      property-name: OsImageNotificationProfile
      
  # Fix VM-related properties
  - where:
      property-name: VMAgent
    set:
      property-name: VmAgent
  - where:
      property-name: VMHealth
    set:
      property-name: VmHealth
  - where:
      property-name: VMSize
    set:
      property-name: VmSize
  - where:
      property-name: VMSizes
    set:
      property-name: VmSizes
  - where:
      property-name: VMSizeProperties
    set:
      property-name: VmSizeProperties
  - where:
      property-name: VMUri
    set:
      property-name: VmUri
  - where:
      property-name: VMId
    set:
      property-name: VmId
  - where:
      property-name: VMAgentVersion
    set:
      property-name: VmAgentVersion
  - where:
      property-name: PrioritizeUnhealthyVMS
    set:
      property-name: PrioritizeUnhealthyVMs
  - where:
      property-name: AllocatableVMS
    set:
      property-name: AllocatableVMs
  - where:
      property-name: DoNotRunExtensionsOnOverprovisionedVms
    set:
      property-name: DoNotRunExtensionsOnOverprovisionedVMs
  - where:
      property-name: VirtualMachineScaleSetVMSOperations
    set:
      property-name: VirtualMachineScaleSetVMsOperations
      
  # Fix GB-related properties
  - where:
      property-name: DiskSizeGb
    set:
      property-name: DiskSizeGB
  - where:
      property-name: SizeInGb
    set:
      property-name: SizeInGB
      
  # Fix IOPS-related properties
  - where:
      property-name: DiskIopsReadWrite
    set:
      property-name: DiskIOPSReadWrite
  - where:
      property-name: DiskIopsReadOnly
    set:
      property-name: DiskIOPSReadOnly
      
  # Fix IP-related properties
  - where:
      property-name: IPConfigurations
    set:
      property-name: IpConfigurations
  - where:
      property-name: IPTags
    set:
      property-name: IpTags
  - where:
      property-name: IPTagType
    set:
      property-name: IpTagType
      
  # Fix other acronyms
  - where:
      property-name: VCpUs
    set:
      property-name: VCPUs
  - where:
      property-name: VCpUsAvailable
    set:
      property-name: VCPUsAvailable
  - where:
      property-name: VCpUsPerCore
    set:
      property-name: VCPUsPerCore
  - where:
      property-name: MeterId
    set:
      property-name: MeterID
  - where:
      property-name: WinRm
    set:
      property-name: WinRM
  - where:
      property-name: UltraSsdEnabled
    set:
      property-name: UltraSSDEnabled
  - where:
      property-name: PropertiesType
    set:
      property-name: VirtualMachineExtensionType
  - where:
      property-name: GetSecureVMGuestStateSas
    set:
      property-name: GetSecureVMGuestStateSAS
  - where:
      property-name: VMScaleSetEnabled
    set:
      property-name: VmScaleSetEnabled
  - where:
      property-name: AccessSas
    set:
      property-name: AccessSAS

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

  # Normalize PurchasePlan in ComputeRP.json
  - from: ComputeRP.json
    where: $.definitions.PurchasePlan
    transform: |
      if ($.required) {
        $.required = ["publisher", "name", "product"];
      }
      // Add promotionCode property to match DiskPurchasePlan
      if (!$.properties.promotionCode) {
        $.properties.promotionCode = {
          "type": "string",
          "description": "The Offer Promotion Code."
        };
      }
      return $;

  # Rename DiskPurchasePlan to PurchasePlan and normalize required fields
  - from: DiskRP.json
    where: $.definitions
    transform: |
      if ($.DiskPurchasePlan) {
        $.PurchasePlan = $.DiskPurchasePlan;
        // Normalize the required array order to match ComputeRP.json
        if ($.PurchasePlan.required) {
          $.PurchasePlan.required = ["publisher", "name", "product"];
        }
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
```