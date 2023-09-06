### Example 1: List network connections in a subscription
```powershell
Get-AzDevCenterAdminNetworkConnection
```
This command lists network connections in the current subscription. 

### Example 2: List network connections in a resource group
```powershell
Get-AzDevCenterAdminNetworkConnection -ResourceGroupName testRg
```
This command lists the network connections under the resource group "testRg".

### Example 3: Get a network connection
```powershell
Get-AzDevCenterAdminNetworkConnection -ResourceGroupName testRg -Name eastusNetwork
```
This command gets the network connection named "eastusNetwork" under the resource group "testRg". 

### Example 4: Get a network connection using InputObject
```powershell
$networkConnection = @{"ResourceGroupName" = "testRg"; "NetworkConnectionName" = "eastusNetwork"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
Get-AzDevCenterAdminNetworkConnection -InputObject $networkConnection
```
This command gets the network connection named "eastusNetwork" under the resource group "testRg". 

