<!-- region Generated -->
# Az.DedicatedHsm
This directory contains the PowerShell module for the DedicatedHsm service.

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
For information on how to develop for `Az.DedicatedHsm`, see [how-to.md](how-to.md).
<!-- endregion -->

---
## Generation Requirements
Use of the beta version of `autorest.powershell` generator requires the following:
- [NodeJS LTS](https://nodejs.org) (10.15.x LTS preferred)
  - **Note**: It *will not work* with Node < 10.x. Using 11.x builds may cause issues as they may introduce instability or breaking changes.
> If you want an easy way to install and update Node, [NVS - Node Version Switcher](../nodejs/installing-via-nvs.md) or [NVM - Node Version Manager](../nodejs/installing-via-nvm.md) is recommended.
- [AutoRest](https://aka.ms/autorest) v3 beta <br>`npm install -g autorest@autorest`<br>&nbsp;
- PowerShell 6.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g pwsh`<br>&nbsp;
- .NET Core SDK 2.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g dotnet-sdk-2.2`<br>&nbsp;

## Run Generation
In this directory, run AutoRest:
> `autorest-beta`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
  - $(this-folder)/../../readme.azure.noprofile.md
commit: f203c1b73639b7e2f85aa96902cfe36c6dd2ffad
input-file:
  - $(repo)/specification/hardwaresecuritymodules/resource-manager/Microsoft.HardwareSecurityModules/stable/2021-11-30/dedicatedhsm.json

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: DedicatedHsm
subject-prefix: $(service-name)

# If there are post APIs for some kinds of actions in the RP, you may need to
# uncomment following line to support viaIdentity for these post APIs
# identity-correction-for-post: true

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

  # Circular reference in `Error` model
  - no-inline:
    - Error

  # Rename parameters to follow design guideline
  - where:
      parameter-name: SkuName
    set:
      parameter-name: Sku
  - where:
      parameter-name: NetworkProfileNetworkInterface
    set:
      parameter-name: NetworkInterface
  - where:
      parameter-name: NetworkProfileSubnetId
    set:
      parameter-name: SubnetId
  - where:
      parameter-name: ManagementNetworkProfileNetworkInterface
    set:
      parameter-name: ManagementNetworkInterface

  - where:
      parameter-name: ManagementNetworkProfileSubnetId
    set:
      parameter-name: ManagementSubnetId
  # Service team asked us to use 2018-10-31, should be the same as 2018-10-31-preview, but it's not ready on swagger yet
  # - from: swagger-document
  #   where: $.info
  #   transform: $['version'] = '2018-10-31'

  # table format
  - where:
      model-name: DedicatedHsm
    set:
      format-table:
        properties:
          - Name
          - ProvisioningState
          - SkuName
          - Location
        labels:
          ProvisioningState: Provisioning State
          SkuName: SKU
```
