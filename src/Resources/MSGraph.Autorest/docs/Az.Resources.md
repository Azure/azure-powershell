---
Module Name: Az.Resources
Module Guid: 26500ceb-dbf8-4aae-b866-5fa86b3ec272
Download Help Link: https://docs.microsoft.com/powershell/module/az.resources
Help Version: 1.0.0.0
Locale: en-US
---

# Az.Resources Module
## Description
Microsoft Azure PowerShell: MSGraph cmdlets

## Az.Resources Cmdlets
### [Add-AzADAppPermission](Add-AzADAppPermission.md)
Add an API permission.
The list of available permissions of API is property of application represented by service principal in tenant.

For instance, to get available permissions for Graph API:
* Azure Active Directory Graph: `Get-AzAdServicePrincipal -ApplicationId 00000002-0000-0000-c000-000000000000`
* Microsoft Graph: `Get-AzAdServicePrincipal -ApplicationId 00000003-0000-0000-c000-000000000000`

Application permissions under the `appRoles` property correspond to `Role` in `-Type`.
Delegated permissions under the `oauth2Permissions` property correspond to `Scope` in `-Type`.

User needs to grant consent via Azure Portal if the permission requires admin consent because Azure PowerShell doesn't support it yet.

### [Add-AzADGroupMember](Add-AzADGroupMember.md)
Add member to group.

### [Get-AzADAppCredential](Get-AzADAppCredential.md)
List key credentials and password credentials for an application.

### [Get-AzADApplication](Get-AzADApplication.md)
List entities from applications or get entity from applications by key

### [Get-AzADAppPermission](Get-AzADAppPermission.md)
List API permissions the application has requested.

### [Get-AzADGroup](Get-AzADGroup.md)
List entities from groups or get entity from groups by key

### [Get-AzADGroupMember](Get-AzADGroupMember.md)
List members from group.

### [Get-AzADServicePrincipal](Get-AzADServicePrincipal.md)
List entities from service principals or get entity from service principals by key

### [Get-AzADSpCredential](Get-AzADSpCredential.md)
List key credentials and password credentials for an service principal.

### [Get-AzADUser](Get-AzADUser.md)
List entities from users or get entity from users by key

### [New-AzADAppCredential](New-AzADAppCredential.md)
Create key credentials or password credentials for an application.

### [New-AzADApplication](New-AzADApplication.md)
Add new entity to applications

### [New-AzADGroup](New-AzADGroup.md)
Add new entity to groups

### [New-AzADServicePrincipal](New-AzADServicePrincipal.md)
Add new entity to servicePrincipals

### [New-AzADSpCredential](New-AzADSpCredential.md)
Create key credentials or password credentials for an service principal.

### [New-AzADUser](New-AzADUser.md)
Add new entity to users

### [Remove-AzADAppCredential](Remove-AzADAppCredential.md)
Remove key credentials or password credentials for an application.

### [Remove-AzADApplication](Remove-AzADApplication.md)
Delete entity from applications

### [Remove-AzADAppPermission](Remove-AzADAppPermission.md)
Remove an API permission.

### [Remove-AzADGroup](Remove-AzADGroup.md)
Delete entity from groups.

### [Remove-AzADGroupMember](Remove-AzADGroupMember.md)
Delete member from group
Users, contacts, and groups that are members of this group.
HTTP Methods: GET (supported for all groups), POST (supported for security groups and mail-enabled security groups), DELETE (supported only for security groups) Read-only.
Nullable.
Supports $expand.

### [Remove-AzADServicePrincipal](Remove-AzADServicePrincipal.md)
Delete entity from service principal.

### [Remove-AzADSpCredential](Remove-AzADSpCredential.md)
Remove key credentials or password credentials for an service principal.

### [Remove-AzADUser](Remove-AzADUser.md)
Delete entity from users.

### [Update-AzADApplication](Update-AzADApplication.md)
Update entity in applications

### [Update-AzADServicePrincipal](Update-AzADServicePrincipal.md)
Update entity in service principal

### [Update-AzADUser](Update-AzADUser.md)
Update entity in users

