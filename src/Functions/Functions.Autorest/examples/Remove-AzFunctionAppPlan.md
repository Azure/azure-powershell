### Example 1: Get a function app plan by name and delete it.

```powershell
Get-AzFunctionAppPlan -Name MyAppName -ResourceGroupName MyResourceGroupName | Remove-AzFunctionAppPlan -Force
```

This command gets a function app plan by name and deletes it.

### Example 2: Delete a function app plan by name.

```powershell
Remove-AzFunctionAppPlan -Name MyAppName -ResourceGroupName MyResourceGroupName -Force
```

This command deletes a function app plan by name.
