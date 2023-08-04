### Example 1: Create an attached network
```powershell
New-AzDevCenterAdminAttachedNetwork -ConnectionName network-uswest3 -DevCenterName Contoso -ResourceGroupName testRg -NetworkConnectionId /subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/testRg/providers/Microsoft.DevCenter/NetworkConnections/network-uswest3
```
This command creates an attached network named "network-uswest3" in the dev center "Contoso". 

### Example 2: Create an attached network using InputObject
```powershell
$attachedNetwork = @{"ResourceGroupName" = "testRg"; "DevCenterName" = "Contoso"; "AttachedNetworkConnectionName" = "network-uswest3"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
New-AzDevCenterAdminAttachedNetwork -InputObject $attachedNetwork -NetworkConnectionId /subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/testRg/providers/Microsoft.DevCenter/NetworkConnections/network-uswest3
```
This command creates an attached network named "network-uswest3" in the dev center "Contoso". 
