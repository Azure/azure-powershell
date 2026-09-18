### Example 1: Replace a usage plan
```powershell
Set-AzResilienceUsagePlan `
  -Name 'up-payments' `
  -ResourceGroupName 'rg-resiliency-prod' `
  -Location 'eastus'
```

Replaces the specified usage plan. Properties that are not supplied are reset.
