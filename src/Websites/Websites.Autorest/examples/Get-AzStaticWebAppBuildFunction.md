### Example 1: List all functions of a particular static site build
```powershell
Get-AzStaticWebAppBuildFunction -ResourceGroupName lucas-rg-test -Name staticweb-portal04 -EnvironmentName 'default'
```
```output
Kind Name            Type
---- ----            ----
     WeatherForecast Microsoft.Web/staticSites/builds/functions
```

This command lists all functions of a particular static site build.

