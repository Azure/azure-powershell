### Example 1: Create a schedule
```powershell
New-AzDevCenterAdminSchedule -PoolName DevPool -ProjectName DevProject -ResourceGroupName testRg -State "Enabled" -Time "18:30" -TimeZone "America/Los_Angeles"
```
This command creates a schedule in the pool "DevPool".

### Example 2: Create a schedule using InputObject
```powershell
$schedule = @{"ResourceGroupName" = "testRg"; "ProjectName" = "DevProject"; "PoolName" = "DevPool"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
New-AzDevCenterAdminSchedule -InputObject $schedule
```
This command creates a schedule in the pool "DevPool".

