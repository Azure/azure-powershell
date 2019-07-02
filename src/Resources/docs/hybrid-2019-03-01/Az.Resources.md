---
Module Name: Az.Resources
Module Guid: f9b08cca-d391-4dba-4015-0d621d522b93
Download Help Link: https://docs.microsoft.com/en-us/powershell/module/az.resources
Help Version: 1.0.0.0
Locale: en-US
---

# Az.Resources Module
## Description
Microsoft Azure PowerShell: Resources cmdlets

## Az.Resources Cmdlets
### [Export-AzDeploymentTemplate](Export-AzDeploymentTemplate.md)
Exports the template used for specified deployment.

### [Get-AzDeployment](Get-AzDeployment.md)
Gets a deployment.

### [Get-AzDeploymentOperation](Get-AzDeploymentOperation.md)
Gets a deployments operation.

### [Get-AzManagementLock](Get-AzManagementLock.md)
Get a management lock by scope.

### [Get-AzPermission](Get-AzPermission.md)
Gets all permissions the caller has for a resource group.

### [Get-AzPolicyAssignment](Get-AzPolicyAssignment.md)
Gets a policy assignment.

### [Get-AzPolicyDefinition](Get-AzPolicyDefinition.md)
Gets the policy definition.

### [Get-AzProviderOperationsMetadata](Get-AzProviderOperationsMetadata.md)
Gets provider operations metadata for the specified resource provider.

### [Get-AzRoleAssignment](Get-AzRoleAssignment.md)
Get the specified role assignment.

### [Get-AzRoleDefinition](Get-AzRoleDefinition.md)
Get role definition by name (GUID).

### [New-AzDeployment](New-AzDeployment.md)
You can provide the template and parameters directly in the request or link to JSON files.

### [New-AzManagementLock](New-AzManagementLock.md)
When you apply a lock at a parent scope, all child resources inherit the same lock.
To create management locks, you must have access to Microsoft.Authorization/* or Microsoft.Authorization/locks/* actions.
Of the built-in roles, only Owner and User Access Administrator are granted those actions.

### [New-AzPolicyAssignment](New-AzPolicyAssignment.md)
Policy assignments are inherited by child resources.
For example, when you apply a policy to a resource group that policy is assigned to all resources in the group.

### [New-AzPolicyDefinition](New-AzPolicyDefinition.md)
Creates or updates a policy definition.

### [New-AzRoleAssignment](New-AzRoleAssignment.md)
Creates a role assignment.

### [New-AzRoleDefinition](New-AzRoleDefinition.md)
Creates or updates a role definition.

### [Remove-AzDeployment](Remove-AzDeployment.md)
A template deployment that is currently running cannot be deleted.
Deleting a template deployment removes the associated deployment operations.
This is an asynchronous operation that returns a status of 202 until the template deployment is successfully deleted.
The Location response header contains the URI that is used to obtain the status of the process.
While the process is running, a call to the URI in the Location header returns a status of 202.
When the process finishes, the URI in the Location header returns a status of 204 on success.
If the asynchronous request failed, the URI in the Location header returns an error-level status code.

### [Remove-AzManagementLock](Remove-AzManagementLock.md)
Delete a management lock by scope.

### [Remove-AzPolicyAssignment](Remove-AzPolicyAssignment.md)
Deletes a policy assignment.

### [Remove-AzPolicyDefinition](Remove-AzPolicyDefinition.md)
Deletes a policy definition.

### [Remove-AzPolicySetDefinition](Remove-AzPolicySetDefinition.md)


### [Remove-AzRoleAssignment](Remove-AzRoleAssignment.md)
Deletes a role assignment.

### [Remove-AzRoleDefinition](Remove-AzRoleDefinition.md)
Deletes a role definition.

### [Set-AzDeployment](Set-AzDeployment.md)
You can provide the template and parameters directly in the request or link to JSON files.

### [Set-AzManagementLock](Set-AzManagementLock.md)
When you apply a lock at a parent scope, all child resources inherit the same lock.
To create management locks, you must have access to Microsoft.Authorization/* or Microsoft.Authorization/locks/* actions.
Of the built-in roles, only Owner and User Access Administrator are granted those actions.

### [Set-AzPolicyDefinition](Set-AzPolicyDefinition.md)
Creates or updates a policy definition.

### [Set-AzRoleDefinition](Set-AzRoleDefinition.md)
Creates or updates a role definition.

### [Stop-AzDeployment](Stop-AzDeployment.md)
You can cancel a deployment only if the provisioningState is Accepted or Running.
After the deployment is canceled, the provisioningState is set to Canceled.
Canceling a template deployment stops the currently running template deployment and leaves the resources partially deployed.

### [Test-AzDeployment](Test-AzDeployment.md)
Validates whether the specified template is syntactically correct and will be accepted by Azure Resource Manager..

### [Test-AzDeploymentExistence](Test-AzDeploymentExistence.md)
Checks whether the deployment exists.

