### Example 1: Create or update data container
```powershell
New-AzMLWorkspaceDataContainer -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-test01 -Name datacontainer-pwsh01 -DataType 'uri_file'
```

```output
Name                 SystemDataCreatedAt SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----                 ------------------- -------------------                 ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
datacontainer-pwsh01 6/1/2022 3:03:56 PM UserName (Example)         User                    6/1/2022 3:03:56 PM                                                            ml-rg-test
```

Create or update data container

