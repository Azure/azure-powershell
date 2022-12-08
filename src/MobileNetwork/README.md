<!-- region Generated -->
# Az.MobileNetwork
This directory contains the PowerShell module for the MobileNetwork service.

---
## Status
[![Az.MobileNetwork](https://img.shields.io/powershellgallery/v/Az.MobileNetwork.svg?style=flat-square&label=Az.MobileNetwork "Az.MobileNetwork")](https://www.powershellgallery.com/packages/Az.MobileNetwork/)

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
For information on how to develop for `Az.MobileNetwork`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: 63adf8a58565b729f70895b65aa7d1333b22d15f
require:
  - $(this-folder)/../readme.azure.noprofile.md 
input-file:
  - $(repo)/specification/mobilenetwork/resource-manager/Microsoft.MobileNetwork/stable/2022-11-01/attachedDataNetwork.json
  - $(repo)/specification/mobilenetwork/resource-manager/Microsoft.MobileNetwork/stable/2022-11-01/common.json
  - $(repo)/specification/mobilenetwork/resource-manager/Microsoft.MobileNetwork/stable/2022-11-01/dataNetwork.json
  - $(repo)/specification/mobilenetwork/resource-manager/Microsoft.MobileNetwork/stable/2022-11-01/mobileNetwork.json
  - $(repo)/specification/mobilenetwork/resource-manager/Microsoft.MobileNetwork/stable/2022-11-01/operation.json
  - $(repo)/specification/mobilenetwork/resource-manager/Microsoft.MobileNetwork/stable/2022-11-01/packetCoreControlPlane.json
  - $(repo)/specification/mobilenetwork/resource-manager/Microsoft.MobileNetwork/stable/2022-11-01/packetCoreDataPlane.json
  - $(repo)/specification/mobilenetwork/resource-manager/Microsoft.MobileNetwork/stable/2022-11-01/service.json
  - $(repo)/specification/mobilenetwork/resource-manager/Microsoft.MobileNetwork/stable/2022-11-01/sim.json
  - $(repo)/specification/mobilenetwork/resource-manager/Microsoft.MobileNetwork/stable/2022-11-01/simGroup.json
  - $(repo)/specification/mobilenetwork/resource-manager/Microsoft.MobileNetwork/stable/2022-11-01/simPolicy.json
  - $(repo)/specification/mobilenetwork/resource-manager/Microsoft.MobileNetwork/stable/2022-11-01/site.json
  - $(repo)/specification/mobilenetwork/resource-manager/Microsoft.MobileNetwork/stable/2022-11-01/slice.json
  - $(repo)/specification/mobilenetwork/resource-manager/Microsoft.MobileNetwork/stable/2022-11-01/ts29571.json

module-version: 0.1.0
title: MobileNetwork
subject-prefix: $(service-name)

resourcegroup-append: true
identity-correction-for-post: true
nested-object-to-string: true

directive:
  - from: swagger-document 
    where: $.definitions
    transform: delete $.CoreNetworkTypeRm
  - from: swagger-document 
    where: $.definitions
    transform: delete $.PduSessionTypeRm

  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$|^BulkViaIdentity$|^Bulk$|^Collect$|^CollectViaIdentity$
    remove: true

  - where:
      verb: Set
    remove: true
  - where:
      subject: ^AttachedDataNetworkTag$
    set:
      subject: AttachedDataNetwork
  - where:
      subject: ^DataNetworkTag$
    set:
      subject: DataNetwork
  - where:
      subject: ^PacketCoreControlPlaneTag$
    set:
      subject: PacketCoreControlPlane
  - where:
      subject: ^PacketCoreDataPlaneTag$
    set:
      subject: PacketCoreDataPlane
  - where:
      subject: ^ServiceTag$
    set:
      subject: Service
  - where:
      subject: ^SimGroupTag$
    set:
      subject: SimGroup
  - where:
      subject: ^SimPolicyTag$
    set:
      subject: SimPolicy
  - where:
      subject: ^SiteTag$
    set:
      subject: Site
  - where:
      subject: ^SlouseTag$
    set:
      subject: Slouse
  - where:
      subject: ^MobileNetworkTag$
    set:
      subject: MobileNetwork
  - where:
      subject: ^Slouse$
    set:
      subject: Slice

  - where:
      verb: Invoke
      subject: ^BulkSimDelete$
    set:
      verb: Remove
  - where:
      verb: Invoke
      subject: ^BulkSimUpload$
    set:
      verb: Update
  - where:
      verb: Invoke
      subject: ^BulkSimUploadEncrypted$
    set:
      verb: Update
  - where:
      verb: Invoke
      subject: ^CollectPacketCoreControlPlaneDiagnosticPackage$
    set:
      verb: Update
  - where:
      verb: Invoke
      subject: ^ReinstallPacketCoreControlPlane$
    set:
      verb: Reset
  - where:
      verb: Invoke
      subject: ^RollbackPacketCoreControlPlane$
    set:
      verb: Revoke

  # The following are commented out and their generated cmdlets may be renamed and custom logic
#   - model-cmdlet:
#       - SimNameAndEncryptedProperties
#       - SimNameAndProperties
#       - SliceConfiguration
#       - DataNetworkConfiguration
#       - ServiceResourceId
#       - SiteResourceId
#       - SimStaticIPProperties
#       - PccRuleConfiguration
#       - ServiceDataFlowTemplate

```
