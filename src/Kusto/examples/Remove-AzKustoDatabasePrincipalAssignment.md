### Example 1: Delete an existing Kusto database PrincipalAssignment by name
```powershell
PS C:\> Remove-AzKustoDatabasePrincipalAssignment -ResourceGroupName testrg -ClusterName testnewkustocluster -DatabaseName mykustodatabase -PrincipalAssignmentName kustoprincipal1
```

The above command deletes the PrincipalAssignment named "kustoprincipal1" in the Kusto database  "mykustodatabase".
