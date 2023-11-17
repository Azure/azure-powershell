### Example 1: List the health check details of a network connection
```powershell
Get-AzDevCenterAdminNetworkConnectionHealthDetail -NetworkConnectionName eastusNetwork -ResourceGroupName testRg
```
This command lists the health check details of the network connection "eastusNetwork" under the resource group "testRg".

### Example 2: List the health check details of a network connection using InputObject
```powershell
$networkConnection = @{"ResourceGroupName" = "testRg"; "NetworkConnectionName" = "eastusNetwork"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
Get-AzDevCenterAdminNetworkConnectionHealthDetail -InputObject $networkConnection
```
This command lists the health check details of the network connection "eastusNetwork" under the resource group "testRg".

