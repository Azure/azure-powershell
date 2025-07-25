### Example 1: Create an plan member
```powershell
$tags = @{"dev" ="test"}
New-AzDevCenterAdminPlanMember -PlanName ContosoPlan -MemberName d702f662-b3f2-4796-9e8c-13c22378ced3 -ResourceGroupName testRg -Tag $tags -MemberId d702f662-b3f2-4796-9e8c-13c22378ced3 -MemberType User
```
This command creates an plan member named "d702f662-b3f2-4796-9e8c-13c22378ced3" in the plan "ContosoPlan". 

### Example 2: Create an plan member using InputObject
```powershell
$tags = @{"dev" ="test"}
$planMember = @{"ResourceGroupName" = "testRg"; "PlanName" = "ContosoPlan"; "MemberName" = "d702f662-b3f2-4796-9e8c-13c22378ced3"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
New-AzDevCenterAdminPlanMember -InputObject $planMember -Tag $tags -MemberId d702f662-b3f2-4796-9e8c-13c22378ced3 -MemberType User
```
This command creates an plan member named "d702f662-b3f2-4796-9e8c-13c22378ced3" in the plan "ContosoPlan". 

