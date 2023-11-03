### Example 1: Lists all data containers under a workspace
```powershell
Get-AzMLWorkspaceDataContainer  -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-portal01
```

```output
Name       SystemDataCreatedAt  SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----       -------------------  -------------------                 ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
iris-data  5/5/2022 2:58:50 AM  Lucas Yao (Wicresoft North America) User                    5/5/2022 2:58:50 AM                                                            ml-rg-test
pwshdata01 5/17/2022 7:11:05 AM Lucas Yao (Wicresoft North America) User                    5/17/2022 7:11:05 AM                                                           ml-rg-test
dtpwsh01   5/24/2022 6:12:06 AM Lucas Yao (Wicresoft North America) User                    5/24/2022 6:12:06 AM                                                           ml-rg-test
dtpwsh02   5/24/2022 6:21:34 AM Lucas Yao (Wicresoft North America) User                    5/24/2022 6:21:35 AM                                                           ml-rg-test
```

Lists all data containers under a workspace

### Example 2: Get a data container by name
```powershell
Get-AzMLWorkspaceDataContainer  -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-portal01 -Name iris-data
```

```output
Name      SystemDataCreatedAt SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----      ------------------- -------------------                 ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
iris-data 5/5/2022 2:58:50 AM Lucas Yao (Wicresoft North America) User                    5/5/2022 2:58:50 AM                                                            ml-rg-test
```

Get a data container by name

