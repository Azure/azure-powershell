### Example 1: Delete an existing Kusto pool PrincipalAssignment by name
```powershell
PS C:\> Remove-AzSynapseKustoPoolPrincipalAssignment -ResourceGroupName testrg -WorkspaceName testws -KustoPoolName testkustopool -PrincipalAssignmentName kustoprincipal1
```

The above command deletes a Kusto pool principalAssignment "kustoprincipal1" in the workspace "testws".
