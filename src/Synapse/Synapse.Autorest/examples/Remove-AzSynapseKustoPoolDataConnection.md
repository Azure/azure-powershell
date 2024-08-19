### Example 1: Delete an existing data connection by name
```powershell
Remove-AzSynapseKustoPoolDataConnection -ResourceGroupName "testrg" -WorkspaceName "testws" -KustoPoolName "testkustopool" -DatabaseName "mykustodatabase" -DataConnectionName "mykustodataconnection"
```

The above command deletes the data connection named "mykustodataconnection" in kusto database "mykustodatabase" of the existing workspace "testws" found in the resource group "testrg"
