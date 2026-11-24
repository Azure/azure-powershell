---
Module Name: Az.ResilienceManagement
Module Guid: 2e268496-8c82-49e6-9984-4457b9fab0ee
Download Help Link: https://learn.microsoft.com/powershell/module/az.resiliencemanagement
Help Version: 1.0.0.0
Locale: en-US
---

# Az.ResilienceManagement Module
## Description
Microsoft Azure PowerShell: Resilience cmdlets

## Az.ResilienceManagement Cmdlets
### [Add-AzResilienceManagementDrillResource](Add-AzResilienceManagementDrillResource.md)
This enables the user to include, exclude or update resources from their Drill.

### [Add-AzResilienceManagementDrillRunNote](Add-AzResilienceManagementDrillRunNote.md)
This enables the user to add notes on this Drill Run.

### [Get-AzResilienceManagementDrill](Get-AzResilienceManagementDrill.md)
Get a Drill

### [Get-AzResilienceManagementDrillResource](Get-AzResilienceManagementDrillResource.md)
Get a DrillResource

### [Get-AzResilienceManagementDrillRun](Get-AzResilienceManagementDrillRun.md)
Get a DrillRun

### [Get-AzResilienceManagementDrillRunReportDownloadUrl](Get-AzResilienceManagementDrillRunReportDownloadUrl.md)
This returns a short-lived, read-only URL to download the report for this Drill Run.
The URL expires at the returned expiryTimestamp and grants access to that single report only.

### [Get-AzResilienceManagementDrillRunResource](Get-AzResilienceManagementDrillRunResource.md)
Get a DrillRunResource

### [Get-AzResilienceManagementEnrollment](Get-AzResilienceManagementEnrollment.md)
Get an Enrollment.

### [Get-AzResilienceManagementGoalAssignment](Get-AzResilienceManagementGoalAssignment.md)
Get a GoalAssignment

### [Get-AzResilienceManagementGoalResource](Get-AzResilienceManagementGoalResource.md)
Get a GoalResource

### [Get-AzResilienceManagementGoalTemplate](Get-AzResilienceManagementGoalTemplate.md)
Get a GoalTemplate

### [Get-AzResilienceManagementOperationStatus](Get-AzResilienceManagementOperationStatus.md)
Returns the current status of an async operation.

### [Get-AzResilienceManagementRecoveryJob](Get-AzResilienceManagementRecoveryJob.md)
Get a RecoveryJob

### [Get-AzResilienceManagementRecoveryJobResource](Get-AzResilienceManagementRecoveryJobResource.md)
Get a RecoveryJobResource

### [Get-AzResilienceManagementRecoveryPlan](Get-AzResilienceManagementRecoveryPlan.md)
Get a RecoveryPlan

### [Get-AzResilienceManagementRecoveryResource](Get-AzResilienceManagementRecoveryResource.md)
Get a RecoveryResource

### [Get-AzResilienceManagementUnifiedResilienceItem](Get-AzResilienceManagementUnifiedResilienceItem.md)
Get a UnifiedResilienceItem

### [Get-AzResilienceManagementUsagePlan](Get-AzResilienceManagementUsagePlan.md)
Get a UsagePlan

### [Invoke-AzResilienceManagementFinalizeRecoveryPlanAction](Invoke-AzResilienceManagementFinalizeRecoveryPlanAction.md)
This action finalizes the recovery orchestration plan, ensuring all necessary configurations are in place.

### [Invoke-AzResilienceManagementMarkDrillRunAsComplete](Invoke-AzResilienceManagementMarkDrillRunAsComplete.md)
This enables the user to mark this stage as complete, disabling further retries on it.

### [Invoke-AzResilienceManagementRecommendGoalAssignmentCapacity](Invoke-AzResilienceManagementRecommendGoalAssignmentCapacity.md)
Recommends capacity improvements for resources under the goal assignments scope.
Returns AI-powered capacity assessments and recommendations.

### [Invoke-AzResilienceManagementRetryRecoveryJob](Invoke-AzResilienceManagementRetryRecoveryJob.md)
This action retries the ongoing recovery orchestration job for resources that failed in previous attempts.

### [New-AzResilienceManagementDrill](New-AzResilienceManagementDrill.md)
Create a Drill

### [New-AzResilienceManagementDrillRunReport](New-AzResilienceManagementDrillRunReport.md)
This generates, or regenerates, the report for this Drill Run.
The action is idempotent and is safe to call at any time: a call that arrives while a generation is already running joins it, and a call made after a failed attempt retries it.
A report that has been finalized is never regenerated.

### [New-AzResilienceManagementEnrollment](New-AzResilienceManagementEnrollment.md)
Create an Enrollment.

### [New-AzResilienceManagementGoalAssignment](New-AzResilienceManagementGoalAssignment.md)
Create a GoalAssignment

### [New-AzResilienceManagementGoalTemplate](New-AzResilienceManagementGoalTemplate.md)
Create a GoalTemplate

### [New-AzResilienceManagementRecoveryPlan](New-AzResilienceManagementRecoveryPlan.md)
Create a RecoveryPlan

### [New-AzResilienceManagementUsagePlan](New-AzResilienceManagementUsagePlan.md)
Create a UsagePlan

### [Remove-AzResilienceManagementDrill](Remove-AzResilienceManagementDrill.md)
Delete a Drill

### [Remove-AzResilienceManagementEnrollment](Remove-AzResilienceManagementEnrollment.md)
Delete an Enrollment.

### [Remove-AzResilienceManagementGoalAssignment](Remove-AzResilienceManagementGoalAssignment.md)
Delete a GoalAssignment

### [Remove-AzResilienceManagementGoalTemplate](Remove-AzResilienceManagementGoalTemplate.md)
Delete a GoalTemplate

### [Remove-AzResilienceManagementRecoveryPlan](Remove-AzResilienceManagementRecoveryPlan.md)
Delete a RecoveryPlan

### [Remove-AzResilienceManagementUsagePlan](Remove-AzResilienceManagementUsagePlan.md)
Delete a UsagePlan

### [Resume-AzResilienceManagementDrillRun](Resume-AzResilienceManagementDrillRun.md)
This unblocks a Failover workflow that is paused after the Fault stage, to proceed to the Failover stage.

### [Resume-AzResilienceManagementRecoveryJob](Resume-AzResilienceManagementRecoveryJob.md)
This action resumes the ongoing recovery orchestration job that was paused for required user intervention.

### [Set-AzResilienceManagementEnrollment](Set-AzResilienceManagementEnrollment.md)
Create an Enrollment.

### [Set-AzResilienceManagementGoalAssignment](Set-AzResilienceManagementGoalAssignment.md)
Create a GoalAssignment

### [Set-AzResilienceManagementGoalTemplate](Set-AzResilienceManagementGoalTemplate.md)
Create a GoalTemplate

### [Set-AzResilienceManagementRecoveryPlan](Set-AzResilienceManagementRecoveryPlan.md)
Create a RecoveryPlan

### [Set-AzResilienceManagementUsagePlan](Set-AzResilienceManagementUsagePlan.md)
Create a UsagePlan

### [Start-AzResilienceManagementDrill](Start-AzResilienceManagementDrill.md)
This starts a new running instance of the Drill.

### [Start-AzResilienceManagementDrillRunFailover](Start-AzResilienceManagementDrillRunFailover.md)
This initiates a new Failover operation on this Drill Run.

### [Start-AzResilienceManagementDrillRunReprotect](Start-AzResilienceManagementDrillRunReprotect.md)
This initiates a new Reprotect operation on this Drill Run.

### [Start-AzResilienceManagementRecoveryPlanFailover](Start-AzResilienceManagementRecoveryPlanFailover.md)
This action triggers the failover operation on the recovery orchestration plan for the qualified resources.

### [Start-AzResilienceManagementRecoveryPlanFailoverCommit](Start-AzResilienceManagementRecoveryPlanFailoverCommit.md)
This action triggers the failover commit operation on the recovery orchestration plan for the qualified resources.

### [Start-AzResilienceManagementRecoveryPlanReprotect](Start-AzResilienceManagementRecoveryPlanReprotect.md)
This action triggers the reprotect operation on the recovery orchestration plan for the qualified resources.

### [Start-AzResilienceManagementRecoveryPlanTestFailover](Start-AzResilienceManagementRecoveryPlanTestFailover.md)
This action triggers the test failover operation on the recovery orchestration plan for the qualified resources.

### [Start-AzResilienceManagementRecoveryPlanTestFailoverCleanup](Start-AzResilienceManagementRecoveryPlanTestFailoverCleanup.md)
This action triggers the test failover cleanup operation on the recovery orchestration plan for the qualified resources.

### [Stop-AzResilienceManagementDrill](Stop-AzResilienceManagementDrill.md)
This ends the currently running instance of the Drill.

### [Stop-AzResilienceManagementRecoveryJob](Stop-AzResilienceManagementRecoveryJob.md)
This action attempts to cancel the ongoing recovery orchestration job.

### [Test-AzResilienceManagementDrill](Test-AzResilienceManagementDrill.md)
This returns eligible resource to be faulted or failed over.

### [Test-AzResilienceManagementDrillResyncReadiness](Test-AzResilienceManagementDrillResyncReadiness.md)
This triggers detection of any drifts from the desired state of Resources and RBAC.

### [Test-AzResilienceManagementRecoveryPlanActionReadiness](Test-AzResilienceManagementRecoveryPlanActionReadiness.md)
This action performs the necessary readiness check on the recovery orchestration plan to ensure it is in the desired state and eligible for all recovery actions, including all protected resources.

### [Test-AzResilienceManagementRecoveryPlanFailoverCommitValidation](Test-AzResilienceManagementRecoveryPlanFailoverCommitValidation.md)
This action checks if the recovery orchestration plan is eligible for failover commit operation, ensuring it meets the necessary criteria and provides a list of qualified and unqualified resources.

### [Test-AzResilienceManagementRecoveryPlanFailoverValidation](Test-AzResilienceManagementRecoveryPlanFailoverValidation.md)
This action checks if the recovery orchestration plan is eligible for failover operation, ensuring it meets the necessary criteria and provides a list of qualified and unqualified resources.

### [Test-AzResilienceManagementRecoveryPlanOperationValidation](Test-AzResilienceManagementRecoveryPlanOperationValidation.md)
This action checks if the recovery orchestration plan is eligible for operations like failover and reprotect, ensuring it meets the necessary criteria.

### [Test-AzResilienceManagementRecoveryPlanReprotectValidation](Test-AzResilienceManagementRecoveryPlanReprotectValidation.md)
This action checks if the recovery orchestration plan is eligible for reprotect operation, ensuring it meets the necessary criteria and provides a list of qualified and unqualified resources.

### [Test-AzResilienceManagementRecoveryPlanTestFailoverCleanupValidation](Test-AzResilienceManagementRecoveryPlanTestFailoverCleanupValidation.md)
This action checks if the recovery orchestration plan is eligible for test failover cleanup operation, ensuring it meets the necessary criteria and provides a list of qualified and unqualified resources.

### [Test-AzResilienceManagementRecoveryPlanTestFailoverValidation](Test-AzResilienceManagementRecoveryPlanTestFailoverValidation.md)
This action checks if the recovery orchestration plan is eligible for test failover operation, ensuring it meets the necessary criteria and provides a list of qualified and unqualified resources.

### [Update-AzResilienceManagementDrill](Update-AzResilienceManagementDrill.md)
Update a Drill

### [Update-AzResilienceManagementDrillResource](Update-AzResilienceManagementDrillResource.md)
This enables the user to include, exclude or update resources from their Drill.

### [Update-AzResilienceManagementEnrollment](Update-AzResilienceManagementEnrollment.md)
Create an Enrollment.

### [Update-AzResilienceManagementGoalAssignment](Update-AzResilienceManagementGoalAssignment.md)
Update a GoalAssignment

### [Update-AzResilienceManagementGoalAssignmentGoalResource](Update-AzResilienceManagementGoalAssignmentGoalResource.md)
Refreshes the goal resources under a goal assignment.
This operation scans for new resources under the scope of the assignment.

### [Update-AzResilienceManagementGoalTemplate](Update-AzResilienceManagementGoalTemplate.md)
Update a GoalTemplate

### [Update-AzResilienceManagementRecoveryPlan](Update-AzResilienceManagementRecoveryPlan.md)
Update a RecoveryPlan

### [Update-AzResilienceManagementRecoveryPlanActionResource](Update-AzResilienceManagementRecoveryPlanActionResource.md)
This action adds or updates the resources to be included in the recovery orchestration plan.

### [Update-AzResilienceManagementUsagePlan](Update-AzResilienceManagementUsagePlan.md)
Update a UsagePlan

