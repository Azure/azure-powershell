### Example 1: List all build functions under a static web
```powershell
PS C:\> Get-AzStaticWebAppBuildFunction -ResourceGroupName lucas-rg-test -Name staticweb-portal04 -EnvironmentName 'default'

Kind Name            Type
---- ----            ----
     WeatherForecast Microsoft.Web/staticSites/builds/functions
```

This command lists all build functions under a static web.

