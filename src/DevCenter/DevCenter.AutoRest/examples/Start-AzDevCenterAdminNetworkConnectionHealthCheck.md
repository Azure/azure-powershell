### Example 1: Start health checks for a network connection
```powershell
Start-AzDevCenterAdminNetworkConnectionHealthCheck -NetworkConnectionName eastusNetwork -ResourceGroupName testRg
```
This command starts the health checks for the network connection "eastusNetwork".

### Example 2: Start health checks for a network connection using InputObject
```powershell
$networkConnection = @{"ResourceGroupName" = "testRg"; "NetworkConnectionName" = "eastusNetwork"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
Start-AzDevCenterAdminNetworkConnectionHealthCheck -InputObject $networkConnection
```
This command starts the health checks for the network connection "eastusNetwork".

