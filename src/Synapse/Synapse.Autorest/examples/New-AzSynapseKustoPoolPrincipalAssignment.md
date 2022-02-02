### Example 1: Create a Kusto pool principalAssignment
```powershell
PS C:\> New-AzKustoPoolPrincipalAssignment -ResourceGroupName testrg -WorkspaceName testws -KustoPoolName testnewkustopool -PrincipalAssignmentName kustoprincipal -PrincipalId "00000000-0000-0000-0000-000000000000" -PrincipalType App -Role AllDatabasesAdmin

Name                                   Type
----                                   ----
testws/testnewkustopool/kustoprincipal Microsoft.Synapse/workspaces/kustoPools/PrincipalAssignments
```

The above command creates a Kusto pool principalAssignment
