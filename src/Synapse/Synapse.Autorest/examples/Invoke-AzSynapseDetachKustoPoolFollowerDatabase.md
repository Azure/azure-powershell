### Example 1: Detach a follower database
```powershell
PS C:\> Invoke-AzSynapseDetachKustoPoolFollowerDatabase -ResourceGroupName testrg -WorkspaceName testws -KustoPoolName testkustopool -AttachedDatabaseConfigurationName "myfollowerconfiguration" -KustoPoolResourceId "/subscriptions/$subscriptionId/resourcegroups/testrg/providers/Microsoft.Synapse/workspaces/testws/kustoPools/testfollowerkustopool"

```

The above command detaches the follower database defined in AttachedDatabaseConfiguration "myfollowerconfiguration" from Kusto Pool "testfollowerkustopool".

