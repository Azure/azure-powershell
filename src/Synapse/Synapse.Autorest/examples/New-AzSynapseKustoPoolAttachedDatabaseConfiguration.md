### Example 1: Create a new AttachedDatabaseConfiguration
```powershell
New-AzSynapseKustoPoolAttachedDatabaseConfiguration -ResourceGroupName testrg -WorkspaceName testws -KustoPoolName testfollowerkustopool -Name followerconfiguration -KustoPoolResourceId /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testrg/providers/Microsoft.Synapse/workspaces/testws/kustoPools/testkustopool -DatabaseName testdatabase -DefaultPrincipalsModificationKind Union -Location eastus2
```

```output
Name                                               Type                                                                   Location
----                                               ----                                                                   --------
testws/testfollowerkustopool/followerconfiguration Microsoft.Synapse/workspaces/kustoPools/AttachedDatabaseConfigurations East US 2
```

The above command creates a ReadOnly database "testdatabase" in cluster "testfollowerkustopool". It follows the database "testdatabase" from cluster "testkustopool"
