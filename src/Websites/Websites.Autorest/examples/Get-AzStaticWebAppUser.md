### Example 1: Get the list of users of a static site
```powershell
Get-AzStaticWebAppUser -ResourceGroupName azure-rg-test -Name staticweb-portal04 -Authprovider all
```
```output
Kind Name                             Type
---- ----                             ----
     c387198f0a7f44748184c9da92cbe241 Microsoft.Web/staticSites/users
```

This command gets the list of users of a static site.

