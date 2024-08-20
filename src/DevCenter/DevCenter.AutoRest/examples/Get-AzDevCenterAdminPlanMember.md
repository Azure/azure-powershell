### Example 1: List plan members in a plan
```powershell
Get-AzDevCenterAdminPlanMember -PlanName ContosoPlan -ResourceGroupName testRg
```
This command lists the plan members in the plan "ContosoPlan" under the resource group "testRg".

### Example 2: Get a plan member
```powershell
Get-AzDevCenterAdminPlanMember -PlanName ContosoPlan -MemberName d702f662-b3f2-4796-9e8c-13c22378ced3 -ResourceGroupName testRg
```
This command gets the plan member named "d702f662-b3f2-4796-9e8c-13c22378ced3" in the plan "ContosoPlan" under the resource group "testRg".

### Example 3: Get a plan member using InputObject
```powershell
$planMember = @{"ResourceGroupName" = "testRg"; "PlanName" = "ContosoPlan"; "MemberName" = "d702f662-b3f2-4796-9e8c-13c22378ced3"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
$planMember = Get-AzDevCenterAdminPlanMember -InputObject $planMember
```
This command gets the plan member named "d702f662-b3f2-4796-9e8c-13c22378ced3" in the plan "ContosoPlan" under the resource group "testRg".
