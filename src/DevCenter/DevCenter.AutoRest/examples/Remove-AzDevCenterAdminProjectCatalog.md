### Example 1: Remove a project catalog
```powershell
Remove-AzDevCenterAdminProjectCatalog -ProjectName DevProject -CatalogName CentralCatalog -ResourceGroupName testRg
```
This command deletes the catalog named "CentralCatalog" in the project "DevProject". 

### Example 2: Remove a project catalog using InputObject
```powershell
$catalog = Get-AzDevCenterAdminProjectCatalog -ProjectName DevProject -CatalogName CentralCatalog -ResourceGroupName testRg
Remove-AzDevCenterAdminProjectCatalog -InputObject $catalog
```
This command deletes the catalog named "CentralCatalog" in the project "DevProject". 

