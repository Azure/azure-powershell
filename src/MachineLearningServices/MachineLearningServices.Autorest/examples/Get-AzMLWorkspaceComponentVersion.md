### Example 1: Lists all component versions
```powershell
Get-AzMLWorkspaceComponentVersion -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -Name train_data_component
```

```output
Name SystemDataCreatedAt  SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy            SystemDataLastModifiedByType ResourceGroupName
---- -------------------  -------------------                 ----------------------- ------------------------ ------------------------            ---------------------------- -----------------
1    5/24/2022 7:23:25 AM Lucas Yao (Wicresoft North America) User                    5/24/2022 7:23:25 AM     Lucas Yao (Wicresoft North America) User                         ml-rg-test
```

Lists all component versions

### Example 2: Gets a component versions
```powershell
Get-AzMLWorkspaceComponentVersion -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -Name train_data_component -Version 1
```

```output
Name SystemDataCreatedAt  SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy            SystemDataLastModifiedByType ResourceGroupName
---- -------------------  -------------------                 ----------------------- ------------------------ ------------------------            ---------------------------- -----------------
1    5/24/2022 7:23:25 AM Lucas Yao (Wicresoft North America) User                    5/24/2022 7:23:25 AM     Lucas Yao (Wicresoft North America) User                         ml-rg-test
```

 Gets a component versions

