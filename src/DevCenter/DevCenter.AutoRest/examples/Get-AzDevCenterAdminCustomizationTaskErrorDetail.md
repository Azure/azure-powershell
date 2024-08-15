### Example 1: Get customization task error detail
```powershell
Get-AzDevCenterAdminCustomizationTaskErrorDetail -CatalogName CentralCatalog -DevCenterName Contoso -ResourceGroupName testRg -TaskName SampleTask
```
This command gets the error details for the customization task "SampleTask" in the catalog named "CentralCatalog" under the dev center "Contoso".

### Example 2: Get customization task error detail using InputObject
```powershell
$customizationTask = @{"ResourceGroupName" = "testRg"; "DevCenterName" = "Contoso"; "CatalogName" = "CentralCatalog"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"; "TaskName" = "SampleTask"}
$customizationTaskErrorDetail = Get-AzDevCenterAdminCustomizationTaskErrorDetail -InputObject $customizationTask
```
This command gets the error details for the customization task "SampleTask" in the catalog named "CentralCatalog" under the dev center "Contoso".