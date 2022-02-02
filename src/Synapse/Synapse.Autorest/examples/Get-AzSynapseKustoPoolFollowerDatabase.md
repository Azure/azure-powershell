### Example 1: List all followed databases
```powershell
PS C:\> Get-AzSynapseKustoPoolFollowerDatabase -ResourceGroupName testrg -WorkspaceName testws -KustoPoolName testkustopool

AttachedDatabaseConfigurationName DatabaseName KustoPoolResourceId
--------------------------------- ------------ -------------------
conf1                             testdatabase /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testrg/providers/Microsoft.Synapse/workspaces/testws/kustoPools/followerpool
```

The above command returns a list of databases that are owned by this Kusto Pool and were followed by another Kusto Pool.


