### Example 1: Delete an attached network
```powershell
Remove-AzDevCenterAdminAttachedNetwork -ConnectionName network-uswest3 -DevCenterName Contoso -ResourceGroupName testRg
```
This command deletes the attached network "network-uswest32" in the dev center "Contoso". 

### Example 2: Delete an attached network
```powershell
$id = "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/testRg/providers/Microsoft.DevCenter/devcenters/Contoso/attachednetworks/network-uswest32"

$attachedNetwork = @{"Id" = $id}
Remove-AzDevCenterAdminAttachedNetwork -InputObject $attachedNetwork
```
This command deletes the attached network "network-uswest32" in the dev center "Contoso". 
