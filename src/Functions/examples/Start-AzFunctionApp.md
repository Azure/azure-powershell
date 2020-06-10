### Example 1: Get a function app by name and start it.
```powershell
PS C:\> Get-AzFunctionApp -Name MyAppName -ResourceGroupName MyResourceGroupName | Start-AzFunctionApp
```

This command gets a function app by name and starts it.

### Example 2: Start a function app by name.
```powershell
PS C:\> Start-AzFunctionApp -Name MyAppName -ResourceGroupName MyResourceGroupName
```

This command starts a function app by name.