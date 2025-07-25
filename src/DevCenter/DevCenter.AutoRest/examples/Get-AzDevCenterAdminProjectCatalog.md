### Example 1: List project catalogs in a project
```powershell
Get-AzDevCenterAdminProjectCatalog -ProjectName DevProject -ResourceGroupName testRg
```
This command lists the catalogs in the project "DevProject" under the resource group "testRg".

### Example 2: Get a project catalog
```powershell
Get-AzDevCenterAdminProjectCatalog -ProjectName DevProject -CatalogName CentralCatalog -ResourceGroupName testRg
```
This command gets the catalog named "CentralCatalog" in the project "DevProject" under the resource group "testRg".

### Example 3: Get a project catalog using InputObject
```powershell
$catalog = @{"ResourceGroupName" = "testRg"; "ProjectName" = "DevProject"; "CatalogName" = "CentralCatalog"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
$catalog = Get-AzDevCenterAdminProjectCatalog -InputObject $catalog
```
This command gets the catalog named "CentralCatalog" in the project "DevProject" under the resource group "testRg".
