### Example 1: Creates or updates azure databricks accessConnector.
```powershell
New-AzDatabricksAccessConnector -ResourceGroupName azps_test_gp_db -Name azps-databricks-accessconnector -Location eastus -IdentityType 'SystemAssigned'
```

```output
Location Name                            ResourceGroupName
-------- ----                            -----------------
eastus   azps-databricks-accessconnector azps_test_gp_db
```

This command creates or updates azure databricks accessConnector.