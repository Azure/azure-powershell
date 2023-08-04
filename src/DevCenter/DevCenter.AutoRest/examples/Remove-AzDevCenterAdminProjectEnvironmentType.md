### Example 1: Delete a project environment type
```powershell
Remove-AzDevCenterAdminProjectEnvironmentType -ProjectName DevProject -ResourceGroupName testRg -EnvironmentTypeName DevTest
```
This command deletes a project environment type named "DevTest" in the project "DevProject".

### Example 2: Delete a project environment type using InputObject
```powershell
$projEnvType = Get-AzDevCenterAdminProjectEnvironmentType -ProjectName DevProject -ResourceGroupName testRg -EnvironmentTypeName DevTest
Remove-AzDevCenterAdminProjectEnvironmentType -InputObject $projEnvType
```
This command deletes a project environment type named "DevTest" in the project "DevProject".
