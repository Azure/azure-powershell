## Resource Manager / Active Directory

The `Az.Resources` module contains cmdlets for the following services:

- Resource Manager (ARM)
    - Calls made from the `Microsoft.Azure.Management.ResourceManager` SDK
- Active Directory (Graph)
    - Calls made from the `Microsoft.Azure.Graph.RBAC` SDK (_note_: this is a data plane SDK)
- Authorization
    - Calls made from the `Microsoft.Azure.Management.Authorization` SDK
- Management Groups
    - Calls made from the `Microsoft.Azure.Management.ManagementGroups` SDK

Below are the projects found in the `Resources` solution and some of the different concepts found within each.

### `ResourceManager` project

The `ResourceManager` project contains all of the Resource Manager cmdlets.

One thing that differentiates the `ResourceManager` project from all other service projects is that it doesn't always use the client exposed from its corresponding SDK (`Microsoft.Azure.Management.ResourceManager`). In some cases, a generic [`HttpClient`](https://github.com/Azure/azure-powershell/blob/4fd93d58860b3ead9b6ba9acf7974457d4891aea/src/Resources/ResourceManager/RestClients/ResourceManagerRestClientBase.cs#L221) is created and used to make requests to ARM, which allows the cmdlets to make calls to endpoints that aren't yet defined in their REST API specification. This pattern was used commonly in the early stages of this module, but since then have shifted primarily to using calls exposed from the SDK that can be made using the given SDK client.

#### Resources

From the [_Azure Resource Manager overview_](https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-group-overview#terminology) document, a resource is defined as the following:

_A manageable item that is available through Azure. Virtual machines, storage accounts, web apps, databases, and virtual networks are examples of resources._

Resources are tracked using an ID; top-level resources have IDs that follow the below pattern:

```
/subscriptions/{SUBSCRIPTION_ID}/resourceGroups/{RESOURCE_GROUP}/{PROVIDER_NAMESPACE}/{RESOURCE_TYPE}/{RESOURCE_NAME}
```

For example, a virtual machined called "MyVM" found in the resource group "MyResourceGroup" for subscription "830afc1a-b2c2-49fa-b36d-c05c335ea986" would have the following ID:

```
/subscriptions/830afc1a-b2c2-49fa-b36d-c05c335ea986/resourceGroups/MyResourceGroup/Microsoft.Compute/virtualMachines/MyVM
```

Child resources have IDs that follow the below pattern:

```
/subscriptions/{SUBSCRIPTION_ID}/resourceGroups/{RESOURCE_GROUP}/{PARENT_PROVIDER_NAMESPACE}/{PARENT_RESOURCE_TYPE}/{PARENT_RESOURCE_NAME}/{CHILD_RESOURCE_TYPE}/{CHILD_RESOURCE_NAME}
```

For example, if the same virtual machine from before had an extension called "MyExtension", the resource ID would be the following:

```
/subscriptions/830afc1a-b2c2-49fa-b36d-c05c335ea986/resourceGroups/MyResourceGroup/Microsoft.Compute/virtualMachines/MyVM/extensions/MyExtension
```

Because a resource's ID contains the identifier properties of the resource (resource group, name, parent name, etc.), we suggest that cmdlets have a parameter set that contains a `-ResourceId` parameter to allow the user to pass in the ID of the resource that they would like to act upon. Within the cmdlet code, the resource ID can be parsed to pull out these identifier properties and then pass them to the corresponding SDK call.

The cmdlets currently found in the `Az.Resources` module that act upon resources are the following:

- [`Get-AzResource`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Get-AzResource.md)
    - Retrieves all resources in the current subscription or specified resource group, or gets a specific resource. The user can also filter results by resource types and tags on the given resources.
- [`Move-AzResource`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Move-AzResource.md)
    - Moves a resource to a different resource group or subscription.
- [`New-AzResource`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/New-AzResource.md)
    - Creates a resource with the given identifier properties and resource-specific properties (found in `-Properties`).
- [`Remove-AzResource`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Remove-AzResource.md)
    - Deletes the resource with the given identifier properties.
- [`Set-AzResource`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Set-AzResource.md)
    - Modifies a resource to have exactly the properties specified by the provided parameters (`PUT` operation).

#### Resource Groups

From the [_Azure Resource Manager overview_](https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-group-overview#terminology) document, a resource group is defined as the following:

_A container that holds related resources for an Azure solution. The resource group includes those resources that you want to manage as a group. You decide which resources belong in a resource group based on what makes the most sense for your organization._

The cmdlets currently found in the `Az.Resources` module that act upon resource groups are the following:

- [`Export-AzResourceGroup`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Export-AzResourceGroup.md)
    - Converts the contents of a resource group to a template and saves it to a file on the user's machine.
- [`Get-AzResourceGroup`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Get-AzResourceGroup.md)
    - Retrieves all resource groups in the current subscription, or gets a specific resource group. The user can also filter results by tags on the given resource groups.
- [`New-AzResourceGroup`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/New-AzResourceGroup.md)
    - Creates a resource group with the given properties.
- [`Remove-AzResourceGroup`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Remove-AzResourceGroup.md)
    - Deletes the resource group with the given identifier properties, as well as all of the resources found in the resource group.
- [`Set-AzResourceGroup`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Set-AzResourceGroup.md)
    - Modifies a resource group to have exactly the properties specified by the provided parameters (`PUT` operation).

#### Deployments

From the [_Azure Resource Manager overview_](https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-group-overview#terminology) document, an ARM template is defined as the following:

_A JavaScript Object Notation (JSON) file that defines one or more resources to deploy to a resource group or subscription. The template can be used to deploy the resources consistently and repeatedly._

Users can find sample JSON templates to deploy in the [`azure-quickstart-templates`](https://github.com/Azure/azure-quickstart-templates) repository. The deployment cmdlets found in the `Az.Resources` module are used to manage the deployment of these templates.

The cmdlets currently found in the `Az.Resources` module that act upon deployments are the following:

- [`Get-AzDeployment`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Get-AzDeployment.md)
    - Retrieves all of the deployments in the current subscription. The user can also filter the results by name and ID.
- [`Get-AzResourceGroupDeployment`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Get-AzResourceGroupDeployment.md)
    - Retrieves all of the deployments in the specified resource group. The user can also filter the results by name and ID.
- [`New-AzDeployment`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/New-AzDeployment.md)
    - Creates a new deployment in the current subscription.
- [`New-AzResourceGroupDeployment`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/New-AzResourceGroupDeployment.md)
    - Creates a new deployment in the specified resource group.
- [`Remove-AzDeployment`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Remove-AzDeployment.md)
    - Deletes a deployment in the current subscription with the given name or ID.
- [`Remove-AzResourceGroupDeployment`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Remove-AzResourceGroupDeployment.md)
    - Deletes a deployment in the specified resource group with the given name or ID.
- [`Stop-AzDeployment`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Stop-AzDeployment.md)
    - Cancels a deployment in the current subscription with the given name or ID.
- [`Stop-AzResourceGroupDeployment`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Stop-AzResourceGroupDeployment.md)
    - Cancels a deployment in the specified resource group with the given name or ID.
- [`Test-AzDeployment`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Test-AzDeployment.md)
    - Determines whether the given deployment template and its parameter values are valid in the current subscription.
- [`Test-AzResourceGroupDeployment`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Test-AzResourceGroupDeployment.md)
    - Determines whether the given deployment template and its parameter values are valid in the specified resource group.

#### Policy Definition

From the [_Azure Policy definition structure_](https://docs.microsoft.com/en-us/azure/governance/policy/concepts/definition-structure) document, a policy definition is defined as the following:

_Resource policy definitions are used by Azure Policy to establish conventions for resources. Each definition describes resource compliance and what effect to take when a resource is non-compliant._

The cmdlets currently found in the `Az.Resources` module that act upon policy definitions are the following:

- [`Get-AzPolicyDefinition`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Get-AzPolicyDefinition.md)
    - Retrieves all of the policy definitions in the current subscription, specified subscription ID or specified management group. The user can also filter the results by name and ID.
- [`New-AzPolicyDefinition`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/New-AzPolicyDefinition.md)
    - Creates a new policy definition in the current subscription, specified subscription or specified management group.
- [`Remove-AzPolicyDefinition`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Remove-AzPolicyDefinition.md)
    - Deletes a policy definition in the current subscription, specified subscription or specified management group, or with the given name.
- [`Set-AzPolicyDefinition`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Set-AzPolicyDefinition.md)
    - Modifies a policy definition to have exactly the properties specified by the provided parameters (`PUT` operation).

#### Policy Assignment

From the [_Overview of the Azure Policy service_](https://docs.microsoft.com/en-us/azure/governance/policy/overview#policy-assignment) document, a policy assignment is defined as the following:

_A policy assignment is a policy definition that has been assigned to take place within a specific scope. This scope could range from a management group to a resource group. Policy assignments are inherited by all child resources. This design means that a policy applied to a resource group is also applied to resources in that resource group. However, you can exclude a subscope from the policy assignment._

The cmdlets currently found in the `Az.Resources` module that act upon policy assignments are the following:

- [`Get-AzPolicyAssignment`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Get-AzPolicyAssignment.md)
    - Retrieves all of the policy assignments in the current subscription or specified scope. The user can also filter the results by name and ID.
- [`New-AzPolicyAssignment`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/New-AzPolicyAssignment.md)
    - Creates a new policy assignment in the current subscription or specified scope.
- [`Remove-AzPolicyAssignment`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Remove-AzPolicyAssignment.md)
    - Deletes a policy assignment in the given scope or by ID.
- [`Set-AzPolicyAssignment`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Set-AzPolicyAssignment.md)
    - Modifies a policy assignment to have exactly the properties specified by the provided parameters (`PUT` operation).

### `Resources` project

The `Resources` project contains all of the Active Directory, Authorization, and Management Groups cmdlets.

#### Active Directory

From the [_Application and service principal objects in Azure Active Directory_](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Test-AzResourceGroupDeployment.md) document, an Azure AD application is defined as the following:

_An Azure AD application is defined by its one and only application object, which resides in the Azure AD tenant where the application was registered, known as the application's "home" tenant._

_The application object serves as the template from which common and default properties are derived for use in creating corresponding service principal objects. An application object therefore has a 1:1 relationship with the software application, and a 1:many relationships with its corresponding service principal object(s)._

The cmdlets currently found in the `Az.Resources` module that act upon applications are the following:

- [`Get-AzADApplication`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Get-AzADApplication.md)
    - Retrieves all applications in the current tenant. The user can also filter results by object ID, application ID and display name.
- [`New-AzADApplication`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/New-AzADApplication.md)
    - Creates a new application in the current tenant with the given properties.
- [`Remove-AzADApplication`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Remove-AzADApplication.md)
    - Deletes an application with the given object ID, application ID or display name.
- [`Update-AzADApplication`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Update-AzADApplication.md)
    - Updates properties of an application based on the parameters provided (`PATCH` operation).

From the [_Manage app and resource access using Azure Active Directory groups_](https://docs.microsoft.com/en-us/azure/active-directory/fundamentals/active-directory-manage-groups#how-does-access-management-in-azure-ad-work) document, an Azure AD group does the following:

_Using groups lets the resource owner (or Azure AD directory owner), assign a set of access permissions to all the members of the group, instead of having to provide the rights one-by-one. The resource or directory owner can also give management rights for the member list to someone else, such as a department manager or a Helpdesk administrator, letting that person add and remove members, as needed._

The cmdlets currently found in the `Az.Resources` module that act upon groups are the following:

- [`Get-AzADGroup`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Get-AzADGroup.md)
    - Retrieves all groups in the current tenant. The user can also filter results by object ID and display name.
- [`New-AzADGroup`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/New-AzADGroup.md)
    - Creates a new group in the current tenant with the given properties.
- [`Remove-AzADGroup`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Remove-AzADGroup.md)
    - Deletes a group with the given object ID or display name.

From the [_Application and service principal objects in Azure Active Directory_](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Test-AzResourceGroupDeployment.md) document, a service principal is defined as the following:

_When an application is given permission to access resources in a tenant (upon registration or consent), a service principal object is created._

_A service principal must be created in each tenant where the application is used, enabling it to establish an identity for sign-in and/or access to resources being secured by the tenant. A single-tenant application has only one service principal (in its home tenant), created and consented for use during application registration. A multi-tenant Web application/API also has a service principal created in each tenant where a user from that tenant has consented to its use._

The cmdlets currently found in the `Az.Resources` module that act upon service principals are the following:

- [`Get-AzADServicePrincipal`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Get-AzADServicePrincipal.md)
     - Retrieves all service principals in the current tenant. The user can also filter results by object ID, application ID, display name and service principal name.
- [`New-AzADServicePrincipal`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/New-AzADServicePrincipal.md)
     - Creates a new service principal in the current tenant with the given properties.
     - Scenario based cmdlet -- sets default values for the following properties if the user does not provide a value for them:
         - `-DisplayName` (default is `azure-powershell-MM-dd-yyyy-HH-mm-ss`, where the suffix is the current time)
         - `-StartDate` (default is the current time)
         - `-EndDate` (default is one year after the start date)
         - `-Scope` (default is the subscription)
         - `-Role` (default value is "Contributor")
- [`Remove-AzADServicePrincipal`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Remove-AzADServicePrincipal.md)
    - Deletes a service principal with the given object ID, application ID, display name or service principal name.
- [`Update-AzADServicePrincipal`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Update-AzADServicePrincipal.md)
    - Updates properties of a service principal based on the parameters provided (`PATCH` operation)

The cmdlets currently found in this `Az.Resources` module that act upon users are the following:

- [`Get-AzADUser`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Get-AzADUser.md)
    - Retrieves all users in the current tenant. The user can also filter the results by object ID, display name, user principal name, or mail nickname.
- [`New-AzADUser`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/New-AzADUser.md)
    - Creates a new user in the current tenant with the given properties.
- [`Remove-AzADUser`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Remove-AzADUser.md)
    - Deletes a user with the given object ID, display name, or user principal name.
- [`Update-AzADUser`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Update-AzADUser.md)
    - Updates properties of a user based on the parameters provided (`PATCH` operation)

#### Role Assignments

From the [__What is role-based access control (RBAC) for Azure resources?_](https://docs.microsoft.com/en-us/azure/role-based-access-control/overview#role-assignments) document, a role assignment is defined as the following:

_A role assignment is the process of attaching a role definition to a user, group, service principal, or managed identity at a particular scope for the purpose of granting access. Access is granted by creating a role assignment, and access is revoked by removing a role assignment._

The cmdlets currently found in the `Az.Resources` module that act upon role assignments are the following:

- [`Get-AzRoleAssignment`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Get-AzRoleAssignment.md)
    - Retrieves all role assignments in the current subscription. The user can also filter the results by scope, service principal name, sign-in name, or object ID.
- [`New-AzRoleAssignment`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/New-AzRoleAssignment.md)
    - Creates a new role assignment in the specified scope with the given role definition.
- [`Remove-AzRoleAssignment`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Remove-AzRoleAssignment.md)
    - Deletes a role assignment with the given scope, service principal name, sign-in name, or object ID.

#### Role Definitions

From the [__What is role-based access control (RBAC) for Azure resources?_](https://docs.microsoft.com/en-us/azure/role-based-access-control/overview#role-assignments) document, a role definition is defined as the following:

_A role definition is a collection of permissions. It's sometimes just called a role. A role definition lists the operations that can be performed, such as read, write, and delete. Roles can be high-level, like owner, or specific, like virtual machine reader._

The cmdlets currently found in the `Az.Resources` module that act upon role definitions are the following:

- [`Get-AzRoleDefinition`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Get-AzRoleDefinition.md)
    - Retrieves all role definitions in the current subscription. The user can also filter the results by scope, name or ID.
- [`New-AzRoleDefinition`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/New-AzRoleDefinition.md)
    - Creates a new custom role definition in Azure RBAC with the given properties.
- [`Remove-AzRoleDefinition`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Remove-AzRoleDefinition.md)
    - Deletes a role definition with the given ID or name.
- [`Set-AzRoleDefinition`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Set-AzRoleDefinition.md)
    - Modifies a role definition to have exactly the properties specified by the provided parameters (`PUT` operation).

### Management Groups

From the [_Organize your resources with Azure management groups_](https://docs.microsoft.com/en-us/azure/governance/management-groups/index) document, a management group is defined as the following:

_Azure management groups provide a level of scope above subscriptions. You organize subscriptions into containers called "management groups" and apply your governance conditions to the management groups. All subscriptions within a management group automatically inherit the conditions applied to the management group. Management groups give you enterprise-grade management at a large scale no matter what type of subscriptions you might have._

The cmdlets currently found in the `Az.Resources` module that act upon management groups are the following:

- [`Get-AzManagementGroup`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Get-AzManagementGroup.md)
    - Retrieves all management groups for the current user. The user can also filter the results by the name of the management group.
- [`New-AzManagementGroup`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/New-AzManagementGroup.md)
    - Creates a new management group with the given properties.
- [`New-AzManagementGroupSubscription`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/New-AzManagementGroupSubscription.md)
    - Adds a subscription to the given management group.
- [`Remove-AzManagementGroup`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Remove-AzManagementGroup.md)
    - Deletes a management group with the given name.
- [`Remove-AzManagementGroupSubscription`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Remove-AzManagementGroupSubscription.md)
    - Removes a subscription from the given management group.
- [`Update-AzManagementGroup`](https://github.com/Azure/azure-powershell/blob/master/src/Resources/Resources/help/Update-AzManagementGroup.md)
    - Updates properties of a management group based on the parameters provided (`PATCH` operation)