### Example 1: Creates an invitation link for a user with the role
```powershell
PS C:\> New-AzStaticWebAppUserRoleInvitationLink -ResourceGroupName azure-rg-test -Name staticweb-pwsh02 -Domain 'blue-wave-0e445fe0f.azurestaticapps.net' -Provider 'github' -UserDetail 'LucasYao93' -Role 'reader' -NumHoursToExpiration 1

Kind Name                                 Type
---- ----                                 ----
     078284a9-ce47-4aa5-b54c-2e55a67dd53c Microsoft.Web/staticSites/invitations
```

This command creates an invitation link for a user with the role.

### Example 2: Creates an invitation link for a user with the role by pipeline
```powershell
PS C:\> $web = Get-AzStaticWebApp -ResourceGroupName resourceGroup -Name staticweb00
PS C:\> New-AzStaticWebAppUserRoleInvitationLink -InputObject $web -Domain 'Hostname' -Provider 'github' -UserDetail 'LucasYao93' -Role 'admin,contributor' -NumHoursToExpiration 1

```

This command creates an invitation link for a user with the role by pipeline.

