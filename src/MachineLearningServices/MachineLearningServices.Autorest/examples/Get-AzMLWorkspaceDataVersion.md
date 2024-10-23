### Example 1: Lists all data versions
```powershell
Get-AzMLWorkspaceDataVersion  -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-portal01 -Name iris-data
```

```output
Name SystemDataCreatedAt SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
---- ------------------- -------------------                 ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
1    5/5/2022 2:58:50 AM UserName (Example)         User                    5/5/2022 2:58:50 AM                                                            ml-rg-test
```

Lists all data versions

### Example 2: Get a data version
```powershell
Get-AzMLWorkspaceDataVersion  -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-portal01 -Name iris-data -Version 1
```

```output
Name SystemDataCreatedAt SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
---- ------------------- -------------------                 ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
1    5/5/2022 2:58:50 AM UserName (Example)         User                    5/5/2022 2:58:50 AM                                                            ml-rg-test
```

Get a data version

