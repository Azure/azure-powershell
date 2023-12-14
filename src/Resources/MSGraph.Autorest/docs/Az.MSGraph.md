---
Module Name: Az.MSGraph
Module Guid: 9c1e9bcf-5175-4d03-99c7-a7f2f7040f46
Download Help Link: https://learn.microsoft.com/powershell/module/az.msgraph
Help Version: 1.0.0.0
Locale: en-US
---

# Az.MSGraph Module
## Description
Microsoft Azure PowerShell: MSGraph cmdlets

## Az.MSGraph Cmdlets
### [Add-AzADAppPermission](Add-AzADAppPermission.md)
Adds an API permission.

### [Add-AzADGroupMember](Add-AzADGroupMember.md)
Adds member to group.

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

### [Get-AzADServicePrincipalAppRoleAssignment](Get-AzADServicePrincipalAppRoleAssignment.md)
Get appRoleAssignments from servicePrincipals

### [Get-AzADSpCredential](Get-AzADSpCredential.md)
Lists key credentials and password credentials for an service principal.

### [Get-AzADUser](Get-AzADUser.md)
Lists entities from users or get entity from users by key

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

### [New-AzADServicePrincipalAppRoleAssignment](New-AzADServicePrincipalAppRoleAssignment.md)
Create new navigation property to appRoleAssignments for servicePrincipals

### [New-AzADSpCredential](New-AzADSpCredential.md)
Creates key credentials or password credentials for an service principal.

### [New-AzADUser](New-AzADUser.md)
Adds new entity to users

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

### [Remove-AzADServicePrincipalAppRoleAssignment](Remove-AzADServicePrincipalAppRoleAssignment.md)
Delete navigation property appRoleAssignments for servicePrincipals

### [Remove-AzADSpCredential](Remove-AzADSpCredential.md)
Removes key credentials or password credentials for an service principal.

### [Remove-AzADUser](Remove-AzADUser.md)
Deletes entity from users.

### [Update-AzADAppFederatedCredential](Update-AzADAppFederatedCredential.md)
Update the navigation property federatedIdentityCredentials in applications

### [Update-AzADApplication](Update-AzADApplication.md)
Updates entity in applications

### [Update-AzADGroup](Update-AzADGroup.md)
Update entity in groups

### [Update-AzADServicePrincipal](Update-AzADServicePrincipal.md)
Updates entity in service principal

### [Update-AzADServicePrincipalAppRoleAssignment](Update-AzADServicePrincipalAppRoleAssignment.md)
Update the navigation property appRoleAssignments in servicePrincipals

### [Update-AzADUser](Update-AzADUser.md)
Updates entity in users

