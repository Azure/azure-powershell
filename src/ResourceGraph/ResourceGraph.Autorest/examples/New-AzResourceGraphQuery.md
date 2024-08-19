### Example 1: Create a resource graph query by the query parameter
```powershell
New-AzResourceGraphQuery -Name query-t03 -ResourceGroupName azure-rg-test -Location "global" -Description "requesting a subset of resource fields." -Query "project id, name, type, location, tags" 
```

```output
Location Name      Type
-------- ----      ----
global   query-t03 microsoft.resourcegraph/queries
```

This command creates a resource graph query by the query parameter.

### Example 2: Create a resource graph query by the file parameter
```powershell
New-AzResourceGraphQuery -Name query-t04 -ResourceGroupName azure-rg-test -Location "global" -Description "requesting a subset of resource fields." -File 'D:\azure-service\ResourceGraph.Autorest\azure-powershell\src\ResourceGraph\ResourceGraph.Autorest\test\Query.kql'
```

```output
Location Name      Type
-------- ----      ----
global   query-t04 microsoft.resourcegraph/queries
```

This command creates a resource graph query by the file parameter.

