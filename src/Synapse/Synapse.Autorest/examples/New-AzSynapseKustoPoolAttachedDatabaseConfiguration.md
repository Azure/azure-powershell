### Example 1: Create a new AttachedDatabaseConfiguration
```powershell
PS C:\> New-AzSynapseKustoPoolAttachedDatabaseConfiguration -ResourceGroupName "testrg" -WorkspaceName "testws" -KustoPoolName "testkustopool" -AttachedDatabaseConfigurationName "myfollowerconfiguration" -Location "East US" -KustoPoolResourceId "/subscriptions/$subscriptionId/resourcegroups/testrg/providers/Microsoft.Synapse/workspace/testws" -DatabaseName "mykustodatabase" -DefaultPrincipalsModificationKind "Union"

Name                                          Location
----                                -         -------
testws/testkustopool/myfollowerconfiguration  East US
```

The above command creates a ReadOnly database "mykustodatabase" in workspace "testws". It follows the database "mykustodatabase" from workspace "testws"
