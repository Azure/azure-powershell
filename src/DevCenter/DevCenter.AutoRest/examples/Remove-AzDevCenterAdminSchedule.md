### Example 1: Delete a schedule
```powershell
Remove-AzDevCenterAdminSchedule -PoolName DevPool -ProjectName DevProject -ResourceGroupName testRg
```
This command deletes the schedule for the pool "DevPool" in the project "DevProject.

### Example 2: Delete a schedule using InputObject
```powershell
$schedule = Get-AzDevCenterAdminSchedule -PoolName DevPool -ProjectName DevProject -ResourceGroupName testRg
Remove-AzDevCenterAdminSchedule -InputObject $schedule
```
This command deletes the schedule for the pool "DevPool" in the project "DevProject.


