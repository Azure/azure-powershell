### Example 1: List all the AttachedDatabaseConfigurations in a kusto pool
```powershell
PS C:\> Get-AzSynapseKustoPoolAttachedDatabaseConfiguration -ResourceGroupName testrg -WorkspaceName testws -KustoPoolName testfollowerkustopool

Name                                               Type                                                                   Location
----                                               ----                                                                   --------
testws/testfollowerkustopool/followerconfiguration Microsoft.Synapse/workspaces/kustoPools/AttachedDatabaseConfigurations East US 2
```

The above command lists all the AttachedDatabaseConfigurations in the kusto pool "testfollowerkustopool".

### Example 2: Get a specific AttachedDatabaseConfiguration in a kusto pool
```powershell
PS C:\> Get-AzSynapseKustoPoolAttachedDatabaseConfiguration -ResourceGroupName testrg -WorkspaceName testws -KustoPoolName testfollowerkustopool -Name followerconfiguration

Name                                               Type                                                                   Location
----                                               ----                                                                   --------
testws/testfollowerkustopool/followerconfiguration Microsoft.Synapse/workspaces/kustoPools/AttachedDatabaseConfigurations East US 2
```

The above command returns the AttachedDatabaseConfigurations named "followerconfiguration" in the cluster "testfollowerkustopool".
