### Example 1: Remove a Databricks workspace
```powershell
PS C:\> Remove-AzDatabricksWorkspace -ResourceGroupName testgroup -Name databricks-test
```

This command removes a Databricks workspace from a resource group.

### Example 2: Remove a Databricks workspace by object
```powershell
PS C:\> $dbr = Get-AzDatabricksWorkspace -ResourceGroupName testgroup -Name databricks-test02
PS C:\> Remove-AzDatabricksWorkspace -InputObject $dbr
```

This command removes a Databricks workspace from a resource group.

