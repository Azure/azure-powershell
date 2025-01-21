### Example 1: Deletes an plan member
```powershell
Remove-AzDevCenterAdminPlanMember -ResourceGroupName testRg -PlanName ContosoPlan -MemberName d702f662-b3f2-4796-9e8c-13c22378ced3
```
This command deletes the plan member d702f662-b3f2-4796-9e8c-13c22378ced3 in the plan "ContosoPlan". 

### Example 2: Deletes an plan member using InputObject
```powershell
$planMember = Get-AzDevCenterAdminPlanMember -ResourceGroupName testRg -PlanName ContosoPlan -MemberName d702f662-b3f2-4796-9e8c-13c22378ced3
Remove-AzDevCenterAdminPlanMember -InputObject $planMember
```
This command deletes the plan member "d702f662-b3f2-4796-9e8c-13c22378ced3" in the plan "ContosoPlan". 
