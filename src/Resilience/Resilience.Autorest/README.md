<!-- region Generated -->
# Az.Resilience
This directory contains the PowerShell module for the Resilience service.

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
For information on how to develop for `Az.Resilience`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
# pin the swagger version by using the commit id instead of branch name
commit: ff379f4dd3298fbe3c77a8bf75bf1f52b4e48387
tag: package-2026-08-31-preview
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/azureresiliencemanagement/resource-manager/Microsoft.AzureResilienceManagement/AzureResilienceManagement/preview/2026-08-31-preview/openapi.json

root-module-name: $(prefix).Resilience
title: Resilience
module-version: 0.1.0
service-name: Resilience
subject-prefix: Resilience

directive:
  # REQUIRED TO COMPILE - not a style choice. autorest.powershell 4.0.758 mis-generates
  # the discriminated DrillProperties subtypes from the flattened errorDetails property,
  # emitting colliding ErrorDetail / ErrorDetails members on RegionalDrillProperties and
  # ZonalDrillProperties that fail to satisfy IDrillProperties (CS0738/CS0535/CS9333/CS0539).
  # The property is readOnly; failure detail still surfaces via the operation error response.
  - from: swagger-document
    where: $.definitions.DrillProperties.properties
    transform: >-
      delete $["errorDetails"];

  # Action-style POSTs normalize onto a single subject per operation group, so their
  # differing request bodies collide on one -Body parameter and Export-ProxyCmdlet
  # fails with "The parameter 'Body' has multiple parameter types". Give each action
  # its own subject and an approved verb so each becomes a distinct cmdlet.
  - from: swagger-document
    where: $.paths.*.post
    transform: >-
      const rename = {
        RecoveryPlanActions_CheckReadiness: 'RecoveryPlanReadiness_Test',
        RecoveryPlanActions_Failover: 'RecoveryPlanFailover_Invoke',
        RecoveryPlanActions_FailoverCommit: 'RecoveryPlanFailoverCommit_Invoke',
        RecoveryPlanActions_Finalize: 'RecoveryPlanFinalize_Invoke',
        RecoveryPlanActions_Reprotect: 'RecoveryPlanReprotect_Invoke',
        RecoveryPlanActions_TestFailover: 'RecoveryPlanTestFailover_Invoke',
        RecoveryPlanActions_TestFailoverCleanup: 'RecoveryPlanTestFailoverCleanup_Invoke',
        RecoveryPlanActions_UpdateResources: 'RecoveryPlanResource_Update',
        RecoveryPlanActions_ValidateForFailover: 'RecoveryPlanFailoverValidation_Test',
        RecoveryPlanActions_ValidateForFailoverCommit: 'RecoveryPlanFailoverCommitValidation_Test',
        RecoveryPlanActions_ValidateForOperation: 'RecoveryPlanOperationValidation_Test',
        RecoveryPlanActions_ValidateForReprotect: 'RecoveryPlanReprotectValidation_Test',
        RecoveryPlanActions_ValidateForTestFailover: 'RecoveryPlanTestFailoverValidation_Test',
        RecoveryPlanActions_ValidateForTestFailoverCleanup: 'RecoveryPlanTestFailoverCleanupValidation_Test',
        Drills_AddOrUpdateResources: 'DrillResource_Update',
        Drills_End: 'Drill_Stop',
        Drills_ResyncReadinessCheck: 'DrillReadiness_Sync',
        Drills_ValidateForExecution: 'DrillExecutionValidation_Test',
        DrillRuns_AddNotes: 'DrillRunNote_Add',
        DrillRuns_FailOver: 'DrillRunFailover_Invoke',
        DrillRuns_GenerateReport: 'DrillRunReport_New',
        DrillRuns_ListReportDownloadUrl: 'DrillRunReportDownloadUrl_Get',
        DrillRuns_MarkAsComplete: 'DrillRun_Complete',
        DrillRuns_Reprotect: 'DrillRunReprotect_Invoke',
        DrillRuns_Resume: 'DrillRun_Resume',
        GoalAssignments_RecommendCapacity: 'GoalAssignmentCapacity_Get',
        GoalAssignments_RefreshGoalResources: 'GoalResource_Sync',
        GoalAssignments_UpdateGoalResources: 'GoalResource_Update'
      };
      if (rename[$.operationId]) { $.operationId = rename[$.operationId]; }

  # A `_Invoke` operation maps to verb Invoke but autorest also leaves Invoke on the
  # subject, yielding Invoke-AzResilienceInvokeRecoveryPlanFailover. Strip the duplicate.
  - where:
      subject: ^Invoke(?<name>.*)$
    set:
      subject: $<name>

  # RecoveryJobs_Retry has no approved-verb mapping, so autorest falls back to
  # Invoke with `Retry` absorbed into the subject. Reorder for consistency with
  # the other Invoke-AzResilience<Resource><Action> cmdlets.
  - where:
      subject: ^RetryRecoveryJob$
    set:
      subject: RecoveryJobRetry

  # UsagePlans has both a by-subscription and a by-resource-group list. AutoRest
  # strips the trailing PascalCase words when deriving the variant name, so both
  # collapse to `_List` and the second is forced to an opaque `_List1`.
  - where:
      verb: Get
      subject: UsagePlan
      variant: List1
    set:
      variant: ListByResourceGroup
```
