### Example 1: Get schedule by endpoint
```powershell
Get-AzDevCenterUserSchedule -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject -PoolName DevPool
```
This command gets the schedule in the pool "DevPool".

### Example 2: Get schedule by dev center
```powershell
Get-AzDevCenterUserSchedule -DevCenter Contoso -ProjectName DevProject -PoolName DevPool
```
This command gets the schedule in the pool "DevPool".

### Example 3: Get schedule by endpoint and InputObject
```powershell
$devBoxInput = @{"ProjectName" = "DevProject"; "PoolName" = "DevPool" }
Get-AzDevCenterUserSchedule -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $devBoxInput
```
This command gets the schedule in the pool "DevPool".

### Example 4: Get schedule by dev center and InputObject
```powershell
$devBoxInput = @{"ProjectName" = "DevProject"; "PoolName" = "DevPool" }
Get-AzDevCenterUserSchedule -DevCenter Contoso -InputObject $devBoxInput
```
This command gets the schedule in the pool "DevPool".
