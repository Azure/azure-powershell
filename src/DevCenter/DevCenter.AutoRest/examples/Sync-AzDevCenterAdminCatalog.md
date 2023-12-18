### Example 1: Sync a catalog
```powershell
Sync-AzDevCenterAdminCatalog -DevCenterName Contoso -Name CentralCatalog -ResourceGroupName testRg
```
This command syncs the catalog named "CentralCatalog".

### Example 2: Sync a catalog using InputObject
```powershell
$catalog = @{"ResourceGroupName" = "testRg"; "DevCenterName" = "Contoso"; "CatalogName" = "CentralCatalog"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
Sync-AzDevCenterAdminCatalog -InputObject $catalog
```
This command syncs the catalog named "CentralCatalog".


