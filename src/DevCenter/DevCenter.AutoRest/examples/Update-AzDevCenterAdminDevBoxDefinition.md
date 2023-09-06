### Example 1: Update a dev box definition
```powershell
$vsImage = "microsoftvisualstudio_visualstudioplustools_vs-2022-pro-general-win10-m365-gen2"
$vsImageReferenceId = "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/testRg/providers/Microsoft.DevCenter/devcenters/Contoso/galleries/Default/images/" + $vsImage

$devBoxDefinition = Update-AzDevCenterAdminDevBoxDefinition -Name "WebDevBox" -DevCenterName Contoso -ResourceGroupName testRg -HibernateSupport "Disabled" -ImageReferenceId $vsImageReferenceId
```
This command updates a dev box definition named "WebDevBox" in the dev center "Contoso". 

### Example 2: Update a dev box definition using InputObject
```powershell
$id = "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/testRg/providers/Microsoft.DevCenter/devcenters/Contoso/devboxdefinitions/WebDevBox"
$devBoxDefinitionId = @{"Id" = $id }

$vsImage = "microsoftvisualstudio_visualstudioplustools_vs-2022-pro-general-win10-m365-gen2"
$vsImageReferenceId = "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/testRg/providers/Microsoft.DevCenter/devcenters/Contoso/galleries/Default/images/" + $vsImage

Update-AzDevCenterAdminDevBoxDefinition -InputObject $devBoxDefinitionId -HibernateSupport "Disabled" -ImageReferenceId $vsImageReferenceId
```
This command updates a dev box definition named "WebDevBox" in the dev center "Contoso". 

