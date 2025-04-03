### Example 1: Sync a project catalog
```powershell
Sync-AzDevCenterAdminProjectCatalog -ProjectName DevProject -CatalogName CentralCatalog -ResourceGroupName testRg
```
This command syncs the project catalog named "CentralCatalog".

### Example 2: Sync a project catalog using InputObject
```powershell
$catalog = @{"ResourceGroupName" = "testRg"; "ProjectName" = "DevProject"; "CatalogName" = "CentralCatalog"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
Sync-AzDevCenterAdminProjectCatalog -InputObject $catalog
```
This command syncs the project catalog named "CentralCatalog".


