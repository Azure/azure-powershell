### Example 1: Create an invitation link for a user with the role
```powershell
New-AzStaticWebAppUserRoleInvitationLink -ResourceGroupName azure-rg-test -Name staticweb-pwsh02 -Domain 'xxxxxxxxx.azurestaticapps.net' -Provider 'github' -UserDetail 'UserName' -Role 'reader' -NumHoursToExpiration 1
```
```output
Kind Name                                 Type
---- ----                                 ----
     078284a9-ce47-4aa5-b54c-2e55a67dd53c Microsoft.Web/staticSites/invitations
```

This command creates an invitation link for a user with the role.

### Example 2: Create an invitation link for a user with the role by pipeline
```powershell
$web = Get-AzStaticWebApp -ResourceGroupName resourceGroup -Name staticweb00
New-AzStaticWebAppUserRoleInvitationLink -InputObject $web -Domain 'Hostname' -Provider 'github' -UserDetail 'UserName' -Role 'admin,contributor' -NumHoursToExpiration 1

```

This command creates an invitation link for a user with the role by pipeline.