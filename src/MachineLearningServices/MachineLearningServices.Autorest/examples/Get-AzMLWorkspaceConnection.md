### Example 1: Lists all connection under a workspace
```powershell
Get-AzMLWorkspaceConnection -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-portal01
```

```output
Name SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
---- ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
test                                                                                                                                                ml-rg-test
```

Lists all connection under a workspace

### Example 2: Gets a connection by name
```powershell
Get-AzMLWorkspaceConnection -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-portal01 -Name test
```

```output
Name SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
---- ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
test                                                                                                                                                ml-rg-test
```

Gets a connection by name

