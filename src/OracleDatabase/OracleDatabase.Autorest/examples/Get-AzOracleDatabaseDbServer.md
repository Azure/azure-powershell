### Example 1: Gets a list of the Database Servers for a Cloud Exadata Infrastructure resource
```powershell
Get-AzOracleDatabaseDbServer -Cloudexadatainfrastructurename "OFake_PowerShellTestExaInfra" -ResourceGroupName "PowerShellTestRg"
```

```output
Name       SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----       ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
dbServer-2                                                                                                                                                PowerShellTestRg
dbServer-3                                                                                                                                                PowerShellTestRg
dbServer-1                                                                                                                                                PowerShellTestRg
```

Gets a list of the Database Servers for a Cloud Exadata Infrastructure resource