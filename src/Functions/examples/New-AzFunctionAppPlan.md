### Example 1: Create a Windows premium app plan in West Europe with burst out capability up to 10 instances.

```powershell
New-AzFunctionAppPlan -ResourceGroupName MyResourceGroupName `
                      -Name MyPremiumPlan `
                      -Location WestEurope `
                      -MinimumWorkerCount 1 `
                      -MaximumWorkerCount 10 `
                      -Sku EP1 `
                      -WorkerType Windows
```

This command creates a Windows premium app plan in West Europe with burst out capability up to 10 instances.