### Example 1: Get inherited settings for a project
```powershell
Get-AzDevCenterAdminProjectInheritedSetting -ProjectName DevProject -ResourceGroupName testRg
```
This command gets the inherited settings for the project "DevProject" under the resource group "testRg".

### Example 2: Get inherited settings for a project using InputObject
```powershell
$project = @{"ResourceGroupName" = "testRg"; "ProjectName" = "DevProject"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
$inheritedSettings = Get-AzDevCenterAdminProjectInheritedSetting -InputObject $project
```
This command gets the inherited settings for the project "DevProject" under the resource group "testRg". 

