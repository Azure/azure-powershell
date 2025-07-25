### Example 1: Create a plan
```powershell
New-AzDevCenterAdminPlan -Name ContosoPlan -ResourceGroupName testRg -Location eastus -SkuName CCOG_Standard
```
This command creates a plan named "ContosoPlan" in the resource group "testRg". 

### Example 3: Create a plan using InputObject
```powershell
$plan = @{"ResourceGroupName" = "testRg"; "PlanName" = "ContosoPlan"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
New-AzDevCenterAdminPlan -InputObject $plan -Location eastus -SkuName CCOG_Standard
```
This command creates a plan named "ContosoPlan" in the resource group "testRg". 
