### Example 1: Get a function app by name and restart it.

```powershell
Get-AzFunctionApp -Name MyAppName -ResourceGroupName MyResourceGroupName | Restart-AzFunctionApp -Force
```

This command gets a function app by name and restarts it.

### Example 2: Restart a function app by name.

```powershell
Restart-AzFunctionApp -Name MyAppName -ResourceGroupName MyResourceGroupName -Force
```

This command restarts a function app by name.