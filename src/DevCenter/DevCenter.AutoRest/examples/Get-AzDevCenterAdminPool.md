### Example 1: List pools in a project
```powershell
Get-AzDevCenterAdminPool -ResourceGroupName testRg -ProjectName DevProject
```
This command lists the pools in the project "DevProject" under the resource group "testRg".

### Example 2: Get a pool
```powershell
Get-AzDevCenterAdminPool -ResourceGroupName testRg -Name DevPool -ProjectName DevProject
```
This command gets the pool named "DevPool" in the project "DevProject" under the resource group "testRg". 

### Example 3: Get a pool using InputObject
```powershell
$pool = @{"ResourceGroupName" = "testRg"; "ProjectName" = "DevProject"; "PoolName" = "DevPool"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
Get-AzDevCenterAdminPool -InputObject $pool
```
This command gets the pool named "DevPool" in the project "DevProject" under the resource group "testRg". 
