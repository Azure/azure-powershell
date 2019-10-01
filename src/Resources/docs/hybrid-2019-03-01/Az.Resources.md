---
Module Name: Az.Resources
Module Guid: 1bb10716-570a-45be-88c4-84927b145b93
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

### [Export-AzResourceGroup](Export-AzResourceGroup.md)
Captures the specified resource group as a template.

### [Get-AzDeployment](Get-AzDeployment.md)
Gets a deployment.

### [Get-AzDeploymentOperation](Get-AzDeploymentOperation.md)
Gets a deployments operation.

### [Get-AzLocation](Get-AzLocation.md)
This operation provides all the locations that are available for resource providers; however, each resource provider may support a subset of this list.

### [Get-AzPolicyAssignment](Get-AzPolicyAssignment.md)
Gets a policy assignment.

### [Get-AzPolicyDefinition](Get-AzPolicyDefinition.md)
Gets the policy definition.

### [Get-AzProviderOperationsMetadata](Get-AzProviderOperationsMetadata.md)
Gets provider operations metadata for the specified resource provider.

### [Get-AzResource](Get-AzResource.md)
Gets a resource by ID.

### [Get-AzResourceGroup](Get-AzResourceGroup.md)
Gets a resource group.

### [Get-AzResourceLock](Get-AzResourceLock.md)
Get a management lock by scope.

### [Get-AzTag](Get-AzTag.md)
Gets the names and values of all resource tags that are defined in a subscription.

### [Move-AzResource](Move-AzResource.md)
The resources to move must be in the same source resource group.
The target resource group may be in a different subscription.
When moving resources, both the source group and the target group are locked for the duration of the operation.
Write and delete operations are blocked on the groups until the move completes.

### [New-AzPolicyAssignment](New-AzPolicyAssignment.md)
Policy assignments are inherited by child resources.
For example, when you apply a policy to a resource group that policy is assigned to all resources in the group.

### [New-AzResource](New-AzResource.md)
Create a resource by ID.

### [New-AzResourceGroup](New-AzResourceGroup.md)
Creates or updates a resource group.

### [New-AzResourceLock](New-AzResourceLock.md)
When you apply a lock at a parent scope, all child resources inherit the same lock.
To create management locks, you must have access to Microsoft.Authorization/* or Microsoft.Authorization/locks/* actions.
Of the built-in roles, only Owner and User Access Administrator are granted those actions.

### [New-AzRoleAssignment](New-AzRoleAssignment.md)
Creates a role assignment.

### [New-AzRoleDefinition](New-AzRoleDefinition.md)
Creates or updates a role definition.

### [New-AzTag](New-AzTag.md)
The tag name can have a maximum of 512 characters and is case insensitive.
Tag names created by Azure have prefixes of microsoft, azure, or windows.
You cannot create tags with one of these prefixes.

### [Register-AzResourceProvider](Register-AzResourceProvider.md)
Registers a subscription with a resource provider.

### [Remove-AzDeployment](Remove-AzDeployment.md)
A template deployment that is currently running cannot be deleted.
Deleting a template deployment removes the associated deployment operations.
This is an asynchronous operation that returns a status of 202 until the template deployment is successfully deleted.
The Location response header contains the URI that is used to obtain the status of the process.
While the process is running, a call to the URI in the Location header returns a status of 202.
When the process finishes, the URI in the Location header returns a status of 204 on success.
If the asynchronous request failed, the URI in the Location header returns an error-level status code.

### [Remove-AzPolicyAssignment](Remove-AzPolicyAssignment.md)
Deletes a policy assignment.

### [Remove-AzPolicyDefinition](Remove-AzPolicyDefinition.md)
Deletes a policy definition.

### [Remove-AzPolicySetDefinition](Remove-AzPolicySetDefinition.md)


### [Remove-AzResource](Remove-AzResource.md)
Deletes a resource by ID.

### [Remove-AzResourceGroup](Remove-AzResourceGroup.md)
When you delete a resource group, all of its resources are also deleted.
Deleting a resource group deletes all of its template deployments and currently stored operations.

### [Remove-AzResourceLock](Remove-AzResourceLock.md)
Delete a management lock by scope.

### [Remove-AzRoleAssignment](Remove-AzRoleAssignment.md)
Deletes a role assignment.

### [Remove-AzRoleDefinition](Remove-AzRoleDefinition.md)
Deletes a role definition.

### [Remove-AzTag](Remove-AzTag.md)
You must remove all values from a resource tag before you can delete it.

### [Set-AzPolicyDefinition](Set-AzPolicyDefinition.md)
Creates or updates a policy definition.

### [Set-AzResourceGroup](Set-AzResourceGroup.md)
Creates or updates a resource group.

### [Set-AzResourceLock](Set-AzResourceLock.md)
When you apply a lock at a parent scope, all child resources inherit the same lock.
To create management locks, you must have access to Microsoft.Authorization/* or Microsoft.Authorization/locks/* actions.
Of the built-in roles, only Owner and User Access Administrator are granted those actions.

### [Set-AzRoleDefinition](Set-AzRoleDefinition.md)
Creates or updates a role definition.

### [Stop-AzDeployment](Stop-AzDeployment.md)
You can cancel a deployment only if the provisioningState is Accepted or Running.
After the deployment is canceled, the provisioningState is set to Canceled.
Canceling a template deployment stops the currently running template deployment and leaves the resources partially deployed.

### [Test-AzResourceGroup](Test-AzResourceGroup.md)
Checks whether a resource group exists.

### [Test-AzResourceMove](Test-AzResourceMove.md)
This operation checks whether the specified resources can be moved to the target.
The resources to move must be in the same source resource group.
The target resource group may be in a different subscription.
If validation succeeds, it returns HTTP response code 204 (no content).
If validation fails, it returns HTTP response code 409 (Conflict) with an error message.
Retrieve the URL in the Location header value to check the result of the long-running operation.

### [Unregister-AzResourceProvider](Unregister-AzResourceProvider.md)
Unregisters a subscription from a resource provider.

### [Update-AzResource](Update-AzResource.md)
Updates a resource by ID.

### [Update-AzResourceGroup](Update-AzResourceGroup.md)
Resource groups can be updated through a simple PATCH operation to a group address.
The format of the request is the same as that for creating a resource group.
If a field is unspecified, the current value is retained.

