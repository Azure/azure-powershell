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
  - from: virtualMachineScaleSet.json
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
  - from: gallery.json
    where: $.definitions.GalleryTargetExtendedLocation.properties.storageAccountType["x-ms-enum"].name
    transform: return "EdgeZoneStorageAccountType"
```


### 
``` yaml
commit: b09c9ec927456021dc549e111fa2cac3b4b00659
input-file: 
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/common-types/v1/common.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2024-07-01/computeRPCommon.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2024-07-01/virtualMachineScaleSet.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2024-07-01/virtualMachine.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2024-07-01/virtualMachineImage.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2024-07-01/virtualMachineExtensionImage.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2024-07-01/availabilitySet.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2024-07-01/proximityPlacementGroup.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2024-07-01/dedicatedHost.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2024-07-01/sshPublicKey.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2024-07-01/image.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2024-07-01/restorePoint.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2024-07-01/capacityReservation.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2024-07-01/logAnalytic.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2024-07-01/runCommand.json 
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/DiskRP/stable/2024-03-02/diskRPCommon.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/DiskRP/stable/2024-03-02/disk.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/DiskRP/stable/2024-03-02/diskAccess.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/DiskRP/stable/2024-03-02/diskEncryptionSet.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/DiskRP/stable/2024-03-02/diskRestorePoint.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/DiskRP/stable/2024-03-02/snapshot.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/Skus/stable/2021-07-01/skus.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/GalleryRP/stable/2024-03-03/galleryRPCommon.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/GalleryRP/stable/2024-03-03/gallery.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/GalleryRP/stable/2024-03-03/sharedGallery.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/GalleryRP/stable/2024-03-03/communityGallery.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/compute/resource-manager/Microsoft.Compute/CloudserviceRP/stable/2022-09-04/cloudService.json

output-folder: Generated

namespace: Microsoft.Azure.Management.Compute
```