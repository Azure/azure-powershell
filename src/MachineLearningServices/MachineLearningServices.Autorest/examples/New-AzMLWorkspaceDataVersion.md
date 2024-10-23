### Example 1: Create or update data version
```powershell
New-AzMLWorkspaceDataVersion  -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-portal01 -Name iris-data -Version 2 -DataType 'uri_file' -DataUri "https://azuremlexamples.blob.core.windows.net/datasets/iris.csv"
```

```output
Name SystemDataCreatedAt SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
---- ------------------- -------------------                 ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
2    6/1/2022 3:11:06 PM UserName (Example)         User                    6/1/2022 3:11:06 PM                                                            ml-rg-test
```

Create or update data version
