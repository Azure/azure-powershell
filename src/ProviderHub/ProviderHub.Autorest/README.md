<!-- region Generated -->
# Az.ProviderHub
This directory contains the PowerShell module for the ProviderHub service.

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
For information on how to develop for `Az.ProviderHub`, see [how-to.md](how-to.md).
<!-- endregion -->

---
## Generation Requirements
Use of the beta version of `autorest.powershell` generator requires the following:
- [NodeJS LTS](https://nodejs.org) (10.15.x LTS preferred)
  - **Note**: It *will not work* with Node < 10.x. Using 11.x builds may cause issues as they may introduce instability or breaking changes.
> If you want an easy way to install and update Node, [NVS - Node Version Switcher](../nodejs/installing-via-nvs.md) or [NVM - Node Version Manager](../nodejs/installing-via-nvm.md) is recommended.
- [AutoRest](https://aka.ms/autorest) v3 beta <br>`npm install -g autorest@beta`<br>&nbsp;
- PowerShell 6.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g pwsh`<br>&nbsp;
- .NET Core SDK 2.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g dotnet-sdk-2.2`<br>&nbsp;

## Run Generation
In this directory, run AutoRest:
> `autorest`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: 0dd49a444195fef7f3555cad038cb7665cbd928c
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/providerhub/resource-manager/Microsoft.ProviderHub/stable/2020-11-20/providerhub.json

module-version: 0.1.0
title: ProviderHub
subject-prefix: $(service-name)

directive:
  - from: swagger-document
    where: $.definitions.Error.properties
    transform: delete $.innerError
  - from: swagger-document
    where: $.definitions.FeaturesRule.properties
    transform: >-
      return {
        "requiredFeaturesPolicy": {
          "type": "string"
        }
      }
  - no-inline:
    - Error
  - where:
      variant: ^(Create|Update|Manifest)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      variant: ^ManifestViaIdentityExpanded$|^CreateViaIdentityExpanded$
    remove: true
  - where:
      verb: Set
    remove: true

# Hide commands to use Custom
  - where:
      verb: Get|New|Remove
      subject: ResourceTypeRegistration
    hide: true
  - where:
      verb: Get|New|Remove
      subject: Sku
    hide: true
  - where:
      verb: Get|New|Remove
      subject: SkuNestedResourceTypeFirst
    hide: true
  - where:
      verb: Get|New|Remove
      subject: SkuNestedResourceTypeSecond
    hide: true
  - where:
      verb: Get|New|Remove|Update
      subject: SkuNestedResourceTypeThird
    hide: true
  - where:
      verb: New
      subject: ProviderRegistrationOperation
    hide: true
```
