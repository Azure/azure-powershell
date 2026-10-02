### Example 1: Create a usage plan
```powershell
New-AzResilienceUsagePlan `
  -Name 'up-payments' `
  -ResourceGroupName 'rg-resiliency-prod' `
  -Location 'eastus'
```

Creates a new usage plan in the specified resource group.
