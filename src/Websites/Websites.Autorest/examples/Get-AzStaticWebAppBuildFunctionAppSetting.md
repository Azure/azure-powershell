### Example 1: List function app setting of build
```powershell
PS C:\> Get-AzStaticWebAppBuildFunctionAppSetting -ResourceGroupName azure-rg-test -Name staticweb-portal04 -EnvironmentName 'default'

Kind Name        Type
---- ----        ----
     appsettings Microsoft.Web/staticSites/builds/config/functionappsettings
```

This command lists function app setting of build.
