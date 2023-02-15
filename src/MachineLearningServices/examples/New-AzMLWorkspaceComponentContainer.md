### Example 1: Create or update component container
```powershell
New-AzMLWorkspaceComponentContainer -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -Name component-pwsh01 -IsArchived
```

```output
Name             SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----             ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
component-pwsh01 6/1/2022 1:45:45 PM                                             6/1/2022 1:45:45 PM                                                            ml-rg-test
```

Create or update component container
