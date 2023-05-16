### Example 1: Remove a Databricks workspace.
```powershell
Remove-AzDatabricksWorkspace -Name azps-databricks-workspace -ResourceGroupName azps_test_gp_db
```

This command removes a Databricks workspace from a resource group.

### Example 2: Remove a Databricks workspace by object.
```powershell
$object = Get-AzDatabricksWorkspace -ResourceGroupName azps_test_gp_db -Name azps-databricks-workspace-t3
Remove-AzDatabricksWorkspace -InputObject $object
```

This command removes a Databricks workspace from a resource group.