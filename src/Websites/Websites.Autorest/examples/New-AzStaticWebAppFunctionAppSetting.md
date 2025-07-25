### Example 1: Create or updates the function app settings of a static site
```powershell
New-AzStaticWebAppFunctionAppSetting -ResourceGroupName azure-rg-test -Name staticweb-pwsh01  -AppSetting @{'function01' = 'value01'; 'function02' = 'value02' }
```
```output
Kind Name        Type
---- ----        ----
     appsettings Microsoft.Web/staticSites/config
```

This command creates or updates the function app settings of a static site.

### Example 2: Create or updates the function app settings of a static site by pipeline
```powershell
Get-AzStaticWebAppFunctionAppSetting -ResourceGroupName resourceGroup -Name staticweb01 | New-AzStaticWebAppFunctionAppSetting -AppSetting @{'function01' = 'value01'; 'function02' = 'value02' }
```
```output
Kind Name        Type
---- ----        ----
     appsettings Microsoft.Web/staticSites/config
```

This command creates or updates the function app settings of a static site by pipeline.