<!-- region Generated -->
# Az.Resiliency
This directory contains the PowerShell module for the Resiliency service.

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
For information on how to develop for `Az.Resiliency`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name
commit: abfe7853f1382c8124b23be81984196102fd9343
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/azureresiliencemanagement/resource-manager/Microsoft.AzureResilienceManagement/AzureResilienceManagement/stable/2026-10-01/openapi.json

root-module-name: $(prefix).Resiliency
title: Resiliency
service-name: Resiliency
subject-prefix: Resiliency

directive:
  # REQUIRED TO COMPILE. autorest.powershell 4.0.758 mis-generates the discriminated
  # DrillProperties subtypes from the flattened errorDetails property, emitting colliding
  # ErrorDetail / ErrorDetails members on RegionalDrillProperties and ZonalDrillProperties
  # that fail to satisfy IDrillProperties (CS0738/CS0535/CS9333/CS0539). Renaming the
  # client-side property avoids the collision while keeping the error details on Drill.
  - from: swagger-document
    where: $.definitions.DrillProperties.properties.errorDetails
    transform: >-
      $["x-ms-client-name"] = "DrillErrorDetail";

  # The service returns planType on GET, but the spec marks it create-only
  # (x-ms-mutability: ["create"]). Without "read", the generated model never
  # deserializes it (.PlanType is null) and Update-AzResiliencyRecoveryPlan (GET+PUT)
  # sends a PUT without the required planType. Mark it readable, matching drillType.
  - from: swagger-document
    where: $.definitions.RecoveryPlanProperties.properties.planType
    transform: >-
      $["x-ms-mutability"] = ["read", "create"];

  # GoalAssignments PUT/PATCH declare final-state-via: location. When the initial
  # response has no Location header the generated final GET fails with
  # "Invalid URI: The URI is empty", and the PATCH Location target returns the
  # resource as a JSON string. Read the final state from the resource itself
  # (original-uri), as the Goals team recommends.
  - from: swagger-document
    where: $.paths["/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/goalAssignments/{goalAssignmentName}"][put,patch]
    transform: >-
      $["x-ms-long-running-operation-options"]["final-state-via"] = "original-uri";

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
  # subject, yielding Invoke-AzResiliencyInvokeRecoveryPlanFailover. Strip the duplicate.
  - where:
      subject: ^Invoke(?<name>.*)$
    set:
      subject: $<name>

  # RecoveryJobs_Retry has no approved-verb mapping, so autorest falls back to
  # Invoke with `Retry` absorbed into the subject. Reorder for consistency with
  # the other Invoke-AzResiliency<Resource><Action> cmdlets.
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

  # Set-AzResiliencyRecoveryPlan (PUT) declares -EnableSystemAssignedIdentity but
  # autorest.powershell 4.0.758 only wires that flag for New- and Update- cmdlets.
  # Set- therefore sends identity.type UserAssigned when -UserAssignedIdentity is
  # given (dropping the system-assigned identity) and no identity at all when only
  # -EnableSystemAssignedIdentity is given. The cmdlet is also redundant: New- creates
  # the plan, Update-AzResiliencyRecoveryPlan (GET+PUT) keeps the existing identity and
  # honours the flag, and Azure CLI has no equivalent. Remove Set-.
  - where:
      verb: Set
      subject: RecoveryPlan
    remove: true

  # Set-AzResiliencyGoalAssignment sends PUT, which the Goals service treats as
  # create-only (one goal assignment per service group): a PUT to an existing goal
  # assignment returns 400 RHUBUserErrorInvalidRequestParameter. New- creates it and
  # Update-AzResiliencyGoalAssignment (PATCH) updates it; Azure CLI likewise has only
  # create and update. Remove Set-.
  - where:
      verb: Set
      subject: GoalAssignment
    remove: true

  # Not supported by the service in this release; Azure CLI omits the same commands.
  - where:
      verb: Stop
      subject: RecoveryJob
    remove: true
  - where:
      verb: Invoke
      subject: RecoveryPlanFailoverCommit
    remove: true
  - where:
      verb: Test
      subject: RecoveryPlanFailoverCommitValidation
    remove: true
  - where:
      verb: Invoke
      subject: RecoveryPlanTestFailover
    remove: true
  - where:
      verb: Test
      subject: RecoveryPlanTestFailoverValidation
    remove: true
  - where:
      verb: Invoke
      subject: RecoveryPlanTestFailoverCleanup
    remove: true
  - where:
      verb: Test
      subject: RecoveryPlanTestFailoverCleanupValidation
    remove: true
```
