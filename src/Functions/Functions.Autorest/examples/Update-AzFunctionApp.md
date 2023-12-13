### Example 1: Update function app hosting plan.
```powershell
Update-AzFunctionApp -Name MyUniqueFunctionAppName -ResourceGroupName MyResourceGroupName -PlanName NewPlanName -Force
```
This command updates function app hosting plan.
### Example 2: Set a SystemAssigned managed identity for a function app.
```powershell
Update-AzFunctionApp -Name MyUniqueFunctionAppName -ResourceGroupName MyResourceGroupName -IdentityType SystemAssigned -Force
```
This command sets a SystemAssigned managed identity for a function app.
### Example 3: Update function app Application Insights.
```powershell
Update-AzFunctionApp -Name MyUniqueFunctionAppName -ResourceGroupName MyResourceGroupName -ApplicationInsightsName ApplicationInsightsProjectName -Force
```
This command updates function app Application Insights.
### Example 3: Remove managed identity from a function app.
```powershell
Update-AzFunctionApp -Name MyUniqueFunctionAppName -ResourceGroupName MyResourceGroupName -IdentityType None -Force
```
This command removes a managed identity from a function app.