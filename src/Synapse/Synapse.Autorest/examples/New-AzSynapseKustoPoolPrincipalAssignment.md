### Example 1: Create a Kusto pool principalAssignment
```powershell
New-AzSynapseKustoPoolPrincipalAssignment -ResourceGroupName testrg -WorkspaceName testws -KustoPoolName testnewkustopool -PrincipalAssignmentName kustoprincipal -PrincipalId "00000000-0000-0000-0000-000000000000" -PrincipalType App -Role AllDatabasesAdmin
```

```output
Name                                   Type
----                                   ----
testws/testnewkustopool/kustoprincipal Microsoft.Synapse/workspaces/kustoPools/PrincipalAssignments
```

The above command creates a Kusto pool principalAssignment
