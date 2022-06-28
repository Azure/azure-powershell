### Example 1: Get the application settings of a static web build
```powershell
Get-AzStaticWebAppBuildAppSetting -ResourceGroupName azure-rg-test -Name staticweb-portal04 -EnvironmentName 'default'
```
```output
Kind Name        Type
---- ----        ----
     appsettings Microsoft.Web/staticSites/builds/config
```

This command gets the application settings of a static web build.
