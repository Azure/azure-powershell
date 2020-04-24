---
Module Name: Az.Migrate
Module Guid: c6168a87-ad07-4821-a6ae-82bfe3d5db80
Download Help Link: https://docs.microsoft.com/en-us/powershell/module/az.migrate
Help Version: 1.0.0.0
Locale: en-US
---

# Az.Migrate Module
## Description
Microsoft Azure PowerShell: Migrate cmdlets

## Az.Migrate Cmdlets
### [Get-AzMigrateAssessedMachine](Get-AzMigrateAssessedMachine.md)
Get an assessed machine with its size & cost estimate that was evaluated in the specified assessment.

### [Get-AzMigrateAssessment](Get-AzMigrateAssessment.md)
Get an existing assessment with the specified name.
Returns a json object of type 'assessment' as specified in Models section.

### [Get-AzMigrateAssessmentReportDownloadUrl](Get-AzMigrateAssessmentReportDownloadUrl.md)
Get the URL for downloading the assessment in a report format.

### [Get-AzMigrateGroup](Get-AzMigrateGroup.md)
Get information related to a specific group in the project.
Returns a json object of type 'group' as specified in the models section.

### [Get-AzMigrateHyperVCluster](Get-AzMigrateHyperVCluster.md)
Method to get a Hyper-V cluster.

### [Get-AzMigrateHyperVCollector](Get-AzMigrateHyperVCollector.md)
Get a Hyper-V collector.

### [Get-AzMigrateHyperVHost](Get-AzMigrateHyperVHost.md)
Method to get a Hyper-V host.

### [Get-AzMigrateHyperVJob](Get-AzMigrateHyperVJob.md)
Method to get job.

### [Get-AzMigrateHyperVMachine](Get-AzMigrateHyperVMachine.md)
Method to get machine.

### [Get-AzMigrateHyperVOperationsStatus](Get-AzMigrateHyperVOperationsStatus.md)
Method to get operation status.

### [Get-AzMigrateHyperVRunAsAccount](Get-AzMigrateHyperVRunAsAccount.md)
Method to get run as account.

### [Get-AzMigrateHyperVSite](Get-AzMigrateHyperVSite.md)
Method to get a site.

### [Get-AzMigrateJob](Get-AzMigrateJob.md)
Method to get job.

### [Get-AzMigrateMachine](Get-AzMigrateMachine.md)
Method to get machine.

### [Get-AzMigrateProject](Get-AzMigrateProject.md)
Get the project with the specified name.

### [Get-AzMigrateProjectAssessmentOption](Get-AzMigrateProjectAssessmentOption.md)
Get all available options for the properties of an assessment on a project.

### [Get-AzMigrateRunAsAccount](Get-AzMigrateRunAsAccount.md)
Method to get run as account.

### [Get-AzMigrateSite](Get-AzMigrateSite.md)
Method to get a site.

### [Get-AzMigrateVCenter](Get-AzMigrateVCenter.md)
Method to get a vCenter.

### [Get-AzMigrateVMwareCollector](Get-AzMigrateVMwareCollector.md)
Get a VMware collector.

### [Get-AzMigrateVMwareOperationsStatus](Get-AzMigrateVMwareOperationsStatus.md)
Method to get operation status.

### [New-AzMigrateAssessment](New-AzMigrateAssessment.md)
Create a new assessment with the given name and the specified settings.
Since name of an assessment in a project is a unique identifier, if an assessment with the name provided already exists, then the existing assessment is updated.\n\nAny PUT operation, resulting in either create or update on an assessment, will cause the assessment to go in a \"InProgress\" state.
This will be indicated by the field 'computationState' on the Assessment object.
During this time no other PUT operation will be allowed on that assessment object, nor will a Delete operation.
Once the computation for the assessment is complete, the field 'computationState' will be updated to 'Ready', and then other PUT or DELETE operations can happen on the assessment.\n\nWhen assessment is under computation, any PUT will lead to a 400 - Bad Request error.\n

### [New-AzMigrateGroup](New-AzMigrateGroup.md)
Create a new group by sending a json object of type 'group' as given in Models section as part of the Request Body.
The group name in a project is unique.\n\nThis operation is Idempotent.\n

### [New-AzMigrateHyperVCluster](New-AzMigrateHyperVCluster.md)
Method to create or update a cluster in site.

### [New-AzMigrateHyperVCollector](New-AzMigrateHyperVCollector.md)
Create or Update Hyper-V collector

### [New-AzMigrateHyperVHost](New-AzMigrateHyperVHost.md)
Method to create or update a host in site.

### [New-AzMigrateHyperVSite](New-AzMigrateHyperVSite.md)
Method to create or update a site.

### [New-AzMigrateProject](New-AzMigrateProject.md)
Create a project with specified name.
If a project already exists, update it.

### [New-AzMigrateSite](New-AzMigrateSite.md)
Method to create or update a site.

### [New-AzMigrateVCenter](New-AzMigrateVCenter.md)
Method to create or update a vCenter in site.

### [New-AzMigrateVMwareCollector](New-AzMigrateVMwareCollector.md)
Create or Update VMware collector

### [Remove-AzMigrateAssessment](Remove-AzMigrateAssessment.md)
Delete an assessment from the project.
The machines remain in the assessment.
Deleting a non-existent assessment results in a no-operation.\n\nWhen an assessment is under computation, as indicated by the 'computationState' field, it cannot be deleted.
Any such attempt will return a 400 - Bad Request.\n

### [Remove-AzMigrateGroup](Remove-AzMigrateGroup.md)
Delete the group from the project.
The machines remain in the project.
Deleting a non-existent group results in a no-operation.\n\nA group is an aggregation mechanism for machines in a project.
Therefore, deleting group does not delete machines in it.\n

### [Remove-AzMigrateHyperVCollector](Remove-AzMigrateHyperVCollector.md)
Delete a Hyper-V collector from the project.

### [Remove-AzMigrateHyperVSite](Remove-AzMigrateHyperVSite.md)
Method to delete a site.

### [Remove-AzMigrateProject](Remove-AzMigrateProject.md)
Delete the project.
Deleting non-existent project is a no-operation.

### [Remove-AzMigrateSite](Remove-AzMigrateSite.md)
Method to delete a site.

### [Remove-AzMigrateVCenter](Remove-AzMigrateVCenter.md)
Method to delete vCenter in site.

### [Remove-AzMigrateVMwareCollector](Remove-AzMigrateVMwareCollector.md)
Delete a VMware collector from the project.

### [Start-AzMigrateMachine](Start-AzMigrateMachine.md)
Method to start a machine.

### [Stop-AzMigrateMachine](Stop-AzMigrateMachine.md)
Method to stop a machine.

### [Update-AzMigrateGroupMachine](Update-AzMigrateGroupMachine.md)
Update machines in group by adding or removing machines.

### [Update-AzMigrateHyperVCluster](Update-AzMigrateHyperVCluster.md)
Method to create or update a cluster in site.

### [Update-AzMigrateHyperVHost](Update-AzMigrateHyperVHost.md)
Method to create or update a host in site.

### [Update-AzMigrateHyperVSite](Update-AzMigrateHyperVSite.md)
Method to refresh a site.

### [Update-AzMigrateProject](Update-AzMigrateProject.md)
Update a project with specified name.
Supports partial updates, for example only tags can be provided.

### [Update-AzMigrateSite](Update-AzMigrateSite.md)
Method to refresh a site.

### [Update-AzMigrateVCenter](Update-AzMigrateVCenter.md)
Method to create or update a vCenter in site.

