### Example 1: Delete a plan
```powershell
Remove-AzDevCenterAdminPlan -Name ContosoPlan -ResourceGroupName testRg
```
This command deletes the plan "ContosoPlan" in the resource group "testRg".

### Example 2: Delete a plan using InputObject
```powershell
$plan = Get-AzDevCenterAdminPlan -ResourceGroupName testRg -Name ContosoPlan

Remove-AzDevCenterAdminPlan -InputObject $plan
```
This command deletes the plan "ContosoPlan" in the resource group "testRg".

