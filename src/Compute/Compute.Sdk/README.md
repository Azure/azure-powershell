# Overall
This directory contains the service clients of Az.Compute module.

## Run Generation
In this directory, run AutoRest:
```
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
```


### 
``` yaml 
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/504c68706d55cb11e0cd4e4265c2c9a218dd2378/specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2022-03-01/computeRPCommon.json
  - https://github.com/Azure/azure-rest-api-specs/blob/504c68706d55cb11e0cd4e4265c2c9a218dd2378/specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2022-03-01/virtualMachineScaleSet.json
  - https://github.com/Azure/azure-rest-api-specs/blob/504c68706d55cb11e0cd4e4265c2c9a218dd2378/specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2022-03-01/virtualMachine.json
  - https://github.com/Azure/azure-rest-api-specs/blob/504c68706d55cb11e0cd4e4265c2c9a218dd2378/specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2022-03-01/virtualMachineImage.json
  - https://github.com/Azure/azure-rest-api-specs/blob/504c68706d55cb11e0cd4e4265c2c9a218dd2378/specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2022-03-01/virtualMachineExtensionImage.json
  - https://github.com/Azure/azure-rest-api-specs/blob/504c68706d55cb11e0cd4e4265c2c9a218dd2378/specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2022-03-01/availabilitySet.json
  - https://github.com/Azure/azure-rest-api-specs/blob/504c68706d55cb11e0cd4e4265c2c9a218dd2378/specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2022-03-01/dedicatedHost.json
  - https://github.com/Azure/azure-rest-api-specs/blob/504c68706d55cb11e0cd4e4265c2c9a218dd2378/specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2022-03-01/sshPublicKey.json
  - https://github.com/Azure/azure-rest-api-specs/blob/504c68706d55cb11e0cd4e4265c2c9a218dd2378/specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2022-03-01/sshPublicKey.json
  - https://github.com/Azure/azure-rest-api-specs/blob/504c68706d55cb11e0cd4e4265c2c9a218dd2378/specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2022-03-01/runCommand.json
  - https://github.com/Azure/azure-rest-api-specs/blob/504c68706d55cb11e0cd4e4265c2c9a218dd2378/specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2022-03-01/proximityPlacementGroup.json
  - https://github.com/Azure/azure-rest-api-specs/blob/504c68706d55cb11e0cd4e4265c2c9a218dd2378/specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2022-03-01/image.json
  - https://github.com/Azure/azure-rest-api-specs/blob/504c68706d55cb11e0cd4e4265c2c9a218dd2378/specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2022-03-01/restorePoint.json
  - https://github.com/Azure/azure-rest-api-specs/blob/504c68706d55cb11e0cd4e4265c2c9a218dd2378/specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2022-03-01/capacityReservation.json
  - https://github.com/Azure/azure-rest-api-specs/blob/504c68706d55cb11e0cd4e4265c2c9a218dd2378/specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2022-03-01/logAnalytic.json
  - https://github.com/Azure/azure-rest-api-specs/blob/504c68706d55cb11e0cd4e4265c2c9a218dd2378/specification/compute/resource-manager/Microsoft.Compute/DiskRP/stable/2022-03-02/disk.json
  - https://github.com/Azure/azure-rest-api-specs/blob/504c68706d55cb11e0cd4e4265c2c9a218dd2378/specification/compute/resource-manager/Microsoft.Compute/DiskRP/stable/2022-03-02/diskAccess.json
  - https://github.com/Azure/azure-rest-api-specs/blob/504c68706d55cb11e0cd4e4265c2c9a218dd2378/specification/compute/resource-manager/Microsoft.Compute/DiskRP/stable/2022-03-02/diskRestorePoint.json
  - https://github.com/Azure/azure-rest-api-specs/blob/504c68706d55cb11e0cd4e4265c2c9a218dd2378/specification/compute/resource-manager/Microsoft.Compute/DiskRP/stable/2022-03-02/diskEncryptionSet.json
  - https://github.com/Azure/azure-rest-api-specs/blob/504c68706d55cb11e0cd4e4265c2c9a218dd2378/specification/compute/resource-manager/Microsoft.Compute/DiskRP/stable/2022-03-02/snapshot.json
  - https://github.com/Azure/azure-rest-api-specs/blob/504c68706d55cb11e0cd4e4265c2c9a218dd2378/specification/compute/resource-manager/Microsoft.Compute/GalleryRP/stable/2022-01-03/gallery.json
  - https://github.com/Azure/azure-rest-api-specs/blob/504c68706d55cb11e0cd4e4265c2c9a218dd2378/specification/compute/resource-manager/Microsoft.Compute/GalleryRP/stable/2022-01-03/sharedGallery.json
  - https://github.com/Azure/azure-rest-api-specs/blob/504c68706d55cb11e0cd4e4265c2c9a218dd2378/specification/compute/resource-manager/Microsoft.Compute/GalleryRP/stable/2022-01-03/communityGallery.json
  - https://github.com/Azure/azure-rest-api-specs/blob/504c68706d55cb11e0cd4e4265c2c9a218dd2378/specification/compute/resource-manager/Microsoft.Compute/Skus/stable/2021-07-01/skus.json

output-folder: Generated

namespace: Microsoft.Azure.Management.Compute
```