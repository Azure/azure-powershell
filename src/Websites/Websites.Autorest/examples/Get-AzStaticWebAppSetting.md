### Example 1: Get the application settings of a static site
```powershell
Get-AzStaticWebAppSetting -ResourceGroupName resourceGroup -Name staticweb00
```
```output
Kind Name        Type
---- ----        ----
     appsettings Microsoft.Web/staticSites/config
```

This command gets the application settings of a static site.

