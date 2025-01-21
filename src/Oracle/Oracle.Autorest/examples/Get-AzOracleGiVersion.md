### Example 1: Get a list of the Grid Infrastructure Versions by location
```powershell
Get-AzOracleGiVersion -Location "eastus"
```

```output
Name     SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----     ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
19.0.0.0                                                                                                                                                
23.0.0.0                                                                                                                                                
```

Get a list of the Grid Infrastructure Versions by location.
For more information, execute `Get-Help Get-AzOracleGiVersion`.