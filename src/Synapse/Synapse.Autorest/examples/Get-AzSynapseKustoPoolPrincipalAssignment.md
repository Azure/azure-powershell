### Example 1: List all Kusto principalAssignments
```powershell
PS C:\> Get-AzSynapseKustoPoolPrincipalAssignment -ResourceGroupName testrg -WorkspaceName testws -KustoPoolName testkustopool

Name                                 Type
----                                 ----
testws/testkustopool/kustoprincipal1 Microsoft.Synapse/workspaces/kustoPools/PrincipalAssignments
```

The above command lists all principalAssignments in the workspace "testws".

### Example 2: Gets a Kusto principalAssignment by name
```powershell
PS C:\> Get-AzSynapseKustoPoolPrincipalAssignment -ResourceGroupName testrg -WorkspaceName testws -KustoPoolName testkustopool -PrincipalAssignmentName kustoprincipal1

Name                                 Type
----                                 ----
testws/testkustopool/kustoprincipal1 Microsoft.Synapse/workspaces/kustoPools/PrincipalAssignments
```

The above command returns the Kusto principalAssignment named "kustoprincipal1" in the workspace "testws".

