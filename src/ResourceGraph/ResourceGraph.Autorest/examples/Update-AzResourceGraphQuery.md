### Example 1: Update the parameter query and tag by name
```powershell
PS C:\>  Update-AzResourceGraphQuery -ResourceGroupName lucas-rg-test -Name query-t05 -Query "project id, name, type, location, tags"  -Tag @{'key1'=1;'key2'=2}

ETag Location Name      Type
---- -------- ----      ----
     global   query-t05 microsoft.resourcegraph/queries
```

This command updates the parameter query and tag by name.

### Example 2: Update the parameter file by object
```powershell
PS C:\> $query =  Get-AzResourceGraphQuery -ResourceGroupName lucas-rg-test -Name query-t05 
PS C:\> Update-AzResourceGraphQuery -InputObject $query -File './Query.kql'

ETag Location Name      Type
---- -------- ----      ----
     global   query-t05 microsoft.resourcegraph/queries
```

This command updates the parameter query and tag by object.
