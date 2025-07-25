### Example 1: List the properties of the specified machine learning workspace under a subscription
```powershell
Get-AzMLWorkspace
```

```output
Name                 SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Location ResourceGroupName
----                 -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -------- -----------------
mlworkspace-portal01 5/5/2022 1:27:26 AM  user@example.com    User                    5/5/2022 1:27:26 AM      user@example.com        User                         eastus   ml-rg-test
mlworkspace-cli01    5/18/2022 6:33:49 AM user@example.com    User                    5/18/2022 6:33:49 AM     user@example.com        User                         eastus   ml-rg-test
mlworkspace-demo     5/25/2022 3:06:22 AM user@example.com    User                    5/25/2022 3:06:22 AM     user@example.com        User                         eastus   ml-rg-test
```

List the properties of the specified machine learning workspace under a subscription.

### Example 2: List the properties of the specified machine learning workspace under a resource group
```powershell
Get-AzMLWorkspace -ResourceGroupName ml-rg-test
```

```output
Name                 SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Location ResourceGroupName
----                 -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -------- -----------------
mlworkspace-portal01 5/5/2022 1:27:26 AM  user@example.com     User                    5/5/2022 1:27:26 AM      user@example.com         User                         eastus   ml-rg-test
mlworkspace-cli01    5/18/2022 6:33:49 AM user@example.com     User                    5/18/2022 6:33:49 AM     user@example.com         User                         eastus   ml-rg-test
mlworkspace-demo     5/25/2022 3:06:22 AM user@example.com     User                    5/25/2022 3:06:22 AM     user@example.com         User                         eastus   ml-rg-test
```

List the properties of the specified machine learning workspace under a resource group.

### Example 3: Gets the properties of the specified machine learning workspace
```powershell
Get-AzMLWorkspace -ResourceGroupName ml-rg-test -Name mlworkspace-cli01
```

```output
Name              SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Location ResourceGroupName
----              -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -------- -----------------
mlworkspace-cli01 5/18/2022 6:33:49 AM user@example.com     User                    5/18/2022 6:33:49 AM     user@example.com         User                         eastus   ml-rg-test
```

Gets the properties of the specified machine learning workspace.

