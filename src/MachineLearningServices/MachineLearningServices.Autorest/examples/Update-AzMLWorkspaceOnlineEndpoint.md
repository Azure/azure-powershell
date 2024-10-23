### Example 1: Update Online Endpoint (asynchronous)
```powershell
Update-AzMLWorkspaceOnlineEndpoint -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -Name online-pwsh02 -Tag @{'key'='value'}
```

```output
Location Name         SystemDataCreatedAt  SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Kind    ResourceGroupName
-------- ----         -------------------  -------------------                 ----------------------- ------------------------ ------------------------ ---------------------------- ----    -----------------
eastus   online-cli01 5/19/2022 2:47:34 AM UserName (Example)                  5/19/2022 2:48:26 AM                                                                                   Managed ml-rg-test
```

Update Online Endpoint (asynchronous)

### Example 2: Update Online Endpoint (asynchronous) by pipeline
```powershell
Get-AzMLWorkspaceOnlineEndpoint -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -Name online-pwsh02 | Update-AzMLWorkspaceOnlineEndpoint -Tag @{'key'='value'}
```

```output
Location Name         SystemDataCreatedAt  SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Kind    ResourceGroupName
-------- ----         -------------------  -------------------                 ----------------------- ------------------------ ------------------------ ---------------------------- ----    -----------------
eastus   online-cli01 5/19/2022 2:47:34 AM UserName (Example)                  5/19/2022 2:48:26 AM                                                                                   Managed ml-rg-test
```

Update Online Endpoint (asynchronous) by pipeline

