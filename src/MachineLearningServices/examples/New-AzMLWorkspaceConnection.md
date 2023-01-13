### Example 1: Creates a workspace connection
```powershell
New-AzMLWorkspaceConnection -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-test01 -Name test01 -AuthType 'None' -Category 'ContainerRegistry' -Target "www.facebook.com"
```

```output
Name   SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----   ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
test01                                                                                                                                                ml-rg-test
```

Creates a workspace connection

