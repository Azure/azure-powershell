---
Module Name: Az.Resilience
Module Guid: {{ Update Module Guid }}
Download Help Link: {{ Update Download Link }}
Help Version: {{ Update Help Version }}
Locale: {{ Update Locale }}
---

# Az.Resilience Module
## Description
{{ Fill in the Description }}

## Az.Resilience Cmdlets
### [Add-AzResilienceDrillRunNote](Add-AzResilienceDrillRunNote.md)
This enables the user to add notes on this Drill Run.

### [Complete-AzResilienceDrillRun](Complete-AzResilienceDrillRun.md)
This enables the user to mark this stage as complete, disabling further retries on it.

### [Get-AzResilienceDrill](Get-AzResilienceDrill.md)
Get a Drill

### [Get-AzResilienceDrillResource](Get-AzResilienceDrillResource.md)
Get a DrillResource

### [Get-AzResilienceDrillRun](Get-AzResilienceDrillRun.md)
Get a DrillRun

### [Get-AzResilienceDrillRunReportDownloadUrl](Get-AzResilienceDrillRunReportDownloadUrl.md)
This returns a short-lived, read-only URL to download the report for this Drill Run.
The URL expires at the returned expiryTimestamp and grants access to that single report only.

### [Get-AzResilienceDrillRunResource](Get-AzResilienceDrillRunResource.md)
Get a DrillRunResource

### [Get-AzResilienceEnrollment](Get-AzResilienceEnrollment.md)
Get an Enrollment.

### [Get-AzResilienceGoalAssignment](Get-AzResilienceGoalAssignment.md)
Get a GoalAssignment

### [Get-AzResilienceGoalAssignmentCapacity](Get-AzResilienceGoalAssignmentCapacity.md)
Recommends capacity improvements for resources under the goal assignments scope.
Returns AI-powered capacity assessments and recommendations.

### [Get-AzResilienceGoalResource](Get-AzResilienceGoalResource.md)
Get a GoalResource

### [Get-AzResilienceGoalTemplate](Get-AzResilienceGoalTemplate.md)
Get a GoalTemplate

### [Get-AzResilienceOperationStatus](Get-AzResilienceOperationStatus.md)
Returns the current status of an async operation.

### [Get-AzResilienceRecoveryJob](Get-AzResilienceRecoveryJob.md)
Get a RecoveryJob

### [Get-AzResilienceRecoveryJobResource](Get-AzResilienceRecoveryJobResource.md)
Get a RecoveryJobResource

### [Get-AzResilienceRecoveryPlan](Get-AzResilienceRecoveryPlan.md)
Get a RecoveryPlan

### [Get-AzResilienceRecoveryResource](Get-AzResilienceRecoveryResource.md)
Get a RecoveryResource

### [Get-AzResilienceUnifiedResilienceItem](Get-AzResilienceUnifiedResilienceItem.md)
Get a UnifiedResilienceItem

### [Get-AzResilienceUsagePlan](Get-AzResilienceUsagePlan.md)
Get a UsagePlan

### [Invoke-AzResilienceDrillRunFailover](Invoke-AzResilienceDrillRunFailover.md)
This initiates a new Failover operation on this Drill Run.

### [Invoke-AzResilienceDrillRunReprotect](Invoke-AzResilienceDrillRunReprotect.md)
This initiates a new Reprotect operation on this Drill Run.

### [Invoke-AzResilienceRecoveryJobRetry](Invoke-AzResilienceRecoveryJobRetry.md)
This action retries the ongoing recovery orchestration job for resources that failed in previous attempts.

### [Invoke-AzResilienceRecoveryPlanFailover](Invoke-AzResilienceRecoveryPlanFailover.md)
This action triggers the failover operation on the recovery orchestration plan for the qualified resources.

### [Invoke-AzResilienceRecoveryPlanFailoverCommit](Invoke-AzResilienceRecoveryPlanFailoverCommit.md)
This action triggers the failover commit operation on the recovery orchestration plan for the qualified resources.

### [Invoke-AzResilienceRecoveryPlanFinalize](Invoke-AzResilienceRecoveryPlanFinalize.md)
This action finalizes the recovery orchestration plan, ensuring all necessary configurations are in place.

### [Invoke-AzResilienceRecoveryPlanReprotect](Invoke-AzResilienceRecoveryPlanReprotect.md)
This action triggers the reprotect operation on the recovery orchestration plan for the qualified resources.

### [Invoke-AzResilienceRecoveryPlanTestFailover](Invoke-AzResilienceRecoveryPlanTestFailover.md)
This action triggers the test failover operation on the recovery orchestration plan for the qualified resources.

### [Invoke-AzResilienceRecoveryPlanTestFailoverCleanup](Invoke-AzResilienceRecoveryPlanTestFailoverCleanup.md)
This action triggers the test failover cleanup operation on the recovery orchestration plan for the qualified resources.

### [New-AzResilienceDrill](New-AzResilienceDrill.md)
Create a Drill

### [New-AzResilienceDrillRunReport](New-AzResilienceDrillRunReport.md)
This generates, or regenerates, the report for this Drill Run.
The action is idempotent and is safe to call at any time: a call that arrives while a generation is already running joins it, and a call made after a failed attempt retries it.
A report that has been finalized is never regenerated.

### [New-AzResilienceEnrollment](New-AzResilienceEnrollment.md)
Create an Enrollment.

### [New-AzResilienceGoalAssignment](New-AzResilienceGoalAssignment.md)
Create a GoalAssignment

### [New-AzResilienceGoalTemplate](New-AzResilienceGoalTemplate.md)
Create a GoalTemplate

### [New-AzResilienceRecoveryPlan](New-AzResilienceRecoveryPlan.md)
Create a RecoveryPlan

### [New-AzResilienceUsagePlan](New-AzResilienceUsagePlan.md)
Create a UsagePlan

### [Remove-AzResilienceDrill](Remove-AzResilienceDrill.md)
Delete a Drill

### [Remove-AzResilienceEnrollment](Remove-AzResilienceEnrollment.md)
Delete an Enrollment.

### [Remove-AzResilienceGoalAssignment](Remove-AzResilienceGoalAssignment.md)
Delete a GoalAssignment

### [Remove-AzResilienceGoalTemplate](Remove-AzResilienceGoalTemplate.md)
Delete a GoalTemplate

### [Remove-AzResilienceRecoveryPlan](Remove-AzResilienceRecoveryPlan.md)
Delete a RecoveryPlan

### [Remove-AzResilienceUsagePlan](Remove-AzResilienceUsagePlan.md)
Delete a UsagePlan

### [Resume-AzResilienceDrillRun](Resume-AzResilienceDrillRun.md)
This unblocks a Failover workflow that is paused after the Fault stage, to proceed to the Failover stage.

### [Resume-AzResilienceRecoveryJob](Resume-AzResilienceRecoveryJob.md)
This action resumes the ongoing recovery orchestration job that was paused for required user intervention.

### [Set-AzResilienceEnrollment](Set-AzResilienceEnrollment.md)
Update an Enrollment.

### [Set-AzResilienceGoalAssignment](Set-AzResilienceGoalAssignment.md)
Update a GoalAssignment

### [Set-AzResilienceGoalTemplate](Set-AzResilienceGoalTemplate.md)
Update a GoalTemplate

### [Set-AzResilienceRecoveryPlan](Set-AzResilienceRecoveryPlan.md)
Update a RecoveryPlan

### [Set-AzResilienceUsagePlan](Set-AzResilienceUsagePlan.md)
Update a UsagePlan

### [Start-AzResilienceDrill](Start-AzResilienceDrill.md)
This starts a new running instance of the Drill.

### [Stop-AzResilienceDrill](Stop-AzResilienceDrill.md)
This ends the currently running instance of the Drill.

### [Stop-AzResilienceRecoveryJob](Stop-AzResilienceRecoveryJob.md)
This action attempts to cancel the ongoing recovery orchestration job.

### [Sync-AzResilienceDrillReadiness](Sync-AzResilienceDrillReadiness.md)
This triggers detection of any drifts from the desired state of Resources and RBAC.

### [Sync-AzResilienceGoalResource](Sync-AzResilienceGoalResource.md)
Refreshes the goal resources under a goal assignment.
This operation scans for new resources under the scope of the assignment.

### [Test-AzResilienceDrillExecutionValidation](Test-AzResilienceDrillExecutionValidation.md)
This returns eligible resource to be faulted or failed over.

### [Test-AzResilienceRecoveryPlanFailoverCommitValidation](Test-AzResilienceRecoveryPlanFailoverCommitValidation.md)
This action checks if the recovery orchestration plan is eligible for failover commit operation, ensuring it meets the necessary criteria and provides a list of qualified and unqualified resources.

### [Test-AzResilienceRecoveryPlanFailoverValidation](Test-AzResilienceRecoveryPlanFailoverValidation.md)
This action checks if the recovery orchestration plan is eligible for failover operation, ensuring it meets the necessary criteria and provides a list of qualified and unqualified resources.

### [Test-AzResilienceRecoveryPlanOperationValidation](Test-AzResilienceRecoveryPlanOperationValidation.md)
This action checks if the recovery orchestration plan is eligible for operations like failover and reprotect, ensuring it meets the necessary criteria.

### [Test-AzResilienceRecoveryPlanReadiness](Test-AzResilienceRecoveryPlanReadiness.md)
This action performs the necessary readiness check on the recovery orchestration plan to ensure it is in the desired state and eligible for all recovery actions, including all protected resources.

### [Test-AzResilienceRecoveryPlanReprotectValidation](Test-AzResilienceRecoveryPlanReprotectValidation.md)
This action checks if the recovery orchestration plan is eligible for reprotect operation, ensuring it meets the necessary criteria and provides a list of qualified and unqualified resources.

### [Test-AzResilienceRecoveryPlanTestFailoverCleanupValidation](Test-AzResilienceRecoveryPlanTestFailoverCleanupValidation.md)
This action checks if the recovery orchestration plan is eligible for test failover cleanup operation, ensuring it meets the necessary criteria and provides a list of qualified and unqualified resources.

### [Test-AzResilienceRecoveryPlanTestFailoverValidation](Test-AzResilienceRecoveryPlanTestFailoverValidation.md)
This action checks if the recovery orchestration plan is eligible for test failover operation, ensuring it meets the necessary criteria and provides a list of qualified and unqualified resources.

### [Update-AzResilienceDrill](Update-AzResilienceDrill.md)
Update a Drill

### [Update-AzResilienceDrillResource](Update-AzResilienceDrillResource.md)
This enables the user to include, exclude or update resources from their Drill.

### [Update-AzResilienceEnrollment](Update-AzResilienceEnrollment.md)
Update an Enrollment.

### [Update-AzResilienceGoalAssignment](Update-AzResilienceGoalAssignment.md)
Update a GoalAssignment

### [Update-AzResilienceGoalResource](Update-AzResilienceGoalResource.md)
Action to exclude a resource from goal assignment.

### [Update-AzResilienceGoalTemplate](Update-AzResilienceGoalTemplate.md)
Update a GoalTemplate

### [Update-AzResilienceRecoveryPlan](Update-AzResilienceRecoveryPlan.md)
Update a RecoveryPlan

### [Update-AzResilienceRecoveryPlanResource](Update-AzResilienceRecoveryPlanResource.md)
This action adds or update the resources to be included in the recovery orchestration plan.

### [Update-AzResilienceUsagePlan](Update-AzResilienceUsagePlan.md)
Update a UsagePlan

