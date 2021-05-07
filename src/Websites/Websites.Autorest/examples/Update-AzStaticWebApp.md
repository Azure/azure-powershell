### Example 1: Updates a static site
```powershell
PS C:\> Update-AzStaticWebApp -ResourceGroupName 'resourceGroup' -Name 'staticweb00'

Kind Location   Name             Type
---- --------   ----             ----
     Central US staticweb00 Microsoft.Web/staticSites
```

This command updates a static site.

### Example 2: Updates a static site by pipeline
```powershell
PS C:\> Get-AzStaticWebApp -ResourceGroupName 'resourceGroup' -Name 'staticweb00' | Update-AzStaticWebApp

Kind Location   Name             Type
---- --------   ----             ----
     Central US staticweb00 Microsoft.Web/staticSites
```

This command updates a static site by pipeline.

