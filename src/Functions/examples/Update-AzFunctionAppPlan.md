### Example 1: Update an app service plan to EP2 sku with twenty maximum workers.

```powershell
PS C:\> Update-AzFunctionAppPlan -ResourceGroupName MyResourceGroupName `
                                 -Name MyPremiumPlan `
                                 -MaximumWorkerCount 20 `
                                 -Sku EP2

```

This command updates an app service plan to EP2 sku with twenty maximum workers.