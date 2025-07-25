### Example 1: Update a project
```powershell
Update-AzDevCenterAdminProject -Name DevProject -ResourceGroupName testRg -MaxDevBoxesPerUser 5
```
This command updates a project name "DevProject" in the resource group "testRg".

### Example 2: Update a project using InputObject
```powershell
$projectInput = Get-AzDevCenterAdminProject -ResourceGroupName testRg -Name DevProject

Update-AzDevCenterAdminProject -InputObject $projectInput -MaxDevBoxesPerUser 5
```
This command updates a project name "DevProject" in the resource group "testRg".
