### Example 1: Updates the Maps Creator resource
```powershell
PS C:\> Update-AzMapsCreator -ResourceGroupName azure-rg-test -AccountName pwsh-mapsAccount03 -Name creator-01 -Tag @{'key1'='value1'; 'key2'='value2'}

Location Name       Type
-------- ----       ----
eastus2  creator-01 Microsoft.Maps/accounts/creators
```

This command updates the Maps Creator resource.
Only a subset of the parameters may be updated after creation, such as Tags.

### Example 2: Updates the Maps Creator resource by pipeline
```powershell
PS C:\> Get-AzMapsCreator -ResourceGroupName azure-rg-test -AccountName pwsh-mapsAccount03 -Name creator-01 | Update-AzMapsCreator -Tag @{'key1'='value1'; 'key2'='value2'}

Location Name       Type
-------- ----       ----
eastus2  creator-01 Microsoft.Maps/accounts/creators
```

This command updates the Maps Creator resource by pipeline.
Only a subset of the parameters may be updated after creation, such as Tags.

