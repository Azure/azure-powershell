### Example 1: List all application settings of a static site build
```powershell
Get-AzStaticWebAppBuildFunctionAppSetting -ResourceGroupName azure-rg-test -Name staticweb-portal04 -EnvironmentName 'default'
```
```output
Kind Name        Type
---- ----        ----
     appsettings Microsoft.Web/staticSites/builds/config/functionappsettings
```

This command lists all application settings of a static site build.
