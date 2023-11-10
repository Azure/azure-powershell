### Example 1: Updates an azure databricks accessConnector.
```powershell
Update-AzDatabricksAccessConnector -ResourceGroupName azps_test_gp_db -Name azps-databricks-accessconnector -Tag @{'key'='value'}
```

```output
Location Name                            ResourceGroupName
-------- ----                            -----------------
eastus   azps-databricks-accessconnector azps_test_gp_db
```

This command updates an azure databricks accessConnector.

### Example 2: Updates an azure databricks accessConnector by pipeline.
```powershell
Get-AzDatabricksAccessConnector -ResourceGroupName azps_test_gp_db -Name azps-databricks-accessconnector | Update-AzDatabricksAccessConnector  -Tag @{'key'='value'}
```

```output
Location Name                            ResourceGroupName
-------- ----                            -----------------
eastus   azps-databricks-accessconnector azps_test_gp_db
```

This command updates an azure databricks accessConnector by pipeline.