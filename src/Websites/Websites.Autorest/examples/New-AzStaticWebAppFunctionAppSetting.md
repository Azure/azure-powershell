### Example 1: Creates or updates the function app settings of a static site
```powershell
PS C:\> New-AzStaticWebAppFunctionAppSetting -ResourceGroupName azure-rg-test -Name staticweb-pwsh01  -Property @{'function01' = 'value01'; 'function02' = 'value02' }

Kind Name        Type
---- ----        ----
     appsettings Microsoft.Web/staticSites/config
```

This command creates or updates the function app settings of a static site.

### Example 1: Creates or updates the function app settings of a static site by pipeline
```powershell
PS C:\> Get-AzStaticWebAppFunctionAppSetting -ResourceGroupName resourceGroup -Name staticweb01 | New-AzStaticWebAppFunctionAppSetting -Property @{'function01' = 'value01'; 'function02' = 'value02' }

Kind Name        Type
---- ----        ----
     appsettings Microsoft.Web/staticSites/config
```

This command creates or updates the function app settings of a static site by pipeline.

