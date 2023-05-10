### Example 1: Remove a Databricks workspace
```powershell
Remove-AzDatabricksWorkspace -ResourceGroupName testgroup -Name databricks-test
```

This command removes a Databricks workspace from a resource group.

### Example 2: Remove a Databricks workspace by object
```powershell
$dbr = Get-AzDatabricksWorkspace -ResourceGroupName testgroup -Name databricks-test02
Remove-AzDatabricksWorkspace -InputObject $dbr
```

This command removes a Databricks workspace from a resource group.

