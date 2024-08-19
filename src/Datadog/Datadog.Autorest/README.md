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
commit: 2e3f1e0c67ee7da1d681a26b6b23b888ce856695
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file: 
  - $(repo)/specification/datadog/resource-manager/Microsoft.Datadog/stable/2021-03-01/datadog.json
  
title: Datadog
module-version: 0.1.0
subject-prefix: Datadog
nested-object-to-string: true
identity-correction-for-post: true

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

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
