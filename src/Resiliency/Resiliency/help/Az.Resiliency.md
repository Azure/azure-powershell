---
Module Name: Az.Resiliency
Module Guid: accceef6-8113-453a-a31c-4f2ce57893d6
Download Help Link: https://learn.microsoft.com/powershell/module/az.resiliency
Help Version: 1.0.0.0
Locale: en-US
---

# Az.Resiliency Module
## Description
Microsoft Azure PowerShell: Resiliency cmdlets

## Az.Resiliency Cmdlets

## Onboarding

### [Get-AzResiliencyUsagePlan](Get-AzResiliencyUsagePlan.md)
Get a UsagePlan

### [New-AzResiliencyUsagePlan](New-AzResiliencyUsagePlan.md)
Create a UsagePlan

### [Set-AzResiliencyUsagePlan](Set-AzResiliencyUsagePlan.md)
Update a UsagePlan

### [Update-AzResiliencyUsagePlan](Update-AzResiliencyUsagePlan.md)
Update a UsagePlan

### [Remove-AzResiliencyUsagePlan](Remove-AzResiliencyUsagePlan.md)
Delete a UsagePlan

### [Get-AzResiliencyEnrollment](Get-AzResiliencyEnrollment.md)
Get an Enrollment.

### [New-AzResiliencyEnrollment](New-AzResiliencyEnrollment.md)
Create an Enrollment.

### [Set-AzResiliencyEnrollment](Set-AzResiliencyEnrollment.md)
Update an Enrollment.

### [Update-AzResiliencyEnrollment](Update-AzResiliencyEnrollment.md)
Update an Enrollment.

### [Remove-AzResiliencyEnrollment](Remove-AzResiliencyEnrollment.md)
Delete an Enrollment.

## Goal

### [Get-AzResiliencyGoalAssignment](Get-AzResiliencyGoalAssignment.md)
Gets a goal assignment.

### [New-AzResiliencyGoalAssignment](New-AzResiliencyGoalAssignment.md)
Create a goal assignment.

### [Set-AzResiliencyGoalAssignment](Set-AzResiliencyGoalAssignment.md)
Update a goal assignment.

### [Update-AzResiliencyGoalAssignment](Update-AzResiliencyGoalAssignment.md)
Update a goal assignment.

### [Remove-AzResiliencyGoalAssignment](Remove-AzResiliencyGoalAssignment.md)
Deletes a goal assignment.

### [Get-AzResiliencyGoalAssignmentCapacity](Get-AzResiliencyGoalAssignmentCapacity.md)
Recommends capacity improvements for resources under the goal assignment's scope.
Returns AI-powered capacity assessments and recommendations.

### [Get-AzResiliencyGoalResource](Get-AzResiliencyGoalResource.md)
Gets a goal resource.

### [Update-AzResiliencyGoalResource](Update-AzResiliencyGoalResource.md)
Update goal resources under a goal assignment.

### [Sync-AzResiliencyGoalResource](Sync-AzResiliencyGoalResource.md)
Refreshes the goal resources under a goal assignment.
This operation scans for new resources under the scope of the assignment.

## Drill

### [Get-AzResiliencyDrill](Get-AzResiliencyDrill.md)
Get a Drill

### [New-AzResiliencyDrill](New-AzResiliencyDrill.md)
Create a Drill

### [Update-AzResiliencyDrill](Update-AzResiliencyDrill.md)
Update a Drill

### [Remove-AzResiliencyDrill](Remove-AzResiliencyDrill.md)
Delete a Drill

### [Start-AzResiliencyDrill](Start-AzResiliencyDrill.md)
This starts a new running instance of the Drill.

### [Stop-AzResiliencyDrill](Stop-AzResiliencyDrill.md)
This ends the currently running instance of the Drill.

### [Test-AzResiliencyDrillExecutionValidation](Test-AzResiliencyDrillExecutionValidation.md)
This returns eligible resource to be faulted or failed over.

### [Sync-AzResiliencyDrillReadiness](Sync-AzResiliencyDrillReadiness.md)
This triggers detection of any drifts from the desired state of Resources and RBAC.

### [Get-AzResiliencyDrillResource](Get-AzResiliencyDrillResource.md)
Get a DrillResource

### [Update-AzResiliencyDrillResource](Update-AzResiliencyDrillResource.md)
This enables the user to include, exclude or update resources from their Drill.

### [Get-AzResiliencyDrillRun](Get-AzResiliencyDrillRun.md)
Get a DrillRun

### [Resume-AzResiliencyDrillRun](Resume-AzResiliencyDrillRun.md)
This unblocks a Failover workflow that is paused after the Fault stage, to proceed to the Failover stage.

### [Complete-AzResiliencyDrillRun](Complete-AzResiliencyDrillRun.md)
This enables the user to mark this stage as complete, disabling further retries on it.

### [Add-AzResiliencyDrillRunNote](Add-AzResiliencyDrillRunNote.md)
This enables the user to add notes on this Drill Run.

### [Invoke-AzResiliencyDrillRunFailover](Invoke-AzResiliencyDrillRunFailover.md)
This initiates a new Failover operation on this Drill Run.

### [Invoke-AzResiliencyDrillRunReprotect](Invoke-AzResiliencyDrillRunReprotect.md)
This initiates a new Reprotect operation on this Drill Run.

### [New-AzResiliencyDrillRunReport](New-AzResiliencyDrillRunReport.md)
This generates, or regenerates, the report for this Drill Run.
The action is idempotent and is safe to call at any time: a call that arrives while a generation is already running joins it, and a call made after a failed attempt retries it.
A report that has been finalized is never regenerated.

### [Get-AzResiliencyDrillRunReportDownloadUrl](Get-AzResiliencyDrillRunReportDownloadUrl.md)
This returns a short-lived, read-only URL to download the report for this Drill Run.
The URL expires at the returned expiryTimestamp and grants access to that single report only.

### [Get-AzResiliencyDrillRunResource](Get-AzResiliencyDrillRunResource.md)
Get a DrillRunResource

## Recovery Plan

### [Get-AzResiliencyRecoveryPlan](Get-AzResiliencyRecoveryPlan.md)
Get a RecoveryPlan

### [New-AzResiliencyRecoveryPlan](New-AzResiliencyRecoveryPlan.md)
Create a RecoveryPlan

### [Update-AzResiliencyRecoveryPlan](Update-AzResiliencyRecoveryPlan.md)
Update a RecoveryPlan

### [Remove-AzResiliencyRecoveryPlan](Remove-AzResiliencyRecoveryPlan.md)
Delete a RecoveryPlan

### [Test-AzResiliencyRecoveryPlanReadiness](Test-AzResiliencyRecoveryPlanReadiness.md)
This action performs the necessary readiness check on the recovery orchestration plan to ensure it is in the desired state and eligible for all recovery actions, including all protected resources.

### [Test-AzResiliencyRecoveryPlanOperationValidation](Test-AzResiliencyRecoveryPlanOperationValidation.md)
This action checks if the recovery orchestration plan is eligible for operations like failover and reprotect, ensuring it meets the necessary criteria.

### [Update-AzResiliencyRecoveryPlanResource](Update-AzResiliencyRecoveryPlanResource.md)
This action adds or update the resources to be included in the recovery orchestration plan.

### [Test-AzResiliencyRecoveryPlanFailoverValidation](Test-AzResiliencyRecoveryPlanFailoverValidation.md)
This action checks if the recovery orchestration plan is eligible for failover operation, ensuring it meets the necessary criteria and provides a list of qualified and unqualified resources.

### [Invoke-AzResiliencyRecoveryPlanFailover](Invoke-AzResiliencyRecoveryPlanFailover.md)
This action triggers the failover operation on the recovery orchestration plan for the qualified resources.

### [Test-AzResiliencyRecoveryPlanFailoverCommitValidation](Test-AzResiliencyRecoveryPlanFailoverCommitValidation.md)
This action checks if the recovery orchestration plan is eligible for failover commit operation, ensuring it meets the necessary criteria and provides a list of qualified and unqualified resources.

### [Invoke-AzResiliencyRecoveryPlanFailoverCommit](Invoke-AzResiliencyRecoveryPlanFailoverCommit.md)
This action triggers the failover commit operation on the recovery orchestration plan for the qualified resources.

### [Test-AzResiliencyRecoveryPlanReprotectValidation](Test-AzResiliencyRecoveryPlanReprotectValidation.md)
This action checks if the recovery orchestration plan is eligible for reprotect operation, ensuring it meets the necessary criteria and provides a list of qualified and unqualified resources.

### [Invoke-AzResiliencyRecoveryPlanReprotect](Invoke-AzResiliencyRecoveryPlanReprotect.md)
This action triggers the reprotect operation on the recovery orchestration plan for the qualified resources.

### [Invoke-AzResiliencyRecoveryPlanFinalize](Invoke-AzResiliencyRecoveryPlanFinalize.md)
This action finalizes the recovery orchestration plan, ensuring all necessary configurations are in place.

### [Test-AzResiliencyRecoveryPlanTestFailoverValidation](Test-AzResiliencyRecoveryPlanTestFailoverValidation.md)
This action checks if the recovery orchestration plan is eligible for test failover operation, ensuring it meets the necessary criteria and provides a list of qualified and unqualified resources.

### [Invoke-AzResiliencyRecoveryPlanTestFailover](Invoke-AzResiliencyRecoveryPlanTestFailover.md)
This action triggers the test failover operation on the recovery orchestration plan for the qualified resources.

### [Test-AzResiliencyRecoveryPlanTestFailoverCleanupValidation](Test-AzResiliencyRecoveryPlanTestFailoverCleanupValidation.md)
This action checks if the recovery orchestration plan is eligible for test failover cleanup operation, ensuring it meets the necessary criteria and provides a list of qualified and unqualified resources.

### [Invoke-AzResiliencyRecoveryPlanTestFailoverCleanup](Invoke-AzResiliencyRecoveryPlanTestFailoverCleanup.md)
This action triggers the test failover cleanup operation on the recovery orchestration plan for the qualified resources.

### [Get-AzResiliencyRecoveryResource](Get-AzResiliencyRecoveryResource.md)
Get a RecoveryResource

### [Get-AzResiliencyRecoveryJob](Get-AzResiliencyRecoveryJob.md)
Get a RecoveryJob

### [Stop-AzResiliencyRecoveryJob](Stop-AzResiliencyRecoveryJob.md)
This action attempts to cancel the ongoing recovery orchestration job.

### [Resume-AzResiliencyRecoveryJob](Resume-AzResiliencyRecoveryJob.md)
This action resumes the ongoing recovery orchestration job that was paused for required user intervention.

### [Invoke-AzResiliencyRecoveryJobRetry](Invoke-AzResiliencyRecoveryJobRetry.md)
This action retries the ongoing recovery orchestration job for resources that failed in previous attempts.

### [Get-AzResiliencyRecoveryJobResource](Get-AzResiliencyRecoveryJobResource.md)
Get a RecoveryJobResource

## Shared

### [Get-AzResiliencyUnifiedResilienceItem](Get-AzResiliencyUnifiedResilienceItem.md)
Get a UnifiedResilienceItem

### [Get-AzResiliencyOperationStatus](Get-AzResiliencyOperationStatus.md)
Returns the current status of an async operation.
