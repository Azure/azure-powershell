### Example 1: {{ Add title here }}
```powershell
PS C:\> New-AzStaticWebAppUserRoleInvitationLink -ResourceGroupName lucas-rg-test -Name staticweb-pwsh02 -Domain 'blue-wave-0e445fe0f.azurestaticapps.net' -Provider 'github' -UserDetail 'LucasYao93' -Role 'reader' -NumHoursToExpiration 1

Kind Name                                 Type
---- ----                                 ----
     078284a9-ce47-4aa5-b54c-2e55a67dd53c Microsoft.Web/staticSites/invitations
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> $web = Get-AzStaticWebApp -ResourceGroupName $env.resourceGroup -Name $env.staticweb00
PS C:\> New-AzStaticWebAppUserRoleInvitationLink -InputObject $web -Domain $web.DefaultHostname -Provider 'github' -UserDetail 'LucasYao93' -Role 'admin,contributor' -NumHoursToExpiration 1


{{ Add output here }}
```

{{ Add description here }}

