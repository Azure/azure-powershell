### Example 1: List project allowed environment types
```powershell
Get-AzDevCenterAdminProjectAllowedEnvironmentType -ProjectName DevProject -ResourceGroupName testRg
```
This command lists the allowed environment types in the project "DevProject" under the resource group "testRg".

### Example 2: Get a project allowed environment type
```powershell
Get-AzDevCenterAdminProjectAllowedEnvironmentType -ProjectName DevProject -ResourceGroupName testRg -EnvironmentTypeName DevTest
```
This command gets the allowed environment type named "DevTest" in the project "DevProject" under the resource group "testRg". 

### Example 3: Get a project allowed environment type using InputObject
```powershell
$envType = @{"ResourceGroupName" = "testRg"; "ProjectName" = "DevProject"; "EnvironmentTypeName" = "DevTest"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
Get-AzDevCenterAdminProjectAllowedEnvironmentType -InputObject $envType
```
This command gets the allowed environment type named "DevTest" in the project "DevProject" under the resource group "testRg". 
