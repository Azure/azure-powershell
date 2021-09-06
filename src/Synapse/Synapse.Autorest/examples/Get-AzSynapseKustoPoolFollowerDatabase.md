### Example 1: List all followed databases
```powershell
PS C:\> AzSynapseKustoPoolFollowerDatabase -ResourceGroupName testrg -WorkspaceName testws -KustoPoolName testkustopool

AttachedDatabaseConfigurationName DatabaseName KustoPoolResourceId
--------------------------------- ------------ -------------------
conf1                             testdatabase /subscriptions/051ddeca-1ed6-4d8b-ba6f-1ff561e5f3b3/resourceGroups/testrg/providers/Microsoft.Synapse/workspaces/testsw/kustoPools/followerpool
```

The above command returns a list of databases that are owned by this Kusto Pool and were followed by another Kusto Pool.


