### Example 1: Deletes the azure databricks accessConnector.
```powershell
Remove-AzDatabricksAccessConnector -ResourceGroupName azps_test_gp_db -Name azps-databricks-accessconnector
```

This command deletes the azure databricks accessConnector.

### Example 2: Deletes the azure databricks accessConnector by pipeline.
```powershell
Get-AzDatabricksAccessConnector -ResourceGroupName azps_test_gp_db -Name azps-databricks-accessconnector | Remove-AzDatabricksAccessConnector
```

This command deletes the azure databricks accessConnector by pipeline.