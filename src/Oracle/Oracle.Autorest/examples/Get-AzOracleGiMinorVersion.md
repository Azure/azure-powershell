### Example 1: Get a list of the Grid Infrastructure Versions by location
```powershell
Get-AzOracleGiVersion -Location "eastus"  -Shape "EXADATA"
```

```output
Name     SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----     ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------

25.1.1.0.0.250121                                                                                                                                              
```

Get a list of the Grid Infrastructure Versions by location.
For more information, execute `Get-Help Get-AzOracleGiVersion`.
