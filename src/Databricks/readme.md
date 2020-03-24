<!-- region Generated -->
# Az.Databricks
This directory contains the PowerShell module for the Databricks service.

---
## Status
[![Az.Databricks](https://img.shields.io/powershellgallery/v/Az.Databricks.svg?style=flat-square&label=Az.Databricks "Az.Databricks")](https://www.powershellgallery.com/packages/Az.Databricks/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 1.7.2 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.Databricks`, see [how-to.md](how-to.md).
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
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/databricks/resource-manager/Microsoft.Databricks/stable/2018-04-01/databricks.json

module-version: 0.0.1
title: Databricks
subject-prefix: $(service-name)

inlining-threshold: 40

directive:
  # Fix the error in swagger, RP actually returns 200 when deletion succeeds
  - from: swagger-document
    where: $
    transform: return $.replace(/204/g, "200")
  # Remove the unexpanded parameter set
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  # Rename the parameter name to follow Azure PowerShell best practice
  - where:
      parameter-name: SkuName
    set:
      parameter-name: Sku
  - where:
      parameter-name: CustomVirtualNetworkIdValue
    set:
      parameter-name: VirtualNetworkId
  - where:
      parameter-name: CustomPublicSubnetNameValue
    set:
      parameter-name: PublicSubnetName
  - where:
      parameter-name: CustomPrivateSubnetNameValue
    set:
      parameter-name: PrivateSubnetName
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  # Hide the New-* cmdlet for customization
  - where:
      verb: New
    hide: true
  - where:
      model-name: Workspace
    set:
      format-table:
        properties:
          - Name
          - Location
          - ManagedResourceGroupId
        labels:
          ManagedResourceGroupId: Managed Resource Group ID
```
