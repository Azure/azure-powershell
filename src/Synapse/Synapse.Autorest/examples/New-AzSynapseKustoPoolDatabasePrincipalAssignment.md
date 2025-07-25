### Example 1: Create a Kusto pool database principalAssignment
```powershell
New-AzSynapseKustoPoolDatabasePrincipalAssignment -ResourceGroupName testrg -WorkspaceName testws -KustoPoolName testkustopool -DatabaseName testdatabase -PrincipalAssignmentName kustoprincipal -PrincipalId 00000000-0000-0000-0000-000000000000 -PrincipalType App -Role Viewer
```

```output
Name                                             Type
----                                             ----
testws/testkustopool/testdatabase/kustoprincipal Microsoft.Synapse/workspaces/kustoPools/Databases/PrincipalAssignments
```

The above command creates a Kusto pool database principalAssignment
