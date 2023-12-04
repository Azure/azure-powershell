---
Module Name: Az.Resources
Module Guid: ab3ca893-26fe-44b0-bd3c-8933df144d7b
Download Help Link: https://learn.microsoft.com/powershell/module/az.resources
Help Version: 5.5.2.0
Locale: en-US
---

# Az.Resources Module
## Description
This topic displays help topics for the Azure Resource Manager Cmdlets.

## Az.Resources Cmdlets
### [Add-AzADAppPermission](Add-AzADAppPermission.md)
Adds an API permission.

### [Add-AzADGroupMember](Add-AzADGroupMember.md)
Adds member to group.

### [Export-AzResourceGroup](Export-AzResourceGroup.md)
Captures a resource group as a template and saves it to a file.

### [Export-AzTemplateSpec](Export-AzTemplateSpec.md)
Exports a Template Spec to the local filesystem

### [Get-AzADAppCredential](Get-AzADAppCredential.md)
Lists key credentials and password credentials for an application.

### [Get-AzADAppFederatedCredential](Get-AzADAppFederatedCredential.md)
Get federatedIdentityCredentials by Id from applications.

### [Get-AzADApplication](Get-AzADApplication.md)
Lists entities from applications or get entity from applications by key

### [Get-AzADAppPermission](Get-AzADAppPermission.md)
Lists API permissions the application has requested.

### [Get-AzADGroup](Get-AzADGroup.md)
Lists entities from groups or get entity from groups by key

### [Get-AzADGroupMember](Get-AzADGroupMember.md)
Lists members from group.

### [Get-AzADGroupOwner](Get-AzADGroupOwner.md)
The owners of the group.
Limited to 100 owners.
Nullable.
If this property is not specified when creating a Microsoft 365 group, the calling user is automatically assigned as the group owner.
Supports $filter (/$count eq 0, /$count ne 0, /$count eq 1, /$count ne 1).
Supports $expand including nested $select.
For example, /groups?$filter=startsWith(displayName,'Role')&$select=id,displayName&$expand=owners($select=id,userPrincipalName,displayName).

### [Get-AzADOrganization](Get-AzADOrganization.md)
Retrieve a list of organization objects.

### [Get-AzADServicePrincipal](Get-AzADServicePrincipal.md)
Lists entities from service principals or get entity from service principals by key

### [Get-AzADSpCredential](Get-AzADSpCredential.md)
Lists key credentials and password credentials for an service principal.

### [Get-AzADUser](Get-AzADUser.md)
Lists entities from users or get entity from users by key

### [Get-AzDenyAssignment](Get-AzDenyAssignment.md)
Lists Azure RBAC deny assignments at the specified scope.
By default it lists all deny assignments in the selected Azure subscription.
Use respective parameters to list deny assignments to a specific user, or to list deny assignments on a specific resource group or resource.

The cmdlet may call below Microsoft Graph API according to input parameters:

- GET /directoryObjects/{id}
- POST /directoryObjects/getByIds

### [Get-AzDeployment](Get-AzDeployment.md)
Get deployment

### [Get-AzDeploymentOperation](Get-AzDeploymentOperation.md)
Get deployment operation

### [Get-AzDeploymentScript](Get-AzDeploymentScript.md)
Gets or lists deployment scripts.

### [Get-AzDeploymentScriptLog](Get-AzDeploymentScriptLog.md)
Gets the log of a deployment script execution.

### [Get-AzDeploymentWhatIfResult](Get-AzDeploymentWhatIfResult.md)
Gets a template What-If result for a deployment at subscription scope. 

### [Get-AzLocation](Get-AzLocation.md)
Gets all locations and the supported resource providers for each location.

### [Get-AzManagedApplication](Get-AzManagedApplication.md)
Gets managed applications

### [Get-AzManagedApplicationDefinition](Get-AzManagedApplicationDefinition.md)
Gets managed application definitions

### [Get-AzManagementGroup](Get-AzManagementGroup.md)
Gets Management Group(s)

### [Get-AzManagementGroupDeployment](Get-AzManagementGroupDeployment.md)
Get deployment at a management group

### [Get-AzManagementGroupDeploymentOperation](Get-AzManagementGroupDeploymentOperation.md)
Get deployment operation for management group deployment

### [Get-AzManagementGroupDeploymentStack](Get-AzManagementGroupDeploymentStack.md)
Gets Management Group scoped Deployment Stacks.

### [Get-AzManagementGroupDeploymentWhatIfResult](Get-AzManagementGroupDeploymentWhatIfResult.md)
Gets a template What-If result for a deployment at management group scope. 

### [Get-AzManagementGroupEntity](Get-AzManagementGroupEntity.md)
Lists all Entities under the current Tenant

### [Get-AzManagementGroupHierarchySetting](Get-AzManagementGroupHierarchySetting.md)
Gets the Hierarchy Settings under the current tenant

### [Get-AzManagementGroupNameAvailability](Get-AzManagementGroupNameAvailability.md)
Checks if the Management Group name is available in the Tenant and a valid name.

### [Get-AzManagementGroupSubscription](Get-AzManagementGroupSubscription.md)
Gets the details of Subscription(s) under a Management Group.

### [Get-AzPolicyAlias](Get-AzPolicyAlias.md)
Get-AzPolicyAlias retrieves and outputs Azure provider resource types that have aliases defined and match the
given parameter values. If no parameters are provided, all provider resource types that contain an alias will be output.
The -ListAvailable switch modifies this behavior by listing all matching resource types including those without aliases.

### [Get-AzPolicyAssignment](Get-AzPolicyAssignment.md)
Gets policy assignments.

### [Get-AzPolicyDefinition](Get-AzPolicyDefinition.md)
Gets policy definitions.

### [Get-AzPolicyExemption](Get-AzPolicyExemption.md)
Gets policy exemptions.

### [Get-AzPolicySetDefinition](Get-AzPolicySetDefinition.md)
Gets policy set definitions.

### [Get-AzPrivateLinkAssociation](Get-AzPrivateLinkAssociation.md)
Gets all the Azure Resource Management Private Link Association(s).

### [Get-AzProviderFeature](Get-AzProviderFeature.md)
Gets information about Azure provider features.

### [Get-AzProviderOperation](Get-AzProviderOperation.md)
Gets the operations for an Azure resource provider that are securable using Azure RBAC.

### [Get-AzProviderPreviewFeature](Get-AzProviderPreviewFeature.md)
Gets a feature registration in your account.

### [Get-AzResource](Get-AzResource.md)
Gets resources.

### [Get-AzResourceGroup](Get-AzResourceGroup.md)
Gets resource groups.

### [Get-AzResourceGroupDeployment](Get-AzResourceGroupDeployment.md)
Gets the deployments in a resource group.

### [Get-AzResourceGroupDeploymentOperation](Get-AzResourceGroupDeploymentOperation.md)
Gets the resource group deployment operation

### [Get-AzResourceGroupDeploymentStack](Get-AzResourceGroupDeploymentStack.md)
Gets Resource Group scoped Deployment Stacks.

### [Get-AzResourceGroupDeploymentWhatIfResult](Get-AzResourceGroupDeploymentWhatIfResult.md)
Gets a template What-If result for a deployment at resource group scope. 

### [Get-AzResourceLock](Get-AzResourceLock.md)
Gets a resource lock.

### [Get-AzResourceManagementPrivateLink](Get-AzResourceManagementPrivateLink.md)
Gets Azure Resource Management Private Link(s)

### [Get-AzResourceProvider](Get-AzResourceProvider.md)
Gets a resource provider.

### [Get-AzRoleAssignment](Get-AzRoleAssignment.md)
Lists Azure RBAC role assignments at the specified scope.
By default it lists all role assignments in the selected Azure subscription.
Use respective parameters to list assignments to a specific user, or to list assignments on a specific resource group or resource.

The cmdlet may call below Microsoft Graph API according to input parameters:

- GET /users/{id}
- GET /servicePrincipals/{id}
- GET /groups/{id}
- GET /directoryObjects/{id}
- POST /directoryObjects/getByIds

Please notice that this cmdlet will mark `ObjectType` as `Unknown` in output if the object of role assignment is not found or current account has insufficient privileges to get object type.

### [Get-AzRoleAssignmentSchedule](Get-AzRoleAssignmentSchedule.md)
Get the specified role assignment schedule for a resource scope

### [Get-AzRoleAssignmentScheduleInstance](Get-AzRoleAssignmentScheduleInstance.md)
Gets the specified role assignment schedule instance.

### [Get-AzRoleAssignmentScheduleRequest](Get-AzRoleAssignmentScheduleRequest.md)
Get the specified role assignment schedule request.

### [Get-AzRoleDefinition](Get-AzRoleDefinition.md)
Lists all Azure RBAC roles that are available for assignment.

### [Get-AzRoleEligibilitySchedule](Get-AzRoleEligibilitySchedule.md)
Get the specified role eligibility schedule for a resource scope

### [Get-AzRoleEligibilityScheduleInstance](Get-AzRoleEligibilityScheduleInstance.md)
Gets the specified role eligibility schedule instance.

### [Get-AzRoleEligibilityScheduleRequest](Get-AzRoleEligibilityScheduleRequest.md)
Get the specified role eligibility schedule request.

### [Get-AzRoleEligibleChildResource](Get-AzRoleEligibleChildResource.md)
Get the child resources of a resource on which user has eligible access

### [Get-AzRoleManagementPolicy](Get-AzRoleManagementPolicy.md)
Get the specified role management policy for a resource scope

### [Get-AzRoleManagementPolicyAssignment](Get-AzRoleManagementPolicyAssignment.md)
Get the specified role management policy assignment for a resource scope

### [Get-AzSubscriptionDeploymentStack](Get-AzSubscriptionDeploymentStack.md)
Gets Subscription scoped Deployment Stacks.

### [Get-AzTag](Get-AzTag.md)
Gets predefined Azure tags | Gets the entire set of tags on a resource or subscription.

### [Get-AzTemplateSpec](Get-AzTemplateSpec.md)
Gets or lists Template Specs

### [Get-AzTenantBackfillStatus](Get-AzTenantBackfillStatus.md)
Get the current Tenant Backfill Subscription Status

### [Get-AzTenantDeployment](Get-AzTenantDeployment.md)
Get deployment at tenant scope

### [Get-AzTenantDeploymentOperation](Get-AzTenantDeploymentOperation.md)
Get deployment operation for deployment at tenant scope

### [Get-AzTenantDeploymentWhatIfResult](Get-AzTenantDeploymentWhatIfResult.md)
Gets a template What-If result for a deployment at tenant scope. 

### [Invoke-AzResourceAction](Invoke-AzResourceAction.md)
Invokes an action on a resource.

### [Move-AzResource](Move-AzResource.md)
Moves a resource to a different resource group or subscription.

### [New-AzADAppCredential](New-AzADAppCredential.md)
Creates key credentials or password credentials for an application.

### [New-AzADAppFederatedCredential](New-AzADAppFederatedCredential.md)
Create federatedIdentityCredential for applications.

### [New-AzADApplication](New-AzADApplication.md)
Adds new entity to applications

### [New-AzADGroup](New-AzADGroup.md)
Adds new entity to groups

### [New-AzADGroupOwner](New-AzADGroupOwner.md)
Create new navigation property ref to owners for groups

### [New-AzADServicePrincipal](New-AzADServicePrincipal.md)
Adds new entity to servicePrincipals

### [New-AzADSpCredential](New-AzADSpCredential.md)
Creates key credentials or password credentials for an service principal.

### [New-AzADUser](New-AzADUser.md)
Adds new entity to users

### [New-AzDeployment](New-AzDeployment.md)
Create a deployment at the current subscription scope.

### [New-AzManagedApplication](New-AzManagedApplication.md)
Creates an Azure managed application.

### [New-AzManagedApplicationDefinition](New-AzManagedApplicationDefinition.md)
Creates a managed application definition.

### [New-AzManagementGroup](New-AzManagementGroup.md)
Creates a Management Group

### [New-AzManagementGroupDeployment](New-AzManagementGroupDeployment.md)
Create a deployment at a management group

### [New-AzManagementGroupDeploymentStack](New-AzManagementGroupDeploymentStack.md)
Creates a new Management Group scoped Deployment Stack.

### [New-AzManagementGroupHierarchySetting](New-AzManagementGroupHierarchySetting.md)
Creates Hierarchy Settings under the current tenant

### [New-AzManagementGroupSubscription](New-AzManagementGroupSubscription.md)
Adds a Subscription to a Management Group.

### [New-AzPolicyAssignment](New-AzPolicyAssignment.md)
Creates a policy assignment.

### [New-AzPolicyDefinition](New-AzPolicyDefinition.md)
Creates a policy definition.

### [New-AzPolicyExemption](New-AzPolicyExemption.md)
Creates a policy exemption.

### [New-AzPolicySetDefinition](New-AzPolicySetDefinition.md)
Creates a policy set definition.

### [New-AzPrivateLinkAssociation](New-AzPrivateLinkAssociation.md)
Creates the Azure Resource Management Private Link Association.

### [New-AzResource](New-AzResource.md)
Creates a resource.

### [New-AzResourceGroup](New-AzResourceGroup.md)
Creates an Azure resource group.

### [New-AzResourceGroupDeployment](New-AzResourceGroupDeployment.md)
Adds an Azure deployment to a resource group.

### [New-AzResourceGroupDeploymentStack](New-AzResourceGroupDeploymentStack.md)
Creates a new Resource Group scoped Deployment Stack.

### [New-AzResourceLock](New-AzResourceLock.md)
Creates a resource lock.

### [New-AzResourceManagementPrivateLink](New-AzResourceManagementPrivateLink.md)
Create Azure Resource Management Private Link

### [New-AzRoleAssignment](New-AzRoleAssignment.md)
Assigns the specified RBAC role to the specified principal, at the specified scope.

The cmdlet may call below Microsoft Graph API according to input parameters:

- GET /users/{id}
- GET /servicePrincipals/{id}
- GET /groups/{id}
- GET /directoryObjects/{id}

Please notice that this cmdlet will mark `ObjectType` as `Unknown` in output if the object of role assignment is not found or current account has insufficient privileges to get object type.

### [New-AzRoleAssignmentScheduleRequest](New-AzRoleAssignmentScheduleRequest.md)
Creates a role assignment schedule request.

### [New-AzRoleDefinition](New-AzRoleDefinition.md)
Creates a custom role in Azure RBAC.
Provide either a JSON role definition file or a PSRoleDefinition object as input.
First, use the Get-AzRoleDefinition command to generate a baseline role definition object.
Then, modify its properties as required.
Finally, use this command to create a custom role using role definition.

### [New-AzRoleEligibilityScheduleRequest](New-AzRoleEligibilityScheduleRequest.md)
Creates a role eligibility schedule request.

### [New-AzRoleManagementPolicyAssignment](New-AzRoleManagementPolicyAssignment.md)
Create a role management policy assignment

### [New-AzSubscriptionDeploymentStack](New-AzSubscriptionDeploymentStack.md)
Creates a new Subscription scoped Deployment Stack.

### [New-AzTag](New-AzTag.md)
Creates a predefined Azure tag or adds values to an existing tag | Creates or updates the entire set of tags on a resource or subscription.

### [New-AzTemplateSpec](New-AzTemplateSpec.md)
Creates a new Template Spec.

### [New-AzTenantDeployment](New-AzTenantDeployment.md)
Create a deployment at tenant scope

### [Publish-AzBicepModule](Publish-AzBicepModule.md)
Publishes a Bicep file to a registry.

### [Register-AzProviderFeature](Register-AzProviderFeature.md)
Registers an Azure provider feature in your current subscription context.

### [Register-AzProviderPreviewFeature](Register-AzProviderPreviewFeature.md)
Creates a feature registration in your account.

### [Register-AzResourceProvider](Register-AzResourceProvider.md)
Registers a resource provider.

### [Remove-AzADAppCredential](Remove-AzADAppCredential.md)
Removes key credentials or password credentials for an application.

### [Remove-AzADAppFederatedCredential](Remove-AzADAppFederatedCredential.md)
Delete navigation property federatedIdentityCredentials for applications

### [Remove-AzADApplication](Remove-AzADApplication.md)
Deletes entity from applications

### [Remove-AzADAppPermission](Remove-AzADAppPermission.md)
Removes an API permission.

### [Remove-AzADGroup](Remove-AzADGroup.md)
Deletes entity from groups.

### [Remove-AzADGroupMember](Remove-AzADGroupMember.md)
Deletes member from group
Users, contacts, and groups that are members of this group.
HTTP Methods: GET (supported for all groups), POST (supported for security groups and mail-enabled security groups), DELETE (supported only for security groups) Read-only.
Nullable.
Supports $expand.

### [Remove-AzADGroupOwner](Remove-AzADGroupOwner.md)
Delete ref of navigation property owners for groups

### [Remove-AzADServicePrincipal](Remove-AzADServicePrincipal.md)
Deletes entity from service principal.

### [Remove-AzADSpCredential](Remove-AzADSpCredential.md)
Removes key credentials or password credentials for an service principal.

### [Remove-AzADUser](Remove-AzADUser.md)
Deletes entity from users.

### [Remove-AzDeployment](Remove-AzDeployment.md)
Removes a deployment and any associated operations

### [Remove-AzDeploymentScript](Remove-AzDeploymentScript.md)
Removes a deployment script and its associated resources.

### [Remove-AzManagedApplication](Remove-AzManagedApplication.md)
Removes a managed application

### [Remove-AzManagedApplicationDefinition](Remove-AzManagedApplicationDefinition.md)
Removes a managed application definition

### [Remove-AzManagementGroup](Remove-AzManagementGroup.md)
Removes a Management Group

### [Remove-AzManagementGroupDeployment](Remove-AzManagementGroupDeployment.md)
Removes a deployment at a management group and any associated operations

### [Remove-AzManagementGroupDeploymentStack](Remove-AzManagementGroupDeploymentStack.md)
Removes a Management Group scoped Deployment Stack.

### [Remove-AzManagementGroupHierarchySetting](Remove-AzManagementGroupHierarchySetting.md)
Deletes all Hierarchy Settings under the current tenant

### [Remove-AzManagementGroupSubscription](Remove-AzManagementGroupSubscription.md)
Removes a Subscription from a Management Group.

### [Remove-AzPolicyAssignment](Remove-AzPolicyAssignment.md)
Removes a policy assignment.

### [Remove-AzPolicyDefinition](Remove-AzPolicyDefinition.md)
Removes a policy definition.

### [Remove-AzPolicyExemption](Remove-AzPolicyExemption.md)
Removes a policy exemption.

### [Remove-AzPolicySetDefinition](Remove-AzPolicySetDefinition.md)
Removes a policy set definition.

### [Remove-AzPrivateLinkAssociation](Remove-AzPrivateLinkAssociation.md)
Delete a specific azure private link association.

### [Remove-AzResource](Remove-AzResource.md)
Removes a resource.

### [Remove-AzResourceGroup](Remove-AzResourceGroup.md)
Removes a resource group.

### [Remove-AzResourceGroupDeployment](Remove-AzResourceGroupDeployment.md)
Removes a resource group deployment and any associated operations.

### [Remove-AzResourceGroupDeploymentStack](Remove-AzResourceGroupDeploymentStack.md)
Removes a Resource Group scoped Deployment Stack.

### [Remove-AzResourceLock](Remove-AzResourceLock.md)
Removes a resource lock.

### [Remove-AzResourceManagementPrivateLink](Remove-AzResourceManagementPrivateLink.md)
Deletes the Resource Manangement Private Link.

### [Remove-AzRoleAssignment](Remove-AzRoleAssignment.md)
Removes a role assignment to the specified principal who is assigned to a particular role at a particular scope.

The cmdlet may call below Microsoft Graph API according to input parameters:

- GET /users/{id}
- GET /servicePrincipals/{id}
- GET /groups/{id}
- GET /directoryObjects/{id}
- POST /directoryObjects/getByIds

Please notice that this cmdlet will mark `ObjectType` as `Unknown` in output if the object of role assignment is not found or current account has insufficient privileges to get object type.

### [Remove-AzRoleDefinition](Remove-AzRoleDefinition.md)
Deletes a custom role in Azure RBAC.
The role to be deleted is specified using the Id property of the role.
Delete will fail if there are existing role assignments made to the custom role.

### [Remove-AzRoleManagementPolicy](Remove-AzRoleManagementPolicy.md)
Delete a role management policy

### [Remove-AzRoleManagementPolicyAssignment](Remove-AzRoleManagementPolicyAssignment.md)
Delete a role management policy assignment

### [Remove-AzSubscriptionDeploymentStack](Remove-AzSubscriptionDeploymentStack.md)
Removes a Subscription scoped Deployment Stack.

### [Remove-AzTag](Remove-AzTag.md)
Deletes predefined Azure tags or values | Deletes the entire set of tags on a resource or subscription.

### [Remove-AzTemplateSpec](Remove-AzTemplateSpec.md)
Removes a Template Spec

### [Remove-AzTenantDeployment](Remove-AzTenantDeployment.md)
Removes a deployment at tenant scope and any associated operations

### [Save-AzDeploymentScriptLog](Save-AzDeploymentScriptLog.md)
Saves the log of a deployment script execution to disk.

### [Save-AzDeploymentTemplate](Save-AzDeploymentTemplate.md)
Saves a deployment template to a file.

### [Save-AzManagementGroupDeploymentStackTemplate](Save-AzManagementGroupDeploymentStackTemplate.md)
Saves a Management Group scoped Deployment Stack Template.

### [Save-AzManagementGroupDeploymentTemplate](Save-AzManagementGroupDeploymentTemplate.md)
Saves a deployment template to a file.

### [Save-AzResourceGroupDeploymentStackTemplate](Save-AzResourceGroupDeploymentStackTemplate.md)
Saves a Resource Group scoped Deployment Stack Template.

### [Save-AzResourceGroupDeploymentTemplate](Save-AzResourceGroupDeploymentTemplate.md)
Saves a resource group deployment template to a file.

### [Save-AzSubscriptionDeploymentStackTemplate](Save-AzSubscriptionDeploymentStackTemplate.md)
Saves a Subscription scoped Deployment Stack Template.

### [Save-AzTenantDeploymentTemplate](Save-AzTenantDeploymentTemplate.md)
Saves a deployment template to a file.

### [Set-AzManagedApplication](Set-AzManagedApplication.md)
Updates managed application

### [Set-AzManagedApplicationDefinition](Set-AzManagedApplicationDefinition.md)
Updates managed application definition

### [Set-AzManagementGroupDeploymentStack](Set-AzManagementGroupDeploymentStack.md)
Sets a new Management Group scoped Deployment Stack.

### [Set-AzPolicyAssignment](Set-AzPolicyAssignment.md)
Modifies a policy assignment.

### [Set-AzPolicyDefinition](Set-AzPolicyDefinition.md)
Modifies a policy definition.

### [Set-AzPolicyExemption](Set-AzPolicyExemption.md)
Modifies a policy exemption.

### [Set-AzPolicySetDefinition](Set-AzPolicySetDefinition.md)
Modifies a policy set definition

### [Set-AzResource](Set-AzResource.md)
Modifies a resource.

### [Set-AzResourceGroup](Set-AzResourceGroup.md)
Modifies a resource group.

### [Set-AzResourceGroupDeploymentStack](Set-AzResourceGroupDeploymentStack.md)
Sets a new Resource Group scoped Deployment Stack.

### [Set-AzResourceLock](Set-AzResourceLock.md)
Modifies a resource lock.

### [Set-AzRoleAssignment](Set-AzRoleAssignment.md)
Update an existing Role Assignment.

The cmdlet may call below Microsoft Graph API according to input parameters:

- GET /users/{id}
- GET /servicePrincipals/{id}
- GET /groups/{id}
- GET /directoryObjects/{id}
- POST /directoryObjects/getByIds

Please notice that this cmdlet will mark `ObjectType` as `Unknown` in output if the object of role assignment is not found or current account has insufficient privileges to get object type.

### [Set-AzRoleDefinition](Set-AzRoleDefinition.md)
Modifies a custom role in Azure RBAC.
Provide the modified role definition either as a JSON file or as a PSRoleDefinition.
First, use the Get-AzRoleDefinition command to retrieve the custom role that you wish to modify.
Then, modify the properties that you wish to change.
Finally, save the role definition using this command.

### [Set-AzSubscriptionDeploymentStack](Set-AzSubscriptionDeploymentStack.md)
Sets a new Subscription scoped Deployment Stack.

### [Set-AzTemplateSpec](Set-AzTemplateSpec.md)
Modifies a Template Spec.

### [Start-AzTenantBackfill](Start-AzTenantBackfill.md)
Starts backfilling subscriptions for the current Tenant

### [Stop-AzDeployment](Stop-AzDeployment.md)
Cancel a running deployment

### [Stop-AzManagementGroupDeployment](Stop-AzManagementGroupDeployment.md)
Cancel a running deployment at a management group

### [Stop-AzResourceGroupDeployment](Stop-AzResourceGroupDeployment.md)
Cancels a resource group deployment.

### [Stop-AzRoleAssignmentScheduleRequest](Stop-AzRoleAssignmentScheduleRequest.md)
Cancels a pending role assignment schedule request.

### [Stop-AzRoleEligibilityScheduleRequest](Stop-AzRoleEligibilityScheduleRequest.md)
Cancels a pending role eligibility schedule request.

### [Stop-AzTenantDeployment](Stop-AzTenantDeployment.md)
Cancel a running deployment at tenant scope

### [Test-AzDeployment](Test-AzDeployment.md)
Validates a deployment.

### [Test-AzManagementGroupDeployment](Test-AzManagementGroupDeployment.md)
Validates a deployment at a management group.

### [Test-AzResourceGroupDeployment](Test-AzResourceGroupDeployment.md)
Validates a resource group deployment.

### [Test-AzTenantDeployment](Test-AzTenantDeployment.md)
Validates a deployment at tenant scope.

### [Unregister-AzProviderFeature](Unregister-AzProviderFeature.md)
Unregisters an Azure provider feature in your account.

### [Unregister-AzProviderPreviewFeature](Unregister-AzProviderPreviewFeature.md)
Removes a feature registration from your account.

### [Unregister-AzResourceProvider](Unregister-AzResourceProvider.md)
Unregisters a resource provider.

### [Update-AzADAppFederatedCredential](Update-AzADAppFederatedCredential.md)
Update the navigation property federatedIdentityCredentials in applications

### [Update-AzADApplication](Update-AzADApplication.md)
Updates entity in applications

### [Update-AzADGroup](Update-AzADGroup.md)
Update entity in groups

### [Update-AzADServicePrincipal](Update-AzADServicePrincipal.md)
Updates entity in service principal

### [Update-AzADUser](Update-AzADUser.md)
Updates entity in users

### [Update-AzManagementGroup](Update-AzManagementGroup.md)
Updates a Management Group

### [Update-AzManagementGroupHierarchySetting](Update-AzManagementGroupHierarchySetting.md)
Updates Hierarchy Settings under the current tenant

### [Update-AzRoleManagementPolicy](Update-AzRoleManagementPolicy.md)
Update a role management policy

### [Update-AzTag](Update-AzTag.md)
Selectively updates the set of tags on a resource or subscription.

