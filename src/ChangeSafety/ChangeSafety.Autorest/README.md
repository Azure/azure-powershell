<!-- region Generated -->
# Az.ChangeSafety
This directory contains the PowerShell module for the ChangeSafety service.

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
For information on how to develop for `Az.ChangeSafety`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
commit: RPSaaSMaster
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/changesafety/resource-manager/Microsoft.ChangeSafety/ChangeControl/preview/2026-01-01-preview/ChangeControl.json

module-version: 0.1.0
title: ChangeSafety
subject-prefix: $(service-name)

directive:
  # Following are common directives which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required
  - where:
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      variant: ^CreateViaIdentity.*$
    remove: true
  # Remove the Set-* cmdlet
  - where:
      verb: Set
    remove: true
  # Hide internal operations
  - where:
      subject: Operation
    hide: true
  # Default subscription parameter
  - where:
      parameter-name: SubscriptionId
    set:
      default:
        script: '(Get-AzContext).Subscription.Id'
  # Remove ChangeState and its child StageProgression cmdlets
  - where:
      subject: ChangeState.*
    remove: true
  - where:
      subject: ^StageProgression.*$
    remove: true
  # Remove Test-* cmdlets (VerifyChangeValidity POST operations)
  - where:
      verb: Test
    remove: true
  # Rename ChangeRecordStageProgression to StageProgression
  - where:
      subject: ChangeRecordStageProgression(.*)
    set:
      subject: StageProgression$1
  # Remove AuditTrail and NextStage cmdlets
  - where:
      subject: .*AuditTrail$
    remove: true
  - where:
      subject: .*NextStage$
    remove: true
```
