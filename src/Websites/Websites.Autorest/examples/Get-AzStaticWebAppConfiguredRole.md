### Example 1: List configured roles of the static web app
```powershell
PS C:\> Get-AzStaticWebAppConfiguredRole -ResourceGroupName azure-rg-test -Name staticweb-portal04

Kind Name            Type                                      Property
---- ----            ----                                      --------
     configuredRoles Microsoft.Web/staticSites/configuredRoles {anonymous, authenticated}

This command lists configured roles of the static web app.

