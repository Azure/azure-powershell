### Example 1: Update a schedule
```powershell
New-AzDevCenterAdminSchedule -PoolName DevPool -ProjectName DevProject -ResourceGroupName testRg -State "Disabled" -Time "17:30" -TimeZone "America/New_York"
```
This command updates a schedule in the pool "DevPool".

### Example 2: Update a schedule using InputObject
```powershell
$scheduleInput = Get-AzDevCenterAdminSchedule -PoolName DevPool -ProjectName DevProject -ResourceGroupName testRg

New-AzDevCenterAdminSchedule -InputObject $scheduleInput -State "Disabled" -Time "17:30" -TimeZone "America/New_York"
```
This command updates a schedule in the pool "DevPool".
