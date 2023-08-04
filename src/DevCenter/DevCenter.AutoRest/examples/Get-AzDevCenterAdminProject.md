### Example 1: List projects in a subscription
```powershell
Get-AzDevCenterAdminProject
 ```
This command lists the projects in the current subscription.

### Example 2: List projects in a resource group
```powershell
Get-AzDevCenterAdminProject -ResourceGroupName testRg
```
This command lists the projects under the resource group "testRg".

### Example 3: Get a project
```powershell
Get-AzDevCenterAdminProject -ResourceGroupName testRg -Name DevProject
```
This command gets the project named "DevProject" under the resource group "testRg". 

### Example 4: Get a project using InputObject
```powershell
$project = @{"ResourceGroupName" = "testRg"; "ProjectName" = "DevProject"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
Get-AzDevCenterAdminProject -InputObject $project
```
This command gets the project named "DevProject" under the resource group "testRg". 
