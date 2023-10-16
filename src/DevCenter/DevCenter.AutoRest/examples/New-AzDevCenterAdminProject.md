### Example 1: Create a project
```powershell
New-AzDevCenterAdminProject -Name DevProject -ResourceGroupName testRg -Location eastus -DevCenterId "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/testRg/providers/Microsoft.DevCenter/devcenters/Contoso" -MaxDevBoxesPerUser 3
```
This command creates a project name "DevProject" in the resource group "testRg".

### Example 2: Create a project using InputObject
```powershell
$project = @{"ResourceGroupName" = "testRg"; "ProjectName" = "DevProject"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
New-AzDevCenterAdminProject -InputObject $project -Location eastus -DevCenterId "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/testRg/providers/Microsoft.DevCenter/devcenters/Contoso" -MaxDevBoxesPerUser 3
```
This command creates a project name "DevProject" in the resource group "testRg".
