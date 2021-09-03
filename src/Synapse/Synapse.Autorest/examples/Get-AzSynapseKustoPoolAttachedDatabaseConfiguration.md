### Example 1: List all the AttachedDatabaseConfigurations in a workspace
```powershell
PS C:\> Get-AzSynapseKustoPoolAttachedDatabaseConfiguration -ResourceGroupName testrg -WorkspaceName testws -KustoPoolName testkustopool

Name                            Location
----                            --------
testws/myfollowerconfiguration  East US
```

The above command lists all AttachedDatabaseConfigurations in Kusto Pool "testkustopool" in the workspace "testws".

### Example 2: Get a specific AttachedDatabaseConfiguration in a workspace
```powershell
PS C:\>  Get-AzSynapseKustoPoolAttachedDatabaseConfiguration -ResourceGroupName testrg -WorkspaceName testws -KustoPoolName testkustopool -AttachedDatabaseConfigurationName myfollowerconfiguration 

Name                            Location
----                            --------
testws/myfollowerconfiguration  East US
```

The above command returns the AttachedDatabaseConfigurations named "myfollowerconfiguration" in Kusto Pool "testkustopool" in the workspace "testws".

