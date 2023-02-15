### Example 1: Lists the roles configured for the static site
```powershell
Get-AzStaticWebAppConfiguredRole -ResourceGroupName azure-rg-test -Name staticweb-portal04
```
```output
Kind Name            Type                                      Property
---- ----            ----                                      --------
     configuredRoles Microsoft.Web/staticSites/configuredRoles {anonymous, authenticated}
```

This command lists the roles configured for the static site.

