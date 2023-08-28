### Example 1: Get a schedule in a pool
```powershell
Get-AzDevCenterAdminSchedule -PoolName DevPool -ProjectName DevProject -ResourceGroupName testRg
```
This command gets a schedule in a pool "DevPool" under the project "DevProject.

### Example 2: Get a schedule in a pool using InputObject
```powershell
$schedule = @{"ResourceGroupName" = "testRg"; "ProjectName" = "DevProject"; "PoolName" = "DevPool"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
Get-AzDevCenterAdminSchedule -InputObject $schedule
```
This command gets a schedule in a pool "DevPool" under the project "DevProject.
