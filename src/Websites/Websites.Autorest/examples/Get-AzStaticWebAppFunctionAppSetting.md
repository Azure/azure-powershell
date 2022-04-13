### Example 1: Get the application settings of a static site 
```powershell
Get-AzStaticWebAppFunctionAppSetting -ResourceGroupName azure-rg-test -Name staticweb-portal04
```
```output
Kind Name        Type
---- ----        ----
     appsettings Microsoft.Web/staticSites/config/functionappsettings
```

This command gets the application settings of a static site.
