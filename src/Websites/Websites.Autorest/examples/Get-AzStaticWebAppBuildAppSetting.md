### Example 1: Get app setting of build under a static web app
```powershell
PS C:\>  Get-AzStaticWebAppBuildAppSetting -ResourceGroupName azure-rg-test -Name staticweb-portal04 -EnvironmentName 'default'

Kind Name        Type
---- ----        ----
     appsettings Microsoft.Web/staticSites/builds/config
```

This command gets app setting of build under a static web app.

