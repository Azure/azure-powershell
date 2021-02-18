<!-- region Generated -->
# Az.Blockchain
This directory contains the PowerShell module for the Blockchain service.

---
## Status
[![Az.Blockchain](https://img.shields.io/powershellgallery/v/Az.Blockchain.svg?style=flat-square&label=Az.Blockchain "Az.Blockchain")](https://www.powershellgallery.com/packages/Az.Blockchain/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 1.7.4 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.Blockchain`, see [how-to.md](how-to.md).
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
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/blockchain/resource-manager/Microsoft.Blockchain/preview/2018-06-01-preview/blockchain.json
module-version: 0.1.0
title: Blockchain
subject-prefix: 'Blockchain'

identity-correction-for-post: true

directive:
  - from: swagger-document
    where: $.paths..operationId
    transform: return $.replace(/ListRegenerateApiKeys$/, "RegenerateApiKeys")
  - from: swagger-document
    where: $
    transform: return $.replace(/locationName/g, "location")
  - where:
      subject: Operation
    hide: true
  - where:
      subject: LocationConsortium
    set:
      subject: Consortium
  - where:
      subject: BlockchainMemberOperationResult
    remove: true
  # Should use verb 'New' for the two RegenateApiKey related APIs
  - where:
      subject: BlockchainMemberRegenerateApiKey
      verb: Get
    set:
      verb: New
      subject: BlockchainMemberApiKey
  - where:
      subject: TransactionNodeRegenerateApiKey
      verb: Get
    set:
      verb: New
      subject: TransactionNodeApiKey
  # Drop the un-flattened parameter-set for Post/New/Set/Update related cmdlets.
  - where:
      subject: (.*)RegenerateApiKey$
      variant: List
    remove: true
  - where:
      verb: Update
      variant: ^Update$|^UpdateViaIdentity$
    remove: true
  - where:
      verb: New
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Regenerate$|^RegenerateViaIdentity$
    remove: true
  - where:
      verb: Test
      variant: ^Check$|^CheckViaIdentity$|^CheckViaIdentityExpanded$
    remove: true
  # Hide these two cmdlets, because we need to customize a version with password secured.
  - where:
      verb: New|Update
      subject: BlockchainMember
    hide: true
  - where:
      verb: New|Update
      subject: TransactionNode
    hide: true
  - where:
      parameter-name: SubscriptionId
    set:
      default:
        script: '(Get-AzContext).Subscription.Id'
```
