<!-- region Generated -->
# Az.DataDog
This directory contains the PowerShell module for the DataDog service.

---
## Status
[![Az.DataDog](https://img.shields.io/powershellgallery/v/Az.DataDog.svg?style=flat-square&label=Az.DataDog "Az.DataDog")](https://www.powershellgallery.com/packages/Az.DataDog/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.2.3 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.DataDog`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: 2e3f1e0c67ee7da1d681a26b6b23b888ce856695
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file: 
  - $(repo)/specification/datadog/resource-manager/Microsoft.Datadog/stable/2021-03-01/datadog.json
  
title: DataDog
module-version: 0.1.0
subject-prefix: $(service-name)
nested-object-to-string: true
identity-correction-for-post: true

directive:
  # Remove cmdlet.
  - where:
      verb: Set
      subject: MarketplaceAgreement
    remove: true

  - where:
      verb: Set
      subject: SingleSignOnConfiguration
    remove: true

  - where:
      verb: Set
      subject: TagRule
    remove: true

  # Remove variant
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$
      subject: MarketplaceAgreement
    remove: true

  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
      subject: Monitor
    remove: true

  - where:
      variant: ^Create$|^CreateViaIdentity$
      subject: SingleSignOnConfiguration
    remove: true

  - where:
      variant: ^Create$|^CreateViaIdentity$
      subject: TagRule
    remove: true

  - where:
      variant: ^Set$
      subject: MonitorDefaultKey
    remove: true

  # Rename parameter name
  - where:
      verb: Get|New|Update|Remove
      subject: MonitorApiKey|MonitorDefaultKey|MonitorHost|MonitorLinkedResource|MonitorMonitoredResource|MonitorSetPasswordLink
      parameter-name: MonitorName
    set:
      parameter-name: Name

  - where:
      verb: New
      subject: Monitor
      parameter-name: Datadog(.*)Property(.*)
    set:
      parameter-name: $1$2

  - where:
      verb: Set
      subject: MonitorDefaultKey
      parameter-name: Created
    set:
      parameter-name: CreatedAt

  - where:
      verb: Get|New|Update|Remove
      subject: TagRule
      parameter-name: RuleSetName
    set:
      parameter-name: Name

  - where:
      subject: SingleSignOnConfiguration
      parameter-name: ConfigurationName
    set:
      parameter-name: Name
  # For memory object that generate cmdlet.
  - model-cmdlet:
    - FilteringTag
```
