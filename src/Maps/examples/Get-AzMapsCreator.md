### Example 1: Get a Maps Creator resource
```powershell
PS C:\> Get-AzMapsCreator -ResourceGroupName azure-rg-test -AccountName pwsh-mapsAccount02 -Name creator-01

Location Name       Type
-------- ----       ----
eastus2  creator-01 Microsoft.Maps/accounts/creators
```

This command gets a Maps Creator resource.

### Example 2: Get a Maps Creator resource by pipeline
```powershell
PS C:\> New-AzMapsCreator -ResourceGroupName azure-rg-test -AccountName pwsh-mapsAccount02 -Name creator-01 -Location eastus2 -StorageUnit 3 | Get-AzMapsCreator

Location Name       Type
-------- ----       ----
eastus2  creator-01 Microsoft.Maps/accounts/creators
```

This command gets a Maps Creator resource by pipeline.

