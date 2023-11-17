### Example 1: Update a static site
```powershell
Update-AzStaticWebApp -ResourceGroupName 'resourceGroup' -Name 'staticweb00'
```
```output
Kind Location   Name             Type
---- --------   ----             ----
     Central US staticweb00 Microsoft.Web/staticSites
```

This command updates a static site.

### Example 2: Update a static site by pipeline
```powershell
Get-AzStaticWebApp -ResourceGroupName 'resourceGroup' -Name 'staticweb00' | Update-AzStaticWebApp
```
```output
Kind Location   Name             Type
---- --------   ----             ----
     Central US staticweb00 Microsoft.Web/staticSites
```

This command updates a static site by pipeline.