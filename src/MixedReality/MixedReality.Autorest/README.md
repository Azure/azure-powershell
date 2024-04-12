<!-- region Generated -->
# Az.MixedReality
This directory contains the PowerShell module for the MixedReality service.

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
For information on how to develop for `Az.MixedReality`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: a0c83df51e02f4e0b21ff3ae72c5a1ac52f72586
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/mixedreality/resource-manager/Microsoft.MixedReality/preview/2021-03-01-preview/common.json
  - $(repo)/specification/mixedreality/resource-manager/Microsoft.MixedReality/preview/2021-03-01-preview/proxy.json
  - $(repo)/specification/mixedreality/resource-manager/Microsoft.MixedReality/preview/2021-03-01-preview/spatial-anchors.json
  - $(repo)/specification/mixedreality/resource-manager/Microsoft.MixedReality/preview/2021-03-01-preview/remote-rendering.json
  - $(repo)/specification/mixedreality/resource-manager/Microsoft.MixedReality/preview/2021-03-01-preview/object-anchors.json

title: MixedReality
module-version: 0.2.0
subject-prefix: $(service-name)

identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  - from: swagger-document 
    where: $.definitions.AccountKeyRegenerateRequest.properties.serial
    transform: >-
      return {
          "type": "integer",
          "format": "int32",
          "enum": [
            1,
            2
          ],
          "default": 1
      }
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  - where:
      variant: ^Check$|^CheckViaIdentity$|^Regenerate$|^RegenerateViaIdentity$
    remove: true
  - where:
      verb: Test
      subject: ^NameAvailabilityLocal$
    set:
      subject: NameAvailability
  - where:
      subject: ^SpatialAnchorAccount$
    set:
      subject: SpatialAnchorsAccount
  - where:
      subject: ^ObjectAnchorAccount$
    set:
      subject: ObjectAnchorsAccount
  - where:
      subject: ^SpatialAnchorAccountKey$
    set:
      subject: SpatialAnchorsAccountKey
  - where:
      subject: ^ObjectAnchorAccountKey$
    set:
      subject: ObjectAnchorsAccountKey
  - where:
      subject: SpatialAnchorsAccount
      parameter-name: AccountName
    set:
      parameter-name: Name
  - where:
      subject: ObjectAnchorsAccount
      parameter-name: AccountName
    set:
      parameter-name: Name
  - where:
      subject: RemoteRenderingAccount
      parameter-name: AccountName
    set:
      parameter-name: Name
```
