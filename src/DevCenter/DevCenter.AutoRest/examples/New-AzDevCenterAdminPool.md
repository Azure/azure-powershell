### Example 1: Create a pool
```powershell
New-AzDevCenterAdminPool -Name DevPool -ProjectName DevProject -ResourceGroupName testRg -Location westus2 -DevBoxDefinitionName WebDevBox -LocalAdministrator "Enabled" -NetworkConnectionName Network1westus2
```
This command creates a pool named "DevPool" in the project "DevProject".

### Example 2: Create a pool using InputObject
```powershell
$pool = @{"ResourceGroupName" = "testRg"; "ProjectName" = "DevProject"; "PoolName" = "DevPool"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
New-AzDevCenterAdminPool -InputObject $pool -Location westus2 -DevBoxDefinitionName WebDevBox -LocalAdministrator "Enabled" -NetworkConnectionName Network1westus2 
```
This command creates a pool named "DevPool" in the project "DevProject".

