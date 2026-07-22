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
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 5.3.2 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.ChangeSafety`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  # The private-preview contract is kept outside this generated directory so AutoRest
  # regeneration does not delete it. The canonical specification hierarchy is preserved
  # so relative "../../../../../../common-types/..." $refs resolve against the local copy.
  # Once the API is ready for public preview, publish the contract to
  # Azure/azure-rest-api-specs, generate from that canonical contract, and remove
  # src/ChangeSafety/spec.
  - $(this-folder)/../spec/specification/changesafety/resource-manager/Microsoft.ChangeSafety/ChangeControl/preview/2026-01-01-preview/ChangeControl.json

module-version: 0.1.0
title: ChangeSafety
subject-prefix: $(service-name)

directive:
  - from: swagger-document
    where: $.definitions.ChangeRecordProperties.properties.changeType.description
    transform: return "Describes the nature of the change. Allowed values are AppDeployment, Config, PolicyDeployment, ManualTouch."
  - from: swagger-document
    where: $.definitions.ChangeRecordPropertiesUpdate.properties.changeType.description
    transform: return "Describes the nature of the change. Allowed values are AppDeployment, Config, PolicyDeployment, ManualTouch."
  - from: swagger-document
    where: $.definitions.ChangeRecordProperties.properties.rolloutType.description
    transform: return "Describes the type of the rollout used for the change. Allowed values are Normal, Hotfix, Emergency."
  - from: swagger-document
    where: $.definitions.ChangeRecordPropertiesUpdate.properties.rolloutType.description
    transform: return "Describes the type of the rollout used for the change. Allowed values are Normal, Hotfix, Emergency."
  - from: swagger-document
    where: $.definitions.ChangeDefinition.properties.kind.description
    transform: return "Kind of the change definition. Allowed values are ApiOperations, Targets."
  - from: swagger-document
    where: $.definitions.ChangeDefinitionUpdate.properties.kind.description
    transform: return "Kind of the change definition. Allowed values are ApiOperations, Targets."
  - from: swagger-document
    where: $.definitions.ChangeRecordStageProgressionProperties.properties.status.description
    transform: return "StageProgression resource status. Allowed values are Initialized, InProgress, Completed, Cancelled, Paused, Failed, Skipped."
  - from: swagger-document
    where: $.definitions.ChangeRecordStageProgressionPropertiesUpdate.properties.status.description
    transform: return "StageProgression resource status. Allowed values are Initialized, InProgress, Completed, Cancelled, Paused, Failed, Skipped."
  # Following are common directives which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required
  - where:
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      variant: ^CreateViaIdentity.*$
    remove: true
  - where:
      subject: ^ChangeRecord$
      variant: ^GetViaIdentity$
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
  - where:
      subject: ^StageMap$
      variant: ^(GetViaIdentity|GetViaIdentity1|GetViaIdentityManagementGroup)$
    remove: true
  - where:
      subject: ^StageProgression$
      variant: ^(GetViaIdentity|GetViaIdentityChangeRecord|GetViaIdentityChangeRecord1)$
    remove: true
  # Remove AuditTrail and NextStage cmdlets
  - where:
      subject: .*AuditTrail$
    remove: true
  - where:
      subject: .*NextStage$
    remove: true
```
