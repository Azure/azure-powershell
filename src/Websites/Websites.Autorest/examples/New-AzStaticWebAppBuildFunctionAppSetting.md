### Example 1: Creates or updates the app settings of a static site build
```powershell
PS C:\> New-AzStaticWebAppBuildFunctionAppSetting -ResourceGroupName azure-rg-test -Name staticweb-pwsh01 -EnvironmentName 'default' -Property @{'functionapp01' = 'value01'; 'functionapp02' = 'value02' }

Kind Name        Type
---- ----        ----
     appsettings Microsoft.Web/staticSites/builds/config
```

This command creates or updates the app settings of a static site build.

### Example 2: Creates or updates the app settings of a static site build by pipeline
```powershell
PS C:\> Get-AzStaticWebAppBuildFunctionAppSetting -ResourceGroupName resourceGroup -Name staticweb01 -EnvironmentName 'default' | New-AzStaticWebAppBuildFunctionAppSetting  -Property @{'buildsetting1' = 'someval'; 'buildsetting2' = 'someval2' }

Kind Name        Type
---- ----        ----
     appsettings Microsoft.Web/staticSites/builds/config
```

This command creates or updates the app settings of a static site build by pipeline.

