### Example 1: Connect a catalog
```powershell
Connect-AzDevCenterAdminCatalog -DevCenterName Contoso -Name CentralCatalog -ResourceGroupName testRg
```
This command connects the catalog named "CentralCatalog" in the dev center "Contoso" under the resource group "testRg".

### Example 2: Connect a catalog using InputObject
```powershell
$catalog = @{"ResourceGroupName" = "testRg"; "DevCenterName" = "Contoso"; "CatalogName" = "CentralCatalog"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
$catalog = Connect-AzDevCenterAdminCatalog -InputObject $catalog
```
This command connects the catalog named "CentralCatalog" in the dev center "Contoso" under the resource group "testRg".

