### Example 1: {{ Add title here }}
```powershell
Get-AzDevCenterAdminProjectEnvironmentType -ProjectName DevProject -ResourceGroupName testRg
```
This command lists the environment types in the project "DevProject" under the resource group "testRg".

### Example 2: {{ Add title here }}
```powershell
Get-AzDevCenterAdminProjectEnvironmentType -ProjectName DevProject -ResourceGroupName testRg -EnvironmentTypeName DevTest
```
This command gets the environment type named "DevTest" in the project "DevProject" under the resource group "testRg". 

### Example 2: {{ Add title here }}
```powershell
$envType = @{"ResourceGroupName" = "testRg"; "ProjectName" = "DevProject"; "EnvironmentTypeName" = "DevTest"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
$envType = Get-AzDevCenterAdminProjectEnvironmentType -InputObject $envType
```
This command gets the environment type named "DevTest" in the project "DevProject" under the resource group "testRg". 
