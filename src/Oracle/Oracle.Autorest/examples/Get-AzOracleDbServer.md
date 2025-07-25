### Example 1: Get a list of the Database Servers for a Cloud Exadata Infrastructure resource
```powershell
Get-AzOracleDbServer -Cloudexadatainfrastructurename "OFake_PowerShellTestExaInfra" -ResourceGroupName "PowerShellTestRg"
```

```output
Name       SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----       ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
dbServer-2                                                                                                                                                PowerShellTestRg
dbServer-3                                                                                                                                                PowerShellTestRg
dbServer-1                                                                                                                                                PowerShellTestRg
```

Get a list of the Database Servers for a Cloud Exadata Infrastructure resource.
For more information, execute `Get-Help Get-AzOracleDbServer`.