### Example 1: Get schedule by endpoint
```powershell
Get-AzDevCenterUserSchedule -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject -PoolName DevPool -ScheduleName default
```
This command gets the schedule in the pool "DevPool".

### Example 2: Get schedule by dev center
```powershell
Get-AzDevCenterUserSchedule -DevCenterName Contoso -ProjectName DevProject -PoolName DevPool -ScheduleName default
```
This command gets the schedule in the pool "DevPool".

### Example 3: Get schedule by endpoint and InputObject
```powershell
$devBoxInput = @{"ProjectName" = "DevProject"; "PoolName" = "DevPool"; "ScheduleName" = "default" }
Get-AzDevCenterUserSchedule -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $devBoxInput
```
This command gets the schedule in the pool "DevPool".

### Example 4: Get schedule by dev center and InputObject
```powershell
$devBoxInput = @{"ProjectName" = "DevProject"; "PoolName" = "DevPool"; "ScheduleName" = "default" }
Get-AzDevCenterUserSchedule -DevCenterName Contoso -InputObject $devBoxInput
```
This command gets the schedule in the pool "DevPool".

### Example 5: List schedule by project and endpoint
```powershell
Get-AzDevCenterUserSchedule -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject
```
This command lists the schedules in the project "DevProject".

### Example 6: List schedule by project and dev center
```powershell
Get-AzDevCenterUserSchedule -DevCenterName Contoso -ProjectName DevProject
```
This command lists the schedules in the project "DevProject".

### Example 7: List schedule by pool and endpoint
```powershell
Get-AzDevCenterUserSchedule -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject -PoolName DevPool
```
This command lists the schedules in the pool "DevPool".

### Example 8: List schedule by pool and dev center
```powershell
Get-AzDevCenterUserSchedule -DevCenterName Contoso -ProjectName DevProject -PoolName DevPool
```
This command lists the schedules in the pool "DevPool".
