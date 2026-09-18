### Example 1: List customization tasks in a catalog
```powershell
Get-AzDevCenterAdminCustomizationTask -CatalogName CentralCatalog -DevCenterName Contoso -ResourceGroupName testRg
```
This command lists the customization tasks in the catalog named "CentralCatalog" under the dev center "Contoso".

### Example 2: Get a customization task in a catalog
```powershell
Get-AzDevCenterAdminCustomizationTask -CatalogName CentralCatalog -DevCenterName Contoso -ResourceGroupName testRg -TaskName SampleTask
```
This command gets the customization task "SampleTask" in the catalog named "CentralCatalog" under the dev center "Contoso".

### Example 3: Get a customization task in a catalog using InputObject
```powershell
$customizationTask = @{"ResourceGroupName" = "testRg"; "DevCenterName" = "Contoso"; "CatalogName" = "CentralCatalog"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"; "TaskName" = "SampleTask"}
$customizationTask = Get-AzDevCenterAdminCustomizationTask -InputObject $customizationTask
```
This command gets the customization task "SampleTask" in the catalog named "CentralCatalog" under the dev center "Contoso".
