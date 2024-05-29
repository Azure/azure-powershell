### Example 1: Update the parameter query and tag by name
```powershell
Update-AzResourceGraphQuery -ResourceGroupName azure-rg-test -Name query-t05 -Query "project id, name, type, location, tags"  -Tag @{'key1'=1;'key2'=2}
```

```output
Location Name      Type
-------- ----      ----
global   query-t05 microsoft.resourcegraph/queries
```

This command updates the parameter query and tag by name.

### Example 2: Update the parameter file by object
```powershell
$query =  Get-AzResourceGraphQuery -ResourceGroupName azure-rg-test -Name query-t05 
Update-AzResourceGraphQuery -InputObject $query -File './Query.kql'
```

```output
Location Name      Type
-------- ----      ----
global   query-t05 microsoft.resourcegraph/queries
```

This command updates the parameter query and tag by object.
