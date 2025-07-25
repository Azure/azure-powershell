### Example 1: Start a pool health check
```powershell
Start-AzDevCenterAdminPoolHealthCheck -ResourceGroupName testRg -PoolName DevPool -ProjectName DevProject
```
This command starts the health check for the pool named "DevPool" in the project "DevProject".

### Example 2: Start a pool health check using InputObject
```powershell
$pool = @{"ResourceGroupName" = "testRg"; "ProjectName" = "DevProject"; "PoolName" = "DevPool"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
Start-AzDevCenterAdminPoolHealthCheck -InputObject $pool
```
This command start the health check of the pool named "DevPool" in the project "DevProject".
