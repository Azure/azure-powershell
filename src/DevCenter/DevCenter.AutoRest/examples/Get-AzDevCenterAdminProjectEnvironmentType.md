### Example 1: List project environment types
```powershell
Get-AzDevCenterAdminProjectEnvironmentType -ProjectName DevProject -ResourceGroupName testRg
```
This command lists the environment types in the project "DevProject" under the resource group "testRg".

### Example 2: Get a project environment type
```powershell
Get-AzDevCenterAdminProjectEnvironmentType -ProjectName DevProject -ResourceGroupName testRg -EnvironmentTypeName DevTest
```
This command gets the environment type named "DevTest" in the project "DevProject" under the resource group "testRg". 

### Example 3: Get a project environment type using InputObject
```powershell
$envType = @{"ResourceGroupName" = "testRg"; "ProjectName" = "DevProject"; "EnvironmentTypeName" = "DevTest"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
Get-AzDevCenterAdminProjectEnvironmentType -InputObject $envType
```
This command gets the environment type named "DevTest" in the project "DevProject" under the resource group "testRg". 
