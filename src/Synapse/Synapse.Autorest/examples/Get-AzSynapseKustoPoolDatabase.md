### Example 1: List all Kusto databases in a workspace by name
```powershell
Get-AzSynapseKustoPoolDatabase -ResourceGroupName testrg -WorkspaceName testws -KustoPoolName testkustopool
```

```output
Kind      Location  Name                                                                                                                                                                                                
----      --------  ----                                  
ReadWrite East US 2 testws/testnewkustopool/mykustodatabase
```

The above command returns all Kusto databases in Kusto Pool "testkustopool" in the workspace "testws" found in the resource group "testrg".

### Example 2: Get a specific Kusto database by name
```powershell
Get-AzSynapseKustoPoolDatabase -ResourceGroupName testrg -WorkspaceName testws -KustoPoolName testkustopool -DatabaseName mykustodatabase
```

```output
Kind      Location  Name                                                                                            
----      --------  ----                                  
ReadWrite East US 2 testws/testnewkustopool/mykustodatabase
```

The above command returns the Kusto database named "mykustodatabase" in Kusto Pool "testkustopool" in the WorkspaceName "testws" found in the resource group "testrg".

