### Example 1: Deletes the azure databricks accessConnector
```powershell
Remove-AzDatabricksAccessConnector -ResourceGroupName databricks-rg-xyv4k5 -Name databricks-ac
```

```output
```

This command deletes the azure databricks accessConnector.

### Example 2: Deletes the azure databricks accessConnector by pipeline
```powershell
Get-AzDatabricksAccessConnector -ResourceGroupName databricks-rg-xyv4k5 -Name databricks-ac | Remove-AzDatabricksAccessConnector
```

```output
```

This command deletes the azure databricks accessConnector by pipeline

