### Example 1: List catalogs in a dev center
```powershell
Get-AzDevCenterAdminCatalog -DevCenterName Contoso -ResourceGroupName testRg
```
This command lists the catalogs in the dev center "Contoso" under the resource group "testRg".

### Example 2: Get a catalog
```powershell
Get-AzDevCenterAdminCatalog -DevCenterName Contoso -Name CentralCatalog -ResourceGroupName testRg
```
This command gets the catalog named "CentralCatalog" in the dev center "Contoso" under the resource group "testRg".

### Example 3: Get a catalog using InputObject
```powershell
$catalog = @{"ResourceGroupName" = "testRg"; "DevCenterName" = "Contoso"; "CatalogName" = "CentralCatalog"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
$catalog = Get-AzDevCenterAdminCatalog -InputObject $catalog
```
This command gets the catalog named "CentralCatalog" in the dev center "Contoso" under the resource group "testRg".
