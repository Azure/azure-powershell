### Example 1: Get the catalog sync error details
```powershell
Get-AzDevCenterAdminCatalogSyncErrorDetail -DevCenterName Contoso -CatalogName CentralCatalog -ResourceGroupName testRg
```
This command gets the sync error detail of the catalog named "CentralCatalog" in the dev center "Contoso" under the resource group "testRg".

### Example 2: Get the catalog sync error detail using InputObject
```powershell
$catalog = @{"ResourceGroupName" = "testRg"; "DevCenterName" = "Contoso"; "CatalogName" = "CentralCatalog"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
$catalogErrorDetail = Get-AzDevCenterAdminCatalogSyncErrorDetail -InputObject $catalog
```
This command gets the sync error detail of the catalog named "CentralCatalog" in the dev center "Contoso" under the resource group "testRg".
