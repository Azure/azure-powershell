### Example 1: Get a list of the Autonomous Database Versions by location
```powershell
Get-AzOracleAutonomousDatabaseVersion -Location "eastus"
```

```output
Name SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
---- ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
19c                                                                                                                                                 
19c                                                                                                                                                 
19c                                                                                                                                                                          
```

Get a list of the Autonomous Database Versions by location.
For more information, execute `Get-Help Get-AzOracleAutonomousDatabaseVersion`.