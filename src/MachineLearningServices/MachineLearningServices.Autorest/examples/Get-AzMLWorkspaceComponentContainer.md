### Example 1: Lists all component containers under a workspace
```powershell
Get-AzMLWorkspaceComponentContainer -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01
```

```output
Name                 SystemDataCreatedAt  SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy            SystemDataLastModifiedByType ResourceGroupName
----                 -------------------  -------------------                 ----------------------- ------------------------ ------------------------            ---------------------------- -----------------
train_data_component 5/24/2022 7:23:25 AM UserName (Example)         User                    5/24/2022 7:23:25 AM     UserName (Example)         User                         ml-rg-test
```

Lists all containers under a workspace

### Example 2: Get a component container by name
```powershell
Get-AzMLWorkspaceComponentContainer -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -Name train_data_component
```

```output
Name                 SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----                 -------------------  ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
train_data_component 5/24/2022 7:23:25 AM                                             5/24/2022 7:23:25 AM                                                           ml-rg-test
```

Get a component container by name

