### Example 1: Delete a project
```powershell
Remove-AzDevCenterAdminProject -ResourceGroupName testRg -Name DevProject
```
This command deletes the project named "DevProject" in the resource group "testRg".

### Example 2: Delete a project using InputObject
```powershell
$project = Get-AzDevCenterAdminProject -ResourceGroupName testRg -Name DevProject
Remove-AzDevCenterAdminProject -InputObject $project
```
This command deletes the project named "DevProject" in the resource group "testRg".
