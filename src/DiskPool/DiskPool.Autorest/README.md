<!-- region Generated -->
# Az.DiskPool
This directory contains the PowerShell module for the DiskPool service.

---
## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.7.5 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.DiskPool`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: 68acb8952caa568dc5c02d7ae4ca53d8356c9c0a
require:
  - $(this-folder)/../../readme.azure.noprofile.md
# lock the commit
input-file:
  - $(repo)/specification/storagepool/resource-manager/Microsoft.StoragePool/stable/2021-08-01/storagepool.json

module-version: 0.1.0
title: DiskPool
subject-prefix: $(service-name)
identity-correction-for-post: true 
nested-object-to-string: true
resourcegroup-append: true

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  # Rename StaticAcls -> StaticAcl
  - where:
      parameter-name: StaticAcls
    set:
      parameter-name: StaticAcl
  # Rename Invoke-AzDiskPoolDeallocateDiskPool -> Stop-AzDiskPool
  - where:
      verb: Invoke
      subject: DeallocateDiskPool
    set:
      verb: Stop
      subject-prefix: ''
      subject: DiskPool
  # Rename Upgrade-AzDiskPool -> Invoke-AzDiskPoolRedeployment
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.StoragePool/diskPools/{diskPoolName}/upgrade"].post.operationId
    transform: >-
      return "DiskPools_Redeploy"
  - where:
      verb: Invoke
      subject: RedeployDiskPool
    set:
      subject: Redeployment
  # Rename DiskPoolName -> Name in Stop-AzDiskPool
  - where:
      verb: Stop
      subject: DiskPool
      parameter-name: DiskPoolName
    set:
      parameter-name: Name
  # Change Disk <IDisk[]> to DiskId <String[]>
  - where:
      verb: New
      subject: DiskPool
    hide: true
  # Change Disk <IDisk[]> to DiskId <String[]>
  - where:
      verb: Update
      subject: DiskPool
    hide: true
  - model-cmdlet:
    - Acl
    - IscsiLun
  - where:
      model-name: DiskPoolZoneInfo
    set:
      format-table:
        properties:
          - SkuName
          - SkuTier
          - AvailabilityZone
          - AdditionalCapability
  - where:
      model-name: OutboundEnvironmentEndpoint
    set:
      format-table:
        properties:
          - Category
          - Endpoint
  - where:
      model-name: DiskPool 
    set:
      format-table:
        properties:
          - Name
          - ResourceGroupName
          - Location
          - Status
          - ProvisioningState
          - AvailabilityZone       
```
