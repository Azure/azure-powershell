# Resource Manager / Active Directory

The `Az.Resources` module contains cmdlets for the following services:

- Resource Manager (ARM)
    - Calls made from the `Microsoft.Azure.Management.ResourceManager` SDK
- Active Directory (Graph)
    - Calls made from the `Microsoft.Azure.Graph.RBAC` SDK (_note_: this is a data plane SDK)
- Authorization
    - Calls made from the `Microsoft.Azure.Management.Authorization` SDK
- Management Groups
    - Calls made from the `Microsoft.Azure.Management.ManagementGroups` SDK

In the `azure-powershell` repository, the cmdlets in the `Az.Resources` module are found in the `ResourceManager` and `Resources` projects. Below are the parts of those projects that the Azure PowerShell team own and help to maintain.

## `ResourceManager` project

The `ResourceManager` project contains all of the Resource Manager cmdlets.

One thing that differentiates the `ResourceManager` project from all other service projects is that it doesn't always use the client exposed from its corresponding SDK (`Microsoft.Azure.Management.ResourceManager`). In some cases, a generic [`HttpClient`](https://github.com/Azure/azure-powershell/blob/4fd93d58860b3ead9b6ba9acf7974457d4891aea/src/Resources/ResourceManager/RestClients/ResourceManagerRestClientBase.cs#L221) is created and used to make requests to ARM, which allows the cmdlets to make calls to endpoints that aren't yet defined in their REST API specification. This pattern was used commonly in the early stages of this module, but since then have shifted primarily to using calls exposed from the SDK that can be made using the given SDK client.

### Resources

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

- [`Get-AzResource`](https://github.com/Azure/azure-powershell/blob/main/src/Resources/Resources/help/Get-AzResource.md)
- [`Move-AzResource`](https://github.com/Azure/azure-powershell/blob/main/src/Resources/Resources/help/Move-AzResource.md)
- [`New-AzResource`](https://github.com/Azure/azure-powershell/blob/main/src/Resources/Resources/help/New-AzResource.md)
- [`Remove-AzResource`](https://github.com/Azure/azure-powershell/blob/main/src/Resources/Resources/help/Remove-AzResource.md)
- [`Set-AzResource`](https://github.com/Azure/azure-powershell/blob/main/src/Resources/Resources/help/Set-AzResource.md)

#### `Get-AzResource`

The `Get-AzResource` cmdlet has a couple of features that make it different than a regular cmdlet:

**Wildcard support**

To allow for another layer of filtering over the large number of resources that may be returned for a given query, wildcard support was added for the `-ResourceGroupName` and `-Name` parameters. This allows users to perform the following:

```powershell
# List all resources that are in any resource group with the prefix "test"
Get-AzResource -ResourceGroupName test*

# List all resources with the prefix "test"
Get-AzResource -Name test*

# List all resources with the prefix "test" in the resource group "test-rg"
Get-AzResource -ResourceGroupName test-rg -Name test*

# List all resources named "test" in any resource group with the prefix "test"
Get-AzResource -ResourceGroupName test* -Name test
```

The cmdlet uses the [`TopLevelWildcardFilter()`](https://github.com/Azure/azure-powershell-common/blob/main/src/ResourceManager/Version2016_09_01/AzureRMCmdlet.cs#L394-L435) call in our common code to [filter the results by the given wildcard](https://github.com/Azure/azure-powershell/blob/main/src/Resources/ResourceManager/Implementation/Resource/GetAzureResourceCmdlet.cs#L185).

**Uses both `HttpClient` and `ResourceManagerClient`**

As mentioned previously, the `ResourceManager` project has a mix of cmdlets that use a generic `HttpClient` and/or the `ResourceManagerClient` to make calls to the server. Where applicable, calls that could be made using the `ResourceManagerClient` were implemented and replaced the calls using the generic `HttpClient`.

First, the cmdlet tries to [construct a resource ID](https://github.com/Azure/azure-powershell/blob/main/src/Resources/ResourceManager/Implementation/Resource/GetAzureResourceCmdlet.cs#L129-L132) out of the parameters provided, specifically,  `-ResourceGroupName`, `-ResourceType` and `-Name`. If the user provided a value for all three of these parameters (and didn't include wildcards in either `-ResourceGroupName` or `-Name`), then we would make a [call to get the resource by ID](https://github.com/Azure/azure-powershell/blob/main/src/Resources/ResourceManager/Implementation/Resource/GetAzureResourceCmdlet.cs#L136) using the `ResourceManagerClient`. Since the `GetById()` call on the client requires both the resource ID _and_ the API version of the service, we make an additional [call to the client to get the resource provider](https://github.com/Azure/azure-powershell/blob/main/src/Resources/ResourceManager/SdkClient/ResourceManagerSdkClient.cs#L1143-L1164) of the resource we're trying to get, and when we [match the resource type from the provider](https://github.com/Azure/azure-powershell/blob/main/src/Resources/ResourceManager/SdkClient/ResourceManagerSdkClient.cs#L1168-L1170), we use either the default API version previously provided, or the latest API version of the service, and then [make the `GetById()` call](https://github.com/Azure/azure-powershell/blob/main/src/Resources/ResourceManager/SdkClient/ResourceManagerSdkClient.cs#L1173-L1177).

If the resource ID could not be constructed, but the user did provide a value for `-ResourceId`, then it would also follow the same flow mentioned above _unless_ the ID provided was partial and not pointing to a specific resource, but a collection of resources. For example, the resource ID `/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/MyResourceGroup/providers/Microsoft.Compute/virtualMachines/MyVM` points to a specific VM called "MyVM" in the resource group "MyResourceGroup", but if the user were to provide the ID `/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/MyResourceGroup/providers/Microsoft.Compute/virtualMachines`, then we would expect to return _all_ VMs in the resource group "MyResourceGroup". Since the `ResourceManagerClient` does not support this scenario, we need to use the generic `HttpClient` to list these resources for the given resource ID.

The last scenario that we would possibly use the generic `HttpClient` for this cmdlet would be if the user provided either the `-ApiVersion` or `-ExpandProperties` parameters. The `-ApiVersion` parameter is used to define which API version of the service should be used when retrieving the resource(s), which can change the values in the `Properties` property on the returned object(s). By default the `Get-AzResource` cmdlet is handled by the ARM service and returns only the generic parts of the resource managed by ARM which are common to all resources (e.g., `ResourceId`, `Sku`, `Tags`, etc.). The `-ExpandProperties` switch parameter is used to signal that the `Properties` property on the returned object(s) should be expanded and include all resource specific information. The `ResourceManagerClient` doesn't allow for either of these scenarios (outside of providing an API version for a resource ID, which was covered previously), so the `HttpClient` must be used to provide users with this functionality.

For all other scenarios, the `ResourceManagerClient` is used either to [list all resources in a given resource group](https://github.com/Azure/azure-powershell/blob/main/src/Resources/ResourceManager/Implementation/Resource/GetAzureResourceCmdlet.cs#L178) or [list all resources in the current subscription](https://github.com/Azure/azure-powershell/blob/main/src/Resources/ResourceManager/Implementation/Resource/GetAzureResourceCmdlet.cs#L182).

**New-AzResource**

Unlike the `Get-AzResource` cmdlet, the `New-AzResource` cmdlet only uses the generic `HttpClient` to make calls to the server to create a resource. With this cmdlet, a user can create a resource at the tenant or subscription level against a specified API version with a defined set of properties. The cmdlet [constructs the resource ID](https://github.com/Azure/azure-powershell/blob/main/src/Resources/ResourceManager/Implementation/Resource/NewAzureResourceCmdlet.cs#L96) from the given identity parameters, [sets up the body](https://github.com/Azure/azure-powershell/blob/main/src/Resources/ResourceManager/Implementation/Resource/NewAzureResourceCmdlet.cs#L105) of the request from the property parameters, and [sends the `PUT` request](https://github.com/Azure/azure-powershell/blob/main/src/Resources/ResourceManager/Implementation/Resource/NewAzureResourceCmdlet.cs#L107-L124) to the server using the `HttpClient` in order to create the resource.

In the future, it should be determined whether or not the `ResourceManagerClient` can be used to make the subscription level calls as it has two functions, `CreateOrUpdate()` and `CreateOrUpdateById()`, which should be able to perform the same steps outlined above.

**Set-AzResource**

Also like the `New-AzResource` cmdlet, the `Set-AzResource` cmdlet only uses the generic `HttpClient` to make calls to the server to update a resource. This cmdlet gives users the ability to perform either a `PUT` or `PATCH` operation on the server to update the given resource. If the user provides the identity properties of a resource as parameters, they can perform a `PATCH` operation by providing the `-UsePatchSemantics` switch, providing a value for the `-Tag` or `-Sku` parameters, or not providing a value for the `-Plan`, `-Properties` and `-Kind` parameters. If the user doesn't do [any of the previous three](https://github.com/Azure/azure-powershell/blob/main/src/Resources/ResourceManager/Implementation/Resource/SetAzureResourceCmdlet.cs#L226-L229), than the cmdlet will perform a `PUT` operation.

If the user provides a `PSResource` object to the `-InputObject` parameter, then the cmdlet will push the value of the properties on the object to the server, [unless overwritten by a parameter provided on the command line](https://github.com/Azure/azure-powershell/blob/main/src/Resources/ResourceManager/Implementation/Resource/SetAzureResourceCmdlet.cs#L94-L102). For example, if the user provides a `PSResource` for `-InputObject` and a new `Hashtable` for `-Tag`, then the tags defined on the given resource will be overwritten with whatever is in the `Hashtable` provided, and all other properties on the `PSResource` will be pushed to the server.

#### Piping Scenarios

```powershell
# Update the tags with a new key-value pair for all resources
Get-AzResource @FilterParameters | ForEach-Object { $_.Tags.Add("SampleKey", "SampleValue") } | Set-AzResource -Force

# Update a single property on a resource
$Resource = Get-AzResource -ResourceGroupName MyResourceGroup -ResourceType Microsoft.Web/sites -Name MySite
$Resource.Properties.Enabled = "False"
$Resource | Set-AzResource -Force
```

## `Resources` project

The `Resources` project contains all of the Active Directory, Authorization, and Management Groups cmdlets.

### Active Directory Applications

From the [_Application and service principal objects in Azure Active Directory_](https://docs.microsoft.com/en-us/azure/active-directory/develop/app-objects-and-service-principals#application-object) document, an Azure AD application is defined as the following:

_An Azure AD application is defined by its one and only application object, which resides in the Azure AD tenant where the application was registered, known as the application's "home" tenant._

_The application object serves as the template from which common and default properties are derived for use in creating corresponding service principal objects. An application object therefore has a 1:1 relationship with the software application, and a 1:many relationships with its corresponding service principal object(s)._

The cmdlets currently found in the `Az.Resources` module that act upon applications are the following:

- [`Get-AzADAppCredential`](https://github.com/Azure/azure-powershell/blob/main/src/Resources/Resources/help/Get-AzADAppCredential.md)
- [`Get-AzADApplication`](https://github.com/Azure/azure-powershell/blob/main/src/Resources/Resources/help/Get-AzADApplication.md)
- [`New-AzADAppCredential`](https://github.com/Azure/azure-powershell/blob/main/src/Resources/Resources/help/New-AzADAppCredential.md)
- [`New-AzADApplication`](https://github.com/Azure/azure-powershell/blob/main/src/Resources/Resources/help/New-AzADApplication.md)
- [`Remove-AzADAppCredential`](https://github.com/Azure/azure-powershell/blob/main/src/Resources/Resources/help/Remove-AzADAppCredential.md)
- [`Remove-AzADApplication`](https://github.com/Azure/azure-powershell/blob/main/src/Resources/Resources/help/Remove-AzADApplication.md)
- [`Update-AzADApplication`](https://github.com/Azure/azure-powershell/blob/main/src/Resources/Resources/help/Update-AzADApplication.md)

#### Piping Scenarios

```powershell
# Remove a set of applications
Get-AzADApplication @FilterParameters | Remove-AzADApplication

# (PATCH) Update a set of applications
Get-AzADApplication @FilterParameters | Update-AzADApplication @PatchParameters

# Get the credentials for a set of applications
Get-AzADApplication @FilterParameters | Get-AzADAppCredential

# Create a new credential for a set of applications
Get-AzADApplication @FilterParameters | New-AzADAppCredential @PutParameters

# Remove the credentials from a set of applications
Get-AzADApplication @FilterParameters | Remove-AzADAppCredential
```

### Active Directory Groups

From the [_Manage app and resource access using Azure Active Directory groups_](https://docs.microsoft.com/en-us/azure/active-directory/fundamentals/active-directory-manage-groups#how-does-access-management-in-azure-ad-work) document, an Azure AD group does the following:

_Using groups lets the resource owner (or Azure AD directory owner), assign a set of access permissions to all the members of the group, instead of having to provide the rights one-by-one. The resource or directory owner can also give management rights for the member list to someone else, such as a department manager or a Helpdesk administrator, letting that person add and remove members, as needed._

The cmdlets currently found in the `Az.Resources` module that act upon groups are the following:

- [`Add-AzADGroupMember`](https://github.com/Azure/azure-powershell/blob/main/src/Resources/Resources/help/Add-AzADGroupMember.md)
- [`Get-AzADGroup`](https://github.com/Azure/azure-powershell/blob/main/src/Resources/Resources/help/Get-AzADGroup.md)
- [`Get-AzADGroupMember`](https://github.com/Azure/azure-powershell/blob/main/src/Resources/Resources/help/Get-AzADGroupMember.md)
- [`New-AzADGroup`](https://github.com/Azure/azure-powershell/blob/main/src/Resources/Resources/help/New-AzADGroup.md)
- [`Remove-AzADGroup`](https://github.com/Azure/azure-powershell/blob/main/src/Resources/Resources/help/Remove-AzADGroup.md)
- [`Remove-AzADGroupMember`](https://github.com/Azure/azure-powershell/blob/main/src/Resources/Resources/help/Remove-AzADGroupMember.md)

#### Piping Scenarios

```powershell
# Remove a set of groups
Get-AzADUser @FilterParameters | Remove-AzADUser

# Get the users of a set of groups
Get-AzADGroup @FilterParameters | Get-AzADGroupMember

# Add a user to a set of groups
Get-AzADGroup @FilterParameters | Add-AzADGroupMember @UserParameters

# Remove a user from a set of groups
Get-AzADGroup @FilterParameters | Remove-AzADGroupMember @UserParameters
```

### Active Directory Service Principals

From the [_Application and service principal objects in Azure Active Directory_](https://docs.microsoft.com/en-us/azure/active-directory/develop/app-objects-and-service-principals) document, a service principal is defined as the following:

_When an application is given permission to access resources in a tenant (upon registration or consent), a service principal object is created._

_A service principal must be created in each tenant where the application is used, enabling it to establish an identity for sign-in and/or access to resources being secured by the tenant. A single-tenant application has only one service principal (in its home tenant), created and consented for use during application registration. A multi-tenant Web application/API also has a service principal created in each tenant where a user from that tenant has consented to its use._

The cmdlets currently found in the `Az.Resources` module that act upon service principals are the following:

- [`Get-AzADServicePrincipal`](https://github.com/Azure/azure-powershell/blob/main/src/Resources/Resources/help/Get-AzADServicePrincipal.md)
- [`Get-AzADSpCredential`](https://github.com/Azure/azure-powershell/blob/main/src/Resources/Resources/help/Get-AzADSpCredential.md)
- [`New-AzADServicePrincipal`](https://github.com/Azure/azure-powershell/blob/main/src/Resources/Resources/help/New-AzADServicePrincipal.md)
- [`New-AzADSpCredential`](https://github.com/Azure/azure-powershell/blob/main/src/Resources/Resources/help/New-AzADSpCredential.md)
- [`Remove-AzADServicePrincipal`](https://github.com/Azure/azure-powershell/blob/main/src/Resources/Resources/help/Remove-AzADServicePrincipal.md)
- [`Remove-AzADSpCredential`](https://github.com/Azure/azure-powershell/blob/main/src/Resources/Resources/help/Remove-AzADSpCredential.md)
- [`Update-AzADServicePrincipal`](https://github.com/Azure/azure-powershell/blob/main/src/Resources/Resources/help/Update-AzADServicePrincipal.md)

#### User Scenarios

A common scenario is for a user to create a service principal in order to automate Azure management tasks.When a service principal is used to automate management tasks, it must have a credential, and it must be given permissions to manage the resources that are part of its task. The `New-AzADServicePrincipal` cmdlet allows the user to create a service principal, give it secure credentials, and allow the service principal the appropriate level of access in Azure through issuing a single cmdlet. If the user provided a value for either the `-Role` or `-Scope` parameter, once the service principal was created, a [call to the authorization SDK](https://github.com/Azure/azure-powershell/blob/main/src/Resources/Resources/ActiveDirectory/Cmdlets/NewAzureADServicePrincipalCommand.cs#L346-L380) would be made to assign the specified role to the service principal over the given scope. If neither parameter was provided, or the `-SkipAssignment` switch was set, then a role assignment would not be created. If only `-Role` was provided, `-Scope` would be [set to the user's current subscription](https://github.com/Azure/azure-powershell/blob/main/src/Resources/Resources/ActiveDirectory/Cmdlets/NewAzureADServicePrincipalCommand.cs#L252-L256), and if only `-Scope` was provided, `-Role` would be [set to the "Contributor"](https://github.com/Azure/azure-powershell/blob/main/src/Resources/Resources/ActiveDirectory/Cmdlets/NewAzureADServicePrincipalCommand.cs#L260-L264).

```powershell
# Create a service principal with no permissions
New-AzADServicePrincipal @Properties

# Create a service principal with "Reader" permissions over the current subscription
New-AzADServicePrincipal -Role Reader @Properties

# Create a service principal with "Contributor" permissions over the "MyResourceGroup" resource group
New-AzADServicePrincipal -Scope /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/MyResourceGroup @Properties

# Create a service principal with "Reader" permissions over the "MyResourceGroup" resource group
New-AzADServicePrincipal -Role Reader -Scope /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/MyResourceGroup @Properties
```

_Note_: for parity with Azure CLI, parameters should be added in the future that would allow for the user to create a self-signed certificate and create or retrieve a certificate from a specified Azure KeyVault. Since .NET Standard does not include a cross-platform library for certificate creation, platform-specific mechanisms for creating certificates will need to be identified.

Another scenario added for the `New-AzADServicePrincipal` cmdlet was to introduce smart defaults for properties that the user may not know the value of, or may not care to provide a value for, when creating a service principal. The following are the parameters that have smart defaults for this cmdlet:

- `-DisplayName`
    - Defaults to "azure-powershell-MM-dd-yyyy-HH-mm-ss", where "MM-dd-yyyy-HH-mm-ss" is the starting date of the service principal
- `-StartDate`
    - Defaults to the current time (in UTC)
- `-EndDate`
    - Defaults to one year after the value of `-StartDate`
- `-Password`
    - Defaults to a generated GUID that the user can retrieve from the `Secret` property on the object returned from this cmdlet
- `-Scope`
    - As mentioned previously, defaults to the current subscription ("/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx")
- `-Role`
    - As mentioned previously, defaults to "Contributor"

#### Piping Scenarios

```powershell
# Get the service principals for a set of applications
Get-AzADApplication @FilterParameters | Get-AzADServicePrincipal

# Create a service principal for a set of applications
Get-AzADApplication @FilterParameters | New-AzADServicePrincipal @PutParameters

# Remove a set of service principals
Get-AzADServicePrincipal @FilterParameters | Remove-AzADServicePrincipal

# Remove a set of service principals from the given applications
Get-AzADApplication @FilterParameters | Remove-AzADServicePrincipal

# (PATCH) Update a set of service principals
Get-AzADServicePrincipal @FilterParameters | Update-AzADServicePrincipal @PatchParameters

# Get the credentials for a set of service principals
Get-AzADServicePrincipal @FilterParameters | Get-AzADSpCredential

# Create a new credential for a set of service principals
Get-AzADServicePrincipal @FilterParameters | New-AzADSpCredential @PutParameters

# Remove the credentials from a set of service principals
Get-AzADServicePrincipal @FilterParameters | Remove-AzADSpCredential
```

### Active Directory Users

The cmdlets currently found in this `Az.Resources` module that act upon users are the following:

- [`Get-AzADUser`](https://github.com/Azure/azure-powershell/blob/main/src/Resources/Resources/help/Get-AzADUser.md)
- [`New-AzADUser`](https://github.com/Azure/azure-powershell/blob/main/src/Resources/Resources/help/New-AzADUser.md)
- [`Remove-AzADUser`](https://github.com/Azure/azure-powershell/blob/main/src/Resources/Resources/help/Remove-AzADUser.md)
- [`Update-AzADUser`](https://github.com/Azure/azure-powershell/blob/main/src/Resources/Resources/help/Update-AzADUser.md)

#### Piping Scenarios

```powershell
# Remove a set of users
Get-AzADUser @FilterParameters | Remove-AzADUser

# (PATCH) Update a set of users
Get-AzADUser @FilterParameters | Update-AzADUser @PatchParameters
```
