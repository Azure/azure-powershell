### Example 1: Get a function app by name and stop it.

```powershell
PS C:\> Get-AzFunctionApp -Name MyAppName -ResourceGroupName MyResourceGroupName | Stop-AzFunctionApp -Force
```

This command gets a function app by name and stops it.

### Example 2: Stop a function app by name.

```powershell
PS C:\> Stop-AzFunctionApp -Name MyAppName -ResourceGroupName MyResourceGroupName -Force
```

This command stops a function app by name.