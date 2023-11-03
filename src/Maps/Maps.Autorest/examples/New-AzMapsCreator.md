### Example 1: Create a Maps Creator resource
```powershell
New-AzMapsCreator -ResourceGroupName azure-rg-test -AccountName pwsh-mapsAccount02 -Name creator-01 -Location eastus2 -StorageUnit 3
```

```output
Location Name       Type
-------- ----       ----
eastus2  creator-01 Microsoft.Maps/accounts/creators
```

This command creates a Maps Creator resource.
Creator resource will manage Azure resources required to populate a custom set of mapping data.
It requires an account to exist before it can be created.
