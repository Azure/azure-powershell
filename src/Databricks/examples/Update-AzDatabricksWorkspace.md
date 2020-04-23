### Example 1: Update a Databricks workspace
```powershell
PS C:\> Update-AzDatabricksWorkspace -ResourceGroupName testgroup -Name databricks-test -Tag @{ dbr="home-resource" }

Location Name            Type
-------- ----            ----
eastus   databricks-test Microsoft.Databricks/workspaces
```

This command updates a Databricks workspace.

