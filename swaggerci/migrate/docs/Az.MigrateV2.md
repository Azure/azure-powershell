---
Module Name: Az.MigrateV2
Module Guid: 47d0d6ff-e7e2-4560-9459-a2b6b643236c
Download Help Link: https://docs.microsoft.com/en-us/powershell/module/az.migratev2
Help Version: 1.0.0.0
Locale: en-US
---

# Az.MigrateV2 Module
## Description
Microsoft Azure PowerShell: MigrateV2 cmdlets

## Az.MigrateV2 Cmdlets
### [Get-AzMigrateV2AssessedMachine](Get-AzMigrateV2AssessedMachine.md)
Get an assessed machine with its size & cost estimate that was evaluated in the specified assessment.

### [Get-AzMigrateV2Assessment](Get-AzMigrateV2Assessment.md)
Get an existing assessment with the specified name.
Returns a json object of type 'assessment' as specified in Models section.

### [Get-AzMigrateV2AssessmentReportDownloadUrl](Get-AzMigrateV2AssessmentReportDownloadUrl.md)
Get the URL for downloading the assessment in a report format.

### [Get-AzMigrateV2Group](Get-AzMigrateV2Group.md)
Get information related to a specific group in the project.
Returns a json object of type 'group' as specified in the models section.

### [Get-AzMigrateV2HyperVCollector](Get-AzMigrateV2HyperVCollector.md)
Get a Hyper-V collector.

### [Get-AzMigrateV2ImportCollector](Get-AzMigrateV2ImportCollector.md)
Get a Import collector.

### [Get-AzMigrateV2Machine](Get-AzMigrateV2Machine.md)
Get the machine with the specified name.
Returns a json object of type 'machine' defined in Models section.

### [Get-AzMigrateV2PrivateEndpointConnection](Get-AzMigrateV2PrivateEndpointConnection.md)
Get information related to a specific private endpoint connection in the project.
Returns a json object of type 'privateEndpointConnections' as specified in the models section.

### [Get-AzMigrateV2PrivateLinkResource](Get-AzMigrateV2PrivateLinkResource.md)
Get information related to a specific private Link Resource in the project.
Returns a json object of type 'privateLinkResources' as specified in the models section.

### [Get-AzMigrateV2Project](Get-AzMigrateV2Project.md)
Get the project with the specified name.

### [Get-AzMigrateV2ProjectAssessmentOption](Get-AzMigrateV2ProjectAssessmentOption.md)
Gets list of all available options for the properties of an assessment on a project.

### [Get-AzMigrateV2ServerCollector](Get-AzMigrateV2ServerCollector.md)
Get a Server collector.

### [Get-AzMigrateV2VMwareCollector](Get-AzMigrateV2VMwareCollector.md)
Get a VMware collector.

### [Invoke-AzMigrateV2AssessmentProjectOption](Invoke-AzMigrateV2AssessmentProjectOption.md)
Get all available options for the properties of an assessment on a project.

### [New-AzMigrateV2Assessment](New-AzMigrateV2Assessment.md)
Create a new assessment with the given name and the specified settings.
Since name of an assessment in a project is a unique identifier, if an assessment with the name provided already exists, then the existing assessment is updated.\n\nAny PUT operation, resulting in either create or update on an assessment, will cause the assessment to go in a \"InProgress\" state.
This will be indicated by the field 'computationState' on the Assessment object.
During this time no other PUT operation will be allowed on that assessment object, nor will a Delete operation.
Once the computation for the assessment is complete, the field 'computationState' will be updated to 'Ready', and then other PUT or DELETE operations can happen on the assessment.\n\nWhen assessment is under computation, any PUT will lead to a 400 - Bad Request error.\n

### [New-AzMigrateV2Group](New-AzMigrateV2Group.md)
Create a new group by sending a json object of type 'group' as given in Models section as part of the Request Body.
The group name in a project is unique.\n\nThis operation is Idempotent.\n

### [New-AzMigrateV2HyperVCollector](New-AzMigrateV2HyperVCollector.md)
Create or Update Hyper-V collector

### [New-AzMigrateV2ImportCollector](New-AzMigrateV2ImportCollector.md)
Create or Update Import collector

### [New-AzMigrateV2Project](New-AzMigrateV2Project.md)
Create a project with specified name.
If a project already exists, update it.

### [New-AzMigrateV2ServerCollector](New-AzMigrateV2ServerCollector.md)
Create or Update Server collector

### [New-AzMigrateV2VMwareCollector](New-AzMigrateV2VMwareCollector.md)
Create or Update VMware collector

### [Remove-AzMigrateV2Assessment](Remove-AzMigrateV2Assessment.md)
Delete an assessment from the project.
The machines remain in the assessment.
Deleting a non-existent assessment results in a no-operation.\n\nWhen an assessment is under computation, as indicated by the 'computationState' field, it cannot be deleted.
Any such attempt will return a 400 - Bad Request.\n

### [Remove-AzMigrateV2Group](Remove-AzMigrateV2Group.md)
Delete the group from the project.
The machines remain in the project.
Deleting a non-existent group results in a no-operation.\n\nA group is an aggregation mechanism for machines in a project.
Therefore, deleting group does not delete machines in it.\n

### [Remove-AzMigrateV2HyperVCollector](Remove-AzMigrateV2HyperVCollector.md)
Delete a Hyper-V collector from the project.

### [Remove-AzMigrateV2ImportCollector](Remove-AzMigrateV2ImportCollector.md)
Delete a Import collector from the project.

### [Remove-AzMigrateV2PrivateEndpointConnection](Remove-AzMigrateV2PrivateEndpointConnection.md)
Delete the private endpoint connection from the project.
T.\n

### [Remove-AzMigrateV2Project](Remove-AzMigrateV2Project.md)
Delete the project.
Deleting non-existent project is a no-operation.

### [Remove-AzMigrateV2ServerCollector](Remove-AzMigrateV2ServerCollector.md)
Delete a Server collector from the project.

### [Remove-AzMigrateV2VMwareCollector](Remove-AzMigrateV2VMwareCollector.md)
Delete a VMware collector from the project.

### [Update-AzMigrateV2GroupMachine](Update-AzMigrateV2GroupMachine.md)
Update machines in group by adding or removing machines.

### [Update-AzMigrateV2Project](Update-AzMigrateV2Project.md)
Update a project with specified name.
Supports partial updates, for example only tags can be provided.

