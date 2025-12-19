<!-- region Generated -->
# Az.Datadog
This directory contains the PowerShell module for the Datadog service.

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
For information on how to develop for `Az.Datadog`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: 84298cdc6b918812b002cc2ba05df0ec23f4e352
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file: 
  - $(repo)/specification/datadog/resource-manager/Microsoft.Datadog/stable/2025-06-11/datadog.json
  
title: Datadog
module-version: 0.1.0
subject-prefix: Datadog

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
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      subject: MarketplaceAgreement
      variant: ^CreateViaIdentity$|^CreateViaIdentityExpanded$
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
      - model-name: FilteringTag
        cmdlet-name: New-AzDatadogFilteringTagObject
```
