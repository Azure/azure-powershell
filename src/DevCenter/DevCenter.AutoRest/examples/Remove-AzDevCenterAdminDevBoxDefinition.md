### Example 1: Delete a dev box definition
```powershell
Remove-AzDevCenterAdminDevBoxDefinition -DevCenterName Contoso -Name WebDevBox -ResourceGroupName testRg
```
This command deletes the dev box definition "WebDevBox" in the dev center "Contoso". 

### Example 2: Delete a dev box definition using InputObject
```powershell
$id = "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/testRg/providers/Microsoft.DevCenter/devcenters/Contoso/devboxdefinitions/WebDevBox"

$devBoxDefinitionId = @{"Id" = $id }
Remove-AzDevCenterAdminDevBoxDefinition -InputObject $devBoxDefinitionId 
```
This command deletes the dev box definition "WebDevBox" in the dev center "Contoso". 

