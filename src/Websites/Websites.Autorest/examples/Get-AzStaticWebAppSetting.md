### Example 1: Get the application settings of a static site
```powershell
PS C:\> Get-AzStaticWebAppSetting -ResourceGroupName resourceGroup -Name staticweb00

Kind Name        Type
---- ----        ----
     appsettings Microsoft.Web/staticSites/config
```

This command gets the application settings of a static site.

