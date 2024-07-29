### Example 1: Update Online Deployment (asynchronous)
```powershell
Update-AzMLWorkspaceOnlineDeployment -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -EndpointName online-pwsh01 -Name pwshblue01 -Tag @{'key'='value'}
```

```output
Location Name SystemDataCreatedAt  SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Kind    ResourceGroupName
-------- ---- -------------------  -------------------                 ----------------------- ------------------------ ------------------------ ---------------------------- ----    -----------------
eastus   blue 5/19/2022 2:52:06 AM UserName (Example)                  5/19/2022 2:52:06 AM                                                                                   Managed ml-rg-test
```

Update Online Deployment (asynchronous)

### Example 2: Update Online Deployment (asynchronous) by pipeline
```powershell
Get-AzMLWorkspaceOnlineDeployment -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -EndpointName online-pwsh01 -Name pwshblue01 | Update-AzMLWorkspaceOnlineDeployment -Tag @{'key'='value'}
```

```output
Location Name SystemDataCreatedAt  SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Kind    ResourceGroupName
-------- ---- -------------------  -------------------                 ----------------------- ------------------------ ------------------------ ---------------------------- ----    -----------------
eastus   blue 5/19/2022 2:52:06 AM UserName (Example)                  5/19/2022 2:52:06 AM                                                                                   Managed ml-rg-test
```

Update Online Deployment (asynchronous) by pipeline

