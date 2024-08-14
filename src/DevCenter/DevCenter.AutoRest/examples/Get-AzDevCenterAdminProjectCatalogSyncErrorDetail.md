### Example 1: Get the project catalog sync error dteail
```powershell
Get-AzDevCenterAdminProjectCatalogSyncErrorDetail -ProjectName DevProject -CatalogName CentralCatalog -ResourceGroupName testRg
```
This command gets the sync error detail of the catalog named "CentralCatalog" in the project "DevProject" under the resource group "testRg".

### Example 2: Get the project catalog sync error detail using InputObject
```powershell
$catalog = @{"ResourceGroupName" = "testRg"; "ProjectName" = "DevProject"; "CatalogName" = "CentralCatalog"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
$catalogErrorDetail = Get-AzDevCenterAdminProjectCatalogSyncErrorDetail -InputObject $catalog
```
This command gets the sync error detail of the catalog named "CentralCatalog" in the project "DevProject" under the resource group "testRg".
