### Example 1: Creates or updates a new kusto database in a workspace
```powershell
New-AzSynapseKustoPoolDatabase -ResourceGroupName "testrg" -WorkspaceName "testws" -KustoPoolName "testkustopool" -DatabaseName "mykustodatabase" -Kind "ReadWrite" -Location "East US 2"
```

```output
Kind      Location  Name                                                                                   
----      --------  ----                              
ReadWrite East US 2 testws/testkustopool/mykustodatabase
```

Creates or updates a kusto database "mykustodatabase" in Kusto Pool "testkustopool" in the workspace "testws" found in the resource group "testrg".

