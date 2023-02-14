### Example 1: Create a Maps Creator resource
```powershell
<<<<<<< HEAD
New-AzMapsCreator -ResourceGroupName azure-rg-test -AccountName pwsh-mapsAccount02 -Name creator-01 -Location eastus2 -StorageUnit 3
```

```output
=======
PS C:\> New-AzMapsCreator -ResourceGroupName azure-rg-test -AccountName pwsh-mapsAccount02 -Name creator-01 -Location eastus2 -StorageUnit 3

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name       Type
-------- ----       ----
eastus2  creator-01 Microsoft.Maps/accounts/creators
```

This command creates a Maps Creator resource.
Creator resource will manage Azure resources required to populate a custom set of mapping data.
It requires an account to exist before it can be created.
