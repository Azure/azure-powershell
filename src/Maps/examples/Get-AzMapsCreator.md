### Example 1: List all Maps Creator resources under a Maps Account
```powershell
<<<<<<< HEAD
Get-AzMapsCreator -ResourceGroupName azure-rg-test -AccountName pwsh-mapsAccount02 -Name creator-01
```

```output
=======
PS C:\> Get-AzMapsCreator -ResourceGroupName azure-rg-test -AccountName pwsh-mapsAccount02 -Name creator-01

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name       Type
-------- ----       ----
eastus2  creator-01 Microsoft.Maps/accounts/creators
```

This command lists Maps Creator resources under a Maps Account.

### Example 2: Get a Maps Creator resource
```powershell
<<<<<<< HEAD
Get-AzMapsCreator -ResourceGroupName azure-rg-test -AccountName pwsh-mapsAccount02 -Name creator-01
```

```output
=======
PS C:\> Get-AzMapsCreator -ResourceGroupName azure-rg-test -AccountName pwsh-mapsAccount02 -Name creator-01

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name       Type
-------- ----       ----
eastus2  creator-01 Microsoft.Maps/accounts/creators
```

This command gets a Maps Creator resource.

### Example 3: Get a Maps Creator resource by pipeline
```powershell
<<<<<<< HEAD
New-AzMapsCreator -ResourceGroupName azure-rg-test -AccountName pwsh-mapsAccount02 -Name creator-01 -Location eastus2 -StorageUnit 3 | Get-AzMapsCreator
```

```output
=======
PS C:\> New-AzMapsCreator -ResourceGroupName azure-rg-test -AccountName pwsh-mapsAccount02 -Name creator-01 -Location eastus2 -StorageUnit 3 | Get-AzMapsCreator

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name       Type
-------- ----       ----
eastus2  creator-01 Microsoft.Maps/accounts/creators
```

This command gets a Maps Creator resource by pipeline.

