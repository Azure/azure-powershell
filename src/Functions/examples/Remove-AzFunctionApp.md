### Example 1: Get a function app by name and delete it.

```powershell
PS C:\> Get-AzFunctionApp -Name MyAppName -ResourceGroupName MyResourceGroupName | Remove-AzFunctionApp -Force
```

This command gets a function app by name and delete it.

### Example 2: Delete a function app by name.

```powershell
PS C:\> Remove-AzFunctionApp -Name MyAppName -ResourceGroupName MyResourceGroupName -Force
```

This command deletes a function app by name.
