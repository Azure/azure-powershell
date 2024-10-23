### Example 1: Update a plan
```powershell
Update-AzDevCenterAdminPlan -Name ContosoPlan -ResourceGroupName testRg -SkuName CCOG_Standard
```
This command updates a plan named "ContosoPlan" in the resource group "testRg". 

### Example 3: Update a plan using InputObject
```powershell
$plan = @{"ResourceGroupName" = "testRg"; "PlanName" = "ContosoPlan"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
Update-AzDevCenterAdminPlan -InputObject $plan -SkuName CCOG_Standard
```
This command updates a plan named "ContosoPlan" in the resource group "testRg". 
