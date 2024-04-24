### Example 1:  List all data connections in a specific database
```powershell
Get-AzSynapseKustoPoolDataConnection -ResourceGroupName testrg -WorkspaceName testws -KustoPoolName testkustopool -DatabaseName mykustodatabase
```

```output
Kind     Location  Name                                                                                                              
----     --------  ----                                             
EventHub East US 2 testws/testkustopool/mykustodatabase/eventhubdc
```

The above command returns all Kusto connections in the workspace "testws" found in the resource group "testrg".

### Example 2: Get a specific data connection by name
```powershell
Get-AzSynapseKustoPoolDataConnection -ResourceGroupName testrg -WorkspaceName testws -KustoPoolName testkustopool -DatabaseName mykustodatabase -DataConnectionName mykustodataconnection
```

```output
Kind     Location  Name                                                                                                             
----     --------  ----                                             
EventHub East US 2 testws/testkustopool/mykustodatabase/mykustodataconnection
```

The above command returns the data connection named "mykustodataconnection" in database "mykustodatabase" in workspace "testws" found in the resource group "testrg".

