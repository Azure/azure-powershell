### Example 1: Updates an azure databricks accessConnector
```powershell
Update-AzDatabricksAccessConnector -ResourceGroupName databricks-rg-xyv4k5 -Name databricks-ac -Tag @{'key'='value'}
```

```output
Location Name          ResourceGroupName
-------- ----          -----------------
eastus   databricks-ac databricks-rg-xyv4k5
```

This command updates an azure databricks accessConnector.

### Example 2: Updates an azure databricks accessConnector by pipeline
```powershell
Get-AzDatabricksAccessConnector -ResourceGroupName databricks-rg-xyv4k5 -Name databricks-ac | Update-AzDatabricksAccessConnector  -Tag @{'key'='value'}
```

```output
Location Name          ResourceGroupName
-------- ----          -----------------
eastus   databricks-ac databricks-rg-xyv4k5
```

This command updates an azure databricks accessConnector by pipeline.

