### Example 1: Delete an existing Kusto database PrincipalAssignment by name
```powershell
PS C:\> Remove-AzSynapseKustoPoolDatabasePrincipalAssignment -ResourceGroupName testrg -WorkspaceName testws -DatabaseName mykustodatabase -PrincipalAssignmentName kustoprincipal1
```

The above command deletes the PrincipalAssignment named "kustoprincipal1" in the Kusto database "mykustodatabase" in workspace "testws" found in resource group "testrg".


