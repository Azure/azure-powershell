### Example 1: Create a dev box definition
```powershell
New-AzDevCenterAdminDevBoxDefinition -Name "WebDevBox" -DevCenterName Contoso -ResourceGroupName testRg -Location "westus3" -HibernateSupport "Enabled" -ImageReferenceId "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/testRg/providers/Microsoft.DevCenter/devcenters/Contoso/galleries/contosogallery/images/exampleImage/version/1.0.0" -OSStorageType "ssd_1024gb" -SkuName "general_a_8c32gb_v1" 
```
This command creates a dev box definition named "WebDevBox" in the dev center "Contoso". 

### Example 2: Create a dev box definition using InputObject
```powershell
$devBoxDefinition = @{"ResourceGroupName" = "testRg"; "DevCenterName" = "Contoso"; "DevBoxDefinitionName" = "WebDevBox"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
New-AzDevCenterAdminDevBoxDefinition -InputObject $devBoxDefinition -Location "westus3" -HibernateSupport "Enabled" -ImageReferenceId "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/testRg/providers/Microsoft.DevCenter/devcenters/Contoso/galleries/contosogallery/images/exampleImage/version/1.0.0" -OSStorageType "ssd_1024gb" -SkuName "general_a_8c32gb_v1"
```
This command creates a dev box definition named "WebDevBox" in the dev center "Contoso". 
