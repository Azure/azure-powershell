### Example 1: Create or updates the app settings of a static site build
```powershell
New-AzStaticWebAppBuildAppSetting -ResourceGroupName azure-rg-test -Name staticweb-pwsh01 -EnvironmentName 'default'  -AppSetting @{'buildsetting1' = 'someval'; 'buildsetting2' = 'someval2' }
```
```output
Kind Name        Type
---- ----        ----
     appsettings Microsoft.Web/staticSites/builds/config
```

This command creates or updates the app settings of a static site build.

### Example 2: Create or updates the app settings of a static site build by pipeline
```powershell
Get-AzStaticWebAppBuildAppSetting -ResourceGroupName resourceGroup -Name taticweb00 -EnvironmentName 'default' | New-AzStaticWebAppBuildAppSetting -AppSetting @{'buildsetting1' = 'someval'; 'buildsetting2' = 'someval2' }
```
```output
Kind Name        Type
---- ----        ----
     appsettings Microsoft.Web/staticSites/builds/config
```

This command creates or updates the app settings of a static site by pipeline build.