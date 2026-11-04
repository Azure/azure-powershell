### Example 1: Replace a usage plan
```powershell
Set-AzResiliencyUsagePlan -ResourceGroupName contoso-rg -Name contoso-usage-plan -Location eastus2 -PlanType Standard -Tag @{ env = "prod" }
```

Replaces the usage plan with the supplied definition (PUT).
