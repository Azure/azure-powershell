<!-- region Generated -->
# Az.ResilienceManagement
This directory contains the PowerShell module for the Resilience service.

---
## Status
[![Az.ResilienceManagement](https://img.shields.io/powershellgallery/v/Az.ResilienceManagement.svg?style=flat-square&label=Az.ResilienceManagement "Az.ResilienceManagement")](https://www.powershellgallery.com/packages/Az.ResilienceManagement/)

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
For information on how to develop for `Az.ResilienceManagement`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
# NOTE: Swagger is still on krtcodee/azure-rest-api-specs branch krt/pwsh-cmd until it
# merges into Azure/azure-rest-api-specs. Once merged, replace `input-file` with a
# `commit:` pin + `$(repo)/specification/...` reference (see other modules).
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - https://raw.githubusercontent.com/krtcodee/azure-rest-api-specs/krt/pwsh-cmd/specification/azureresiliencemanagement/resource-manager/Microsoft.AzureResilienceManagement/AzureResilienceManagement/preview/2026-08-31-preview/openapi.json

root-module-name: $(prefix).ResilienceManagement
title: AzureResilienceManagement
module-version: 0.1.0
service-name: ResilienceManagement
subject-prefix: ResilienceManagement
identity-correction-for-post: true

directive:
  # Drop the unexpanded / JSON-only variants for Create/Update per Az conventions
  - where:
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      variant: ^CreateViaIdentityExpanded$
    remove: true

  # ---------------------------------------------------------------------
  # Swagger fix: DrillProperties.errorDetails breaks codegen (see prior
  # readme.powershell.md notes). Drop the flattened readOnly field.
  # ---------------------------------------------------------------------
  - from: swagger-document
    where: $.definitions.DrillProperties.properties
    transform: delete $["errorDetails"]

  # ---------------------------------------------------------------------
  # UsagePlans has two List endpoints (by-subscription, by-resource-group)
  # that collapse to the same variant `_List`. Give the second one a
  # distinct variant name.
  # ---------------------------------------------------------------------
  - where:
      verb: Get
      subject: UsagePlan
      variant: List1
    set:
      variant: ListByResourceGroup

  # ---------------------------------------------------------------------
  # RecoveryPlanActions has 11 POST endpoints under the same operation
  # group. Autorest tries to merge them into a single cmdlet whose -Body
  # parameter has ~11 different types, which Export-ProxyCmdlet refuses.
  #
  # Rename each operationId to give it a distinct subject so autorest
  # emits one cmdlet per action.
  # ---------------------------------------------------------------------
  # Action operations (each gets its own Invoke-* cmdlet)
  - from: swagger-document
    where: $.paths["/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{recoveryPlanName}/failover"].post
    transform: $.operationId = "RecoveryPlanFailover_Trigger";
  - from: swagger-document
    where: $.paths["/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{recoveryPlanName}/failoverCommit"].post
    transform: $.operationId = "RecoveryPlanFailoverCommit_Trigger";
  - from: swagger-document
    where: $.paths["/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{recoveryPlanName}/reprotect"].post
    transform: $.operationId = "RecoveryPlanReprotect_Trigger";
  - from: swagger-document
    where: $.paths["/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{recoveryPlanName}/testFailover"].post
    transform: $.operationId = "RecoveryPlanTestFailover_Trigger";
  - from: swagger-document
    where: $.paths["/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{recoveryPlanName}/testFailoverCleanup"].post
    transform: $.operationId = "RecoveryPlanTestFailoverCleanup_Trigger";

  # Validation operations
  - from: swagger-document
    where: $.paths["/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{recoveryPlanName}/validateForFailover"].post
    transform: $.operationId = "RecoveryPlanFailoverValidation_Validate";
  - from: swagger-document
    where: $.paths["/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{recoveryPlanName}/validateForFailoverCommit"].post
    transform: $.operationId = "RecoveryPlanFailoverCommitValidation_Validate";
  - from: swagger-document
    where: $.paths["/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{recoveryPlanName}/validateForOperation"].post
    transform: $.operationId = "RecoveryPlanOperationValidation_Validate";
  - from: swagger-document
    where: $.paths["/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{recoveryPlanName}/validateForReprotect"].post
    transform: $.operationId = "RecoveryPlanReprotectValidation_Validate";
  - from: swagger-document
    where: $.paths["/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{recoveryPlanName}/validateForTestFailover"].post
    transform: $.operationId = "RecoveryPlanTestFailoverValidation_Validate";
  - from: swagger-document
    where: $.paths["/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{recoveryPlanName}/validateForTestFailoverCleanup"].post
    transform: $.operationId = "RecoveryPlanTestFailoverCleanupValidation_Validate";

  # ---------------------------------------------------------------------
  # DrillRuns has FailOver + Reprotect endpoints — same collision pattern.
  # ---------------------------------------------------------------------
  - from: swagger-document
    where: $.paths["/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/drills/{drillName}/drillRuns/{drillRunName}/failOver"].post
    transform: $.operationId = "DrillRunFailover_Trigger";
  - from: swagger-document
    where: $.paths["/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/drills/{drillName}/drillRuns/{drillRunName}/reprotect"].post
    transform: $.operationId = "DrillRunReprotect_Trigger";
```
