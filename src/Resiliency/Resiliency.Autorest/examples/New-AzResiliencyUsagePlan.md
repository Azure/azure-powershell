### Example 1: Create a usage plan
```powershell
New-AzResiliencyUsagePlan -ResourceGroupName contoso-rg -Name contoso-usage-plan -Location eastus2 -PlanType Standard
```

Creates a Standard resiliency usage plan in East US 2.

### Example 2: Create a usage plan with tags
```powershell
New-AzResiliencyUsagePlan -ResourceGroupName contoso-rg -Name contoso-usage-plan -Location eastus2 -PlanType Standard -Tag @{ env = "prod" }
```

Creates a usage plan and tags it.
