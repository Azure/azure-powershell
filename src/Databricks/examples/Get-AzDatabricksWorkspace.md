### Example 1: Get a Databricks workspace with name
```powershell
Get-AzDatabricksWorkspace -Name databricks-test -ResourceGroupName testgroup
```

```output
Location Name            Type
-------- ----            ----
eastus   databricks-test Microsoft.Databricks/workspaces
```

This command gets a Databricks workspace in a resource group.

### Example 2: List all Databricks workspaces in a subscription
```powershell
Get-AzDatabricksWorkspace
```

```output
Location Name                           Type
-------- ----                           ----
eastus   databricks-test                Microsoft.Databricks/workspaces
eastus   databricks-test-with-custom-vn Microsoft.Databricks/workspaces
```

This command lists all Databricks workspaces in a subscription.

### Example 3: List all Databricks workspaces in a resource group
```powershell
Get-AzDatabricksWorkspace -ResourceGroupName testgroup
```

```output
Location Name                           Type
-------- ----                           ----
eastus   databricks-test                Microsoft.Databricks/workspaces
eastus   databricks-test-with-custom-vn Microsoft.Databricks/workspaces
```

This command lists all Databricks workspaces in a resource group.