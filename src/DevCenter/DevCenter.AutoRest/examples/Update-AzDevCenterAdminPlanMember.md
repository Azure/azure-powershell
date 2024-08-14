### Example 1: Update a plan member
```powershell
$tags = @{"dev" = "test" }

Update-AzDevCenterAdminPlanMember -PlanName ContosoPlan -MemberName d702f662-b3f2-4796-9e8c-13c22378ced3 -ResourceGroupName testRg -Tag $tags
```
This command updates a plan member named "d702f662-b3f2-4796-9e8c-13c22378ced3" in the plan "ContosoPlan". 


### Example 2: Update a plan member using InputObject
```powershell
$planMember = @{"ResourceGroupName" = "testRg"; "PlanName" = "ContosoPlan"; "MemberName" = "d702f662-b3f2-4796-9e8c-13c22378ced3"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
$tags = @{"dev" = "test" }

Update-AzDevCenterAdminPlanMember -InputObject $planMember -Tag $tags
```
This command updates a plan member named "d702f662-b3f2-4796-9e8c-13c22378ced3" in the plan "ContosoPlan". 

