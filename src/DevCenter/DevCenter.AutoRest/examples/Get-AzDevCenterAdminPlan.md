### Example 1: List plans in a subscription
```powershell
Get-AzDevCenterAdminPlan
```
This command lists the plans in the current subscription.

### Example 2: List plans in a resource group
```powershell
Get-AzDevCenterAdminPlan -ResourceGroupName testRg
```
This command lists the plans under the resource group "testRg".

### Example 3: Get a plan
```powershell
Get-AzDevCenterAdminPlan -ResourceGroupName testRg -Name ContosoPlan
```
This command gets the plan named "ContosoPlan" under the resource group "testRg". 

### Example 4: Get a plan using InputObject
```powershell
$plan = @{"ResourceGroupName" = "testRg"; "PlanName" = "ContosoPlan"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
Get-AzDevCenterAdminPlan -InputObject $plan
```
This command gets the plan named "ContosoPlan" under the resource group "testRg".
