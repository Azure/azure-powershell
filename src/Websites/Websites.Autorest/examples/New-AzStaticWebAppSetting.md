### Example 1: Create or updates the app settings of a static site
```powershell
PS C:\> New-AzStaticWebAppSetting -ResourceGroupName resourceGroup -Name staticweb01 -AppSetting @{'function01' = 'value01'; 'function02' = 'value02' }

Kind Name        Type
---- ----        ----
     appsettings Microsoft.Web/staticSites/config
```

This command creates or updates the app settings of a static site.

### Example 2: Create or updates the app settings of a static site by pipeline.
```powershell
PS C:\> Get-AzStaticWebAppSetting -ResourceGroupName resourceGroup -Name staticweb01 | New-AzStaticWebAppSetting -AppSetting @{'function01' = 'value01'; 'function02' = 'value02' }

Kind Name        Type
---- ----        ----
     appsettings Microsoft.Web/staticSites/config
```

This command creates or updates the app settings of a static site by pipeline. 

