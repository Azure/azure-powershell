### Example 1: List all Kusto principalAssignments
```powershell
Get-AzSynapseKustoPoolPrincipalAssignment -ResourceGroupName testrg -WorkspaceName testws -KustoPoolName testkustopool
```

```output
Name                                 Type
----                                 ----
testws/testkustopool/kustoprincipal1 Microsoft.Synapse/workspaces/kustoPools/PrincipalAssignments
```

The above command lists all principalAssignments in the workspace "testws".

### Example 2: Gets a Kusto principalAssignment by name
```powershell
Get-AzSynapseKustoPoolPrincipalAssignment -ResourceGroupName testrg -WorkspaceName testws -KustoPoolName testkustopool -PrincipalAssignmentName kustoprincipal1
```

```output
Name                                 Type
----                                 ----
testws/testkustopool/kustoprincipal1 Microsoft.Synapse/workspaces/kustoPools/PrincipalAssignments
```

The above command returns the Kusto principalAssignment named "kustoprincipal1" in the workspace "testws".

