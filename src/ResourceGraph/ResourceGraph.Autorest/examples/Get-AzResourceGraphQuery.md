### Example 1: Get all resource graph query under a resource group
```powershell
Get-AzResourceGraphQuery -ResourceGroupName azure-rg-test
```

```output
Location Name            Type
-------- ----            ----
global   SharedQuery-t01 microsoft.resourcegraph/queries
```

This command gets all resource graph query under a resource group.

### Example 2: Get a resource graph query by name
```powershell
Get-AzResourceGraphQuery -ResourceGroupName azure-rg-test -Name SharedQuery-t01
```

```output
Location Name            Type
-------- ----            ----
global   SharedQuery-t01 microsoft.resourcegraph/queries
```

This command gets a resource graph query by name.

### Example 3: Get a resource graph query by objecy
```powershell
$query = New-AzResourceGraphQuery -ResourceGroupName azure-rg-test -Name query-t03 -Location 'global' -Query 'project id, name, type, location' -Description 'test'
Get-AzResourceGraphQuery -InputObject $query
```

```output
Location Name            Type
-------- ----            ----
global   SharedQuery-t01 microsoft.resourcegraph/queries
```

This command gets a resource graph query by object.

